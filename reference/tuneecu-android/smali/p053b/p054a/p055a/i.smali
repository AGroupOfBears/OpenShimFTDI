.class public Lb/a/a/i;
.super Ljava/lang/Object;
.source ""


# instance fields
.field a:J

.field b:Ljava/lang/Boolean;

.field c:Landroid/hardware/usb/UsbDevice;

.field d:Landroid/hardware/usb/UsbInterface;

.field e:Landroid/hardware/usb/UsbEndpoint;

.field f:Landroid/hardware/usb/UsbEndpoint;

.field private g:Landroid/hardware/usb/UsbRequest;

.field private h:Landroid/hardware/usb/UsbDeviceConnection;

.field private i:Lb/a/a/a;

.field private j:Ljava/lang/Thread;

.field private k:Ljava/lang/Thread;

.field l:Lb/a/a/f;

.field private m:Lb/a/a/v;

.field private n:Lb/a/a/r;

.field o:Lb/a/a/x;

.field private p:Lb/a/a/e;

.field private q:I

.field r:Landroid/content/Context;

.field private s:I


# direct methods
.method public constructor <init>(Landroid/content/Context;Landroid/hardware/usb/UsbManager;Landroid/hardware/usb/UsbDevice;Landroid/hardware/usb/UsbInterface;)V
    .locals 24

    move-object/from16 v1, p0

    const-string v0, "Failed to open the device!"

    const-string v2, "FTDI_Device::"

    invoke-direct/range {p0 .. p0}, Ljava/lang/Object;-><init>()V

    const/4 v3, 0x0

    iput v3, v1, Lb/a/a/i;->q:I

    const/16 v4, 0xff

    new-array v4, v4, [B

    move-object/from16 v5, p1

    iput-object v5, v1, Lb/a/a/i;->r:Landroid/content/Context;

    new-instance v5, Lb/a/a/e;

    invoke-direct {v5}, Lb/a/a/e;-><init>()V

    iput-object v5, v1, Lb/a/a/i;->p:Lb/a/a/e;

    move-object/from16 v5, p3

    :try_start_0
    iput-object v5, v1, Lb/a/a/i;->c:Landroid/hardware/usb/UsbDevice;

    move-object/from16 v5, p4

    iput-object v5, v1, Lb/a/a/i;->d:Landroid/hardware/usb/UsbInterface;

    const/4 v13, 0x0

    iput-object v13, v1, Lb/a/a/i;->e:Landroid/hardware/usb/UsbEndpoint;

    iput-object v13, v1, Lb/a/a/i;->f:Landroid/hardware/usb/UsbEndpoint;

    iput v3, v1, Lb/a/a/i;->s:I

    new-instance v5, Lb/a/a/x;

    invoke-direct {v5}, Lb/a/a/x;-><init>()V

    iput-object v5, v1, Lb/a/a/i;->o:Lb/a/a/x;

    new-instance v5, Lb/a/a/f;

    invoke-direct {v5}, Lb/a/a/f;-><init>()V

    iput-object v5, v1, Lb/a/a/i;->l:Lb/a/a/f;

    new-instance v5, Landroid/hardware/usb/UsbRequest;

    invoke-direct {v5}, Landroid/hardware/usb/UsbRequest;-><init>()V

    iput-object v5, v1, Lb/a/a/i;->g:Landroid/hardware/usb/UsbRequest;

    iget-object v5, v1, Lb/a/a/i;->c:Landroid/hardware/usb/UsbDevice;

    move-object/from16 v6, p2

    invoke-virtual {v6, v5}, Landroid/hardware/usb/UsbManager;->openDevice(Landroid/hardware/usb/UsbDevice;)Landroid/hardware/usb/UsbDeviceConnection;

    move-result-object v5

    invoke-virtual {v1, v5}, Lb/a/a/i;->F(Landroid/hardware/usb/UsbDeviceConnection;)V

    invoke-virtual/range {p0 .. p0}, Lb/a/a/i;->d()Landroid/hardware/usb/UsbDeviceConnection;

    move-result-object v5

    if-eqz v5, :cond_d

    invoke-virtual/range {p0 .. p0}, Lb/a/a/i;->d()Landroid/hardware/usb/UsbDeviceConnection;

    move-result-object v0

    iget-object v5, v1, Lb/a/a/i;->d:Landroid/hardware/usb/UsbInterface;

    invoke-virtual {v0, v5, v3}, Landroid/hardware/usb/UsbDeviceConnection;->claimInterface(Landroid/hardware/usb/UsbInterface;Z)Z

    invoke-virtual/range {p0 .. p0}, Lb/a/a/i;->d()Landroid/hardware/usb/UsbDeviceConnection;

    move-result-object v0

    invoke-virtual {v0}, Landroid/hardware/usb/UsbDeviceConnection;->getRawDescriptors()[B

    move-result-object v0

    iget-object v5, v1, Lb/a/a/i;->c:Landroid/hardware/usb/UsbDevice;

    invoke-virtual {v5}, Landroid/hardware/usb/UsbDevice;->getDeviceId()I

    move-result v5

    iget-object v6, v1, Lb/a/a/i;->d:Landroid/hardware/usb/UsbInterface;

    invoke-virtual {v6}, Landroid/hardware/usb/UsbInterface;->getId()I

    move-result v6

    const/4 v14, 0x1

    add-int/2addr v6, v14

    iput v6, v1, Lb/a/a/i;->q:I

    iget-object v7, v1, Lb/a/a/i;->l:Lb/a/a/f;

    const/4 v15, 0x4

    shl-int/2addr v5, v15

    const/16 v8, 0xf

    and-int/2addr v6, v8

    or-int/2addr v5, v6

    iput v5, v7, Lb/a/a/f;->f:I

    const/4 v12, 0x2

    invoke-static {v12}, Ljava/nio/ByteBuffer;->allocate(I)Ljava/nio/ByteBuffer;

    move-result-object v5

    sget-object v6, Ljava/nio/ByteOrder;->LITTLE_ENDIAN:Ljava/nio/ByteOrder;

    invoke-virtual {v5, v6}, Ljava/nio/ByteBuffer;->order(Ljava/nio/ByteOrder;)Ljava/nio/ByteBuffer;

    const/16 v11, 0xc

    aget-byte v6, v0, v11

    invoke-virtual {v5, v6}, Ljava/nio/ByteBuffer;->put(B)Ljava/nio/ByteBuffer;

    const/16 v6, 0xd

    aget-byte v6, v0, v6

    invoke-virtual {v5, v6}, Ljava/nio/ByteBuffer;->put(B)Ljava/nio/ByteBuffer;

    iget-object v6, v1, Lb/a/a/i;->l:Lb/a/a/f;

    invoke-virtual {v5, v3}, Ljava/nio/ByteBuffer;->getShort(I)S

    move-result v5

    iput-short v5, v6, Lb/a/a/f;->b:S

    iget-object v5, v1, Lb/a/a/i;->l:Lb/a/a/f;

    const/16 v10, 0x10

    aget-byte v6, v0, v10

    iput-byte v6, v5, Lb/a/a/f;->d:B

    invoke-virtual/range {p0 .. p0}, Lb/a/a/i;->d()Landroid/hardware/usb/UsbDeviceConnection;

    move-result-object v6

    invoke-virtual {v6}, Landroid/hardware/usb/UsbDeviceConnection;->getSerial()Ljava/lang/String;

    move-result-object v6

    iput-object v6, v5, Lb/a/a/f;->g:Ljava/lang/String;

    iget-object v5, v1, Lb/a/a/i;->l:Lb/a/a/f;

    iget-object v6, v1, Lb/a/a/i;->c:Landroid/hardware/usb/UsbDevice;

    invoke-virtual {v6}, Landroid/hardware/usb/UsbDevice;->getVendorId()I

    move-result v6

    shl-int/2addr v6, v10

    iget-object v7, v1, Lb/a/a/i;->c:Landroid/hardware/usb/UsbDevice;

    invoke-virtual {v7}, Landroid/hardware/usb/UsbDevice;->getProductId()I

    move-result v7

    or-int/2addr v6, v7

    iput v6, v5, Lb/a/a/f;->e:I

    iget-object v5, v1, Lb/a/a/i;->l:Lb/a/a/f;

    const/16 v9, 0x8

    iput v9, v5, Lb/a/a/f;->i:I

    invoke-virtual/range {p0 .. p0}, Lb/a/a/i;->d()Landroid/hardware/usb/UsbDeviceConnection;

    move-result-object v5

    const/16 v6, -0x80

    const/4 v7, 0x6

    aget-byte v0, v0, v8

    or-int/lit16 v8, v0, 0x300

    const/4 v0, 0x0

    const/16 v16, 0xff

    const/16 v17, 0x0

    const/16 v13, 0x8

    move v9, v0

    const/16 v0, 0x10

    move-object v10, v4

    const/16 v0, 0xc

    move/from16 v11, v16

    const/4 v0, 0x2

    move/from16 v12, v17

    invoke-virtual/range {v5 .. v12}, Landroid/hardware/usb/UsbDeviceConnection;->controlTransfer(IIII[BII)I

    iget-object v5, v1, Lb/a/a/i;->l:Lb/a/a/f;

    invoke-direct {v1, v4}, Lb/a/a/i;->O([B)Ljava/lang/String;

    move-result-object v4

    iput-object v4, v5, Lb/a/a/f;->h:Ljava/lang/String;

    iget-object v4, v1, Lb/a/a/i;->l:Lb/a/a/f;

    iget-short v5, v4, Lb/a/a/f;->b:S

    const v6, 0xff00

    and-int/2addr v5, v6

    const/4 v7, 0x3

    sparse-switch v5, :sswitch_data_0

    goto/16 :goto_3

    :sswitch_0
    const/16 v5, 0xb

    iput v5, v4, Lb/a/a/f;->c:I

    iget v5, v1, Lb/a/a/i;->q:I

    if-ne v5, v15, :cond_2

    iget-object v4, v1, Lb/a/a/i;->c:Landroid/hardware/usb/UsbDevice;

    sub-int/2addr v5, v14

    invoke-virtual {v4, v5}, Landroid/hardware/usb/UsbDevice;->getInterface(I)Landroid/hardware/usb/UsbInterface;

    move-result-object v4

    invoke-virtual {v4, v3}, Landroid/hardware/usb/UsbInterface;->getEndpoint(I)Landroid/hardware/usb/UsbEndpoint;

    move-result-object v4

    invoke-virtual {v4}, Landroid/hardware/usb/UsbEndpoint;->getMaxPacketSize()I

    move-result v4

    const-string v5, "dev"

    new-instance v8, Ljava/lang/StringBuilder;

    const-string v9, "mInterfaceID : "

    invoke-direct {v8, v9}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    iget v9, v1, Lb/a/a/i;->q:I

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v9, "   iMaxPacketSize : "

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v8, v4}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    invoke-static {v5, v8}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    if-ne v4, v13, :cond_1

    iget-object v4, v1, Lb/a/a/i;->l:Lb/a/a/f;

    :cond_0
    iput v3, v4, Lb/a/a/f;->a:I

    goto/16 :goto_4

    :cond_1
    iget-object v4, v1, Lb/a/a/i;->l:Lb/a/a/f;

    :cond_2
    :goto_0
    iput v0, v4, Lb/a/a/f;->a:I

    goto/16 :goto_4

    :sswitch_1
    const/16 v5, 0xa

    iput v5, v4, Lb/a/a/f;->c:I

    iget v5, v1, Lb/a/a/i;->q:I

    if-ne v5, v14, :cond_0

    goto :goto_0

    :sswitch_2
    const/16 v5, 0xc

    iput v5, v4, Lb/a/a/f;->c:I

    goto :goto_0

    :sswitch_3
    const/16 v5, 0x9

    iput v5, v4, Lb/a/a/f;->c:I

    new-instance v4, Lb/a/a/s;

    invoke-direct {v4, v1}, Lb/a/a/s;-><init>(Lb/a/a/i;)V

    :goto_1
    iput-object v4, v1, Lb/a/a/i;->n:Lb/a/a/r;

    goto/16 :goto_4

    :sswitch_4
    iput v13, v4, Lb/a/a/f;->c:I

    iput v0, v4, Lb/a/a/f;->a:I

    new-instance v4, Lb/a/a/n;

    invoke-direct {v4, v1}, Lb/a/a/n;-><init>(Lb/a/a/i;)V

    goto :goto_1

    :sswitch_5
    const/4 v5, 0x7

    iput v5, v4, Lb/a/a/f;->c:I

    iput v0, v4, Lb/a/a/f;->a:I

    invoke-direct/range {p0 .. p0}, Lb/a/a/i;->b()V

    new-instance v4, Lb/a/a/q;

    invoke-direct {v4, v1}, Lb/a/a/q;-><init>(Lb/a/a/i;)V

    goto :goto_1

    :sswitch_6
    const/4 v5, 0x6

    iput v5, v4, Lb/a/a/f;->c:I

    iput v0, v4, Lb/a/a/f;->a:I

    invoke-direct/range {p0 .. p0}, Lb/a/a/i;->b()V

    new-instance v4, Lb/a/a/j;

    invoke-direct {v4, v1}, Lb/a/a/j;-><init>(Lb/a/a/i;)V

    goto :goto_1

    :sswitch_7
    new-instance v4, Lb/a/a/r;

    invoke-direct {v4, v1}, Lb/a/a/r;-><init>(Lb/a/a/i;)V

    iput-object v4, v1, Lb/a/a/i;->n:Lb/a/a/r;

    invoke-virtual {v4, v3}, Lb/a/a/r;->c(S)I

    move-result v4

    and-int/2addr v4, v14

    int-to-short v4, v4

    const/4 v5, 0x0

    iput-object v5, v1, Lb/a/a/i;->n:Lb/a/a/r;

    const/4 v5, 0x5

    if-nez v4, :cond_3

    iget-object v4, v1, Lb/a/a/i;->l:Lb/a/a/f;

    iput v5, v4, Lb/a/a/f;->c:I

    new-instance v4, Lb/a/a/o;

    invoke-direct {v4, v1}, Lb/a/a/o;-><init>(Lb/a/a/i;)V

    goto :goto_1

    :cond_3
    iget-object v4, v1, Lb/a/a/i;->l:Lb/a/a/f;

    iput v5, v4, Lb/a/a/f;->c:I

    new-instance v4, Lb/a/a/p;

    invoke-direct {v4, v1}, Lb/a/a/p;-><init>(Lb/a/a/i;)V

    goto :goto_1

    :sswitch_8
    new-instance v4, Lb/a/a/k;

    invoke-direct {v4, v1}, Lb/a/a/k;-><init>(Lb/a/a/i;)V

    iput-object v4, v1, Lb/a/a/i;->n:Lb/a/a/r;

    iget-object v4, v1, Lb/a/a/i;->l:Lb/a/a/f;

    iput v15, v4, Lb/a/a/f;->c:I

    invoke-direct/range {p0 .. p0}, Lb/a/a/i;->b()V

    goto :goto_4

    :sswitch_9
    new-instance v5, Lb/a/a/m;

    invoke-direct {v5, v1}, Lb/a/a/m;-><init>(Lb/a/a/i;)V

    iput-object v5, v1, Lb/a/a/i;->n:Lb/a/a/r;

    :goto_2
    iput v3, v4, Lb/a/a/f;->c:I

    goto :goto_4

    :sswitch_a
    iget-byte v5, v4, Lb/a/a/f;->d:B

    if-nez v5, :cond_4

    new-instance v5, Lb/a/a/m;

    invoke-direct {v5, v1}, Lb/a/a/m;-><init>(Lb/a/a/i;)V

    iput-object v5, v1, Lb/a/a/i;->n:Lb/a/a/r;

    goto :goto_2

    :cond_4
    iput v14, v4, Lb/a/a/f;->c:I

    new-instance v4, Lb/a/a/l;

    invoke-direct {v4, v1}, Lb/a/a/l;-><init>(Lb/a/a/i;)V

    goto :goto_1

    :goto_3
    iput v7, v4, Lb/a/a/f;->c:I

    new-instance v4, Lb/a/a/r;

    invoke-direct {v4, v1}, Lb/a/a/r;-><init>(Lb/a/a/i;)V

    goto/16 :goto_1

    :goto_4
    iget-object v4, v1, Lb/a/a/i;->l:Lb/a/a/f;

    iget-short v5, v4, Lb/a/a/f;->b:S

    and-int/2addr v5, v6

    const/16 v8, 0x1700

    const/16 v9, 0x1900

    const/16 v10, 0x1800

    if-eq v5, v8, :cond_5

    if-eq v5, v10, :cond_5

    if-eq v5, v9, :cond_5

    goto :goto_6

    :cond_5
    iget-object v4, v4, Lb/a/a/f;->g:Ljava/lang/String;

    if-nez v4, :cond_7

    const/16 v4, 0x10

    new-array v4, v4, [B

    invoke-virtual/range {p0 .. p0}, Lb/a/a/i;->d()Landroid/hardware/usb/UsbDeviceConnection;

    move-result-object v16

    const/16 v17, -0x40

    const/16 v18, 0x90

    const/16 v19, 0x0

    const/16 v20, 0x1b

    const/16 v22, 0x10

    const/16 v23, 0x0

    move-object/from16 v21, v4

    invoke-virtual/range {v16 .. v23}, Landroid/hardware/usb/UsbDeviceConnection;->controlTransfer(IIII[BII)I

    const-string v5, ""

    :goto_5
    if-lt v3, v13, :cond_6

    iget-object v3, v1, Lb/a/a/i;->l:Lb/a/a/f;

    new-instance v4, Ljava/lang/String;

    invoke-direct {v4, v5}, Ljava/lang/String;-><init>(Ljava/lang/String;)V

    iput-object v4, v3, Lb/a/a/f;->g:Ljava/lang/String;

    goto :goto_6

    :cond_6
    new-instance v8, Ljava/lang/StringBuilder;

    invoke-static {v5}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v5

    invoke-direct {v8, v5}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    mul-int/lit8 v5, v3, 0x2

    aget-byte v5, v4, v5

    int-to-char v5, v5

    invoke-virtual {v8, v5}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    add-int/lit8 v3, v3, 0x1

    goto :goto_5

    :cond_7
    :goto_6
    iget-object v3, v1, Lb/a/a/i;->l:Lb/a/a/f;

    iget-short v4, v3, Lb/a/a/f;->b:S

    and-int/2addr v4, v6

    if-eq v4, v10, :cond_8

    if-eq v4, v9, :cond_8

    goto/16 :goto_8

    :cond_8
    iget v4, v1, Lb/a/a/i;->q:I

    if-ne v4, v14, :cond_9

    iget-object v0, v3, Lb/a/a/f;->h:Ljava/lang/String;

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-static {v0}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    invoke-direct {v4, v0}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    const-string v0, " A"

    invoke-virtual {v4, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    iput-object v0, v3, Lb/a/a/f;->h:Ljava/lang/String;

    iget-object v0, v1, Lb/a/a/i;->l:Lb/a/a/f;

    iget-object v3, v0, Lb/a/a/f;->g:Ljava/lang/String;

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-static {v3}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v3

    invoke-direct {v4, v3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    const-string v3, "A"

    invoke-virtual {v4, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    :goto_7
    iput-object v3, v0, Lb/a/a/f;->g:Ljava/lang/String;

    goto/16 :goto_8

    :cond_9
    if-ne v4, v0, :cond_a

    iget-object v0, v3, Lb/a/a/f;->h:Ljava/lang/String;

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-static {v0}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    invoke-direct {v4, v0}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    const-string v0, " B"

    invoke-virtual {v4, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    iput-object v0, v3, Lb/a/a/f;->h:Ljava/lang/String;

    iget-object v0, v1, Lb/a/a/i;->l:Lb/a/a/f;

    iget-object v3, v0, Lb/a/a/f;->g:Ljava/lang/String;

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-static {v3}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v3

    invoke-direct {v4, v3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    const-string v3, "B"

    invoke-virtual {v4, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    goto :goto_7

    :cond_a
    if-ne v4, v7, :cond_b

    iget-object v0, v3, Lb/a/a/f;->h:Ljava/lang/String;

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-static {v0}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    invoke-direct {v4, v0}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    const-string v0, " C"

    invoke-virtual {v4, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    iput-object v0, v3, Lb/a/a/f;->h:Ljava/lang/String;

    iget-object v0, v1, Lb/a/a/i;->l:Lb/a/a/f;

    iget-object v3, v0, Lb/a/a/f;->g:Ljava/lang/String;

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-static {v3}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v3

    invoke-direct {v4, v3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    const-string v3, "C"

    invoke-virtual {v4, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    goto :goto_7

    :cond_b
    if-ne v4, v15, :cond_c

    iget-object v0, v3, Lb/a/a/f;->h:Ljava/lang/String;

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-static {v0}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    invoke-direct {v4, v0}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    const-string v0, " D"

    invoke-virtual {v4, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    iput-object v0, v3, Lb/a/a/f;->h:Ljava/lang/String;

    iget-object v0, v1, Lb/a/a/i;->l:Lb/a/a/f;

    iget-object v3, v0, Lb/a/a/f;->g:Ljava/lang/String;

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-static {v3}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v3

    invoke-direct {v4, v3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    const-string v3, "D"

    invoke-virtual {v4, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    goto/16 :goto_7

    :cond_c
    :goto_8
    invoke-virtual/range {p0 .. p0}, Lb/a/a/i;->d()Landroid/hardware/usb/UsbDeviceConnection;

    move-result-object v0

    iget-object v3, v1, Lb/a/a/i;->d:Landroid/hardware/usb/UsbInterface;

    invoke-virtual {v0, v3}, Landroid/hardware/usb/UsbDeviceConnection;->releaseInterface(Landroid/hardware/usb/UsbInterface;)Z

    invoke-virtual/range {p0 .. p0}, Lb/a/a/i;->d()Landroid/hardware/usb/UsbDeviceConnection;

    move-result-object v0

    invoke-virtual {v0}, Landroid/hardware/usb/UsbDeviceConnection;->close()V

    const/4 v0, 0x0

    invoke-virtual {v1, v0}, Lb/a/a/i;->F(Landroid/hardware/usb/UsbDeviceConnection;)V

    invoke-direct/range {p0 .. p0}, Lb/a/a/i;->E()V

    return-void

    :cond_d
    invoke-static {v2, v0}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    new-instance v3, Lb/a/a/d;

    invoke-direct {v3, v0}, Lb/a/a/d;-><init>(Ljava/lang/String;)V

    throw v3
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :catch_0
    move-exception v0

    invoke-virtual {v0}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v3

    if-eqz v3, :cond_e

    invoke-virtual {v0}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v0

    invoke-static {v2, v0}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    :cond_e
    return-void

    nop

    :sswitch_data_0
    .sparse-switch
        0x200 -> :sswitch_a
        0x400 -> :sswitch_9
        0x500 -> :sswitch_8
        0x600 -> :sswitch_7
        0x700 -> :sswitch_6
        0x800 -> :sswitch_5
        0x900 -> :sswitch_4
        0x1000 -> :sswitch_3
        0x1700 -> :sswitch_2
        0x1800 -> :sswitch_1
        0x1900 -> :sswitch_0
    .end sparse-switch
.end method

.method private B(I)Z
    .locals 9

    iget-object v0, p0, Lb/a/a/i;->l:Lb/a/a/f;

    iget v0, v0, Lb/a/a/f;->i:I

    or-int v4, v0, p1

    invoke-virtual {p0}, Lb/a/a/i;->t()Z

    move-result p1

    const/4 v0, 0x0

    if-nez p1, :cond_0

    return v0

    :cond_0
    invoke-virtual {p0}, Lb/a/a/i;->d()Landroid/hardware/usb/UsbDeviceConnection;

    move-result-object v1

    const/16 v2, 0x40

    const/4 v3, 0x4

    iget v5, p0, Lb/a/a/i;->q:I

    const/4 v6, 0x0

    const/4 v7, 0x0

    const/4 v8, 0x0

    invoke-virtual/range {v1 .. v8}, Landroid/hardware/usb/UsbDeviceConnection;->controlTransfer(IIII[BII)I

    move-result p1

    if-nez p1, :cond_1

    const/4 v0, 0x1

    :cond_1
    return v0
.end method

.method private declared-synchronized E()V
    .locals 2

    monitor-enter p0

    :try_start_0
    sget-object v0, Ljava/lang/Boolean;->FALSE:Ljava/lang/Boolean;

    iput-object v0, p0, Lb/a/a/i;->b:Ljava/lang/Boolean;

    iget-object v0, p0, Lb/a/a/i;->l:Lb/a/a/f;

    iget v1, v0, Lb/a/a/f;->a:I

    and-int/lit8 v1, v1, 0x2

    iput v1, v0, Lb/a/a/f;->a:I
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return-void

    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method private declared-synchronized M()V
    .locals 2

    monitor-enter p0

    :try_start_0
    sget-object v0, Ljava/lang/Boolean;->TRUE:Ljava/lang/Boolean;

    iput-object v0, p0, Lb/a/a/i;->b:Ljava/lang/Boolean;

    iget-object v0, p0, Lb/a/a/i;->l:Lb/a/a/f;

    iget v1, v0, Lb/a/a/f;->a:I

    or-int/lit8 v1, v1, 0x1

    iput v1, v0, Lb/a/a/f;->a:I
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return-void

    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method private final O([B)Ljava/lang/String;
    .locals 4

    new-instance v0, Ljava/lang/String;

    const/4 v1, 0x0

    aget-byte v1, p1, v1

    const/4 v2, 0x2

    sub-int/2addr v1, v2

    const-string v3, "UTF-16LE"

    invoke-direct {v0, p1, v2, v1, v3}, Ljava/lang/String;-><init>([BIILjava/lang/String;)V

    return-object v0
.end method

.method private b()V
    .locals 3

    iget v0, p0, Lb/a/a/i;->q:I

    const/4 v1, 0x1

    if-ne v0, v1, :cond_0

    iget-object v0, p0, Lb/a/a/i;->l:Lb/a/a/f;

    iget-object v1, v0, Lb/a/a/f;->g:Ljava/lang/String;

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-static {v1}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    invoke-direct {v2, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    const-string v1, "A"

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    iput-object v1, v0, Lb/a/a/f;->g:Ljava/lang/String;

    iget-object v0, p0, Lb/a/a/i;->l:Lb/a/a/f;

    iget-object v1, v0, Lb/a/a/f;->h:Ljava/lang/String;

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-static {v1}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    invoke-direct {v2, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    const-string v1, " A"

    :goto_0
    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    iput-object v1, v0, Lb/a/a/f;->h:Ljava/lang/String;

    goto/16 :goto_1

    :cond_0
    const/4 v1, 0x2

    if-ne v0, v1, :cond_1

    iget-object v0, p0, Lb/a/a/i;->l:Lb/a/a/f;

    iget-object v1, v0, Lb/a/a/f;->g:Ljava/lang/String;

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-static {v1}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    invoke-direct {v2, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    const-string v1, "B"

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    iput-object v1, v0, Lb/a/a/f;->g:Ljava/lang/String;

    iget-object v0, p0, Lb/a/a/i;->l:Lb/a/a/f;

    iget-object v1, v0, Lb/a/a/f;->h:Ljava/lang/String;

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-static {v1}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    invoke-direct {v2, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    const-string v1, " B"

    goto :goto_0

    :cond_1
    const/4 v1, 0x3

    if-ne v0, v1, :cond_2

    iget-object v0, p0, Lb/a/a/i;->l:Lb/a/a/f;

    iget-object v1, v0, Lb/a/a/f;->g:Ljava/lang/String;

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-static {v1}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    invoke-direct {v2, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    const-string v1, "C"

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    iput-object v1, v0, Lb/a/a/f;->g:Ljava/lang/String;

    iget-object v0, p0, Lb/a/a/i;->l:Lb/a/a/f;

    iget-object v1, v0, Lb/a/a/f;->h:Ljava/lang/String;

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-static {v1}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    invoke-direct {v2, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    const-string v1, " C"

    goto :goto_0

    :cond_2
    const/4 v1, 0x4

    if-ne v0, v1, :cond_3

    iget-object v0, p0, Lb/a/a/i;->l:Lb/a/a/f;

    iget-object v1, v0, Lb/a/a/f;->g:Ljava/lang/String;

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-static {v1}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    invoke-direct {v2, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    const-string v1, "D"

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    iput-object v1, v0, Lb/a/a/f;->g:Ljava/lang/String;

    iget-object v0, p0, Lb/a/a/i;->l:Lb/a/a/f;

    iget-object v1, v0, Lb/a/a/f;->h:Ljava/lang/String;

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-static {v1}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    invoke-direct {v2, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    const-string v1, " D"

    goto/16 :goto_0

    :cond_3
    :goto_1
    return-void
.end method

.method private c()Z
    .locals 5

    const/4 v0, 0x0

    const/4 v1, 0x0

    :goto_0
    iget-object v2, p0, Lb/a/a/i;->d:Landroid/hardware/usb/UsbInterface;

    invoke-virtual {v2}, Landroid/hardware/usb/UsbInterface;->getEndpointCount()I

    move-result v2

    const/4 v3, 0x1

    if-lt v1, v2, :cond_2

    iget-object v1, p0, Lb/a/a/i;->e:Landroid/hardware/usb/UsbEndpoint;

    if-eqz v1, :cond_1

    iget-object v1, p0, Lb/a/a/i;->f:Landroid/hardware/usb/UsbEndpoint;

    if-nez v1, :cond_0

    goto :goto_1

    :cond_0
    return v3

    :cond_1
    :goto_1
    return v0

    :cond_2
    new-instance v2, Ljava/lang/StringBuilder;

    const-string v4, "EP: "

    invoke-direct {v2, v4}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    new-array v3, v3, [Ljava/lang/Object;

    iget-object v4, p0, Lb/a/a/i;->d:Landroid/hardware/usb/UsbInterface;

    invoke-virtual {v4, v1}, Landroid/hardware/usb/UsbInterface;->getEndpoint(I)Landroid/hardware/usb/UsbEndpoint;

    move-result-object v4

    invoke-virtual {v4}, Landroid/hardware/usb/UsbEndpoint;->getAddress()I

    move-result v4

    invoke-static {v4}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v4

    aput-object v4, v3, v0

    const-string v4, "0x%02X"

    invoke-static {v4, v3}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    const-string v3, "FTDI_Device::"

    invoke-static {v3, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    iget-object v2, p0, Lb/a/a/i;->d:Landroid/hardware/usb/UsbInterface;

    invoke-virtual {v2, v1}, Landroid/hardware/usb/UsbInterface;->getEndpoint(I)Landroid/hardware/usb/UsbEndpoint;

    move-result-object v2

    invoke-virtual {v2}, Landroid/hardware/usb/UsbEndpoint;->getType()I

    move-result v2

    const/4 v4, 0x2

    if-ne v2, v4, :cond_4

    iget-object v2, p0, Lb/a/a/i;->d:Landroid/hardware/usb/UsbInterface;

    invoke-virtual {v2, v1}, Landroid/hardware/usb/UsbInterface;->getEndpoint(I)Landroid/hardware/usb/UsbEndpoint;

    move-result-object v2

    invoke-virtual {v2}, Landroid/hardware/usb/UsbEndpoint;->getDirection()I

    move-result v2

    const/16 v3, 0x80

    if-ne v2, v3, :cond_3

    iget-object v2, p0, Lb/a/a/i;->d:Landroid/hardware/usb/UsbInterface;

    invoke-virtual {v2, v1}, Landroid/hardware/usb/UsbInterface;->getEndpoint(I)Landroid/hardware/usb/UsbEndpoint;

    move-result-object v2

    iput-object v2, p0, Lb/a/a/i;->f:Landroid/hardware/usb/UsbEndpoint;

    invoke-virtual {v2}, Landroid/hardware/usb/UsbEndpoint;->getMaxPacketSize()I

    move-result v2

    iput v2, p0, Lb/a/a/i;->s:I

    goto :goto_2

    :cond_3
    iget-object v2, p0, Lb/a/a/i;->d:Landroid/hardware/usb/UsbInterface;

    invoke-virtual {v2, v1}, Landroid/hardware/usb/UsbInterface;->getEndpoint(I)Landroid/hardware/usb/UsbEndpoint;

    move-result-object v2

    iput-object v2, p0, Lb/a/a/i;->e:Landroid/hardware/usb/UsbEndpoint;

    goto :goto_2

    :cond_4
    const-string v2, "Not Bulk Endpoint"

    invoke-static {v3, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    :goto_2
    add-int/lit8 v1, v1, 0x1

    goto :goto_0
.end method

.method private final j()Z
    .locals 1

    invoke-direct {p0}, Lb/a/a/i;->m()Z

    move-result v0

    if-nez v0, :cond_0

    invoke-direct {p0}, Lb/a/a/i;->k()Z

    move-result v0

    if-nez v0, :cond_0

    invoke-direct {p0}, Lb/a/a/i;->p()Z

    move-result v0

    if-nez v0, :cond_0

    invoke-direct {p0}, Lb/a/a/i;->l()Z

    move-result v0

    if-nez v0, :cond_0

    invoke-virtual {p0}, Lb/a/a/i;->q()Z

    move-result v0

    if-nez v0, :cond_0

    invoke-direct {p0}, Lb/a/a/i;->o()Z

    move-result v0

    if-nez v0, :cond_0

    invoke-direct {p0}, Lb/a/a/i;->n()Z

    move-result v0

    if-nez v0, :cond_0

    const/4 v0, 0x0

    return v0

    :cond_0
    const/4 v0, 0x1

    return v0
.end method

.method private final k()Z
    .locals 2

    iget-object v0, p0, Lb/a/a/i;->l:Lb/a/a/f;

    iget-short v0, v0, Lb/a/a/f;->b:S

    const v1, 0xff00

    and-int/2addr v0, v1

    const/16 v1, 0x500

    if-ne v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method private final l()Z
    .locals 2

    iget-object v0, p0, Lb/a/a/i;->l:Lb/a/a/f;

    iget-short v0, v0, Lb/a/a/f;->b:S

    const v1, 0xff00

    and-int/2addr v0, v1

    const/16 v1, 0x700

    if-ne v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method private final m()Z
    .locals 5

    iget-object v0, p0, Lb/a/a/i;->l:Lb/a/a/f;

    iget-short v1, v0, Lb/a/a/f;->b:S

    const v2, 0xff00

    and-int v3, v1, v2

    const/16 v4, 0x400

    if-eq v3, v4, :cond_1

    and-int/2addr v1, v2

    const/16 v2, 0x200

    if-ne v1, v2, :cond_0

    iget-byte v0, v0, Lb/a/a/f;->d:B

    if-eqz v0, :cond_1

    :cond_0
    const/4 v0, 0x0

    return v0

    :cond_1
    const/4 v0, 0x1

    return v0
.end method

.method private final n()Z
    .locals 2

    iget-object v0, p0, Lb/a/a/i;->l:Lb/a/a/f;

    iget-short v0, v0, Lb/a/a/f;->b:S

    const v1, 0xff00

    and-int/2addr v0, v1

    const/16 v1, 0x1000

    if-ne v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method private final o()Z
    .locals 2

    iget-object v0, p0, Lb/a/a/i;->l:Lb/a/a/f;

    iget-short v0, v0, Lb/a/a/f;->b:S

    const v1, 0xff00

    and-int/2addr v0, v1

    const/16 v1, 0x900

    if-ne v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method private final p()Z
    .locals 2

    iget-object v0, p0, Lb/a/a/i;->l:Lb/a/a/f;

    iget-short v0, v0, Lb/a/a/f;->b:S

    const v1, 0xff00

    and-int/2addr v0, v1

    const/16 v1, 0x600

    if-ne v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method private final r()Z
    .locals 1

    invoke-direct {p0}, Lb/a/a/i;->o()Z

    move-result v0

    if-nez v0, :cond_0

    invoke-direct {p0}, Lb/a/a/i;->l()Z

    move-result v0

    if-nez v0, :cond_0

    invoke-virtual {p0}, Lb/a/a/i;->q()Z

    move-result v0

    if-nez v0, :cond_0

    const/4 v0, 0x0

    return v0

    :cond_0
    const/4 v0, 0x1

    return v0
.end method

.method private w(ZZ)Z
    .locals 11

    invoke-virtual {p0}, Lb/a/a/i;->t()Z

    move-result v0

    const/4 v1, 0x0

    if-nez v0, :cond_0

    return v1

    :cond_0
    if-eqz p1, :cond_3

    const/4 p1, 0x1

    const/4 v0, 0x0

    const/4 v2, 0x0

    :goto_0
    const/4 v3, 0x6

    if-lt v0, v3, :cond_2

    if-lez v2, :cond_1

    return v1

    :cond_1
    iget-object p1, p0, Lb/a/a/i;->m:Lb/a/a/v;

    invoke-virtual {p1}, Lb/a/a/v;->m()I

    goto :goto_1

    :cond_2
    invoke-virtual {p0}, Lb/a/a/i;->d()Landroid/hardware/usb/UsbDeviceConnection;

    move-result-object v2

    const/16 v3, 0x40

    const/4 v4, 0x0

    iget v6, p0, Lb/a/a/i;->q:I

    const/4 v7, 0x0

    const/4 v8, 0x0

    const/4 v9, 0x0

    move v5, p1

    invoke-virtual/range {v2 .. v9}, Landroid/hardware/usb/UsbDeviceConnection;->controlTransfer(IIII[BII)I

    move-result v2

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_3
    :goto_1
    if-eqz p2, :cond_4

    const/4 v6, 0x2

    invoke-virtual {p0}, Lb/a/a/i;->d()Landroid/hardware/usb/UsbDeviceConnection;

    move-result-object v3

    const/16 v4, 0x40

    const/4 v5, 0x0

    iget v7, p0, Lb/a/a/i;->q:I

    const/4 v8, 0x0

    const/4 v9, 0x0

    const/4 v10, 0x0

    invoke-virtual/range {v3 .. v10}, Landroid/hardware/usb/UsbDeviceConnection;->controlTransfer(IIII[BII)I

    move-result p1

    if-nez p1, :cond_4

    const/4 v1, 0x1

    :cond_4
    return v1
.end method


# virtual methods
.method public A(BB)Z
    .locals 11

    iget-object v0, p0, Lb/a/a/i;->l:Lb/a/a/f;

    iget v0, v0, Lb/a/a/f;->c:I

    invoke-virtual {p0}, Lb/a/a/i;->t()Z

    move-result v1

    const/4 v2, 0x0

    if-nez v1, :cond_0

    return v2

    :cond_0
    const/4 v1, 0x1

    if-ne v0, v1, :cond_1

    return v2

    :cond_1
    const/16 v3, 0x8

    if-nez v0, :cond_2

    if-eqz p2, :cond_2

    and-int/lit8 v0, p2, 0x1

    if-nez v0, :cond_11

    return v2

    :cond_2
    const/4 v4, 0x4

    const/4 v5, 0x2

    if-ne v0, v4, :cond_6

    if-eqz p2, :cond_6

    and-int/lit8 v0, p2, 0x1f

    if-nez v0, :cond_3

    return v2

    :cond_3
    if-ne p2, v5, :cond_4

    const/4 v0, 0x1

    goto :goto_0

    :cond_4
    const/4 v0, 0x0

    :goto_0
    iget-object v4, p0, Lb/a/a/i;->d:Landroid/hardware/usb/UsbInterface;

    invoke-virtual {v4}, Landroid/hardware/usb/UsbInterface;->getId()I

    move-result v4

    if-eqz v4, :cond_5

    const/4 v4, 0x1

    goto :goto_1

    :cond_5
    const/4 v4, 0x0

    :goto_1
    and-int/2addr v0, v4

    if-eqz v0, :cond_11

    return v2

    :cond_6
    const/4 v4, 0x5

    if-ne v0, v4, :cond_7

    if-eqz p2, :cond_7

    and-int/lit8 v0, p2, 0x25

    if-nez v0, :cond_11

    return v2

    :cond_7
    const/4 v4, 0x6

    if-ne v0, v4, :cond_b

    if-eqz p2, :cond_b

    and-int/lit8 v0, p2, 0x5f

    if-nez v0, :cond_8

    return v2

    :cond_8
    and-int/lit8 v0, p2, 0x48

    if-lez v0, :cond_9

    const/4 v0, 0x1

    goto :goto_2

    :cond_9
    const/4 v0, 0x0

    :goto_2
    iget-object v4, p0, Lb/a/a/i;->d:Landroid/hardware/usb/UsbInterface;

    invoke-virtual {v4}, Landroid/hardware/usb/UsbInterface;->getId()I

    move-result v4

    if-eqz v4, :cond_a

    const/4 v4, 0x1

    goto :goto_3

    :cond_a
    const/4 v4, 0x0

    :goto_3
    and-int/2addr v0, v4

    if-eqz v0, :cond_11

    return v2

    :cond_b
    const/4 v4, 0x7

    if-ne v0, v4, :cond_10

    if-eqz p2, :cond_10

    and-int/lit8 v0, p2, 0x7

    if-nez v0, :cond_c

    return v2

    :cond_c
    if-ne p2, v5, :cond_d

    const/4 v0, 0x1

    goto :goto_4

    :cond_d
    const/4 v0, 0x0

    :goto_4
    iget-object v4, p0, Lb/a/a/i;->d:Landroid/hardware/usb/UsbInterface;

    invoke-virtual {v4}, Landroid/hardware/usb/UsbInterface;->getId()I

    move-result v4

    if-eqz v4, :cond_e

    const/4 v4, 0x1

    goto :goto_5

    :cond_e
    const/4 v4, 0x0

    :goto_5
    and-int/2addr v0, v4

    iget-object v4, p0, Lb/a/a/i;->d:Landroid/hardware/usb/UsbInterface;

    invoke-virtual {v4}, Landroid/hardware/usb/UsbInterface;->getId()I

    move-result v4

    if-eq v4, v1, :cond_f

    const/4 v4, 0x1

    goto :goto_6

    :cond_f
    const/4 v4, 0x0

    :goto_6
    and-int/2addr v0, v4

    if-eqz v0, :cond_11

    return v2

    :cond_10
    if-ne v0, v3, :cond_11

    if-eqz p2, :cond_11

    const/16 v0, 0x40

    if-le p2, v0, :cond_11

    return v2

    :cond_11
    shl-int/2addr p2, v3

    and-int/lit16 p1, p1, 0xff

    or-int v6, p2, p1

    invoke-virtual {p0}, Lb/a/a/i;->d()Landroid/hardware/usb/UsbDeviceConnection;

    move-result-object v3

    const/16 v4, 0x40

    const/16 v5, 0xb

    iget v7, p0, Lb/a/a/i;->q:I

    const/4 v8, 0x0

    const/4 v9, 0x0

    const/4 v10, 0x0

    invoke-virtual/range {v3 .. v10}, Landroid/hardware/usb/UsbDeviceConnection;->controlTransfer(IIII[BII)I

    move-result p1

    if-nez p1, :cond_12

    const/4 v2, 0x1

    :cond_12
    return v2
.end method

.method public C()Z
    .locals 1

    const/4 v0, 0x0

    invoke-direct {p0, v0}, Lb/a/a/i;->B(I)Z

    move-result v0

    return v0
.end method

.method public D()Z
    .locals 1

    const/16 v0, 0x4000

    invoke-direct {p0, v0}, Lb/a/a/i;->B(I)Z

    move-result v0

    return v0
.end method

.method F(Landroid/hardware/usb/UsbDeviceConnection;)V
    .locals 0

    iput-object p1, p0, Lb/a/a/i;->h:Landroid/hardware/usb/UsbDeviceConnection;

    return-void
.end method

.method declared-synchronized G(Landroid/content/Context;)Z
    .locals 1

    monitor-enter p0

    const/4 v0, 0x0

    if-eqz p1, :cond_0

    :try_start_0
    iput-object p1, p0, Lb/a/a/i;->r:Landroid/content/Context;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    const/4 v0, 0x1

    goto :goto_0

    :catchall_0
    move-exception p1

    monitor-exit p0

    throw p1

    :cond_0
    :goto_0
    monitor-exit p0

    return v0
.end method

.method public H(BBB)Z
    .locals 10

    invoke-virtual {p0}, Lb/a/a/i;->t()Z

    move-result v0

    const/4 v1, 0x0

    if-nez v0, :cond_0

    return v1

    :cond_0
    shl-int/lit8 p3, p3, 0x8

    or-int/2addr p1, p3

    int-to-short p1, p1

    shl-int/lit8 p2, p2, 0xb

    or-int/2addr p1, p2

    int-to-short v5, p1

    iget-object p1, p0, Lb/a/a/i;->l:Lb/a/a/f;

    iput v5, p1, Lb/a/a/f;->i:I

    invoke-virtual {p0}, Lb/a/a/i;->d()Landroid/hardware/usb/UsbDeviceConnection;

    move-result-object v2

    const/16 v3, 0x40

    const/4 v4, 0x4

    iget v6, p0, Lb/a/a/i;->q:I

    const/4 v7, 0x0

    const/4 v8, 0x0

    const/4 v9, 0x0

    invoke-virtual/range {v2 .. v9}, Landroid/hardware/usb/UsbDeviceConnection;->controlTransfer(IIII[BII)I

    move-result p1

    if-nez p1, :cond_1

    const/4 v1, 0x1

    :cond_1
    return v1
.end method

.method protected I(Lb/a/a/e;)V
    .locals 2

    iget-object v0, p0, Lb/a/a/i;->p:Lb/a/a/e;

    invoke-virtual {p1}, Lb/a/a/e;->b()I

    move-result v1

    invoke-virtual {v0, v1}, Lb/a/a/e;->f(I)Z

    iget-object v0, p0, Lb/a/a/i;->p:Lb/a/a/e;

    invoke-virtual {p1}, Lb/a/a/e;->c()I

    move-result v1

    invoke-virtual {v0, v1}, Lb/a/a/e;->g(I)Z

    iget-object v0, p0, Lb/a/a/i;->p:Lb/a/a/e;

    invoke-virtual {p1}, Lb/a/a/e;->a()I

    move-result v1

    invoke-virtual {v0, v1}, Lb/a/a/e;->e(I)Z

    iget-object v0, p0, Lb/a/a/i;->p:Lb/a/a/e;

    invoke-virtual {p1}, Lb/a/a/e;->d()I

    move-result p1

    invoke-virtual {v0, p1}, Lb/a/a/e;->h(I)Z

    return-void
.end method

.method public J()Z
    .locals 10

    invoke-virtual {p0}, Lb/a/a/i;->t()Z

    move-result v0

    const/4 v1, 0x0

    if-nez v0, :cond_0

    return v1

    :cond_0
    invoke-virtual {p0}, Lb/a/a/i;->d()Landroid/hardware/usb/UsbDeviceConnection;

    move-result-object v2

    const/16 v3, 0x40

    const/4 v4, 0x1

    iget v6, p0, Lb/a/a/i;->q:I

    const/4 v7, 0x0

    const/4 v8, 0x0

    const/4 v9, 0x0

    const/16 v5, 0x101

    invoke-virtual/range {v2 .. v9}, Landroid/hardware/usb/UsbDeviceConnection;->controlTransfer(IIII[BII)I

    move-result v0

    if-nez v0, :cond_1

    const/4 v1, 0x1

    :cond_1
    return v1
.end method

.method public K(SBB)Z
    .locals 10

    invoke-virtual {p0}, Lb/a/a/i;->t()Z

    move-result v0

    const/4 v1, 0x0

    if-nez v0, :cond_0

    return v1

    :cond_0
    const/16 v0, 0x400

    if-ne p1, v0, :cond_1

    shl-int/lit8 p3, p3, 0x8

    int-to-short p3, p3

    and-int/lit16 p2, p2, 0xff

    or-int/2addr p2, p3

    int-to-short p2, p2

    move v5, p2

    goto :goto_0

    :cond_1
    const/4 v5, 0x0

    :goto_0
    invoke-virtual {p0}, Lb/a/a/i;->d()Landroid/hardware/usb/UsbDeviceConnection;

    move-result-object v2

    const/16 v3, 0x40

    const/4 v4, 0x2

    iget p2, p0, Lb/a/a/i;->q:I

    or-int v6, p2, p1

    const/4 v7, 0x0

    const/4 v8, 0x0

    const/4 v9, 0x0

    invoke-virtual/range {v2 .. v9}, Landroid/hardware/usb/UsbDeviceConnection;->controlTransfer(IIII[BII)I

    move-result p2

    if-nez p2, :cond_3

    const/4 v1, 0x1

    const/16 p2, 0x100

    if-ne p1, p2, :cond_2

    invoke-virtual {p0}, Lb/a/a/i;->N()Z

    move-result v1

    goto :goto_1

    :cond_2
    const/16 p2, 0x200

    if-ne p1, p2, :cond_3

    invoke-virtual {p0}, Lb/a/a/i;->J()Z

    move-result v1

    :cond_3
    :goto_1
    return v1
.end method

.method public L(B)Z
    .locals 9

    and-int/lit16 v3, p1, 0xff

    invoke-virtual {p0}, Lb/a/a/i;->t()Z

    move-result p1

    const/4 v8, 0x0

    if-nez p1, :cond_0

    return v8

    :cond_0
    invoke-virtual {p0}, Lb/a/a/i;->d()Landroid/hardware/usb/UsbDeviceConnection;

    move-result-object v0

    const/16 v1, 0x40

    const/16 v2, 0x9

    iget v4, p0, Lb/a/a/i;->q:I

    const/4 v5, 0x0

    const/4 v6, 0x0

    const/4 v7, 0x0

    invoke-virtual/range {v0 .. v7}, Landroid/hardware/usb/UsbDeviceConnection;->controlTransfer(IIII[BII)I

    move-result p1

    if-nez p1, :cond_1

    const/4 v8, 0x1

    :cond_1
    return v8
.end method

.method public N()Z
    .locals 10

    invoke-virtual {p0}, Lb/a/a/i;->t()Z

    move-result v0

    const/4 v1, 0x0

    if-nez v0, :cond_0

    return v1

    :cond_0
    invoke-virtual {p0}, Lb/a/a/i;->d()Landroid/hardware/usb/UsbDeviceConnection;

    move-result-object v2

    const/16 v3, 0x40

    const/4 v4, 0x1

    iget v6, p0, Lb/a/a/i;->q:I

    const/4 v7, 0x0

    const/4 v8, 0x0

    const/4 v9, 0x0

    const/16 v5, 0x202

    invoke-virtual/range {v2 .. v9}, Landroid/hardware/usb/UsbDeviceConnection;->controlTransfer(IIII[BII)I

    move-result v0

    if-nez v0, :cond_1

    const/4 v1, 0x1

    :cond_1
    return v1
.end method

.method public P([BIZ)I
    .locals 2

    invoke-virtual {p0}, Lb/a/a/i;->t()Z

    move-result v0

    const/4 v1, -0x1

    if-nez v0, :cond_0

    return v1

    :cond_0
    if-gez p2, :cond_1

    return v1

    :cond_1
    iget-object v0, p0, Lb/a/a/i;->g:Landroid/hardware/usb/UsbRequest;

    if-eqz p3, :cond_2

    invoke-virtual {v0, p0}, Landroid/hardware/usb/UsbRequest;->setClientData(Ljava/lang/Object;)V

    :cond_2
    if-nez p2, :cond_3

    const/4 p1, 0x1

    new-array p1, p1, [B

    invoke-static {p1}, Ljava/nio/ByteBuffer;->wrap([B)Ljava/nio/ByteBuffer;

    move-result-object p1

    invoke-virtual {v0, p1, p2}, Landroid/hardware/usb/UsbRequest;->queue(Ljava/nio/ByteBuffer;I)Z

    move-result p1

    if-eqz p1, :cond_4

    goto :goto_0

    :cond_3
    invoke-static {p1}, Ljava/nio/ByteBuffer;->wrap([B)Ljava/nio/ByteBuffer;

    move-result-object p1

    invoke-virtual {v0, p1, p2}, Landroid/hardware/usb/UsbRequest;->queue(Ljava/nio/ByteBuffer;I)Z

    move-result p1

    if-eqz p1, :cond_4

    goto :goto_0

    :cond_4
    const/4 p2, -0x1

    :goto_0
    if-eqz p3, :cond_7

    :cond_5
    iget-object p1, p0, Lb/a/a/i;->h:Landroid/hardware/usb/UsbDeviceConnection;

    invoke-virtual {p1}, Landroid/hardware/usb/UsbDeviceConnection;->requestWait()Landroid/hardware/usb/UsbRequest;

    move-result-object p1

    if-eqz p1, :cond_6

    invoke-virtual {p1}, Landroid/hardware/usb/UsbRequest;->getClientData()Ljava/lang/Object;

    move-result-object p1

    if-ne p1, p0, :cond_5

    goto :goto_1

    :cond_6
    const-string p1, "FTDI_Device::"

    const-string p2, "UsbConnection.requestWait() == null"

    invoke-static {p1, p2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    const/16 p1, -0x63

    return p1

    :cond_7
    :goto_1
    return p2
.end method

.method public declared-synchronized a()V
    .locals 3

    monitor-enter p0

    :try_start_0
    iget-object v0, p0, Lb/a/a/i;->j:Ljava/lang/Thread;

    if-eqz v0, :cond_0

    invoke-virtual {v0}, Ljava/lang/Thread;->interrupt()V

    :cond_0
    iget-object v0, p0, Lb/a/a/i;->k:Ljava/lang/Thread;

    if-eqz v0, :cond_1

    invoke-virtual {v0}, Ljava/lang/Thread;->interrupt()V

    :cond_1
    iget-object v0, p0, Lb/a/a/i;->h:Landroid/hardware/usb/UsbDeviceConnection;

    const/4 v1, 0x0

    if-eqz v0, :cond_2

    iget-object v2, p0, Lb/a/a/i;->d:Landroid/hardware/usb/UsbInterface;

    invoke-virtual {v0, v2}, Landroid/hardware/usb/UsbDeviceConnection;->releaseInterface(Landroid/hardware/usb/UsbInterface;)Z

    iget-object v0, p0, Lb/a/a/i;->h:Landroid/hardware/usb/UsbDeviceConnection;

    invoke-virtual {v0}, Landroid/hardware/usb/UsbDeviceConnection;->close()V

    iput-object v1, p0, Lb/a/a/i;->h:Landroid/hardware/usb/UsbDeviceConnection;

    :cond_2
    iget-object v0, p0, Lb/a/a/i;->m:Lb/a/a/v;

    if-eqz v0, :cond_3

    invoke-virtual {v0}, Lb/a/a/v;->c()V

    :cond_3
    iput-object v1, p0, Lb/a/a/i;->j:Ljava/lang/Thread;

    iput-object v1, p0, Lb/a/a/i;->k:Ljava/lang/Thread;

    iput-object v1, p0, Lb/a/a/i;->i:Lb/a/a/a;

    iput-object v1, p0, Lb/a/a/i;->m:Lb/a/a/v;

    invoke-direct {p0}, Lb/a/a/i;->E()V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return-void

    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method d()Landroid/hardware/usb/UsbDeviceConnection;
    .locals 1

    iget-object v0, p0, Lb/a/a/i;->h:Landroid/hardware/usb/UsbDeviceConnection;

    return-object v0
.end method

.method e()Lb/a/a/e;
    .locals 1

    iget-object v0, p0, Lb/a/a/i;->p:Lb/a/a/e;

    return-object v0
.end method

.method public f()B
    .locals 10

    const/4 v0, 0x1

    new-array v9, v0, [B

    invoke-virtual {p0}, Lb/a/a/i;->t()Z

    move-result v1

    if-nez v1, :cond_0

    const/4 v0, -0x1

    return v0

    :cond_0
    invoke-virtual {p0}, Lb/a/a/i;->d()Landroid/hardware/usb/UsbDeviceConnection;

    move-result-object v1

    const/16 v2, -0x40

    const/16 v3, 0xa

    const/4 v4, 0x0

    iget v5, p0, Lb/a/a/i;->q:I

    const/4 v8, 0x0

    const/4 v7, 0x1

    move-object v6, v9

    invoke-virtual/range {v1 .. v8}, Landroid/hardware/usb/UsbDeviceConnection;->controlTransfer(IIII[BII)I

    move-result v1

    const/4 v2, 0x0

    if-ne v1, v0, :cond_1

    aget-byte v0, v9, v2

    return v0

    :cond_1
    return v2
.end method

.method g()I
    .locals 1

    iget v0, p0, Lb/a/a/i;->s:I

    return v0
.end method

.method public h()I
    .locals 1

    invoke-virtual {p0}, Lb/a/a/i;->t()Z

    move-result v0

    if-nez v0, :cond_0

    const/4 v0, -0x1

    return v0

    :cond_0
    iget-object v0, p0, Lb/a/a/i;->m:Lb/a/a/v;

    if-nez v0, :cond_1

    const/4 v0, -0x2

    return v0

    :cond_1
    invoke-virtual {v0}, Lb/a/a/v;->g()I

    move-result v0

    return v0
.end method

.method protected i()Landroid/hardware/usb/UsbDevice;
    .locals 1

    iget-object v0, p0, Lb/a/a/i;->c:Landroid/hardware/usb/UsbDevice;

    return-object v0
.end method

.method final q()Z
    .locals 2

    iget-object v0, p0, Lb/a/a/i;->l:Lb/a/a/f;

    iget-short v0, v0, Lb/a/a/f;->b:S

    const v1, 0xff00

    and-int/2addr v0, v1

    const/16 v1, 0x800

    if-ne v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method final s()Z
    .locals 1

    invoke-direct {p0}, Lb/a/a/i;->k()Z

    move-result v0

    if-nez v0, :cond_0

    invoke-direct {p0}, Lb/a/a/i;->l()Z

    move-result v0

    if-nez v0, :cond_0

    invoke-virtual {p0}, Lb/a/a/i;->q()Z

    move-result v0

    if-nez v0, :cond_0

    const/4 v0, 0x0

    return v0

    :cond_0
    const/4 v0, 0x1

    return v0
.end method

.method public declared-synchronized t()Z
    .locals 1

    monitor-enter p0

    :try_start_0
    iget-object v0, p0, Lb/a/a/i;->b:Ljava/lang/Boolean;

    invoke-virtual {v0}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return v0

    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method declared-synchronized u(Landroid/hardware/usb/UsbManager;)Z
    .locals 4

    monitor-enter p0

    const/4 v0, 0x0

    :try_start_0
    invoke-virtual {p0}, Lb/a/a/i;->t()Z

    move-result v1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    if-eqz v1, :cond_0

    monitor-exit p0

    return v0

    :cond_0
    if-nez p1, :cond_1

    :try_start_1
    const-string p1, "FTDI_Device::"

    const-string v1, "UsbManager cannot be null."

    invoke-static {p1, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    monitor-exit p0

    return v0

    :cond_1
    :try_start_2
    invoke-virtual {p0}, Lb/a/a/i;->d()Landroid/hardware/usb/UsbDeviceConnection;

    move-result-object v1

    if-eqz v1, :cond_2

    const-string p1, "FTDI_Device::"

    const-string v1, "There should not have an UsbConnection."

    invoke-static {p1, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    monitor-exit p0

    return v0

    :cond_2
    :try_start_3
    iget-object v1, p0, Lb/a/a/i;->c:Landroid/hardware/usb/UsbDevice;

    invoke-virtual {p1, v1}, Landroid/hardware/usb/UsbManager;->openDevice(Landroid/hardware/usb/UsbDevice;)Landroid/hardware/usb/UsbDeviceConnection;

    move-result-object p1

    invoke-virtual {p0, p1}, Lb/a/a/i;->F(Landroid/hardware/usb/UsbDeviceConnection;)V

    invoke-virtual {p0}, Lb/a/a/i;->d()Landroid/hardware/usb/UsbDeviceConnection;

    move-result-object p1

    if-nez p1, :cond_3

    const-string p1, "FTDI_Device::"

    const-string v1, "UsbConnection cannot be null."

    invoke-static {p1, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_3
    .catchall {:try_start_3 .. :try_end_3} :catchall_0

    monitor-exit p0

    return v0

    :cond_3
    :try_start_4
    invoke-virtual {p0}, Lb/a/a/i;->d()Landroid/hardware/usb/UsbDeviceConnection;

    move-result-object p1

    iget-object v1, p0, Lb/a/a/i;->d:Landroid/hardware/usb/UsbInterface;

    const/4 v2, 0x1

    invoke-virtual {p1, v1, v2}, Landroid/hardware/usb/UsbDeviceConnection;->claimInterface(Landroid/hardware/usb/UsbInterface;Z)Z

    move-result p1

    if-nez p1, :cond_4

    const-string p1, "FTDI_Device::"

    const-string v1, "ClaimInteface returned false."

    invoke-static {p1, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_4
    .catchall {:try_start_4 .. :try_end_4} :catchall_0

    monitor-exit p0

    return v0

    :cond_4
    :try_start_5
    const-string p1, "FTDI_Device::"

    const-string v1, "open SUCCESS"

    invoke-static {p1, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    invoke-direct {p0}, Lb/a/a/i;->c()Z

    move-result p1

    if-nez p1, :cond_5

    const-string p1, "FTDI_Device::"

    const-string v1, "Failed to find endpoints."

    invoke-static {p1, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_5
    .catchall {:try_start_5 .. :try_end_5} :catchall_0

    monitor-exit p0

    return v0

    :cond_5
    :try_start_6
    iget-object p1, p0, Lb/a/a/i;->g:Landroid/hardware/usb/UsbRequest;

    iget-object v0, p0, Lb/a/a/i;->h:Landroid/hardware/usb/UsbDeviceConnection;

    iget-object v1, p0, Lb/a/a/i;->e:Landroid/hardware/usb/UsbEndpoint;

    invoke-virtual {p1, v0, v1}, Landroid/hardware/usb/UsbRequest;->initialize(Landroid/hardware/usb/UsbDeviceConnection;Landroid/hardware/usb/UsbEndpoint;)Z

    const-string p1, "D2XX::"

    const-string v0, "**********************Device Opened**********************"

    invoke-static {p1, v0}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    new-instance p1, Lb/a/a/v;

    invoke-direct {p1, p0}, Lb/a/a/v;-><init>(Lb/a/a/i;)V

    iput-object p1, p0, Lb/a/a/i;->m:Lb/a/a/v;

    new-instance v0, Lb/a/a/a;

    invoke-virtual {p0}, Lb/a/a/i;->d()Landroid/hardware/usb/UsbDeviceConnection;

    move-result-object v1

    iget-object v3, p0, Lb/a/a/i;->f:Landroid/hardware/usb/UsbEndpoint;

    invoke-direct {v0, p0, p1, v1, v3}, Lb/a/a/a;-><init>(Lb/a/a/i;Lb/a/a/v;Landroid/hardware/usb/UsbDeviceConnection;Landroid/hardware/usb/UsbEndpoint;)V

    iput-object v0, p0, Lb/a/a/i;->i:Lb/a/a/a;

    new-instance p1, Ljava/lang/Thread;

    iget-object v0, p0, Lb/a/a/i;->i:Lb/a/a/a;

    invoke-direct {p1, v0}, Ljava/lang/Thread;-><init>(Ljava/lang/Runnable;)V

    iput-object p1, p0, Lb/a/a/i;->k:Ljava/lang/Thread;

    const-string v0, "bulkInThread"

    invoke-virtual {p1, v0}, Ljava/lang/Thread;->setName(Ljava/lang/String;)V

    new-instance p1, Ljava/lang/Thread;

    new-instance v0, Lb/a/a/w;

    iget-object v1, p0, Lb/a/a/i;->m:Lb/a/a/v;

    invoke-direct {v0, v1}, Lb/a/a/w;-><init>(Lb/a/a/v;)V

    invoke-direct {p1, v0}, Ljava/lang/Thread;-><init>(Ljava/lang/Runnable;)V

    iput-object p1, p0, Lb/a/a/i;->j:Ljava/lang/Thread;

    const-string v0, "processRequestThread"

    invoke-virtual {p1, v0}, Ljava/lang/Thread;->setName(Ljava/lang/String;)V

    invoke-direct {p0, v2, v2}, Lb/a/a/i;->w(ZZ)Z

    iget-object p1, p0, Lb/a/a/i;->k:Ljava/lang/Thread;

    invoke-virtual {p1}, Ljava/lang/Thread;->start()V

    iget-object p1, p0, Lb/a/a/i;->j:Ljava/lang/Thread;

    invoke-virtual {p1}, Ljava/lang/Thread;->start()V

    invoke-direct {p0}, Lb/a/a/i;->M()V
    :try_end_6
    .catchall {:try_start_6 .. :try_end_6} :catchall_0

    monitor-exit p0

    return v2

    :catchall_0
    move-exception p1

    monitor-exit p0

    throw p1
.end method

.method public v(B)Z
    .locals 4

    and-int/lit8 v0, p1, 0x1

    const/4 v1, 0x0

    const/4 v2, 0x1

    if-ne v0, v2, :cond_0

    const/4 v0, 0x1

    goto :goto_0

    :cond_0
    const/4 v0, 0x0

    :goto_0
    const/4 v3, 0x2

    and-int/2addr p1, v3

    if-ne p1, v3, :cond_1

    const/4 v1, 0x1

    :cond_1
    invoke-direct {p0, v0, v1}, Lb/a/a/i;->w(ZZ)Z

    move-result p1

    return p1
.end method

.method public x([BI)I
    .locals 2

    iget-object v0, p0, Lb/a/a/i;->p:Lb/a/a/e;

    invoke-virtual {v0}, Lb/a/a/e;->d()I

    move-result v0

    int-to-long v0, v0

    invoke-virtual {p0, p1, p2, v0, v1}, Lb/a/a/i;->y([BIJ)I

    move-result p1

    return p1
.end method

.method public y([BIJ)I
    .locals 1

    invoke-virtual {p0}, Lb/a/a/i;->t()Z

    move-result v0

    if-nez v0, :cond_0

    const/4 p1, -0x1

    return p1

    :cond_0
    if-gtz p2, :cond_1

    const/4 p1, -0x2

    return p1

    :cond_1
    iget-object v0, p0, Lb/a/a/i;->m:Lb/a/a/v;

    if-nez v0, :cond_2

    const/4 p1, -0x3

    return p1

    :cond_2
    invoke-virtual {v0, p1, p2, p3, p4}, Lb/a/a/v;->n([BIJ)I

    move-result p1

    return p1
.end method

.method public z(I)Z
    .locals 12

    const/4 v0, 0x2

    new-array v0, v0, [I

    invoke-virtual {p0}, Lb/a/a/i;->t()Z

    move-result v1

    const/4 v2, 0x0

    if-nez v1, :cond_0

    return v2

    :cond_0
    const/4 v1, 0x1

    sparse-switch p1, :sswitch_data_0

    invoke-direct {p0}, Lb/a/a/i;->r()Z

    move-result v3

    if-eqz v3, :cond_1

    const/16 v3, 0x4b0

    if-lt p1, v3, :cond_1

    invoke-static {p1, v0}, Lb/a/a/h;->f(I[I)B

    move-result p1

    goto :goto_1

    :sswitch_0
    const p1, 0x8003

    aput p1, v0, v2

    goto :goto_0

    :sswitch_1
    const/16 p1, 0x4006

    aput p1, v0, v2

    goto :goto_0

    :sswitch_2
    const/16 p1, 0xd

    aput p1, v0, v2

    goto :goto_0

    :sswitch_3
    const/16 p1, 0x1a

    aput p1, v0, v2

    goto :goto_0

    :sswitch_4
    const/16 p1, 0x34

    aput p1, v0, v2

    goto :goto_0

    :sswitch_5
    const p1, 0xc04e

    aput p1, v0, v2

    goto :goto_0

    :sswitch_6
    const p1, 0x809c

    aput p1, v0, v2

    goto :goto_0

    :sswitch_7
    const/16 p1, 0x4138

    aput p1, v0, v2

    goto :goto_0

    :sswitch_8
    const/16 p1, 0x271

    aput p1, v0, v2

    goto :goto_0

    :sswitch_9
    const/16 p1, 0x4e2

    aput p1, v0, v2

    goto :goto_0

    :sswitch_a
    const/16 p1, 0x9c4

    aput p1, v0, v2

    goto :goto_0

    :sswitch_b
    const/16 p1, 0x1388

    aput p1, v0, v2

    goto :goto_0

    :sswitch_c
    const/16 p1, 0x2710

    aput p1, v0, v2

    :goto_0
    const/4 p1, 0x1

    goto :goto_1

    :cond_1
    invoke-direct {p0}, Lb/a/a/i;->j()Z

    move-result v3

    invoke-static {p1, v0, v3}, Lb/a/a/h;->e(I[IZ)B

    move-result p1

    :goto_1
    invoke-virtual {p0}, Lb/a/a/i;->s()Z

    move-result v3

    if-nez v3, :cond_2

    invoke-direct {p0}, Lb/a/a/i;->o()Z

    move-result v3

    if-nez v3, :cond_2

    invoke-direct {p0}, Lb/a/a/i;->n()Z

    move-result v3

    if-eqz v3, :cond_3

    :cond_2
    aget v3, v0, v1

    shl-int/lit8 v3, v3, 0x8

    aput v3, v0, v1

    aget v3, v0, v1

    const v4, 0xff00

    and-int/2addr v3, v4

    aput v3, v0, v1

    aget v3, v0, v1

    iget v4, p0, Lb/a/a/i;->q:I

    or-int/2addr v3, v4

    aput v3, v0, v1

    :cond_3
    if-ne p1, v1, :cond_4

    invoke-virtual {p0}, Lb/a/a/i;->d()Landroid/hardware/usb/UsbDeviceConnection;

    move-result-object v4

    const/16 v5, 0x40

    const/4 v6, 0x3

    aget v7, v0, v2

    aget v8, v0, v1

    const/4 v9, 0x0

    const/4 v10, 0x0

    const/4 v11, 0x0

    invoke-virtual/range {v4 .. v11}, Landroid/hardware/usb/UsbDeviceConnection;->controlTransfer(IIII[BII)I

    move-result p1

    if-nez p1, :cond_4

    const/4 v2, 0x1

    :cond_4
    return v2

    :sswitch_data_0
    .sparse-switch
        0x12c -> :sswitch_c
        0x258 -> :sswitch_b
        0x4b0 -> :sswitch_a
        0x960 -> :sswitch_9
        0x12c0 -> :sswitch_8
        0x2580 -> :sswitch_7
        0x4b00 -> :sswitch_6
        0x9600 -> :sswitch_5
        0xe100 -> :sswitch_4
        0x1c200 -> :sswitch_3
        0x38400 -> :sswitch_2
        0x70800 -> :sswitch_1
        0xe1000 -> :sswitch_0
    .end sparse-switch
.end method
