.class Lcom/tuneecu/rc;
.super Landroid/os/Handler;
.source ""


# instance fields
.field final synthetic a:Lcom/tuneecu/vc;


# direct methods
.method constructor <init>(Lcom/tuneecu/vc;)V
    .locals 0

    iput-object p1, p0, Lcom/tuneecu/rc;->a:Lcom/tuneecu/vc;

    invoke-direct {p0}, Landroid/os/Handler;-><init>()V

    return-void
.end method


# virtual methods
.method public handleMessage(Landroid/os/Message;)V
    .locals 7

    iget p1, p1, Landroid/os/Message;->what:I

    if-nez p1, :cond_0

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v0

    invoke-static {v0, v1}, Lcom/tuneecu/vc;->Db(J)J

    iget-object p1, p0, Lcom/tuneecu/rc;->a:Lcom/tuneecu/vc;

    invoke-static {p1}, Lcom/tuneecu/vc;->Eb(Lcom/tuneecu/vc;)V

    goto :goto_0

    :cond_0
    const/4 v0, 0x1

    if-ne p1, v0, :cond_2

    sget-object v1, Lcom/tuneecu/MainActivity;->nd:Ljava/io/OutputStreamWriter;

    invoke-static {}, Lcom/tuneecu/vc;->Fb()[B

    move-result-object v3

    sget v4, Lcom/tuneecu/vc;->Gd:I

    sget v5, Lcom/tuneecu/vc;->Ed:I

    const/4 v6, 0x1

    const-string v2, ": "

    invoke-static/range {v1 .. v6}, Lcom/tuneecu/MainActivity;->Bb(Ljava/io/OutputStreamWriter;Ljava/lang/String;[BIIZ)V

    sget-boolean p1, Lcom/tuneecu/z;->gf:Z

    const/4 v0, 0x0

    if-eqz p1, :cond_1

    invoke-static {}, Lcom/tuneecu/vc;->Fb()[B

    move-result-object p1

    sget v1, Lcom/tuneecu/vc;->Gd:I

    sget v2, Lcom/tuneecu/vc;->Ed:I

    invoke-static {p1, v1, v2}, Lcom/tuneecu/z;->Pc([BII)Z

    move-result p1

    if-eqz p1, :cond_3

    sput v0, Lcom/tuneecu/vc;->Cd:I

    sput v0, Lcom/tuneecu/vc;->Ad:I

    sget-boolean p1, Lcom/tuneecu/vc;->Wd:Z

    if-eqz p1, :cond_3

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v0

    invoke-static {v0, v1}, Lcom/tuneecu/vc;->Db(J)J

    goto :goto_0

    :cond_1
    invoke-static {}, Lcom/tuneecu/vc;->Fb()[B

    move-result-object p1

    sget v1, Lcom/tuneecu/vc;->Gd:I

    sget v2, Lcom/tuneecu/vc;->Ed:I

    invoke-static {}, Lcom/tuneecu/vc;->Gb()Z

    move-result v3

    invoke-static {p1, v1, v2, v3}, Lcom/tuneecu/z;->Nc([BIIZ)V

    sput v0, Lcom/tuneecu/vc;->Ad:I

    goto :goto_0

    :cond_2
    const/4 v0, 0x2

    if-ne p1, v0, :cond_3

    sget-object p1, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    invoke-static {}, Lcom/tuneecu/vc;->Fb()[B

    move-result-object v0

    invoke-virtual {p1, v0}, Lcom/tuneecu/MainActivity;->m8([B)V

    :cond_3
    :goto_0
    return-void
.end method
