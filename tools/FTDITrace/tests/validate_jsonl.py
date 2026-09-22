#!/usr/bin/env python3
import sys
import os
import glob
import json

def validate_jsonl_file(path):
    print(f"Validating JSONL log: {path}")
    line_count = 0
    event_count = 0
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
                return False
                
            if "meta" in rec:
                meta_type = rec["meta"]
                if meta_type == "start":
                    meta_start = rec
                    assert "version" in rec, f"Line {line_num}: missing version"
                    assert "arch" in rec and rec["arch"] == "win32-x86", f"Line {line_num}: invalid arch"
                    assert "pid" in rec and isinstance(rec["pid"], int), f"Line {line_num}: invalid pid"
                    assert "qpf" in rec and len(rec["qpf"]) == 16, f"Line {line_num}: invalid qpf"
                    assert "session_start_qpc" in rec and len(rec["session_start_qpc"]) == 16, f"Line {line_num}: invalid start qpc"
                    assert "proxy_dll" in rec, f"Line {line_num}: missing proxy_dll"
                    assert "real_dll" in rec, f"Line {line_num}: missing real_dll"
                    assert "utc_start" in rec, f"Line {line_num}: missing utc_start"
                elif meta_type == "stop":
                    meta_stop = rec
                    assert "session_stop_qpc" in rec and len(rec["session_stop_qpc"]) == 16, f"Line {line_num}: invalid stop qpc"
                    assert "total_events_logged" in rec, f"Line {line_num}: missing total_events_logged"
                    assert "total_events_dropped" in rec, f"Line {line_num}: missing total_events_dropped"
                elif meta_type == "dropped_events":
                    assert "dropped_total" in rec, f"Line {line_num}: missing dropped_total"
            else:
                event_count += 1
                # Check required fields
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
                
                # Check QPC hex formatting
                qpc_in = rec["qpc_entry"]
                qpc_out = rec["qpc_exit"]
                assert len(qpc_in) == 16, f"Line {line_num}: qpc_entry must be 16-hex characters: {qpc_in}"
                assert len(qpc_out) == 16, f"Line {line_num}: qpc_exit must be 16-hex characters: {qpc_out}"
                
                val_in = int(qpc_in, 16)
                val_out = int(qpc_out, 16)
                assert val_out >= val_in, f"Line {line_num}: Monotonicity violation: qpc_exit {val_out} < qpc_entry {val_in}"
                
                # Check truncated flag and data length
                assert isinstance(rec["truncated"], bool), f"Line {line_num}: truncated must be bool"
                assert isinstance(rec["data"], list), f"Line {line_num}: data must be list"
                assert len(rec["data"]) == rec["data_len"], f"Line {line_num}: len(data) {len(rec['data'])} != data_len {rec['data_len']}"
                
                if rec["original_data_len"] > 512:
                    assert rec["truncated"] is True, f"Line {line_num}: original_data_len > 512 but truncated is False"
                    assert rec["data_len"] == 512, f"Line {line_num}: data_len != 512 when truncated"
                    
    assert meta_start is not None, "Missing start metadata"
    assert meta_stop is not None, "Missing stop metadata"
    assert meta_stop["total_events_logged"] == event_count, f"Stop metadata count {meta_stop['total_events_logged']} != actual {event_count}"
    
    print(f"  [OK] Validated {line_count} JSONL lines ({event_count} call events). All assertions passed.")
    return True

def main():
    log_dir = sys.argv[1] if len(sys.argv) > 1 else "FTDITrace-Logs"
    files = glob.glob(os.path.join(log_dir, "*.jsonl"))
    if not files:
        print(f"No JSONL files found in {log_dir}")
        sys.exit(1)
        
    all_ok = True
    for f in files:
        if not validate_jsonl_file(f):
            all_ok = False
            
    if all_ok:
        print("ALL JSONL LOGS FULLY VALID!")
        sys.exit(0)
    else:
        print("JSONL VALIDATION FAILED!")
        sys.exit(1)

if __name__ == "__main__":
    main()
