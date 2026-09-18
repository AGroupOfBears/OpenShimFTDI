package p053b.p054a.p055a;

import android.content.Context;
import android.hardware.usb.UsbDevice;
import android.hardware.usb.UsbDeviceConnection;
import android.hardware.usb.UsbEndpoint;
import android.hardware.usb.UsbInterface;
import android.hardware.usb.UsbManager;
import android.hardware.usb.UsbRequest;
import android.util.Log;
import java.nio.ByteBuffer;
import java.nio.ByteOrder;

/* JADX INFO: renamed from: b.a.a.i */
/* JADX INFO: loaded from: classes.dex */
public class C1145i {

    /* JADX INFO: renamed from: a */
    long f3916a;

    /* JADX INFO: renamed from: b */
    Boolean f3917b;

    /* JADX INFO: renamed from: c */
    UsbDevice f3918c;

    /* JADX INFO: renamed from: d */
    UsbInterface f3919d;

    /* JADX INFO: renamed from: e */
    UsbEndpoint f3920e;

    /* JADX INFO: renamed from: f */
    UsbEndpoint f3921f;

    /* JADX INFO: renamed from: g */
    private UsbRequest f3922g;

    /* JADX INFO: renamed from: h */
    private UsbDeviceConnection f3923h;

    /* JADX INFO: renamed from: i */
    private RunnableC1137a f3924i;

    /* JADX INFO: renamed from: j */
    private Thread f3925j;

    /* JADX INFO: renamed from: k */
    private Thread f3926k;

    /* JADX INFO: renamed from: l */
    C1142f f3927l;

    /* JADX INFO: renamed from: m */
    private C1158v f3928m;

    /* JADX INFO: renamed from: n */
    private C1154r f3929n;

    /* JADX INFO: renamed from: o */
    C1160x f3930o;

    /* JADX INFO: renamed from: p */
    private C1141e f3931p = new C1141e();

    /* JADX INFO: renamed from: q */
    private int f3932q;

    /* JADX INFO: renamed from: r */
    Context f3933r;

    /* JADX INFO: renamed from: s */
    private int f3934s;

    public C1145i(Context context, UsbManager usbManager, UsbDevice usbDevice, UsbInterface usbInterface) {
        C1154r c1148l;
        C1142f c1142f;
        String str;
        this.f3932q = 0;
        byte[] bArr = new byte[255];
        this.f3933r = context;
        try {
            this.f3918c = usbDevice;
            this.f3919d = usbInterface;
            this.f3920e = null;
            this.f3921f = null;
            this.f3934s = 0;
            this.f3930o = new C1160x();
            this.f3927l = new C1142f();
            this.f3922g = new UsbRequest();
            m5132F(usbManager.openDevice(this.f3918c));
            if (m5142d() == null) {
                Log.e("FTDI_Device::", "Failed to open the device!");
                throw new C1140d("Failed to open the device!");
            }
            m5142d().claimInterface(this.f3919d, false);
            byte[] rawDescriptors = m5142d().getRawDescriptors();
            int deviceId = this.f3918c.getDeviceId();
            int id = this.f3919d.getId() + 1;
            this.f3932q = id;
            this.f3927l.f3900f = (deviceId << 4) | (id & 15);
            ByteBuffer byteBufferAllocate = ByteBuffer.allocate(2);
            byteBufferAllocate.order(ByteOrder.LITTLE_ENDIAN);
            byteBufferAllocate.put(rawDescriptors[12]);
            byteBufferAllocate.put(rawDescriptors[13]);
            this.f3927l.f3896b = byteBufferAllocate.getShort(0);
            C1142f c1142f2 = this.f3927l;
            c1142f2.f3898d = rawDescriptors[16];
            c1142f2.f3901g = m5142d().getSerial();
            this.f3927l.f3899e = (this.f3918c.getVendorId() << 16) | this.f3918c.getProductId();
            this.f3927l.f3903i = 8;
            m5142d().controlTransfer(-128, 6, rawDescriptors[15] | 768, 0, bArr, 255, 0);
            this.f3927l.f3902h = m5117O(bArr);
            C1142f c1142f3 = this.f3927l;
            switch (c1142f3.f3896b & 65280) {
                case 512:
                    if (c1142f3.f3898d == 0) {
                        this.f3929n = new C1149m(this);
                        c1142f3.f3897c = 0;
                    } else {
                        c1142f3.f3897c = 1;
                        c1148l = new C1148l(this);
                        this.f3929n = c1148l;
                    }
                    break;
                case 1024:
                    this.f3929n = new C1149m(this);
                    c1142f3.f3897c = 0;
                    break;
                case 1280:
                    this.f3929n = new C1147k(this);
                    this.f3927l.f3897c = 4;
                    m5118b();
                    break;
                case 1536:
                    C1154r c1154r = new C1154r(this);
                    this.f3929n = c1154r;
                    short sM5159c = (short) (c1154r.m5159c((short) 0) & 1);
                    this.f3929n = null;
                    if (sM5159c == 0) {
                        this.f3927l.f3897c = 5;
                        c1148l = new C1151o(this);
                    } else {
                        this.f3927l.f3897c = 5;
                        c1148l = new C1152p(this);
                    }
                    this.f3929n = c1148l;
                    break;
                case 1792:
                    c1142f3.f3897c = 6;
                    c1142f3.f3895a = 2;
                    m5118b();
                    c1148l = new C1146j(this);
                    this.f3929n = c1148l;
                    break;
                case 2048:
                    c1142f3.f3897c = 7;
                    c1142f3.f3895a = 2;
                    m5118b();
                    c1148l = new C1153q(this);
                    this.f3929n = c1148l;
                    break;
                case 2304:
                    c1142f3.f3897c = 8;
                    c1142f3.f3895a = 2;
                    c1148l = new C1150n(this);
                    this.f3929n = c1148l;
                    break;
                case 4096:
                    c1142f3.f3897c = 9;
                    c1148l = new C1155s(this);
                    this.f3929n = c1148l;
                    break;
                case 5888:
                    c1142f3.f3897c = 12;
                    c1142f3.f3895a = 2;
                    break;
                case 6144:
                    c1142f3.f3897c = 10;
                    if (this.f3932q == 1) {
                        c1142f3.f3895a = 2;
                    } else {
                        c1142f3.f3895a = 0;
                    }
                    break;
                case 6400:
                    c1142f3.f3897c = 11;
                    int i = this.f3932q;
                    if (i == 4) {
                        int maxPacketSize = this.f3918c.getInterface(i - 1).getEndpoint(0).getMaxPacketSize();
                        Log.e("dev", "mInterfaceID : " + this.f3932q + "   iMaxPacketSize : " + maxPacketSize);
                        if (maxPacketSize == 8) {
                            c1142f3 = this.f3927l;
                            c1142f3.f3895a = 0;
                        } else {
                            c1142f3 = this.f3927l;
                        }
                    }
                    c1142f3.f3895a = 2;
                    break;
                default:
                    c1142f3.f3897c = 3;
                    c1148l = new C1154r(this);
                    this.f3929n = c1148l;
                    break;
            }
            C1142f c1142f4 = this.f3927l;
            int i2 = c1142f4.f3896b & 65280;
            if ((i2 == 5888 || i2 == 6144 || i2 == 6400) && c1142f4.f3901g == null) {
                byte[] bArr2 = new byte[16];
                m5142d().controlTransfer(-64, 144, 0, 27, bArr2, 16, 0);
                String str2 = "";
                for (int i3 = 0; i3 < 8; i3++) {
                    str2 = String.valueOf(str2) + ((char) bArr2[i3 * 2]);
                }
                this.f3927l.f3901g = new String(str2);
            }
            C1142f c1142f5 = this.f3927l;
            int i4 = c1142f5.f3896b & 65280;
            if (i4 == 6144 || i4 == 6400) {
                int i5 = this.f3932q;
                if (i5 == 1) {
                    c1142f5.f3902h = String.valueOf(c1142f5.f3902h) + " A";
                    c1142f = this.f3927l;
                    str = String.valueOf(c1142f.f3901g) + "A";
                } else if (i5 == 2) {
                    c1142f5.f3902h = String.valueOf(c1142f5.f3902h) + " B";
                    c1142f = this.f3927l;
                    str = String.valueOf(c1142f.f3901g) + "B";
                } else if (i5 == 3) {
                    c1142f5.f3902h = String.valueOf(c1142f5.f3902h) + " C";
                    c1142f = this.f3927l;
                    str = String.valueOf(c1142f.f3901g) + "C";
                } else if (i5 == 4) {
                    c1142f5.f3902h = String.valueOf(c1142f5.f3902h) + " D";
                    c1142f = this.f3927l;
                    str = String.valueOf(c1142f.f3901g) + "D";
                }
                c1142f.f3901g = str;
            }
            m5142d().releaseInterface(this.f3919d);
            m5142d().close();
            m5132F(null);
            m5115E();
        } catch (Exception e) {
            if (e.getMessage() != null) {
                Log.e("FTDI_Device::", e.getMessage());
            }
        }
    }

    /* JADX INFO: renamed from: B */
    private boolean m5114B(int i) {
        return m5150t() && m5142d().controlTransfer(64, 4, this.f3927l.f3903i | i, this.f3932q, null, 0, 0) == 0;
    }

    /* JADX INFO: renamed from: E */
    private synchronized void m5115E() {
        this.f3917b = Boolean.FALSE;
        this.f3927l.f3895a &= 2;
    }

    /* JADX INFO: renamed from: M */
    private synchronized void m5116M() {
        this.f3917b = Boolean.TRUE;
        this.f3927l.f3895a |= 1;
    }

    /* JADX INFO: renamed from: O */
    private final String m5117O(byte[] bArr) {
        return new String(bArr, 2, bArr[0] - 2, "UTF-16LE");
    }

    /* JADX INFO: renamed from: b */
    private void m5118b() {
        C1142f c1142f;
        StringBuilder sb;
        String str;
        int i = this.f3932q;
        if (i == 1) {
            C1142f c1142f2 = this.f3927l;
            c1142f2.f3901g = String.valueOf(c1142f2.f3901g) + "A";
            c1142f = this.f3927l;
            sb = new StringBuilder(String.valueOf(c1142f.f3902h));
            str = " A";
        } else if (i == 2) {
            C1142f c1142f3 = this.f3927l;
            c1142f3.f3901g = String.valueOf(c1142f3.f3901g) + "B";
            c1142f = this.f3927l;
            sb = new StringBuilder(String.valueOf(c1142f.f3902h));
            str = " B";
        } else if (i == 3) {
            C1142f c1142f4 = this.f3927l;
            c1142f4.f3901g = String.valueOf(c1142f4.f3901g) + "C";
            c1142f = this.f3927l;
            sb = new StringBuilder(String.valueOf(c1142f.f3902h));
            str = " C";
        } else {
            if (i != 4) {
                return;
            }
            C1142f c1142f5 = this.f3927l;
            c1142f5.f3901g = String.valueOf(c1142f5.f3901g) + "D";
            c1142f = this.f3927l;
            sb = new StringBuilder(String.valueOf(c1142f.f3902h));
            str = " D";
        }
        sb.append(str);
        c1142f.f3902h = sb.toString();
    }

    /* JADX INFO: renamed from: c */
    private boolean m5119c() {
        for (int i = 0; i < this.f3919d.getEndpointCount(); i++) {
            Log.i("FTDI_Device::", "EP: " + String.format("0x%02X", Integer.valueOf(this.f3919d.getEndpoint(i).getAddress())));
            if (this.f3919d.getEndpoint(i).getType() != 2) {
                Log.i("FTDI_Device::", "Not Bulk Endpoint");
            } else if (this.f3919d.getEndpoint(i).getDirection() == 128) {
                UsbEndpoint endpoint = this.f3919d.getEndpoint(i);
                this.f3921f = endpoint;
                this.f3934s = endpoint.getMaxPacketSize();
            } else {
                this.f3920e = this.f3919d.getEndpoint(i);
            }
        }
        return (this.f3920e == null || this.f3921f == null) ? false : true;
    }

    /* JADX INFO: renamed from: j */
    private final boolean m5120j() {
        return m5123m() || m5121k() || m5126p() || m5122l() || m5148q() || m5125o() || m5124n();
    }

    /* JADX INFO: renamed from: k */
    private final boolean m5121k() {
        return (this.f3927l.f3896b & 65280) == 1280;
    }

    /* JADX INFO: renamed from: l */
    private final boolean m5122l() {
        return (this.f3927l.f3896b & 65280) == 1792;
    }

    /* JADX INFO: renamed from: m */
    private final boolean m5123m() {
        C1142f c1142f = this.f3927l;
        short s = c1142f.f3896b;
        if ((s & 65280) != 1024) {
            return (s & 65280) == 512 && c1142f.f3898d == 0;
        }
        return true;
    }

    /* JADX INFO: renamed from: n */
    private final boolean m5124n() {
        return (this.f3927l.f3896b & 65280) == 4096;
    }

    /* JADX INFO: renamed from: o */
    private final boolean m5125o() {
        return (this.f3927l.f3896b & 65280) == 2304;
    }

    /* JADX INFO: renamed from: p */
    private final boolean m5126p() {
        return (this.f3927l.f3896b & 65280) == 1536;
    }

    /* JADX INFO: renamed from: r */
    private final boolean m5127r() {
        return m5125o() || m5122l() || m5148q();
    }

    /* JADX INFO: renamed from: w */
    private boolean m5128w(boolean z, boolean z2) {
        if (!m5150t()) {
            return false;
        }
        if (z) {
            int iControlTransfer = 0;
            for (int i = 0; i < 6; i++) {
                iControlTransfer = m5142d().controlTransfer(64, 0, 1, this.f3932q, null, 0, 0);
            }
            if (iControlTransfer > 0) {
                return false;
            }
            this.f3928m.m5181m();
        }
        return z2 && m5142d().controlTransfer(64, 0, 2, this.f3932q, null, 0, 0) == 0;
    }

    /* JADX INFO: renamed from: A */
    public boolean m5129A(byte b2, byte b3) {
        int i = this.f3927l.f3897c;
        if (!m5150t() || i == 1) {
            return false;
        }
        if (i != 0 || b3 == 0) {
            if (i != 4 || b3 == 0) {
                if (i != 5 || b3 == 0) {
                    if (i != 6 || b3 == 0) {
                        if (i != 7 || b3 == 0) {
                            if (i == 8 && b3 != 0 && b3 > 64) {
                                return false;
                            }
                        } else {
                            if ((b3 & 7) == 0) {
                                return false;
                            }
                            if ((b3 == 2) & (this.f3919d.getId() != 0) & (this.f3919d.getId() != 1)) {
                                return false;
                            }
                        }
                    } else {
                        if ((b3 & 95) == 0) {
                            return false;
                        }
                        if (((b3 & 72) > 0) & (this.f3919d.getId() != 0)) {
                            return false;
                        }
                    }
                } else if ((b3 & 37) == 0) {
                    return false;
                }
            } else {
                if ((b3 & 31) == 0) {
                    return false;
                }
                if ((b3 == 2) & (this.f3919d.getId() != 0)) {
                    return false;
                }
            }
        } else if ((b3 & 1) == 0) {
            return false;
        }
        return m5142d().controlTransfer(64, 11, (b3 << 8) | (b2 & 255), this.f3932q, null, 0, 0) == 0;
    }

    /* JADX INFO: renamed from: C */
    public boolean m5130C() {
        return m5114B(0);
    }

    /* JADX INFO: renamed from: D */
    public boolean m5131D() {
        return m5114B(16384);
    }

    /* JADX INFO: renamed from: F */
    void m5132F(UsbDeviceConnection usbDeviceConnection) {
        this.f3923h = usbDeviceConnection;
    }

    /* JADX INFO: renamed from: G */
    synchronized boolean m5133G(Context context) {
        boolean z;
        z = false;
        if (context != null) {
            this.f3933r = context;
            z = true;
        }
        return z;
    }

    /* JADX INFO: renamed from: H */
    public boolean m5134H(byte b2, byte b3, byte b4) {
        if (!m5150t()) {
            return false;
        }
        short s = (short) (((short) (b2 | (b4 << 8))) | (b3 << 11));
        this.f3927l.f3903i = s;
        return m5142d().controlTransfer(64, 4, s, this.f3932q, null, 0, 0) == 0;
    }

    /* JADX INFO: renamed from: I */
    protected void m5135I(C1141e c1141e) {
        this.f3931p.m5088f(c1141e.m5084b());
        this.f3931p.m5089g(c1141e.m5085c());
        this.f3931p.m5087e(c1141e.m5083a());
        this.f3931p.m5090h(c1141e.m5086d());
    }

    /* JADX INFO: renamed from: J */
    public boolean m5136J() {
        return m5150t() && m5142d().controlTransfer(64, 1, 257, this.f3932q, null, 0, 0) == 0;
    }

    /* JADX INFO: renamed from: K */
    public boolean m5137K(short s, byte b2, byte b3) {
        short s2;
        if (!m5150t()) {
            return false;
        }
        if (s == 1024) {
            s2 = (short) ((b2 & 255) | ((short) (b3 << 8)));
        } else {
            s2 = 0;
        }
        if (m5142d().controlTransfer(64, 2, s2, this.f3932q | s, null, 0, 0) != 0) {
            return false;
        }
        if (s == 256) {
            return m5139N();
        }
        if (s == 512) {
            return m5136J();
        }
        return true;
    }

    /* JADX INFO: renamed from: L */
    public boolean m5138L(byte b2) {
        return m5150t() && m5142d().controlTransfer(64, 9, b2 & 255, this.f3932q, null, 0, 0) == 0;
    }

    /* JADX INFO: renamed from: N */
    public boolean m5139N() {
        return m5150t() && m5142d().controlTransfer(64, 1, 514, this.f3932q, null, 0, 0) == 0;
    }

    /* JADX INFO: renamed from: P */
    public int m5140P(byte[] bArr, int i, boolean z) {
        UsbRequest usbRequestRequestWait;
        if (!m5150t() || i < 0) {
            return -1;
        }
        UsbRequest usbRequest = this.f3922g;
        if (z) {
            usbRequest.setClientData(this);
        }
        if (i != 0 ? !usbRequest.queue(ByteBuffer.wrap(bArr), i) : !usbRequest.queue(ByteBuffer.wrap(new byte[1]), i)) {
            i = -1;
        }
        if (z) {
            do {
                usbRequestRequestWait = this.f3923h.requestWait();
                if (usbRequestRequestWait == null) {
                    Log.e("FTDI_Device::", "UsbConnection.requestWait() == null");
                    return -99;
                }
            } while (usbRequestRequestWait.getClientData() != this);
        }
        return i;
    }

    /* JADX INFO: renamed from: a */
    public synchronized void m5141a() {
        Thread thread = this.f3925j;
        if (thread != null) {
            thread.interrupt();
        }
        Thread thread2 = this.f3926k;
        if (thread2 != null) {
            thread2.interrupt();
        }
        UsbDeviceConnection usbDeviceConnection = this.f3923h;
        if (usbDeviceConnection != null) {
            usbDeviceConnection.releaseInterface(this.f3919d);
            this.f3923h.close();
            this.f3923h = null;
        }
        C1158v c1158v = this.f3928m;
        if (c1158v != null) {
            c1158v.m5174c();
        }
        this.f3925j = null;
        this.f3926k = null;
        this.f3924i = null;
        this.f3928m = null;
        m5115E();
    }

    /* JADX INFO: renamed from: d */
    UsbDeviceConnection m5142d() {
        return this.f3923h;
    }

    /* JADX INFO: renamed from: e */
    C1141e m5143e() {
        return this.f3931p;
    }

    /* JADX INFO: renamed from: f */
    public byte m5144f() {
        byte[] bArr = new byte[1];
        if (!m5150t()) {
            return (byte) -1;
        }
        if (m5142d().controlTransfer(-64, 10, 0, this.f3932q, bArr, 1, 0) == 1) {
            return bArr[0];
        }
        return (byte) 0;
    }

    /* JADX INFO: renamed from: g */
    int m5145g() {
        return this.f3934s;
    }

    /* JADX INFO: renamed from: h */
    public int m5146h() {
        if (!m5150t()) {
            return -1;
        }
        C1158v c1158v = this.f3928m;
        if (c1158v == null) {
            return -2;
        }
        return c1158v.m5176g();
    }

    /* JADX INFO: renamed from: i */
    protected UsbDevice m5147i() {
        return this.f3918c;
    }

    /* JADX INFO: renamed from: q */
    final boolean m5148q() {
        return (this.f3927l.f3896b & 65280) == 2048;
    }

    /* JADX INFO: renamed from: s */
    final boolean m5149s() {
        return m5121k() || m5122l() || m5148q();
    }

    /* JADX INFO: renamed from: t */
    public synchronized boolean m5150t() {
        return this.f3917b.booleanValue();
    }

    /* JADX INFO: renamed from: u */
    synchronized boolean m5151u(UsbManager usbManager) {
        if (m5150t()) {
            return false;
        }
        if (usbManager == null) {
            Log.e("FTDI_Device::", "UsbManager cannot be null.");
            return false;
        }
        if (m5142d() != null) {
            Log.e("FTDI_Device::", "There should not have an UsbConnection.");
            return false;
        }
        m5132F(usbManager.openDevice(this.f3918c));
        if (m5142d() == null) {
            Log.e("FTDI_Device::", "UsbConnection cannot be null.");
            return false;
        }
        if (!m5142d().claimInterface(this.f3919d, true)) {
            Log.e("FTDI_Device::", "ClaimInteface returned false.");
            return false;
        }
        Log.d("FTDI_Device::", "open SUCCESS");
        if (!m5119c()) {
            Log.e("FTDI_Device::", "Failed to find endpoints.");
            return false;
        }
        this.f3922g.initialize(this.f3923h, this.f3920e);
        Log.d("D2XX::", "**********************Device Opened**********************");
        C1158v c1158v = new C1158v(this);
        this.f3928m = c1158v;
        this.f3924i = new RunnableC1137a(this, c1158v, m5142d(), this.f3921f);
        Thread thread = new Thread(this.f3924i);
        this.f3926k = thread;
        thread.setName("bulkInThread");
        Thread thread2 = new Thread(new RunnableC1159w(this.f3928m));
        this.f3925j = thread2;
        thread2.setName("processRequestThread");
        m5128w(true, true);
        this.f3926k.start();
        this.f3925j.start();
        m5116M();
        return true;
    }

    /* JADX INFO: renamed from: v */
    public boolean m5152v(byte b2) {
        return m5128w((b2 & 1) == 1, (b2 & 2) == 2);
    }

    /* JADX INFO: renamed from: x */
    public int m5153x(byte[] bArr, int i) {
        return m5154y(bArr, i, this.f3931p.m5086d());
    }

    /* JADX INFO: renamed from: y */
    public int m5154y(byte[] bArr, int i, long j) {
        if (!m5150t()) {
            return -1;
        }
        if (i <= 0) {
            return -2;
        }
        C1158v c1158v = this.f3928m;
        if (c1158v == null) {
            return -3;
        }
        return c1158v.m5182n(bArr, i, j);
    }

    /* JADX INFO: renamed from: z */
    public boolean m5155z(int i) {
        byte bM5113f;
        int[] iArr = new int[2];
        if (!m5150t()) {
            return false;
        }
        switch (i) {
            case 300:
                iArr[0] = 10000;
                bM5113f = 1;
                break;
            case 600:
                iArr[0] = 5000;
                bM5113f = 1;
                break;
            case 1200:
                iArr[0] = 2500;
                bM5113f = 1;
                break;
            case 2400:
                iArr[0] = 1250;
                bM5113f = 1;
                break;
            case 4800:
                iArr[0] = 625;
                bM5113f = 1;
                break;
            case 9600:
                iArr[0] = 16696;
                bM5113f = 1;
                break;
            case 19200:
                iArr[0] = 32924;
                bM5113f = 1;
                break;
            case 38400:
                iArr[0] = 49230;
                bM5113f = 1;
                break;
            case 57600:
                iArr[0] = 52;
                bM5113f = 1;
                break;
            case 115200:
                iArr[0] = 26;
                bM5113f = 1;
                break;
            case 230400:
                iArr[0] = 13;
                bM5113f = 1;
                break;
            case 460800:
                iArr[0] = 16390;
                bM5113f = 1;
                break;
            case 921600:
                iArr[0] = 32771;
                bM5113f = 1;
                break;
            default:
                bM5113f = (m5127r() && i >= 1200) ? C1144h.m5113f(i, iArr) : C1144h.m5112e(i, iArr, m5120j());
                break;
        }
        if (m5149s() || m5125o() || m5124n()) {
            iArr[1] = iArr[1] << 8;
            iArr[1] = iArr[1] & 65280;
            iArr[1] = iArr[1] | this.f3932q;
        }
        return bM5113f == 1 && m5142d().controlTransfer(64, 3, iArr[0], iArr[1], null, 0, 0) == 0;
    }
}
