package com.tuneecu;

import android.os.Handler;
import android.os.Message;

/* JADX INFO: renamed from: com.tuneecu.rc */
/* JADX INFO: loaded from: classes.dex */
class HandlerC2210rc extends Handler {

    /* JADX INFO: renamed from: a */
    final /* synthetic */ ActivityC2266vc f8309a;

    HandlerC2210rc(ActivityC2266vc activityC2266vc) {
        this.f8309a = activityC2266vc;
    }

    @Override // android.os.Handler
    public void handleMessage(Message message) {
        int i = message.what;
        if (i == 0) {
            long unused = ActivityC2266vc.f8595ae = System.currentTimeMillis();
            this.f8309a.m9067Lb();
            return;
        }
        if (i != 1) {
            if (i == 2) {
                ActivityC2266vc.f8600fe.m8779m8(ActivityC2266vc.f8598de);
                return;
            }
            return;
        }
        MainActivity.m8179Bb(MainActivity.f7211nd, ": ", ActivityC2266vc.f8598de, ActivityC2266vc.f8575Gd, ActivityC2266vc.f8573Ed, true);
        if (!ActivityC2307z.f8931gf) {
            ActivityC2307z.m9133Nc(ActivityC2266vc.f8598de, ActivityC2266vc.f8575Gd, ActivityC2266vc.f8573Ed, ActivityC2266vc.f8587Sd);
            ActivityC2266vc.f8569Ad = 0;
        } else if (ActivityC2307z.m9141Pc(ActivityC2266vc.f8598de, ActivityC2266vc.f8575Gd, ActivityC2266vc.f8573Ed)) {
            ActivityC2266vc.f8571Cd = 0;
            ActivityC2266vc.f8569Ad = 0;
            if (ActivityC2266vc.f8591Wd) {
                long unused2 = ActivityC2266vc.f8595ae = System.currentTimeMillis();
            }
        }
    }
}
