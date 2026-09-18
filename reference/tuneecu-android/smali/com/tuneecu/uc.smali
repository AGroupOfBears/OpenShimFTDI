.class Lcom/tuneecu/uc;
.super Ljava/lang/Thread;
.source ""


# instance fields
.field final b:Landroid/os/Handler;

.field final c:Ljava/io/OutputStreamWriter;


# direct methods
.method constructor <init>(Lcom/tuneecu/vc;Landroid/os/Handler;Ljava/io/OutputStreamWriter;)V
    .locals 0

    invoke-direct {p0}, Ljava/lang/Thread;-><init>()V

    iput-object p2, p0, Lcom/tuneecu/uc;->b:Landroid/os/Handler;

    iput-object p3, p0, Lcom/tuneecu/uc;->c:Ljava/io/OutputStreamWriter;

    const/4 p1, 0x5

    invoke-virtual {p0, p1}, Ljava/lang/Thread;->setPriority(I)V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 13

    sget-object v0, Lcom/tuneecu/vc;->ud:Lb/a/a/i;

    const/16 v1, 0x10

    invoke-virtual {v0, v1}, Lb/a/a/i;->L(B)Z

    sget-object v0, Lcom/tuneecu/vc;->ud:Lb/a/a/i;

    const/4 v1, 0x3

    invoke-virtual {v0, v1}, Lb/a/a/i;->v(B)Z

    :goto_0
    sget-boolean v0, Lcom/tuneecu/vc;->Xd:Z

    if-eqz v0, :cond_25

    sget v0, Lcom/tuneecu/vc;->Pd:I

    if-lez v0, :cond_0

    invoke-static {v0}, Lcom/tuneecu/vc;->Ib(I)V

    :cond_0
    sget-object v0, Lcom/tuneecu/vc;->ud:Lb/a/a/i;

    monitor-enter v0

    :try_start_0
    sget-object v2, Lcom/tuneecu/vc;->ud:Lb/a/a/i;

    invoke-virtual {v2}, Lb/a/a/i;->h()I

    move-result v2

    const/4 v3, 0x0

    const/4 v4, 0x1

    if-lez v2, :cond_22

    invoke-static {}, Lcom/tuneecu/vc;->Jb()Z

    move-result v5

    if-eqz v5, :cond_22

    const/16 v5, 0x800

    if-le v2, v5, :cond_1

    const/16 v2, 0x800

    :cond_1
    sget-object v5, Lcom/tuneecu/z;->vd:Lcom/tuneecu/y;

    sget-object v6, Lcom/tuneecu/y;->I:Lcom/tuneecu/y;

    if-ne v5, v6, :cond_2

    const/4 v5, 0x1

    goto :goto_1

    :cond_2
    const/4 v5, 0x0

    :goto_1
    sget-boolean v6, Lcom/tuneecu/z;->gf:Z

    sget v7, Lcom/tuneecu/vc;->Ed:I

    if-lez v7, :cond_3

    xor-int/lit8 v8, v5, 0x1

    xor-int/lit8 v9, v6, 0x1

    and-int/2addr v8, v9

    if-eqz v8, :cond_3

    invoke-static {v7, v2}, Ljava/lang/Math;->min(II)I

    move-result v2

    :cond_3
    sget-object v7, Lcom/tuneecu/vc;->ud:Lb/a/a/i;

    invoke-static {}, Lcom/tuneecu/vc;->Kb()[B

    move-result-object v8

    invoke-virtual {v7, v8, v2}, Lb/a/a/i;->x([BI)I

    iget-object v7, p0, Lcom/tuneecu/uc;->c:Ljava/io/OutputStreamWriter;

    const-string v8, "< "

    invoke-static {}, Lcom/tuneecu/vc;->Kb()[B

    move-result-object v9

    const/4 v10, 0x0

    const/4 v12, 0x1

    move v11, v2

    invoke-static/range {v7 .. v12}, Lcom/tuneecu/MainActivity;->Bb(Ljava/io/OutputStreamWriter;Ljava/lang/String;[BIIZ)V

    sget v7, Lcom/tuneecu/vc;->Dd:I

    const/16 v8, 0x600

    if-le v7, v8, :cond_4

    sget v8, Lcom/tuneecu/vc;->Gd:I

    sub-int/2addr v7, v8

    invoke-static {}, Lcom/tuneecu/vc;->Fb()[B

    move-result-object v8

    sget v9, Lcom/tuneecu/vc;->Gd:I

    invoke-static {}, Lcom/tuneecu/vc;->Fb()[B

    move-result-object v10

    invoke-static {v8, v9, v10, v3, v7}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    sput v3, Lcom/tuneecu/vc;->Gd:I

    sput v7, Lcom/tuneecu/vc;->Dd:I

    :cond_4
    invoke-static {}, Lcom/tuneecu/vc;->Kb()[B

    move-result-object v7

    invoke-static {}, Lcom/tuneecu/vc;->Fb()[B

    move-result-object v8

    sget v9, Lcom/tuneecu/vc;->Dd:I

    invoke-static {v7, v3, v8, v9, v2}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    sget v7, Lcom/tuneecu/vc;->Dd:I

    add-int v8, v7, v2

    sput v8, Lcom/tuneecu/vc;->Dd:I

    sget-boolean v8, Lcom/tuneecu/MainActivity;->C5:Z

    const/4 v9, 0x2

    if-eqz v8, :cond_6

    sget v5, Lcom/tuneecu/vc;->Dd:I

    sget v6, Lcom/tuneecu/vc;->Gd:I

    add-int/2addr v6, v2

    if-lt v5, v6, :cond_22

    sget v5, Lcom/tuneecu/vc;->Dd:I

    sub-int/2addr v5, v4

    invoke-static {}, Lcom/tuneecu/vc;->Fb()[B

    move-result-object v4

    aget-byte v4, v4, v5

    const/16 v6, 0x3e

    if-ne v4, v6, :cond_5

    invoke-static {}, Lcom/tuneecu/vc;->Fb()[B

    move-result-object v2

    aput-byte v3, v2, v5

    sget v2, Lcom/tuneecu/vc;->Dd:I

    sget v4, Lcom/tuneecu/vc;->Gd:I

    sub-int/2addr v2, v4

    sput v2, Lcom/tuneecu/vc;->Ed:I

    iget-object v2, p0, Lcom/tuneecu/uc;->b:Landroid/os/Handler;

    invoke-virtual {v2, v9}, Landroid/os/Handler;->obtainMessage(I)Landroid/os/Message;

    move-result-object v2

    iget-object v4, p0, Lcom/tuneecu/uc;->b:Landroid/os/Handler;

    invoke-virtual {v4, v2}, Landroid/os/Handler;->sendMessage(Landroid/os/Message;)Z

    goto/16 :goto_13

    :cond_5
    invoke-static {}, Lcom/tuneecu/vc;->Fb()[B

    move-result-object v4

    aget-byte v4, v4, v5

    const/16 v5, 0xd

    if-ne v4, v5, :cond_22

    sget v4, Lcom/tuneecu/vc;->Gd:I

    add-int/2addr v4, v2

    sput v4, Lcom/tuneecu/vc;->Gd:I

    goto/16 :goto_13

    :cond_6
    const/4 v8, 0x4

    if-eqz v6, :cond_19

    sget-object v5, Lcom/tuneecu/z;->vd:Lcom/tuneecu/y;

    sget-object v6, Lcom/tuneecu/y;->l0:Lcom/tuneecu/y;

    if-ne v5, v6, :cond_7

    const/4 v5, 0x1

    goto :goto_2

    :cond_7
    const/4 v5, 0x0

    :goto_2
    sget-boolean v6, Lcom/tuneecu/vc;->Wd:Z

    and-int/2addr v5, v6

    if-eqz v5, :cond_c

    if-nez v7, :cond_8

    sput v3, Lcom/tuneecu/vc;->Gd:I

    :cond_8
    sget v5, Lcom/tuneecu/vc;->Gd:I

    :goto_3
    const/16 v6, 0x3a

    if-ge v5, v2, :cond_a

    invoke-static {}, Lcom/tuneecu/vc;->Fb()[B

    move-result-object v8

    add-int v9, v7, v5

    aget-byte v8, v8, v9

    if-ne v8, v6, :cond_9

    sput v9, Lcom/tuneecu/vc;->Gd:I

    goto :goto_4

    :cond_9
    add-int/lit8 v5, v5, 0x1

    goto :goto_3

    :cond_a
    :goto_4
    invoke-static {}, Lcom/tuneecu/vc;->Fb()[B

    move-result-object v2

    sget v5, Lcom/tuneecu/vc;->Gd:I

    aget-byte v2, v2, v5

    if-ne v2, v6, :cond_17

    goto :goto_6

    :goto_5
    sget v2, Lcom/tuneecu/vc;->Dd:I

    if-ge v5, v2, :cond_17

    invoke-static {}, Lcom/tuneecu/vc;->Fb()[B

    move-result-object v2

    aget-byte v2, v2, v5

    if-ne v2, v6, :cond_b

    sget v2, Lcom/tuneecu/vc;->Gd:I

    sub-int/2addr v5, v2

    sput v5, Lcom/tuneecu/vc;->Ed:I

    sput v3, Lcom/tuneecu/vc;->Dd:I

    goto :goto_7

    :cond_b
    :goto_6
    add-int/lit8 v5, v5, 0x1

    goto :goto_5

    :cond_c
    sget-object v2, Lcom/tuneecu/z;->vd:Lcom/tuneecu/y;

    sget-object v5, Lcom/tuneecu/y;->r0:Lcom/tuneecu/y;

    if-ne v2, v5, :cond_f

    sget v2, Lcom/tuneecu/vc;->Dd:I

    sget v5, Lcom/tuneecu/vc;->Gd:I

    sget v6, Lcom/tuneecu/vc;->Ed:I

    add-int/2addr v5, v6

    if-lt v2, v5, :cond_d

    if-ne v6, v8, :cond_d

    :goto_7
    const/4 v2, 0x1

    goto/16 :goto_c

    :cond_d
    if-nez v7, :cond_e

    invoke-static {}, Lcom/tuneecu/vc;->Fb()[B

    move-result-object v2

    aget-byte v2, v2, v3

    if-eq v2, v8, :cond_e

    sget v2, Lcom/tuneecu/vc;->Gd:I

    add-int/2addr v2, v4

    sput v2, Lcom/tuneecu/vc;->Gd:I

    :cond_e
    sget v2, Lcom/tuneecu/vc;->Dd:I

    sget v5, Lcom/tuneecu/vc;->Gd:I

    sget v6, Lcom/tuneecu/vc;->Ed:I

    add-int/2addr v5, v6

    if-lt v2, v5, :cond_17

    invoke-static {}, Lcom/tuneecu/vc;->Fb()[B

    move-result-object v2

    sget v5, Lcom/tuneecu/vc;->Gd:I

    aget-byte v2, v2, v5

    if-ne v2, v8, :cond_17

    goto :goto_7

    :cond_f
    sget-object v2, Lcom/tuneecu/z;->vd:Lcom/tuneecu/y;

    sget-object v5, Lcom/tuneecu/y;->s0:Lcom/tuneecu/y;

    if-ne v2, v5, :cond_10

    sget v2, Lcom/tuneecu/vc;->Dd:I

    sget v5, Lcom/tuneecu/vc;->Gd:I

    sget v6, Lcom/tuneecu/vc;->Ed:I

    add-int/2addr v5, v6

    if-lt v2, v5, :cond_17

    invoke-static {}, Lcom/tuneecu/vc;->Fb()[B

    move-result-object v2

    sget v5, Lcom/tuneecu/vc;->Gd:I

    aget-byte v2, v2, v5

    if-ne v2, v8, :cond_17

    goto :goto_7

    :cond_10
    sget-object v2, Lcom/tuneecu/z;->vd:Lcom/tuneecu/y;

    sget-object v5, Lcom/tuneecu/y;->t0:Lcom/tuneecu/y;

    if-ne v2, v5, :cond_16

    sget v2, Lcom/tuneecu/vc;->Ed:I

    if-le v2, v9, :cond_15

    sget v2, Lcom/tuneecu/vc;->Gd:I

    :goto_8
    sget v5, Lcom/tuneecu/vc;->Dd:I

    if-ge v2, v5, :cond_12

    invoke-static {}, Lcom/tuneecu/vc;->Fb()[B

    move-result-object v5

    aget-byte v5, v5, v2

    const/16 v6, -0x10

    if-ne v5, v6, :cond_11

    goto :goto_9

    :cond_11
    add-int/lit8 v2, v2, 0x1

    goto :goto_8

    :cond_12
    :goto_9
    sget v5, Lcom/tuneecu/vc;->Gd:I

    sub-int v5, v2, v5

    if-le v5, v9, :cond_13

    const/4 v5, 0x1

    goto :goto_a

    :cond_13
    const/4 v5, 0x0

    :goto_a
    sget v6, Lcom/tuneecu/vc;->Dd:I

    if-ge v2, v6, :cond_14

    const/4 v6, 0x1

    goto :goto_b

    :cond_14
    const/4 v6, 0x0

    :goto_b
    and-int/2addr v5, v6

    if-eqz v5, :cond_17

    add-int/lit8 v2, v2, -0x3

    sput v2, Lcom/tuneecu/vc;->Gd:I

    goto :goto_7

    :cond_15
    sget v2, Lcom/tuneecu/vc;->Dd:I

    sget v5, Lcom/tuneecu/vc;->Gd:I

    add-int/2addr v5, v4

    if-lt v2, v5, :cond_17

    sget v2, Lcom/tuneecu/vc;->Dd:I

    sub-int/2addr v2, v4

    sput v2, Lcom/tuneecu/vc;->Gd:I

    goto/16 :goto_7

    :cond_16
    sget v2, Lcom/tuneecu/vc;->Dd:I

    sget v5, Lcom/tuneecu/vc;->Gd:I

    sget v6, Lcom/tuneecu/vc;->Ed:I

    add-int/2addr v5, v6

    if-lt v2, v5, :cond_17

    if-lez v6, :cond_17

    goto/16 :goto_7

    :cond_17
    const/4 v2, 0x0

    :goto_c
    if-eqz v2, :cond_18

    iget-object v5, p0, Lcom/tuneecu/uc;->b:Landroid/os/Handler;

    invoke-virtual {v5, v4}, Landroid/os/Handler;->obtainMessage(I)Landroid/os/Message;

    move-result-object v4

    iget-object v5, p0, Lcom/tuneecu/uc;->b:Landroid/os/Handler;

    invoke-virtual {v5, v4}, Landroid/os/Handler;->sendMessage(Landroid/os/Message;)Z

    :cond_18
    move v4, v2

    goto/16 :goto_14

    :cond_19
    sget-boolean v2, Lcom/tuneecu/z;->Lf:Z

    or-int/2addr v2, v5

    if-eqz v2, :cond_1c

    sget v2, Lcom/tuneecu/vc;->Gd:I

    sget v5, Lcom/tuneecu/vc;->Ed:I

    add-int/2addr v2, v5

    sget v5, Lcom/tuneecu/vc;->Dd:I

    add-int/lit8 v6, v2, 0x4

    if-lt v5, v6, :cond_23

    sget-object v5, Lcom/tuneecu/z;->vd:Lcom/tuneecu/y;

    sget-object v6, Lcom/tuneecu/y;->c:Lcom/tuneecu/y;

    if-ne v5, v6, :cond_1a

    :goto_d
    invoke-static {}, Lcom/tuneecu/vc;->Fb()[B

    move-result-object v5

    aget-byte v5, v5, v2

    and-int/lit16 v5, v5, 0x80

    if-nez v5, :cond_1a

    sget v5, Lcom/tuneecu/vc;->Dd:I

    if-le v5, v2, :cond_1a

    add-int/lit8 v2, v2, 0x1

    goto :goto_d

    :cond_1a
    invoke-static {}, Lcom/tuneecu/vc;->Fb()[B

    move-result-object v5

    aget-byte v5, v5, v2

    and-int/lit8 v5, v5, 0x7f

    if-nez v5, :cond_1b

    invoke-static {}, Lcom/tuneecu/vc;->Fb()[B

    move-result-object v5

    add-int/lit8 v6, v2, 0x3

    aget-byte v5, v5, v6

    and-int/lit16 v5, v5, 0xff

    add-int/lit8 v5, v5, 0x5

    goto :goto_e

    :cond_1b
    invoke-static {}, Lcom/tuneecu/vc;->Fb()[B

    move-result-object v5

    aget-byte v5, v5, v2

    and-int/lit8 v5, v5, 0x7f

    add-int/2addr v5, v8

    :goto_e
    sget v6, Lcom/tuneecu/vc;->Dd:I

    add-int v7, v2, v5

    if-lt v6, v7, :cond_23

    invoke-static {v3}, Lcom/tuneecu/vc;->g3(Z)Z

    sput v2, Lcom/tuneecu/vc;->Gd:I

    sput v5, Lcom/tuneecu/vc;->Ed:I

    iget-object v2, p0, Lcom/tuneecu/uc;->b:Landroid/os/Handler;

    invoke-virtual {v2, v4}, Landroid/os/Handler;->obtainMessage(I)Landroid/os/Message;

    move-result-object v2

    iget-object v5, p0, Lcom/tuneecu/uc;->b:Landroid/os/Handler;

    :goto_f
    invoke-virtual {v5, v2}, Landroid/os/Handler;->sendMessage(Landroid/os/Message;)Z

    goto/16 :goto_14

    :cond_1c
    sget v2, Lcom/tuneecu/vc;->Ed:I

    if-gez v2, :cond_1d

    const/4 v2, 0x1

    goto :goto_10

    :cond_1d
    const/4 v2, 0x0

    :goto_10
    sget v5, Lcom/tuneecu/vc;->Dd:I

    sget v6, Lcom/tuneecu/vc;->Gd:I

    if-le v5, v6, :cond_1e

    const/4 v5, 0x1

    goto :goto_11

    :cond_1e
    const/4 v5, 0x0

    :goto_11
    and-int/2addr v2, v5

    if-eqz v2, :cond_20

    invoke-static {}, Lcom/tuneecu/vc;->Fb()[B

    move-result-object v2

    sget v5, Lcom/tuneecu/vc;->Gd:I

    aget-byte v2, v2, v5

    and-int/lit8 v2, v2, 0x7f

    if-nez v2, :cond_1f

    sget v2, Lcom/tuneecu/vc;->Dd:I

    sget v5, Lcom/tuneecu/vc;->Gd:I

    add-int/2addr v5, v1

    if-le v2, v5, :cond_20

    invoke-static {}, Lcom/tuneecu/vc;->Fb()[B

    move-result-object v2

    sget v5, Lcom/tuneecu/vc;->Gd:I

    add-int/2addr v5, v1

    aget-byte v2, v2, v5

    and-int/lit16 v2, v2, 0xff

    add-int/lit8 v2, v2, 0x5

    sput v2, Lcom/tuneecu/vc;->Ed:I

    goto :goto_12

    :cond_1f
    invoke-static {}, Lcom/tuneecu/vc;->Fb()[B

    move-result-object v2

    sget v5, Lcom/tuneecu/vc;->Gd:I

    aget-byte v2, v2, v5

    and-int/lit8 v2, v2, 0x7f

    add-int/2addr v2, v8

    sput v2, Lcom/tuneecu/vc;->Ed:I

    :cond_20
    :goto_12
    sget v2, Lcom/tuneecu/vc;->Dd:I

    sget v5, Lcom/tuneecu/vc;->Gd:I

    sget v6, Lcom/tuneecu/vc;->Ed:I

    add-int/2addr v5, v6

    if-lt v2, v5, :cond_23

    if-lez v6, :cond_23

    invoke-static {}, Lcom/tuneecu/vc;->Gb()Z

    move-result v2

    if-eqz v2, :cond_21

    sget v2, Lcom/tuneecu/vc;->Gd:I

    sget v5, Lcom/tuneecu/vc;->Ed:I

    add-int/2addr v2, v5

    sput v2, Lcom/tuneecu/vc;->Gd:I

    invoke-static {v3}, Lcom/tuneecu/vc;->g3(Z)Z

    invoke-static {}, Lcom/tuneecu/vc;->A4()I

    move-result v2

    sput v2, Lcom/tuneecu/vc;->Ed:I

    goto :goto_14

    :cond_21
    iget-object v2, p0, Lcom/tuneecu/uc;->b:Landroid/os/Handler;

    invoke-virtual {v2, v4}, Landroid/os/Handler;->obtainMessage(I)Landroid/os/Message;

    move-result-object v2

    iget-object v5, p0, Lcom/tuneecu/uc;->b:Landroid/os/Handler;

    goto :goto_f

    :cond_22
    :goto_13
    const/4 v4, 0x0

    :cond_23
    :goto_14
    if-nez v4, :cond_24

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v4

    invoke-static {}, Lcom/tuneecu/vc;->Cb()J

    move-result-wide v6

    const-wide/16 v8, 0xa0

    add-long/2addr v6, v8

    cmp-long v2, v4, v6

    if-lez v2, :cond_24

    iget-object v2, p0, Lcom/tuneecu/uc;->b:Landroid/os/Handler;

    invoke-virtual {v2, v3}, Landroid/os/Handler;->obtainMessage(I)Landroid/os/Message;

    move-result-object v2

    iget-object v3, p0, Lcom/tuneecu/uc;->b:Landroid/os/Handler;

    invoke-virtual {v3, v2}, Landroid/os/Handler;->sendMessage(Landroid/os/Message;)Z

    :cond_24
    monitor-exit v0

    goto/16 :goto_0

    :catchall_0
    move-exception v1

    monitor-exit v0
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v1

    :cond_25
    return-void
.end method
