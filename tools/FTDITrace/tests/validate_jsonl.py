#!/usr/bin/env python3
import sys
import os
import glob
import json

def validate_jsonl_file(path):
    print(f"Validating JSONL log: {path}")
    line_count = 0
    d2xx_call_count = 0
    dropped_event_records = 0
    truncation_records = 0
    meta_start = None
    meta_stop = None
    seen_seqs = set()
    
    with open(path, 'r', encoding='utf-8') as f:
        for line_num, line in enumerate(f, 1):
            line = line.strip()
            if not line:
                continue
            line_count += 1
            try:
                rec = json.loads(line)
            except Exception as e:
                print(f"Line {line_num}: JSON parse error: {e}")
                return False, 0, 0, 0, 0
                
            if "meta" in rec:
                meta_type = rec["meta"]
                if meta_type == "start":
                    meta_start = rec
                    assert "version" in rec, f"Line {line_num}: missing version"
                    assert "arch" in rec and rec["arch"] == "win32-x86", f"Line {line_num}: invalid arch"
                    assert "pid" in rec and isinstance(rec["pid"], int), f"Line {line_num}: invalid pid"
                    assert "qpf" in rec and len(rec["qpf"]) == 16, f"Line {line_num}: invalid 64-bit qpf: {rec.get('qpf')}"
                    assert "session_start_qpc" in rec and len(rec["session_start_qpc"]) == 16, f"Line {line_num}: invalid 64-bit start qpc: {rec.get('session_start_qpc')}"
                    assert "proxy_dll" in rec, f"Line {line_num}: missing proxy_dll"
                    assert "real_dll" in rec, f"Line {line_num}: missing real_dll"
                    assert "utc_start" in rec, f"Line {line_num}: missing utc_start"
                elif meta_type == "stop":
                    meta_stop = rec
                    assert "session_stop_qpc" in rec and len(rec["session_stop_qpc"]) == 16, f"Line {line_num}: invalid stop qpc"
                    assert "total_events_logged" in rec, f"Line {line_num}: missing total_events_logged"
                    assert "total_events_dropped" in rec, f"Line {line_num}: missing total_events_dropped"
                elif meta_type == "dropped_events":
                    dropped_event_records += 1
                    assert "dropped_total" in rec, f"Line {line_num}: missing dropped_total"
                    assert rec["dropped_total"] > 0, f"Line {line_num}: dropped_total must be > 0"
            else:
                d2xx_call_count += 1
                # Check required fields (no corrupted records)
                required_fields = [
                    "seq", "event", "tid", "qpc_entry", "qpc_exit", "rel_ms", "dur_ms",
                    "status", "handle", "arg1", "arg2", "arg3", "req_bytes", "act_bytes",
                    "original_data_len", "data_len", "truncated", "data"
                ]
                for rf in required_fields:
                    assert rf in rec, f"Line {line_num}: missing required field {rf}"
                
                # Verify seq uniqueness
                seq = rec["seq"]
                assert isinstance(seq, int) and seq > 0, f"Line {line_num}: invalid seq {seq}"
                assert seq not in seen_seqs, f"Line {line_num}: duplicate seq {seq}"
                seen_seqs.add(seq)
                
                # Check raw 64-bit QPC hex formatting (16 hex chars)
                qpc_in = rec["qpc_entry"]
                qpc_out = rec["qpc_exit"]
                assert len(qpc_in) == 16, f"Line {line_num}: qpc_entry must be 16-hex characters: {qpc_in}"
                assert len(qpc_out) == 16, f"Line {line_num}: qpc_exit must be 16-hex characters: {qpc_out}"
                
                # Check monotonicity
                val_in = int(qpc_in, 16)
                val_out = int(qpc_out, 16)
                assert val_out >= val_in, f"Line {line_num}: Monotonicity violation: qpc_exit {val_out} < qpc_entry {val_in}"
                
                # Check truncated flag and payload length semantics
                assert isinstance(rec["truncated"], bool), f"Line {line_num}: truncated must be bool"
                assert isinstance(rec["data"], list), f"Line {line_num}: data must be list"
                assert len(rec["data"]) == rec["data_len"], f"Line {line_num}: len(data) {len(rec['data'])} != data_len {rec['data_len']}"
                
                if rec["original_data_len"] > 512:
                    assert rec["truncated"] is True, f"Line {line_num}: original_data_len > 512 but truncated is False"
                    assert rec["data_len"] == 512, f"Line {line_num}: data_len != 512 when truncated"
                    truncation_records += 1
                else:
                    assert rec["truncated"] is False, f"Line {line_num}: original_data_len <= 512 but truncated is True"
                    assert rec["data_len"] == rec["original_data_len"], f"Line {line_num}: data_len != original_data_len"
                    
    assert meta_start is not None, "Missing start metadata"
    assert meta_stop is not None, "Missing stop metadata"
    assert meta_stop["total_events_logged"] == d2xx_call_count, f"Stop metadata count {meta_stop['total_events_logged']} != actual {d2xx_call_count}"
    
    print(f"  [OK] File passed: {line_count} records ({d2xx_call_count} D2XX calls, {dropped_event_records} dropped records, {truncation_records} truncation records)")
    return True, line_count, d2xx_call_count, dropped_event_records, truncation_records

def main():
    log_dir = sys.argv[1] if len(sys.argv) > 1 else "FTDITrace-Logs"
    files = sorted(glob.glob(os.path.join(log_dir, "*.jsonl")))
    if not files:
        print(f"No JSONL files found in {log_dir}")
        sys.exit(1)
        
    total_logs = len(files)
    total_records = 0
    total_d2xx_calls = 0
    total_dropped_records = 0
    total_truncation_records = 0
    
    all_ok = True
    for f in files:
        ok, lines, calls, dropped, trunc = validate_jsonl_file(f)
        if not ok:
            all_ok = False
        total_records += lines
        total_d2xx_calls += calls
        total_dropped_records += dropped
        total_truncation_records += trunc
            
    print("\n==================================================")
    print(" JSONL VALIDATION SUMMARY")
    print("==================================================")
    print(f"  number of logs                  : {total_logs}")
    print(f"  number of records               : {total_records}")
    print(f"  number of D2XX calls            : {total_d2xx_calls}")
    print(f"  number of dropped-event records : {total_dropped_records}")
    print(f"  number of truncation records    : {total_truncation_records}")
    print("==================================================")

    if all_ok:
        print("ALL JSONL LOGS FULLY VALID!")
        sys.exit(0)
    else:
        print("JSONL VALIDATION FAILED!")
        sys.exit(1)

if __name__ == "__main__":
    main()
