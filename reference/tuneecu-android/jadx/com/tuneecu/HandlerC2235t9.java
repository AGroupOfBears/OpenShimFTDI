package com.tuneecu;

import android.os.Handler;
import android.os.Message;
import android.util.Log;

/* JADX INFO: renamed from: com.tuneecu.t9 */
/* JADX INFO: loaded from: classes.dex */
class HandlerC2235t9 extends Handler {

    /* JADX INFO: renamed from: a */
    final /* synthetic */ MainActivity f8529a;

    HandlerC2235t9(MainActivity mainActivity) {
        this.f8529a = mainActivity;
    }

    @Override // android.os.Handler
    public void handleMessage(Message message) {
        Boolean bool = Boolean.TRUE;
        int i = message.what;
        if (i != 1) {
            if (i == 2) {
                try {
                    this.f8529a.m8402W5(message.obj.toString());
                    return;
                } catch (Exception e) {
                    if (MainActivity.f6988P5) {
                        Log.e("MainActivity", Log.getStackTraceString(e));
                        return;
                    }
                    return;
                }
            }
            if (i != 4) {
                if (i != 5) {
                    return;
                }
                this.f8529a.m8792r6(message.getData().getString("toast"), 0, bool);
                return;
            }
            MainActivity.f6898F5 = true;
            boolean unused = MainActivity.f7212o5 = false;
            String unused2 = MainActivity.f7140g5 = message.getData().getString("device_name");
            this.f8529a.m8792r6(this.f8529a.getText(R.string.connected_to).toString() + " " + MainActivity.f7140g5, 0, bool);
            return;
        }
        if (MainActivity.f6988P5) {
            Log.i("MainActivity", "MESSAGE_STATE_CHANGE: " + message.arg1);
        }
        int i2 = message.arg1;
        if (i2 == 0 || i2 == 1) {
            MainActivity.f6916H5 = false;
            if (MainActivity.f6898F5 && (!MainActivity.f7212o5)) {
                MainActivity.f7249s6.m8103o(false);
                this.f8529a.m8782n6(false);
                try {
                    Thread.sleep(1000L);
                } catch (InterruptedException e2) {
                    if (MainActivity.f6988P5) {
                        Log.e("MainActivity", Log.getStackTraceString(e2));
                    }
                }
                MainActivity mainActivity = this.f8529a;
                mainActivity.m8792r6(mainActivity.getText(R.string.connection_terminated).toString(), 0, bool);
            } else if (MainActivity.f7212o5) {
                if (MainActivity.f7309z5) {
                    if (MainActivity.f6939Ja == 20) {
                        this.f8529a.m8782n6(true);
                    } else {
                        this.f8529a.m8426Y5(null, 0);
                    }
                } else if (this.f8529a.f7317A == null) {
                    MainActivity.f7249s6.m8103o(false);
                    boolean unused3 = MainActivity.f7212o5 = false;
                    this.f8529a.m8787o9();
                    ActivityC2266vc.f8592Xd = false;
                    MainActivity.m8169Ab(7, "");
                    MainActivity mainActivity2 = this.f8529a;
                    mainActivity2.m8792r6(mainActivity2.getText(R.string.unable_connect).toString(), 0, bool);
                } else if (!MainActivity.f6938J9) {
                    this.f8529a.f7317A = null;
                }
            }
            this.f8529a.m8579m7();
        } else {
            if (i2 == 2) {
                LedBar.m8101n(true);
                ActivityC2307z.m9135Ne(EnumC2294y.MODE_NULL);
                LedBar.m8097j(3);
                boolean unused4 = MainActivity.f7212o5 = true;
                MainActivity.f6938J9 = true;
                return;
            }
            if (i2 != 3) {
                return;
            }
            MainActivity.m8169Ab(6, "");
            MainActivity.f6916H5 = false;
            LedBar.m8097j(0);
            MainActivity mainActivity3 = this.f8529a;
            mainActivity3.f7317A = mainActivity3.f7592z;
            MainActivity.f6939Ja = MainActivity.f6930Ia;
            MainActivity.m8169Ab(5, MainActivity.f7209nb);
            ActivityC2307z.m9135Ne(EnumC2294y.MODE_NULL);
            ActivityC2266vc.m9072Ub(8);
            if (MainActivity.f6929I9 && !MainActivity.f6934J5) {
                this.f8529a.m8296M7();
            }
            MainActivity.f7204n6.m9080Vb();
            boolean unused5 = MainActivity.f7265u6 = true;
        }
        this.f8529a.m8787o9();
    }
}
