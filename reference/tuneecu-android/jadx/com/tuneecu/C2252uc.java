package com.tuneecu;

import android.os.Handler;
import android.os.Message;
import java.io.OutputStreamWriter;

/* JADX INFO: renamed from: com.tuneecu.uc */
/* JADX INFO: loaded from: classes.dex */
class C2252uc extends Thread {

    /* JADX INFO: renamed from: b */
    final Handler f8550b;

    /* JADX INFO: renamed from: c */
    final OutputStreamWriter f8551c;

    C2252uc(ActivityC2266vc activityC2266vc, Handler handler, OutputStreamWriter outputStreamWriter) {
        this.f8550b = handler;
        this.f8551c = outputStreamWriter;
        setPriority(5);
    }

    /* JADX WARN: Code duplicated, block: B:116:0x01c2  */
    @Override // java.lang.Thread, java.lang.Runnable
    public void run() {
        Message messageObtainMessage;
        Handler handler;
        boolean z;
        ActivityC2266vc.f8601ud.m5138L((byte) 16);
        ActivityC2266vc.f8601ud.m5152v((byte) 3);
        while (ActivityC2266vc.f8592Xd) {
            int i = ActivityC2266vc.f8584Pd;
            if (i > 0) {
                ActivityC2266vc.m9069Pb(i);
            }
            synchronized (ActivityC2266vc.f8601ud) {
                int iM5146h = ActivityC2266vc.f8601ud.m5146h();
                boolean z2 = true;
                if (iM5146h <= 0 || !ActivityC2266vc.f8589Ud) {
                    z2 = false;
                } else {
                    if (iM5146h > 2048) {
                        iM5146h = 2048;
                    }
                    boolean z3 = ActivityC2307z.f8992vd == EnumC2294y.MODE_DOWNLOAD;
                    boolean z4 = ActivityC2307z.f8931gf;
                    int i2 = ActivityC2266vc.f8573Ed;
                    if (i2 > 0 && ((!z3) & (!z4))) {
                        iM5146h = Math.min(i2, iM5146h);
                    }
                    ActivityC2266vc.f8601ud.m5153x(ActivityC2266vc.f8597ce, iM5146h);
                    MainActivity.m8179Bb(this.f8551c, "< ", ActivityC2266vc.f8597ce, 0, iM5146h, true);
                    int i3 = ActivityC2266vc.f8572Dd;
                    if (i3 > 1536) {
                        int i4 = i3 - ActivityC2266vc.f8575Gd;
                        System.arraycopy(ActivityC2266vc.f8598de, ActivityC2266vc.f8575Gd, ActivityC2266vc.f8598de, 0, i4);
                        ActivityC2266vc.f8575Gd = 0;
                        ActivityC2266vc.f8572Dd = i4;
                    }
                    System.arraycopy(ActivityC2266vc.f8597ce, 0, ActivityC2266vc.f8598de, ActivityC2266vc.f8572Dd, iM5146h);
                    int i5 = ActivityC2266vc.f8572Dd;
                    ActivityC2266vc.f8572Dd = i5 + iM5146h;
                    if (MainActivity.f6871C5) {
                        if (ActivityC2266vc.f8572Dd >= ActivityC2266vc.f8575Gd + iM5146h) {
                            int i6 = ActivityC2266vc.f8572Dd - 1;
                            if (ActivityC2266vc.f8598de[i6] == 62) {
                                ActivityC2266vc.f8598de[i6] = 0;
                                ActivityC2266vc.f8573Ed = ActivityC2266vc.f8572Dd - ActivityC2266vc.f8575Gd;
                                this.f8550b.sendMessage(this.f8550b.obtainMessage(2));
                            } else if (ActivityC2266vc.f8598de[i6] == 13) {
                                ActivityC2266vc.f8575Gd += iM5146h;
                            }
                        }
                        z2 = false;
                    } else if (z4) {
                        if ((ActivityC2307z.f8992vd == EnumC2294y.MODE_WALBRO_SENSORS) && ActivityC2266vc.f8591Wd) {
                            if (i5 == 0) {
                                ActivityC2266vc.f8575Gd = 0;
                            }
                            for (int i7 = ActivityC2266vc.f8575Gd; i7 < iM5146h; i7++) {
                                int i8 = i5 + i7;
                                if (ActivityC2266vc.f8598de[i8] == 58) {
                                    ActivityC2266vc.f8575Gd = i8;
                                    break;
                                }
                            }
                            byte[] bArr = ActivityC2266vc.f8598de;
                            int i9 = ActivityC2266vc.f8575Gd;
                            if (bArr[i9] == 58) {
                                while (true) {
                                    i9++;
                                    if (i9 < ActivityC2266vc.f8572Dd) {
                                        if (ActivityC2266vc.f8598de[i9] == 58) {
                                            ActivityC2266vc.f8573Ed = i9 - ActivityC2266vc.f8575Gd;
                                            ActivityC2266vc.f8572Dd = 0;
                                            z = true;
                                        }
                                    }
                                }
                            }
                            z = false;
                        } else if (ActivityC2307z.f8992vd == EnumC2294y.MODE_WALBRO_ERASING) {
                            int i10 = ActivityC2266vc.f8572Dd;
                            int i11 = ActivityC2266vc.f8575Gd;
                            int i12 = ActivityC2266vc.f8573Ed;
                            if (i10 < i11 + i12 || i12 != 4) {
                                if (i5 == 0 && ActivityC2266vc.f8598de[0] != 4) {
                                    ActivityC2266vc.f8575Gd++;
                                }
                                if (ActivityC2266vc.f8572Dd < ActivityC2266vc.f8575Gd + ActivityC2266vc.f8573Ed || ActivityC2266vc.f8598de[ActivityC2266vc.f8575Gd] != 4) {
                                    z = false;
                                }
                            }
                            z = true;
                        } else if (ActivityC2307z.f8992vd == EnumC2294y.MODE_WALBRO_ERASED) {
                            if (ActivityC2266vc.f8572Dd < ActivityC2266vc.f8575Gd + ActivityC2266vc.f8573Ed || ActivityC2266vc.f8598de[ActivityC2266vc.f8575Gd] != 4) {
                                z = false;
                            } else {
                                z = true;
                            }
                        } else if (ActivityC2307z.f8992vd != EnumC2294y.MODE_WALBRO_DOWNLOAD) {
                            int i13 = ActivityC2266vc.f8572Dd;
                            int i14 = ActivityC2266vc.f8575Gd;
                            int i15 = ActivityC2266vc.f8573Ed;
                            if (i13 < i14 + i15 || i15 <= 0) {
                                z = false;
                            } else {
                                z = true;
                            }
                        } else if (ActivityC2266vc.f8573Ed > 2) {
                            int i16 = ActivityC2266vc.f8575Gd;
                            while (i16 < ActivityC2266vc.f8572Dd && ActivityC2266vc.f8598de[i16] != -16) {
                                i16++;
                            }
                            if ((i16 - ActivityC2266vc.f8575Gd > 2) && (i16 < ActivityC2266vc.f8572Dd)) {
                                ActivityC2266vc.f8575Gd = i16 - 3;
                                z = true;
                            } else {
                                z = false;
                            }
                        } else if (ActivityC2266vc.f8572Dd >= ActivityC2266vc.f8575Gd + 1) {
                            ActivityC2266vc.f8575Gd = ActivityC2266vc.f8572Dd - 1;
                            z = true;
                        } else {
                            z = false;
                        }
                        if (z) {
                            this.f8550b.sendMessage(this.f8550b.obtainMessage(1));
                        }
                        z2 = z;
                    } else if (ActivityC2307z.f8827Lf || z3) {
                        int i17 = ActivityC2266vc.f8575Gd + ActivityC2266vc.f8573Ed;
                        if (ActivityC2266vc.f8572Dd >= i17 + 4) {
                            if (ActivityC2307z.f8992vd == EnumC2294y.MODE_INIT) {
                                while ((ActivityC2266vc.f8598de[i17] & 128) == 0 && ActivityC2266vc.f8572Dd > i17) {
                                    i17++;
                                }
                            }
                            int i18 = (ActivityC2266vc.f8598de[i17] & 127) == 0 ? (ActivityC2266vc.f8598de[i17 + 3] & 255) + 5 : (ActivityC2266vc.f8598de[i17] & 127) + 4;
                            if (ActivityC2266vc.f8572Dd >= i17 + i18) {
                                boolean unused = ActivityC2266vc.f8587Sd = false;
                                ActivityC2266vc.f8575Gd = i17;
                                ActivityC2266vc.f8573Ed = i18;
                                messageObtainMessage = this.f8550b.obtainMessage(1);
                                handler = this.f8550b;
                                handler.sendMessage(messageObtainMessage);
                            }
                        }
                    } else {
                        if ((ActivityC2266vc.f8573Ed < 0) & (ActivityC2266vc.f8572Dd > ActivityC2266vc.f8575Gd)) {
                            if ((ActivityC2266vc.f8598de[ActivityC2266vc.f8575Gd] & 127) != 0) {
                                ActivityC2266vc.f8573Ed = (ActivityC2266vc.f8598de[ActivityC2266vc.f8575Gd] & 127) + 4;
                            } else if (ActivityC2266vc.f8572Dd > ActivityC2266vc.f8575Gd + 3) {
                                ActivityC2266vc.f8573Ed = (ActivityC2266vc.f8598de[ActivityC2266vc.f8575Gd + 3] & 255) + 5;
                            }
                        }
                        int i19 = ActivityC2266vc.f8572Dd;
                        int i20 = ActivityC2266vc.f8575Gd;
                        int i21 = ActivityC2266vc.f8573Ed;
                        if (i19 >= i20 + i21 && i21 > 0) {
                            if (ActivityC2266vc.f8587Sd) {
                                ActivityC2266vc.f8575Gd += ActivityC2266vc.f8573Ed;
                                boolean unused2 = ActivityC2266vc.f8587Sd = false;
                                ActivityC2266vc.f8573Ed = ActivityC2266vc.f8606zd;
                            } else {
                                messageObtainMessage = this.f8550b.obtainMessage(1);
                                handler = this.f8550b;
                                handler.sendMessage(messageObtainMessage);
                            }
                        }
                    }
                }
                if (!z2 && System.currentTimeMillis() > ActivityC2266vc.f8595ae + 160) {
                    this.f8550b.sendMessage(this.f8550b.obtainMessage(0));
                }
            }
        }
    }
}
