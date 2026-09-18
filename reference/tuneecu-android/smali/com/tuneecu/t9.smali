.class Lcom/tuneecu/t9;
.super Landroid/os/Handler;
.source ""


# instance fields
.field final synthetic a:Lcom/tuneecu/MainActivity;


# direct methods
.method constructor <init>(Lcom/tuneecu/MainActivity;)V
    .locals 0

    iput-object p1, p0, Lcom/tuneecu/t9;->a:Lcom/tuneecu/MainActivity;

    invoke-direct {p0}, Landroid/os/Handler;-><init>()V

    return-void
.end method


# virtual methods
.method public handleMessage(Landroid/os/Message;)V
    .locals 8

    sget-object v0, Ljava/lang/Boolean;->TRUE:Ljava/lang/Boolean;

    iget v1, p1, Landroid/os/Message;->what:I

    const/4 v2, 0x5

    const/4 v3, 0x2

    const-string v4, "MainActivity"

    const/4 v5, 0x1

    const/4 v6, 0x0

    if-eq v1, v5, :cond_3

    if-eq v1, v3, :cond_2

    const/4 v3, 0x4

    if-eq v1, v3, :cond_1

    if-eq v1, v2, :cond_0

    goto/16 :goto_3

    :cond_0
    iget-object v1, p0, Lcom/tuneecu/t9;->a:Lcom/tuneecu/MainActivity;

    invoke-virtual {p1}, Landroid/os/Message;->getData()Landroid/os/Bundle;

    move-result-object p1

    const-string v2, "toast"

    invoke-virtual {p1, v2}, Landroid/os/Bundle;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object p1

    invoke-virtual {v1, p1, v6, v0}, Lcom/tuneecu/MainActivity;->r6(Ljava/lang/String;ILjava/lang/Boolean;)V

    goto/16 :goto_3

    :cond_1
    sput-boolean v5, Lcom/tuneecu/MainActivity;->F5:Z

    invoke-static {v6}, Lcom/tuneecu/MainActivity;->O(Z)Z

    invoke-virtual {p1}, Landroid/os/Message;->getData()Landroid/os/Bundle;

    move-result-object p1

    const-string v1, "device_name"

    invoke-virtual {p1, v1}, Landroid/os/Bundle;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object p1

    invoke-static {p1}, Lcom/tuneecu/MainActivity;->T(Ljava/lang/String;)Ljava/lang/String;

    iget-object p1, p0, Lcom/tuneecu/t9;->a:Lcom/tuneecu/MainActivity;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    iget-object v2, p0, Lcom/tuneecu/t9;->a:Lcom/tuneecu/MainActivity;

    const v3, 0x7f1102cf

    invoke-virtual {v2, v3}, Landroid/app/Activity;->getText(I)Ljava/lang/CharSequence;

    move-result-object v2

    invoke-interface {v2}, Ljava/lang/CharSequence;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v2, " "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-static {}, Lcom/tuneecu/MainActivity;->S()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {p1, v1, v6, v0}, Lcom/tuneecu/MainActivity;->r6(Ljava/lang/String;ILjava/lang/Boolean;)V

    goto/16 :goto_3

    :cond_2
    :try_start_0
    iget-object v0, p0, Lcom/tuneecu/t9;->a:Lcom/tuneecu/MainActivity;

    iget-object p1, p1, Landroid/os/Message;->obj:Ljava/lang/Object;

    invoke-virtual {p1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-static {v0, p1}, Lcom/tuneecu/MainActivity;->R(Lcom/tuneecu/MainActivity;Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto/16 :goto_3

    :catch_0
    move-exception p1

    sget-boolean v0, Lcom/tuneecu/MainActivity;->P5:Z

    if-eqz v0, :cond_10

    invoke-static {p1}, Landroid/util/Log;->getStackTraceString(Ljava/lang/Throwable;)Ljava/lang/String;

    move-result-object p1

    invoke-static {v4, p1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto/16 :goto_3

    :cond_3
    sget-boolean v1, Lcom/tuneecu/MainActivity;->P5:Z

    if-eqz v1, :cond_4

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v7, "MESSAGE_STATE_CHANGE: "

    invoke-virtual {v1, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget v7, p1, Landroid/os/Message;->arg1:I

    invoke-virtual {v1, v7}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v4, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    :cond_4
    iget p1, p1, Landroid/os/Message;->arg1:I

    const-string v1, ""

    if-eqz p1, :cond_9

    if-eq p1, v5, :cond_9

    const/4 v0, 0x3

    if-eq p1, v3, :cond_8

    if-eq p1, v0, :cond_5

    goto/16 :goto_3

    :cond_5
    const/4 p1, 0x6

    invoke-static {p1, v1}, Lcom/tuneecu/MainActivity;->Ab(ILjava/lang/String;)V

    sput-boolean v6, Lcom/tuneecu/MainActivity;->H5:Z

    invoke-static {v6}, Lcom/tuneecu/LedBar;->j(I)V

    iget-object p1, p0, Lcom/tuneecu/t9;->a:Lcom/tuneecu/MainActivity;

    invoke-static {p1}, Lcom/tuneecu/MainActivity;->J(Lcom/tuneecu/MainActivity;)Ljava/lang/String;

    move-result-object v0

    invoke-static {p1, v0}, Lcom/tuneecu/MainActivity;->I(Lcom/tuneecu/MainActivity;Ljava/lang/String;)Ljava/lang/String;

    sget p1, Lcom/tuneecu/MainActivity;->Ia:I

    sput p1, Lcom/tuneecu/MainActivity;->Ja:I

    sget-object p1, Lcom/tuneecu/MainActivity;->nb:Ljava/lang/String;

    invoke-static {v2, p1}, Lcom/tuneecu/MainActivity;->Ab(ILjava/lang/String;)V

    sget-object p1, Lcom/tuneecu/y;->b:Lcom/tuneecu/y;

    invoke-static {p1}, Lcom/tuneecu/z;->Ne(Lcom/tuneecu/y;)V

    const/16 p1, 0x8

    invoke-static {p1}, Lcom/tuneecu/vc;->Ub(I)V

    sget-boolean p1, Lcom/tuneecu/MainActivity;->I9:Z

    if-eqz p1, :cond_6

    sget-boolean p1, Lcom/tuneecu/MainActivity;->J5:Z

    if-nez p1, :cond_6

    iget-object p1, p0, Lcom/tuneecu/t9;->a:Lcom/tuneecu/MainActivity;

    invoke-static {p1}, Lcom/tuneecu/MainActivity;->L(Lcom/tuneecu/MainActivity;)V

    :cond_6
    sget-object p1, Lcom/tuneecu/MainActivity;->n6:Lcom/tuneecu/vc;

    invoke-virtual {p1}, Lcom/tuneecu/vc;->Vb()V

    invoke-static {v5}, Lcom/tuneecu/MainActivity;->M(Z)Z

    :cond_7
    :goto_0
    iget-object p1, p0, Lcom/tuneecu/t9;->a:Lcom/tuneecu/MainActivity;

    invoke-virtual {p1}, Lcom/tuneecu/MainActivity;->o9()V

    goto/16 :goto_3

    :cond_8
    invoke-static {v5}, Lcom/tuneecu/LedBar;->n(Z)V

    sget-object p1, Lcom/tuneecu/y;->b:Lcom/tuneecu/y;

    invoke-static {p1}, Lcom/tuneecu/z;->Ne(Lcom/tuneecu/y;)V

    invoke-static {v0}, Lcom/tuneecu/LedBar;->j(I)V

    invoke-static {v5}, Lcom/tuneecu/MainActivity;->O(Z)Z

    sput-boolean v5, Lcom/tuneecu/MainActivity;->J9:Z

    goto/16 :goto_3

    :cond_9
    sput-boolean v6, Lcom/tuneecu/MainActivity;->H5:Z

    sget-boolean p1, Lcom/tuneecu/MainActivity;->F5:Z

    invoke-static {}, Lcom/tuneecu/MainActivity;->N()Z

    move-result v2

    xor-int/2addr v2, v5

    and-int/2addr p1, v2

    if-eqz p1, :cond_c

    sget-object p1, Lcom/tuneecu/MainActivity;->s6:Lcom/tuneecu/LedBar;

    invoke-virtual {p1, v6}, Lcom/tuneecu/LedBar;->o(Z)V

    iget-object p1, p0, Lcom/tuneecu/t9;->a:Lcom/tuneecu/MainActivity;

    invoke-virtual {p1, v6}, Lcom/tuneecu/MainActivity;->n6(Z)V

    const-wide/16 v1, 0x3e8

    :try_start_1
    invoke-static {v1, v2}, Ljava/lang/Thread;->sleep(J)V
    :try_end_1
    .catch Ljava/lang/InterruptedException; {:try_start_1 .. :try_end_1} :catch_1

    goto :goto_1

    :catch_1
    move-exception p1

    sget-boolean v1, Lcom/tuneecu/MainActivity;->P5:Z

    if-eqz v1, :cond_a

    invoke-static {p1}, Landroid/util/Log;->getStackTraceString(Ljava/lang/Throwable;)Ljava/lang/String;

    move-result-object p1

    invoke-static {v4, p1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    :cond_a
    :goto_1
    iget-object p1, p0, Lcom/tuneecu/t9;->a:Lcom/tuneecu/MainActivity;

    const v1, 0x7f1102d2

    invoke-virtual {p1, v1}, Landroid/app/Activity;->getText(I)Ljava/lang/CharSequence;

    move-result-object v1

    invoke-interface {v1}, Ljava/lang/CharSequence;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {p1, v1, v6, v0}, Lcom/tuneecu/MainActivity;->r6(Ljava/lang/String;ILjava/lang/Boolean;)V

    :cond_b
    :goto_2
    iget-object p1, p0, Lcom/tuneecu/t9;->a:Lcom/tuneecu/MainActivity;

    invoke-static {p1}, Lcom/tuneecu/MainActivity;->P(Lcom/tuneecu/MainActivity;)V

    goto :goto_0

    :cond_c
    invoke-static {}, Lcom/tuneecu/MainActivity;->N()Z

    move-result p1

    if-eqz p1, :cond_7

    sget-boolean p1, Lcom/tuneecu/MainActivity;->z5:Z

    const/4 v2, 0x0

    if-nez p1, :cond_e

    iget-object p1, p0, Lcom/tuneecu/t9;->a:Lcom/tuneecu/MainActivity;

    invoke-static {p1}, Lcom/tuneecu/MainActivity;->H(Lcom/tuneecu/MainActivity;)Ljava/lang/String;

    move-result-object p1

    if-eqz p1, :cond_d

    sget-boolean p1, Lcom/tuneecu/MainActivity;->J9:Z

    if-nez p1, :cond_b

    iget-object p1, p0, Lcom/tuneecu/t9;->a:Lcom/tuneecu/MainActivity;

    invoke-static {p1, v2}, Lcom/tuneecu/MainActivity;->I(Lcom/tuneecu/MainActivity;Ljava/lang/String;)Ljava/lang/String;

    goto :goto_2

    :cond_d
    sget-object p1, Lcom/tuneecu/MainActivity;->s6:Lcom/tuneecu/LedBar;

    invoke-virtual {p1, v6}, Lcom/tuneecu/LedBar;->o(Z)V

    invoke-static {v6}, Lcom/tuneecu/MainActivity;->O(Z)Z

    iget-object p1, p0, Lcom/tuneecu/t9;->a:Lcom/tuneecu/MainActivity;

    invoke-virtual {p1}, Lcom/tuneecu/MainActivity;->o9()V

    sput-boolean v6, Lcom/tuneecu/vc;->Xd:Z

    const/4 p1, 0x7

    invoke-static {p1, v1}, Lcom/tuneecu/MainActivity;->Ab(ILjava/lang/String;)V

    iget-object p1, p0, Lcom/tuneecu/t9;->a:Lcom/tuneecu/MainActivity;

    const v1, 0x7f11070a

    invoke-virtual {p1, v1}, Landroid/app/Activity;->getText(I)Ljava/lang/CharSequence;

    move-result-object v1

    invoke-interface {v1}, Ljava/lang/CharSequence;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {p1, v1, v6, v0}, Lcom/tuneecu/MainActivity;->r6(Ljava/lang/String;ILjava/lang/Boolean;)V

    goto/16 :goto_0

    :cond_e
    sget p1, Lcom/tuneecu/MainActivity;->Ja:I

    const/16 v0, 0x14

    if-ne p1, v0, :cond_f

    iget-object p1, p0, Lcom/tuneecu/t9;->a:Lcom/tuneecu/MainActivity;

    invoke-virtual {p1, v5}, Lcom/tuneecu/MainActivity;->n6(Z)V

    goto/16 :goto_0

    :cond_f
    iget-object p1, p0, Lcom/tuneecu/t9;->a:Lcom/tuneecu/MainActivity;

    invoke-static {p1, v2, v6}, Lcom/tuneecu/MainActivity;->Q(Lcom/tuneecu/MainActivity;Ljava/lang/String;I)V

    goto/16 :goto_0

    :cond_10
    :goto_3
    return-void
.end method
