.class public Lcom/tuneecu/vc;
.super Lcom/tuneecu/MainActivity;
.source ""


# static fields
.field public static Ad:I = 0x0

.field public static Bd:I = 0x0

.field public static Cd:I = 0x0

.field public static Dd:I = 0x0

.field public static Ed:I = 0x0

.field public static Fd:I = 0x0

.field public static Gd:I = 0x0

.field public static Hd:I = 0x0

.field public static Id:I = 0x0

.field public static Jd:I = 0x0

.field public static Kd:I = 0x0

.field public static Ld:I = 0x0

.field public static Md:I = 0x0

.field public static Nd:I = 0x0

.field public static Od:I = 0x0

.field public static Pd:I = 0x0

.field public static Qd:I = 0x1

.field private static Rd:Z = false

.field private static Sd:Z = false

.field private static Td:Z = false

.field private static Ud:Z = false

.field public static Vd:Z = false

.field public static Wd:Z = false

.field public static Xd:Z = false

.field public static Yd:Z = false

.field public static Zd:Z = false

.field private static ae:J = 0x0L

.field private static be:[B = null

.field private static ce:[B = null

.field private static de:[B = null

.field private static final ee:[B

.field static fe:Lcom/tuneecu/MainActivity; = null
    .annotation build Landroid/annotation/SuppressLint;
        value = {
            "StaticFieldLeak"
        }
    .end annotation
.end field

.field public static ud:Lb/a/a/i; = null

.field public static vd:I = -0x1

.field private static wd:Z

.field private static xd:I

.field private static yd:I

.field private static zd:I


# instance fields
.field private sd:Lcom/tuneecu/uc;

.field final td:Landroid/os/Handler;
    .annotation build Landroid/annotation/SuppressLint;
        value = {
            "HandlerLeak"
        }
    .end annotation
.end field


# direct methods
.method static constructor <clinit>()V
    .locals 2

    const/4 v0, 0x1

    new-array v0, v0, [B

    const/4 v1, 0x0

    aput-byte v1, v0, v1

    sput-object v0, Lcom/tuneecu/vc;->ee:[B

    return-void
.end method

.method public constructor <init>(Landroid/content/Context;)V
    .locals 1

    invoke-direct {p0}, Lcom/tuneecu/MainActivity;-><init>()V

    new-instance v0, Lcom/tuneecu/rc;

    invoke-direct {v0, p0}, Lcom/tuneecu/rc;-><init>(Lcom/tuneecu/vc;)V

    iput-object v0, p0, Lcom/tuneecu/vc;->td:Landroid/os/Handler;

    sget-boolean v0, Lcom/tuneecu/MainActivity;->P5:Z

    sput-boolean v0, Lcom/tuneecu/vc;->wd:Z

    check-cast p1, Lcom/tuneecu/MainActivity;

    sput-object p1, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    return-void
.end method

.method static synthetic A4()I
    .locals 1

    sget v0, Lcom/tuneecu/vc;->zd:I

    return v0
.end method

.method static synthetic Cb()J
    .locals 2

    sget-wide v0, Lcom/tuneecu/vc;->ae:J

    return-wide v0
.end method

.method static synthetic Db(J)J
    .locals 0

    sput-wide p0, Lcom/tuneecu/vc;->ae:J

    return-wide p0
.end method

.method static synthetic Eb(Lcom/tuneecu/vc;)V
    .locals 0

    invoke-direct {p0}, Lcom/tuneecu/vc;->Lb()V

    return-void
.end method

.method static synthetic Fb()[B
    .locals 1

    sget-object v0, Lcom/tuneecu/vc;->de:[B

    return-object v0
.end method

.method static synthetic Gb()Z
    .locals 1

    sget-boolean v0, Lcom/tuneecu/vc;->Sd:Z

    return v0
.end method

.method static synthetic Hb()Z
    .locals 1

    sget-boolean v0, Lcom/tuneecu/vc;->Rd:Z

    return v0
.end method

.method static synthetic Ib(I)V
    .locals 0

    invoke-static {p0}, Lcom/tuneecu/vc;->Pb(I)V

    return-void
.end method

.method static synthetic Jb()Z
    .locals 1

    sget-boolean v0, Lcom/tuneecu/vc;->Ud:Z

    return v0
.end method

.method static synthetic Kb()[B
    .locals 1

    sget-object v0, Lcom/tuneecu/vc;->ce:[B

    return-object v0
.end method

.method private Lb()V
    .locals 22

    move-object/from16 v0, p0

    sget-boolean v1, Lcom/tuneecu/MainActivity;->B5:Z

    const/16 v3, 0xa

    const/4 v4, 0x3

    const/4 v5, 0x1

    if-eqz v1, :cond_0

    const/16 v1, 0xa

    goto :goto_0

    :cond_0
    sget-boolean v1, Lcom/tuneecu/MainActivity;->C5:Z

    if-eqz v1, :cond_1

    const/4 v1, 0x3

    goto :goto_0

    :cond_1
    sget v1, Lcom/tuneecu/vc;->Hd:I

    if-ne v1, v4, :cond_2

    const/4 v1, 0x5

    goto :goto_0

    :cond_2
    const/4 v1, 0x1

    :goto_0
    sget-object v6, Lcom/tuneecu/z;->vd:Lcom/tuneecu/y;

    invoke-virtual {v6}, Ljava/lang/Enum;->ordinal()I

    move-result v6

    sget-object v7, Lcom/tuneecu/sc;->a:[I

    sget-object v8, Lcom/tuneecu/z;->vd:Lcom/tuneecu/y;

    invoke-virtual {v8}, Ljava/lang/Enum;->ordinal()I

    move-result v8

    aget v7, v7, v8

    const/16 v8, 0x9

    const/16 v10, 0x3c

    const/16 v14, 0x14

    const/16 v15, 0x8

    const/4 v2, -0x1

    const/4 v12, 0x4

    const/16 v11, 0x1a

    const/4 v9, 0x2

    const/4 v13, 0x0

    packed-switch v7, :pswitch_data_0

    invoke-static {v6}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v1

    invoke-static {v11, v1}, Lcom/tuneecu/MainActivity;->Ab(ILjava/lang/String;)V

    sget v1, Lcom/tuneecu/vc;->Ad:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Ad:I

    sget v2, Lcom/tuneecu/vc;->Qd:I

    mul-int/lit8 v2, v2, 0x2

    if-le v1, v2, :cond_4a

    invoke-static {v13}, Lcom/tuneecu/LedBar;->n(Z)V

    sget-object v1, Lcom/tuneecu/y;->b:Lcom/tuneecu/y;

    goto/16 :goto_10

    :pswitch_0
    sget v1, Lcom/tuneecu/vc;->Ad:I

    add-int/lit8 v3, v1, 0x1

    sput v3, Lcom/tuneecu/vc;->Ad:I

    sget v3, Lcom/tuneecu/vc;->Qd:I

    mul-int/lit8 v3, v3, 0x2

    if-le v1, v3, :cond_4a

    const/4 v1, 0x0

    invoke-static {v1, v2, v13, v13}, Lcom/tuneecu/vc;->Xb([BIZZ)V

    invoke-direct/range {p0 .. p0}, Lcom/tuneecu/vc;->Qb()V

    goto/16 :goto_1a

    :pswitch_1
    sget v1, Lcom/tuneecu/vc;->Ad:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Ad:I

    sget v2, Lcom/tuneecu/vc;->Qd:I

    mul-int/lit8 v2, v2, 0x2

    if-le v1, v2, :cond_4a

    invoke-static {v6}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v1

    invoke-static {v11, v1}, Lcom/tuneecu/MainActivity;->Ab(ILjava/lang/String;)V

    sget v1, Lcom/tuneecu/vc;->Cd:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Cd:I

    if-le v1, v4, :cond_19

    sput v13, Lcom/tuneecu/vc;->Cd:I

    sget-object v1, Lcom/tuneecu/y;->m0:Lcom/tuneecu/y;

    goto/16 :goto_10

    :pswitch_2
    sget v1, Lcom/tuneecu/vc;->Ad:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Ad:I

    sget v2, Lcom/tuneecu/vc;->Qd:I

    mul-int/lit8 v2, v2, 0x2

    if-le v1, v2, :cond_4a

    sget v1, Lcom/tuneecu/vc;->Cd:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Cd:I

    if-le v1, v4, :cond_3

    invoke-static {v6}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v1

    invoke-static {v11, v1}, Lcom/tuneecu/MainActivity;->Ab(ILjava/lang/String;)V

    sput v13, Lcom/tuneecu/vc;->Cd:I

    :goto_1
    sget-object v1, Lcom/tuneecu/y;->b:Lcom/tuneecu/y;

    invoke-static {v1}, Lcom/tuneecu/z;->Ne(Lcom/tuneecu/y;)V

    :goto_2
    sget-object v1, Lcom/tuneecu/x;->n:Lcom/tuneecu/x;

    invoke-virtual {v0, v1}, Lcom/tuneecu/vc;->Tb(Lcom/tuneecu/x;)Ljava/lang/String;

    move-result-object v5

    sput-boolean v13, Lcom/tuneecu/MainActivity;->N4:Z

    sget-object v2, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    const/4 v3, 0x0

    const/4 v4, 0x0

    const/4 v6, 0x0

    const/4 v7, 0x2

    const/4 v8, 0x2

    const/16 v9, 0x13

    :goto_3
    invoke-virtual/range {v2 .. v9}, Lcom/tuneecu/MainActivity;->K9(Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;IIII)V

    goto/16 :goto_12

    :cond_3
    sget-object v1, Lcom/tuneecu/y;->t0:Lcom/tuneecu/y;

    goto/16 :goto_10

    :pswitch_3
    sget v1, Lcom/tuneecu/vc;->Ad:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Ad:I

    if-le v1, v10, :cond_4

    goto :goto_4

    :cond_4
    const/4 v5, 0x0

    :goto_4
    sget-boolean v1, Lcom/tuneecu/vc;->Td:Z

    or-int/2addr v1, v5

    if-eqz v1, :cond_4a

    invoke-static {v6}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v1

    invoke-static {v11, v1}, Lcom/tuneecu/MainActivity;->Ab(ILjava/lang/String;)V

    sput v13, Lcom/tuneecu/vc;->Cd:I

    sget-object v1, Lcom/tuneecu/y;->b:Lcom/tuneecu/y;

    invoke-static {v1}, Lcom/tuneecu/z;->Ne(Lcom/tuneecu/y;)V

    sget-object v1, Lcom/tuneecu/x;->n:Lcom/tuneecu/x;

    invoke-virtual {v0, v1}, Lcom/tuneecu/vc;->Tb(Lcom/tuneecu/x;)Ljava/lang/String;

    move-result-object v5

    sput-boolean v13, Lcom/tuneecu/MainActivity;->N4:Z

    sget-object v2, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    const/4 v3, 0x0

    const/4 v4, 0x0

    const/4 v6, 0x0

    const/4 v7, 0x2

    const/4 v8, 0x2

    const/16 v9, 0x13

    invoke-virtual/range {v2 .. v9}, Lcom/tuneecu/MainActivity;->K9(Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;IIII)V

    goto/16 :goto_28

    :pswitch_4
    sget v1, Lcom/tuneecu/vc;->Ad:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Ad:I

    sget v2, Lcom/tuneecu/vc;->Qd:I

    mul-int/lit8 v2, v2, 0x2

    if-le v1, v2, :cond_4a

    invoke-static {v6}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v1

    invoke-static {v11, v1}, Lcom/tuneecu/MainActivity;->Ab(ILjava/lang/String;)V

    sget v1, Lcom/tuneecu/vc;->Cd:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Cd:I

    if-le v1, v4, :cond_5

    sput v13, Lcom/tuneecu/vc;->Cd:I

    sget-object v1, Lcom/tuneecu/y;->b:Lcom/tuneecu/y;

    invoke-static {v1}, Lcom/tuneecu/z;->Ne(Lcom/tuneecu/y;)V

    sget-boolean v1, Lcom/tuneecu/z;->Tf:Z

    if-eqz v1, :cond_19

    goto :goto_2

    :cond_5
    sget-object v1, Lcom/tuneecu/z;->vd:Lcom/tuneecu/y;

    sget-object v2, Lcom/tuneecu/y;->i0:Lcom/tuneecu/y;

    if-ne v1, v2, :cond_6

    invoke-static {}, Lcom/tuneecu/z;->Ue()V

    :cond_6
    sget-object v1, Lcom/tuneecu/z;->vd:Lcom/tuneecu/y;

    goto/16 :goto_10

    :pswitch_5
    sget v1, Lcom/tuneecu/vc;->Ad:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Ad:I

    sget v2, Lcom/tuneecu/vc;->Qd:I

    mul-int/lit8 v2, v2, 0x2

    if-le v1, v2, :cond_4a

    invoke-static {v6}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v1

    invoke-static {v11, v1}, Lcom/tuneecu/MainActivity;->Ab(ILjava/lang/String;)V

    invoke-static {v13}, Lcom/tuneecu/LedBar;->n(Z)V

    sget v1, Lcom/tuneecu/vc;->Cd:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Cd:I

    if-le v1, v14, :cond_7

    goto/16 :goto_1

    :cond_7
    sget-boolean v1, Lcom/tuneecu/MainActivity;->B5:Z

    sget-boolean v2, Lcom/tuneecu/MainActivity;->C5:Z

    or-int/2addr v1, v2

    xor-int/2addr v1, v5

    sget v2, Lcom/tuneecu/vc;->Hd:I

    if-nez v2, :cond_8

    const/4 v2, 0x1

    goto :goto_5

    :cond_8
    const/4 v2, 0x0

    :goto_5
    and-int/2addr v1, v2

    sget v2, Lcom/tuneecu/z;->Ne:I

    if-ge v2, v3, :cond_9

    const/4 v2, 0x1

    goto :goto_6

    :cond_9
    const/4 v2, 0x0

    :goto_6
    and-int/2addr v1, v2

    sget v2, Lcom/tuneecu/vc;->Fd:I

    add-int/lit8 v4, v2, 0x1

    sput v4, Lcom/tuneecu/vc;->Fd:I

    if-le v2, v15, :cond_a

    const/4 v2, 0x1

    goto :goto_7

    :cond_a
    const/4 v2, 0x0

    :goto_7
    and-int/2addr v1, v2

    const/4 v2, -0x6

    if-eqz v1, :cond_b

    sput-boolean v5, Lcom/tuneecu/z;->Wf:Z

    sget v1, Lcom/tuneecu/z;->Ne:I

    add-int/2addr v1, v5

    sput v1, Lcom/tuneecu/z;->Ne:I

    sput-boolean v13, Lcom/tuneecu/z;->Ve:Z

    sget v1, Lcom/tuneecu/z;->Je:I

    sput v1, Lcom/tuneecu/MainActivity;->J7:I

    sget v1, Lcom/tuneecu/z;->Le:I

    sput v1, Lcom/tuneecu/MainActivity;->K7:I

    sget-object v1, Lcom/tuneecu/y;->b:Lcom/tuneecu/y;

    sput-object v1, Lcom/tuneecu/z;->vd:Lcom/tuneecu/y;

    const/16 v1, 0x55

    invoke-static {v1}, Lcom/tuneecu/z;->yc(I)V

    :goto_8
    sput v2, Lcom/tuneecu/vc;->Cd:I

    sput v13, Lcom/tuneecu/vc;->Ad:I

    sput v13, Lcom/tuneecu/vc;->Fd:I

    goto/16 :goto_12

    :cond_b
    sget-boolean v1, Lcom/tuneecu/MainActivity;->B5:Z

    sget-boolean v4, Lcom/tuneecu/MainActivity;->C5:Z

    or-int/2addr v1, v4

    xor-int/2addr v1, v5

    sget-boolean v4, Lcom/tuneecu/z;->Hf:Z

    and-int/2addr v1, v4

    sget v4, Lcom/tuneecu/z;->Ne:I

    if-ge v4, v3, :cond_c

    const/4 v3, 0x1

    goto :goto_9

    :cond_c
    const/4 v3, 0x0

    :goto_9
    and-int/2addr v1, v3

    sget v3, Lcom/tuneecu/vc;->Fd:I

    add-int/lit8 v4, v3, 0x1

    sput v4, Lcom/tuneecu/vc;->Fd:I

    if-le v3, v15, :cond_d

    const/4 v3, 0x1

    goto :goto_a

    :cond_d
    const/4 v3, 0x0

    :goto_a
    and-int/2addr v1, v3

    if-eqz v1, :cond_6

    sput-boolean v5, Lcom/tuneecu/z;->Wf:Z

    sget v1, Lcom/tuneecu/z;->Ne:I

    add-int/2addr v1, v5

    sput v1, Lcom/tuneecu/z;->Ne:I

    sput-boolean v13, Lcom/tuneecu/z;->Ve:Z

    sget-object v1, Lcom/tuneecu/y;->b:Lcom/tuneecu/y;

    sput-object v1, Lcom/tuneecu/z;->vd:Lcom/tuneecu/y;

    invoke-static {}, Lcom/tuneecu/z;->Ec()V

    goto :goto_8

    :pswitch_6
    sget-boolean v1, Lcom/tuneecu/MainActivity;->ua:Z

    if-nez v1, :cond_4a

    sget v1, Lcom/tuneecu/vc;->Ad:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Ad:I

    sget v2, Lcom/tuneecu/vc;->Qd:I

    mul-int/lit8 v2, v2, 0x2

    if-le v1, v2, :cond_4a

    sget-byte v1, Lcom/tuneecu/z;->Rd:B

    if-nez v1, :cond_e

    sget v2, Lcom/tuneecu/vc;->Bd:I

    add-int/lit8 v4, v2, 0x1

    sput v4, Lcom/tuneecu/vc;->Bd:I

    if-le v2, v8, :cond_e

    sput-byte v9, Lcom/tuneecu/z;->Rd:B

    invoke-static {v9}, Lcom/tuneecu/z;->xe(I)V

    goto/16 :goto_f

    :cond_e
    if-ne v1, v9, :cond_f

    sget v1, Lcom/tuneecu/vc;->Bd:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Bd:I

    if-le v1, v5, :cond_f

    sput v13, Lcom/tuneecu/vc;->Bd:I

    sget-boolean v1, Lcom/tuneecu/MainActivity;->sa:Z

    sput-boolean v1, Lcom/tuneecu/MainActivity;->ua:Z

    sget-object v1, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    invoke-virtual {v1, v5}, Lcom/tuneecu/MainActivity;->y8(Z)V

    goto/16 :goto_f

    :cond_f
    sget-boolean v1, Lcom/tuneecu/MainActivity;->sa:Z

    if-eqz v1, :cond_18

    sget-object v1, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    sget v2, Lcom/tuneecu/vc;->Bd:I

    sget-byte v4, Lcom/tuneecu/z;->Rd:B

    if-ne v4, v9, :cond_10

    goto :goto_b

    :cond_10
    const/4 v3, 0x0

    :goto_b
    add-int/2addr v2, v3

    const/16 v3, 0xb

    const-wide/16 v4, 0x0

    invoke-virtual {v1, v2, v3, v4, v5}, Lcom/tuneecu/MainActivity;->r9(IIJ)V

    goto/16 :goto_f

    :pswitch_7
    sget v1, Lcom/tuneecu/vc;->Ad:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Ad:I

    sget v2, Lcom/tuneecu/vc;->Qd:I

    mul-int/lit8 v2, v2, 0x2

    if-le v1, v2, :cond_4a

    invoke-static {v6}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v1

    invoke-static {v11, v1}, Lcom/tuneecu/MainActivity;->Ab(ILjava/lang/String;)V

    invoke-static {v13}, Lcom/tuneecu/LedBar;->n(Z)V

    sget v1, Lcom/tuneecu/vc;->Cd:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Cd:I

    if-le v1, v4, :cond_19

    sput v13, Lcom/tuneecu/vc;->Cd:I

    sget-object v1, Lcom/tuneecu/x;->n:Lcom/tuneecu/x;

    invoke-virtual {v0, v1}, Lcom/tuneecu/vc;->Tb(Lcom/tuneecu/x;)Ljava/lang/String;

    move-result-object v5

    sput-boolean v13, Lcom/tuneecu/MainActivity;->N4:Z

    sget-object v2, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    const/4 v3, 0x0

    const/4 v4, 0x0

    const/4 v6, 0x0

    const/4 v7, 0x2

    const/4 v8, 0x2

    const/16 v9, 0x13

    invoke-virtual/range {v2 .. v9}, Lcom/tuneecu/MainActivity;->K9(Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;IIII)V

    :cond_11
    :goto_c
    sget-object v1, Lcom/tuneecu/y;->b:Lcom/tuneecu/y;

    goto/16 :goto_10

    :pswitch_8
    sget v1, Lcom/tuneecu/vc;->Ad:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Ad:I

    sget v2, Lcom/tuneecu/vc;->Qd:I

    mul-int/lit8 v2, v2, 0x2

    if-le v1, v2, :cond_4a

    invoke-static {v6}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v1

    invoke-static {v11, v1}, Lcom/tuneecu/MainActivity;->Ab(ILjava/lang/String;)V

    invoke-static {v13}, Lcom/tuneecu/LedBar;->n(Z)V

    sget v1, Lcom/tuneecu/vc;->Cd:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Cd:I

    if-le v1, v4, :cond_13

    sput v13, Lcom/tuneecu/vc;->Cd:I

    sget-boolean v1, Lcom/tuneecu/z;->Tf:Z

    sget-boolean v2, Lcom/tuneecu/z;->Rf:Z

    or-int/2addr v1, v2

    if-eqz v1, :cond_12

    sget-object v1, Lcom/tuneecu/x;->n:Lcom/tuneecu/x;

    invoke-virtual {v0, v1}, Lcom/tuneecu/vc;->Tb(Lcom/tuneecu/x;)Ljava/lang/String;

    move-result-object v5

    sput-boolean v13, Lcom/tuneecu/MainActivity;->N4:Z

    sget-object v2, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    const/4 v3, 0x0

    const/4 v4, 0x0

    const/4 v6, 0x0

    const/4 v7, 0x2

    const/4 v8, 0x2

    const/16 v9, 0x13

    invoke-virtual/range {v2 .. v9}, Lcom/tuneecu/MainActivity;->K9(Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;IIII)V

    :cond_12
    sget-object v1, Lcom/tuneecu/y;->b:Lcom/tuneecu/y;

    goto/16 :goto_10

    :cond_13
    sget-object v1, Lcom/tuneecu/z;->vd:Lcom/tuneecu/y;

    goto/16 :goto_10

    :pswitch_9
    sget v1, Lcom/tuneecu/vc;->Ad:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Ad:I

    sget v2, Lcom/tuneecu/vc;->Qd:I

    mul-int/lit8 v2, v2, 0x2

    if-le v1, v2, :cond_4a

    sget v1, Lcom/tuneecu/vc;->Cd:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Cd:I

    if-le v1, v4, :cond_19

    sget v1, Lcom/tuneecu/MainActivity;->Ia:I

    sput v1, Lcom/tuneecu/MainActivity;->Ja:I

    goto :goto_c

    :pswitch_a
    sget v1, Lcom/tuneecu/vc;->Ad:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Ad:I

    sget v2, Lcom/tuneecu/vc;->Qd:I

    mul-int/lit8 v2, v2, 0x2

    if-le v1, v2, :cond_4a

    sget v1, Lcom/tuneecu/vc;->Cd:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Cd:I

    if-le v1, v4, :cond_6

    sput v13, Lcom/tuneecu/vc;->Cd:I

    sget-object v1, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    invoke-virtual {v1}, Lcom/tuneecu/MainActivity;->wb()V

    goto/16 :goto_12

    :pswitch_b
    sget v1, Lcom/tuneecu/vc;->Ad:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Ad:I

    sget v2, Lcom/tuneecu/vc;->Qd:I

    mul-int/lit8 v2, v2, 0x2

    if-le v1, v2, :cond_4a

    sget-object v1, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    invoke-virtual {v1, v13, v13}, Lcom/tuneecu/MainActivity;->b5(II)V

    sget-object v1, Lcom/tuneecu/y;->b0:Lcom/tuneecu/y;

    goto/16 :goto_10

    :pswitch_c
    sget v1, Lcom/tuneecu/vc;->Ad:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Ad:I

    sget v2, Lcom/tuneecu/vc;->Qd:I

    mul-int/lit8 v2, v2, 0x2

    if-le v1, v2, :cond_4a

    sget v1, Lcom/tuneecu/vc;->Cd:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Cd:I

    if-le v1, v4, :cond_14

    sput v13, Lcom/tuneecu/vc;->Cd:I

    sget-object v1, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    invoke-virtual {v1, v13, v13}, Lcom/tuneecu/MainActivity;->b5(II)V

    sget v1, Lcom/tuneecu/MainActivity;->Ia:I

    sput v1, Lcom/tuneecu/MainActivity;->Ja:I

    sget-object v1, Lcom/tuneecu/y;->b:Lcom/tuneecu/y;

    goto/16 :goto_10

    :cond_14
    sget-object v1, Lcom/tuneecu/z;->vd:Lcom/tuneecu/y;

    goto/16 :goto_10

    :pswitch_d
    sget v1, Lcom/tuneecu/vc;->Ad:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Ad:I

    sget v2, Lcom/tuneecu/vc;->Qd:I

    mul-int/lit8 v2, v2, 0x2

    if-le v1, v2, :cond_4a

    sget-boolean v1, Lcom/tuneecu/MainActivity;->r9:Z

    if-eqz v1, :cond_15

    goto/16 :goto_f

    :cond_15
    sget v1, Lcom/tuneecu/vc;->Cd:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Cd:I

    if-le v1, v4, :cond_19

    sput v13, Lcom/tuneecu/vc;->Cd:I

    :goto_d
    sget-object v1, Lcom/tuneecu/y;->b:Lcom/tuneecu/y;

    invoke-static {v1}, Lcom/tuneecu/z;->Ne(Lcom/tuneecu/y;)V

    sget-object v1, Lcom/tuneecu/x;->B:Lcom/tuneecu/x;

    invoke-virtual {v0, v1}, Lcom/tuneecu/vc;->Tb(Lcom/tuneecu/x;)Ljava/lang/String;

    move-result-object v5

    sget-object v2, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    const/4 v3, 0x0

    const/4 v4, 0x0

    const/4 v6, 0x0

    const/4 v7, 0x2

    const/4 v8, 0x2

    const/16 v9, 0x46

    goto/16 :goto_3

    :pswitch_e
    sget v1, Lcom/tuneecu/vc;->Ad:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Ad:I

    sget v2, Lcom/tuneecu/vc;->Qd:I

    mul-int/lit8 v2, v2, 0x2

    if-le v1, v2, :cond_4a

    sget v1, Lcom/tuneecu/z;->ke:I

    if-ne v1, v12, :cond_16

    goto/16 :goto_f

    :cond_16
    sget v1, Lcom/tuneecu/vc;->Cd:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Cd:I

    if-le v1, v4, :cond_6

    sput v13, Lcom/tuneecu/vc;->Cd:I

    sput-boolean v5, Lcom/tuneecu/vc;->Yd:Z

    goto :goto_d

    :pswitch_f
    sget v1, Lcom/tuneecu/vc;->Ad:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Ad:I

    sget v2, Lcom/tuneecu/vc;->Qd:I

    mul-int/lit8 v2, v2, 0x2

    if-le v1, v2, :cond_4a

    sget-boolean v1, Lcom/tuneecu/vc;->Zd:Z

    if-eqz v1, :cond_17

    :goto_e
    invoke-static {}, Lcom/tuneecu/z;->ad()V

    goto/16 :goto_28

    :cond_17
    sput v13, Lcom/tuneecu/MainActivity;->La:I

    sput v13, Lcom/tuneecu/vc;->Ad:I

    sget v1, Lcom/tuneecu/MainActivity;->Ia:I

    sput v1, Lcom/tuneecu/MainActivity;->Ja:I

    sget-object v1, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    invoke-virtual {v1, v13}, Lcom/tuneecu/MainActivity;->y8(Z)V

    goto/16 :goto_28

    :pswitch_10
    sget v1, Lcom/tuneecu/vc;->Ad:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Ad:I

    sget v2, Lcom/tuneecu/vc;->Qd:I

    mul-int/lit8 v2, v2, 0x2

    if-le v1, v2, :cond_4a

    invoke-static {}, Lcom/tuneecu/z;->ad()V

    sget-boolean v1, Lcom/tuneecu/vc;->Zd:Z

    if-eqz v1, :cond_19

    sget-object v1, Lcom/tuneecu/y;->W:Lcom/tuneecu/y;

    goto :goto_10

    :pswitch_11
    sget v1, Lcom/tuneecu/vc;->Ad:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Ad:I

    sget v2, Lcom/tuneecu/vc;->Qd:I

    mul-int/lit8 v2, v2, 0x2

    if-le v1, v2, :cond_4a

    sget v1, Lcom/tuneecu/vc;->Cd:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Cd:I

    if-le v1, v5, :cond_6

    sput v13, Lcom/tuneecu/vc;->Cd:I

    sget-object v1, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    invoke-virtual {v1, v5}, Lcom/tuneecu/MainActivity;->B6(Z)V

    goto :goto_12

    :pswitch_12
    sget v1, Lcom/tuneecu/vc;->Ad:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Ad:I

    sget v2, Lcom/tuneecu/vc;->Qd:I

    mul-int/lit8 v2, v2, 0x2

    if-le v1, v2, :cond_4a

    :cond_18
    :goto_f
    invoke-static {}, Lcom/tuneecu/z;->ad()V

    goto :goto_12

    :pswitch_13
    sget v1, Lcom/tuneecu/vc;->Ad:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Ad:I

    sget v2, Lcom/tuneecu/vc;->Qd:I

    mul-int/lit8 v2, v2, 0x2

    if-le v1, v2, :cond_4a

    sput v13, Lcom/tuneecu/z;->le:I

    sput-boolean v5, Lcom/tuneecu/z;->ng:Z

    sget-object v1, Lcom/tuneecu/y;->h:Lcom/tuneecu/y;

    :goto_10
    invoke-static {v1}, Lcom/tuneecu/z;->Ne(Lcom/tuneecu/y;)V

    goto :goto_12

    :pswitch_14
    sget v1, Lcom/tuneecu/vc;->Ad:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Ad:I

    sget v2, Lcom/tuneecu/vc;->Qd:I

    mul-int/lit8 v2, v2, 0x2

    if-le v1, v2, :cond_4a

    sget v1, Lcom/tuneecu/vc;->Cd:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Cd:I

    if-le v1, v5, :cond_6

    sput v13, Lcom/tuneecu/vc;->Cd:I

    :goto_11
    sget-object v1, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    invoke-virtual {v1, v5, v13}, Lcom/tuneecu/MainActivity;->z6(ZZ)V

    goto :goto_12

    :pswitch_15
    sget v1, Lcom/tuneecu/vc;->Ad:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Ad:I

    sget v2, Lcom/tuneecu/vc;->Qd:I

    mul-int/lit8 v2, v2, 0x2

    if-le v1, v2, :cond_4a

    invoke-static {v6}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v1

    invoke-static {v11, v1}, Lcom/tuneecu/MainActivity;->Ab(ILjava/lang/String;)V

    sget-object v1, Lcom/tuneecu/y;->h:Lcom/tuneecu/y;

    sput-object v1, Lcom/tuneecu/z;->vd:Lcom/tuneecu/y;

    invoke-static {v5, v13}, Lcom/tuneecu/z;->Hb(ZI)V

    :cond_19
    :goto_12
    sput v13, Lcom/tuneecu/vc;->Ad:I

    goto/16 :goto_28

    :pswitch_16
    sget v1, Lcom/tuneecu/vc;->Ad:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Ad:I

    sget v2, Lcom/tuneecu/vc;->Qd:I

    mul-int/lit8 v2, v2, 0x2

    if-le v1, v2, :cond_4a

    invoke-static {v6}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v1

    invoke-static {v11, v1}, Lcom/tuneecu/MainActivity;->Ab(ILjava/lang/String;)V

    invoke-static {v13}, Lcom/tuneecu/LedBar;->n(Z)V

    sget v1, Lcom/tuneecu/vc;->Cd:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Cd:I

    if-le v1, v4, :cond_1a

    sput v13, Lcom/tuneecu/vc;->Cd:I

    sget-boolean v1, Lcom/tuneecu/z;->dg:Z

    if-eqz v1, :cond_11

    goto :goto_11

    :cond_1a
    if-ne v6, v12, :cond_18

    invoke-static {v5}, Lcom/tuneecu/LedBar;->j(I)V

    goto :goto_f

    :pswitch_17
    sget-boolean v1, Lcom/tuneecu/MainActivity;->B5:Z

    if-eqz v1, :cond_1c

    sget-boolean v1, Lcom/tuneecu/MainActivity;->A5:Z

    if-eqz v1, :cond_1c

    sget v1, Lcom/tuneecu/vc;->Ad:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Ad:I

    const/16 v2, 0x19

    if-le v1, v2, :cond_1b

    invoke-static {v6}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v1

    invoke-static {v11, v1}, Lcom/tuneecu/MainActivity;->Ab(ILjava/lang/String;)V

    sput v13, Lcom/tuneecu/vc;->Cd:I

    sget-object v1, Lcom/tuneecu/x;->x:Lcom/tuneecu/x;

    invoke-virtual {v0, v1}, Lcom/tuneecu/vc;->Tb(Lcom/tuneecu/x;)Ljava/lang/String;

    move-result-object v5

    sget-object v2, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    const/4 v3, 0x0

    const/4 v4, 0x0

    const/4 v6, 0x0

    const/16 v7, 0x14

    const/4 v8, 0x2

    const/16 v9, 0xe

    invoke-virtual/range {v2 .. v9}, Lcom/tuneecu/MainActivity;->K9(Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;IIII)V

    sget-object v1, Lcom/tuneecu/z;->vd:Lcom/tuneecu/y;

    invoke-static {v1}, Lcom/tuneecu/z;->Ne(Lcom/tuneecu/y;)V

    sput v13, Lcom/tuneecu/vc;->Ad:I

    :cond_1b
    return-void

    :cond_1c
    sget v1, Lcom/tuneecu/vc;->Ad:I

    add-int/lit8 v7, v1, 0x1

    sput v7, Lcom/tuneecu/vc;->Ad:I

    sget v7, Lcom/tuneecu/vc;->Qd:I

    mul-int/lit8 v7, v7, 0x2

    if-le v1, v7, :cond_4a

    invoke-static {v6}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v1

    invoke-static {v11, v1}, Lcom/tuneecu/MainActivity;->Ab(ILjava/lang/String;)V

    sget-boolean v1, Lcom/tuneecu/z;->Nf:Z

    if-eqz v1, :cond_1d

    sget v1, Lcom/tuneecu/z;->oe:I

    if-lez v1, :cond_1d

    goto/16 :goto_e

    :cond_1d
    sget-boolean v1, Lcom/tuneecu/z;->eg:Z

    if-eqz v1, :cond_1f

    sget v1, Lcom/tuneecu/vc;->Cd:I

    add-int/lit8 v4, v1, 0x1

    sput v4, Lcom/tuneecu/vc;->Cd:I

    if-le v1, v3, :cond_1e

    sput v13, Lcom/tuneecu/vc;->Cd:I

    sput-boolean v13, Lcom/tuneecu/z;->ag:Z

    sput v2, Lcom/tuneecu/vc;->Hd:I

    sget-object v1, Lcom/tuneecu/y;->b:Lcom/tuneecu/y;

    goto/16 :goto_10

    :cond_1e
    sget-boolean v1, Lcom/tuneecu/vc;->Vd:Z

    sget-boolean v2, Lcom/tuneecu/z;->cg:Z

    xor-int/2addr v2, v5

    and-int/2addr v1, v2

    if-eqz v1, :cond_19

    sget-object v1, Lcom/tuneecu/y;->e:Lcom/tuneecu/y;

    goto/16 :goto_10

    :cond_1f
    invoke-static {v13}, Lcom/tuneecu/LedBar;->n(Z)V

    sget v1, Lcom/tuneecu/vc;->Cd:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Cd:I

    if-le v1, v4, :cond_21

    sput v13, Lcom/tuneecu/vc;->Cd:I

    sget v1, Lcom/tuneecu/MainActivity;->f7:I

    const/16 v2, 0x10

    if-ge v1, v2, :cond_20

    goto :goto_13

    :cond_20
    const/4 v5, 0x0

    :goto_13
    sput-boolean v5, Lcom/tuneecu/z;->ff:Z

    sget v1, Lcom/tuneecu/vc;->Md:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Md:I

    if-ne v1, v4, :cond_11

    sget-object v1, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    invoke-virtual {v1}, Lcom/tuneecu/MainActivity;->o8()V

    goto/16 :goto_12

    :cond_21
    sput-boolean v13, Lcom/tuneecu/z;->Pf:Z

    goto/16 :goto_f

    :pswitch_18
    sget v1, Lcom/tuneecu/vc;->Ad:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Ad:I

    sget v2, Lcom/tuneecu/vc;->Qd:I

    mul-int/lit8 v2, v2, 0x2

    if-le v1, v2, :cond_4a

    invoke-static {v6}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v1

    invoke-static {v11, v1}, Lcom/tuneecu/MainActivity;->Ab(ILjava/lang/String;)V

    invoke-static {v13}, Lcom/tuneecu/LedBar;->n(Z)V

    const/16 v1, 0x12c

    invoke-static {v1}, Lcom/tuneecu/vc;->Pb(I)V

    sget-boolean v1, Lcom/tuneecu/MainActivity;->B5:Z

    sget-boolean v2, Lcom/tuneecu/MainActivity;->C5:Z

    or-int/2addr v1, v2

    if-eqz v1, :cond_22

    sget-object v1, Lcom/tuneecu/y;->b:Lcom/tuneecu/y;

    sput-object v1, Lcom/tuneecu/z;->vd:Lcom/tuneecu/y;

    return-void

    :cond_22
    sget-boolean v1, Lcom/tuneecu/z;->Qf:Z

    sget v2, Lcom/tuneecu/z;->ue:I

    if-ne v2, v5, :cond_23

    const/4 v2, 0x1

    goto :goto_14

    :cond_23
    const/4 v2, 0x0

    :goto_14
    and-int/2addr v1, v2

    sget-boolean v2, Lcom/tuneecu/z;->Kf:Z

    and-int/2addr v1, v2

    if-eqz v1, :cond_28

    sget-boolean v1, Lcom/tuneecu/z;->Tf:Z

    if-eqz v1, :cond_26

    sget v1, Lcom/tuneecu/vc;->Id:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Id:I

    sget-boolean v2, Lcom/tuneecu/z;->Wf:Z

    if-eqz v2, :cond_24

    const/4 v12, 0x7

    goto :goto_15

    :cond_24
    const/4 v12, 0x2

    :goto_15
    if-le v1, v12, :cond_25

    sget-object v1, Lcom/tuneecu/y;->b:Lcom/tuneecu/y;

    sput-object v1, Lcom/tuneecu/z;->vd:Lcom/tuneecu/y;

    sget-object v1, Lcom/tuneecu/x;->n:Lcom/tuneecu/x;

    invoke-virtual {v0, v1}, Lcom/tuneecu/vc;->Tb(Lcom/tuneecu/x;)Ljava/lang/String;

    move-result-object v8

    sget-object v5, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    const/4 v6, 0x0

    const/4 v7, 0x0

    const/4 v9, 0x0

    const/4 v10, 0x2

    const/4 v11, 0x2

    const/16 v12, 0xa

    invoke-virtual/range {v5 .. v12}, Lcom/tuneecu/MainActivity;->K9(Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;IIII)V

    goto :goto_18

    :cond_25
    :goto_16
    invoke-static {}, Lcom/tuneecu/z;->Ec()V

    goto :goto_18

    :cond_26
    sget-boolean v1, Lcom/tuneecu/z;->Wf:Z

    if-nez v1, :cond_28

    sget v1, Lcom/tuneecu/vc;->Id:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Id:I

    if-ge v1, v9, :cond_27

    goto :goto_17

    :cond_27
    const/4 v5, 0x0

    :goto_17
    sput-boolean v5, Lcom/tuneecu/z;->if:Z

    sput v5, Lcom/tuneecu/z;->ue:I

    goto :goto_16

    :cond_28
    :goto_18
    sget-boolean v1, Lcom/tuneecu/z;->ag:Z

    if-eqz v1, :cond_2a

    sget v1, Lcom/tuneecu/vc;->Cd:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Cd:I

    if-ge v1, v4, :cond_29

    sput v13, Lcom/tuneecu/vc;->Ad:I

    invoke-static {}, Lcom/tuneecu/z;->Jc()V

    return-void

    :cond_29
    sput v13, Lcom/tuneecu/vc;->Cd:I

    goto :goto_19

    :cond_2a
    sget v1, Lcom/tuneecu/MainActivity;->J8:I

    if-gez v1, :cond_2b

    sget v1, Lcom/tuneecu/vc;->Hd:I

    if-nez v1, :cond_2b

    const/16 v1, 0x1f4

    invoke-static {v1}, Lcom/tuneecu/vc;->Pb(I)V

    const/16 v1, 0x33

    invoke-static {v1}, Lcom/tuneecu/z;->yc(I)V

    :cond_2b
    :goto_19
    sget-object v1, Lcom/tuneecu/y;->b:Lcom/tuneecu/y;

    sput-object v1, Lcom/tuneecu/z;->vd:Lcom/tuneecu/y;

    goto :goto_1a

    :pswitch_19
    sget v1, Lcom/tuneecu/vc;->Ad:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Ad:I

    sget v2, Lcom/tuneecu/vc;->Qd:I

    mul-int/lit8 v2, v2, 0x2

    if-le v1, v2, :cond_4a

    invoke-static {v6}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v1

    invoke-static {v11, v1}, Lcom/tuneecu/MainActivity;->Ab(ILjava/lang/String;)V

    invoke-static {v13}, Lcom/tuneecu/LedBar;->n(Z)V

    sget-object v1, Lcom/tuneecu/y;->b:Lcom/tuneecu/y;

    sput-object v1, Lcom/tuneecu/z;->vd:Lcom/tuneecu/y;

    const/16 v1, 0x12c

    invoke-static {v1}, Lcom/tuneecu/vc;->Pb(I)V

    :goto_1a
    sput v13, Lcom/tuneecu/vc;->Ad:I

    :goto_1b
    sput v13, Lcom/tuneecu/vc;->Cd:I

    goto/16 :goto_28

    :pswitch_1a
    sget-boolean v3, Lcom/tuneecu/vc;->Yd:Z

    if-eqz v3, :cond_2c

    sput v13, Lcom/tuneecu/vc;->Ad:I

    :cond_2c
    sput-boolean v13, Lcom/tuneecu/z;->gf:Z

    sget v3, Lcom/tuneecu/vc;->Ad:I

    add-int/lit8 v6, v3, 0x1

    sput v6, Lcom/tuneecu/vc;->Ad:I

    div-int/2addr v10, v1

    if-gt v3, v10, :cond_2d

    sget-boolean v1, Lcom/tuneecu/vc;->Td:Z

    if-eqz v1, :cond_4a

    :cond_2d
    invoke-static {v13}, Lcom/tuneecu/LedBar;->n(Z)V

    sput v13, Lcom/tuneecu/vc;->Ad:I

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "P="

    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    sget v3, Lcom/tuneecu/MainActivity;->Ja:I

    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v3, ":"

    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    sget-boolean v3, Lcom/tuneecu/MainActivity;->C5:Z

    if-eqz v3, :cond_2e

    const-string v3, "1"

    goto :goto_1c

    :cond_2e
    const-string v3, "0"

    :goto_1c
    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v13, v1}, Lcom/tuneecu/MainActivity;->Ab(ILjava/lang/String;)V

    sget-boolean v1, Lcom/tuneecu/MainActivity;->B5:Z

    sget-boolean v3, Lcom/tuneecu/MainActivity;->C5:Z

    or-int/2addr v1, v3

    if-eqz v1, :cond_38

    sget v1, Lcom/tuneecu/vc;->Jd:I

    const/4 v2, 0x7

    if-le v1, v2, :cond_30

    sget v1, Lcom/tuneecu/MainActivity;->Ja:I

    if-nez v1, :cond_30

    sput-boolean v5, Lcom/tuneecu/z;->ig:Z

    sput v14, Lcom/tuneecu/MainActivity;->Ja:I

    :cond_2f
    :goto_1d
    sget-object v1, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    invoke-virtual {v1, v13}, Lcom/tuneecu/MainActivity;->y8(Z)V

    goto/16 :goto_27

    :cond_30
    sget v1, Lcom/tuneecu/vc;->Jd:I

    if-le v1, v2, :cond_31

    sget v1, Lcom/tuneecu/MainActivity;->Ja:I

    if-ne v1, v14, :cond_31

    sput-boolean v13, Lcom/tuneecu/z;->ig:Z

    sput-boolean v13, Lcom/tuneecu/MainActivity;->Q9:Z

    sput v5, Lcom/tuneecu/MainActivity;->Ja:I

    goto :goto_1d

    :cond_31
    sget v1, Lcom/tuneecu/vc;->Jd:I

    if-le v1, v15, :cond_33

    sput v13, Lcom/tuneecu/vc;->Jd:I

    sget-boolean v1, Lcom/tuneecu/MainActivity;->B5:Z

    if-eqz v1, :cond_32

    sget-boolean v1, Lcom/tuneecu/MainActivity;->D5:Z

    if-eqz v1, :cond_32

    sput-boolean v13, Lcom/tuneecu/MainActivity;->B5:Z

    sget-object v1, Lcom/tuneecu/x;->h:Lcom/tuneecu/x;

    invoke-virtual {v0, v1}, Lcom/tuneecu/vc;->Tb(Lcom/tuneecu/x;)Ljava/lang/String;

    move-result-object v5

    sget-object v2, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    const/4 v3, 0x0

    const/4 v4, 0x0

    const/4 v6, 0x0

    const/16 v7, 0x14

    const/4 v8, 0x2

    const/4 v9, 0x0

    invoke-virtual/range {v2 .. v9}, Lcom/tuneecu/MainActivity;->K9(Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;IIII)V

    sget-object v1, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    invoke-virtual {v1, v13}, Lcom/tuneecu/MainActivity;->N5(Z)V

    goto/16 :goto_27

    :cond_32
    sget-boolean v1, Lcom/tuneecu/MainActivity;->I9:Z

    if-nez v1, :cond_49

    sput-boolean v13, Lcom/tuneecu/MainActivity;->Q9:Z

    sget-object v1, Lcom/tuneecu/x;->d:Lcom/tuneecu/x;

    invoke-virtual {v0, v1}, Lcom/tuneecu/vc;->Tb(Lcom/tuneecu/x;)Ljava/lang/String;

    move-result-object v5

    sget-object v2, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    const/4 v3, 0x0

    const/4 v4, 0x0

    const/4 v6, 0x0

    const/4 v7, 0x3

    const/4 v8, 0x3

    const/16 v9, 0xa

    invoke-virtual/range {v2 .. v9}, Lcom/tuneecu/MainActivity;->K9(Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;IIII)V

    goto/16 :goto_27

    :cond_33
    add-int/2addr v1, v5

    sput v1, Lcom/tuneecu/vc;->Jd:I

    sget-boolean v1, Lcom/tuneecu/MainActivity;->E5:Z

    if-nez v1, :cond_2f

    sget v1, Lcom/tuneecu/vc;->Jd:I

    if-le v1, v5, :cond_2f

    sget v1, Lcom/tuneecu/MainActivity;->Ia:I

    if-ne v1, v12, :cond_34

    sget v2, Lcom/tuneecu/vc;->Jd:I

    if-ne v2, v9, :cond_34

    sput v13, Lcom/tuneecu/MainActivity;->Ja:I

    goto :goto_1d

    :cond_34
    const/4 v2, 0x6

    if-ne v1, v2, :cond_35

    sget v1, Lcom/tuneecu/vc;->Jd:I

    if-ne v1, v4, :cond_35

    sput v12, Lcom/tuneecu/MainActivity;->Ja:I

    goto :goto_1d

    :cond_35
    sget-boolean v1, Lcom/tuneecu/z;->ig:Z

    xor-int/2addr v1, v5

    sget v2, Lcom/tuneecu/MainActivity;->Ia:I

    if-nez v2, :cond_36

    const/4 v2, 0x1

    goto :goto_1e

    :cond_36
    const/4 v2, 0x0

    :goto_1e
    and-int/2addr v1, v2

    if-eqz v1, :cond_37

    sget v1, Lcom/tuneecu/vc;->Jd:I

    if-le v1, v4, :cond_37

    sget v1, Lcom/tuneecu/MainActivity;->Ja:I

    xor-int/2addr v1, v5

    :goto_1f
    sput v1, Lcom/tuneecu/MainActivity;->Ja:I

    goto/16 :goto_1d

    :cond_37
    sget-boolean v1, Lcom/tuneecu/z;->ig:Z

    xor-int/2addr v1, v5

    sget-boolean v2, Lcom/tuneecu/MainActivity;->Q9:Z

    xor-int/2addr v2, v5

    and-int/2addr v1, v2

    if-eqz v1, :cond_2f

    sget v1, Lcom/tuneecu/MainActivity;->Ja:I

    add-int/2addr v1, v5

    goto :goto_1f

    :cond_38
    sget-boolean v1, Lcom/tuneecu/MainActivity;->R5:Z

    if-eqz v1, :cond_39

    sget-object v1, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "Protocol "

    invoke-virtual {v3, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    sget v6, Lcom/tuneecu/vc;->Hd:I

    invoke-virtual {v3, v6}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    sget-object v6, Ljava/lang/Boolean;->FALSE:Ljava/lang/Boolean;

    invoke-virtual {v1, v3, v13, v6}, Lcom/tuneecu/MainActivity;->r6(Ljava/lang/String;ILjava/lang/Boolean;)V

    :cond_39
    sget v1, Lcom/tuneecu/vc;->Ld:I

    if-le v1, v12, :cond_3a

    const/4 v1, 0x1

    goto :goto_20

    :cond_3a
    const/4 v1, 0x0

    :goto_20
    sget-boolean v3, Lcom/tuneecu/z;->Rf:Z

    sget-boolean v6, Lcom/tuneecu/z;->Tf:Z

    or-int/2addr v3, v6

    sget-boolean v6, Lcom/tuneecu/z;->Sf:Z

    or-int/2addr v3, v6

    xor-int/2addr v3, v5

    and-int/2addr v1, v3

    if-eqz v1, :cond_3c

    sget-boolean v1, Lcom/tuneecu/MainActivity;->Q9:Z

    if-eqz v1, :cond_3b

    sput-boolean v13, Lcom/tuneecu/MainActivity;->Q9:Z

    goto :goto_21

    :cond_3b
    sput v2, Lcom/tuneecu/vc;->Hd:I

    :cond_3c
    :goto_21
    sget v1, Lcom/tuneecu/MainActivity;->J8:I

    if-le v1, v2, :cond_3e

    add-int/lit8 v2, v1, -0x1

    sput v2, Lcom/tuneecu/MainActivity;->J8:I

    if-ge v1, v5, :cond_3d

    sget-object v1, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    invoke-virtual {v1, v5, v13}, Lcom/tuneecu/MainActivity;->z6(ZZ)V

    goto/16 :goto_27

    :cond_3d
    const/16 v1, 0x19

    sput v1, Lcom/tuneecu/vc;->Pd:I

    const/16 v1, 0x43

    :goto_22
    invoke-static {v1}, Lcom/tuneecu/z;->yc(I)V

    goto/16 :goto_27

    :cond_3e
    sget v1, Lcom/tuneecu/vc;->Hd:I

    if-gez v1, :cond_41

    sget v1, Lcom/tuneecu/z;->xd:I

    and-int/2addr v1, v5

    sget v2, Lcom/tuneecu/vc;->Nd:I

    if-ne v1, v2, :cond_3f

    sput v13, Lcom/tuneecu/vc;->Ld:I

    sput v13, Lcom/tuneecu/vc;->Id:I

    sget-boolean v1, Lcom/tuneecu/z;->ag:Z

    xor-int/2addr v1, v5

    sput-boolean v1, Lcom/tuneecu/z;->ag:Z

    if-eqz v1, :cond_46

    goto :goto_26

    :cond_3f
    sget v1, Lcom/tuneecu/vc;->Od:I

    add-int/lit8 v2, v1, 0x1

    sput v2, Lcom/tuneecu/vc;->Od:I

    if-ge v1, v5, :cond_40

    :goto_23
    invoke-static {v5}, Lcom/tuneecu/z;->Cb(Z)V

    goto/16 :goto_27

    :cond_40
    :goto_24
    const/16 v1, 0x33

    goto :goto_22

    :cond_41
    if-ne v1, v15, :cond_44

    sget v1, Lcom/tuneecu/vc;->Kd:I

    add-int/2addr v1, v5

    sput v1, Lcom/tuneecu/vc;->Kd:I

    if-le v1, v4, :cond_42

    sget v1, Lcom/tuneecu/z;->zd:I

    const/16 v2, 0x17

    if-le v1, v2, :cond_42

    sub-int/2addr v1, v5

    sput v1, Lcom/tuneecu/z;->zd:I

    sput v5, Lcom/tuneecu/vc;->Kd:I

    goto :goto_25

    :cond_42
    sget v1, Lcom/tuneecu/vc;->Kd:I

    const/4 v2, 0x5

    if-le v1, v2, :cond_43

    sput v13, Lcom/tuneecu/vc;->Kd:I

    const/16 v1, 0x19

    sput v1, Lcom/tuneecu/z;->zd:I

    sget-object v1, Lcom/tuneecu/x;->d:Lcom/tuneecu/x;

    invoke-virtual {v0, v1}, Lcom/tuneecu/vc;->Tb(Lcom/tuneecu/x;)Ljava/lang/String;

    move-result-object v17

    sget-object v14, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    const/4 v15, 0x0

    const/16 v16, 0x0

    const/16 v18, 0x0

    const/16 v19, 0x3

    const/16 v20, 0x3

    const/16 v21, 0xa

    invoke-virtual/range {v14 .. v21}, Lcom/tuneecu/MainActivity;->K9(Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;IIII)V

    :cond_43
    :goto_25
    sput-boolean v5, Lcom/tuneecu/z;->ag:Z

    goto :goto_26

    :cond_44
    if-ne v1, v8, :cond_45

    sget v1, Lcom/tuneecu/vc;->Ld:I

    add-int/2addr v1, v5

    sput v1, Lcom/tuneecu/vc;->Ld:I

    sput-boolean v5, Lcom/tuneecu/z;->bg:Z

    :goto_26
    invoke-static {}, Lcom/tuneecu/z;->Jc()V

    goto :goto_27

    :cond_45
    and-int/lit8 v2, v1, 0x3

    if-ne v2, v9, :cond_47

    sget v1, Lcom/tuneecu/vc;->Ld:I

    add-int/2addr v1, v5

    sput v1, Lcom/tuneecu/vc;->Ld:I

    sput v13, Lcom/tuneecu/vc;->Id:I

    :cond_46
    invoke-static {}, Lcom/tuneecu/z;->Ec()V

    goto :goto_27

    :cond_47
    if-ne v1, v4, :cond_48

    sget v1, Lcom/tuneecu/vc;->Ld:I

    add-int/2addr v1, v5

    sput v1, Lcom/tuneecu/vc;->Ld:I

    sput v13, Lcom/tuneecu/vc;->Id:I

    goto :goto_23

    :cond_48
    sget v1, Lcom/tuneecu/vc;->Ld:I

    add-int/2addr v1, v5

    sput v1, Lcom/tuneecu/vc;->Ld:I

    goto :goto_24

    :cond_49
    :goto_27
    sput-boolean v13, Lcom/tuneecu/vc;->Td:Z

    goto/16 :goto_1b

    :cond_4a
    :goto_28
    return-void

    nop

    :pswitch_data_0
    .packed-switch 0x1
        :pswitch_1a
        :pswitch_19
        :pswitch_18
        :pswitch_17
        :pswitch_16
        :pswitch_16
        :pswitch_16
        :pswitch_16
        :pswitch_16
        :pswitch_16
        :pswitch_16
        :pswitch_16
        :pswitch_15
        :pswitch_14
        :pswitch_14
        :pswitch_14
        :pswitch_13
        :pswitch_12
        :pswitch_11
        :pswitch_10
        :pswitch_f
        :pswitch_e
        :pswitch_d
        :pswitch_c
        :pswitch_b
        :pswitch_a
        :pswitch_9
        :pswitch_9
        :pswitch_8
        :pswitch_8
        :pswitch_8
        :pswitch_8
        :pswitch_8
        :pswitch_8
        :pswitch_8
        :pswitch_8
        :pswitch_8
        :pswitch_8
        :pswitch_8
        :pswitch_8
        :pswitch_8
        :pswitch_7
        :pswitch_7
        :pswitch_7
        :pswitch_7
        :pswitch_7
        :pswitch_7
        :pswitch_7
        :pswitch_7
        :pswitch_7
        :pswitch_7
        :pswitch_6
        :pswitch_5
        :pswitch_5
        :pswitch_5
        :pswitch_5
        :pswitch_4
        :pswitch_4
        :pswitch_4
        :pswitch_4
        :pswitch_4
        :pswitch_4
        :pswitch_4
        :pswitch_3
        :pswitch_3
        :pswitch_3
        :pswitch_3
        :pswitch_3
        :pswitch_2
        :pswitch_1
        :pswitch_0
    .end packed-switch
.end method

.method public static Nb(Z)V
    .locals 6

    sget-object v0, Ljava/lang/Boolean;->TRUE:Ljava/lang/Boolean;

    const/4 v1, 0x0

    sput v1, Lcom/tuneecu/vc;->vd:I

    sget v2, Lcom/tuneecu/MainActivity;->K8:I

    and-int/lit8 v2, v2, 0x1

    sput v2, Lcom/tuneecu/MainActivity;->K8:I

    sget-object v2, Lcom/tuneecu/MainActivity;->v4:Lb/a/a/g;

    if-eqz v2, :cond_0

    sget-object v3, Lcom/tuneecu/MainActivity;->y4:Landroid/content/Context;

    invoke-virtual {v2, v3}, Lb/a/a/g;->f(Landroid/content/Context;)I

    move-result v2

    sput v2, Lcom/tuneecu/vc;->vd:I

    :cond_0
    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Device number = "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    sget v3, Lcom/tuneecu/vc;->vd:I

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    const-string v3, "FtdiModeControl"

    invoke-static {v3, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    sget v2, Lcom/tuneecu/vc;->vd:I

    if-lez v2, :cond_2

    new-array p0, v2, [Lb/a/a/f;

    sget-object v2, Lcom/tuneecu/MainActivity;->v4:Lb/a/a/g;

    sget v3, Lcom/tuneecu/vc;->vd:I

    invoke-virtual {v2, v3, p0}, Lb/a/a/g;->i(I[Lb/a/a/f;)I

    const/4 v2, 0x3

    sput v2, Lcom/tuneecu/MainActivity;->K8:I

    aget-object v2, p0, v1

    iget-object v2, v2, Lb/a/a/f;->h:Ljava/lang/String;

    if-eqz v2, :cond_1

    aget-object p0, p0, v1

    iget-object p0, p0, Lb/a/a/f;->h:Ljava/lang/String;

    const-string v2, " "

    const-string v3, ""

    invoke-virtual {p0, v2, v3}, Ljava/lang/String;->replaceAll(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    sget-object v4, Lcom/tuneecu/MainActivity;->y4:Landroid/content/Context;

    const v5, 0x7f1106fb

    invoke-virtual {v4, v5}, Landroid/content/Context;->getText(I)Ljava/lang/CharSequence;

    move-result-object v4

    invoke-interface {v4}, Ljava/lang/CharSequence;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v4, " : ("

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v3, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string p0, ")"

    invoke-virtual {v3, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    sget-object v3, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    invoke-virtual {v3, p0, v1, v0}, Lcom/tuneecu/MainActivity;->r6(Ljava/lang/String;ILjava/lang/Boolean;)V

    const-string p0, "OBDLinkSX"

    invoke-virtual {v2, p0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result p0

    sput-boolean p0, Lcom/tuneecu/MainActivity;->C5:Z

    sget p0, Lcom/tuneecu/MainActivity;->Ia:I

    sput p0, Lcom/tuneecu/MainActivity;->Ja:I

    goto :goto_0

    :cond_1
    sput v1, Lcom/tuneecu/vc;->vd:I

    goto :goto_0

    :cond_2
    if-eqz p0, :cond_3

    sput v1, Lcom/tuneecu/MainActivity;->K8:I

    sget-object p0, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    sget-object v2, Lcom/tuneecu/MainActivity;->y4:Landroid/content/Context;

    const v3, 0x7f110424

    invoke-virtual {v2, v3}, Landroid/content/Context;->getText(I)Ljava/lang/CharSequence;

    move-result-object v2

    invoke-interface {v2}, Ljava/lang/CharSequence;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {p0, v2, v1, v0}, Lcom/tuneecu/MainActivity;->r6(Ljava/lang/String;ILjava/lang/Boolean;)V

    :cond_3
    :goto_0
    return-void
.end method

.method private static Pb(I)V
    .locals 2

    int-to-long v0, p0

    :try_start_0
    invoke-static {v0, v1}, Ljava/lang/Thread;->sleep(J)V
    :try_end_0
    .catch Ljava/lang/InterruptedException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    :catch_0
    move-exception p0

    sget-boolean v0, Lcom/tuneecu/vc;->wd:Z

    if-eqz v0, :cond_0

    invoke-static {p0}, Landroid/util/Log;->getStackTraceString(Ljava/lang/Throwable;)Ljava/lang/String;

    move-result-object p0

    const-string v0, "ftdiActivity"

    invoke-static {v0, p0}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    :cond_0
    :goto_0
    return-void
.end method

.method private Qb()V
    .locals 2

    sget-object v0, Lcom/tuneecu/y;->b:Lcom/tuneecu/y;

    sput-object v0, Lcom/tuneecu/z;->vd:Lcom/tuneecu/y;

    const/4 v0, 0x1

    invoke-static {v0}, Lcom/tuneecu/LedBar;->j(I)V

    invoke-virtual {p0}, Lcom/tuneecu/MainActivity;->o9()V

    sget-object v0, Lcom/tuneecu/vc;->ud:Lb/a/a/i;

    if-eqz v0, :cond_0

    invoke-virtual {v0}, Lb/a/a/i;->t()Z

    move-result v0

    if-eqz v0, :cond_0

    sget-object v0, Lcom/tuneecu/vc;->ud:Lb/a/a/i;

    invoke-virtual {v0}, Lb/a/a/i;->a()V

    :cond_0
    const/16 v0, 0x64

    invoke-static {v0}, Lcom/tuneecu/vc;->Pb(I)V

    const/4 v0, 0x0

    sput v0, Lcom/tuneecu/vc;->Od:I

    invoke-virtual {p0}, Lcom/tuneecu/vc;->Ob()Z

    move-result v1

    sput-boolean v1, Lcom/tuneecu/MainActivity;->G5:Z

    sput-boolean v1, Lcom/tuneecu/MainActivity;->F5:Z

    if-eqz v1, :cond_1

    invoke-static {v0}, Lcom/tuneecu/z;->Cb(Z)V

    :cond_1
    return-void
.end method

.method public static Sb(B)V
    .locals 1

    sget-object v0, Lcom/tuneecu/vc;->ud:Lb/a/a/i;

    if-eqz v0, :cond_1

    invoke-virtual {v0}, Lb/a/a/i;->t()Z

    move-result v0

    if-eqz v0, :cond_1

    if-nez p0, :cond_0

    sget-object p0, Lcom/tuneecu/vc;->ud:Lb/a/a/i;

    invoke-virtual {p0}, Lb/a/a/i;->D()Z

    goto :goto_0

    :cond_0
    sget-object p0, Lcom/tuneecu/vc;->ud:Lb/a/a/i;

    invoke-virtual {p0}, Lb/a/a/i;->C()Z

    :goto_0
    const/4 p0, 0x1

    sput p0, Lcom/tuneecu/vc;->Ed:I

    sput-boolean p0, Lcom/tuneecu/vc;->Ud:Z

    :cond_1
    return-void
.end method

.method public static Ub(I)V
    .locals 0

    if-gez p0, :cond_0

    const/4 p0, 0x1

    sput-boolean p0, Lcom/tuneecu/vc;->Td:Z

    goto :goto_0

    :cond_0
    mul-int/lit8 p0, p0, 0x3c

    div-int/lit8 p0, p0, 0xa

    sput p0, Lcom/tuneecu/vc;->Ad:I

    const/4 p0, 0x0

    sput-boolean p0, Lcom/tuneecu/vc;->Yd:Z

    :goto_0
    return-void
.end method

.method private static Wb()V
    .locals 8

    :goto_0
    sget v0, Lcom/tuneecu/vc;->yd:I

    if-lez v0, :cond_0

    sget-object v3, Lcom/tuneecu/vc;->ee:[B

    const/4 v1, 0x0

    sget-object v2, Lcom/tuneecu/vc;->be:[B

    sget v4, Lcom/tuneecu/vc;->xd:I

    sub-int/2addr v4, v0

    aget-byte v0, v2, v4

    aput-byte v0, v3, v1

    sget-object v0, Lcom/tuneecu/vc;->ud:Lb/a/a/i;

    const/4 v7, 0x1

    invoke-virtual {v0, v3, v7, v7}, Lb/a/a/i;->P([BIZ)I

    sget-object v1, Lcom/tuneecu/MainActivity;->nd:Ljava/io/OutputStreamWriter;

    const/4 v4, 0x0

    const/4 v5, 0x1

    const/4 v6, 0x1

    const-string v2, "> "

    invoke-static/range {v1 .. v6}, Lcom/tuneecu/MainActivity;->Bb(Ljava/io/OutputStreamWriter;Ljava/lang/String;[BIIZ)V

    sget v0, Lcom/tuneecu/vc;->yd:I

    sub-int/2addr v0, v7

    sput v0, Lcom/tuneecu/vc;->yd:I

    const/4 v0, 0x3

    invoke-static {v0}, Lcom/tuneecu/vc;->Pb(I)V

    goto :goto_0

    :cond_0
    return-void
.end method

.method public static Xb([BIZZ)V
    .locals 7

    if-eqz p2, :cond_0

    array-length v0, p0

    sput v0, Lcom/tuneecu/vc;->Ed:I

    goto :goto_0

    :cond_0
    sput p1, Lcom/tuneecu/vc;->Ed:I

    :goto_0
    sput-boolean p2, Lcom/tuneecu/vc;->Sd:Z

    sput p1, Lcom/tuneecu/vc;->zd:I

    const/4 p1, 0x0

    sput-boolean p1, Lcom/tuneecu/vc;->Ud:Z

    const/4 p2, 0x1

    if-nez p0, :cond_1

    :try_start_0
    sget-object p0, Lcom/tuneecu/vc;->ud:Lb/a/a/i;

    invoke-virtual {p0, p2}, Lb/a/a/i;->v(B)Z

    goto :goto_1

    :cond_1
    array-length v0, p0

    if-lez v0, :cond_3

    if-eqz p3, :cond_2

    sput p1, Lcom/tuneecu/vc;->yd:I

    sget-object p3, Lcom/tuneecu/vc;->ud:Lb/a/a/i;

    array-length v0, p0

    invoke-virtual {p3, p0, v0, p2}, Lb/a/a/i;->P([BIZ)I

    sget-object v1, Lcom/tuneecu/MainActivity;->nd:Ljava/io/OutputStreamWriter;

    const-string v2, "> "

    const/4 v4, 0x0

    array-length v5, p0

    const/4 v6, 0x1

    move-object v3, p0

    invoke-static/range {v1 .. v6}, Lcom/tuneecu/MainActivity;->Bb(Ljava/io/OutputStreamWriter;Ljava/lang/String;[BIIZ)V

    goto :goto_1

    :cond_2
    sput-object p0, Lcom/tuneecu/vc;->be:[B

    array-length p0, p0

    sput p0, Lcom/tuneecu/vc;->xd:I

    sput p0, Lcom/tuneecu/vc;->yd:I

    invoke-static {}, Lcom/tuneecu/vc;->Wb()V
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    :cond_3
    :goto_1
    sput p1, Lcom/tuneecu/vc;->Dd:I

    sput p1, Lcom/tuneecu/vc;->Gd:I

    sput-boolean p2, Lcom/tuneecu/vc;->Ud:Z

    invoke-static {p2}, Lcom/tuneecu/LedBar;->n(Z)V

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide p0

    sput-wide p0, Lcom/tuneecu/vc;->ae:J

    return-void

    :catchall_0
    move-exception p0

    sput p1, Lcom/tuneecu/vc;->Dd:I

    sput p1, Lcom/tuneecu/vc;->Gd:I

    sput-boolean p2, Lcom/tuneecu/vc;->Ud:Z

    throw p0
.end method

.method static synthetic g3(Z)Z
    .locals 0

    sput-boolean p0, Lcom/tuneecu/vc;->Sd:Z

    return p0
.end method


# virtual methods
.method public Mb()V
    .locals 1

    const/4 v0, 0x0

    sput-boolean v0, Lcom/tuneecu/vc;->Rd:Z

    sput-boolean v0, Lcom/tuneecu/vc;->Xd:Z

    sget-boolean v0, Lcom/tuneecu/vc;->Wd:Z

    if-eqz v0, :cond_0

    sget-object v0, Lcom/tuneecu/y;->m0:Lcom/tuneecu/y;

    invoke-static {v0}, Lcom/tuneecu/z;->Ne(Lcom/tuneecu/y;)V

    :cond_0
    const/16 v0, 0x32

    invoke-static {v0}, Lcom/tuneecu/vc;->Pb(I)V

    sget-object v0, Lcom/tuneecu/vc;->ud:Lb/a/a/i;

    if-eqz v0, :cond_1

    sget-boolean v0, Lcom/tuneecu/MainActivity;->G5:Z

    if-eqz v0, :cond_1

    sget-object v0, Lcom/tuneecu/vc;->ud:Lb/a/a/i;

    invoke-virtual {v0}, Lb/a/a/i;->t()Z

    move-result v0

    if-eqz v0, :cond_1

    sget-object v0, Lcom/tuneecu/vc;->ud:Lb/a/a/i;

    invoke-virtual {v0}, Lb/a/a/i;->a()V

    iget-object v0, p0, Lcom/tuneecu/vc;->sd:Lcom/tuneecu/uc;

    if-eqz v0, :cond_1

    invoke-virtual {v0}, Ljava/lang/Thread;->interrupt()V

    :cond_1
    return-void
.end method

.method public Ob()Z
    .locals 6

    sget-object v0, Ljava/lang/Boolean;->TRUE:Ljava/lang/Boolean;

    const/4 v1, 0x0

    sput v1, Lcom/tuneecu/vc;->Dd:I

    const/16 v2, 0x800

    new-array v2, v2, [B

    sput-object v2, Lcom/tuneecu/vc;->ce:[B

    const/16 v2, 0x1000

    new-array v2, v2, [B

    sput-object v2, Lcom/tuneecu/vc;->de:[B

    sget-object v2, Lcom/tuneecu/MainActivity;->v4:Lb/a/a/g;

    if-eqz v2, :cond_0

    sget-object v3, Lcom/tuneecu/MainActivity;->y4:Landroid/content/Context;

    invoke-virtual {v2, v3}, Lb/a/a/g;->f(Landroid/content/Context;)I

    move-result v2

    sput v2, Lcom/tuneecu/vc;->vd:I

    :cond_0
    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Device number = "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    sget v3, Lcom/tuneecu/vc;->vd:I

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    const-string v3, "Misc Function Test "

    invoke-static {v3, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    sget v2, Lcom/tuneecu/vc;->vd:I

    if-lez v2, :cond_6

    const/4 v2, 0x1

    :try_start_0
    sget-object v3, Lcom/tuneecu/MainActivity;->v4:Lb/a/a/g;

    sget-object v4, Lcom/tuneecu/MainActivity;->y4:Landroid/content/Context;

    invoke-virtual {v3, v4, v1}, Lb/a/a/g;->m(Landroid/content/Context;I)Lb/a/a/i;

    move-result-object v3

    sput-object v3, Lcom/tuneecu/vc;->ud:Lb/a/a/i;

    if-nez v3, :cond_1

    sget-object v2, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    const-string v3, "ftDevice == null"

    invoke-virtual {v2, v3, v1, v0}, Lcom/tuneecu/MainActivity;->r6(Ljava/lang/String;ILjava/lang/Boolean;)V

    goto/16 :goto_0

    :cond_1
    invoke-virtual {v3}, Lb/a/a/i;->t()Z

    move-result v3
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    if-eqz v3, :cond_5

    :try_start_1
    sget-object v3, Lcom/tuneecu/vc;->ud:Lb/a/a/i;

    const/16 v4, 0x8

    invoke-virtual {v3, v4, v2, v1}, Lb/a/a/i;->H(BBB)Z

    sget-object v3, Lcom/tuneecu/vc;->ud:Lb/a/a/i;

    const/16 v4, 0x11

    const/16 v5, 0x13

    invoke-virtual {v3, v1, v4, v5}, Lb/a/a/i;->K(SBB)Z

    sget-object v3, Lcom/tuneecu/vc;->ud:Lb/a/a/i;

    invoke-virtual {v3, v1, v1}, Lb/a/a/i;->A(BB)Z

    sget-boolean v3, Lcom/tuneecu/MainActivity;->F5:Z

    if-nez v3, :cond_4

    sget-boolean v3, Lcom/tuneecu/vc;->Xd:Z

    if-nez v3, :cond_2

    new-instance v3, Lcom/tuneecu/uc;

    iget-object v4, p0, Lcom/tuneecu/vc;->td:Landroid/os/Handler;

    sget-object v5, Lcom/tuneecu/MainActivity;->nd:Ljava/io/OutputStreamWriter;

    invoke-direct {v3, p0, v4, v5}, Lcom/tuneecu/uc;-><init>(Lcom/tuneecu/vc;Landroid/os/Handler;Ljava/io/OutputStreamWriter;)V

    iput-object v3, p0, Lcom/tuneecu/vc;->sd:Lcom/tuneecu/uc;

    invoke-virtual {v3}, Ljava/lang/Thread;->start()V

    sput-boolean v2, Lcom/tuneecu/vc;->Xd:Z

    sput v1, Lcom/tuneecu/vc;->Md:I

    :cond_2
    sget-boolean v3, Lcom/tuneecu/MainActivity;->C5:Z

    if-eqz v3, :cond_3

    sget-object v3, Lcom/tuneecu/vc;->ud:Lb/a/a/i;

    const v4, 0x1c200

    invoke-virtual {v3, v4}, Lb/a/a/i;->z(I)Z

    :cond_3
    const/16 v3, 0x28a0

    invoke-virtual {p0, v3, v2}, Lcom/tuneecu/vc;->Rb(IZ)V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_1

    :cond_4
    const/4 v1, 0x1

    goto :goto_0

    :cond_5
    :try_start_2
    sget-object v2, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    sget-object v3, Lcom/tuneecu/MainActivity;->y4:Landroid/content/Context;

    const v4, 0x7f110424

    invoke-virtual {v3, v4}, Landroid/content/Context;->getText(I)Ljava/lang/CharSequence;

    move-result-object v3

    invoke-interface {v3}, Ljava/lang/CharSequence;->toString()Ljava/lang/String;

    move-result-object v3

    sget-object v4, Ljava/lang/Boolean;->FALSE:Ljava/lang/Boolean;

    invoke-virtual {v2, v3, v1, v4}, Lcom/tuneecu/MainActivity;->r6(Ljava/lang/String;ILjava/lang/Boolean;)V
    :try_end_2
    .catch Ljava/lang/Exception; {:try_start_2 .. :try_end_2} :catch_0

    goto :goto_0

    :catch_0
    const/4 v2, 0x0

    :catch_1
    sget-object v3, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    sget-object v4, Lcom/tuneecu/MainActivity;->y4:Landroid/content/Context;

    const v5, 0x7f11070a

    invoke-virtual {v4, v5}, Landroid/content/Context;->getText(I)Ljava/lang/CharSequence;

    move-result-object v4

    invoke-interface {v4}, Ljava/lang/CharSequence;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4, v1, v0}, Lcom/tuneecu/MainActivity;->r6(Ljava/lang/String;ILjava/lang/Boolean;)V

    sget-object v0, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    invoke-virtual {v0}, Lcom/tuneecu/MainActivity;->o9()V

    move v1, v2

    :cond_6
    :goto_0
    return v1
.end method

.method public Rb(IZ)V
    .locals 1

    sget-object v0, Lcom/tuneecu/vc;->ud:Lb/a/a/i;

    if-eqz v0, :cond_1

    invoke-virtual {v0}, Lb/a/a/i;->t()Z

    move-result v0

    if-eqz v0, :cond_1

    sget-boolean v0, Lcom/tuneecu/MainActivity;->C5:Z

    if-nez v0, :cond_0

    sget-object v0, Lcom/tuneecu/vc;->ud:Lb/a/a/i;

    invoke-virtual {v0, p1}, Lb/a/a/i;->z(I)Z

    :cond_0
    if-eqz p2, :cond_1

    sget-object p1, Lcom/tuneecu/vc;->ud:Lb/a/a/i;

    const/4 p2, 0x3

    invoke-virtual {p1, p2}, Lb/a/a/i;->v(B)Z

    :cond_1
    return-void
.end method

.method public Tb(Lcom/tuneecu/x;)Ljava/lang/String;
    .locals 5

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result v0

    sget-object v1, Lcom/tuneecu/x;->q:Lcom/tuneecu/x;

    const/4 v2, 0x0

    const/4 v3, 0x1

    if-ne p1, v1, :cond_0

    const/4 v1, 0x1

    goto :goto_0

    :cond_0
    const/4 v1, 0x0

    :goto_0
    sget-object v4, Lcom/tuneecu/x;->A:Lcom/tuneecu/x;

    if-ne p1, v4, :cond_1

    const/4 v4, 0x1

    goto :goto_1

    :cond_1
    const/4 v4, 0x0

    :goto_1
    or-int/2addr v1, v4

    if-eqz v1, :cond_2

    sget-object p1, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    invoke-virtual {p1, v2}, Lcom/tuneecu/MainActivity;->c8(I)V

    goto :goto_2

    :cond_2
    sget-object v1, Lcom/tuneecu/x;->n:Lcom/tuneecu/x;

    if-ne p1, v1, :cond_3

    sget-object p1, Lcom/tuneecu/vc;->fe:Lcom/tuneecu/MainActivity;

    invoke-virtual {p1, v3}, Lcom/tuneecu/MainActivity;->c8(I)V

    :cond_3
    :goto_2
    sget-object p1, Lcom/tuneecu/MainActivity;->y4:Landroid/content/Context;

    invoke-virtual {p1}, Landroid/content/Context;->getResources()Landroid/content/res/Resources;

    move-result-object p1

    const v1, 0x7f030009

    invoke-virtual {p1, v1}, Landroid/content/res/Resources;->getStringArray(I)[Ljava/lang/String;

    move-result-object p1

    aget-object p1, p1, v0

    sput-boolean v3, Lcom/tuneecu/vc;->Yd:Z

    return-object p1
.end method

.method public Vb()V
    .locals 2

    sget-boolean v0, Lcom/tuneecu/vc;->Rd:Z

    if-nez v0, :cond_0

    new-instance v0, Lcom/tuneecu/tc;

    iget-object v1, p0, Lcom/tuneecu/vc;->td:Landroid/os/Handler;

    invoke-direct {v0, v1}, Lcom/tuneecu/tc;-><init>(Landroid/os/Handler;)V

    invoke-virtual {v0}, Ljava/lang/Thread;->start()V

    const/4 v0, 0x1

    sput-boolean v0, Lcom/tuneecu/vc;->Rd:Z

    const/4 v0, 0x0

    sput v0, Lcom/tuneecu/vc;->Md:I

    :cond_0
    return-void
.end method
