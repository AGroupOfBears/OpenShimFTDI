package p053b.p054a.p055a;

import android.app.PendingIntent;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.hardware.usb.UsbDevice;
import android.hardware.usb.UsbManager;
import android.util.Log;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/* JADX INFO: renamed from: b.a.a.g */
/* JADX INFO: loaded from: classes.dex */
public class C1143g {

    /* JADX INFO: renamed from: c */
    private static C1143g f3906c = null;

    /* JADX INFO: renamed from: d */
    private static boolean f3907d = true;

    /* JADX INFO: renamed from: e */
    private static Context f3908e;

    /* JADX INFO: renamed from: f */
    private static PendingIntent f3909f;

    /* JADX INFO: renamed from: g */
    private static IntentFilter f3910g;

    /* JADX INFO: renamed from: i */
    private static UsbManager f3912i;

    /* JADX INFO: renamed from: a */
    private ArrayList f3914a;

    /* JADX INFO: renamed from: b */
    private BroadcastReceiver f3915b = new C1138b(this);

    /* JADX INFO: renamed from: h */
    private static List f3911h = new ArrayList(Arrays.asList(new C1156t(1027, 24597), new C1156t(1027, 24596), new C1156t(1027, 24593), new C1156t(1027, 24592), new C1156t(1027, 24577), new C1156t(1027, 24582), new C1156t(1027, 24604), new C1156t(1027, 64193), new C1156t(1027, 64194), new C1156t(1027, 64195), new C1156t(1027, 64196), new C1156t(1027, 64197), new C1156t(1027, 64198), new C1156t(1027, 24594), new C1156t(2220, 4133), new C1156t(5590, 1), new C1156t(1027, 24599)));

    /* JADX INFO: renamed from: j */
    private static BroadcastReceiver f3913j = new C1139c();

    private C1143g(Context context) throws C1140d {
        Log.v("D2xx::", "Start constructor");
        if (context == null) {
            throw new C1140d("D2xx init failed: Can not find parentContext!");
        }
        m5100q(context);
        if (!m5096h()) {
            throw new C1140d("D2xx init failed: Can not find UsbManager!");
        }
        this.f3914a = new ArrayList();
        IntentFilter intentFilter = new IntentFilter();
        intentFilter.addAction("android.hardware.usb.action.USB_DEVICE_ATTACHED");
        intentFilter.addAction("android.hardware.usb.action.USB_DEVICE_DETACHED");
        context.getApplicationContext().registerReceiver(this.f3915b, intentFilter);
        Log.v("D2xx::", "End constructor");
    }

    /* JADX INFO: renamed from: d */
    private boolean m5093d(UsbDevice usbDevice) {
        if (!f3912i.hasPermission(usbDevice)) {
            f3912i.requestPermission(usbDevice, f3909f);
        }
        return f3912i.hasPermission(usbDevice);
    }

    /* JADX INFO: renamed from: e */
    private void m5094e() {
        synchronized (this.f3914a) {
            int size = this.f3914a.size();
            for (int i = 0; i < size; i++) {
                this.f3914a.remove(0);
            }
        }
    }

    /* JADX INFO: Access modifiers changed from: private */
    /* JADX INFO: renamed from: g */
    public C1145i m5095g(UsbDevice usbDevice) {
        C1145i c1145i;
        synchronized (this.f3914a) {
            int size = this.f3914a.size();
            for (int i = 0; i < size; i++) {
                C1145i c1145i2 = (C1145i) this.f3914a.get(i);
                if (c1145i2.m5147i().equals(usbDevice)) {
                    c1145i = c1145i2;
                }
            }
            c1145i = null;
        }
        return c1145i;
    }

    /* JADX INFO: renamed from: h */
    private static boolean m5096h() {
        Context context;
        if (f3912i == null && (context = f3908e) != null) {
            f3912i = (UsbManager) context.getApplicationContext().getSystemService("usb");
        }
        return f3912i != null;
    }

    /* JADX INFO: renamed from: j */
    public static synchronized C1143g m5097j(Context context) {
        if (f3906c == null) {
            f3906c = new C1143g(context);
        }
        if (context != null) {
            m5100q(context);
        }
        return f3906c;
    }

    /* JADX INFO: renamed from: l */
    private boolean m5098l(UsbDevice usbDevice) {
        if (f3907d && !f3912i.hasPermission(usbDevice)) {
            f3912i.requestPermission(usbDevice, f3909f);
        }
        return f3912i.hasPermission(usbDevice);
    }

    /* JADX INFO: renamed from: p */
    private boolean m5099p(Context context, C1145i c1145i, C1141e c1141e) {
        if (c1145i == null || context == null) {
            return false;
        }
        c1145i.m5133G(context);
        if (c1141e != null) {
            c1145i.m5135I(c1141e);
        }
        return c1145i.m5151u(f3912i) && c1145i.m5150t();
    }

    /* JADX INFO: renamed from: q */
    private static synchronized boolean m5100q(Context context) {
        if (context == null) {
            return false;
        }
        if (f3908e != context) {
            f3908e = context;
            f3909f = PendingIntent.getBroadcast(context.getApplicationContext(), 0, new Intent("com.ftdi.j2xx"), 134217728);
            f3910g = new IntentFilter("com.ftdi.j2xx");
            f3908e.getApplicationContext().registerReceiver(f3913j, f3910g);
        }
        return true;
    }

    /* JADX INFO: renamed from: c */
    public int m5101c(UsbDevice usbDevice) {
        if (!m5104k(usbDevice)) {
            return 0;
        }
        int interfaceCount = usbDevice.getInterfaceCount();
        int i = 0;
        for (int i2 = 0; i2 < interfaceCount; i2++) {
            if (m5093d(usbDevice)) {
                synchronized (this.f3914a) {
                    C1145i c1145iM5095g = m5095g(usbDevice);
                    if (c1145iM5095g == null) {
                        c1145iM5095g = new C1145i(f3908e, f3912i, usbDevice, usbDevice.getInterface(i2));
                    } else {
                        c1145iM5095g.m5133G(f3908e);
                        this.f3914a.remove(c1145iM5095g);
                    }
                    this.f3914a.add(c1145iM5095g);
                    i++;
                }
            }
        }
        return i;
    }

    /* JADX INFO: renamed from: f */
    public int m5102f(Context context) {
        int size;
        ArrayList arrayList = new ArrayList();
        if (context == null) {
            return 0;
        }
        m5100q(context);
        for (UsbDevice usbDevice : f3912i.getDeviceList().values()) {
            if (m5104k(usbDevice)) {
                int interfaceCount = usbDevice.getInterfaceCount();
                for (int i = 0; i < interfaceCount; i++) {
                    if (m5098l(usbDevice)) {
                        synchronized (this.f3914a) {
                            C1145i c1145iM5095g = m5095g(usbDevice);
                            if (c1145iM5095g == null) {
                                c1145iM5095g = new C1145i(context, f3912i, usbDevice, usbDevice.getInterface(i));
                            } else {
                                this.f3914a.remove(c1145iM5095g);
                                c1145iM5095g.m5133G(context);
                            }
                            arrayList.add(c1145iM5095g);
                        }
                    }
                }
            }
        }
        synchronized (this.f3914a) {
            m5094e();
            this.f3914a = arrayList;
            size = arrayList.size();
        }
        return size;
    }

    /* JADX INFO: renamed from: i */
    public synchronized int m5103i(int i, C1142f[] c1142fArr) {
        for (int i2 = 0; i2 < i; i2++) {
            c1142fArr[i2] = ((C1145i) this.f3914a.get(i2)).f3927l;
        }
        return this.f3914a.size();
    }

    /* JADX INFO: renamed from: k */
    public boolean m5104k(UsbDevice usbDevice) {
        if (f3908e == null) {
            return false;
        }
        C1156t c1156t = new C1156t(usbDevice.getVendorId(), usbDevice.getProductId());
        boolean zContains = f3911h.contains(c1156t);
        Log.v("D2xx::", c1156t.toString());
        return zContains;
    }

    /* JADX INFO: renamed from: m */
    public synchronized C1145i m5105m(Context context, int i) {
        return m5106n(context, i, null);
    }

    /* JADX INFO: renamed from: n */
    public synchronized C1145i m5106n(Context context, int i, C1141e c1141e) {
        if (i < 0) {
            return null;
        }
        if (context == null) {
            return null;
        }
        m5100q(context);
        C1145i c1145i = (C1145i) this.f3914a.get(i);
        return m5099p(context, c1145i, c1141e) ? c1145i : null;
    }

    /* JADX INFO: renamed from: o */
    public boolean m5107o(int i, int i2) {
        String str;
        if (i == 0 || i2 == 0) {
            str = "Invalid parameter to setVIDPID";
        } else {
            C1156t c1156t = new C1156t(i, i2);
            if (f3911h.contains(c1156t)) {
                Log.i("D2xx::", "Existing vid:" + i + "  pid:" + i2);
                return true;
            }
            if (f3911h.add(c1156t)) {
                return true;
            }
            str = "Failed to add VID/PID combination to list.";
        }
        Log.d("D2xx::", str);
        return false;
    }
}
