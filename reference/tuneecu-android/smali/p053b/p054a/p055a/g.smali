.class public Lb/a/a/g;
.super Ljava/lang/Object;
.source ""


# static fields
.field private static c:Lb/a/a/g; = null

.field private static d:Z = true

.field private static e:Landroid/content/Context;

.field private static f:Landroid/app/PendingIntent;

.field private static g:Landroid/content/IntentFilter;

.field private static h:Ljava/util/List;

.field private static i:Landroid/hardware/usb/UsbManager;

.field private static j:Landroid/content/BroadcastReceiver;


# instance fields
.field private a:Ljava/util/ArrayList;

.field private b:Landroid/content/BroadcastReceiver;


# direct methods
.method static constructor <clinit>()V
    .locals 7

    new-instance v0, Ljava/util/ArrayList;

    const/16 v1, 0x11

    new-array v1, v1, [Lb/a/a/t;

    new-instance v2, Lb/a/a/t;

    const/16 v3, 0x403

    const/16 v4, 0x6015

    invoke-direct {v2, v3, v4}, Lb/a/a/t;-><init>(II)V

    const/4 v4, 0x0

    aput-object v2, v1, v4

    new-instance v2, Lb/a/a/t;

    const/16 v4, 0x6014

    invoke-direct {v2, v3, v4}, Lb/a/a/t;-><init>(II)V

    const/4 v4, 0x1

    aput-object v2, v1, v4

    new-instance v2, Lb/a/a/t;

    const/16 v5, 0x6011

    invoke-direct {v2, v3, v5}, Lb/a/a/t;-><init>(II)V

    const/4 v5, 0x2

    aput-object v2, v1, v5

    new-instance v2, Lb/a/a/t;

    const/16 v5, 0x6010

    invoke-direct {v2, v3, v5}, Lb/a/a/t;-><init>(II)V

    const/4 v5, 0x3

    aput-object v2, v1, v5

    new-instance v2, Lb/a/a/t;

    const/16 v5, 0x6001

    invoke-direct {v2, v3, v5}, Lb/a/a/t;-><init>(II)V

    const/4 v5, 0x4

    aput-object v2, v1, v5

    new-instance v2, Lb/a/a/t;

    const/16 v5, 0x6006

    invoke-direct {v2, v3, v5}, Lb/a/a/t;-><init>(II)V

    const/4 v5, 0x5

    aput-object v2, v1, v5

    new-instance v2, Lb/a/a/t;

    const/16 v5, 0x601c

    invoke-direct {v2, v3, v5}, Lb/a/a/t;-><init>(II)V

    const/4 v5, 0x6

    aput-object v2, v1, v5

    new-instance v2, Lb/a/a/t;

    const v5, 0xfac1

    invoke-direct {v2, v3, v5}, Lb/a/a/t;-><init>(II)V

    const/4 v5, 0x7

    aput-object v2, v1, v5

    new-instance v2, Lb/a/a/t;

    const v5, 0xfac2

    invoke-direct {v2, v3, v5}, Lb/a/a/t;-><init>(II)V

    const/16 v5, 0x8

    aput-object v2, v1, v5

    new-instance v2, Lb/a/a/t;

    const v5, 0xfac3

    invoke-direct {v2, v3, v5}, Lb/a/a/t;-><init>(II)V

    const/16 v5, 0x9

    aput-object v2, v1, v5

    new-instance v2, Lb/a/a/t;

    const v5, 0xfac4

    invoke-direct {v2, v3, v5}, Lb/a/a/t;-><init>(II)V

    const/16 v5, 0xa

    aput-object v2, v1, v5

    new-instance v2, Lb/a/a/t;

    const v5, 0xfac5

    invoke-direct {v2, v3, v5}, Lb/a/a/t;-><init>(II)V

    const/16 v5, 0xb

    aput-object v2, v1, v5

    new-instance v2, Lb/a/a/t;

    const v5, 0xfac6

    invoke-direct {v2, v3, v5}, Lb/a/a/t;-><init>(II)V

    const/16 v5, 0xc

    aput-object v2, v1, v5

    new-instance v2, Lb/a/a/t;

    const/16 v5, 0x6012

    invoke-direct {v2, v3, v5}, Lb/a/a/t;-><init>(II)V

    const/16 v5, 0xd

    aput-object v2, v1, v5

    new-instance v2, Lb/a/a/t;

    const/16 v5, 0x8ac

    const/16 v6, 0x1025

    invoke-direct {v2, v5, v6}, Lb/a/a/t;-><init>(II)V

    const/16 v5, 0xe

    aput-object v2, v1, v5

    new-instance v2, Lb/a/a/t;

    const/16 v5, 0x15d6

    invoke-direct {v2, v5, v4}, Lb/a/a/t;-><init>(II)V

    const/16 v4, 0xf

    aput-object v2, v1, v4

    new-instance v2, Lb/a/a/t;

    const/16 v4, 0x6017

    invoke-direct {v2, v3, v4}, Lb/a/a/t;-><init>(II)V

    const/16 v3, 0x10

    aput-object v2, v1, v3

    invoke-static {v1}, Ljava/util/Arrays;->asList([Ljava/lang/Object;)Ljava/util/List;

    move-result-object v1

    invoke-direct {v0, v1}, Ljava/util/ArrayList;-><init>(Ljava/util/Collection;)V

    sput-object v0, Lb/a/a/g;->h:Ljava/util/List;

    new-instance v0, Lb/a/a/c;

    invoke-direct {v0}, Lb/a/a/c;-><init>()V

    sput-object v0, Lb/a/a/g;->j:Landroid/content/BroadcastReceiver;

    return-void
.end method

.method private constructor <init>(Landroid/content/Context;)V
    .locals 3

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    new-instance v0, Lb/a/a/b;

    invoke-direct {v0, p0}, Lb/a/a/b;-><init>(Lb/a/a/g;)V

    iput-object v0, p0, Lb/a/a/g;->b:Landroid/content/BroadcastReceiver;

    const-string v0, "D2xx::"

    const-string v1, "Start constructor"

    invoke-static {v0, v1}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    if-eqz p1, :cond_1

    invoke-static {p1}, Lb/a/a/g;->q(Landroid/content/Context;)Z

    invoke-static {}, Lb/a/a/g;->h()Z

    move-result v1

    if-eqz v1, :cond_0

    new-instance v1, Ljava/util/ArrayList;

    invoke-direct {v1}, Ljava/util/ArrayList;-><init>()V

    iput-object v1, p0, Lb/a/a/g;->a:Ljava/util/ArrayList;

    new-instance v1, Landroid/content/IntentFilter;

    invoke-direct {v1}, Landroid/content/IntentFilter;-><init>()V

    const-string v2, "android.hardware.usb.action.USB_DEVICE_ATTACHED"

    invoke-virtual {v1, v2}, Landroid/content/IntentFilter;->addAction(Ljava/lang/String;)V

    const-string v2, "android.hardware.usb.action.USB_DEVICE_DETACHED"

    invoke-virtual {v1, v2}, Landroid/content/IntentFilter;->addAction(Ljava/lang/String;)V

    invoke-virtual {p1}, Landroid/content/Context;->getApplicationContext()Landroid/content/Context;

    move-result-object p1

    iget-object v2, p0, Lb/a/a/g;->b:Landroid/content/BroadcastReceiver;

    invoke-virtual {p1, v2, v1}, Landroid/content/Context;->registerReceiver(Landroid/content/BroadcastReceiver;Landroid/content/IntentFilter;)Landroid/content/Intent;

    const-string p1, "End constructor"

    invoke-static {v0, p1}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    return-void

    :cond_0
    new-instance p1, Lb/a/a/d;

    const-string v0, "D2xx init failed: Can not find UsbManager!"

    invoke-direct {p1, v0}, Lb/a/a/d;-><init>(Ljava/lang/String;)V

    throw p1

    :cond_1
    new-instance p1, Lb/a/a/d;

    const-string v0, "D2xx init failed: Can not find parentContext!"

    invoke-direct {p1, v0}, Lb/a/a/d;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method static synthetic a(Lb/a/a/g;Landroid/hardware/usb/UsbDevice;)Lb/a/a/i;
    .locals 0

    invoke-direct {p0, p1}, Lb/a/a/g;->g(Landroid/hardware/usb/UsbDevice;)Lb/a/a/i;

    move-result-object p0

    return-object p0
.end method

.method static synthetic b(Lb/a/a/g;)Ljava/util/ArrayList;
    .locals 0

    iget-object p0, p0, Lb/a/a/g;->a:Ljava/util/ArrayList;

    return-object p0
.end method

.method private d(Landroid/hardware/usb/UsbDevice;)Z
    .locals 2

    sget-object v0, Lb/a/a/g;->i:Landroid/hardware/usb/UsbManager;

    invoke-virtual {v0, p1}, Landroid/hardware/usb/UsbManager;->hasPermission(Landroid/hardware/usb/UsbDevice;)Z

    move-result v0

    if-nez v0, :cond_0

    sget-object v0, Lb/a/a/g;->i:Landroid/hardware/usb/UsbManager;

    sget-object v1, Lb/a/a/g;->f:Landroid/app/PendingIntent;

    invoke-virtual {v0, p1, v1}, Landroid/hardware/usb/UsbManager;->requestPermission(Landroid/hardware/usb/UsbDevice;Landroid/app/PendingIntent;)V

    :cond_0
    sget-object v0, Lb/a/a/g;->i:Landroid/hardware/usb/UsbManager;

    invoke-virtual {v0, p1}, Landroid/hardware/usb/UsbManager;->hasPermission(Landroid/hardware/usb/UsbDevice;)Z

    move-result p1

    return p1
.end method

.method private e()V
    .locals 5

    iget-object v0, p0, Lb/a/a/g;->a:Ljava/util/ArrayList;

    monitor-enter v0

    :try_start_0
    iget-object v1, p0, Lb/a/a/g;->a:Ljava/util/ArrayList;

    invoke-virtual {v1}, Ljava/util/ArrayList;->size()I

    move-result v1

    const/4 v2, 0x0

    const/4 v3, 0x0

    :goto_0
    if-lt v3, v1, :cond_0

    monitor-exit v0

    return-void

    :cond_0
    iget-object v4, p0, Lb/a/a/g;->a:Ljava/util/ArrayList;

    invoke-virtual {v4, v2}, Ljava/util/ArrayList;->remove(I)Ljava/lang/Object;

    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    :catchall_0
    move-exception v1

    monitor-exit v0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    goto :goto_2

    :goto_1
    throw v1

    :goto_2
    goto :goto_1
.end method

.method private g(Landroid/hardware/usb/UsbDevice;)Lb/a/a/i;
    .locals 5

    iget-object v0, p0, Lb/a/a/g;->a:Ljava/util/ArrayList;

    monitor-enter v0

    :try_start_0
    iget-object v1, p0, Lb/a/a/g;->a:Ljava/util/ArrayList;

    invoke-virtual {v1}, Ljava/util/ArrayList;->size()I

    move-result v1

    const/4 v2, 0x0

    :goto_0
    if-lt v2, v1, :cond_0

    const/4 p1, 0x0

    goto :goto_1

    :cond_0
    iget-object v3, p0, Lb/a/a/g;->a:Ljava/util/ArrayList;

    invoke-virtual {v3, v2}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Lb/a/a/i;

    invoke-virtual {v3}, Lb/a/a/i;->i()Landroid/hardware/usb/UsbDevice;

    move-result-object v4

    invoke-virtual {v4, p1}, Landroid/hardware/usb/UsbDevice;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_1

    move-object p1, v3

    :goto_1
    monitor-exit v0

    return-object p1

    :cond_1
    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :catchall_0
    move-exception p1

    monitor-exit v0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    goto :goto_3

    :goto_2
    throw p1

    :goto_3
    goto :goto_2
.end method

.method private static h()Z
    .locals 2

    sget-object v0, Lb/a/a/g;->i:Landroid/hardware/usb/UsbManager;

    if-nez v0, :cond_0

    sget-object v0, Lb/a/a/g;->e:Landroid/content/Context;

    if-eqz v0, :cond_0

    invoke-virtual {v0}, Landroid/content/Context;->getApplicationContext()Landroid/content/Context;

    move-result-object v0

    const-string v1, "usb"

    invoke-virtual {v0, v1}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/hardware/usb/UsbManager;

    sput-object v0, Lb/a/a/g;->i:Landroid/hardware/usb/UsbManager;

    :cond_0
    sget-object v0, Lb/a/a/g;->i:Landroid/hardware/usb/UsbManager;

    if-nez v0, :cond_1

    const/4 v0, 0x0

    goto :goto_0

    :cond_1
    const/4 v0, 0x1

    :goto_0
    return v0
.end method

.method public static declared-synchronized j(Landroid/content/Context;)Lb/a/a/g;
    .locals 2

    const-class v0, Lb/a/a/g;

    monitor-enter v0

    :try_start_0
    sget-object v1, Lb/a/a/g;->c:Lb/a/a/g;

    if-nez v1, :cond_0

    new-instance v1, Lb/a/a/g;

    invoke-direct {v1, p0}, Lb/a/a/g;-><init>(Landroid/content/Context;)V

    sput-object v1, Lb/a/a/g;->c:Lb/a/a/g;

    :cond_0
    if-eqz p0, :cond_1

    invoke-static {p0}, Lb/a/a/g;->q(Landroid/content/Context;)Z

    :cond_1
    sget-object p0, Lb/a/a/g;->c:Lb/a/a/g;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit v0

    return-object p0

    :catchall_0
    move-exception p0

    monitor-exit v0

    throw p0
.end method

.method private l(Landroid/hardware/usb/UsbDevice;)Z
    .locals 2

    sget-boolean v0, Lb/a/a/g;->d:Z

    if-eqz v0, :cond_0

    sget-object v0, Lb/a/a/g;->i:Landroid/hardware/usb/UsbManager;

    invoke-virtual {v0, p1}, Landroid/hardware/usb/UsbManager;->hasPermission(Landroid/hardware/usb/UsbDevice;)Z

    move-result v0

    if-nez v0, :cond_0

    sget-object v0, Lb/a/a/g;->i:Landroid/hardware/usb/UsbManager;

    sget-object v1, Lb/a/a/g;->f:Landroid/app/PendingIntent;

    invoke-virtual {v0, p1, v1}, Landroid/hardware/usb/UsbManager;->requestPermission(Landroid/hardware/usb/UsbDevice;Landroid/app/PendingIntent;)V

    :cond_0
    sget-object v0, Lb/a/a/g;->i:Landroid/hardware/usb/UsbManager;

    invoke-virtual {v0, p1}, Landroid/hardware/usb/UsbManager;->hasPermission(Landroid/hardware/usb/UsbDevice;)Z

    move-result p1

    return p1
.end method

.method private p(Landroid/content/Context;Lb/a/a/i;Lb/a/a/e;)Z
    .locals 1

    const/4 v0, 0x0

    if-nez p2, :cond_0

    return v0

    :cond_0
    if-nez p1, :cond_1

    return v0

    :cond_1
    invoke-virtual {p2, p1}, Lb/a/a/i;->G(Landroid/content/Context;)Z

    if-eqz p3, :cond_2

    invoke-virtual {p2, p3}, Lb/a/a/i;->I(Lb/a/a/e;)V

    :cond_2
    sget-object p1, Lb/a/a/g;->i:Landroid/hardware/usb/UsbManager;

    invoke-virtual {p2, p1}, Lb/a/a/i;->u(Landroid/hardware/usb/UsbManager;)Z

    move-result p1

    if-eqz p1, :cond_3

    invoke-virtual {p2}, Lb/a/a/i;->t()Z

    move-result p1

    if-eqz p1, :cond_3

    const/4 v0, 0x1

    :cond_3
    return v0
.end method

.method private static declared-synchronized q(Landroid/content/Context;)Z
    .locals 4

    const-class v0, Lb/a/a/g;

    monitor-enter v0

    const/4 v1, 0x0

    if-nez p0, :cond_0

    monitor-exit v0

    return v1

    :cond_0
    :try_start_0
    sget-object v2, Lb/a/a/g;->e:Landroid/content/Context;

    if-eq v2, p0, :cond_1

    sput-object p0, Lb/a/a/g;->e:Landroid/content/Context;

    invoke-virtual {p0}, Landroid/content/Context;->getApplicationContext()Landroid/content/Context;

    move-result-object p0

    new-instance v2, Landroid/content/Intent;

    const-string v3, "com.ftdi.j2xx"

    invoke-direct {v2, v3}, Landroid/content/Intent;-><init>(Ljava/lang/String;)V

    const/high16 v3, 0x8000000

    invoke-static {p0, v1, v2, v3}, Landroid/app/PendingIntent;->getBroadcast(Landroid/content/Context;ILandroid/content/Intent;I)Landroid/app/PendingIntent;

    move-result-object p0

    sput-object p0, Lb/a/a/g;->f:Landroid/app/PendingIntent;

    new-instance p0, Landroid/content/IntentFilter;

    const-string v1, "com.ftdi.j2xx"

    invoke-direct {p0, v1}, Landroid/content/IntentFilter;-><init>(Ljava/lang/String;)V

    sput-object p0, Lb/a/a/g;->g:Landroid/content/IntentFilter;

    sget-object p0, Lb/a/a/g;->e:Landroid/content/Context;

    invoke-virtual {p0}, Landroid/content/Context;->getApplicationContext()Landroid/content/Context;

    move-result-object p0

    sget-object v1, Lb/a/a/g;->j:Landroid/content/BroadcastReceiver;

    sget-object v2, Lb/a/a/g;->g:Landroid/content/IntentFilter;

    invoke-virtual {p0, v1, v2}, Landroid/content/Context;->registerReceiver(Landroid/content/BroadcastReceiver;Landroid/content/IntentFilter;)Landroid/content/Intent;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    :cond_1
    const/4 p0, 0x1

    monitor-exit v0

    return p0

    :catchall_0
    move-exception p0

    monitor-exit v0

    throw p0
.end method


# virtual methods
.method public c(Landroid/hardware/usb/UsbDevice;)I
    .locals 8

    invoke-virtual {p0, p1}, Lb/a/a/g;->k(Landroid/hardware/usb/UsbDevice;)Z

    move-result v0

    const/4 v1, 0x0

    if-eqz v0, :cond_3

    invoke-virtual {p1}, Landroid/hardware/usb/UsbDevice;->getInterfaceCount()I

    move-result v0

    const/4 v2, 0x0

    :goto_0
    if-lt v1, v0, :cond_0

    move v1, v2

    goto :goto_3

    :cond_0
    invoke-direct {p0, p1}, Lb/a/a/g;->d(Landroid/hardware/usb/UsbDevice;)Z

    move-result v3

    if-nez v3, :cond_1

    goto :goto_2

    :cond_1
    iget-object v3, p0, Lb/a/a/g;->a:Ljava/util/ArrayList;

    monitor-enter v3

    :try_start_0
    invoke-direct {p0, p1}, Lb/a/a/g;->g(Landroid/hardware/usb/UsbDevice;)Lb/a/a/i;

    move-result-object v4

    if-nez v4, :cond_2

    new-instance v4, Lb/a/a/i;

    sget-object v5, Lb/a/a/g;->e:Landroid/content/Context;

    sget-object v6, Lb/a/a/g;->i:Landroid/hardware/usb/UsbManager;

    invoke-virtual {p1, v1}, Landroid/hardware/usb/UsbDevice;->getInterface(I)Landroid/hardware/usb/UsbInterface;

    move-result-object v7

    invoke-direct {v4, v5, v6, p1, v7}, Lb/a/a/i;-><init>(Landroid/content/Context;Landroid/hardware/usb/UsbManager;Landroid/hardware/usb/UsbDevice;Landroid/hardware/usb/UsbInterface;)V

    goto :goto_1

    :cond_2
    sget-object v5, Lb/a/a/g;->e:Landroid/content/Context;

    invoke-virtual {v4, v5}, Lb/a/a/i;->G(Landroid/content/Context;)Z

    iget-object v5, p0, Lb/a/a/g;->a:Ljava/util/ArrayList;

    invoke-virtual {v5, v4}, Ljava/util/ArrayList;->remove(Ljava/lang/Object;)Z

    :goto_1
    iget-object v5, p0, Lb/a/a/g;->a:Ljava/util/ArrayList;

    invoke-virtual {v5, v4}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    add-int/lit8 v2, v2, 0x1

    monitor-exit v3

    :goto_2
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :catchall_0
    move-exception p1

    monitor-exit v3
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p1

    :cond_3
    :goto_3
    return v1
.end method

.method public f(Landroid/content/Context;)I
    .locals 10

    sget-object v0, Lb/a/a/g;->i:Landroid/hardware/usb/UsbManager;

    invoke-virtual {v0}, Landroid/hardware/usb/UsbManager;->getDeviceList()Ljava/util/HashMap;

    move-result-object v0

    invoke-virtual {v0}, Ljava/util/HashMap;->values()Ljava/util/Collection;

    move-result-object v0

    invoke-interface {v0}, Ljava/util/Collection;->iterator()Ljava/util/Iterator;

    move-result-object v0

    new-instance v1, Ljava/util/ArrayList;

    invoke-direct {v1}, Ljava/util/ArrayList;-><init>()V

    const/4 v2, 0x0

    if-nez p1, :cond_0

    return v2

    :cond_0
    invoke-static {p1}, Lb/a/a/g;->q(Landroid/content/Context;)Z

    :cond_1
    :goto_0
    invoke-interface {v0}, Ljava/util/Iterator;->hasNext()Z

    move-result v3

    if-nez v3, :cond_2

    iget-object v3, p0, Lb/a/a/g;->a:Ljava/util/ArrayList;

    monitor-enter v3

    :try_start_0
    invoke-direct {p0}, Lb/a/a/g;->e()V

    iput-object v1, p0, Lb/a/a/g;->a:Ljava/util/ArrayList;

    invoke-virtual {v1}, Ljava/util/ArrayList;->size()I

    move-result p1

    monitor-exit v3

    return p1

    :catchall_0
    move-exception p1

    monitor-exit v3
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw p1

    :cond_2
    invoke-interface {v0}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Landroid/hardware/usb/UsbDevice;

    invoke-virtual {p0, v3}, Lb/a/a/g;->k(Landroid/hardware/usb/UsbDevice;)Z

    move-result v4

    if-eqz v4, :cond_1

    invoke-virtual {v3}, Landroid/hardware/usb/UsbDevice;->getInterfaceCount()I

    move-result v4

    const/4 v5, 0x0

    :goto_1
    if-lt v5, v4, :cond_3

    goto :goto_0

    :cond_3
    invoke-direct {p0, v3}, Lb/a/a/g;->l(Landroid/hardware/usb/UsbDevice;)Z

    move-result v6

    if-nez v6, :cond_4

    goto :goto_3

    :cond_4
    iget-object v6, p0, Lb/a/a/g;->a:Ljava/util/ArrayList;

    monitor-enter v6

    :try_start_1
    invoke-direct {p0, v3}, Lb/a/a/g;->g(Landroid/hardware/usb/UsbDevice;)Lb/a/a/i;

    move-result-object v7

    if-nez v7, :cond_5

    new-instance v7, Lb/a/a/i;

    sget-object v8, Lb/a/a/g;->i:Landroid/hardware/usb/UsbManager;

    invoke-virtual {v3, v5}, Landroid/hardware/usb/UsbDevice;->getInterface(I)Landroid/hardware/usb/UsbInterface;

    move-result-object v9

    invoke-direct {v7, p1, v8, v3, v9}, Lb/a/a/i;-><init>(Landroid/content/Context;Landroid/hardware/usb/UsbManager;Landroid/hardware/usb/UsbDevice;Landroid/hardware/usb/UsbInterface;)V

    goto :goto_2

    :cond_5
    iget-object v8, p0, Lb/a/a/g;->a:Ljava/util/ArrayList;

    invoke-virtual {v8, v7}, Ljava/util/ArrayList;->remove(Ljava/lang/Object;)Z

    invoke-virtual {v7, p1}, Lb/a/a/i;->G(Landroid/content/Context;)Z

    :goto_2
    invoke-virtual {v1, v7}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    monitor-exit v6

    :goto_3
    add-int/lit8 v5, v5, 0x1

    goto :goto_1

    :catchall_1
    move-exception p1

    monitor-exit v6
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_1

    goto :goto_5

    :goto_4
    throw p1

    :goto_5
    goto :goto_4
.end method

.method public declared-synchronized i(I[Lb/a/a/f;)I
    .locals 2

    monitor-enter p0

    const/4 v0, 0x0

    :goto_0
    if-lt v0, p1, :cond_0

    :try_start_0
    iget-object p1, p0, Lb/a/a/g;->a:Ljava/util/ArrayList;

    invoke-virtual {p1}, Ljava/util/ArrayList;->size()I

    move-result p1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return p1

    :cond_0
    :try_start_1
    iget-object v1, p0, Lb/a/a/g;->a:Ljava/util/ArrayList;

    invoke-virtual {v1, v0}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lb/a/a/i;

    iget-object v1, v1, Lb/a/a/i;->l:Lb/a/a/f;

    aput-object v1, p2, v0
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :catchall_0
    move-exception p1

    monitor-exit p0

    goto :goto_2

    :goto_1
    throw p1

    :goto_2
    goto :goto_1
.end method

.method public k(Landroid/hardware/usb/UsbDevice;)Z
    .locals 2

    sget-object v0, Lb/a/a/g;->e:Landroid/content/Context;

    if-nez v0, :cond_0

    const/4 p1, 0x0

    return p1

    :cond_0
    new-instance v0, Lb/a/a/t;

    invoke-virtual {p1}, Landroid/hardware/usb/UsbDevice;->getVendorId()I

    move-result v1

    invoke-virtual {p1}, Landroid/hardware/usb/UsbDevice;->getProductId()I

    move-result p1

    invoke-direct {v0, v1, p1}, Lb/a/a/t;-><init>(II)V

    sget-object p1, Lb/a/a/g;->h:Ljava/util/List;

    invoke-interface {p1, v0}, Ljava/util/List;->contains(Ljava/lang/Object;)Z

    move-result p1

    invoke-virtual {v0}, Lb/a/a/t;->toString()Ljava/lang/String;

    move-result-object v0

    const-string v1, "D2xx::"

    invoke-static {v1, v0}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    return p1
.end method

.method public declared-synchronized m(Landroid/content/Context;I)Lb/a/a/i;
    .locals 1

    monitor-enter p0

    const/4 v0, 0x0

    :try_start_0
    invoke-virtual {p0, p1, p2, v0}, Lb/a/a/g;->n(Landroid/content/Context;ILb/a/a/e;)Lb/a/a/i;

    move-result-object p1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return-object p1

    :catchall_0
    move-exception p1

    monitor-exit p0

    throw p1
.end method

.method public declared-synchronized n(Landroid/content/Context;ILb/a/a/e;)Lb/a/a/i;
    .locals 2

    monitor-enter p0

    const/4 v0, 0x0

    if-gez p2, :cond_0

    monitor-exit p0

    return-object v0

    :cond_0
    if-nez p1, :cond_1

    monitor-exit p0

    return-object v0

    :cond_1
    :try_start_0
    invoke-static {p1}, Lb/a/a/g;->q(Landroid/content/Context;)Z

    iget-object v1, p0, Lb/a/a/g;->a:Ljava/util/ArrayList;

    invoke-virtual {v1, p2}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object p2

    check-cast p2, Lb/a/a/i;

    invoke-direct {p0, p1, p2, p3}, Lb/a/a/g;->p(Landroid/content/Context;Lb/a/a/i;Lb/a/a/e;)Z

    move-result p1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    if-nez p1, :cond_2

    goto :goto_0

    :cond_2
    move-object v0, p2

    :goto_0
    monitor-exit p0

    return-object v0

    :catchall_0
    move-exception p1

    monitor-exit p0

    throw p1
.end method

.method public o(II)Z
    .locals 4

    const/4 v0, 0x1

    const-string v1, "D2xx::"

    if-eqz p1, :cond_1

    if-eqz p2, :cond_1

    new-instance v2, Lb/a/a/t;

    invoke-direct {v2, p1, p2}, Lb/a/a/t;-><init>(II)V

    sget-object v3, Lb/a/a/g;->h:Ljava/util/List;

    invoke-interface {v3, v2}, Ljava/util/List;->contains(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_0

    new-instance v2, Ljava/lang/StringBuilder;

    const-string v3, "Existing vid:"

    invoke-direct {v2, v3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v2, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string p1, "  pid:"

    invoke-virtual {v2, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, p2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-static {v1, p1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    return v0

    :cond_0
    sget-object p1, Lb/a/a/g;->h:Ljava/util/List;

    invoke-interface {p1, v2}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    move-result p1

    if-nez p1, :cond_2

    const-string p1, "Failed to add VID/PID combination to list."

    goto :goto_0

    :cond_1
    const-string p1, "Invalid parameter to setVIDPID"

    :goto_0
    invoke-static {v1, p1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    const/4 v0, 0x0

    :cond_2
    return v0
.end method
