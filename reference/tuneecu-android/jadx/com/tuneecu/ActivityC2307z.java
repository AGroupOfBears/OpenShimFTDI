package com.tuneecu;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.os.SystemClock;
import android.util.Log;
import android.widget.TextView;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Locale;

/* JADX INFO: renamed from: com.tuneecu.z */
/* JADX INFO: loaded from: classes.dex */
public class ActivityC2307z extends MainActivity {

    /* JADX INFO: renamed from: Ad */
    static int f8770Ad = 0;

    /* JADX INFO: renamed from: Af */
    public static boolean f8772Af = false;

    /* JADX INFO: renamed from: Ag */
    static String f8773Ag = null;

    /* JADX INFO: renamed from: Bd */
    static int f8775Bd = 0;

    /* JADX INFO: renamed from: Bf */
    public static boolean f8777Bf = false;

    /* JADX INFO: renamed from: Bg */
    static ActivityC2266vc f8778Bg = null;

    /* JADX INFO: renamed from: Cd */
    static int f8780Cd = 0;

    /* JADX INFO: renamed from: Ce */
    private static int f8781Ce = 0;

    /* JADX INFO: renamed from: Cf */
    public static boolean f8782Cf = false;

    /* JADX INFO: renamed from: Cg */
    @SuppressLint({"StaticFieldLeak"})
    static MainActivity f8783Cg = null;

    /* JADX INFO: renamed from: Dd */
    private static boolean f8785Dd = false;

    /* JADX INFO: renamed from: De */
    private static int f8786De = 0;

    /* JADX INFO: renamed from: Df */
    public static boolean f8787Df = false;

    /* JADX INFO: renamed from: Dg */
    static ActivityC1960a0 f8788Dg = null;

    /* JADX INFO: renamed from: Ed */
    private static int f8790Ed = 0;

    /* JADX INFO: renamed from: Ee */
    private static int f8791Ee = 0;

    /* JADX INFO: renamed from: Ef */
    public static boolean f8792Ef = false;

    /* JADX INFO: renamed from: Eg */
    static StatusBar f8793Eg = null;

    /* JADX INFO: renamed from: Fd */
    private static int f8795Fd = 0;

    /* JADX INFO: renamed from: Fe */
    private static String f8796Fe = null;

    /* JADX INFO: renamed from: Ff */
    public static boolean f8797Ff = false;

    /* JADX INFO: renamed from: Fg */
    private static short f8798Fg = 0;

    /* JADX INFO: renamed from: Gd */
    private static int f8800Gd = 0;

    /* JADX INFO: renamed from: Ge */
    private static int f8801Ge = 0;

    /* JADX INFO: renamed from: Gf */
    public static boolean f8802Gf = false;

    /* JADX INFO: renamed from: Gg */
    public static short f8803Gg = 0;

    /* JADX INFO: renamed from: Hd */
    private static int f8805Hd = 0;

    /* JADX INFO: renamed from: He */
    private static int f8806He = 0;

    /* JADX INFO: renamed from: Hf */
    public static boolean f8807Hf = false;

    /* JADX INFO: renamed from: Hg */
    private static int f8808Hg = 0;

    /* JADX INFO: renamed from: Id */
    private static int f8810Id = 0;

    /* JADX INFO: renamed from: Ie */
    private static int f8811Ie = 0;

    /* JADX INFO: renamed from: If */
    public static boolean f8812If = false;

    /* JADX INFO: renamed from: Ig */
    private static int f8813Ig = 0;

    /* JADX INFO: renamed from: Jd */
    private static int f8815Jd = 0;

    /* JADX INFO: renamed from: Je */
    public static int f8816Je = 0;

    /* JADX INFO: renamed from: Jf */
    public static boolean f8817Jf = false;

    /* JADX INFO: renamed from: Jg */
    private static int f8818Jg = 0;

    /* JADX INFO: renamed from: Kd */
    private static int f8820Kd = 0;

    /* JADX INFO: renamed from: Ke */
    public static int f8821Ke = 0;

    /* JADX INFO: renamed from: Kf */
    public static boolean f8822Kf = false;

    /* JADX INFO: renamed from: Kg */
    private static int f8823Kg = 0;

    /* JADX INFO: renamed from: Ld */
    private static long f8825Ld = 0;

    /* JADX INFO: renamed from: Le */
    public static int f8826Le = 0;

    /* JADX INFO: renamed from: Lf */
    public static boolean f8827Lf = false;

    /* JADX INFO: renamed from: Lg */
    public static Boolean f8828Lg = null;

    /* JADX INFO: renamed from: Md */
    private static long f8830Md = 0;

    /* JADX INFO: renamed from: Me */
    public static int f8831Me = 0;

    /* JADX INFO: renamed from: Mf */
    public static boolean f8832Mf = false;

    /* JADX INFO: renamed from: Mg */
    private static List f8833Mg = null;

    /* JADX INFO: renamed from: Nd */
    public static byte f8835Nd = 0;

    /* JADX INFO: renamed from: Ne */
    public static int f8836Ne = 0;

    /* JADX INFO: renamed from: Nf */
    public static boolean f8837Nf = false;

    /* JADX INFO: renamed from: Ng */
    static int f8838Ng = 0;

    /* JADX INFO: renamed from: Od */
    public static byte f8840Od = 0;

    /* JADX INFO: renamed from: Oe */
    public static int f8841Oe = 0;

    /* JADX INFO: renamed from: Of */
    public static boolean f8842Of = false;

    /* JADX INFO: renamed from: Og */
    static int f8843Og = 0;

    /* JADX INFO: renamed from: Pd */
    public static byte f8845Pd = 0;

    /* JADX INFO: renamed from: Pe */
    public static int f8846Pe = 0;

    /* JADX INFO: renamed from: Pf */
    public static boolean f8847Pf = false;

    /* JADX INFO: renamed from: Qd */
    public static byte f8850Qd = 0;

    /* JADX INFO: renamed from: Qe */
    public static int f8851Qe = 0;

    /* JADX INFO: renamed from: Qf */
    public static boolean f8852Qf = false;

    /* JADX INFO: renamed from: Rd */
    public static byte f8855Rd = 0;

    /* JADX INFO: renamed from: Re */
    public static int f8856Re = 0;

    /* JADX INFO: renamed from: Rf */
    public static boolean f8857Rf = false;

    /* JADX INFO: renamed from: Se */
    public static int f8861Se = 0;

    /* JADX INFO: renamed from: Sf */
    public static boolean f8862Sf = false;

    /* JADX INFO: renamed from: Td */
    public static String f8865Td = null;

    /* JADX INFO: renamed from: Te */
    public static boolean f8866Te = false;

    /* JADX INFO: renamed from: Tf */
    public static boolean f8867Tf = false;

    /* JADX INFO: renamed from: Tg */
    private static short[] f8868Tg = null;

    /* JADX INFO: renamed from: Ud */
    public static String f8870Ud = null;

    /* JADX INFO: renamed from: Ue */
    public static boolean f8871Ue = false;

    /* JADX INFO: renamed from: Uf */
    public static boolean f8872Uf = false;

    /* JADX INFO: renamed from: Ug */
    private static short[] f8873Ug = null;

    /* JADX INFO: renamed from: Vd */
    private static byte[] f8875Vd = null;

    /* JADX INFO: renamed from: Ve */
    public static boolean f8876Ve = false;

    /* JADX INFO: renamed from: Vf */
    public static boolean f8877Vf = false;

    /* JADX INFO: renamed from: Wd */
    private static byte[] f8880Wd = null;

    /* JADX INFO: renamed from: We */
    public static boolean f8881We = false;

    /* JADX INFO: renamed from: Wf */
    public static boolean f8882Wf = false;

    /* JADX INFO: renamed from: Xd */
    private static byte[] f8885Xd = null;

    /* JADX INFO: renamed from: Xe */
    public static boolean f8886Xe = false;

    /* JADX INFO: renamed from: Xf */
    public static boolean f8887Xf = false;

    /* JADX INFO: renamed from: Yd */
    private static byte[] f8890Yd = null;

    /* JADX INFO: renamed from: Ye */
    public static boolean f8891Ye = false;

    /* JADX INFO: renamed from: Yf */
    public static boolean f8892Yf = false;

    /* JADX INFO: renamed from: Zd */
    private static byte[] f8895Zd = null;

    /* JADX INFO: renamed from: Ze */
    public static boolean f8896Ze = false;

    /* JADX INFO: renamed from: Zf */
    public static boolean f8897Zf = false;

    /* JADX INFO: renamed from: ae */
    public static byte[] f8900ae = null;

    /* JADX INFO: renamed from: af */
    public static boolean f8901af = false;

    /* JADX INFO: renamed from: ag */
    public static boolean f8902ag = false;

    /* JADX INFO: renamed from: bf */
    public static boolean f8906bf = false;

    /* JADX INFO: renamed from: bg */
    public static boolean f8907bg = false;

    /* JADX INFO: renamed from: cf */
    public static boolean f8911cf = false;

    /* JADX INFO: renamed from: cg */
    public static boolean f8912cg = false;

    /* JADX INFO: renamed from: df */
    public static boolean f8916df = false;

    /* JADX INFO: renamed from: dg */
    public static boolean f8917dg = false;

    /* JADX INFO: renamed from: ef */
    public static boolean f8921ef = false;

    /* JADX INFO: renamed from: eg */
    public static boolean f8922eg = false;

    /* JADX INFO: renamed from: fe */
    public static byte f8925fe = 0;

    /* JADX INFO: renamed from: ff */
    public static boolean f8926ff = false;

    /* JADX INFO: renamed from: fg */
    public static boolean f8927fg = false;

    /* JADX INFO: renamed from: ge */
    public static byte f8930ge = 0;

    /* JADX INFO: renamed from: gf */
    public static boolean f8931gf = false;

    /* JADX INFO: renamed from: gg */
    public static boolean f8932gg = false;

    /* JADX INFO: renamed from: he */
    private static int f8935he = 0;

    /* JADX INFO: renamed from: hf */
    public static boolean f8936hf = false;

    /* JADX INFO: renamed from: hg */
    public static boolean f8937hg = false;

    /* JADX INFO: renamed from: ie */
    private static int f8940ie = 0;

    /* JADX INFO: renamed from: if */
    public static boolean f8941if = false;

    /* JADX INFO: renamed from: ig */
    public static boolean f8942ig = false;

    /* JADX INFO: renamed from: je */
    private static int f8944je = 0;

    /* JADX INFO: renamed from: jf */
    public static boolean f8945jf = false;

    /* JADX INFO: renamed from: jg */
    public static boolean f8946jg = false;

    /* JADX INFO: renamed from: ke */
    public static int f8948ke = 0;

    /* JADX INFO: renamed from: kf */
    public static boolean f8949kf = false;

    /* JADX INFO: renamed from: kg */
    public static boolean f8950kg = false;

    /* JADX INFO: renamed from: le */
    public static int f8952le = 0;

    /* JADX INFO: renamed from: lf */
    public static boolean f8953lf = false;

    /* JADX INFO: renamed from: lg */
    public static boolean f8954lg = false;

    /* JADX INFO: renamed from: me */
    public static int f8956me = 0;

    /* JADX INFO: renamed from: mf */
    public static boolean f8957mf = false;

    /* JADX INFO: renamed from: mg */
    public static boolean f8958mg = false;

    /* JADX INFO: renamed from: ne */
    public static int f8960ne = 0;

    /* JADX INFO: renamed from: nf */
    public static boolean f8961nf = false;

    /* JADX INFO: renamed from: ng */
    public static boolean f8962ng = false;

    /* JADX INFO: renamed from: oe */
    public static int f8964oe = 0;

    /* JADX INFO: renamed from: of */
    public static boolean f8965of = false;

    /* JADX INFO: renamed from: og */
    public static boolean f8966og = false;

    /* JADX INFO: renamed from: pe */
    public static int f8968pe = 0;

    /* JADX INFO: renamed from: pf */
    public static boolean f8969pf = false;

    /* JADX INFO: renamed from: pg */
    public static boolean f8970pg = false;

    /* JADX INFO: renamed from: qe */
    public static int f8972qe = 0;

    /* JADX INFO: renamed from: qf */
    public static boolean f8973qf = false;

    /* JADX INFO: renamed from: qg */
    public static boolean f8974qg = false;

    /* JADX INFO: renamed from: re */
    public static int f8976re = 0;

    /* JADX INFO: renamed from: rf */
    public static boolean f8977rf = false;

    /* JADX INFO: renamed from: rg */
    public static boolean f8978rg = false;

    /* JADX INFO: renamed from: se */
    public static int f8980se = 0;

    /* JADX INFO: renamed from: sf */
    public static boolean f8981sf = false;

    /* JADX INFO: renamed from: sg */
    public static boolean f8982sg = false;

    /* JADX INFO: renamed from: te */
    public static int f8984te = 0;

    /* JADX INFO: renamed from: tf */
    public static boolean f8985tf = false;

    /* JADX INFO: renamed from: tg */
    public static boolean f8986tg = false;

    /* JADX INFO: renamed from: ue */
    public static int f8988ue = 0;

    /* JADX INFO: renamed from: uf */
    public static boolean f8989uf = false;

    /* JADX INFO: renamed from: ug */
    private static boolean f8990ug = false;

    /* JADX INFO: renamed from: vd */
    public static EnumC2294y f8992vd = null;

    /* JADX INFO: renamed from: ve */
    public static int f8993ve = 0;

    /* JADX INFO: renamed from: vf */
    public static boolean f8994vf = false;

    /* JADX INFO: renamed from: vg */
    private static boolean f8995vg = false;

    /* JADX INFO: renamed from: wd */
    static int f8997wd = 0;

    /* JADX INFO: renamed from: we */
    public static int f8998we = 0;

    /* JADX INFO: renamed from: wf */
    public static boolean f8999wf = false;

    /* JADX INFO: renamed from: wg */
    private static boolean f9000wg = false;

    /* JADX INFO: renamed from: xd */
    static int f9002xd = 0;

    /* JADX INFO: renamed from: xe */
    public static int f9003xe = 0;

    /* JADX INFO: renamed from: xf */
    public static boolean f9004xf = false;

    /* JADX INFO: renamed from: xg */
    private static boolean f9005xg = false;

    /* JADX INFO: renamed from: yd */
    static int f9007yd = 0;

    /* JADX INFO: renamed from: ye */
    public static int f9008ye = 0;

    /* JADX INFO: renamed from: yf */
    public static boolean f9009yf = false;

    /* JADX INFO: renamed from: yg */
    private static boolean f9010yg = false;

    /* JADX INFO: renamed from: zd */
    static int f9012zd = 0;

    /* JADX INFO: renamed from: ze */
    public static int f9013ze = 0;

    /* JADX INFO: renamed from: zf */
    public static boolean f9014zf = false;

    /* JADX INFO: renamed from: zg */
    private static boolean f9015zg = false;

    /* JADX INFO: renamed from: sd */
    short[] f9017sd = {257, 262, 260, 258, 259, 266, 268, 269, 264, 270, 271, 274, 511, 511, 511, 511, 511, 511, 511, 511, 511, 511, 511, 511, 273, 511, 368, 304, 511, 416, 511, 511, 400, 511, 511, 511, 337, 338, 321, 322, 323, 324, 400, 497, 498, 337, 321, 497, 511, 485, 468, 477, 511, 479, 511, 482, 478, 511, 511, 511, 511, 511, 511, 511, 511, 511, 511, 511, 511, 511, 511, 511, 511, 511, 261, 4, 511, 511, 511, 511, 511, 511, 511, 511, 264, 265, 258, 259, 511, 511, 511, 511, 511, 511, 511, 511, 262, 511, 261, 511, 511, 511, 511, 511, 511, 511, 511, 511, 258, 259, 290, 291, 264, 265, 266, 267, 511, 511, 511, 511, 511, 256, 258, 511, 260, 262, 511, 264, 511, 511, 511, 511, 266, 268, 511, 511, 14, 511, 272, 511, 18, 511, 511, 511, 511, 257, 258, 511, 260, 511, 511, 511, 511, 511, 511, 511, 511, 511, 511, 511, 511, 511, 511, 511, 511, 277, 278, 279};

    /* JADX INFO: renamed from: td */
    short[] f9018td = {256, 263, 265, 267, 512, 385, 392, 395, 398, 275, 276, 2585, 511, 450, 511, 511, 511, 511, 511, 511, 512, 305, 511, 511, 511, 511, 511, 511, 511, 511, 511, 511, 511, 511, 511, 511, 511, 391, 511, 511, 511, 261, 511, 511, 511, 511, 511, 511, 289, 511, 511, 511, 638, 511, 511, 288, 20, 511, 511, 511, 511, 511, 511, 511, 511, 511, 511, 511, 382, 511, 511, 511, 511, 511, 290, 291, 511, 511, 511, 511};

    /* JADX INFO: renamed from: ud */
    int[] f9019ud = {5, 9015, 9010, 9013, 0, 0, 0, 0, 0, 127, 34160, 145};

    /* JADX INFO: renamed from: Sd */
    public static final String[] f8860Sd = new String[100];

    /* JADX INFO: renamed from: be */
    public static byte[] f8905be = new byte[28];

    /* JADX INFO: renamed from: ce */
    public static byte[] f8910ce = new byte[28];

    /* JADX INFO: renamed from: de */
    public static byte[] f8915de = new byte[6];

    /* JADX INFO: renamed from: ee */
    private static final byte[] f8920ee = new byte[128];

    /* JADX INFO: renamed from: Ae */
    public static int[] f8771Ae = new int[60];

    /* JADX INFO: renamed from: Be */
    private static final int[] f8776Be = new int[8];

    /* JADX INFO: renamed from: Pg */
    static int[] f8848Pg = {40014, 20419, 51235, 48689, 44616, 47863};

    /* JADX INFO: renamed from: Qg */
    private static final short[] f8853Qg = {15361, 15362, 15363, 15364, 15368, 15369, 15371, 0, 6657, 6658, 6661, 6664, 6674, 6688, 6705, 6706, 160, 174, 140, 153, 155, 144, 167, 128, 162, 0, 0, 0, 0, 0, 0, 0, 6784, 8602, 8614, 8624, 6811, 0, 0, 0, 6796, 6790, 6794, 0, 0, 0, 0, 0, 136, 140, 0, 0, 0, 0, 0, 0, 140, 144, 153, 17};

    /* JADX INFO: renamed from: Rg */
    private static int[] f8858Rg = {0, 100860414, 197118, 0, 318963713, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 33751041, 50528766, 67305982};

    /* JADX INFO: renamed from: Sg */
    private static int[] f8863Sg = {0, 0, 0, 0, 0, 16912638, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

    /* JADX INFO: renamed from: Vg */
    private static final short[] f8878Vg = {256, 1, 1, 1, 256, 1, 1, 1, 20739, 1, 256, 1, 1, 1, 256, 1, 1, 1, 313, 1, 256, 1, 1, 1, 256, 1, 1, 1, 7, 1};

    /* JADX INFO: renamed from: Wg */
    private static final short[] f8883Wg = {257, 1, 266, 1, 257, 1, 266, 1, 259, 1, 257, 1, 266, 1, 257, 1, 266, 1, 257, 1, 266, 1, 257, 1, 266, 1, 262, 1};

    /* JADX INFO: renamed from: Xg */
    private static final short[] f8888Xg = {256, 1, 1, 1, 256, 1, 1, 1, 256, 1, 256, 1, 1, 1, 256, 1, 1, 1, 256, 1, 256, 1, 1, 1, 256, 1, 1, 1, 7, 1};

    /* JADX INFO: renamed from: Yg */
    private static final short[] f8893Yg = {256, 1, 119, 1, 256, 1, 119, 1, 256, 1, 256, 1, 119, 1, 256, 1, 119, 1, 256, 1, 256, 1, 119, 1, 256, 1, 119, 1, 7, 1};

    /* JADX INFO: renamed from: Zg */
    private static final short[] f8898Zg = {59, 1, 23, 1, 59, 1, 23, 1, 20739, 1, 59, 1, 23, 1, 59, 1, 23, 1, 21, 1};

    /* JADX INFO: renamed from: ah */
    private static final short[] f8903ah = {256, 4, 23, 3, 1, 4, 7, 3, 256, 4, 257, 7, 1, 4, 9, 3, 256, 4, 23, 3, 1, 4, 64, 3, 256, 4, 257, 7, 1, 4, 33, 3, 256, 4, 23, 3, 1, 4, 313, 3, 256, 4, 257, 3, 1, 4, 64, 3, 256, 4, 23, 7, 1, 4, 33, 3, 256, 4, 257, 7, 1, 4, 20739, 3, 256, 4, 23, 3, 1, 4, 64, 3, 256, 4, 257, 7, 1, 4, 33, 3};

    /* JADX INFO: renamed from: bh */
    private static final short[] f8908bh = {257, 4, 284, 3, 266, 4, 262, 3, 257, 4, 264, 7, 266, 4, 261, 3, 257, 4, 284, 3, 266, 4, 257, 4, 264, 7, 266, 4, 273, 3, 257, 4, 284, 3, 266, 4, 257, 4, 264, 3, 266, 4, 257, 4, 284, 7, 266, 4, 273, 3, 257, 4, 264, 7, 266, 4, 259, 3, 257, 4, 284, 3, 266, 4, 257, 4, 264, 7, 266, 4, 273, 3};

    /* JADX INFO: renamed from: ch */
    private static final short[] f8913ch = {256, 4, 3, 3, 1, 4, 7, 3, 256, 4, 3, 3, 1, 4, 9, 3, 256, 4, 3, 3, 1, 4, 64, 3};

    /* JADX INFO: renamed from: dh */
    private static final short[] f8918dh = {256, 4, 23, 3, 1, 4, 7, 3, 256, 4, 23, 3, 1, 4, 9, 3, 256, 4, 23, 3, 1, 4, 64, 3};

    /* JADX INFO: renamed from: eh */
    private static final short[] f8923eh = {256, 4, 23, 3, 1, 4, 7, 3, 256, 4, 23, 3, 1, 4, 9, 3, 256, 4, 23, 3, 1, 4, 49, 3};

    /* JADX INFO: renamed from: fh */
    private static final short[] f8928fh = {256, 4, 3, 3, 119, 4, 7, 3, 256, 4, 3, 3, 119, 4, 9, 3, 256, 4, 3, 3, 119, 4, 64, 3};

    /* JADX INFO: renamed from: gh */
    private static final short[] f8933gh = {256, 4, 3, 3, 1, 4, 7, 3, 256, 4, 3, 3, 1, 4, 9, 3, 256, 4, 3, 3, 1, 4, 64, 3};

    /* JADX INFO: renamed from: hh */
    private static final short[] f8938hh = {59, 4, 23, 4, 26, 1, 8, 1, 59, 4, 23, 4, 26, 1, 3, 1, 59, 4, 23, 4, 26, 1, 15, 1, 59, 4, 23, 4, 26, 1, 21, 1, 59, 4, 23, 4, 26, 1, 20739, 1};

    /* JADX INFO: renamed from: ih */
    private static final short[] f8943ih = {59, 4, 23, 4, 26, 1, 8, 1, 59, 4, 23, 4, 26, 1, 3, 1, 59, 4, 23, 4, 26, 1, 15, 1, 59, 4, 23, 4, 26, 1, 21, 1};

    /* JADX INFO: renamed from: jh */
    private static final short[] f8947jh = {256, 0, 3, 0, 23, 0, 49, 0, 3, 0, 23, 0, 49, 0, 51, 0, 256, 0, 3, 0, 23, 0, 49, 0, 3, 0, 23, 0, 49, 0, 7, 0, 0, 0, 35, 0};

    /* JADX INFO: renamed from: kh */
    private static final short[] f8951kh = {257, 0, 284, 0, 266, 0, 257, 0, 284, 0, 266, 0, 257, 0, 284, 0, 266, 0, 257, 0, 284, 0, 266, 0, 257, 0, 284, 0, 266, 0, 262, 0, 0, 0, 35, 0};

    /* JADX INFO: renamed from: lh */
    private static final short[] f8955lh = {1, 0, 257, 0, 513, 0, 1025, 0};

    /* JADX INFO: renamed from: mh */
    private static final short[] f8959mh = {256, 0, 3, 0, 1, 0, 256, 0, 3, 0, 1, 0, 256, 0, 3, 0, 256, 0, 3, 0, 1, 0, 256, 0, 3, 0, 1, 0, 256, 0, 3, 0, 0, 0, 35, 0, 4240, 0};

    /* JADX INFO: renamed from: nh */
    private static final short[] f8963nh = {256, 0, 3, 0, 23, 0, 0, 0, 3, 0, 23, 0, 256, 0, 0, 0, 7, 0, 3, 0, 23, 0, 0, 0, 256, 0, 3, 0, 23, 0, 0, 0, 0, 0};

    /* JADX INFO: renamed from: oh */
    private static final short[] f8967oh = {256, 0, 3, 0, 118, 0, 256, 0, 3, 0, 118, 0, 256, 0, 3, 0, 118, 0, 256, 0, 3, 0, 118, 0, 256, 0, 3, 0, 118, 0, 256, 0};

    /* JADX INFO: renamed from: ph */
    private static final short[] f8971ph = {256, 0, 3, 0, 0, 0, 256, 0, 3, 0, 0, 0, 256, 0, 3, 0, 0, 0, 256, 0, 3, 0, 0, 0, 256, 0, 3, 0, 0, 0, 256, 0};

    /* JADX INFO: renamed from: qh */
    private static final short[] f8975qh = {59, 0, 5, 0, 9010, 0, 9015, 0, 59, 0, 5, 0, 21, 0, 9015, 0};

    /* JADX INFO: renamed from: rh */
    private static final short[] f8979rh = {9, 1, 4, 1, 9, 1, 4, 1, 10, 1};

    /* JADX INFO: renamed from: sh */
    private static final short[] f8983sh = {9, 4, 5, 3, 4, 4, 10, 3, 9, 4, 12, 7, 4, 4, 11, 3, 9, 4, 5, 3, 4, 4, 6, 3, 9, 4, 12, 7, 4, 4, 10, 3};

    /* JADX INFO: renamed from: th */
    private static final short[] f8987th = {9, 0, 4, 0, 9, 0, 4, 0, 9, 0, 4, 0, 9, 0, 4, 0, 9, 0, 4, 0, 9, 0, 4, 0, 9, 0, 4, 0, 9, 0, 4, 0, 91, 0, 102, 0};

    /* JADX INFO: renamed from: uh */
    private static final short[] f8991uh = {48, 1, 52, 1, 48, 1, 52, 1, 48, 1, 52, 1, 48, 1, 52, 1, 48, 1, 60, 1};

    /* JADX INFO: renamed from: vh */
    private static final short[] f8996vh = {48, 4, 96, 3, 52, 4, 60, 3, 48, 4, 83, 7, 52, 4, 51, 3};

    /* JADX INFO: renamed from: wh */
    private static final short[] f9001wh = {48, 1, 52, 1, 61, 1, 48, 1, 52, 1, 61, 1, 48, 1, 52, 1, 61, 1, 51, 1};

    /* JADX INFO: renamed from: xh */
    private static final short[] f9006xh = {48, 1, 128, 1, 48, 1, 128, 1, 48, 1, 128, 1, 48, 1, 128, 1, 48, 1, 85, 1};

    /* JADX INFO: renamed from: yh */
    private static final short[] f9011yh = {48, 4, 68, 3, 59, 4, 85, 3, 48, 4, 121, 7, 59, 4, 130, 3, 48, 4, 68, 7, 59, 4, 129, 3, 48, 4, 121, 3, 59, 4, 51, 3, 48, 4, 68, 7, 59, 4, 130, 3, 48, 4, 121, 7, 59, 4, 129, 3};

    /* JADX INFO: renamed from: zh */
    private static final short[] f9016zh = {48, 1, 59, 1, 68, 1, 48, 1, 59, 1, 68, 1, 48, 1, 59, 1, 68, 1, 85, 1};

    /* JADX INFO: renamed from: Ah */
    private static final short[] f8774Ah = {4364, 1, 4360, 1, 4364, 1, 4360, 1, 4364, 1, 4360, 1, 4364, 1, 4368, 1};

    /* JADX INFO: renamed from: Bh */
    private static final short[] f8779Bh = {4364, 4, 4362, 3, 4356, 4, 4357, 3, 4368, 3, 4364, 4, 4627, 3, 4356, 4, 4424, 3, 4375, 3, 4364, 4, 4376, 3, 4356, 4, 4377, 3, 4428, 3, 4364, 4, 4627, 3, 4356, 4, 4400, 3, 4427, 3, 4364, 4, 4375, 3, 4356, 4, 4376, 3, 4353, 3, 4364, 4, 4627, 3, 4356, 4, 4374, 3, 4428, 3, 4364, 4, 4375, 3, 4356, 4, 4376, 3, 4355, 3, 4364, 4, 4627, 3, 4356, 4, 4425, 3, 4486, 3, 4364, 4, 4374, 3, 4356, 4, 4400, 3, 4428, 3, 4364, 4, 4627, 3, 4356, 4, 4369, 3, 4360, 3};

    /* JADX INFO: renamed from: Ch */
    private static final short[] f8784Ch = {4364, 1, 4356, 1, 4627, 1, 4364, 1, 4356, 1, 4627, 1, 4364, 1, 4368, 1};

    /* JADX INFO: renamed from: Dh */
    private static final short[] f8789Dh = {-23296, -24576, -24560, 0, 259};

    /* JADX INFO: renamed from: Eh */
    private static final short[] f8794Eh = {257, 262, 265, 288, 0, 289};

    /* JADX INFO: renamed from: Fh */
    private static final int[] f8799Fh = {3145736, 38994, 3145737, 38995, 3145744, 38996, 3145745, 38997, 3145746, 38998, 3145747, 38999, 3145748, 39000, 3145749, 39001, 3145750, 39008, 3145751, 39009, 3145752, 39010, 3145753, 39011, 3145814, 39048, 3145815, 39049, 3145816, 39056, 3145817, 39057, 3145824, 39058, 3145825, 39059, 3146050, 39060, 3146051, 39061, 3146052, 39062, 3146053, 39063, 3146054, 39064, 3146055, 39065, 3211529, 65649, 3211536, 65650, 3211537, 65651, 3211538, 65652, 3211539, 65653, 3211540, 65654, 3211541, 65655, 3211542, 65656, 3211543, 65657, 3211544, 65664, 3211545, 65665, 3211552, 65666, 3211553, 65667, 3211554, 65668, 3211555, 65669, 3211556, 65670, 3211557, 65671, 3211569, 65684, 3211570, 65685, 3211571, 65686, 3211609, 65815, 3211616, 65816, 3211617, 65817, 3211618, 65824, 3211619, 65825, 3211622, 65828, 3211623, 65829, 3211624, 65830, 3211625, 65831, 3211632, 65832, 3211633, 65833, 3211602, 65840, 3211603, 65841, 3211856, 65872, 3211858, 65874, 3211859, 65875, 3211860, 65876, 3211861, 65877, 3211862, 65878, 3211863, 65879, 3211864, 65880, 3211865, 65881, 3211872, 65888, 3211873, 65889, 3211874, 65890, 3211875, 65891, 3211876, 65896, 3211877, 65897, 3211878, 65904, 3211879, 65905, 3211880, 65906, 3211881, 65907, 3211888, 65908, 3211889, 65909, 3211890, 65910, 3211891, 65911, 3211892, 65912, 3211893, 65913, 3211894, 65920, 3211895, 65921, 4260134, 65672, 4260135, 65673, 4260136, 65680, 4260137, 65681, 4260198, 65892, 4260199, 65894, 4260200, 65895, 4260201, 65893, 132626, 24583, 135429, 24593, 135443, 24594, 1643010, 24598, 197121, 24608, 1181187, 24615, 198930, 24624, 1116419, 24627, 1507844, 24628, 2101507, 24835, 1245444, 24837};

    /* JADX INFO: renamed from: Gh */
    private static final String[] f8804Gh = {"Boot7SM 50Mz r02", "Boot7SM 64Mz r02", "", "", "Boot5DM r03     ", "", "", ""};

    /* JADX INFO: renamed from: Hh */
    private static final int[] f8809Hh = {7680256, 7680768, 0, 0, 5522432, 0, 0, 0};

    /* JADX INFO: renamed from: Ih */
    private static final int[] f8814Ih = {0, 65797, 65799, 197379, 66054, 0, 0, 131843, 262401, 262913, 0, 100860163};

    /* JADX INFO: renamed from: Jh */
    private static final byte[] f8819Jh = {68, 85, 67, 32, 32, 32, 32, 32, 32, 32};

    /* JADX INFO: renamed from: Kh */
    private static final String[] f8824Kh = {"2214DT56", "2214B14DT56", "2216DT72", "2218DI83", "2218DS24", "2218DS26", "2218DT80", "2218PI82", "2218PT70", "2219DS32", "2219DS33", "2219DS34", "2219PI96", "2219PI97", "2219PT80", "2216B16DI82", "2218B18DT81", "321818PU015", "321818PU016", "321818PU017", "321818PUA05", "321818PUB03", "3218SUA5", "22AELM26", "22AELM33", "22AELM35", "22AESMA2", "22ADADPSMA1", "22ADBADLM01", "22ADBADLM02", "22ADBADLM03", "22ADBADLM10", "22ADBADLM12", "22ADBADLM14", "22ADBADSMB1", "32A0A0PD003", "32A0A0PD004", "32A0A0PDA05", "32A0A0PDB05", "96519508B", "32A0A0PC030", "32A0A0PC031", "32A0A0PC032", "32A0A0PC033", "32A0A0PC21W", "32A0BA0SCA1", "32A0BA0SCA2", "32A0BA0SCB2", "2218DD07", "2218DD08", "2218DD10", "2218DQ07", "2218DQ11", "2218DQ12", "2218DQ13", "2218DR11", "2218DR20", "2219DD07", "2219DQ07", "2219DQ08", "2219DQ09", "2219DQ11", "2219DQ12", "2219DR11", "2219DR20", "2219PQ14", "221999SDQDP", "22BFBBFLO08", "22BFBBFLO11", "22BFBFPO005", "22BFBFPOA04", "22BFBBFSOA2", "22BF2STKR14", "22371SSK627", "2237BA7LN11", "2237BA7LN14", "2237BA7LN20", "2237BA7LN22", "2237BA7LN30", "2237BA7LN32", "2237BA7LN34", "2237BA7LN36", "2237BA7LN41", "22A7LN36", "22A7LN37", "22A7LN38", "22A7LN39", "22A7LN40", "2237B37SN01", "223737SNB04", "223737PN115", "2237SNA1", "223737PNA2", "2237B37SNB5", "2237B37SNPZ", "22C0BCOSOB1", "22C3BC3SOB1", "321414PS021", "321414PS022", "321414PS023", "321414PW021", "321414PW022", "321414PW024", "321515PS28E", "3215PS28F", "321515PS28U", "3215LS29", "3215LS30", "3215LW28", "3215LW30", "3215LW31", "3215SWA5", "321515PSB2E", "321515PSA02", "321515PWA02", "321515PW28E", "321515PW28U", "32A0A0PSA05", "32A0A0PS034", "32A0A0PSB02", "3213STA5", "3213B13SQBB", "3213B13PQ65", "3213B13PT64", "3213PQ58", "3213PT58", "3213PT62", "3213SQA3", "3215PQ58", "3215PQ64", "3215PQ65", "3215PQ67", "3215___PQ67", "3215SQA3", "3215SQB5", "3220MA14", "3220B20MA14", "3220MA15", "3220TAA3", "3220TAB5", "3215PT58", "22BFBFPOA03", "22C3SYB1", "22A9A9PH023", "22A9ACPH024", "22AABA9SHA4", "22AABA9SHB4", "22ABAABSHC4", "22ABBABSHA5", "22ABABSHB6B", "22ABLH01", "22ABLH02", "22ABLH06", "22ABBABLH01", "22ABBABLH06", "2219EE04", "2218PG18", "2218B18DG18", "2219DG18", "2219PG20", "2235LI01", "2235PI01", "2235SI01", "2219B19PZ0P", "2219DZ13", "2219PZ10", "2235LG01", "2218B18DZ12", "2235B35LGPH", "2216PN11", "2218DN09", "2219DN09", "2218DM31", "2218PM28", "2229B2DFP4", "2229B2DFP5", "2235B35LB01", "2235LB01", "2235LB02", "2233SB01", "2232B32LEPA", "2235B35LEPI", "2235B35LEPJ", "2216DO08", "2218PO14", "2219DO14", "2234SE01", "2235LE01", "2235LE02", "2235SE01", "2235B35SE01", "2235B35SEPK", "2219ER22", "2219ER28", "2219B19ER28", "2218DU94", "2218DU95", "2218DU96", "2219DU94", "2219DU96", "2219DU97", "2219DU98", "2219PU00", "2219PU98", "2235LL04", "2235LL05", "2235LL06", "2235SL02", "2235B35LLPQ", "2219SA02", "2229B29DAP5", "2229B29DAP6", "2235LF01", "2235LF02", "2235SF01", "2235B35LFPQ", "2235B35LFPW", "2235B35LFPY", "2214EDPR", "2214EDUK", "2216ED04", "2216ED06", "2218ED04", "2218ED08", "2218PD08", "2235SC01", "2235SD01", "2232B32LCPV", "2232B32LDPY", "2232B32LDPS", "2216EA11", "2218EA11", "2218EA12", "2218PA13", "2218PB13", "2219EB14", "2229BLG9427", "2229BRV1249", "2229BRV8V08", "2229BRV8V15", "2229BRV8205", "2229BRVSP05", "2229GRS8529", "2229GRS1102", "2229GRS1103", "2229GRS4V34", "2229GRS8V68", "2229NGR1207", "2229STA42Z", "2229STA42ZA", "2229STV52K", "2229STVAD42", "2230ST01", "2230BA20", "2230BB10", "2230BD01", "2230BG27", "2230GRJ1", "2230G803", "2230GS08", "2230NG17", "2230NG18", "3221NRG136", "3221NRG142", "3222ST02", "32230BA20", "2333MOL1249", "2333MORSK19", "2337MOR95OL", "23ABMOLSK22", "23ACMOL49C", "23ACMOL49D", "23ACMOLK22C", "23ACMOLK22D", "23ACMOR95C", "23ACMORCAVE", "23ACMORCAVF", "23ACMORCAVG", "23ACMORCORA", "23ACMORSPTA", "23ECCLGPSMB", "23ECCLGPSMC", "23ECCLGPSMD", "23ECMOLCORB", "23ECMOLCORC", "23EDMORSPTC", "23ECOLGPSMQ", "v1.4LAFURBA", "V1.0FURBAR", "MX20GIUSTA", "MPX2.1GIUSTADC", "v2.3GIUSTA", "v2.1LAPAZZA", "v1.3LAFURBA", "2.1SCLAPAZZA", "3219MOCO38F", "2249GA33", "2253GA37", "225AGA40", "225AGA41", "2253AL37", "22FM2A37", "3223GA48", "4225GAA2", "VD5G622", "VC5L981", "VD5L980", "RSV4", "4021AA04", "4023AC02", "4023AE01", "103BAE09", "1237AA12", "1338AA13", "1338AC13", "1338AD13", "1338AE13", "1338AF13", "1338AG13", "13A8AD23ST", "13A9AA23", "13A9AA24", "13A9AB23", "13A9AD23", "13A9AE23", "13A9AF23", "13A9AG23", "6403BA45", "6404BA51", "6404BB51", "6404BD51", "6404C3BD51", "7613HA08", "7613HB12", "7614HD15", "7614HD15ST", "7614HA16", "7614HB16", "7617HM26", "7617HM27", "7617HN27", "7617HO28", "7617HO28A7", "1037AH01", "1037AL01", "1037C1AH64", "1237AH03", "1338AH04", "1338AI04", "1338AL04", "1338AM04", "13A9AH14", "13A9AI14", "13A9AM14", "6401DA44", "6401DA48", "6401DD48", "6404DA51", "6404DB51", "6404DD51", "7613LA13", "7613LB12", "7614LA17", "7614LB17", "7614LD17", "7614LA20", "7614LA20A1", "7614LB20", "7614LD20", "013299", "0134A0", "0134A1", "0134A2", "0132D3", "0134D5", "0134D6", "0134D7", "7616BE17", "7616BG18", "7616BH18", "7616BF17", "7616BD18", "1050FA32", "1050FA35", "1050FD35", "1050FE35", "1050FG37", "1050FH37", "1050FI37", "1034EA84A", "P1034C4_77", "P1034C4_78A", "S34EB783", "1036EA84R", "1338EA07", "1338EC09"};

    /* JADX INFO: renamed from: Lh */
    private static final String[] f8829Lh = {"v2.1LA", "v2.1LAPAZZA", "MPX2GIUSTAD", "MPX2.1GIUSTADC", "2.1SLA", "2.1SCLAPAZZA"};

    /* JADX INFO: renamed from: Mh */
    private static final int[] f8834Mh = {118768694, 118768706, 118899762, 119032195, 119034660, 119034662, 119035008, 119032194, 119034992, 119100210, 119100211, 119100212, 119097750, 119097751, 119690368, 119687554, 119690369, 135790613, 135790614, 135790615, 135807237, 135807491, 135811845, 136445990, 136446003, 136446005, 136462594, 136462593, 136463361, 136463362, 136463363, 136463376, 136463378, 136463380, 136463426, 137511939, 137511940, 137511941, 137511685, 144086280, 137511728, 137511729, 137511730, 137511731, 137511713, 137511169, 137511170, 137511426, 152585223, 152585224, 152585232, 152588551, 152588561, 152588562, 152588563, 152588817, 152588832, 152650759, 152654087, 152654088, 152654089, 152654097, 152654098, 152654353, 152654368, 152653844, 152654672, 270663688, 270663697, 270683909, 270680324, 270664450, 270664212, 270665255, 270665489, 270665504, 270665504, 270665506, 270665520, 270665522, 270665524, 270665534, 270665537, 270665526, 270665527, 270665528, 270665529, 270665536, 270677761, 270677764, 270677781, 270677825, 270677826, 270677765, 270677815, 270684993, 270684994, 271717409, 271717410, 271717411, 271734561, 271734562, 271734564, 271717765, 271717766, 271717781, 271717673, 271717680, 271717928, 271717936, 271717937, 271717953, 271717698, 271733506, 271734530, 271734568, 271734613, 271728901, 271728948, 271728898, 286474501, 286474757, 286478597, 286479364, 286478600, 286479624, 286479634, 286478659, 286609672, 286609684, 286609685, 286609687, 286609703, 286609731, 286609733, 287326228, 287326484, 287326485, 287326467, 287326469, 287396872, 287458819, 287490817, 287443235, 287443236, 287443265, 287443266, 287457859, 287457797, 287457798, 287449089, 287449090, 287449094, 287459073, 287459078, 69354756, 102912024, 102908440, 102908952, 102912032, 119673345, 119676929, 119677697, 135879248, 135879187, 135879184, 137709313, 135813650, 137709384, 270669329, 270669833, 270670089, 270669873, 270669864, 270681092, 270681093, 271925761, 271925761, 271925762, 271794689, 153236033, 153236809, 153236810, 153228808, 153229332, 153229588, 153236481, 153240833, 153240834, 153236737, 153236819, 153236811, 102322722, 102322728, 102322728, 270669972, 270669973, 270669974, 270670228, 270670230, 270670231, 270670231, 270684160, 270684312, 287454468, 287454469, 287454469, 287454466, 287454545, 270670082, 270674181, 270674182, 271928321, 271928322, 271926785, 271929425, 271929431, 271929433, 269763923, 269763925, 269894660, 269894662, 270025988, 270025992, 270028808, 271926017, 271926273, 271729494, 271729753, 271729748, 269894929, 270026001, 270026002, 270024979, 270025235, 270091540, 692229159, 692195913, 692193288, 692193301, 692209669, 692211717, 692553001, 692523266, 692523267, 692519988, 692521064, 692982279, 693322304, 693322305, 693326411, 693322818, 810767361, 809648416, 809648656, 809649153, 809649959, 809980417, 809961475, 810439432, 810436375, 810436376, 827195702, 827148098, 844321794, 843202848, 590549577, 590564121, 590827340, 591481634, 591481155, 591481156, 591471171, 591471172, 591500611, 591479109, 591479110, 591479111, 591483457, 591483472, 591744322, 591744323, 591744324, 591745602, 591745603, 591745091, 592399441, 340153682, 273044818, 541542741, 558319957, 591874389, 558907738, 324026714, 559108161, 840500111, 136464691, 136464695, 136469056, 136469057, 136462647, 136456759, 136464200, 136660898, 121043020, 121043021, 121043021, 1381193268, 1075921156, 1076052738, 1076053249, 272319753, 305611026, 322455315, 322455315, 322455315, 322455315, 322455315, 322455315, 329794595, 329860643, 329860643, 329860643, 329860643, 329860643, 329860643, 329860643, 1677935173, 1678000705, 1678000705, 1678000705, 1678033745, 1980973320, 1980973320, 1981038870, 1981038870, 1981038870, 1981038870, 1981237286, 1981237286, 1981237286, 1981237286, 1981237286, 272058369, 272058369, 272058468, 305612803, 322455556, 322455556, 322455556, 322455556, 329861140, 329861140, 329861140, 1678001220, 1678001220, 1678001220, 1678001233, 1678001233, 1678001233, 1980976146, 1980976146, 1981041687, 1981041687, 1981041687, 1981041687, 1981041687, 1981041687, 1981041687, 20071427, 20201728, 20201728, 20201728, 20071427, 20201728, 20201728, 20201728, 1984055064, 1984055064, 1984055064, 1984055064, 1984055064, 273695797, 273695797, 273695797, 273695797, 273695797, 273695797, 273695797, 271877185, 271893623, 271877185, 271877185, 272008274, 322497545, 322497545};

    /* JADX INFO: renamed from: Nh */
    private static final int[] f8839Nh = {88485211, 88481342, 88482685, 88513355, 88498614, 88489865, 88489466, 88489094, 88489094, 88489094, 88496654, 88525219, 88534067, 88479953, 88533423, 88474186, 88533651, 88533554, 88473929, 87598888, 87558526, 87557832, 87560827, 87556096, 87572366, 87562019, 87617193, 87556096, 87562947, 87618664, 87438114, 87438322, 87440718, 87431647, 87489292, 97674592, 97674623, 97669250, 97702176, 97690813, 97690105, 97690779, 97652565, 97685284, 97684715, 97691559, 86728247, 86733556, 86704128, 86728282, 86727678, 86732558, 89399160, 89393577, 89452598, 89449145, 89416835, 89450069, 89433935, 89446603, 89428321, 73805665, 73807869, 73842379, 73842650, 73806069, 73808233, 73842748, 73843014, 74995618, 74990267, 74987926, 74407389, 74401958, 83386492, 83389328, 94929776, 94922680, 94913569, 94913233, 94913529, 83755039, 83810303, 83756647, 83820059, 83808277, 83789171, 83787449};

    /* JADX INFO: renamed from: Oh */
    private static final int[] f8844Oh = {110404, 110404, 110404, 110404, 110914, 110404, 110404, 110404, 110404, 110404, 110404, 110404, 110404, 110404, 110404, 110404, 110404, 110404, 110404, 241338, 241338, 241338, 241338, 241338, 241338, 241338, 241338, 241338, 241338, 241338, 241338, 241338, 241338, 241338, 241338, 110914, 110914, 110914, 110914, 110404, 110404, 110404, 110404, 110404, 110404, 110404, 241338, 241338, 241338, 241338, 241338, 241338, 241338, 241338, 241338, 241338, 241338, 241338, 241338, 241338, 241338, 307221, 307221, 307221, 307221, 307221, 307221, 307221, 307221, 241338, 241338, 241338, 241338, 241338, 110404, 110404, 110404, 110404, 110404, 110404, 110404, 65536, 65536, 65536, 65536, 65536, 65536, 65536};

    /* JADX INFO: renamed from: Ph */
    private static final int[] f8849Ph = {262144, 262144, 262144, 262144, 262144, 262144, 262144, 262144, 262144, 262144, 262144, 263164, 262144, 262144, 262144, 262144, 262144, 262144, 262144, 327680, 327680, 327680, 327680, 2132, 327680, 327680, 327680, 327680, 327680, 327680, 327680, 327680, 327680, 327680, 328700, 327680, 327680, 328700, 327680, 327680, 327680, 327680, 327680, 327680, 327680, 327680, 131072, 131072, 131072, 131072, 131072, 131072, 131072, 131072, 131072, 131072, 131072, 131072, 328700, 131072, 131072, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 204047, 0, 0, 0, 0, 132092, 132092, 132092, 132092, 132092, 132092, 132092};

    /* JADX INFO: renamed from: Qh */
    private static final short[] f8854Qh = {2084, 2114, 1064};

    /* JADX INFO: renamed from: Rh */
    private static final byte[] f8859Rh = {-67, -61, -125, -42, 122, -49, 49, -32, -42, -92, -47, 97, 11, 22, 4, 96, 55, -91, 98, 43, 25, -9, -40, -73};

    /* JADX INFO: renamed from: Sh */
    private static final byte[] f8864Sh = {2, 24, -30, 49, 2};

    /* JADX INFO: renamed from: Th */
    private static final byte[] f8869Th = {9, 0, 0, 0, 0, 0, 1, 25};

    /* JADX INFO: renamed from: Uh */
    private static final byte[] f8874Uh = {4, 0};

    /* JADX INFO: renamed from: Vh */
    private static final byte[] f8879Vh = {4, 16};

    /* JADX INFO: renamed from: Wh */
    private static final byte[] f8884Wh = {58, 63, 0};

    /* JADX INFO: renamed from: Xh */
    private static final byte[] f8889Xh = {58, 82, 48, 48, 48, 50, 48, 56, 48, 48, 51, 67, 0};

    /* JADX INFO: renamed from: Yh */
    private static final byte[] f8894Yh = {58, 86, 48, 48, 48, 48, 48, 48, 48, 48, 48, 56, 0};

    /* JADX INFO: renamed from: Zh */
    private static final byte[] f8899Zh = {58, 82, 48, 48, 70, 70, 69, 67, 48, 56, 48, 50, 0};

    /* JADX INFO: renamed from: ai */
    private static final byte[] f8904ai = {58, 82, 48, 48, 48, 48, 48, 48, 48, 48, 50, 48, 0};

    /* JADX INFO: renamed from: bi */
    private static final byte[] f8909bi = {58, 82, 48, 48, 48, 50, 48, 48, 48, 48, 49, 56, 0};

    /* JADX INFO: renamed from: ci */
    private static final byte[] f8914ci = {58, 87, 48, 48, 48, 50, 48, 48, 48, 48, 48, 49, 48, 48, 0};

    /* JADX INFO: renamed from: di */
    private static final byte[] f8919di = {58, 84, 48, 48, 48, 48, 48, 48, 48, 48, 48, 56, 0};

    /* JADX INFO: renamed from: ei */
    private static final byte[] f8924ei = {58, 82, 48, 48, 48, 50, 48, 56, 48, 48, 48, 56, 0};

    /* JADX INFO: renamed from: fi */
    private static final byte[] f8929fi = {58, 87, 48, 48, 48, 50, 48, 56, 48, 48, 48, 56, 50, 54, 68, 48, 56, 67, 56, 67, 56, 67, 56, 67, 56, 49, 48, 48, 0};

    /* JADX INFO: renamed from: gi */
    private static final byte[] f8934gi = {58, 87, 48, 48, 48, 50, 48, 56, 48, 48, 50, 54, 48, 48, 70, 70, 56, 48, 56, 48, 56, 48, 56, 48, 56, 49, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 0};

    /* JADX INFO: renamed from: hi */
    private static final int[] f8939hi = {122, 123, 0, 0, 105, 0, 118, 119, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 562, 563, 1203, 0, 0, 0, 0, 0, 1201, 1202, 1352, 1353, 0, 0, 1231, 1232, 0, 1351, 1502, 1552, 1553, 1601, 0, 0, 0, 1501, 0, 0, 0, 0, 1602, 0, 0, 0};

    public ActivityC2307z(Activity activity, ActivityC2266vc activityC2266vc, StatusBar statusBar, ActivityC1960a0 activityC1960a0) {
        f8785Dd = MainActivity.f6988P5;
        f8783Cg = (MainActivity) activity;
        f8778Bg = activityC2266vc;
        f8793Eg = statusBar;
        f8788Dg = activityC1960a0;
    }

    /* JADX INFO: renamed from: Ac */
    private static void m9082Ac(byte[] bArr) {
        EnumC2294y enumC2294y;
        byte b2;
        if ((bArr.length < 6) || (f8992vd == EnumC2294y.MODE_NULL)) {
            return;
        }
        byte[] bArrM9218mc = m9218mc(bArr);
        byte b3 = bArrM9218mc[5];
        if (b3 == 80) {
            f8847Pf = false;
            f8835Nd = (byte) 1;
            enumC2294y = EnumC2294y.MODE_SEED;
        } else {
            if (b3 != 98) {
                if (b3 == 103) {
                    if (bArrM9218mc[6] == 1 && bArrM9218mc[4] == 6) {
                        f8812If = true;
                        f8817Jf = false;
                        MainActivity.f7243r9 = false;
                        MainActivity.f7295x9 = false;
                        f8801Ge = 0;
                        int i = 0;
                        for (int i2 = 0; i2 < 4; i2++) {
                            i |= (bArrM9218mc[i2 + 7] & 255) << (i2 * 8);
                        }
                        f8776Be[0] = i;
                        b2 = 49;
                    } else {
                        if (bArrM9218mc[6] != 2) {
                            return;
                        }
                        LedBar.m8097j(2);
                        b2 = 48;
                    }
                    f8840Od = b2;
                    m9170Wd(b2);
                    return;
                }
                if (b3 != 110) {
                    if (b3 == 126) {
                        if (MainActivity.f7243r9 && (f8992vd == EnumC2294y.MODE_INSTR_WRITE)) {
                            MainActivity.f7243r9 = false;
                            MainActivity.f7295x9 = false;
                            m9086Bd();
                            return;
                        }
                        return;
                    }
                    if (b3 != 127 || bArrM9218mc[6] != 39) {
                        return;
                    }
                    f8783Cg.m8734K9(null, null, MainActivity.f7299y4.getResources().getStringArray(R.array.eMessage)[5], 0, 12, 1, 0);
                    MainActivity.f6939Ja = 1;
                } else {
                    if (bArrM9218mc[7] == 16) {
                        m9246vd();
                        return;
                    }
                    if (f8992vd == EnumC2294y.MODE_INTERVAL_WRITE) {
                        f8783Cg.m8756b5(7, 0);
                    } else if (f8992vd == EnumC2294y.MODE_INSTR_WRITE) {
                        MainActivity.f6957La = 0;
                        f8783Cg.m8756b5(6, 0);
                    }
                    MainActivity.f6939Ja = MainActivity.f6930Ia;
                }
                f8783Cg.m8805y8(false);
                return;
            }
            if (bArrM9218mc[6] == -15) {
                byte b4 = bArrM9218mc[7];
                if (b4 != -120) {
                    if (b4 != -116) {
                        return;
                    }
                    int i3 = 3;
                    for (int i4 = 1; i4 < 4; i4++) {
                        i3 |= (bArrM9218mc[i4 + 7] & 255) << (i4 * 8);
                    }
                    f8776Be[1] = i3;
                    int i5 = 0;
                    for (int i6 = 0; i6 < 4; i6++) {
                        i5 |= (bArrM9218mc[i6 + 11] & 255) << (i6 * 8);
                    }
                    f8776Be[2] = i5;
                    int i7 = 16777216;
                    for (int i8 = 0; i8 < 3; i8++) {
                        i7 |= (bArrM9218mc[i8 + 15] & 255) << (i8 * 8);
                    }
                    f8776Be[3] = i7;
                    m9258zd(m9136Ob());
                    return;
                }
                if (bArrM9218mc.length > 11) {
                    MainActivity.m8169Ab(25, String.format("%02x", Byte.valueOf(bArrM9218mc[8])).concat(".").concat(String.format("%02x", Byte.valueOf(bArrM9218mc[9])).concat(".").concat(String.format("%02x", Byte.valueOf(bArrM9218mc[11])))));
                }
                enumC2294y = EnumC2294y.MODE_INSTR_READ;
            } else {
                if (MainActivity.f7243r9) {
                    m9135Ne(EnumC2294y.MODE_INTERVAL_READ);
                    f8801Ge = 1;
                    MainActivity.f7243r9 = false;
                    return;
                }
                if (MainActivity.f7295x9) {
                    m9083Ad();
                    MainActivity.f7295x9 = false;
                    return;
                }
                byte b5 = bArrM9218mc[6];
                if (b5 != -96) {
                    if (b5 != -91) {
                        if (b5 != 1) {
                            return;
                        }
                        if (bArr[7] == 3) {
                            MainActivity.f7032U4 = bArr[8] == 1;
                        }
                        f8783Cg.m8764da(1, new boolean[]{MainActivity.f7032U4});
                        return;
                    }
                    f8948ke = 1;
                    m9246vd();
                    int i9 = f8801Ge;
                    if (i9 > 0) {
                        f8801Ge = i9 + 1;
                        return;
                    }
                    byte[] bArr2 = new byte[3];
                    System.arraycopy(bArrM9218mc, 8, bArr2, 0, 3);
                    System.arraycopy(bArrM9218mc, 8, MainActivity.f7120dc, 0, 3);
                    f8783Cg.m8773i7(bArr2, 3);
                    return;
                }
                if (f8801Ge != 2) {
                    if (bArrM9218mc[7] != 0) {
                        m9246vd();
                        byte[] bArr3 = new byte[3];
                        System.arraycopy(bArrM9218mc, 8, bArr3, 0, 3);
                        System.arraycopy(bArrM9218mc, 8, MainActivity.f7120dc, 3, 3);
                        f8783Cg.m8773i7(bArr3, 1);
                        return;
                    }
                    f8948ke = 2;
                    m9246vd();
                    int length = bArrM9218mc.length - 8;
                    byte[] bArr4 = new byte[length];
                    f9015zg = length == 12;
                    System.arraycopy(bArrM9218mc, 8, bArr4, 0, length);
                    f8783Cg.m8773i7(bArr4, 0);
                    return;
                }
                enumC2294y = EnumC2294y.MODE_INTERVAL_WRITE;
            }
        }
        m9135Ne(enumC2294y);
    }

    /* JADX INFO: renamed from: Ad */
    private static void m9083Ad() {
        f8828Lg = Boolean.TRUE;
        f8818Jg = 5;
        int[] iArr = MainActivity.f7102bc;
        m9177Yc(new byte[]{16, 9, 46, -96, 16, (byte) iArr[2], (byte) iArr[1], (byte) iArr[0]}, (byte) 0);
    }

    /* JADX INFO: renamed from: Ae */
    public static void m9084Ae(String str) {
        if (str == null || str.equals("")) {
            str = " ";
        }
        String strSubstring = str.substring(0, 1);
        f8777Bf = strSubstring.equals("P");
        f8797Ff = strSubstring.equals("F");
        f8802Gf = strSubstring.equals("E");
        f8969pf = strSubstring.equals("D");
        f8973qf = strSubstring.equals("C");
        f8901af = strSubstring.equals("J");
        f8977rf = strSubstring.equals("B");
        f8999wf = strSubstring.equals("A");
        f8985tf = strSubstring.equals("8");
        f8994vf = strSubstring.equals("7");
        f8989uf = strSubstring.equals("6");
        f8981sf = strSubstring.equals("5");
        f8871Ue = strSubstring.equals("4");
        f8965of = strSubstring.equals("3");
        f8822Kf = strSubstring.equals("2");
        f8961nf = strSubstring.equals("1");
        f8772Af = strSubstring.equals("0");
        f8807Hf = f8822Kf | f8977rf | f8969pf | f8973qf;
        f8827Lf = f8981sf | f8989uf | f8994vf | f8985tf | f8999wf | f8797Ff | f8802Gf;
        f8926ff = false;
        f8931gf = false;
    }

    /* JADX WARN: Code duplicated, block: B:199:0x02cb  */
    /* JADX WARN: Code duplicated, block: B:326:0x0590 A[PHI: r0
      0x0590: PHI (r0v15 android.widget.TextView) = (r0v14 android.widget.TextView), (r0v17 android.widget.TextView), (r0v19 android.widget.TextView) binds: [B:325:0x058e, B:322:0x0587, B:319:0x0580] A[DONT_GENERATE, DONT_INLINE]] */
    /* JADX WARN: Code duplicated, block: B:352:0x05ed  */
    /* JADX WARN: Code duplicated, block: B:78:0x012c  */
    /* JADX WARN: Multi-variable type inference failed */
    /* JADX WARN: Type inference fix 'apply assigned field type' failed
    java.lang.UnsupportedOperationException: ArgType.getObject(), call class: class jadx.core.dex.instructions.args.ArgType$UnknownArg
    	at jadx.core.dex.instructions.args.ArgType.getObject(ArgType.java:596)
    	at jadx.core.dex.attributes.nodes.ClassTypeVarsAttr.getTypeVarsMapFor(ClassTypeVarsAttr.java:35)
    	at jadx.core.dex.nodes.utils.TypeUtils.replaceClassGenerics(TypeUtils.java:177)
    	at jadx.core.dex.visitors.typeinference.FixTypesVisitor.insertExplicitUseCast(FixTypesVisitor.java:397)
    	at jadx.core.dex.visitors.typeinference.FixTypesVisitor.tryFieldTypeWithNewCasts(FixTypesVisitor.java:359)
    	at jadx.core.dex.visitors.typeinference.FixTypesVisitor.applyFieldType(FixTypesVisitor.java:309)
    	at jadx.core.dex.visitors.typeinference.FixTypesVisitor.visit(FixTypesVisitor.java:94)
     */
    /* JADX INFO: renamed from: Bc */
    private static void m9085Bc(byte[] bArr, int i, int i2) throws CloneNotSupportedException {
        EnumC2294y enumC2294y;
        TextView textView;
        byte b2;
        int i3;
        byte b3;
        EnumC2294y enumC2294y2;
        int i4 = i2;
        if (i4 <= 4 || !m9168Wb(bArr, i, i2)) {
            return;
        }
        int i5 = i + 3;
        byte b4 = bArr[i5];
        if (b4 != -32) {
            if (b4 == -31) {
                byte b5 = (byte) (MainActivity.f6928I8 == 0 ? 255 : 0);
                byte b6 = bArr[i + 4];
                if (b6 == -80) {
                    int i6 = bArr[i + 5] & 255;
                    if (!MainActivity.f6893E9) {
                        f8783Cg.m8736La();
                    } else if (i6 != MainActivity.f6928I8) {
                        MainActivity.f6928I8 = i6;
                    }
                } else if (b6 == 1) {
                    MainActivity.f6928I8 = (bArr[i + 5] & 255) == 0 ? 0 : 1;
                    f8946jg = false;
                    if (f8992vd != EnumC2294y.MODE_BLEEDING) {
                        m9135Ne(EnumC2294y.MODE_ABS_DTC);
                        return;
                    }
                    f8783Cg.m8768g5();
                }
                m9173Xc(b5);
                if (MainActivity.f7304y9) {
                    MainActivity.m8546jb(false);
                    return;
                }
                return;
            }
            if (b4 == -29) {
                MainActivity.f7277v9 = false;
                byte b7 = bArr[i + 5];
                if (b7 == 5) {
                    textView = f8783Cg.f7330C2;
                    if (textView != null) {
                        textView.setTag("1");
                    }
                } else if (b7 == 50) {
                    textView = f8783Cg.f7345F2;
                    if (textView != null) {
                        textView.setTag("1");
                    }
                } else if (b7 == 53) {
                    MainActivity.f7286w9 = true;
                    MainActivity.m8199D9(1500);
                } else if (b7 == 55 && (textView = f8783Cg.f7340E2) != null) {
                    textView.setTag("1");
                }
            } else if (b4 == 65) {
                if (bArr[i + 4] != 1) {
                    short[] sArr = f8873Ug;
                    if ((sArr != null) & (sArr == f8868Tg)) {
                        int i7 = 0;
                        while (true) {
                            short[] sArr2 = f8873Ug;
                            if (i7 >= sArr2.length / 2) {
                                break;
                            }
                            int i8 = i7 * 2;
                            boolean z = sArr2[i8] == f8798Fg;
                            int i9 = i8 + 1;
                            if (z & (sArr2[i9] < 4)) {
                                sArr2[i9] = 3;
                            }
                            i7++;
                        }
                    }
                    m9217le();
                    f8788Dg.m8890Cb(bArr, i5);
                    return;
                }
                f8956me = 0;
                short s = (short) (bArr[i + 5] & 255);
                f8803Gg = s;
                f8783Cg.m8788p8(s > 0, false);
                m9091Ce(f8803Gg & 127);
                if (f8803Gg > 0 && MainActivity.f6925I5) {
                    m9169Wc();
                    return;
                } else if (MainActivity.f6925I5) {
                    m9206ic();
                }
            } else if (b4 == 103) {
                f8835Nd = bArr[i + 4];
                ActivityC2266vc.f8582Nd = 1;
                byte b8 = f8835Nd;
                if (b8 != 3) {
                    if (b8 == 5) {
                        if (i4 > 6) {
                            f8812If = false;
                            f8817Jf = false;
                            f8847Pf = false;
                            f8926ff = false;
                            f8807Hf = false;
                            f8822Kf = false;
                            f8901af = false;
                            f8896Ze = false;
                            f8977rf = false;
                            f8973qf = false;
                            f8969pf = false;
                            f8827Lf = false;
                            f8837Nf = false;
                            f8981sf = false;
                            f8989uf = false;
                            f8994vf = false;
                            f8985tf = false;
                            f8999wf = false;
                            f9004xf = false;
                            f9009yf = false;
                            f9014zf = false;
                            m9114Id(m9152Sb((bArr[i + 6] & 255) | (bArr[i + 5] << 8)));
                            return;
                        }
                        return;
                    }
                    if (b8 != 6) {
                        return;
                    }
                    f8960ne = 0;
                    f8840Od = (byte) 0;
                    MainActivity.f6930Ia = 0;
                    MainActivity.m8169Ab(18, "");
                    MainActivity.f6889E5 = true;
                    LedBar.m8097j(2);
                    f8885Xd = new byte[17];
                    MainActivity.f7218ob = "?";
                } else {
                    if (i4 <= 5 || bArr[i + 5] != 2) {
                        return;
                    }
                    if (i4 > 7) {
                        m9118Jd(m9152Sb((bArr[i + 7] & 255) | (bArr[i + 6] << 8)));
                        f8812If = false;
                        f8817Jf = false;
                        f8847Pf = false;
                        f8926ff = true;
                        f8807Hf = false;
                        f8822Kf = false;
                        f8901af = false;
                        f8896Ze = false;
                        f8977rf = false;
                        f8973qf = false;
                        f8969pf = false;
                        f8787Df = false;
                        f8792Ef = false;
                        f8797Ff = false;
                        f8802Gf = false;
                        f8827Lf = false;
                        f8837Nf = false;
                        f8981sf = false;
                        f8989uf = false;
                        f8994vf = false;
                        f8985tf = false;
                        f8999wf = false;
                        f9004xf = false;
                        f9009yf = false;
                        f9014zf = false;
                        f8965of = false;
                        f8772Af = false;
                        f8777Bf = false;
                        f8931gf = false;
                        MainActivity.f6900F7 = 0;
                        return;
                    }
                    f8960ne = 0;
                    f8840Od = (byte) 0;
                    MainActivity.f6955L8 = 100;
                    MainActivity.f6930Ia = 0;
                    MainActivity.m8169Ab(18, "");
                    MainActivity.f6889E5 = true;
                    LedBar.m8097j(2);
                    f8885Xd = new byte[17];
                    MainActivity.f7218ob = "?";
                    MainActivity.f7030Tb = null;
                }
                enumC2294y = EnumC2294y.MODE_READ_ECU_INFOS;
            } else {
                if (b4 == 124) {
                    int i10 = i + 4;
                    int i11 = bArr[i10] - 1;
                    byte b9 = bArr[i10];
                    if (b9 == 1 || b9 == 2 || b9 == 3) {
                        m9112Ib(bArr, i + 5, f8885Xd, i11 * 5, 5);
                    } else {
                        if (b9 != 4) {
                            if (b9 != 8) {
                                if (b9 == 9 || b9 == 11) {
                                    if (i4 == 8) {
                                        i3 = (bArr[i + 5] << 8) & 65280;
                                        b3 = bArr[i + 6];
                                        b2 = 255;
                                    } else {
                                        b2 = 255;
                                        i3 = ((bArr[i + 5] & 255) << 16) | ((bArr[i + 6] & 255) << 8);
                                        b3 = bArr[i + 7];
                                    }
                                    m9251xc(0, (b3 & b2) | i3);
                                    return;
                                }
                                return;
                            }
                            String[] strArr = f8860Sd;
                            strArr[64] = m9124Lb(bArr, i + 5, 5, false, false);
                            if (strArr[64] == null || !strArr[64].equals(f8796Fe)) {
                                strArr[66] = "0";
                            } else {
                                strArr[66] = Integer.toString(f8993ve);
                            }
                            MainActivity.f7030Tb = strArr[64];
                            f8840Od = (byte) (f8840Od + 2);
                            if (f8926ff) {
                                f8936hf = true;
                            }
                            if (!MainActivity.f7019S9) {
                                m9170Wd(f8840Od);
                                f8783Cg.m8794t5();
                                MainActivity.m8169Ab(MainActivity.f7127ea ? 28 : 29, MainActivity.f7030Tb);
                                return;
                            } else {
                                m9135Ne(EnumC2294y.MODE_READ_SENSORS);
                                ActivityC2266vc.f8578Jd = 0;
                                MainActivity.f7019S9 = false;
                                MainActivity.f6925I5 = false;
                                f8956me = 1;
                                return;
                            }
                        }
                        m9112Ib(bArr, i + 5, f8885Xd, i11 * 5, 2);
                        f8860Sd[63] = m9124Lb(f8885Xd, 0, 17, true, false);
                    }
                    byte b10 = (byte) (f8840Od + 1);
                    f8840Od = b10;
                    m9170Wd(b10);
                    return;
                }
                if (b4 == 127) {
                    byte b11 = bArr[i + 4];
                    if (b11 == 0) {
                        ActivityC2266vc.f8571Cd = 0;
                    } else {
                        if (b11 != 51) {
                            return;
                        }
                        ActivityC2266vc.f8571Cd = 0;
                        MainActivity.m8169Ab(19, "");
                    }
                    m9129Mc();
                    return;
                }
                if (b4 == 67) {
                    if (!(MainActivity.f6862B5 | MainActivity.f6871C5)) {
                        i4 = ActivityC2266vc.f8572Dd - 1;
                        f8992vd = EnumC2294y.MODE_READ_ACTIVE;
                    }
                    m9194ec(bArr, i + 4, i4);
                    if (!MainActivity.f6862B5 && !MainActivity.f6871C5) {
                        return;
                    }
                    if (MainActivity.f6925I5) {
                        m9206ic();
                    }
                } else if (b4 == 68) {
                    f8952le = 0;
                    MainActivity.f6857A9 = false;
                    f8783Cg.m8734K9(null, null, null, R.string.error_erased, 1, 2, 5);
                } else if (b4 == 83) {
                    boolean z2 = f8962ng;
                    f8962ng = false;
                    if (f8992vd == EnumC2294y.MODE_ABS_DTC) {
                        f8917dg = true;
                        f8812If = false;
                        f8817Jf = false;
                        if (!f8783Cg.m8766f()) {
                            if (z2) {
                                f8783Cg.m8807z6(false, false);
                            } else {
                                enumC2294y2 = EnumC2294y.MODE_BLEEDING;
                            }
                            LedBar.m8097j(2);
                            MainActivity.f6925I5 = false;
                            return;
                        }
                        f8783Cg.m8758c5(bArr[i + 4], 10);
                        m9111He(MainActivity.f7116d8);
                        enumC2294y2 = EnumC2294y.MODE_READ_SENSORS;
                        m9135Ne(enumC2294y2);
                        LedBar.m8097j(2);
                        MainActivity.f6925I5 = false;
                        return;
                    }
                    if (f8956me <= 0) {
                        return;
                    }
                    f8956me = 0;
                    MainActivity.f6925I5 = true;
                    m9091Ce(MainActivity.f7170j8);
                    if (!(MainActivity.f6862B5 | MainActivity.f6871C5)) {
                        i4 = ActivityC2266vc.f8572Dd - 1;
                    }
                    m9100Fb(bArr, i + 4, i4);
                    m9206ic();
                } else if (b4 == 84) {
                    f8952le = 0;
                    f8992vd = EnumC2294y.MODE_READ_SENSORS;
                    f8962ng = true;
                } else if (b4 == 97) {
                    short[] sArr3 = f8873Ug;
                    if ((sArr3 != null) & (sArr3 == f8868Tg)) {
                        int i12 = 0;
                        while (true) {
                            short[] sArr4 = f8873Ug;
                            if (i12 >= sArr4.length / 2) {
                                break;
                            }
                            int i13 = i12 * 2;
                            boolean z3 = sArr4[i13] == f8798Fg;
                            int i14 = i13 + 1;
                            if (z3 & (sArr4[i14] < 4)) {
                                sArr4[i14] = 3;
                            }
                            i12++;
                        }
                    }
                    if (f8962ng) {
                        enumC2294y = EnumC2294y.MODE_ABS_DTC;
                    } else if (f8966og) {
                        enumC2294y = EnumC2294y.MODE_BLEEDING;
                    } else if (f8956me > 0) {
                        m9165Vc();
                        return;
                    } else {
                        if (f8952le <= 0) {
                            m9217le();
                            f8788Dg.m8890Cb(bArr, i + 4);
                            return;
                        }
                        enumC2294y = EnumC2294y.MODE_ABS_CLR_DTC;
                    }
                } else {
                    if (b4 != 98) {
                        switch (b4) {
                            case 113:
                            case 115:
                                MainActivity.f7268u9 = false;
                                byte b12 = bArr[i + 4];
                                if (b12 != 0) {
                                    if (b12 != 2) {
                                        if (b12 != 7) {
                                            if (b12 == 9) {
                                                MainActivity.f7286w9 = true;
                                                f8930ge = f8925fe;
                                                MainActivity.f7125e8 = 131072;
                                                f8957mf = true;
                                                f8783Cg.m8731G9(1);
                                            } else if (b12 == 11) {
                                                MainActivity.f7286w9 = true;
                                                byte b13 = f8925fe;
                                                f8930ge = b13;
                                                f8783Cg.m8756b5(20, b13);
                                            } else {
                                                int i15 = 10000;
                                                MainActivity.f7286w9 = true;
                                                if (b12 != 13) {
                                                    f8930ge = (byte) 0;
                                                    f8783Cg.m8746Sa(1, false);
                                                    if (f8926ff) {
                                                        i15 = 12000;
                                                    }
                                                } else if (MainActivity.f6875C9) {
                                                    byte b14 = f8925fe;
                                                    f8930ge = b14;
                                                    f8783Cg.m8756b5(20, b14);
                                                    MainActivity.m8199D9(10000);
                                                } else {
                                                    f8930ge = (byte) 0;
                                                    f8783Cg.m8746Sa(1, false);
                                                }
                                                MainActivity.m8211E9(i15);
                                            }
                                            break;
                                        } else {
                                            MainActivity.f7286w9 = true;
                                            f8930ge = f8925fe;
                                            if (!MainActivity.f6884D9) {
                                                MainActivity.f7125e8 = 65536;
                                                f8957mf = true;
                                                f8783Cg.m8732H9();
                                            } else {
                                                f8783Cg.m8756b5(20, f8925fe);
                                                MainActivity.m8199D9(15000);
                                            }
                                        }
                                    } else {
                                        MainActivity.f7286w9 = true;
                                        f8930ge = f8926ff ? (byte) 0 : f8925fe;
                                        f8783Cg.m8746Sa(1, false);
                                        MainActivity.m8211E9(18000);
                                    }
                                } else {
                                    f8930ge = (byte) 0;
                                    if (MainActivity.f7002Qa == 0) {
                                        MainActivity.f7286w9 = true;
                                        MainActivity.m8199D9(1500);
                                    }
                                }
                                break;
                            case 114:
                                f8930ge = (byte) 0;
                                if (!MainActivity.f6875C9) {
                                    if (!MainActivity.f6884D9) {
                                        if (MainActivity.f7002Qa != 4) {
                                            MainActivity.f7268u9 = false;
                                        } else {
                                            f8925fe = (byte) 0;
                                        }
                                    } else if (f8925fe != 7) {
                                        f8925fe = (byte) 7;
                                    } else {
                                        f8925fe = (byte) 11;
                                    }
                                } else if (f8925fe == 9) {
                                    f8925fe = (byte) 13;
                                }
                                break;
                        }
                        return;
                    }
                    short[] sArr5 = f8873Ug;
                    if ((sArr5 != null) & (sArr5 == f8868Tg)) {
                        int i16 = 0;
                        while (true) {
                            short[] sArr6 = f8873Ug;
                            if (i16 >= sArr6.length / 2) {
                                break;
                            }
                            int i17 = i16 * 2;
                            boolean z4 = sArr6[i17] == f8798Fg;
                            int i18 = i17 + 1;
                            if (z4 & (sArr6[i18] < 4)) {
                                sArr6[i18] = 3;
                            }
                            i16++;
                        }
                    }
                    if (!f8957mf) {
                        if (f8956me > 0) {
                            m9207id();
                            return;
                        }
                        if (f8952le > 0) {
                            m9186bd();
                            return;
                        }
                        if (MainActivity.f7268u9) {
                            m9235re();
                            return;
                        }
                        if (MainActivity.f7277v9) {
                            m9208ie();
                            return;
                        }
                        int i19 = f8998we;
                        if (i19 > 0) {
                            f8783Cg.m8738Ma(i19 & 127);
                            return;
                        }
                        if (f8970pg || f8974qg) {
                            f8783Cg.m8805y8(false);
                            return;
                        }
                        if (f8887Xf) {
                            m9137Oc();
                            return;
                        }
                        if (f8892Yf) {
                            m9215lc(false);
                            return;
                        }
                        m9217le();
                        f8788Dg.m8890Cb(bArr, i + 4);
                        if (MainActivity.f7304y9) {
                            MainActivity.m8546jb(false);
                        }
                        if (!MainActivity.f6866B9 || System.currentTimeMillis() <= MainActivity.f6903Fa) {
                            if (!MainActivity.f7313z9 || System.currentTimeMillis() <= MainActivity.f6903Fa) {
                                return;
                            }
                            f8783Cg.m8756b5(20, f8925fe);
                            return;
                        }
                        f8783Cg.m8746Sa(4, false);
                        if (f8930ge == 2) {
                            MainActivity.f7268u9 = true;
                            return;
                        }
                        return;
                    }
                    m9111He(MainActivity.f7116d8);
                }
            }
            m9217le();
            return;
        }
        enumC2294y = EnumC2294y.MODE_ABS_DTC;
        m9135Ne(enumC2294y);
    }

    /* JADX INFO: renamed from: Bd */
    private static void m9086Bd() {
        m9098Ed(new byte[]{46, 1, 3, MainActivity.f7032U4 ? (byte) 1 : (byte) 0}, -1, true);
    }

    /* JADX INFO: renamed from: Be */
    public static void m9087Be(String str) {
        if (MainActivity.f7209nb.equals("")) {
            MainActivity.f6973N8 = 120.0f;
            MainActivity.f6910G8 = 120;
        }
        if (str == null || str.length() == 0) {
            str = " ";
        }
        m9084Ae(str);
        if (str.length() == 8) {
            f8926ff = str.substring(1, 2).equals("1");
            f8931gf = str.substring(1, 2).equals("2");
            try {
                MainActivity.f6973N8 = Float.parseFloat(str.substring(2, 5));
                MainActivity.f6910G8 = Integer.parseInt(str.substring(5, 8));
            } catch (Exception e) {
                if (f8785Dd) {
                    Log.e("ISORead", Log.getStackTraceString(e));
                }
            }
        }
        ActivityC2266vc.f8582Nd = (((f8827Lf ? 1 : 0) | (f8871Ue ? 1 : 0)) | (f8807Hf ? 1 : 0)) ^ 1;
        if ((MainActivity.f7116d8 < 3) && (!MainActivity.f6970N5)) {
            f8783Cg.m8778kb(MainActivity.f7152h8);
        }
    }

    /* JADX INFO: renamed from: Cb */
    public static void m9088Cb(boolean z) {
        String strM9079Tb;
        MainActivity mainActivity;
        String str;
        String[] strArr;
        int i;
        int i2;
        int i3;
        int i4;
        f8807Hf = false;
        f8822Kf = false;
        f8901af = false;
        f8896Ze = false;
        f8977rf = false;
        f8973qf = false;
        f8969pf = false;
        f8827Lf = false;
        f8837Nf = false;
        f8981sf = false;
        f8989uf = false;
        f8994vf = false;
        f8985tf = false;
        f8999wf = false;
        f9004xf = false;
        f9009yf = false;
        f9014zf = false;
        f8965of = false;
        f8772Af = false;
        f8777Bf = false;
        f8931gf = true;
        f8912cg = false;
        if (!f8862Sf) {
            if (z) {
                MainActivity.m8169Ab(11, "");
            }
            f8778Bg.m9078Rb(38400, true);
            m9180Zc(f8884Wh, 5, true);
            m9212kc(100);
            return;
        }
        int i5 = f9002xd;
        f9002xd = i5 + 1;
        if (i5 <= 6) {
            byte[] bArr = new byte[1];
            f8890Yd = bArr;
            ActivityC2266vc.m9074Xb(bArr, 1, false, true);
            ActivityC2266vc.m9072Ub(8);
            return;
        }
        f9002xd = 0;
        f8862Sf = false;
        if (f8857Rf) {
            strM9079Tb = f8778Bg.m9079Tb(EnumC2281x.ERR_FAILED);
            mainActivity = f8783Cg;
            str = null;
            strArr = null;
            i = 0;
            i2 = 2;
            i3 = 2;
            i4 = 19;
        } else {
            strM9079Tb = f8778Bg.m9079Tb(EnumC2281x.ERR_NO_ECU);
            mainActivity = f8783Cg;
            str = null;
            strArr = null;
            i = 0;
            i2 = 3;
            i3 = 3;
            i4 = 10;
        }
        mainActivity.m8734K9(str, strArr, strM9079Tb, i, i2, i3, i4);
        ActivityC2266vc.f8581Md = 0;
    }

    /* JADX INFO: renamed from: Cc */
    public static void m9089Cc(int i) {
        String str;
        f8783Cg.m8788p8(i > 0, true);
        if (i > 0) {
            str = String.format("%04x", Integer.valueOf(i));
            f8833Mg.add(str);
        } else {
            str = "";
        }
        if (MainActivity.f6925I5) {
            m9206ic();
        }
        if (MainActivity.f6929I9) {
            if (i == 0) {
                str = "----";
            }
            if (MainActivity.f6967Mb.equals(str)) {
                return;
            }
            String str2 = new SimpleDateFormat("HH:mm:ss", Locale.US).format(Long.valueOf(System.currentTimeMillis()));
            MainActivity.f6967Mb = str;
            MainActivity.m8169Ab(0, str2 + " : " + str + " = " + m9227pc(str));
        }
    }

    /* JADX INFO: renamed from: Cd */
    public static void m9090Cd() {
        int[] iArr = MainActivity.f7111cc;
        m9177Yc(new byte[]{92, (byte) iArr[1], (byte) iArr[2], (byte) iArr[3], 1, 110, 0, 0}, (byte) 0);
    }

    /* JADX INFO: renamed from: Ce */
    private static void m9091Ce(int i) {
        f8833Mg = new ArrayList();
        f8813Ig = i;
        f8808Hg = 0;
    }

    /* JADX WARN: Code duplicated, block: B:28:0x0043  */
    /* JADX WARN: Code duplicated, block: B:29:0x0045  */
    /* JADX WARN: Code duplicated, block: B:31:0x0048  */
    /* JADX WARN: Code duplicated, block: B:32:0x004a  */
    /* JADX WARN: Code duplicated, block: B:35:0x004e  */
    /* JADX WARN: Code duplicated, block: B:37:0x0052 A[DONT_INVERT] */
    /* JADX WARN: Code duplicated, block: B:38:0x0054  */
    /* JADX WARN: Code duplicated, block: B:39:0x0056  */
    /* JADX WARN: Code duplicated, block: B:41:0x0059  */
    /* JADX WARN: Code duplicated, block: B:42:0x005b  */
    /* JADX WARN: Code duplicated, block: B:45:0x005f  */
    /* JADX WARN: Code duplicated, block: B:47:0x0064  */
    /* JADX WARN: Code duplicated, block: B:48:0x006b  */
    /* JADX WARN: Code duplicated, block: B:52:0x0074 A[LOOP:0: B:3:0x000b->B:52:0x0074, LOOP_END] */
    /* JADX WARN: Code duplicated, block: B:56:0x007d A[EDGE_INSN: B:56:0x007d->B:53:0x007d BREAK  A[LOOP:0: B:3:0x000b->B:52:0x0074], SYNTHETIC] */
    /* JADX INFO: renamed from: Db */
    private static String m9092Db(byte[] bArr, int i, int i2) {
        boolean z;
        int i3;
        boolean z2;
        boolean z3;
        boolean z4;
        boolean z5;
        int i4 = i2 / 2;
        byte[] bArr2 = new byte[i4];
        StringBuilder sb = new StringBuilder();
        for (int i5 = 0; i5 < i4; i5++) {
            int i6 = (i5 * 2) + i;
            int i7 = bArr[i6];
            boolean z6 = true;
            if ((i7 >= 48) && (i7 < 58)) {
                i7 -= 48;
            } else {
                if ((i7 >= 65) && (i7 < 91)) {
                    i7 -= 55;
                } else {
                    z = true;
                }
                i3 = bArr[i6 + 1];
                if (i3 >= 48) {
                    z2 = true;
                } else {
                    z2 = false;
                }
                if (i3 < 58) {
                    z3 = true;
                } else {
                    z3 = false;
                }
                if (z2 && z3) {
                    i3 -= 48;
                } else {
                    if (i3 >= 65) {
                        z4 = true;
                    } else {
                        z4 = false;
                    }
                    if (i3 < 91) {
                        z5 = true;
                    } else {
                        z5 = false;
                    }
                    if (z4 & z5) {
                        i3 -= 55;
                    }
                    if (z6) {
                        bArr2[i5] = 63;
                    } else {
                        bArr2[i5] = (byte) (i3 | (i7 << 4));
                    }
                    if (bArr2[i5] == 0) {
                        break;
                    }
                    sb.append((char) bArr2[i5]);
                }
                z6 = z;
                if (z6) {
                    bArr2[i5] = (byte) (i3 | (i7 << 4));
                } else {
                    bArr2[i5] = 63;
                }
                if (bArr2[i5] == 0) {
                    break;
                    break;
                }
                sb.append((char) bArr2[i5]);
            }
            z = false;
            i3 = bArr[i6 + 1];
            if (i3 >= 48) {
                z2 = true;
            } else {
                z2 = false;
            }
            if (i3 < 58) {
                z3 = true;
            } else {
                z3 = false;
            }
            if (z2 && z3) {
                i3 -= 48;
            } else {
                if (i3 >= 65) {
                    z4 = true;
                } else {
                    z4 = false;
                }
                if (i3 < 91) {
                    z5 = true;
                } else {
                    z5 = false;
                }
                if (z4 & z5) {
                    i3 -= 55;
                }
                if (z6) {
                    bArr2[i5] = (byte) (i3 | (i7 << 4));
                } else {
                    bArr2[i5] = 63;
                }
                if (bArr2[i5] == 0) {
                    break;
                    break;
                }
                sb.append((char) bArr2[i5]);
            }
            z6 = z;
            if (z6) {
                bArr2[i5] = (byte) (i3 | (i7 << 4));
            } else {
                bArr2[i5] = 63;
            }
            if (bArr2[i5] == 0) {
                break;
                break;
            }
            sb.append((char) bArr2[i5]);
        }
        return sb.toString();
    }

    /* JADX WARN: Code duplicated, block: B:40:0x007a  */
    /* JADX INFO: renamed from: Dc */
    private static void m9093Dc(byte[] bArr, int i, int i2) throws CloneNotSupportedException {
        int i3;
        if (bArr[(i + i2) - 1] == m9132Nb(bArr, i, i2 - 1)) {
            int i4 = i + 1;
            byte b2 = bArr[i4 + 3];
            if (b2 == 80) {
                MainActivity.f6930Ia = 4;
                f8871Ue = true;
                MainActivity.m8169Ab(6, "");
                MainActivity.f6889E5 = true;
                m9135Ne(EnumC2294y.MODE_READ_IDENT);
                return;
            }
            if (b2 != 84) {
                if (b2 == 90) {
                    LedBar.m8097j(2);
                    f8812If = false;
                    f8817Jf = false;
                    f8847Pf = false;
                    f8926ff = false;
                    f8787Df = false;
                    f8792Ef = false;
                    f8797Ff = false;
                    f8802Gf = false;
                    f8827Lf = false;
                    f8837Nf = false;
                    f8981sf = false;
                    f8989uf = false;
                    f8807Hf = false;
                    f8822Kf = false;
                    f8901af = false;
                    f8896Ze = false;
                    f8977rf = false;
                    f8973qf = false;
                    f8969pf = false;
                    f8965of = false;
                    f8772Af = false;
                    f8777Bf = false;
                    f8931gf = false;
                    f8953lf = false;
                    f8945jf = false;
                    f8961nf = false;
                    f8949kf = false;
                    f8921ef = false;
                    MainActivity.f7030Tb = null;
                    MainActivity.f6958Lb = "K";
                    f8935he = 0;
                    MainActivity.f6973N8 = 110.0f;
                    MainActivity.f6910G8 = 120;
                    String[] strArr = f8860Sd;
                    strArr[62] = m9124Lb(bArr, i4 + 4, 10, true, false);
                    strArr[63] = "";
                    strArr[64] = "";
                    strArr[65] = "";
                    MainActivity.f7223p7 = "A57JEPQRUVWTgvhk";
                    f8788Dg.f7799vd = "A57JEPQRUVWTgvhk";
                    MainActivity.f7242r8 = 0;
                    f8980se = 2168656;
                    ActivityC2266vc.f8582Nd = 0;
                    ActivityC2225t.m9000Lb(f8980se, 1, null);
                    m9099Ee("");
                    f8783Cg.m8780m9();
                    MainActivity.f7051W5 = false;
                    f8783Cg.m8778kb(30);
                    m9135Ne(EnumC2294y.MODE_READ_SENSORS);
                    f8956me = 1;
                    return;
                }
                if (b2 == 97) {
                    short[] sArr = f8873Ug;
                    if ((sArr != null) & (sArr == f8868Tg)) {
                        int i5 = 0;
                        while (true) {
                            short[] sArr2 = f8873Ug;
                            if (i5 >= sArr2.length / 2) {
                                break;
                            }
                            int i6 = i5 * 2;
                            boolean z = sArr2[i6] == f8798Fg;
                            int i7 = i6 + 1;
                            if (z & (sArr2[i7] < 4)) {
                                sArr2[i7] = 3;
                            }
                            i5++;
                        }
                    }
                    if (!f8957mf) {
                        if (MainActivity.f7268u9) {
                            m9235re();
                            return;
                        }
                        if (f8956me > 0) {
                            m9091Ce(20);
                        }
                        m9217le();
                        f8788Dg.m8890Cb(bArr, i4 + 4);
                        if (MainActivity.f7304y9) {
                            MainActivity.m8546jb(false);
                        }
                        if (!MainActivity.f6866B9 || System.currentTimeMillis() <= MainActivity.f6903Fa) {
                            return;
                        }
                        f8783Cg.m8746Sa(4, false);
                        return;
                    }
                    m9111He(MainActivity.f7116d8);
                } else {
                    if (b2 != 113) {
                        if (b2 != 126) {
                            if (b2 != 127) {
                                return;
                            }
                            byte b3 = bArr[i4 + 4];
                            if (b3 != 0) {
                                if (b3 == 49) {
                                    m9139Oe(true);
                                    return;
                                } else if (b3 != 62) {
                                    return;
                                }
                            }
                        }
                        ActivityC2266vc.f8571Cd = 0;
                        m9129Mc();
                        return;
                    }
                    int i8 = 5000;
                    MainActivity.f7286w9 = true;
                    MainActivity.f7268u9 = false;
                    byte b4 = f8925fe;
                    if (b4 != -34) {
                        if (b4 != -33) {
                            i3 = b4 == -30 ? 131072 : 65536;
                        } else {
                            i8 = 19000;
                        }
                        f8783Cg.m8746Sa(1, (MainActivity.f7125e8 & 16711680) > 0);
                        MainActivity.m8211E9(i8);
                    }
                    MainActivity.f7125e8 = i3;
                    f8957mf = true;
                    f8783Cg.m8746Sa(1, (MainActivity.f7125e8 & 16711680) > 0);
                    MainActivity.m8211E9(i8);
                }
            } else {
                f8783Cg.m8734K9(null, null, null, R.string.error_erased, 1, 2, 5);
            }
            m9217le();
        }
    }

    /* JADX INFO: renamed from: Dd */
    private static void m9094Dd() {
        f8828Lg = Boolean.TRUE;
        if (!f9015zg) {
            int[] iArr = MainActivity.f7111cc;
            int i = iArr[0] / 25;
            m9177Yc(new byte[]{16, 8, 46, -96, 0, (byte) (i >> 8), (byte) (i & 255), (byte) iArr[1]}, (byte) 0);
            return;
        }
        MainActivity.f7024T5 = true;
        MainActivity.f7057Wb = "STPX D:2EA000";
        String strConcat = "STPX D:2EA000".concat(String.format("%02x", Byte.valueOf(MainActivity.f7120dc[0])));
        MainActivity.f7057Wb = strConcat;
        String strConcat2 = strConcat.concat(String.format("%02x", Byte.valueOf(MainActivity.f7120dc[1])));
        MainActivity.f7057Wb = strConcat2;
        String strConcat3 = strConcat2.concat(String.format("%02x", Byte.valueOf(MainActivity.f7120dc[2])));
        MainActivity.f7057Wb = strConcat3;
        String strConcat4 = strConcat3.concat(String.format("%06x", Integer.valueOf(MainActivity.f7111cc[0])));
        MainActivity.f7057Wb = strConcat4;
        String strConcat5 = strConcat4.concat(String.format("%02x", Byte.valueOf(MainActivity.f7120dc[3])));
        MainActivity.f7057Wb = strConcat5;
        String strConcat6 = strConcat5.concat(String.format("%02x", Byte.valueOf(MainActivity.f7120dc[4])));
        MainActivity.f7057Wb = strConcat6;
        String strConcat7 = strConcat6.concat(String.format("%02x", Byte.valueOf(MainActivity.f7120dc[5])));
        MainActivity.f7057Wb = strConcat7;
        String strConcat8 = strConcat7.concat(String.format("%02x", Integer.valueOf(MainActivity.f7111cc[1])));
        MainActivity.f7057Wb = strConcat8;
        String strConcat9 = strConcat8.concat(String.format("%02x", Integer.valueOf(MainActivity.f7111cc[2])));
        MainActivity.f7057Wb = strConcat9;
        MainActivity.f7057Wb = strConcat9.concat(String.format("%02x", Integer.valueOf(MainActivity.f7111cc[3])));
        f8783Cg.m8752Z8("ATCAF1");
    }

    /* JADX INFO: renamed from: De */
    private static void m9095De() {
        f8790Ed = -1705012149;
        int i = (-1705012149) ^ 978928971;
        f8795Fd = i;
        f8790Ed = (i >> 16) & 65535;
        f8795Fd = i & 65535;
    }

    /* JADX INFO: renamed from: Eb */
    private static byte[] m9096Eb(int i) {
        byte[] bArr = new byte[4];
        for (int i2 = 0; i2 < 4; i2++) {
            bArr[3 - i2] = (byte) (i & 255);
            i >>= 8;
        }
        return bArr;
    }

    /* JADX INFO: renamed from: Ec */
    public static void m9097Ec() {
        String strM9079Tb;
        MainActivity mainActivity;
        String str;
        String[] strArr;
        int i;
        int i2;
        int i3;
        f9007yd = 0;
        f8942ig = false;
        f8787Df = false;
        f8792Ef = false;
        f8797Ff = false;
        f8802Gf = false;
        f8827Lf = false;
        f8837Nf = false;
        f8912cg = true;
        LedBar.m8101n(true);
        LedBar.m8097j(0);
        int i4 = f9002xd;
        f9002xd = i4 + 1;
        if (i4 <= 4) {
            MainActivity.m8169Ab(10, "");
            f8778Bg.m9078Rb(10400, true);
            ActivityC2266vc.m9071Sb((byte) 0);
            SystemClock.sleep(25L);
            ActivityC2266vc.m9071Sb((byte) 1);
            m9135Ne(EnumC2294y.MODE_INIT);
            return;
        }
        f9002xd = -1;
        if (!f8857Rf) {
            if (MainActivity.f6862B5 && MainActivity.f6880D5) {
                f8783Cg.m8734K9(null, null, f8778Bg.m9079Tb(EnumC2281x.ERR_BAD_DEVICE), 0, 20, 1, 0);
                f8783Cg.m8739N5(false);
            } else if (!MainActivity.f6929I9) {
                strM9079Tb = f8778Bg.m9079Tb(EnumC2281x.ERR_NO_ECU);
                mainActivity = f8783Cg;
                str = null;
                strArr = null;
                i = 0;
                i2 = 3;
                i3 = 3;
            }
            ActivityC2266vc.f8581Md = 0;
        }
        strM9079Tb = f8778Bg.m9079Tb(EnumC2281x.ERR_FAILED);
        mainActivity = f8783Cg;
        str = null;
        strArr = null;
        i = 0;
        i2 = 2;
        i3 = 2;
        mainActivity.m8734K9(str, strArr, strM9079Tb, i, i2, i3, 10);
        ActivityC2266vc.f8581Md = 0;
    }

    /* JADX INFO: renamed from: Ed */
    private static void m9098Ed(byte[] bArr, int i, boolean z) {
        int i2;
        int i3;
        if (MainActivity.f6862B5 || MainActivity.f6871C5) {
            int i4 = f8881We ? 2 : 0;
            byte[] bArr2 = new byte[(bArr.length * 2) + i4 + 1];
            int i5 = 0;
            while (i5 < bArr.length) {
                byte b2 = (byte) ((bArr[i5] >> 4) & 15);
                int i6 = (i5 * 2) + i4;
                bArr2[i6] = (byte) (b2 > 9 ? b2 + 55 : b2 + 48);
                byte b3 = (byte) (bArr[i5] & 15);
                bArr2[i6 + 1] = (byte) (b3 > 9 ? b3 + 55 : b3 + 48);
                i5++;
            }
            bArr2[(i5 * 2) + i4] = 13;
            if (i4 > 0) {
                byte length = (byte) ((bArr.length >> 4) & 15);
                bArr2[0] = (byte) (length > 9 ? length + 55 : length + 48);
                byte length2 = (byte) (bArr.length & 15);
                bArr2[1] = (byte) (length2 > 9 ? length2 + 55 : length2 + 48);
            }
            f8783Cg.m8755a9(bArr2);
            return;
        }
        boolean z2 = bArr.length > 120;
        int length3 = bArr.length;
        boolean z3 = f8876Ve;
        boolean z4 = f8871Ue;
        boolean z5 = f8990ug;
        int i7 = length3 + (((z3 | z4) | z2) | z5 ? 5 : 4);
        byte[] bArr3 = new byte[i7];
        int i8 = f9007yd;
        bArr3[0] = (byte) (i8 == 247 ? 104 : (((z3 | z4) | z2) | z5 ? 0 : bArr.length) + 128);
        if (i8 == 247) {
            i2 = 106;
        } else if (z4) {
            i2 = 17;
        } else if (f8902ag) {
            i2 = 16;
        } else if (f8907bg) {
            i2 = 1;
        } else {
            i2 = (f8822Kf ? f8988ue : 0) + 213;
        }
        bArr3[1] = (byte) i2;
        if (f8922eg) {
            i3 = 1;
        } else {
            boolean z6 = f8907bg;
            i3 = (f8867Tf && z6) ? 243 : (((i8 == 247) | z4) | f8902ag) | z6 ? 241 : 245;
        }
        bArr3[2] = (byte) i3;
        boolean z7 = z3 | z4 | z2 | z5;
        int i9 = -1;
        if (z7) {
            bArr3[3] = (byte) bArr.length;
        } else if (!(f8827Lf | f8837Nf)) {
            i9 = i;
        }
        for (int i10 = 0; i10 < bArr.length; i10++) {
            bArr3[(((f8876Ve | f8871Ue) | z2) | f8990ug ? 4 : 3) + i10] = bArr[i10];
        }
        int i11 = i7 - 1;
        bArr3[i11] = m9132Nb(bArr3, 0, i11);
        ActivityC2266vc.m9074Xb(bArr3, i9, true, z);
    }

    /* JADX INFO: renamed from: Ee */
    private static void m9099Ee(String str) {
        int i = 0;
        int iIndexOf = 0;
        while (true) {
            String[] strArr = MainActivity.f6891E7;
            if (i >= strArr.length - 1 || ((iIndexOf = strArr[i].indexOf(":")) > 0 && str.equals(MainActivity.f6891E7[i].substring(iIndexOf + 1, iIndexOf + 2)))) {
                break;
            } else {
                i++;
            }
        }
        String[] strArr2 = MainActivity.f6891E7;
        if (i >= strArr2.length - 1) {
            MainActivity.f7209nb = strArr2[i];
            return;
        }
        MainActivity.f7209nb = strArr2[i].substring(0, iIndexOf);
        if (!MainActivity.f6891E7[i].contains("-v") || MainActivity.f7200mb.contains(str)) {
            return;
        }
        MainActivity.f7200mb = MainActivity.f7200mb.concat(str);
    }

    /* JADX INFO: renamed from: Fb */
    private static void m9100Fb(byte[] bArr, int i, int i2) {
        char[] cArr = {'P', 'C', 'B', 'U'};
        char[] cArr2 = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};
        int i3 = i2 - i;
        int i4 = i;
        while (i3 >= 0) {
            for (int i5 = 0; i5 < 3; i5++) {
                if (f8808Hg < f8813Ig) {
                    short s = (short) ((bArr[i4] << 8) | (bArr[i4 + 1] & 255));
                    if (s != 0) {
                        StringBuilder sb = new StringBuilder();
                        sb.append(cArr[(s >> 14) & 3]);
                        sb.append(cArr2[3 & (s >> 12)]);
                        sb.append(cArr2[(s >> 8) & 15]);
                        sb.append(cArr2[(s >> 4) & 15]);
                        sb.append(cArr2[s & 15]);
                        if (!f8833Mg.contains(sb.toString())) {
                            f8833Mg.add(sb.toString());
                        }
                    }
                    f8808Hg++;
                    i4 += 2;
                }
            }
            i3 -= 11;
            i4 += i + 1;
        }
    }

    /* JADX WARN: Code duplicated, block: B:253:0x046b  */
    /* JADX WARN: Code duplicated, block: B:570:0x0950  */
    /* JADX WARN: Code duplicated, block: B:582:0x09a2  */
    /* JADX WARN: Code duplicated, block: B:586:0x09b8  */
    /* JADX WARN: Code duplicated, block: B:589:0x09c5  */
    /* JADX WARN: Code duplicated, block: B:96:0x01db  */
    /* JADX WARN: Code restructure failed: missing block: B:135:0x0272, code lost:
    
        if (((r20[r1] & 255) | (((r20[r4] << 32) | (r20[r8] << 16)) | (r20[r11] << 8))) == com.tuneecu.ActivityC2307z.f8814Ih[com.tuneecu.C2182pc.f8244j]) goto L93;
     */
    /* JADX WARN: Code restructure failed: missing block: B:568:0x094d, code lost:
    
        if (((com.tuneecu.ActivityC2307z.f8988ue == 1) & (com.tuneecu.ActivityC2307z.f8956me + com.tuneecu.ActivityC2307z.f8952le == 0)) != false) goto L558;
     */
    /* JADX WARN: Code restructure failed: missing block: B:92:0x01b4, code lost:
    
        if (((r20[r1] & 255) | (((r20[r4] << 32) | (r20[r8] << 16)) | (r20[r11] << 8))) == com.tuneecu.ActivityC2307z.f8814Ih[com.tuneecu.C2182pc.f8244j]) goto L93;
     */
    /* JADX WARN: Code restructure failed: missing block: B:94:0x01bd, code lost:
    
        com.tuneecu.ActivityC2307z.f8857Rf = false;
        com.tuneecu.ActivityC2307z.f8937hg = false;
        com.tuneecu.ActivityC2307z.f8954lg = false;
     */
    /* JADX WARN: Multi-variable type inference failed */
    /* JADX WARN: Type inference fix 'apply assigned field type' failed
    java.lang.UnsupportedOperationException: ArgType.getObject(), call class: class jadx.core.dex.instructions.args.ArgType$UnknownArg
    	at jadx.core.dex.instructions.args.ArgType.getObject(ArgType.java:596)
    	at jadx.core.dex.attributes.nodes.ClassTypeVarsAttr.getTypeVarsMapFor(ClassTypeVarsAttr.java:35)
    	at jadx.core.dex.nodes.utils.TypeUtils.replaceClassGenerics(TypeUtils.java:177)
    	at jadx.core.dex.visitors.typeinference.FixTypesVisitor.insertExplicitUseCast(FixTypesVisitor.java:397)
    	at jadx.core.dex.visitors.typeinference.FixTypesVisitor.tryFieldTypeWithNewCasts(FixTypesVisitor.java:359)
    	at jadx.core.dex.visitors.typeinference.FixTypesVisitor.applyFieldType(FixTypesVisitor.java:309)
    	at jadx.core.dex.visitors.typeinference.FixTypesVisitor.visit(FixTypesVisitor.java:94)
     */
    /* JADX INFO: renamed from: Fc */
    /*
        Code decompiled incorrectly, please refer to instructions dump.
    */
    private static void m9101Fc(byte[] bArr, int i, int i2) throws Throwable {
        int i3;
        int i4;
        EnumC2294y enumC2294y;
        String strM9079Tb;
        MainActivity mainActivity;
        String str;
        String[] strArr;
        int i5;
        int i6;
        int i7;
        int i8;
        int i9;
        byte b2;
        int i10;
        String strM9079Tb2;
        MainActivity mainActivity2;
        String str2;
        String[] strArr2;
        int i11;
        int i12;
        int i13;
        int i14;
        ActivityC2266vc activityC2266vc;
        EnumC2281x enumC2281x;
        byte b3;
        boolean z;
        int i15;
        int i16;
        if (m9168Wb(bArr, i, i2)) {
            if (f8876Ve) {
                i3 = i + 1;
                i4 = i2 - 1;
                if (!f8857Rf && !f8867Tf && (i16 = MainActivity.f6909G7) > 0) {
                    m9212kc(i16 * 5);
                }
            } else {
                i3 = i;
                i4 = i2;
            }
            byte b4 = bArr[i3 + 3];
            boolean z2 = true;
            int i17 = 0;
            if (b4 != -30 && b4 != -27) {
                if (b4 == 81) {
                    m9135Ne(EnumC2294y.MODE_NULL);
                    strM9079Tb = f8778Bg.m9079Tb(EnumC2281x.END_DOWNLOAD);
                    mainActivity = f8783Cg;
                    str = null;
                    strArr = null;
                    i5 = 0;
                    i6 = 3;
                    i7 = 2;
                } else {
                    if (b4 == 90) {
                        byte[] bArr2 = new byte[i4];
                        System.arraycopy(bArr, i3, bArr2, 0, i4);
                        m9248wc(bArr2, 2);
                        return;
                    }
                    if (b4 == 103) {
                        int i18 = 10;
                        byte b5 = bArr[i3 + 4];
                        f8835Nd = b5;
                        if (b5 == 3) {
                            f8812If = false;
                            f8817Jf = false;
                            i9 = bArr[i3 + 5] << 8;
                            b2 = bArr[i3 + 6];
                        } else {
                            if (b5 == 4) {
                                f8926ff = false;
                                f8787Df = false;
                                f8792Ef = false;
                                f8797Ff = false;
                                f8802Gf = false;
                                f8827Lf = false;
                                f8837Nf = false;
                                f8981sf = false;
                                f8989uf = false;
                                f8994vf = false;
                                f8985tf = false;
                                f8999wf = false;
                                f9004xf = false;
                                f9009yf = false;
                                f9014zf = false;
                                f8965of = false;
                                f8772Af = false;
                                f8777Bf = false;
                                f8931gf = false;
                                f8807Hf = true;
                                byte b6 = f8845Pd;
                                boolean z3 = b6 == 0;
                                f8822Kf = z3;
                                f8977rf = b6 == 1;
                                boolean z4 = b6 == 2;
                                f8973qf = z4;
                                f8773Ag = "";
                                if (z3) {
                                    i18 = 2;
                                } else if (!z4) {
                                    i18 = 6;
                                }
                                ActivityC2266vc.f8576Hd = i18;
                                MainActivity.f6900F7 = i18;
                                ActivityC2266vc.f8582Nd = 0;
                                f8960ne = 0;
                                f8840Od = (byte) 8;
                                MainActivity.f6930Ia = 2;
                                MainActivity.f7114d6 = false;
                                MainActivity.m8169Ab(18, "");
                                MainActivity.f6889E5 = true;
                                LedBar.m8097j(2);
                                if (!f8867Tf) {
                                    if (!f8852Qf) {
                                        MainActivity.f7030Tb = null;
                                    }
                                    f8800Gd = 0;
                                    m9107Ge(24576, 32, -32);
                                    f8992vd = EnumC2294y.MODE_READ_ECU_INFOS;
                                    return;
                                }
                            } else if (b5 == 5) {
                                f8812If = false;
                                f8817Jf = false;
                                i9 = bArr[i3 + 5] << 8;
                                b2 = bArr[i3 + 6];
                            } else {
                                if (b5 != 6) {
                                    switch (b5) {
                                        case -125:
                                        case -123:
                                            i9 = bArr[i3 + 5] << 8;
                                            b2 = bArr[i3 + 6];
                                            break;
                                        case -124:
                                            LedBar.m8097j(2);
                                            if (!f8937hg && MainActivity.m8498f5(f8905be, 20, 4) == MainActivity.m8498f5(ActivityC2225t.f8446Ed, 20, 4)) {
                                                z2 = false;
                                            }
                                            f8842Of = z2;
                                            enumC2294y = EnumC2294y.MODE_SPEED_COM;
                                            break;
                                        case -122:
                                            LedBar.m8097j(2);
                                            if (!f8937hg && MainActivity.m8498f5(f8905be, 20, 4) == MainActivity.m8498f5(ActivityC2225t.f8446Ed, 20, 4)) {
                                                z2 = false;
                                            }
                                            f8842Of = z2;
                                            m9119Je();
                                            enumC2294y = EnumC2294y.MODE_SPEED_COM;
                                            break;
                                    }
                                }
                                LedBar.m8097j(2);
                                boolean z5 = f8876Ve;
                                if (!z5 || f8867Tf) {
                                    boolean z6 = f8867Tf;
                                    if (z6 && f8877Vf) {
                                        i10 = f8811Ie + 24576;
                                    } else {
                                        if (!f8872Uf) {
                                            if (!z6) {
                                                if (!f8857Rf) {
                                                    return;
                                                }
                                                if (MainActivity.f7115d7 <= 0 || (ActivityC2225t.f8481Yd[0] & 4095) != 80 ? !(f8937hg || MainActivity.m8498f5(f8905be, 20, 4) != MainActivity.m8498f5(ActivityC2225t.f8446Ed, 20, 4)) : !(f8954lg || (f8877Vf && ActivityC2225t.f8442Cd[f8811Ie + 24575] == 0))) {
                                                    z2 = false;
                                                }
                                                f8842Of = z2;
                                                m9119Je();
                                                enumC2294y = EnumC2294y.MODE_START_PROG;
                                            } else if (z5) {
                                                f8840Od = (byte) 8;
                                            } else {
                                                enumC2294y = EnumC2294y.MODE_READ_MEM;
                                            }
                                        }
                                        i10 = 327680;
                                    }
                                    m9107Ge(i10, 32, -32);
                                    return;
                                }
                                f8800Gd = 0;
                                f8807Hf = true;
                                byte b7 = f8845Pd;
                                f8822Kf = b7 == 0;
                                f8977rf = b7 == 1;
                                f8973qf = b7 == 2;
                                MainActivity.f7114d6 = false;
                                MainActivity.m8169Ab(18, "");
                                if (f8937hg) {
                                    i10 = 24576;
                                    m9107Ge(i10, 32, -32);
                                    return;
                                } else if (!f8857Rf) {
                                    return;
                                } else {
                                    f8840Od = (byte) 14;
                                }
                            }
                            enumC2294y = EnumC2294y.MODE_READ_ECU_INFOS;
                        }
                        m9114Id(m9152Sb((b2 & 255) | i9));
                        return;
                    }
                    if (b4 != 116) {
                        if (b4 != 67) {
                            if (b4 == 68) {
                                int i19 = f8952le - 1;
                                f8952le = i19;
                                if (i19 != 0) {
                                    if (i19 <= 0 || (MainActivity.f6862B5 || MainActivity.f6871C5)) {
                                        return;
                                    }
                                    m9125Lc(1);
                                    return;
                                }
                                if (f8988ue == 1) {
                                    m9125Lc(0);
                                }
                                f8783Cg.m8734K9(null, null, null, R.string.error_erased, 1, 2, 5);
                            } else if (b4 == 113) {
                                int i20 = i3 + 4;
                                byte b8 = bArr[i20];
                                if (b8 != -112) {
                                    if (b8 != -111) {
                                        if ((bArr[i20] & 160) == 160) {
                                            MainActivity.f7286w9 = true;
                                            MainActivity.f7268u9 = false;
                                            byte b9 = f8925fe;
                                            if (b9 == 0) {
                                                MainActivity.m8199D9(1500);
                                            } else if (b9 == 49) {
                                                f8783Cg.m8756b5(10, b9);
                                            } else {
                                                if (b9 == -112) {
                                                    f8930ge = b9;
                                                } else {
                                                    f8930ge = (byte) 0;
                                                }
                                                f8783Cg.m8746Sa(1, false);
                                                MainActivity.m8211E9(10000);
                                            }
                                        }
                                    }
                                } else if (f8926ff) {
                                    enumC2294y = EnumC2294y.MODE_START_DOWNLOAD;
                                } else if (!f8807Hf) {
                                    enumC2294y = EnumC2294y.MODE_SPEED_COM;
                                }
                            } else if (b4 == 114) {
                                if ((bArr[i3 + 4] & 160) != 160) {
                                    return;
                                }
                                f8930ge = (byte) 0;
                                MainActivity.f7268u9 = false;
                            } else if (b4 == 118) {
                                int i21 = MainActivity.f7169j7 + (f8807Hf ? 136 : 38);
                                MainActivity.f7169j7 = i21;
                                f8783Cg.m8793r9(i21, ActivityC2225t.f8440Bd.length, f8825Ld);
                                if (MainActivity.f7169j7 < ActivityC2225t.f8440Bd.length) {
                                    m9244ue();
                                    return;
                                }
                                enumC2294y = EnumC2294y.MODE_DOWNLOAD_EXIT;
                            } else {
                                if (b4 != 119) {
                                    if (b4 == 126) {
                                        ActivityC2266vc.f8571Cd = 0;
                                        m9129Mc();
                                        return;
                                    }
                                    if (b4 == 127) {
                                        int i22 = i3 + 4;
                                        byte b10 = bArr[i22];
                                        if (b10 == 26) {
                                            int i23 = f8960ne;
                                            f8960ne = i23 + 1;
                                            if (i23 <= 1) {
                                                return;
                                            }
                                            f8783Cg.m8786o8();
                                            return;
                                        }
                                        if (b10 != 33) {
                                            if (b10 == 35) {
                                                byte b11 = bArr[i3 + 5];
                                                if (b11 == 51) {
                                                    if (f8867Tf) {
                                                        f8778Bg.m9079Tb(EnumC2281x.ERR_TIMEOUT);
                                                        return;
                                                    }
                                                    return;
                                                } else {
                                                    if (b11 != 66 || !f8867Tf) {
                                                        return;
                                                    }
                                                    activityC2266vc = f8778Bg;
                                                    enumC2281x = EnumC2281x.ERR_FAILED;
                                                }
                                            } else {
                                                if (b10 != 39) {
                                                    if (b10 == 49) {
                                                        int i24 = i3 + 5;
                                                        if ((bArr[i24] & 255) == 18) {
                                                            m9139Oe(true);
                                                            return;
                                                        }
                                                        if ((bArr[i24] & 255) == 130) {
                                                            m9135Ne(EnumC2294y.MODE_NULL);
                                                            String strM9079Tb3 = f8778Bg.m9079Tb(EnumC2281x.ERR_CHECKSUM);
                                                            MainActivity.f6969N4 = false;
                                                            f8783Cg.m8734K9(null, null, strM9079Tb3, 0, 2, 2, 19);
                                                            return;
                                                        }
                                                        i17 = (bArr[i24] & 255) == 145 ? 500 : 0;
                                                        if (!f8926ff) {
                                                            return;
                                                        } else {
                                                            b3 = bArr[i22];
                                                        }
                                                    } else {
                                                        if (b10 != 54) {
                                                            if (b10 == 55 && f8926ff) {
                                                                m9259ze(bArr[i22], 250);
                                                                return;
                                                            }
                                                            return;
                                                        }
                                                        if (f8926ff) {
                                                            b3 = bArr[i22];
                                                        }
                                                    }
                                                    m9259ze(b3, i17);
                                                    return;
                                                }
                                                if (f8857Rf || f8867Tf) {
                                                    activityC2266vc = f8778Bg;
                                                    enumC2281x = EnumC2281x.ERR_AUTHENTIFY;
                                                } else {
                                                    f8845Pd = (byte) (f8845Pd + 1);
                                                    if (!(MainActivity.f6862B5 | MainActivity.f6871C5)) {
                                                        ActivityC2266vc.f8576Hd = 2;
                                                    }
                                                    m9212kc(4000);
                                                    ActivityC2266vc.m9072Ub(8);
                                                    enumC2294y = EnumC2294y.MODE_NULL;
                                                }
                                            }
                                            strM9079Tb2 = activityC2266vc.m9079Tb(enumC2281x);
                                            mainActivity2 = f8783Cg;
                                            str2 = null;
                                            strArr2 = null;
                                            i11 = 0;
                                            i12 = 2;
                                            i13 = 2;
                                            i14 = 14;
                                        } else {
                                            strM9079Tb2 = f8778Bg.m9079Tb(EnumC2281x.ERR_PSESSION);
                                            mainActivity2 = f8783Cg;
                                            str2 = null;
                                            strArr2 = null;
                                            i11 = 0;
                                            i12 = 2;
                                            i13 = 2;
                                            i14 = 11;
                                        }
                                        mainActivity2.m8734K9(str2, strArr2, strM9079Tb2, i11, i12, i13, i14);
                                        f8992vd = EnumC2294y.MODE_NULL;
                                        LedBar.m8101n(false);
                                        return;
                                    }
                                    switch (b4) {
                                        case 97:
                                            if (bArr[i3 + 4] == -128) {
                                                MainActivity.f6900F7 = 0;
                                                ActivityC2266vc.f8576Hd = 0;
                                                f8980se = (bArr[i3 + 17] << 16) | ((bArr[i3 + 18] & 255) << 8) | (bArr[i3 + 19] & 255);
                                                int i25 = (bArr[i3 + 31] << 16) | ((bArr[i3 + 32] & 255) << 8) | (bArr[i3 + 33] & 255);
                                                int i26 = (bArr[i3 + 23] << 16) | (bArr[i3 + 24] << 8) | (bArr[i3 + 25] & 255);
                                                System.arraycopy(bArr, i3 + 20, f8905be, 8, 16);
                                                int i27 = f8980se;
                                                if ((16711680 & i27) != 2097152) {
                                                    z = false;
                                                } else if (((i27 >> 8) > 8194) || ((i27 & 1) > 0)) {
                                                    z = true;
                                                } else {
                                                    z = false;
                                                }
                                                f8877Vf = z;
                                                if (z) {
                                                    int iM9037kc = ActivityC2225t.m9037kc(i27, i26 & 65535);
                                                    f8811Ie = iM9037kc;
                                                    f8877Vf = iM9037kc > 0;
                                                }
                                                if (f8877Vf) {
                                                    i15 = 65535;
                                                } else {
                                                    byte[] bArr3 = f8905be;
                                                    i15 = bArr3[23] & bArr3[14] & bArr3[15] & bArr3[22] & 65535;
                                                }
                                                f8993ve = (bArr[i3 + 37] & 255) | ((bArr[i3 + 36] & 255) << 8);
                                                String[] strArr3 = f8860Sd;
                                                if (strArr3[64] != null) {
                                                    f8796Fe = strArr3[64];
                                                }
                                                byte[] bArr4 = f8905be;
                                                strArr3[72] = Integer.toHexString(((bArr4[22] << 8) | (bArr4[23] & 255)) & 65535);
                                                MainActivity.m8169Ab(21, Integer.toHexString(f8980se));
                                                MainActivity.m8169Ab(24, Integer.toHexString(i26));
                                                MainActivity.m8169Ab(23, strArr3[72]);
                                                if (!f8857Rf) {
                                                    boolean z7 = f8942ig;
                                                    EnumC2294y enumC2294y2 = f8992vd;
                                                    EnumC2294y enumC2294y3 = EnumC2294y.MODE_NULL;
                                                    if (z7 && (enumC2294y2 != enumC2294y3)) {
                                                        if (i26 != 0 && (i26 & 65535) != 65535) {
                                                            f8992vd = enumC2294y3;
                                                        }
                                                        f8783Cg.m8786o8();
                                                    } else if (f8867Tf) {
                                                        f8835Nd = (byte) (f8926ff ? 131 : 5);
                                                        if ((i15 != 65535) & (!f8882Wf)) {
                                                            f8872Uf = false;
                                                            f8992vd = enumC2294y3;
                                                            f8778Bg.m9079Tb(EnumC2281x.ERR_NULL);
                                                            f8783Cg.m8800x5();
                                                        }
                                                    } else if (MainActivity.f7019S9) {
                                                        m9251xc(i25, i26);
                                                        MainActivity.f7028T9 = false;
                                                        MainActivity.f6939Ja = 0;
                                                        f8847Pf = f8926ff;
                                                        if (MainActivity.f6862B5 || MainActivity.f6871C5) {
                                                            f8783Cg.m8805y8(false);
                                                        } else {
                                                            f8992vd = enumC2294y3;
                                                            m9254yc(51);
                                                        }
                                                    }
                                                } else {
                                                    int iM9038lc = ActivityC2225t.m9038lc(f8905be, 20, -1, null);
                                                    String str3 = (iM9038lc <= 12) & (iM9038lc >= 8) ? "%06x" : "%x";
                                                    f8926ff = MainActivity.f7133f7 < 16;
                                                    f8865Td = String.format(str3, Integer.valueOf(i25));
                                                    if (ActivityC2225t.m9000Lb(f8980se, 0, null) >= 4) {
                                                        f8857Rf = false;
                                                        m9135Ne(EnumC2294y.MODE_NULL);
                                                        strM9079Tb = f8778Bg.m9079Tb(EnumC2281x.ERR_VERSION_MAP);
                                                        mainActivity = f8783Cg;
                                                        str = null;
                                                        strArr = null;
                                                        i5 = 0;
                                                        i6 = 2;
                                                        i7 = 1;
                                                        i8 = 8;
                                                        mainActivity.m8734K9(str, strArr, strM9079Tb, i5, i6, i7, i8);
                                                    } else {
                                                        f8847Pf = false;
                                                        boolean z8 = f8926ff;
                                                        f8835Nd = (byte) (z8 ? 133 : 5);
                                                        if (!z8 && i15 == 65535) {
                                                        }
                                                        enumC2294y = EnumC2294y.MODE_ACCESS;
                                                    }
                                                }
                                                f8872Uf = true;
                                                enumC2294y = EnumC2294y.MODE_ACCESS;
                                            }
                                            break;
                                        case 98:
                                            short[] sArr = f8873Ug;
                                            if ((sArr != null) & (sArr == f8868Tg)) {
                                                int i28 = 0;
                                                while (true) {
                                                    short[] sArr2 = f8873Ug;
                                                    if (i28 < sArr2.length / 2) {
                                                        int i29 = i28 * 2;
                                                        boolean z9 = sArr2[i29] == f8798Fg;
                                                        int i30 = i29 + 1;
                                                        if (z9 & (sArr2[i30] < 4)) {
                                                            sArr2[i30] = 3;
                                                        }
                                                        i28++;
                                                    }
                                                }
                                            }
                                            if (f8957mf) {
                                                m9111He(MainActivity.f7116d8);
                                                break;
                                            } else if (f8956me > 0) {
                                                m9091Ce(20);
                                                enumC2294y = EnumC2294y.MODE_READ_CODES;
                                                break;
                                            } else if (f8952le > 0) {
                                                m9186bd();
                                                break;
                                            } else if (MainActivity.f7268u9) {
                                                m9235re();
                                                break;
                                            } else if (f8887Xf) {
                                                m9103Fe(null, 0, MainActivity.f7178k7);
                                                break;
                                            } else if (f8892Yf) {
                                                m9215lc(false);
                                                break;
                                            } else {
                                                m9217le();
                                                f8788Dg.m8890Cb(bArr, i3 + 4);
                                                if (MainActivity.f7304y9) {
                                                    MainActivity.m8546jb(false);
                                                }
                                                if (MainActivity.f6866B9 && System.currentTimeMillis() > MainActivity.f6903Fa) {
                                                    f8783Cg.m8746Sa(4, false);
                                                    if (f8930ge == -112) {
                                                        MainActivity.f7268u9 = true;
                                                    }
                                                    break;
                                                } else if (MainActivity.f7313z9 && System.currentTimeMillis() > MainActivity.f6903Fa) {
                                                    f8783Cg.m8756b5(20, f8925fe);
                                                    break;
                                                }
                                            }
                                            break;
                                        case 99:
                                            int i31 = f8826Le;
                                            if (i31 < 0) {
                                                if ((!f8977rf && !f8969pf) && !f8973qf) {
                                                    if (f8822Kf) {
                                                        int i32 = i3 + 10;
                                                        if ((f8800Gd == 0) && (MainActivity.m8498f5(bArr, i32, 2) != 4357)) {
                                                            f8800Gd = 1;
                                                            i10 = 16384;
                                                        } else if ((f8800Gd == 1) && (MainActivity.m8498f5(bArr, i32, 2) != 4357)) {
                                                            f8800Gd = 2;
                                                            i10 = 23552;
                                                        } else if ((f8800Gd == 2) && (MainActivity.m8498f5(bArr, i32, 2) != 4357)) {
                                                            f8800Gd = 255;
                                                            i10 = 24320;
                                                        } else if (!f8937hg) {
                                                            enumC2294y = EnumC2294y.MODE_READ_ECU_INFOS;
                                                        } else {
                                                            int i33 = i3 + 17;
                                                            int i34 = i3 + 18;
                                                            int i35 = i3 + 20;
                                                            int i36 = i3 + 24;
                                                            MainActivity.m8169Ab(22, Integer.toHexString((bArr[i36] & 255) | (bArr[i33] << 32) | (bArr[i34] << 16) | (bArr[i35] << 8)));
                                                        }
                                                    } else if (f8877Vf && f8816Je == f8811Ie + 24576) {
                                                        if (bArr[i3 + 35] == 0) {
                                                            m9135Ne(EnumC2294y.MODE_NULL);
                                                            strM9079Tb = f8778Bg.m9079Tb(EnumC2281x.PROTECTED_MAP);
                                                            mainActivity = f8783Cg;
                                                            str = null;
                                                            strArr = null;
                                                            i5 = 0;
                                                            i6 = 2;
                                                            i7 = 1;
                                                        }
                                                        i10 = 327680;
                                                    } else {
                                                        int i37 = bArr[i3 + 29] == 2 ? 8 : 0;
                                                        int i38 = (bArr[i3 + 35] & 255) | (bArr[i3 + 34] << 8);
                                                        byte[] bArr5 = f8905be;
                                                        int i39 = i37 + 14;
                                                        int i40 = i37 + 15;
                                                        int i41 = i38 & ((bArr5[i39] << 8) | (bArr5[i40] & 255));
                                                        bArr5[i39] = (byte) (i41 >> 8);
                                                        bArr5[i40] = (byte) i41;
                                                        if (f8882Wf && (f8851Qe == ((bArr5[23] & 255) | (bArr5[22] << 8)))) {
                                                            f8816Je = MainActivity.f6936J7;
                                                            f8826Le = MainActivity.f6945K7;
                                                            enumC2294y = EnumC2294y.MODE_READ_MEM;
                                                        } else if (i37 == 8) {
                                                            i10 = 393216;
                                                        } else if (!f8857Rf) {
                                                            f8992vd = EnumC2294y.MODE_NULL;
                                                            f8778Bg.m9079Tb(EnumC2281x.ERR_NULL);
                                                            f8783Cg.m8800x5();
                                                        } else {
                                                            if (MainActivity.f7115d7 <= 0 || (ActivityC2225t.f8481Yd[0] & 4095) != 80 ? !(f8937hg || MainActivity.m8498f5(f8905be, 20, 4) != MainActivity.m8498f5(ActivityC2225t.f8446Ed, 20, 4)) : !(f8954lg || (f8877Vf && ActivityC2225t.f8442Cd[f8811Ie + 24575] == 0))) {
                                                                z2 = false;
                                                            }
                                                            f8842Of = z2;
                                                            m9119Je();
                                                            enumC2294y = EnumC2294y.MODE_START_PROG;
                                                        }
                                                    }
                                                    m9107Ge(i10, 32, -32);
                                                    break;
                                                } else {
                                                    int i42 = f8800Gd;
                                                    if (i42 != 0) {
                                                        if (i42 == 1) {
                                                            f8800Gd = 2;
                                                            System.arraycopy(bArr, i3 + 4, f8920ee, 16, 2);
                                                            i10 = 262144;
                                                        } else if (i42 == 2) {
                                                            f8800Gd = 255;
                                                            byte[] bArr6 = f8920ee;
                                                            System.arraycopy(bArr, i3 + 4, bArr6, 96, 32);
                                                            if (f8977rf) {
                                                                f8773Ag = ActivityC2225t.m9028bc(bArr6, 16, false);
                                                            }
                                                            if (f8773Ag.equals("")) {
                                                                f8860Sd[64] = m9124Lb(bArr6, 107, 17, true, false);
                                                            }
                                                            i10 = 24096;
                                                        } else if (!f8937hg) {
                                                            enumC2294y = EnumC2294y.MODE_READ_ECU_INFOS;
                                                        } else {
                                                            int i43 = i3 + 17;
                                                            int i44 = i3 + 18;
                                                            int i45 = i3 + 20;
                                                            int i46 = i3 + 24;
                                                            MainActivity.m8169Ab(22, Integer.toHexString((bArr[i46] & 255) | (bArr[i43] << 32) | (bArr[i44] << 16) | (bArr[i45] << 8)));
                                                        }
                                                        m9107Ge(i10, 32, -32);
                                                    } else {
                                                        f8800Gd = 1;
                                                        m9107Ge(262144, 4, -112);
                                                    }
                                                }
                                                break;
                                            } else {
                                                byte[] bArr7 = f8900ae;
                                                int i47 = i3 + 4;
                                                if (bArr7 == null) {
                                                    System.arraycopy(bArr, i47, ActivityC2225t.f8442Cd, f8826Le + (MainActivity.f7180k9 ? f8816Je : (f8816Je & 65535) | ActivityC2225t.f8477Ud), f8841Oe);
                                                } else {
                                                    System.arraycopy(bArr, i47, bArr7, i31, f8841Oe);
                                                }
                                                int i48 = f8821Ke;
                                                int i49 = f8841Oe;
                                                f8821Ke = i48 + i49;
                                                f8826Le += i49;
                                                f8836Ne = 0;
                                                f8882Wf = false;
                                                ActivityC2266vc.f8574Fd = 0;
                                                if (f8900ae == null) {
                                                    f8826Le = ActivityC2225t.m9050xc(f8816Je, f8826Le);
                                                    f8783Cg.m8793r9(f8821Ke, f8831Me, f8825Ld);
                                                }
                                                ActivityC2266vc.f8571Cd = 0;
                                                if (f8821Ke < f8831Me && !f8958mg) {
                                                    m9178Yd();
                                                } else {
                                                    m9135Ne(EnumC2294y.MODE_NULL);
                                                    if (!f8958mg) {
                                                        f8783Cg.m8734K9(null, null, f8778Bg.m9079Tb(EnumC2281x.END_READ), 0, 3, 2, f8982sg ? 19 : 14);
                                                        f8783Cg.m8781mb();
                                                    } else {
                                                        strM9079Tb = f8778Bg.m9079Tb(EnumC2281x.ERR_ABORT);
                                                        mainActivity = f8783Cg;
                                                        str = null;
                                                        strArr = null;
                                                        i5 = 0;
                                                        i6 = 3;
                                                        i7 = 2;
                                                        if (f8982sg) {
                                                        }
                                                        mainActivity.m8734K9(str, strArr, strM9079Tb, i5, i6, i7, i8);
                                                    }
                                                }
                                            }
                                            i8 = 10;
                                            mainActivity.m8734K9(str, strArr, strM9079Tb, i5, i6, i7, i8);
                                            break;
                                    }
                                }
                                enumC2294y = f8807Hf ? EnumC2294y.MODE_ECU_RESET : EnumC2294y.MODE_END_PROG;
                            }
                            m9217le();
                            return;
                        }
                        f8956me = 0;
                        m9212kc(250);
                        if (!(MainActivity.f6862B5 | MainActivity.f6871C5)) {
                            i4 = ActivityC2266vc.f8572Dd - 1;
                        }
                        m9194ec(bArr, i3 + 4, i4);
                        f8783Cg.m8788p8(f8808Hg > 0, true);
                        if (!MainActivity.f6862B5 && !MainActivity.f6871C5) {
                            return;
                        }
                        if (MainActivity.f6925I5) {
                            m9206ic();
                        }
                        enumC2294y = EnumC2294y.MODE_READ_SENSORS;
                    } else {
                        if (bArr[i3 + 4] != 68) {
                            return;
                        }
                        if (f8807Hf) {
                            m9212kc(500);
                            enumC2294y = EnumC2294y.MODE_START_PROG;
                        } else {
                            m9212kc(340);
                        }
                    }
                    enumC2294y = EnumC2294y.MODE_DOWNLOAD;
                }
                i8 = 19;
                mainActivity.m8734K9(str, strArr, strM9079Tb, i5, i6, i7, i8);
                return;
            }
            f8840Od = (byte) 0;
            byte b12 = bArr[i3 + 4];
            if (b12 != 74) {
                switch (b12) {
                    case -128:
                        m9212kc(600);
                        if (f8867Tf) {
                            enumC2294y = EnumC2294y.MODE_READ_MEM;
                        } else if (!f8926ff) {
                            enumC2294y = EnumC2294y.MODE_START_DOWNLOAD;
                        } else {
                            enumC2294y = EnumC2294y.MODE_START_PROG;
                        }
                        break;
                    case -127:
                        f8778Bg.m9078Rb(57600, true);
                        m9212kc(100);
                        if (!f8867Tf) {
                            enumC2294y = EnumC2294y.MODE_START_PROG;
                        } else {
                            enumC2294y = EnumC2294y.MODE_READ_MEM;
                        }
                        break;
                    case -126:
                        f8778Bg.m9078Rb(62600, true);
                        m9212kc(600);
                        if (!f8867Tf) {
                            enumC2294y = EnumC2294y.MODE_START_DOWNLOAD;
                        } else {
                            enumC2294y = EnumC2294y.MODE_READ_MEM;
                        }
                        break;
                }
            }
            if (bArr[i3 + 5] == -126) {
                f8778Bg.m9078Rb(62500, true);
            }
            m9212kc(60);
            if (f8867Tf) {
                enumC2294y = EnumC2294y.MODE_READ_MEM;
            } else {
                enumC2294y = EnumC2294y.MODE_START_DOWNLOAD;
            }
            m9135Ne(enumC2294y);
        }
    }

    /* JADX INFO: renamed from: Fd */
    private static void m9102Fd(int i) {
        byte[] bArr = new byte[5];
        bArr[0] = 4;
        bArr[1] = 46;
        bArr[2] = 1;
        bArr[3] = 6;
        bArr[4] = (byte) (i == 1 ? 0 : 255);
        m9098Ed(bArr, -1, false);
    }

    /* JADX INFO: renamed from: Fe */
    public static void m9103Fe(byte[] bArr, int i, int i2) {
        if (bArr == null) {
            i = ActivityC2225t.f8450Gd[0];
        }
        f8816Je = i;
        if (f8931gf | f8986tg) {
            bArr = new byte[f8841Oe];
        }
        f8900ae = bArr;
        f8831Me = i2;
        MainActivity.f7169j7 = 0;
        f8821Ke = 0;
        f8826Le = 0;
        f8867Tf = true;
        f8882Wf = false;
        f8887Xf = false;
        f8982sg = f8911cf;
        byte[] bArr2 = f8905be;
        f8851Qe = (bArr2[23] & 255) | (bArr2[22] << 8);
        f9002xd = 0;
        if (f8881We) {
            f8876Ve = false;
        }
        if (f8876Ve) {
            m9125Lc(MainActivity.f7285w8);
        } else if (f8827Lf) {
            m9109Hc();
        } else if (f8837Nf) {
            f8835Nd = (byte) -5;
            m9117Jc();
        } else if (f8931gf || f8986tg) {
            m9135Ne(EnumC2294y.MODE_WALBRO_BREAK);
        } else {
            m9131Me(true);
        }
        f8783Cg.m8787o9();
    }

    /* JADX INFO: renamed from: Gc */
    static /* synthetic */ void m9105Gc(byte[] bArr) {
        try {
            Thread.sleep(250L);
            m9098Ed(bArr, -1, false);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    /* JADX INFO: renamed from: Gd */
    private static void m9106Gd(int i) {
        byte[] bArr = new byte[7];
        bArr[0] = 6;
        bArr[1] = 39;
        bArr[2] = 4;
        for (int i2 = 0; i2 < 4; i2++) {
            bArr[i2 + 3] = (byte) ((i >> (i2 * 8)) & 255);
        }
        m9098Ed(bArr, -1, false);
    }

    /* JADX INFO: renamed from: Ge */
    private static void m9107Ge(int i, int i2, int i3) {
        f8816Je = i;
        f8841Oe = i2;
        f8826Le = i3;
        m9135Ne(EnumC2294y.MODE_READ_MEM);
    }

    /* JADX INFO: renamed from: Hb */
    public static void m9108Hb(boolean z, int i) {
        MainActivity.f7268u9 = false;
        MainActivity.f7277v9 = false;
        f8960ne = 0;
        f8930ge = (byte) 0;
        f8998we = 0;
        if (z) {
            f8783Cg.m8756b5(i, 0);
        }
        m9217le();
    }

    /* JADX INFO: renamed from: Hc */
    private static void m9109Hc() {
        f8835Nd = (byte) (f8797Ff | f8802Gf ? 3 : 1);
        f8805Hd = -1;
        f8942ig = false;
        m9135Ne(EnumC2294y.MODE_HIGH_SPEED);
    }

    /* JADX INFO: renamed from: Hd */
    private static void m9110Hd() {
        int[] iArr = MainActivity.f7111cc;
        m9098Ed(new byte[]{5, 46, 1, 33, (byte) (iArr[0] >> 8), (byte) (iArr[0] & 255)}, -1, false);
    }

    /* JADX INFO: renamed from: He */
    public static void m9111He(int i) throws CloneNotSupportedException {
        int i2;
        short[] sArr;
        Object objClone;
        f8935he = 0;
        f8957mf = false;
        if (f8817Jf) {
            i2 = 24;
        } else if (f8837Nf) {
            i2 = 20;
        } else if (f8827Lf) {
            i2 = 16;
        } else if (f8871Ue) {
            i2 = 12;
        } else if (f8926ff) {
            i2 = 8;
        } else {
            i2 = f8807Hf ? 4 : 0;
        }
        int i3 = i + i2;
        switch (i3) {
            case 0:
                f8873Ug = (short[]) f8878Vg.clone();
                if (f9010yg) {
                    int i4 = 0;
                    while (true) {
                        short[] sArr2 = f8873Ug;
                        if (i4 < sArr2.length / 2) {
                            int i5 = i4 * 2;
                            if (sArr2[i5] == 1) {
                                sArr2[i5] = 376;
                            }
                            i4++;
                        }
                    }
                }
                f8873Ug[8] = (short) (f8812If ? 400 : 20739);
                break;
            case 1:
                short[] sArr3 = (short[]) (f8921ef ? f8913ch.clone() : f8903ah.clone());
                f8868Tg = sArr3;
                f8873Ug = sArr3;
                if (f9010yg) {
                    int i6 = 0;
                    while (true) {
                        short[] sArr4 = f8873Ug;
                        if (i6 < sArr4.length / 2) {
                            int i7 = i6 * 2;
                            if (sArr4[i7] == 1) {
                                sArr4[i7] = 376;
                            }
                            i6++;
                        }
                    }
                }
                if (!f8921ef) {
                    f8873Ug[62] = (short) (f8812If ? 400 : 20739);
                }
                break;
            case 2:
                if (f8917dg) {
                    sArr = f8955lh;
                } else {
                    sArr = (short[]) (f8921ef ? f8959mh.clone() : f8949kf ? f8963nh.clone() : f8947jh.clone());
                }
                f8868Tg = sArr;
                f8873Ug = sArr;
                break;
            case 3:
                short[] sArr5 = SensorView.f7625k0;
                f8868Tg = sArr5;
                f8873Ug = sArr5;
                break;
            case 4:
                f8873Ug = (short[]) (f8906bf ? f8893Yg.clone() : f8888Xg.clone());
                break;
            case 5:
                if (f8906bf) {
                    objClone = f8928fh.clone();
                } else if (((f8901af | f8896Ze | f8977rf | f8969pf) || f8973qf) || f8911cf) {
                    objClone = f8933gh.clone();
                } else {
                    objClone = f8891Ye ? f8923eh.clone() : f8918dh.clone();
                }
                f8868Tg = (short[]) objClone;
                int i8 = 0;
                while (true) {
                    short[] sArr6 = f8868Tg;
                    if (i8 >= sArr6.length / 2) {
                        f8873Ug = sArr6;
                    } else {
                        int i9 = i8 * 2;
                        if (sArr6[i9] == 64) {
                            sArr6[i9 + 1] = (short) (f8901af | f8896Ze ? 0 : 3);
                        }
                        i8++;
                    }
                    break;
                }
                break;
            case 6:
                short[] sArr7 = (short[]) (f8906bf ? f8967oh.clone() : ((((f8901af | f8896Ze) | f8977rf) | f8969pf) | f8973qf) | f8911cf ? f8971ph.clone() : f8963nh.clone());
                f8868Tg = sArr7;
                f8873Ug = sArr7;
                break;
            case 7:
                short[] sArr8 = SensorView.f7625k0;
                f8868Tg = sArr8;
                f8873Ug = sArr8;
                break;
            case 8:
                short[] sArr9 = f8898Zg;
                sArr9[9] = (short) (!f8927fg ? 1 : 0);
                f8873Ug = (short[]) sArr9.clone();
                break;
            case 9:
                short[] sArr10 = (short[]) (f8866Te ? f8943ih.clone() : f8938hh.clone());
                f8868Tg = sArr10;
                f8873Ug = sArr10;
                break;
            case 10:
                short[] sArr11 = f8975qh;
                sArr11[5] = (short) (!f8927fg ? 1 : 0);
                short[] sArr12 = (short[]) sArr11.clone();
                f8868Tg = sArr12;
                f8873Ug = sArr12;
                break;
            case 11:
                short[] sArr13 = SensorView.f7625k0;
                f8868Tg = sArr13;
                f8873Ug = sArr13;
                break;
            case 12:
                f8873Ug = (short[]) f8979rh.clone();
                break;
            case 13:
                short[] sArr14 = (short[]) f8983sh.clone();
                f8868Tg = sArr14;
                f8873Ug = sArr14;
                break;
            case 14:
                short[] sArr15 = (short[]) f8987th.clone();
                f8868Tg = sArr15;
                f8873Ug = sArr15;
                break;
            case 15:
                short[] sArr16 = SensorView.f7625k0;
                f8868Tg = sArr16;
                f8873Ug = sArr16;
                break;
            case 16:
                f8873Ug = f8797Ff | f8802Gf ? f9006xh : (short[]) f8991uh.clone();
                break;
            case 17:
                short[] sArr17 = f8797Ff | f8802Gf ? f9011yh : (short[]) f8996vh.clone();
                f8868Tg = sArr17;
                f8873Ug = sArr17;
                break;
            case 18:
                short[] sArr18 = f8797Ff | f8802Gf ? f9016zh : (short[]) f9001wh.clone();
                f8868Tg = sArr18;
                f8873Ug = sArr18;
                break;
            case 19:
                short[] sArr19 = SensorView.f7625k0;
                f8868Tg = sArr19;
                f8873Ug = sArr19;
                break;
            case 20:
                f8873Ug = (short[]) f8774Ah.clone();
                break;
            case 21:
                short[] sArr20 = (short[]) f8779Bh.clone();
                f8868Tg = sArr20;
                f8873Ug = sArr20;
                break;
            case 22:
                short[] sArr21 = (short[]) f8784Ch.clone();
                f8868Tg = sArr21;
                f8873Ug = sArr21;
                break;
            case 23:
                f8868Tg = null;
                f8873Ug = null;
                break;
            case 24:
                f8873Ug = (short[]) f8883Wg.clone();
                break;
            case 25:
                short[] sArr22 = (short[]) f8908bh.clone();
                f8868Tg = sArr22;
                f8873Ug = sArr22;
                break;
            case 26:
                short[] sArr23 = (short[]) f8951kh.clone();
                f8868Tg = sArr23;
                f8873Ug = sArr23;
                break;
            case 27:
                short[] sArr24 = SensorView.f7625k0;
                f8868Tg = sArr24;
                f8873Ug = sArr24;
                break;
        }
        if (f8873Ug != null) {
            int i10 = 0;
            while (true) {
                short[] sArr25 = f8873Ug;
                if (i10 < sArr25.length / 2) {
                    int i11 = (i10 * 2) + 1;
                    if (sArr25[i11] == 7) {
                        sArr25[i11] = (short) (MainActivity.f7150h6 ? 0 : 3);
                    }
                    short[] sArr26 = f8873Ug;
                    if (sArr26[i11] % 4 > 0) {
                        sArr26[i11] = 3;
                    } else if (i3 % 4 == 2) {
                        f8873Ug[i11] = (short) (((MainActivity.f7125e8 >> i10) & 1) * 3);
                    }
                    i10++;
                }
            }
        }
        f8793Eg.setCloseLoop(false);
        f8793Eg.setAdapt(false);
        f8793Eg.setBalanced(0);
    }

    /* JADX INFO: renamed from: Ib */
    private static void m9112Ib(byte[] bArr, int i, byte[] bArr2, int i2, int i3) {
        try {
            System.arraycopy(bArr, i, bArr2, i2, i3);
        } catch (Exception e) {
            if (f8785Dd) {
                Log.e("ISORead", Log.getStackTraceString(e));
            }
        }
    }

    /* JADX INFO: renamed from: Ic */
    private static void m9113Ic() {
        boolean z = f8797Ff;
        boolean z2 = f8802Gf;
        f8835Nd = (byte) (z | z2 ? 3 : 1);
        f8805Hd = -1;
        f8942ig = false;
        f8892Yf = false;
        f8867Tf = false;
        f8842Of = true;
        f9002xd = 0;
        f9012zd = 25;
        if (!f8954lg || !(z | z2) || (MainActivity.f7133f7 & 61440) != 8192) {
            if (ActivityC2225t.m9000Lb(f8980se, 0, null) >= 4) {
                m9155Se(f8860Sd[62]);
                return;
            }
            f8857Rf = true;
        }
        m9135Ne(EnumC2294y.MODE_HIGH_SPEED);
    }

    /* JADX INFO: renamed from: Id */
    private static void m9114Id(int i) {
        m9098Ed(new byte[]{39, (byte) (f8835Nd + 1), (byte) (i / 256), (byte) (i & 255)}, f9007yd == 247 ? 6 : -1, false);
    }

    /* JADX INFO: renamed from: Ie */
    private static void m9115Ie(int i, int i2) {
        for (int i3 = 0; i3 < 3; i3++) {
            int iM9128Mb = m9128Mb((byte) ((i >> (i3 * 8)) & 255));
            byte[] bArr = f8904ai;
            int i4 = i3 * 2;
            bArr[9 - i4] = (byte) iM9128Mb;
            bArr[8 - i4] = (byte) (iM9128Mb >> 8);
        }
        int iM9128Mb2 = m9128Mb((byte) i2);
        byte[] bArr2 = f8904ai;
        bArr2[11] = (byte) iM9128Mb2;
        bArr2[10] = (byte) (iM9128Mb2 >> 8);
    }

    /* JADX INFO: renamed from: Jb */
    private static String m9116Jb(byte[] bArr, int i, int i2) {
        StringBuilder sb = new StringBuilder();
        for (int i3 = i; i3 < i + i2; i3++) {
            if ((((bArr[i3] < 48) & (bArr[i3] != 46)) | ((bArr[i3] > 90) & (bArr[i3] != 95) & (bArr[i3] != 118))) || ((bArr[i3] > 57) & (bArr[i3] < 65))) {
                break;
            }
            sb.append((char) bArr[i3]);
        }
        return sb.toString();
    }

    @SuppressLint({"DefaultLocale"})
    /* JADX INFO: renamed from: Jc */
    public static void m9117Jc() {
        f9007yd = 0;
        f8964oe = 0;
        f8942ig = false;
        f8827Lf = f8902ag;
        f8837Nf = f8907bg;
        f8912cg = false;
        LedBar.m8101n(true);
        LedBar.m8097j(0);
        MainActivity.m8169Ab(f8827Lf ? 12 : 13, "");
        MainActivity.m8169Ab(15, String.format("%d", Integer.valueOf(f9012zd)));
        ActivityC2266vc.f8584Pd = 25;
        f8778Bg.m9078Rb(10400, true);
        ActivityC2266vc.m9071Sb((byte) 0);
        SystemClock.sleep(f9012zd);
        ActivityC2266vc.m9071Sb((byte) 1);
        m9135Ne(EnumC2294y.MODE_INIT);
    }

    /* JADX INFO: renamed from: Jd */
    private static void m9118Jd(int i) {
        m9098Ed(new byte[]{39, 3, 2, (byte) (i / 256), (byte) (i & 255)}, 7, false);
    }

    /* JADX INFO: renamed from: Je */
    private static void m9119Je() {
        MainActivity.f7187l7 = f8807Hf ? 128 : 32;
        if (f8842Of) {
            ActivityC2225t.m8994Ib();
        } else {
            ActivityC2225t.m8990Gb();
        }
    }

    /* JADX INFO: renamed from: Kb */
    private static String m9120Kb(byte[] bArr, int i, int i2, String str) {
        StringBuilder sb = new StringBuilder();
        for (int i3 = i; i3 < i + i2; i3++) {
            if (i3 != i || str.equals("") || bArr[i3] <= 90) {
                if ((((bArr[i3] > 90) & (bArr[i3] != 95) & (bArr[i3] != 118)) | (bArr[i3] < 48)) || ((bArr[i3] > 57) & (bArr[i3] < 65))) {
                    break;
                }
                sb.append((char) bArr[i3]);
            }
        }
        return sb.toString();
    }

    /* JADX WARN: Code restructure failed: missing block: B:104:0x01ca, code lost:
    
        if (com.tuneecu.ActivityC2307z.f8835Nd == (-2)) goto L105;
     */
    /* JADX WARN: Code restructure failed: missing block: B:105:0x01cc, code lost:
    
        m9107Ge(524320, 16, -16);
     */
    /* JADX WARN: Code restructure failed: missing block: B:106:0x01d1, code lost:
    
        m9131Me(true);
     */
    /* JADX WARN: Code restructure failed: missing block: B:110:0x01e9, code lost:
    
        if (com.tuneecu.ActivityC2307z.f8835Nd == (-3)) goto L105;
     */
    /* JADX WARN: Code restructure failed: missing block: B:160:?, code lost:
    
        return;
     */
    /* JADX WARN: Code restructure failed: missing block: B:161:?, code lost:
    
        return;
     */
    /* JADX INFO: renamed from: Kc */
    /*
        Code decompiled incorrectly, please refer to instructions dump.
    */
    private static void m9121Kc(byte[] bArr, int i, int i2) throws Throwable {
        EnumC2294y enumC2294y;
        int i3;
        if (m9168Wb(bArr, i, i2)) {
            byte b2 = bArr[i + 3];
            if (b2 != 84) {
                if (b2 == 88) {
                    f8956me = 0;
                    short s = (short) (bArr[i + 4] & 255);
                    f8803Gg = s;
                    f8783Cg.m8788p8(s > 0, false);
                    if (MainActivity.f6925I5) {
                        m9091Ce(f8803Gg);
                        m9233rc(bArr, i + 5);
                        m9206ic();
                    }
                } else {
                    if (b2 == 90) {
                        byte b3 = bArr[i + 4];
                        if (b3 == -122) {
                            String[] strArr = f8860Sd;
                            strArr[63] = "";
                            strArr[65] = m9124Lb(bArr, i + 15, 3, false, false);
                            MainActivity.m8169Ab(20, strArr[65]);
                        } else {
                            if (b3 == -118) {
                                MainActivity.f6930Ia = 6;
                                MainActivity.m8169Ab(18, "");
                                MainActivity.f6889E5 = true;
                                LedBar.m8097j(2);
                                f8960ne = 0;
                                MainActivity.f6958Lb = "";
                                ActivityC2266vc.f8576Hd = 9;
                                MainActivity.f6900F7 = 9;
                                ActivityC2266vc.f8582Nd = 0;
                                MainActivity.f6973N8 = 120.0f;
                                MainActivity.f6910G8 = 120;
                                String strM9124Lb = m9124Lb(bArr, i + 32, 7, true, false);
                                MainActivity.m8169Ab(25, strM9124Lb);
                                f8860Sd[65] = strM9124Lb;
                                f8905be[20] = -1;
                                m9176Yb(strM9124Lb);
                                MainActivity.f7223p7 = "";
                                f8788Dg.f7799vd = "";
                                f8783Cg.m8778kb(60);
                                m9111He(MainActivity.f7116d8);
                                m9135Ne(EnumC2294y.MODE_READ_SENSORS);
                                f8956me = 1;
                                return;
                            }
                            if (b3 != -116) {
                                return;
                            }
                            MainActivity.f7030Tb = null;
                            String strM9124Lb2 = m9124Lb(bArr, i + 17, 15, true, false);
                            MainActivity.m8169Ab(21, strM9124Lb2);
                            int i4 = strM9124Lb2.contains("Bombard.R") ? 3625476 : 0;
                            f8980se = i4;
                            if (i4 == 3625476) {
                                f8860Sd[62] = "MSE 3.7 R";
                            }
                            boolean z = !MainActivity.f7081Z8;
                            MainActivity.f7127ea = z;
                            MainActivity.m8169Ab(z ? 28 : 29, "");
                        }
                        byte b4 = (byte) (f8840Od + 1);
                        f8840Od = b4;
                        m9170Wd(b4);
                        return;
                    }
                    if (b2 != 103) {
                        if (b2 == 98) {
                            short[] sArr = f8873Ug;
                            if ((sArr != null) & (sArr == f8868Tg)) {
                                int i5 = 0;
                                while (true) {
                                    short[] sArr2 = f8873Ug;
                                    if (i5 >= sArr2.length / 2) {
                                        break;
                                    }
                                    int i6 = i5 * 2;
                                    boolean z2 = sArr2[i6] == f8798Fg;
                                    int i7 = i6 + 1;
                                    if (z2 & (sArr2[i7] < 4)) {
                                        sArr2[i7] = 3;
                                    }
                                    i5++;
                                }
                            }
                            if (f8957mf) {
                                m9111He(MainActivity.f7116d8);
                            } else {
                                if (f8956me > 0) {
                                    m9240td();
                                    return;
                                }
                                if (f8952le > 0) {
                                    m9189cd();
                                    return;
                                } else if (!f8887Xf) {
                                    m9217le();
                                    f8788Dg.m8890Cb(bArr, i + 4);
                                    return;
                                } else {
                                    f8835Nd = (byte) -3;
                                    f8964oe = 3;
                                    enumC2294y = EnumC2294y.MODE_SEED;
                                }
                            }
                        } else {
                            if (b2 != 99) {
                                if (b2 != 126) {
                                    if (b2 == 127 && bArr[i + 4] == 39) {
                                        m9135Ne(EnumC2294y.MODE_NULL);
                                        f8783Cg.m8734K9(null, null, f8778Bg.m9079Tb(EnumC2281x.ERR_AUTHENTIFY), 0, 2, 2, 14);
                                        return;
                                    }
                                    return;
                                }
                                ActivityC2266vc.f8571Cd = 0;
                                EnumC2294y enumC2294y2 = f8992vd;
                                EnumC2294y enumC2294y3 = EnumC2294y.MODE_SEED;
                                if (enumC2294y2 != enumC2294y3 || (i3 = f8964oe) <= 0) {
                                    m9129Mc();
                                    return;
                                }
                                int i8 = i3 - 1;
                                f8964oe = i8;
                                if (i8 == 0) {
                                    m9135Ne(enumC2294y3);
                                    return;
                                }
                                return;
                            }
                            int i9 = f8826Le;
                            if (i9 >= 0) {
                                byte[] bArr2 = f8900ae;
                                int i10 = i + 4;
                                if (bArr2 == null) {
                                    System.arraycopy(bArr, i10, ActivityC2225t.f8442Cd, f8826Le + (MainActivity.f7180k9 ? f8816Je & 524287 : (f8816Je & 65535) | ActivityC2225t.f8477Ud), f8841Oe);
                                } else {
                                    System.arraycopy(bArr, i10, bArr2, i9, f8841Oe);
                                }
                                int i11 = f8821Ke;
                                int i12 = f8841Oe;
                                f8821Ke = i11 + i12;
                                f8826Le += i12;
                                f8836Ne = 0;
                                f8882Wf = false;
                                ActivityC2266vc.f8574Fd = 0;
                                if (f8900ae == null) {
                                    f8826Le = ActivityC2225t.m9050xc(f8816Je, f8826Le);
                                    f8783Cg.m8793r9(f8821Ke, f8831Me, f8825Ld);
                                }
                                ActivityC2266vc.f8571Cd = 0;
                                if (f8821Ke < f8831Me && !f8958mg) {
                                    m9178Yd();
                                    return;
                                }
                                m9135Ne(EnumC2294y.MODE_NULL);
                                if (f8958mg) {
                                    f8783Cg.m8734K9(null, null, f8778Bg.m9079Tb(EnumC2281x.ERR_ABORT), 0, 3, 2, 10);
                                    f8783Cg.m8739N5(false);
                                    return;
                                } else {
                                    String strM9079Tb = f8778Bg.m9079Tb(EnumC2281x.END_READ);
                                    MainActivity.f6969N4 = false;
                                    f8783Cg.m8734K9(null, null, strM9079Tb, 0, 3, 2, 19);
                                    f8783Cg.m8781mb();
                                    return;
                                }
                            }
                            f8887Xf = false;
                            if (MainActivity.m8498f5(bArr, i + 4, 4) == 1051642) {
                                f8980se = 3625483;
                                m9179Zb("");
                            }
                            f8783Cg.m8800x5();
                            ActivityC2266vc.f8585Qd = 1;
                            enumC2294y = EnumC2294y.MODE_READ_SENSORS;
                        }
                        f8992vd = enumC2294y;
                        return;
                    }
                    byte b5 = bArr[i + 4];
                    f8835Nd = b5;
                    if (b5 != -5) {
                        if (b5 != -4) {
                            if (b5 != -3) {
                                if (b5 != -2) {
                                    return;
                                }
                            }
                        }
                        MainActivity.m8169Ab(18, "");
                        LedBar.m8097j(2);
                    }
                    int i13 = (bArr[i + 6] & 255) | (bArr[i + 5] << 8);
                    if (i13 != 0) {
                        m9114Id(m9149Rc(i13));
                        return;
                    }
                    LedBar.m8097j(2);
                }
            } else {
                f8952le = 0;
                MainActivity.f6857A9 = false;
                f8783Cg.m8734K9(null, null, null, R.string.error_erased, 1, 2, 5);
            }
            m9217le();
        }
    }

    /* JADX INFO: renamed from: Kd */
    private static void m9122Kd() {
        boolean z = f8792Ef;
        byte[] bArr = new byte[z ? 8 : 14];
        bArr[0] = 49;
        bArr[1] = (byte) (z ? 2 : 196);
        boolean z2 = f8842Of;
        bArr[2] = (byte) ((z || z2) ? 0 : 8);
        bArr[3] = (byte) (z ? 64 : z2 ? 96 : 0);
        bArr[4] = 0;
        bArr[5] = (byte) (z ? 4 : 11);
        bArr[6] = -1;
        bArr[7] = -1;
        if (!z) {
            for (int i = 0; i < 6; i++) {
                bArr[i + 8] = 32;
            }
        }
        m9098Ed(bArr, -1, false);
    }

    /* JADX INFO: renamed from: Ke */
    private static byte m9123Ke(byte[] bArr, int i) {
        int i2 = bArr[i];
        if ((i2 >= 48) && (i2 < 58)) {
            i2 -= 48;
        } else {
            if ((i2 >= 65) & (i2 < 91)) {
                i2 -= 55;
            }
        }
        int i3 = bArr[i + 1];
        if ((i3 >= 48) && (i3 < 58)) {
            i3 -= 48;
        } else {
            if ((i3 >= 65) & (i3 < 91)) {
                i3 -= 55;
            }
        }
        return (byte) (i3 | (i2 << 4));
    }

    /* JADX INFO: renamed from: Lb */
    public static String m9124Lb(byte[] bArr, int i, int i2, boolean z, boolean z2) {
        StringBuilder sb = new StringBuilder();
        for (int i3 = i; i3 < i + i2 && i3 != bArr.length; i3++) {
            if (!z) {
                sb.append(String.format("%02x", Byte.valueOf(bArr[i3])));
            } else {
                if (bArr[i3] == 0) {
                    break;
                }
                sb.append((char) bArr[i3]);
            }
        }
        if (z2) {
            while (true) {
                if (!(sb.length() > 0) || !(sb.indexOf("0") == 0)) {
                    break;
                }
                sb.delete(0, 1);
            }
        }
        return sb.toString();
    }

    /* JADX INFO: renamed from: Lc */
    private static void m9125Lc(int i) {
        f8876Ve = false;
        f8988ue = i;
        m9097Ec();
    }

    /* JADX INFO: renamed from: Ld */
    private static void m9126Ld(int i) {
        int i2;
        byte[] bArr = new byte[10];
        bArr[0] = 49;
        boolean z = f8792Ef;
        bArr[1] = (byte) (z ? 1 : 197);
        boolean z2 = f8842Of;
        bArr[2] = (byte) (z | z2 ? 0 : 8);
        if (z) {
            i2 = 64;
        } else {
            i2 = z2 ? 96 : 0;
        }
        bArr[3] = (byte) i2;
        bArr[4] = 0;
        bArr[5] = (byte) (z ? 4 : 10);
        bArr[6] = -1;
        bArr[7] = -1;
        bArr[8] = (byte) (i / 256);
        bArr[9] = (byte) (i & 255);
        m9098Ed(bArr, -1, false);
    }

    /* JADX INFO: renamed from: Le */
    private static byte[] m9127Le(String str) {
        str.length();
        int length = str.length() / 2;
        byte[] bArr = new byte[length];
        int i = 0;
        for (int i2 = 0; i2 < length; i2++) {
            int i3 = i2 * 2;
            int i4 = i3 + 1;
            int iIndexOf = "0123456789abcdef".indexOf(str.substring(i3, i4).toLowerCase());
            if (iIndexOf >= 0) {
                i = iIndexOf;
            }
            i <<= 4;
            int iIndexOf2 = "0123456789abcdef".indexOf(str.substring(i4, i3 + 2).toLowerCase());
            if (iIndexOf2 >= 0) {
                i |= iIndexOf2;
            }
            bArr[i2] = (byte) i;
        }
        return bArr;
    }

    /* JADX INFO: renamed from: Mb */
    private static int m9128Mb(byte b2) {
        byte b3 = (byte) (b2 & 15);
        byte b4 = (byte) ((b2 >> 4) & 15);
        return (((byte) (b4 < 10 ? b4 + 48 : b4 + 55)) << 8) | ((byte) (b3 < 10 ? b3 + 48 : b3 + 55));
    }

    /* JADX WARN: Code duplicated, block: B:84:0x011c  */
    /* JADX WARN: Code duplicated, block: B:86:0x0120  */
    /* JADX INFO: renamed from: Mc */
    private static void m9129Mc() throws CloneNotSupportedException {
        EnumC2294y enumC2294y;
        byte b2;
        int i = C2267w.f8609a[f8992vd.ordinal()];
        if (i == 18) {
            if (f8855Rd == 2) {
                m9209jc();
                return;
            }
            return;
        }
        if (i == 40) {
            f8783Cg.m8734K9(null, null, f8778Bg.m9079Tb(EnumC2281x.END_DOWNLOAD), 0, 3, 2, 19);
            return;
        }
        if (i != 45) {
            if (i != 72) {
                switch (i) {
                    case 4:
                        int i2 = f8960ne;
                        f8960ne = i2 + 1;
                        if (i2 < 3) {
                            m9211je();
                        }
                        break;
                    case 5:
                        int i3 = f8960ne;
                        f8960ne = i3 + 1;
                        if (i3 < 2) {
                            if (f8926ff && (b2 = f8840Od) == 6 && f8936hf) {
                                f8936hf = false;
                                f8840Od = (byte) (b2 - 1);
                            }
                            m9170Wd(f8840Od);
                        }
                        break;
                    case 6:
                        if (MainActivity.f7268u9) {
                            int i4 = f8960ne;
                            f8960ne = i4 + 1;
                            if (i4 >= 2) {
                                m9139Oe(true);
                            } else {
                                m9235re();
                            }
                        } else if (MainActivity.f7277v9) {
                            int i5 = f8960ne;
                            f8960ne = i5 + 1;
                            if (i5 >= 2) {
                                m9139Oe(false);
                            } else {
                                m9208ie();
                            }
                        } else if (f8998we > 0) {
                            m9108Hb(true, 0);
                        } else if (f8812If && MainActivity.f7068Y4) {
                            f8850Qd = (byte) 2;
                            m9146Qd();
                        } else {
                            if (f8957mf) {
                                m9111He(MainActivity.f7116d8);
                            }
                            short[] sArr = f8873Ug;
                            if ((sArr != null) & (sArr == f8868Tg)) {
                                int i6 = 0;
                                while (true) {
                                    short[] sArr2 = f8873Ug;
                                    if (i6 < sArr2.length / 2) {
                                        int i7 = i6 * 2;
                                        boolean z = sArr2[i7] == f8798Fg;
                                        int i8 = i7 + 1;
                                        if (z & (sArr2[i8] < 4)) {
                                            sArr2[i8] = (short) (sArr2[i8] - 1);
                                        }
                                        i6++;
                                    }
                                }
                            }
                            m9217le();
                            f8960ne = 0;
                        }
                        break;
                    case 7:
                        if (MainActivity.f6925I5) {
                            m9206ic();
                        }
                        f8956me = 0;
                        enumC2294y = EnumC2294y.MODE_READ_SENSORS;
                        break;
                    case 8:
                        if (MainActivity.f6857A9) {
                            f8952le = 0;
                            ActivityC2266vc.f8571Cd = 0;
                            MainActivity.f6857A9 = false;
                            f8783Cg.m8741O5(7);
                            f8992vd = EnumC2294y.MODE_READ_SENSORS;
                        }
                        break;
                    case 9:
                        if (f8857Rf && f8897Zf) {
                            f8897Zf = false;
                            enumC2294y = EnumC2294y.MODE_REQ_ERASE;
                        } else {
                            m9183ad();
                        }
                        break;
                    default:
                        switch (i) {
                            case 29:
                                f9002xd = 0;
                                break;
                            case 30:
                                m9166Vd();
                                break;
                            case 31:
                                m9178Yd();
                                break;
                        }
                        break;
                }
                return;
            }
            if (MainActivity.f6925I5) {
                m9206ic();
            }
            f8956me = 0;
            enumC2294y = EnumC2294y.MODE_READ_SENSORS;
            m9135Ne(enumC2294y);
        }
        if (MainActivity.f6875C9) {
            if (!MainActivity.f7313z9 || System.currentTimeMillis() <= MainActivity.f6903Fa) {
                return;
            }
            if (MainActivity.f7286w9) {
                m9235re();
                MainActivity.f7286w9 = false;
                f8783Cg.m8761cb(16, 0);
                return;
            } else {
                m9219md(4496);
                MainActivity.m8199D9(11000);
                MainActivity.f7286w9 = true;
                return;
            }
        }
        enumC2294y = EnumC2294y.MODE_NULL;
        m9135Ne(enumC2294y);
    }

    /* JADX INFO: renamed from: Md */
    public static void m9130Md() {
        byte[] bArr = new byte[8];
        f8828Lg = Boolean.FALSE;
        int i = f8818Jg;
        if (i == 4) {
            m9142Pd();
            return;
        }
        if (i == 5) {
            bArr[0] = (byte) 33;
            int[] iArr = MainActivity.f7102bc;
            bArr[1] = (byte) iArr[3];
            bArr[2] = (byte) iArr[4];
            bArr[3] = (byte) iArr[5];
        } else if (i == 6) {
            bArr[0] = (byte) 33;
            int[] iArr2 = MainActivity.f7111cc;
            bArr[1] = (byte) iArr2[2];
            bArr[2] = (byte) iArr2[3];
        } else if (i == 8) {
            int i2 = MainActivity.f7178k7;
            bArr[0] = (byte) 33;
            bArr[1] = (byte) (i2 >> 16);
            bArr[2] = (byte) (i2 >> 8);
            bArr[3] = 0;
        } else if (i == 9) {
            bArr[0] = (byte) 33;
            bArr[1] = 0;
            bArr[2] = 1;
        } else {
            if (i == 16) {
                m9138Od();
                return;
            }
            if (i != 18) {
                return;
            }
            bArr[0] = (byte) 33;
            int i3 = 0;
            while (i3 < 4) {
                int i4 = i3 + 1;
                bArr[i4] = (byte) ((f8820Kd >> (i3 * 8)) & 255);
                i3 = i4;
            }
        }
        m9177Yc(bArr, (byte) 0);
    }

    /* JADX INFO: renamed from: Me */
    private static void m9131Me(boolean z) {
        EnumC2294y enumC2294y;
        if (z) {
            if (f8900ae == null) {
                for (int i = 0; i < ActivityC2225t.f8479Wd; i++) {
                    ActivityC2225t.f8442Cd[ActivityC2225t.f8477Ud + i] = -1;
                }
            }
            f8783Cg.m8791qa(true, 0);
        }
        ActivityC2266vc.f8593Yd = false;
        if ((f8876Ve || f8872Uf) || f8837Nf) {
            if (z) {
                f8836Ne = 0;
            }
            enumC2294y = f8982sg ? EnumC2294y.MODE_SPEED_COM : EnumC2294y.MODE_READ_MEM;
        } else if (f8827Lf) {
            enumC2294y = EnumC2294y.MODE_IAW_READ;
        } else {
            enumC2294y = f8812If ? EnumC2294y.MODE_SESSION : EnumC2294y.MODE_ACCESS;
        }
        m9135Ne(enumC2294y);
    }

    /* JADX INFO: renamed from: Nb */
    private static byte m9132Nb(byte[] bArr, int i, int i2) {
        int i3 = 0;
        for (int i4 = 0; i4 < i2; i4++) {
            i3 += bArr[i + i4];
        }
        return (byte) i3;
    }

    /* JADX WARN: Code restructure failed: missing block: B:76:0x00f2, code lost:
    
        if (((r10[r13] == 2) | (r10[r13] == 0)) != false) goto L57;
     */
    /* JADX INFO: renamed from: Nc */
    /*
        Code decompiled incorrectly, please refer to instructions dump.
    */
    public static void m9133Nc(byte[] bArr, int i, int i2, boolean z) {
        EnumC2294y enumC2294y;
        if (z || i2 == 0) {
            return;
        }
        int i3 = C2267w.f8609a[f8992vd.ordinal()];
        if (i3 != 1) {
            if (i3 != 2) {
                if (bArr[i] == 72 && bArr[i + 1] == 107) {
                    int i4 = i + 2;
                    if (bArr[i4] == -47 || bArr[i4] == -46) {
                        m9085Bc(bArr, i, i2);
                        return;
                    }
                }
                if (bArr[i] >= -128 && bArr[i + 1] == -11 && (bArr[i + 2] & (-36)) == -44) {
                    m9101Fc(bArr, i, i2);
                    return;
                }
                if (bArr[i] == 24 && bArr[i + 1] == -38 && bArr[i + 2] == -15 && bArr[i + 3] == -63) {
                    m9082Ac(bArr);
                    return;
                }
                if (bArr[i] == 24 && bArr[i + 1] == -38 && bArr[i + 2] == -15 && bArr[i + 3] == -56) {
                    m9147Qe(bArr);
                    return;
                }
                if (bArr[i] == 24 && bArr[i + 1] == -38 && bArr[i + 2] == -15) {
                    m9160Ub(bArr, false);
                    return;
                }
                if (bArr[i] != 7 || bArr[i + 1] != -24) {
                    if (bArr[i] == 7 && bArr[i + 1] == -127 && f8777Bf) {
                        m9257zc(bArr);
                        return;
                    }
                    if (bArr[i] == 6) {
                        int i5 = i + 1;
                    }
                    if (bArr[i] == -128 && bArr[i + 1] == -15 && bArr[i + 2] == 17) {
                        m9093Dc(bArr, i, i2);
                        return;
                    }
                    if (bArr[i] >= -128) {
                        if (bArr[i + 1] == (f8922eg ? (byte) 1 : (byte) -15) && bArr[i + 2] == 16) {
                            m9236sc(bArr, i, i2);
                            return;
                        }
                    }
                    if (bArr[i] >= -128) {
                        int i6 = i + 1;
                        if ((!(bArr[i6] == -15) && !(bArr[i6] == -13)) || bArr[i + 2] != 1) {
                            return;
                        }
                        m9121Kc(bArr, i, i2);
                        return;
                    }
                    return;
                }
                if (f8777Bf) {
                    m9164Vb(bArr);
                    return;
                }
                m9160Ub(bArr, true);
                return;
            }
            f9002xd = 0;
            f9008ye = 0;
            MainActivity.f6992P9 = false;
            if (bArr[i] == -68) {
                enumC2294y = EnumC2294y.MODE_ABS_ID;
            } else {
                if (bArr[i] == -52) {
                    f8835Nd = (byte) ((f8847Pf || f8926ff) ? 3 : 5);
                } else if (bArr[i] == 42) {
                    enumC2294y = EnumC2294y.MODE_READ_IDENT;
                } else {
                    int i7 = i + 4;
                    if (bArr[i7] == -63 && bArr[i + 5] == -38 && bArr[i + 6] == -113) {
                        int i8 = ActivityC2266vc.f8576Hd;
                        ActivityC2266vc.f8576Hd = 2;
                        f8797Ff = false;
                        f8802Gf = false;
                        f8961nf = false;
                        f8965of = false;
                        f8772Af = false;
                        f8777Bf = false;
                        f8827Lf = false;
                        f8837Nf = false;
                        if ((!f8852Qf) & (!f8857Rf)) {
                            f8807Hf = false;
                            f8822Kf = false;
                            f8906bf = false;
                        }
                        ActivityC2266vc.f8577Id = 0;
                        f8847Pf = false;
                        f9007yd = (byte) (bArr[i + 2] ^ 255);
                        f8835Nd = (byte) ((f8857Rf || (f8867Tf && f8982sg)) ? 5 : 3);
                        if (((i8 == -1) & f8912cg) && MainActivity.f7114d6) {
                            f8992vd = EnumC2294y.MODE_NULL;
                            ActivityC2266vc.f8593Yd = true;
                            MainActivity.f7114d6 = false;
                            f8783Cg.m8734K9(null, MainActivity.f7299y4.getResources().getStringArray(R.array.brand), null, 0, 14, 3, 18);
                            return;
                        }
                        f8876Ve = true;
                    } else {
                        int i9 = i + 3;
                        int i10 = i + 5;
                        if (((bArr[i9] == -63) & ((bArr[i7] & 107) == 107)) && (bArr[i10] == -113)) {
                            ActivityC2266vc.f8576Hd = 8;
                            f8961nf = false;
                            f8965of = false;
                            f8772Af = false;
                            f8777Bf = false;
                            f8981sf = false;
                            f8989uf = false;
                            f8994vf = false;
                            f8985tf = false;
                            f8871Ue = false;
                            f8876Ve = false;
                            f8926ff = false;
                            f8827Lf = true;
                            f8837Nf = false;
                            f8797Ff = false;
                            f8802Gf = bArr[i7] == 107;
                            if ((!f8852Qf) & (!f8857Rf)) {
                                f8807Hf = false;
                                f8822Kf = false;
                                f8901af = false;
                                f8896Ze = false;
                                f8977rf = false;
                                f8973qf = false;
                                f8969pf = false;
                                f8906bf = false;
                                f8911cf = false;
                                f8916df = false;
                            }
                            ActivityC2266vc.f8577Id = 0;
                            f8847Pf = false;
                            f8812If = false;
                            f8817Jf = false;
                            f9007yd = bArr[i + 2] ^ 255;
                            LedBar.m8097j(1);
                            f8960ne = 0;
                            f8840Od = (byte) (f8802Gf ? 35 : 32);
                            if (f8954lg) {
                                m9113Ic();
                                return;
                            }
                        } else {
                            if (!(bArr[i10] == -113) || !((bArr[i9] == -63) & (bArr[i7] == -23))) {
                                return;
                            }
                            ActivityC2266vc.f8576Hd = 9;
                            f8961nf = false;
                            f8965of = false;
                            f8772Af = false;
                            f8777Bf = false;
                            f8981sf = false;
                            f8989uf = false;
                            f8994vf = false;
                            f8985tf = false;
                            f8871Ue = false;
                            f8876Ve = false;
                            f8926ff = false;
                            f8827Lf = false;
                            f8837Nf = true;
                            if ((!f8852Qf) & (!f8857Rf)) {
                                f8807Hf = false;
                                f8822Kf = false;
                                f8901af = false;
                                f8896Ze = false;
                                f8977rf = false;
                                f8973qf = false;
                                f8969pf = false;
                                f8906bf = false;
                                f8911cf = false;
                                f8916df = false;
                            }
                            ActivityC2266vc.f8577Id = 0;
                            f8847Pf = false;
                            f8812If = false;
                            f8817Jf = false;
                            LedBar.m8097j(1);
                            if (!f8867Tf) {
                                f8960ne = 0;
                                f8840Od = (byte) 40;
                            }
                        }
                        enumC2294y = EnumC2294y.MODE_READ_ECU_INFOS;
                    }
                }
                enumC2294y = EnumC2294y.MODE_SEED;
            }
        } else {
            if (bArr[i] != 85) {
                return;
            }
            int i11 = i + 1;
            if (bArr[i11] != 8 && bArr[i11] != -39) {
                return;
            }
            f8917dg = false;
            f8962ng = false;
            MainActivity.f6900F7 = 0;
            if (!MainActivity.f7019S9) {
                f8980se = 0;
            }
            ActivityC2266vc.f8576Hd = 0;
            f8787Df = false;
            f8792Ef = false;
            f8797Ff = false;
            f8802Gf = false;
            f8827Lf = false;
            f8837Nf = false;
            f8876Ve = false;
            f8871Ue = false;
            f8807Hf = false;
            f8822Kf = false;
            f8901af = false;
            f8896Ze = false;
            f8977rf = false;
            f8973qf = false;
            f8969pf = false;
            f8906bf = false;
            f8911cf = false;
            f8916df = false;
            MainActivity.f6992P9 = false;
            f8886Xe = false;
            f9007yd = bArr[i + 2] ^ 255;
            enumC2294y = EnumC2294y.MODE_INIT;
        }
        m9135Ne(enumC2294y);
    }

    /* JADX INFO: renamed from: Nd */
    private static void m9134Nd() {
        m9098Ed(new byte[]{34, 3, 0}, -1, false);
    }

    /* JADX INFO: renamed from: Ne */
    public static void m9135Ne(EnumC2294y enumC2294y) {
        f8992vd = enumC2294y;
        ActivityC2266vc.f8585Qd = 1;
        ActivityC2266vc.f8584Pd = 50;
        MainActivity.f7024T5 = false;
        if (MainActivity.f7015S5) {
            MainActivity.f7015S5 = false;
        }
        switch (C2267w.f8609a[f8992vd.ordinal()]) {
            case 1:
                f8852Qf = false;
                ActivityC2266vc.f8578Jd = 0;
                f9002xd = 0;
                f9007yd = 0;
                MainActivity.f7196m7 = 0;
                if (ActivityC2266vc.f8591Wd) {
                    ActivityC2266vc.f8591Wd = false;
                }
                if ((!f8857Rf) & (!f8954lg)) {
                    f8988ue = 0;
                }
                MainActivity.f6905Fc = 0;
                f8922eg = false;
                MainActivity.f7286w9 = false;
                MainActivity.f7268u9 = false;
                MainActivity.f7277v9 = false;
                MainActivity.f7313z9 = false;
                MainActivity.f6866B9 = false;
                f8783Cg.m8741O5(7);
                f8876Ve = false;
                f8990ug = false;
                f8932gg = false;
                f8956me = 0;
                f8952le = 0;
                f8980se = 0;
                m9191dc(false);
                f8847Pf = true ^ ((f8942ig | f8867Tf) | f8857Rf);
                f8783Cg.m8721A8(false, false, 0);
                f8783Cg.m8787o9();
                LedBar.m8097j(0);
                m9212kc(500);
                MainActivity.f7071Y7 = System.currentTimeMillis();
                f8783Cg.m8770g9(false, -1.0f);
                MainActivity.f7054W8[2] = -1.0f;
                break;
            case 2:
                ActivityC2266vc.f8585Qd = 3;
                if (f9007yd == 0) {
                    m9255yd();
                } else {
                    m9252xd();
                }
                break;
            case 3:
                ActivityC2266vc.f8585Qd = 2;
                m9146Qd();
                break;
            case 4:
                ActivityC2266vc.f8585Qd = 8;
                if ((f8826Le == 0) | (!f8867Tf)) {
                    LedBar.m8097j(1);
                    if ((true ^ f8837Nf) & (!f8852Qf) & (!f8882Wf)) {
                        MainActivity.m8169Ab(16, "");
                    }
                }
                if (f8837Nf) {
                    MainActivity.m8169Ab(17, "");
                }
                m9212kc(f8922eg ? 500 : 50);
                m9211je();
                break;
            case 5:
                ActivityC2266vc.f8585Qd = 5;
                m9170Wd(f8840Od);
                break;
            case 6:
                ActivityC2266vc.f8585Qd = 3;
                f8978rg = true ^ (f8916df | ((f8980se > 2105344) & f8812If));
                f8783Cg.m8787o9();
                m9217le();
                break;
            case 7:
                m9169Wc();
                break;
            case 8:
                ActivityC2266vc.f8585Qd = (f8812If && (MainActivity.f7301y6 || MainActivity.f7310z6)) ? 20 : 5;
                m9189cd();
                break;
            case 9:
                m9183ad();
                break;
            case 10:
                ActivityC2266vc.f8585Qd = 5;
                ActivityC2266vc.f8581Md = 0;
                LedBar.m8097j(1);
                if (!f8871Ue) {
                    m9243ud();
                } else {
                    m9249wd();
                }
                break;
            case 11:
                ActivityC2266vc.f8585Qd = 4;
                if ((true ^ f8867Tf) & f8857Rf & (!f8937hg)) {
                    MainActivity.m8169Ab(17, "");
                }
                m9211je();
                break;
            case 12:
                m9212kc(100);
                m9231qd();
                break;
            case 13:
                m9158Td();
                break;
            case 14:
                ActivityC2266vc.f8585Qd = 4;
                m9212kc(100);
                f8922eg = false;
                m9204hd();
                break;
            case 15:
                ActivityC2266vc.f8585Qd = 2;
                m9212kc(100);
                m9201gd();
                break;
            case 16:
                ActivityC2266vc.f8585Qd = 2;
                m9212kc(100);
                m9122Kd();
                break;
            case 17:
                ActivityC2266vc.f8585Qd = 10;
                ActivityC2266vc.f8584Pd = 20;
                f8825Ld = System.currentTimeMillis();
                m9216ld();
                break;
            case 18:
                ActivityC2266vc.f8585Qd = 2;
                m9253xe(f8855Rd);
                break;
            case 19:
                m9181Zd();
                break;
            case 20:
                ActivityC2266vc.f8585Qd = 6;
                f8783Cg.m8791qa(false, 1);
                m9184ae();
                break;
            case 21:
                f8818Jg = 8;
                int i = (ActivityC2225t.f8481Yd[0] & 752) << 12;
                int i2 = ActivityC2225t.f8509wd[0];
                if (f8842Of) {
                    i = i2;
                }
                f8806He = i;
                m9193de();
                break;
            case 22:
                MainActivity.f7196m7 = 40;
                ActivityC2266vc.f8585Qd = 2;
                f8825Ld = System.currentTimeMillis();
                m9222nd();
                break;
            case 23:
                ActivityC2266vc.f8585Qd = 10;
                if (MainActivity.f7169j7 == 0) {
                    f8825Ld = System.currentTimeMillis();
                }
                m9199fe();
                break;
            case 24:
                ActivityC2266vc.f8585Qd = 50;
                m9212kc(500);
                m9235re();
                break;
            case 25:
                ActivityC2266vc.f8585Qd = 5;
                ActivityC2266vc.f8584Pd = 5;
                m9238se();
                break;
            case 26:
                ActivityC2266vc.f8585Qd = 10;
                ActivityC2266vc.f8584Pd = 5;
                if (f8821Ke == 0) {
                    f8825Ld = System.currentTimeMillis();
                }
                if (!f8797Ff && !f8802Gf) {
                    m9154Sd();
                } else if (!f8954lg) {
                    m9190ce();
                } else {
                    m9187be();
                }
                break;
            case 27:
                ActivityC2266vc.f8585Qd = 4;
                m9212kc(100);
                m9126Ld(f8851Qe);
                break;
            case 28:
                ActivityC2266vc.f8585Qd = 10;
                ActivityC2266vc.f8584Pd = 20;
                f8825Ld = System.currentTimeMillis();
                m9212kc(100);
                m9237sd();
                break;
            case 29:
                ActivityC2266vc.f8585Qd = 10;
                f8922eg = false;
                m9212kc(100);
                m9192dd();
                break;
            case 30:
                ActivityC2266vc.f8585Qd = 4;
                m9166Vd();
                break;
            case 31:
                ActivityC2266vc.f8585Qd = 4;
                if (f8821Ke == 0) {
                    f8825Ld = System.currentTimeMillis();
                }
                m9178Yd();
                break;
            case 32:
                ActivityC2266vc.f8585Qd = 5;
                m9220me();
                break;
            case 33:
                ActivityC2266vc.f8585Qd = 5;
                m9205he();
                break;
            case 34:
                m9239tc();
                break;
            case 35:
                ActivityC2266vc.f8585Qd = 5;
                m9196ee();
                break;
            case 36:
                if (!f8827Lf) {
                    ActivityC2266vc.f8585Qd = 4;
                    m9212kc(160);
                }
                if (MainActivity.f7169j7 == 0) {
                    f8825Ld = System.currentTimeMillis();
                }
                m9244ue();
                break;
            case 37:
                m9241te();
                break;
            case 38:
                ActivityC2266vc.f8585Qd = 5;
                m9212kc(100);
                m9247ve();
                break;
            case 39:
                ActivityC2266vc.f8585Qd = 5;
                f8993ve++;
                m9212kc(500);
                m9256ye();
                break;
            case 40:
                ActivityC2266vc.f8585Qd = 5;
                m9212kc(500);
                m9202ge();
                break;
            case 41:
                ActivityC2266vc.f8585Qd = 10;
                m9153Sc();
                break;
            case 42:
                ActivityC2266vc.f8585Qd = 5;
                m9161Uc();
                break;
            case 43:
                ActivityC2266vc.f8585Qd = 5;
                m9157Tc();
                break;
            case 44:
                ActivityC2266vc.f8585Qd = 2;
                m9173Xc((byte) -1);
                break;
            case 45:
                f8783Cg.m8750Y9();
                break;
            case 46:
            case 49:
                f8783Cg.m8787o9();
                ActivityC2266vc.f8585Qd = 3;
                break;
            case 47:
                ActivityC2266vc.f8585Qd = 2;
                m9229pe((byte) 16);
                break;
            case 48:
                ActivityC2266vc.f8585Qd = 2;
                break;
            case 50:
                ActivityC2266vc.f8585Qd = 3;
                m9212kc(1500);
                m9090Cd();
                break;
            case 51:
                ActivityC2266vc.f8585Qd = 5;
                m9246vd();
                break;
            case 52:
                ActivityC2266vc.f8585Qd = 5;
                MainActivity.f7243r9 = true;
                break;
            case 53:
                ActivityC2266vc.f8585Qd = 5;
                f8948ke = 0;
                m9246vd();
                break;
            case 54:
                f8818Jg = 6;
                f8801Ge = 0;
                m9094Dd();
                break;
            case 55:
                ActivityC2266vc.f8585Qd = 3;
                m9228pd();
                break;
            case 56:
                m9212kc(20);
                LedBar.m8097j(2);
                m9180Zc(f8889Xh, 125, true);
                break;
            case 57:
                m9180Zc(f8894Yh, 13, true);
                break;
            case 58:
                ActivityC2266vc.f8585Qd = f8867Tf | f8857Rf ? 5 : 2;
                m9212kc(20);
                m9115Ie(f8816Je + f8826Le, f8900ae.length);
                m9180Zc(f8904ai, (f8900ae.length * 2) + 5, true);
                break;
            case 59:
                m9180Zc(f8909bi, 53, true);
                break;
            case 60:
                ActivityC2266vc.f8585Qd = 4;
                m9180Zc(f8914ci, 5, true);
                break;
            case 61:
                ActivityC2266vc.f8585Qd = 2;
                m9212kc(100);
                ActivityC2266vc.f8591Wd = false;
                m9180Zc(f8919di, 5, true);
                break;
            case 62:
                f8783Cg.m8787o9();
                m9180Zc(f8884Wh, 5, false);
                m9212kc(100);
                break;
            case 63:
                m9180Zc(f8924ei, 21, true);
                break;
            case 64:
                m9180Zc(f8929fi, 5, true);
                break;
            case 65:
                m9180Zc(f8934gi, 5, true);
                break;
            case 66:
                f8862Sf = false;
                byte[] bArr = {85};
                f8890Yd = bArr;
                ActivityC2266vc.m9074Xb(bArr, 1, false, true);
                break;
            case 67:
                byte[] bArr2 = C2196qc.f8288a;
                int length = bArr2.length;
                ActivityC2266vc.f8584Pd = 20;
                int i3 = f8826Le;
                if (i3 != -2) {
                    int i4 = i3 + 4 >= length ? length - i3 : 4;
                    byte[] bArr3 = new byte[i4];
                    f8890Yd = bArr3;
                    if (i4 >= 0) {
                        System.arraycopy(bArr2, i3, bArr3, 0, i4);
                    }
                    ActivityC2266vc.m9074Xb(f8890Yd, i4, false, true);
                } else {
                    f8783Cg.m8791qa(true, 3);
                    byte[] bArr4 = {(byte) ((length >> 8) & 255), (byte) (length & 255)};
                    f8890Yd = bArr4;
                    ActivityC2266vc.m9074Xb(bArr4, 2, false, true);
                }
                break;
            case 68:
                ActivityC2266vc.f8584Pd = 20;
                LedBar.m8097j(1);
                f8783Cg.m8791qa(true, 2);
                f9002xd = 7;
                f8778Bg.m9078Rb(38400, true);
                m9180Zc(null, 4, false);
                break;
            case 69:
                ActivityC2266vc.f8584Pd = 20;
                ActivityC2266vc.m9074Xb(f8890Yd, 1, false, true);
                f8825Ld = System.currentTimeMillis();
                f8783Cg.m8791qa(true, 4);
                f9002xd = 7;
                break;
            case 70:
                ActivityC2266vc.f8585Qd = 2;
                ActivityC2266vc.f8584Pd = 20;
                byte[] bArr5 = {80, 37};
                f8890Yd = bArr5;
                ActivityC2266vc.m9074Xb(bArr5, 1, false, true);
                break;
            case 71:
                byte[] bArr6 = {69, -1};
                f8890Yd = bArr6;
                ActivityC2266vc.m9074Xb(bArr6, 1, false, true);
                break;
        }
    }

    /* JADX INFO: renamed from: Ob */
    public static int m9136Ob() {
        int[] iArr = new int[4];
        int[] iArr2 = new int[44];
        int[] iArr3 = C2112kc.f8061f;
        int[] iArr4 = {-1605603089, -872368047, 1793034130, 2024345909, -195055148, -256431415, 2054042008, 967577947, -1529110564, 414003055, 316782756, -1031573188};
        short[] sArr = {1, 2, 4, 8, 16, 32, 64, 128, 27, 54};
        for (int i = 0; i < 4; i++) {
            iArr[i] = iArr4[(MainActivity.f7106c7 * 4) + i];
            iArr2[i] = iArr[i];
        }
        int i2 = 0;
        while (i2 < 10) {
            int i3 = (iArr[3] >> 8) & 255;
            iArr[0] = ((iArr3[(i3 / 4) + 1024] >> ((i3 % 4) * 8)) & 255) ^ iArr[0];
            int i4 = (iArr[3] >> 16) & 255;
            iArr[0] = (((iArr3[(i4 / 4) + 1024] >> ((i4 % 4) * 8)) & 255) << 8) ^ iArr[0];
            int i5 = (iArr[3] >> 24) & 255;
            iArr[0] = (((iArr3[(i5 / 4) + 1024] >> ((i5 % 4) * 8)) & 255) << 16) ^ iArr[0];
            int i6 = iArr[3] & 255;
            iArr[0] = (((iArr3[(i6 / 4) + 1024] >> ((i6 % 4) * 8)) & 255) << 24) ^ iArr[0];
            int i7 = i2 + 1;
            iArr[0] = sArr[i2] ^ iArr[0];
            int i8 = 0;
            while (i8 < 3) {
                int i9 = i8 + 1;
                iArr[i9] = iArr[i8] ^ iArr[i9];
                i8 = i9;
            }
            for (int i10 = 0; i10 < 4; i10++) {
                iArr2[(i7 * 4) + i10] = iArr[i10];
            }
            i2 = i7;
        }
        int i11 = 0;
        for (int i12 = 0; i12 < 9; i12++) {
            int[] iArr5 = f8776Be;
            int i13 = i11 * 4;
            iArr5[4] = iArr5[0] ^ iArr2[i13];
            iArr5[5] = iArr5[1] ^ iArr2[i13 + 1];
            iArr5[6] = iArr5[2] ^ iArr2[i13 + 2];
            iArr5[7] = iArr5[3] ^ iArr2[i13 + 3];
            iArr5[0] = ((iArr3[iArr5[4] & 255] ^ iArr3[((iArr5[5] >> 8) & 255) + 256]) ^ iArr3[((iArr5[6] >> 16) & 255) + 512]) ^ iArr3[((iArr5[7] >> 24) & 255) + 768];
            iArr5[1] = (((iArr3[iArr5[5] & 255] ^ 0) ^ iArr3[((iArr5[6] >> 8) & 255) + 256]) ^ iArr3[((iArr5[7] >> 16) & 255) + 512]) ^ iArr3[((iArr5[4] >> 24) & 255) + 768];
            iArr5[2] = (((iArr3[iArr5[6] & 255] ^ 0) ^ iArr3[((iArr5[7] >> 8) & 255) + 256]) ^ iArr3[((iArr5[4] >> 16) & 255) + 512]) ^ iArr3[((iArr5[5] >> 24) & 255) + 768];
            iArr5[3] = (((iArr3[iArr5[7] & 255] ^ 0) ^ iArr3[((iArr5[4] >> 8) & 255) + 256]) ^ iArr3[((iArr5[5] >> 16) & 255) + 512]) ^ iArr3[((iArr5[6] >> 24) & 255) + 768];
            i11++;
        }
        int[] iArr6 = f8776Be;
        int i14 = i11 * 4;
        iArr6[4] = iArr6[0] ^ iArr2[i14];
        iArr6[5] = iArr6[1] ^ iArr2[i14 + 1];
        iArr6[6] = iArr6[2] ^ iArr2[i14 + 2];
        iArr6[7] = iArr6[3] ^ iArr2[i14 + 3];
        iArr6[0] = ((iArr3[iArr6[4] & 255] >> 8) & 255) | (((iArr3[(iArr6[5] >> 8) & 255] >> 8) & 255) << 8) | (((iArr3[(iArr6[6] >> 16) & 255] >> 8) & 255) << 16) | (((iArr3[(iArr6[7] >> 24) & 255] >> 8) & 255) << 24);
        iArr6[1] = ((iArr3[iArr6[5] & 255] >> 8) & 255) | (((iArr3[(iArr6[6] >> 8) & 255] >> 8) & 255) << 8) | (((iArr3[(iArr6[7] >> 16) & 255] >> 8) & 255) << 16) | (((iArr3[(iArr6[4] >> 24) & 255] >> 8) & 255) << 24);
        iArr6[2] = ((iArr3[iArr6[6] & 255] >> 8) & 255) | (((iArr3[(iArr6[7] >> 8) & 255] >> 8) & 255) << 8) | (((iArr3[(iArr6[4] >> 16) & 255] >> 8) & 255) << 16) | (((iArr3[(iArr6[5] >> 24) & 255] >> 8) & 255) << 24);
        iArr6[3] = (((iArr3[(iArr6[6] >> 24) & 255] >> 8) & 255) << 24) | ((iArr3[iArr6[7] & 255] >> 8) & 255) | (((iArr3[(iArr6[4] >> 8) & 255] >> 8) & 255) << 8) | (((iArr3[(iArr6[5] >> 16) & 255] >> 8) & 255) << 16);
        int i15 = (i11 + 1) * 4;
        iArr6[0] = iArr2[i15] ^ iArr6[0];
        iArr6[1] = iArr6[1] ^ iArr2[i15 + 1];
        iArr6[2] = iArr6[2] ^ iArr2[i15 + 2];
        iArr6[3] = iArr6[3] ^ iArr2[i15 + 3];
        return iArr6[0];
    }

    /* JADX INFO: renamed from: Oc */
    private static void m9137Oc() {
        f8857Rf = false;
        f8867Tf = true;
        f9002xd = 0;
        f8992vd = EnumC2294y.MODE_NULL;
        if (!MainActivity.f6862B5 && !MainActivity.f6871C5) {
            m9254yc(213);
        } else {
            MainActivity.f6939Ja = 20;
            f8783Cg.m8805y8(false);
        }
    }

    /* JADX INFO: renamed from: Od */
    public static void m9138Od() {
        int i = f8968pe;
        int i2 = 1;
        int i3 = i == 4 ? 112 : f8841Oe;
        int i4 = ((i3 - i) + 6) / 7;
        int i5 = f8806He;
        if (MainActivity.f7169j7 + i5 >= f8856Re) {
            i5 += f8861Se;
        }
        byte[] bArr = new byte[i4 * 8];
        int i6 = 0;
        while (i < i3) {
            int i7 = i2 + 1;
            bArr[i6] = (byte) ((i2 & 15) | 32);
            i6++;
            int i8 = 0;
            while (i8 < 7) {
                bArr[i6] = ActivityC2225t.f8442Cd[MainActivity.f7169j7 + i5 + i];
                i8++;
                i6++;
                i++;
            }
            i2 = i7;
        }
        f8968pe = i;
        m9177Yc(bArr, (byte) 0);
    }

    /* JADX INFO: renamed from: Oe */
    private static void m9139Oe(boolean z) {
        MainActivity.f7268u9 = false;
        MainActivity.f7277v9 = false;
        f8960ne = 0;
        f8930ge = (byte) 0;
        if (z) {
            f8783Cg.m8746Sa(0, false);
        }
        m9217le();
    }

    /* JADX INFO: renamed from: Pb */
    public static int m9140Pb(int i) {
        byte[] bArr = {0, 0, -102, -30, 19, 75, 106};
        bArr[0] = (byte) (i >> 8);
        bArr[1] = (byte) (i & 255);
        int i2 = 65535;
        for (int i3 = 0; i3 < 7; i3++) {
            int i4 = ((bArr[i3] ^ ((byte) (i2 >> 8))) << 8) & 65535;
            int i5 = 0;
            for (int i6 = 0; i6 < 8; i6++) {
                int i7 = (i4 ^ i5) & 32768;
                int i8 = i5 * 2;
                if (i7 > 0) {
                    i8 ^= 4129;
                }
                i4 = (i4 * 2) & 65535;
                i5 = i8 & 65535;
            }
            i2 = ((i2 << 8) & 65535) ^ i5;
        }
        return i2;
    }

    /* JADX WARN: Can't fix incorrect switch cases order, some code will duplicate */
    /* JADX WARN: Code duplicated, block: B:55:0x00ee  */
    /* JADX INFO: renamed from: Pc */
    public static boolean m9141Pc(byte[] bArr, int i, int i2) throws Throwable {
        EnumC2294y enumC2294y;
        EnumC2294y enumC2294y2;
        int i3;
        int i4;
        boolean z = true;
        if (((i < 0) | (i2 < 1)) || (i2 > 254)) {
            return false;
        }
        if (((!f8932gg) && (i2 > 1)) && bArr[(i + i2) - 1] != m9132Nb(bArr, i, i2 - 1)) {
            return false;
        }
        MainActivity.f7249s6.m8102a(1);
        StringBuilder sb = new StringBuilder();
        for (int i5 = 0; i5 < i2; i5++) {
            sb.append((char) bArr[i5]);
        }
        String string = sb.toString();
        int i6 = C2267w.f8609a[f8992vd.ordinal()];
        if (i6 == 1) {
            if (!f8862Sf) {
                if (string.startsWith(":OK!")) {
                    MainActivity.f6900F7 = 3;
                    ActivityC2266vc.f8576Hd = 3;
                    ActivityC2266vc.f8583Od = 0;
                    f8876Ve = false;
                    f8871Ue = false;
                    MainActivity.f6983O9 = false;
                    f8807Hf = false;
                    f8822Kf = false;
                    f8901af = false;
                    f8896Ze = false;
                    f8977rf = false;
                    f8973qf = false;
                    f8969pf = false;
                    f8906bf = false;
                    f8911cf = false;
                    f8916df = false;
                    f8926ff = false;
                    f8961nf = false;
                    f8965of = false;
                    f8772Af = false;
                    f8777Bf = false;
                    f8862Sf = false;
                    MainActivity.f6992P9 = false;
                    f8986tg = false;
                    f8783Cg.m8787o9();
                    if (f8857Rf) {
                        m9159Te();
                        return true;
                    }
                    if (f8867Tf) {
                        LedBar.m8097j(2);
                        f8825Ld = System.currentTimeMillis();
                        f8783Cg.m8791qa(true, 0);
                        enumC2294y = EnumC2294y.MODE_WALBRO_READ_MEM;
                    } else {
                        enumC2294y = EnumC2294y.MODE_WALBRO_VERSION;
                    }
                    m9135Ne(enumC2294y);
                    return true;
                }
                if (string.startsWith(":NOT")) {
                    m9088Cb(false);
                } else {
                    ActivityC2266vc.f8575Gd = 0;
                    ActivityC2266vc.f8572Dd = 0;
                }
            } else if (bArr[i] == 0) {
                enumC2294y2 = EnumC2294y.MODE_WALBRO_SYNC;
                m9135Ne(enumC2294y2);
            }
            return false;
        }
        int i7 = -1;
        switch (i6) {
            case 56:
                if (string.startsWith(":OK!")) {
                    f8972qe = 0;
                    MainActivity.f7033U5 = false;
                    f8905be[20] = m9123Ke(bArr, 108);
                    f8905be[21] = m9123Ke(bArr, 110);
                    String strM9036jc = ActivityC2225t.m9036jc(f8905be);
                    f8771Ae[16] = m9123Ke(bArr, i + 4) & 255;
                    f8771Ae[17] = m9123Ke(bArr, i + 6) & 255;
                    f8771Ae[18] = m9123Ke(bArr, i + 8) & 255;
                    f8771Ae[19] = m9123Ke(bArr, i + 12) & 255;
                    f8771Ae[20] = m9123Ke(bArr, i + 10) & 255;
                    f8771Ae[21] = m9123Ke(bArr, i + 14) & 255;
                    String[] strArr = f8860Sd;
                    strArr[63] = m9092Db(bArr, 20, 34);
                    byte[] bArr2 = f8934gi;
                    System.arraycopy(bArr, 4, bArr2, 12, 16);
                    System.arraycopy(bArr, 20, bArr2, 28, 34);
                    strArr[64] = m9092Db(bArr, 60, 20);
                    System.arraycopy(bArr, 60, bArr2, 68, 20);
                    strArr[65] = strM9036jc;
                    MainActivity.f7030Tb = strArr[64];
                    byte[] bArr3 = f8905be;
                    MainActivity.m8169Ab(23, Integer.toHexString((bArr3[23] & 255) | ((bArr3[22] & 255) << 8)));
                    m9135Ne(EnumC2294y.MODE_WALBRO_DTC);
                    f8783Cg.m8794t5();
                    MainActivity.m8169Ab(MainActivity.f7127ea ? 28 : 29, MainActivity.f7030Tb);
                    MainActivity.f7051W5 = false;
                    f8783Cg.m8778kb(50);
                    return true;
                }
                return false;
            case 57:
                if (string.startsWith(":OK!")) {
                    MainActivity.f6958Lb = "";
                    f8976re = 0;
                    MainActivity.f6930Ia = 7;
                    MainActivity.f7030Tb = null;
                    String strM9124Lb = m9124Lb(bArr, 4, 8, true, true);
                    MainActivity.m8169Ab(21, strM9124Lb);
                    String[] strArr2 = f8860Sd;
                    strArr2[62] = strM9124Lb;
                    if (strM9124Lb.equals("WBE400AL") || strM9124Lb.equals("WBE400AN")) {
                        i7 = 16386;
                    } else if (strM9124Lb.equals("WBE400AQ") || strM9124Lb.equals("WBE400AR")) {
                        i7 = 16388;
                    } else if (strM9124Lb.equals("WBE400AS") || strM9124Lb.equals("WBE400AU")) {
                        i7 = 16390;
                    } else if (strM9124Lb.equals("A1BEN_02")) {
                        i7 = 16642;
                    } else if (strM9124Lb.equals("A1BEN_04")) {
                        i7 = 16644;
                    } else if (strM9124Lb.equals("A1BEN_07")) {
                        i7 = 16647;
                    }
                    f8980se = i7;
                    f8965of = (61440 & i7) == 16384;
                    m9099Ee("3");
                    int iM9000Lb = ActivityC2225t.m9000Lb(f8980se, 1, C2212s0.f8420a) >> 16;
                    if (iM9000Lb < 0) {
                        f8986tg = true;
                        strArr2[65] = strM9124Lb;
                        m9135Ne(EnumC2294y.MODE_NULL);
                        f8783Cg.m8734K9(null, null, f8778Bg.m9079Tb(EnumC2281x.UNSUPPORTED_ECU), 0, 6, MainActivity.f7116d8 == 0 ? 3 : 1, 26);
                        if (MainActivity.f7116d8 <= 0) {
                            return true;
                        }
                        f8783Cg.m8739N5(false);
                        return true;
                    }
                    f8940ie = ActivityC2225t.m9029cc(iM9000Lb, 5) | 65536;
                    f8944je = ActivityC2225t.m9029cc(iM9000Lb, 36) | 16711680;
                    f8899Zh[9] = (byte) m9128Mb((byte) ((f8980se & 16640) == 16640 ? 10 : 8));
                    f8816Je = 2;
                    f8826Le = 0;
                    MainActivity.f6910G8 = 120;
                    MainActivity.f6973N8 = 95.0f;
                    MainActivity.f7242r8 = 0;
                    f8900ae = new byte[2];
                    enumC2294y = EnumC2294y.MODE_WALBRO_READ_MEM;
                    m9135Ne(enumC2294y);
                    return true;
                }
                return false;
            case 58:
                if (string.startsWith(":OK!")) {
                    if (f8867Tf) {
                        int i8 = 0;
                        while (true) {
                            int i9 = f8841Oe;
                            if (i8 < i9) {
                                ActivityC2225t.f8442Cd[f8816Je + f8826Le + i8] = m9123Ke(bArr, (i8 * 2) + 4);
                                i8++;
                            } else {
                                f8821Ke += i9;
                                int i10 = f8826Le + i9;
                                f8826Le = i10;
                                int iM9050xc = ActivityC2225t.m9050xc(f8816Je, i10);
                                f8826Le = iM9050xc;
                                if (iM9050xc >= 0) {
                                    f8783Cg.m8793r9(f8821Ke, f8831Me, f8825Ld);
                                }
                                ActivityC2266vc.f8571Cd = 0;
                                if (f8821Ke >= f8831Me || f8958mg) {
                                    f8900ae = null;
                                    m9135Ne(EnumC2294y.MODE_NULL);
                                    if (f8958mg) {
                                        f8783Cg.m8734K9(null, null, f8778Bg.m9079Tb(EnumC2281x.ERR_ABORT), 0, 3, 2, 10);
                                    } else {
                                        f8783Cg.m8734K9(null, null, f8778Bg.m9079Tb(EnumC2281x.END_READ), 0, 3, 2, 10);
                                        f8783Cg.m8781mb();
                                    }
                                    f8783Cg.m8739N5(false);
                                    return true;
                                }
                            }
                        }
                    } else {
                        int i11 = f8816Je;
                        if (i11 >= 512) {
                            if (i11 == f8940ie) {
                                f8771Ae[14] = m9123Ke(bArr, 6) | (m9123Ke(bArr, 4) << 8);
                                i3 = 131070;
                            } else {
                                int iM9123Ke = (m9123Ke(bArr, 6) & 255) | ((m9123Ke(bArr, 4) & 255) << 8);
                                if (iM9123Ke != 65535) {
                                    f8860Sd[66] = String.format("%x", Integer.valueOf(iM9123Ke));
                                }
                                enumC2294y = EnumC2294y.MODE_WALBRO_INFO;
                            }
                            m9135Ne(enumC2294y);
                            return true;
                        }
                        f8905be[22] = m9123Ke(bArr, 4);
                        f8905be[23] = m9123Ke(bArr, 6);
                        i3 = f8940ie;
                        f8816Je = i3;
                    }
                    enumC2294y = EnumC2294y.MODE_WALBRO_READ_MEM;
                    m9135Ne(enumC2294y);
                    return true;
                }
                return false;
            case 59:
                if (string.startsWith(":OK!")) {
                    m9091Ce(20);
                    m9200gc(bArr);
                    f8783Cg.m8788p8(!f8833Mg.isEmpty(), false);
                    if (MainActivity.f6925I5) {
                        m9206ic();
                    }
                    enumC2294y = f8867Tf ? EnumC2294y.MODE_NULL : MainActivity.f7116d8 == 2 ? EnumC2294y.MODE_WALBRO_TPS : EnumC2294y.MODE_WALBRO_SENSORS;
                    m9135Ne(enumC2294y);
                    return true;
                }
                return false;
            case 60:
                if (string.startsWith(":OK!")) {
                    f8783Cg.m8734K9(null, null, null, R.string.error_erased, 1, 2, 5);
                    m9135Ne(enumC2294y);
                    return true;
                }
                return false;
            case 61:
                if (string.startsWith(":OK!")) {
                    m9180Zc(null, -1, false);
                    ActivityC2266vc.f8591Wd = true;
                    f8978rg = true;
                    f8783Cg.m8787o9();
                } else if (bArr[i] == 58) {
                    MainActivity.f7080Z7 = System.currentTimeMillis() - MainActivity.f7071Y7;
                    f8783Cg.m8770g9(MainActivity.f7116d8 > 0, MainActivity.f7080Z7);
                    ActivityC1960a0.m8887Db(bArr, i, i2);
                    ActivityC2266vc.f8571Cd = 0;
                } else {
                    z = false;
                }
                if (f8892Yf) {
                    if ((MainActivity.f7133f7 & 65280) == 2048) {
                        m9215lc(false);
                    } else {
                        f8997wd = -1;
                        f8954lg = false;
                        m9135Ne(EnumC2294y.MODE_NULL);
                        f8783Cg.m8734K9(null, null, f8778Bg.m9079Tb(EnumC2281x.ERR_VERSION_MAP), 0, 2, 1, 8);
                    }
                }
                ActivityC2266vc.f8573Ed = -1;
                return z;
            case 62:
                if (string.startsWith(":OK!")) {
                    ActivityC2266vc.f8591Wd = false;
                    return true;
                }
                return false;
            case 63:
                if (string.startsWith(":OK!")) {
                    if (MainActivity.f7116d8 != 2) {
                        f8992vd = EnumC2294y.MODE_NULL;
                    } else if (i2 == 21) {
                        int i12 = i + 4;
                        f8771Ae[16] = m9123Ke(bArr, i12) & 255;
                        f8771Ae[17] = m9123Ke(bArr, i + 6) & 255;
                        f8771Ae[18] = m9123Ke(bArr, i + 8) & 255;
                        f8771Ae[19] = m9123Ke(bArr, i + 12) & 255;
                        f8771Ae[20] = m9123Ke(bArr, i + 10) & 255;
                        f8771Ae[21] = m9123Ke(bArr, i + 14) & 255;
                        MainActivity.f6914Gc = f8771Ae[f8976re + 18];
                        MainActivity.f6896Ec = f8771Ae[f8976re + 19];
                        System.arraycopy(bArr, i12, f8929fi, 12, 12);
                    }
                    MainActivity.f7080Z7 = System.currentTimeMillis() - MainActivity.f7071Y7;
                    f8783Cg.m8770g9(MainActivity.f7116d8 > 0, MainActivity.f7080Z7);
                    f8783Cg.m8787o9();
                    if (f8952le > 0) {
                        f8952le = 0;
                        enumC2294y = EnumC2294y.MODE_WALBRO_CLEAR_DTC;
                    } else if (f8956me > 0) {
                        f8956me = 0;
                        enumC2294y = EnumC2294y.MODE_WALBRO_DTC;
                    } else {
                        if (!MainActivity.f7033U5) {
                            int i13 = f8972qe;
                            if (i13 > 0) {
                                f8995vg = i13 == 1;
                                m9135Ne(EnumC2294y.MODE_WALBRO_SET_VALUE);
                                f8972qe = 0;
                                return true;
                            }
                            if (i2 == 9) {
                                ActivityC1960a0.m8887Db(bArr, 0, i2);
                                m9115Ie(f8944je, 1);
                                m9180Zc(f8904ai, 7, true);
                                return true;
                            }
                            if (i2 != 7) {
                                if (MainActivity.f6874C8 == 2) {
                                    f8783Cg.m8733J9();
                                }
                                m9180Zc(f8899Zh, 9, true);
                                return true;
                            }
                            f8771Ae[2] = m9123Ke(bArr, 4);
                            int i14 = f8771Ae[2] == 0 ? 0 : 2;
                            f8976re = i14;
                            f8783Cg.m8776j9((i14 > 0 ? 2 : 0) + 32);
                            m9180Zc(f8899Zh, 9, true);
                            return true;
                        }
                        enumC2294y = EnumC2294y.MODE_WALBRO_SET_INFOS;
                    }
                    m9135Ne(enumC2294y);
                    return true;
                }
                return false;
            case 64:
                if (string.startsWith(":OK!")) {
                    if (f8995vg) {
                        f8783Cg.m8757b9(1);
                    }
                    m9135Ne(enumC2294y);
                    return true;
                }
                return false;
            case 65:
                enumC2294y2 = EnumC2294y.MODE_NULL;
                m9135Ne(enumC2294y2);
                return false;
            case 66:
                f8826Le = -2;
                f8932gg = true;
                if (bArr[i] == -86) {
                    LedBar.m8097j(3);
                    m9135Ne(enumC2294y);
                    return true;
                }
                i4 = 100;
                m9212kc(i4);
                return false;
            case 67:
                int length = C2196qc.f8288a.length;
                boolean z2 = i2 != f8890Yd.length;
                if (!z2) {
                    for (int i15 = 0; i15 < i2; i15++) {
                        if (f8890Yd[i15] != bArr[i15]) {
                            z2 = true;
                        }
                    }
                }
                if (z2) {
                    i4 = 500;
                    m9212kc(i4);
                    return false;
                }
                int i16 = f8826Le + i2;
                f8826Le = i16;
                f8783Cg.m8793r9(i16, length, 0L);
                enumC2294y = f8826Le >= length ? EnumC2294y.MODE_WALBRO_ERASING : EnumC2294y.MODE_WALBRO_UPROG;
                m9135Ne(enumC2294y);
                return true;
            case 68:
                if (i2 == 4) {
                    if (((bArr[i + 3] & 255) | (bArr[i + 2] << 8)) == 257) {
                        byte[] bArr4 = {2};
                        f8890Yd = bArr4;
                        ActivityC2266vc.m9074Xb(bArr4, 2, false, true);
                        return true;
                    }
                    int i17 = f9002xd;
                    f9002xd = i17 - 1;
                    if (i17 > 0) {
                        ActivityC2266vc.m9074Xb(null, 4, false, true);
                        return true;
                    }
                    ActivityC2266vc.m9072Ub(-1);
                    return true;
                }
                if (bArr[i] != 4) {
                    int i18 = f9002xd;
                    f9002xd = i18 - 1;
                    if (i18 > 0) {
                        ActivityC2266vc.m9074Xb(null, 2, false, true);
                    } else {
                        ActivityC2266vc.m9072Ub(-1);
                    }
                    return false;
                }
                f8890Yd[0] = 8;
                byte b2 = bArr[i + 1];
                f8783Cg.m8793r9(b2, 16, 0L);
                if (b2 != 15) {
                    ActivityC2266vc.m9074Xb(f8890Yd, 2, false, true);
                    return true;
                }
                enumC2294y = EnumC2294y.MODE_WALBRO_ERASED;
                m9135Ne(enumC2294y);
                return true;
            case 69:
                if (bArr[i] == 4) {
                    byte[] bArr5 = f8890Yd;
                    if (bArr5[0] == 8) {
                        bArr5[0] = 6;
                        ActivityC2266vc.m9074Xb(bArr5, 1, false, true);
                        return true;
                    }
                    LedBar.m8097j(2);
                    m9135Ne(enumC2294y);
                    return true;
                }
                ActivityC2266vc.m9072Ub(-1);
                return false;
            case 70:
                if (i2 == 1) {
                    if (bArr[i] == 75) {
                        f8890Yd = new byte[37];
                        System.arraycopy(ActivityC2225t.f8440Bd, MainActivity.f7169j7, f8890Yd, 0, 37);
                        ActivityC2266vc.m9074Xb(f8890Yd, 4, false, true);
                        return true;
                    }
                    if (bArr[i] != 4) {
                        ActivityC2266vc.m9072Ub(-1);
                    }
                } else if (bArr[i] == 78) {
                    int i19 = MainActivity.f7169j7 + 37;
                    MainActivity.f7169j7 = i19;
                    f8783Cg.m8793r9(i19, ActivityC2225t.f8440Bd.length, f8825Ld);
                    enumC2294y = MainActivity.f7169j7 < ActivityC2225t.f8440Bd.length ? EnumC2294y.MODE_WALBRO_DOWNLOAD : EnumC2294y.MODE_WALBRO_END_PROG;
                    m9135Ne(enumC2294y);
                    return true;
                }
                return false;
            case 71:
                if (bArr[i] == 69) {
                    m9135Ne(EnumC2294y.MODE_NULL);
                    f8783Cg.m8734K9(null, null, f8778Bg.m9079Tb(EnumC2281x.END_DOWNLOAD), 0, 3, 2, 13);
                    return true;
                }
                return false;
            default:
                return false;
        }
    }

    /* JADX INFO: renamed from: Pd */
    private static void m9142Pd() {
        int length = f8895Zd.length;
        byte[] bArr = new byte[((length + 5) / 6) * 7];
        int i = 1;
        int i2 = 0;
        int i3 = 0;
        int i4 = 0;
        while (i2 < length) {
            int i5 = i + 1;
            bArr[i3] = (byte) ((i & 15) | 32);
            i3++;
            int i6 = 0;
            while (i6 < Math.min(length - i4, 6)) {
                bArr[i3] = f8895Zd[i2];
                i6++;
                i3++;
                i2++;
            }
            i4 += 6;
            i = i5;
        }
        m9177Yc(bArr, (byte) 0);
    }

    /* JADX INFO: renamed from: Pe */
    public static byte[] m9143Pe(String str, int i) {
        byte bIndexOf;
        byte[] bArr = new byte[4];
        if (str.length() == i) {
            for (int i2 = 0; i2 < i / 2; i2++) {
                byte bIndexOf2 = (byte) "0123456789ABCDEF".indexOf(str.substring(0, 1));
                if (bIndexOf2 >= 0 && (bIndexOf = (byte) "0123456789ABCDEF".indexOf(str.substring(1, 2))) >= 0) {
                    bArr[i2] = (byte) (bIndexOf | (bIndexOf2 << 4));
                }
                str = str.substring(2);
            }
        }
        return bArr;
    }

    /* JADX INFO: renamed from: Qb */
    private static int m9144Qb(int i) {
        int[] iArr = C2112kc.f8063h;
        int[] iArr2 = C2112kc.f8062g;
        int[] iArr3 = new int[4];
        int[] iArr4 = new int[4];
        iArr3[0] = i;
        iArr3[1] = 21;
        byte[] bArrM9127Le = m9127Le(MainActivity.f7030Tb);
        int i2 = 0;
        while (i2 < 3) {
            int i3 = bArrM9127Le[i2] & 255;
            i2++;
            iArr3[1] = (i3 << (i2 * 8)) | iArr3[1];
        }
        for (int i4 = 0; i4 < 2; i4++) {
            iArr3[2] = ((bArrM9127Le[i4 + 3] & 255) << (i4 * 8)) | iArr3[2];
        }
        int i5 = iArr3[2];
        int i6 = f8786De;
        int i7 = 16;
        iArr3[2] = i5 | (((i6 >> 16) & 255) << 16);
        iArr3[2] = iArr3[2] | (((i6 >> 8) & 255) << 24);
        iArr3[3] = i6 & 255;
        int i8 = 0;
        while (i8 < 3) {
            int i9 = (f8791Ee >> ((2 - i8) * 8)) & 255;
            i8++;
            iArr3[3] = (i9 << (i8 * 8)) | iArr3[3];
        }
        int i10 = 9;
        int i11 = 0;
        while (i10 > 0) {
            int i12 = i11 << 2;
            for (int i13 = 0; i13 < 4; i13++) {
                iArr3[i13] = iArr2[i12 + i13] ^ iArr3[i13];
            }
            byte[] bArr = new byte[i7];
            int i14 = 0;
            while (i14 < i7) {
                bArr[i14] = (byte) ((iArr3[i14 / 4] >> ((i14 % 4) * 8)) & 255);
                i14++;
                i7 = 16;
            }
            iArr3[0] = ((iArr[bArr[0] & 255] ^ iArr[(bArr[5] & 255) + 256]) ^ iArr[(bArr[10] & 255) + 512]) ^ iArr[(bArr[15] & 255) + 768];
            iArr3[1] = ((iArr[bArr[4] & 255] ^ iArr[(bArr[9] & 255) + 256]) ^ iArr[(bArr[14] & 255) + 512]) ^ iArr[(bArr[3] & 255) + 768];
            iArr3[2] = ((iArr[bArr[8] & 255] ^ iArr[(bArr[13] & 255) + 256]) ^ iArr[(bArr[2] & 255) + 512]) ^ iArr[(bArr[7] & 255) + 768];
            iArr3[3] = ((iArr[bArr[12] & 255] ^ iArr[(bArr[1] & 255) + 256]) ^ iArr[(bArr[6] & 255) + 512]) ^ iArr[(bArr[11] & 255) + 768];
            i11++;
            i10--;
            i7 = 16;
        }
        byte[] bArr2 = new byte[16];
        int i15 = 0;
        for (int i16 = 16; i15 < i16; i16 = 16) {
            bArr2[i15] = (byte) ((iArr3[i15 / 4] >> ((i15 % 4) * 8)) & 255);
            i15++;
        }
        int i17 = (i11 + 1) << 2;
        for (int i18 = 0; i18 < 4; i18++) {
            iArr4[i18] = iArr2[i17 + i18] ^ iArr3[i18];
        }
        byte[] bArr3 = new byte[16];
        int i19 = 0;
        for (int i20 = 16; i19 < i20; i20 = 16) {
            bArr3[i19] = (byte) ((iArr4[i19 / 4] >> ((i19 % 4) * 8)) & 255);
            i19++;
        }
        bArr2[0] = (byte) ((iArr[bArr3[0] & 255] >> 8) & 255);
        int i21 = bArr3[5] & 255;
        int i22 = iArr[i21];
        bArr2[1] = (byte) ((iArr[i21] >> 8) & 255);
        bArr2[2] = (byte) ((iArr[bArr3[10] & 255] >> 8) & 255);
        bArr2[3] = (byte) ((iArr[bArr3[15] & 255] >> 8) & 255);
        bArr2[4] = (byte) ((iArr[bArr3[4] & 255] >> 8) & 255);
        bArr2[5] = (byte) ((iArr[bArr3[9] & 255] >> 8) & 255);
        bArr2[6] = (byte) ((iArr[bArr3[14] & 255] >> 8) & 255);
        bArr2[7] = (byte) ((iArr[bArr3[3] & 255] >> 8) & 255);
        bArr2[8] = (byte) ((iArr[bArr3[8] & 255] >> 8) & 255);
        bArr2[9] = (byte) ((iArr[bArr3[13] & 255] >> 8) & 255);
        bArr2[10] = (byte) ((iArr[bArr3[2] & 255] >> 8) & 255);
        bArr2[11] = (byte) ((iArr[bArr3[7] & 255] >> 8) & 255);
        bArr2[12] = (byte) ((iArr[bArr3[12] & 255] >> 8) & 255);
        bArr2[13] = (byte) ((iArr[bArr3[1] & 255] >> 8) & 255);
        bArr2[14] = (byte) ((iArr[bArr3[6] & 255] >> 8) & 255);
        bArr2[15] = (byte) ((iArr[bArr3[11] & 255] >> 8) & 255);
        for (int i23 = 0; i23 < 4; i23++) {
            int i24 = 0;
            for (int i25 = 0; i25 < 4; i25++) {
                i24 |= (bArr2[(i23 * 4) + i25] & 255) << (i25 * 8);
            }
            iArr3[i23] = i24;
        }
        for (int i26 = 0; i26 < 4; i26++) {
            iArr3[i26] = iArr2[(i17 + i26) + 4] ^ iArr3[i26];
        }
        return iArr3[0];
    }

    /* JADX INFO: renamed from: Qc */
    private static int m9145Qc(int i, int i2, long[] jArr) {
        if (jArr == null) {
            jArr = C2198r0.f8292a;
        }
        for (int i3 = 0; i3 < jArr.length / 8; i3++) {
            int i4 = i3 * 8;
            if (((jArr[i4] >> 16) & 65535) == i && jArr[i4 + 3] == i2) {
                return (int) ((jArr[i4 + 7] >> 20) & 255);
            }
        }
        return 0;
    }

    /* JADX INFO: renamed from: Qd */
    private static void m9146Qd() {
        int i;
        boolean z = f8777Bf;
        byte[] bArr = new byte[z ? 3 : 2];
        if (z) {
            bArr[0] = 2;
            i = 1;
        } else {
            i = 0;
        }
        bArr[i] = 16;
        bArr[i + 1] = f8850Qd;
        m9098Ed(bArr, -1, false);
    }

    /* JADX WARN: Code duplicated, block: B:48:0x00ae  */
    /* JADX INFO: renamed from: Qe */
    private static void m9147Qe(byte[] bArr) {
        if (bArr.length < 6) {
            return;
        }
        byte[] bArrM9218mc = m9218mc(bArr);
        byte b2 = bArrM9218mc[5];
        if (b2 == 80) {
            f8835Nd = (byte) 1;
            m9135Ne(EnumC2294y.MODE_SEED);
            ActivityC2266vc.f8594Zd = false;
            return;
        }
        if (b2 == 98) {
            if (bArrM9218mc[7] == 16) {
                MainActivity.f7050W4 = bArrM9218mc[8] > 0;
                if (MainActivity.f6957La == 0) {
                    m9229pe((byte) 20);
                    return;
                }
                return;
            }
            if (bArrM9218mc[7] == 20) {
                MainActivity.f6985Ob = m9124Lb(bArr, 8, 4, false, false).toUpperCase();
                if (MainActivity.f6957La == 0) {
                    m9229pe((byte) 21);
                    return;
                }
                return;
            }
            if (bArrM9218mc[7] == 21) {
                MainActivity.f6994Pb = m9124Lb(bArr, 8, 4, false, false).toUpperCase();
                if (MainActivity.f6957La == 0) {
                    f8783Cg.m8727Ca();
                    return;
                }
                return;
            }
            return;
        }
        if (b2 == 103) {
            if (bArrM9218mc[6] == 1 && bArrM9218mc[4] == 4) {
                m9114Id(m9140Pb(((bArr[8] & 255) | (bArr[7] << 8)) & 65535));
                return;
            } else {
                if (bArrM9218mc[6] == 2) {
                    LedBar.m8097j(2);
                    m9135Ne(EnumC2294y.MODE_TPMS_READ);
                    return;
                }
                return;
            }
        }
        if (b2 == 110) {
            ActivityC2266vc.f8594Zd = false;
            if (bArrM9218mc[7] == 16) {
                int i = f8823Kg;
                if ((i & 1) == 1) {
                    m9223ne((byte) 20, MainActivity.f6985Ob);
                } else if ((i & 2) == 2) {
                    m9223ne((byte) 21, MainActivity.f6994Pb);
                }
            } else if (bArrM9218mc[7] == 20) {
                int i2 = f8823Kg & 2;
                f8823Kg = i2;
                if ((i2 & 2) == 2) {
                    m9223ne((byte) 21, MainActivity.f6994Pb);
                }
            } else if (bArrM9218mc[7] == 21) {
                f8823Kg = 0;
            }
            if (f8823Kg == 0) {
                m9229pe((byte) 16);
                return;
            }
            return;
        }
        if (b2 != 126) {
            if (b2 == 127 && bArrM9218mc[6] == 39) {
                f8783Cg.m8734K9(null, null, MainActivity.f7299y4.getResources().getStringArray(R.array.eMessage)[5], 0, 12, 1, 0);
                MainActivity.f6939Ja = 1;
                f8783Cg.m8805y8(false);
                return;
            }
            return;
        }
        if (f8992vd == EnumC2294y.MODE_TPMS_WRITE) {
            if (f9000wg) {
                m9223ne((byte) 16, MainActivity.f7050W4 ? "0" : "1");
                return;
            }
            int i3 = f8823Kg;
            if ((i3 & 1) == 1) {
                m9223ne((byte) 20, MainActivity.f6985Ob);
            } else if ((i3 & 2) == 2) {
                m9223ne((byte) 21, MainActivity.f6994Pb);
            }
        }
    }

    /* JADX INFO: renamed from: Rb */
    private static int m9148Rb(int i) {
        int i2 = f8786De;
        int i3 = i2 & 255;
        int i4 = ((i2 >> 8) & 255 & 31) + 1;
        int i5 = (f8781Ce * i3) + (1339490472 << i4) + (1339490472 >> (32 - i4));
        int i6 = (i & 65535) * 21044;
        int i7 = i6 + i5;
        int i8 = i6 > ((-1) - i5) + 2 ? 1 : 0;
        if (i8 == 0) {
            return i7 & 65535;
        }
        int i9 = i8;
        int i10 = i7;
        int i11 = 0;
        int i12 = 64;
        while (i12 > 0) {
            int i13 = i10 * 2;
            int i14 = ((byte) ((i10 >> 31) == 0 ? 0 : 1)) + (i9 * 2);
            i11 = (i11 * 2) + ((byte) ((i9 >> 31) == 0 ? 0 : 1));
            if (i11 >= 65536) {
                i11 -= 65536;
                i13++;
            }
            i12--;
            i9 = i14;
            i10 = i13;
        }
        return i11;
    }

    /* JADX INFO: renamed from: Rc */
    private static int m9149Rc(int i) {
        byte b2 = f8835Nd;
        int i2 = 0;
        int i3 = b2 == 3 ? 2 : b2 == -5 ? 1 : 0;
        int i4 = i & 65535;
        short s = f8854Qh[i3];
        for (int i5 = 32768; i5 > 0; i5 /= 2) {
            if ((s & i5) > 0) {
                i2 *= 2;
                if ((i4 & i5) > 0) {
                    i2++;
                }
            }
        }
        return (((i4 ^ 65535) * (f8859Rh[i2 + (i3 * 8)] & 255)) >> 6) & 65535;
    }

    /* JADX INFO: renamed from: Rd */
    public static void m9150Rd() {
        short s = (short) MainActivity.f7160i7;
        m9098Ed(new byte[]{2, (byte) ((s >> 8) & 255), (byte) (s & 255)}, -1, false);
        f8798Fg = s;
    }

    /* JADX INFO: renamed from: Re */
    public static void m9151Re(boolean z, boolean z2, boolean z3) {
        f9000wg = z;
        f8823Kg = (z2 ? 1 : 0) + (z3 ? 2 : 0);
        ActivityC2266vc.f8594Zd = true;
    }

    /* JADX WARN: Code duplicated, block: B:28:0x0058  */
    /* JADX INFO: renamed from: Sb */
    private static int m9152Sb(int i) {
        int i2;
        int i3;
        int i4 = i & 65535;
        int i5 = 0;
        if (f8845Pd >= 3) {
            f8845Pd = (byte) 0;
        }
        m9095De();
        if (f9007yd == 247) {
            i2 = f8790Ed;
            if (f8847Pf) {
                i5 = 51087;
            }
        } else {
            if (f8876Ve) {
                boolean z = f8857Rf;
                if (f8867Tf && f8982sg) {
                    i5 = 1;
                }
                if (((z ? 1 : 0) | i5) != 0) {
                    i3 = f8848Pg[f8845Pd + 3];
                } else if (f8835Nd == 1) {
                    i5 = 39508;
                } else {
                    i3 = f8848Pg[f8845Pd];
                }
                i5 = i3;
            } else if (f8812If) {
                i5 = 39496;
            } else if (f8881We) {
                if (f8891Ye) {
                    i5 = 48689;
                } else if (f8867Tf) {
                    i5 = 17232;
                } else {
                    i5 = 39496;
                }
            } else if (f8926ff) {
                i5 = 11090 - (f8867Tf ? 1 : 0);
            }
            i2 = f8795Fd;
        }
        return (i4 * (i2 ^ i5)) & 65535;
    }

    /* JADX INFO: renamed from: Sc */
    private static void m9153Sc() {
        m9098Ed(new byte[]{-96}, 6, false);
    }

    /* JADX INFO: renamed from: Sd */
    private static void m9154Sd() {
        m9098Ed(new byte[]{54, 17, 0, -2, 2, 1, (byte) ((f8816Je + f8826Le) / 16384)}, -1, true);
    }

    /* JADX INFO: renamed from: Se */
    private static void m9155Se(String str) {
        String str2;
        f8997wd = -1;
        f8954lg = false;
        m9135Ne(EnumC2294y.MODE_NULL);
        String strM9079Tb = f8778Bg.m9079Tb(EnumC2281x.ERR_VERSION_MAP);
        if (str != null) {
            str2 = " (ECU " + str + ")";
        } else {
            str2 = "";
        }
        f8783Cg.m8734K9(null, null, strM9079Tb + str2, 0, 2, 1, 8);
    }

    /* JADX INFO: renamed from: Tb */
    private static int m9156Tb(int i) {
        return ((((i & 65535) * 54549) & 65535) ^ 28956) & 65535;
    }

    /* JADX INFO: renamed from: Tc */
    private static void m9157Tc() {
        m9098Ed(new byte[]{20, 0, 0}, 7, false);
    }

    /* JADX INFO: renamed from: Td */
    private static void m9158Td() {
        m9098Ed(new byte[]{-125, 3, 30, 2, 10, 20, 0}, -1, false);
    }

    /* JADX INFO: renamed from: Te */
    public static void m9159Te() {
        f8862Sf = true;
        f8857Rf = true;
        f8931gf = true;
        MainActivity.f6992P9 = false;
        ActivityC2266vc.f8576Hd = 3;
        m9135Ne(EnumC2294y.MODE_NULL);
        f8783Cg.m8734K9(null, null, f8778Bg.m9079Tb(EnumC2281x.PLUG_SWITCH), 0, 20, 2, 15);
        f8842Of = true;
        m9119Je();
        f8778Bg.m9078Rb(9600, true);
    }

    /* JADX WARN: Code duplicated, block: B:1161:0x02c4 A[SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:1163:0x0264 A[SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:1167:0x029d A[SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:187:0x021e  */
    /* JADX WARN: Code duplicated, block: B:198:0x025a  */
    /* JADX WARN: Code duplicated, block: B:202:0x026a  */
    /* JADX WARN: Code duplicated, block: B:205:0x0275  */
    /* JADX WARN: Code duplicated, block: B:208:0x027c  */
    /* JADX WARN: Code duplicated, block: B:211:0x029f A[LOOP:4: B:207:0x027a->B:211:0x029f, LOOP_END] */
    /* JADX WARN: Code duplicated, block: B:214:0x02aa  */
    /* JADX WARN: Code duplicated, block: B:219:0x02bd  */
    /* JADX WARN: Code duplicated, block: B:646:0x0ad1 A[Catch: Exception -> 0x150b, TryCatch #0 {Exception -> 0x150b, blocks: (B:224:0x02cb, B:268:0x032c, B:272:0x0339, B:274:0x033c, B:276:0x0347, B:295:0x036f, B:296:0x0371, B:297:0x0376, B:298:0x037c, B:302:0x0385, B:306:0x0392, B:308:0x0395, B:309:0x039d, B:311:0x03a1, B:312:0x03a6, B:315:0x03ae, B:316:0x03b3, B:319:0x03b8, B:320:0x03be, B:321:0x03c2, B:323:0x03c9, B:324:0x03cd, B:325:0x03d2, B:327:0x03d9, B:329:0x03e1, B:330:0x03fe, B:331:0x0403, B:332:0x041a, B:334:0x041e, B:335:0x0436, B:337:0x043a, B:339:0x0442, B:340:0x0458, B:344:0x0461, B:348:0x0469, B:350:0x046c, B:351:0x0483, B:352:0x049a, B:353:0x049e, B:354:0x04a2, B:355:0x04a7, B:356:0x04ab, B:357:0x04c4, B:360:0x04ca, B:361:0x04ce, B:365:0x04db, B:366:0x04e0, B:367:0x04e4, B:369:0x04ff, B:371:0x050a, B:372:0x050e, B:373:0x0513, B:374:0x0518, B:375:0x051b, B:376:0x0525, B:377:0x0529, B:379:0x052e, B:381:0x0536, B:383:0x053a, B:385:0x0542, B:386:0x054a, B:387:0x054e, B:389:0x0552, B:390:0x0563, B:391:0x0568, B:392:0x057a, B:394:0x0582, B:396:0x0586, B:397:0x059f, B:399:0x05a3, B:401:0x05a9, B:403:0x05b1, B:404:0x05b5, B:406:0x05bb, B:407:0x05bf, B:408:0x05e8, B:410:0x05ec, B:411:0x05ff, B:412:0x0625, B:414:0x062d, B:416:0x0633, B:418:0x0637, B:420:0x0641, B:422:0x0645, B:424:0x064f, B:426:0x0688, B:430:0x0693, B:427:0x068d, B:429:0x0691, B:431:0x069e, B:433:0x06a2, B:435:0x06e1, B:434:0x06cd, B:436:0x06f9, B:438:0x06fd, B:440:0x0705, B:442:0x0711, B:444:0x071f, B:446:0x0735, B:447:0x074a, B:449:0x0752, B:451:0x0756, B:453:0x075a, B:454:0x075e, B:455:0x0763, B:457:0x076c, B:458:0x0787, B:441:0x0708, B:443:0x0718, B:459:0x07a4, B:461:0x07aa, B:480:0x07d6, B:482:0x07db, B:483:0x07fd, B:484:0x0803, B:485:0x0808, B:487:0x0825, B:489:0x082e, B:490:0x0838, B:492:0x0852, B:494:0x0856, B:496:0x085a, B:500:0x0864, B:502:0x0868, B:505:0x08b1, B:506:0x08c8, B:510:0x08d6, B:512:0x08e0, B:514:0x08eb, B:524:0x08fd, B:525:0x0900, B:526:0x092f, B:528:0x0944, B:530:0x094f, B:532:0x0956, B:536:0x0965, B:538:0x099f, B:539:0x09a6, B:541:0x09c5, B:601:0x0a53, B:605:0x0a5c, B:613:0x0a76, B:617:0x0a7e, B:625:0x0a8d, B:644:0x0aca, B:646:0x0ad1, B:647:0x0ad7, B:657:0x0ae9, B:661:0x0af1, B:670:0x0b02, B:672:0x0b23, B:676:0x0b3e, B:678:0x0b55, B:679:0x0b59, B:671:0x0b05, B:632:0x0a9b, B:637:0x0aa8, B:641:0x0ab4, B:550:0x09e4, B:554:0x09ec, B:558:0x09f4, B:570:0x0a0f, B:578:0x0a1f, B:582:0x0a27, B:586:0x0a2f, B:600:0x0a51, B:589:0x0a35, B:561:0x09fa, B:680:0x0b5d, B:681:0x0b66, B:682:0x0b6b, B:684:0x0b8a, B:686:0x0bb9, B:689:0x0bd1, B:691:0x0bea, B:693:0x0bf7, B:692:0x0bef, B:694:0x0bfb, B:696:0x0bff, B:698:0x0c08, B:700:0x0c0c, B:702:0x0c14, B:704:0x0c2f, B:706:0x0c33, B:708:0x0c37, B:710:0x0c3b, B:712:0x0c42, B:714:0x0c77, B:716:0x0c81, B:717:0x0c86, B:718:0x0c8a, B:720:0x0cab, B:722:0x0caf, B:724:0x0cb6, B:726:0x0cda, B:728:0x0cdf, B:729:0x0d29, B:730:0x0d31, B:732:0x0d35, B:734:0x0d51, B:735:0x0d6c, B:737:0x0dfe, B:740:0x0e1e, B:742:0x0e28, B:744:0x0e3a, B:745:0x0e3f, B:749:0x0e56, B:750:0x0e5d, B:751:0x0e8e, B:753:0x0e94, B:755:0x0e98, B:756:0x0ea0, B:758:0x0ea5, B:760:0x0eb6, B:761:0x0ebc, B:762:0x0ec3, B:764:0x0ec9, B:856:0x1046, B:860:0x104d, B:863:0x1054, B:865:0x1057, B:781:0x0ef7, B:783:0x0eff, B:785:0x0f03, B:787:0x0f0d, B:788:0x0f14, B:789:0x0f19, B:793:0x0f24, B:797:0x0f34, B:799:0x0f37, B:800:0x0f3e, B:801:0x0f51, B:803:0x0f57, B:804:0x0f5e, B:805:0x0f63, B:807:0x0f74, B:811:0x0f7d, B:812:0x0f8d, B:816:0x0fa2, B:820:0x0fa9, B:822:0x0fac, B:832:0x0fc1, B:834:0x0fc5, B:836:0x0fcf, B:837:0x0fd5, B:839:0x0fdd, B:840:0x0fe3, B:829:0x0fbc, B:831:0x0fbf, B:841:0x0fe9, B:843:0x0ff7, B:845:0x0ffb, B:847:0x1005, B:849:0x100f, B:851:0x1013, B:848:0x100a, B:852:0x1019, B:854:0x102f, B:855:0x1033, B:866:0x105d, B:868:0x1062, B:870:0x1068, B:871:0x1082, B:878:0x1090, B:881:0x1094, B:883:0x109b, B:887:0x10a6, B:891:0x10b0, B:895:0x10b8, B:897:0x10bb, B:898:0x10bd, B:899:0x10c0, B:901:0x10c4, B:902:0x10c9, B:903:0x10ce, B:905:0x10d2, B:907:0x10d6, B:909:0x10dd, B:911:0x10e3, B:908:0x10da, B:912:0x10ea, B:914:0x10ee, B:916:0x10f2, B:917:0x10fe, B:918:0x1103, B:920:0x1107, B:921:0x110b, B:923:0x110f, B:924:0x1114, B:926:0x1118, B:927:0x1121, B:929:0x1128, B:930:0x112c, B:932:0x1130, B:933:0x113b, B:935:0x113f, B:936:0x1147, B:938:0x114b, B:942:0x1153, B:943:0x1159, B:945:0x115d, B:946:0x1162, B:948:0x1166, B:949:0x116a, B:951:0x1170, B:952:0x1178, B:954:0x117c, B:955:0x117f, B:957:0x1183, B:959:0x118d, B:960:0x1195, B:962:0x1199, B:964:0x11a3, B:966:0x11ae, B:967:0x11b2, B:969:0x11b6, B:971:0x11c0, B:972:0x11c9, B:973:0x11de, B:975:0x11e2, B:979:0x11f4, B:981:0x1200, B:983:0x1204, B:984:0x120d, B:986:0x1211, B:987:0x1214, B:989:0x1218, B:990:0x1224, B:992:0x1228, B:993:0x1230, B:994:0x1234, B:995:0x125b, B:997:0x1261, B:999:0x1270, B:1003:0x1277, B:1005:0x127a, B:1007:0x1284, B:1010:0x128b, B:1012:0x1296, B:1013:0x12a4, B:1014:0x12a8, B:1015:0x12bc, B:1019:0x12c9, B:1021:0x12d2, B:1023:0x12d6, B:1024:0x12e5, B:1025:0x12f3, B:1029:0x12ff, B:1031:0x1303, B:1047:0x1324, B:1048:0x132d, B:1113:0x1460, B:1049:0x1334, B:1050:0x133d, B:1054:0x134b, B:1055:0x1350, B:1057:0x1356, B:1058:0x1366, B:1059:0x136e, B:1060:0x137b, B:1062:0x1383, B:1064:0x1389, B:1068:0x1392, B:1070:0x1396, B:1071:0x139e, B:1073:0x13a8, B:1074:0x13b6, B:1075:0x13c3, B:1076:0x13d0, B:1078:0x13d6, B:1079:0x13df, B:1081:0x13e4, B:1083:0x13ea, B:1086:0x13f2, B:1088:0x13f8, B:1089:0x13fd, B:1091:0x1401, B:1093:0x1406, B:1094:0x140b, B:1095:0x140e, B:1097:0x1413, B:1098:0x1416, B:1099:0x1419, B:1101:0x141d, B:1105:0x142d, B:1108:0x1437, B:1111:0x144a, B:1112:0x1450, B:1116:0x1468, B:1118:0x146c, B:1120:0x1474, B:1121:0x1489, B:1123:0x148f, B:1125:0x1497, B:1127:0x149e, B:1128:0x14a3, B:1129:0x14bb, B:1130:0x14d7, B:1131:0x14f3, B:1138:0x14fe, B:1140:0x1502), top: B:1147:0x02cb }] */
    /* JADX WARN: Code duplicated, block: B:649:0x0adb  */
    /* JADX WARN: Code duplicated, block: B:651:0x0adf  */
    /* JADX WARN: Code duplicated, block: B:652:0x0ae1  */
    /* JADX WARN: Code duplicated, block: B:655:0x0ae6  */
    /* JADX WARN: Code duplicated, block: B:656:0x0ae8  */
    /* JADX WARN: Code duplicated, block: B:659:0x0aee  */
    /* JADX WARN: Code duplicated, block: B:660:0x0af0  */
    /* JADX WARN: Code duplicated, block: B:663:0x0af4  */
    /* JADX WARN: Code duplicated, block: B:664:0x0af6  */
    /* JADX WARN: Code duplicated, block: B:666:0x0afa  */
    /* JADX WARN: Code duplicated, block: B:669:0x0b00  */
    /* JADX WARN: Code duplicated, block: B:671:0x0b05 A[Catch: Exception -> 0x150b, TryCatch #0 {Exception -> 0x150b, blocks: (B:224:0x02cb, B:268:0x032c, B:272:0x0339, B:274:0x033c, B:276:0x0347, B:295:0x036f, B:296:0x0371, B:297:0x0376, B:298:0x037c, B:302:0x0385, B:306:0x0392, B:308:0x0395, B:309:0x039d, B:311:0x03a1, B:312:0x03a6, B:315:0x03ae, B:316:0x03b3, B:319:0x03b8, B:320:0x03be, B:321:0x03c2, B:323:0x03c9, B:324:0x03cd, B:325:0x03d2, B:327:0x03d9, B:329:0x03e1, B:330:0x03fe, B:331:0x0403, B:332:0x041a, B:334:0x041e, B:335:0x0436, B:337:0x043a, B:339:0x0442, B:340:0x0458, B:344:0x0461, B:348:0x0469, B:350:0x046c, B:351:0x0483, B:352:0x049a, B:353:0x049e, B:354:0x04a2, B:355:0x04a7, B:356:0x04ab, B:357:0x04c4, B:360:0x04ca, B:361:0x04ce, B:365:0x04db, B:366:0x04e0, B:367:0x04e4, B:369:0x04ff, B:371:0x050a, B:372:0x050e, B:373:0x0513, B:374:0x0518, B:375:0x051b, B:376:0x0525, B:377:0x0529, B:379:0x052e, B:381:0x0536, B:383:0x053a, B:385:0x0542, B:386:0x054a, B:387:0x054e, B:389:0x0552, B:390:0x0563, B:391:0x0568, B:392:0x057a, B:394:0x0582, B:396:0x0586, B:397:0x059f, B:399:0x05a3, B:401:0x05a9, B:403:0x05b1, B:404:0x05b5, B:406:0x05bb, B:407:0x05bf, B:408:0x05e8, B:410:0x05ec, B:411:0x05ff, B:412:0x0625, B:414:0x062d, B:416:0x0633, B:418:0x0637, B:420:0x0641, B:422:0x0645, B:424:0x064f, B:426:0x0688, B:430:0x0693, B:427:0x068d, B:429:0x0691, B:431:0x069e, B:433:0x06a2, B:435:0x06e1, B:434:0x06cd, B:436:0x06f9, B:438:0x06fd, B:440:0x0705, B:442:0x0711, B:444:0x071f, B:446:0x0735, B:447:0x074a, B:449:0x0752, B:451:0x0756, B:453:0x075a, B:454:0x075e, B:455:0x0763, B:457:0x076c, B:458:0x0787, B:441:0x0708, B:443:0x0718, B:459:0x07a4, B:461:0x07aa, B:480:0x07d6, B:482:0x07db, B:483:0x07fd, B:484:0x0803, B:485:0x0808, B:487:0x0825, B:489:0x082e, B:490:0x0838, B:492:0x0852, B:494:0x0856, B:496:0x085a, B:500:0x0864, B:502:0x0868, B:505:0x08b1, B:506:0x08c8, B:510:0x08d6, B:512:0x08e0, B:514:0x08eb, B:524:0x08fd, B:525:0x0900, B:526:0x092f, B:528:0x0944, B:530:0x094f, B:532:0x0956, B:536:0x0965, B:538:0x099f, B:539:0x09a6, B:541:0x09c5, B:601:0x0a53, B:605:0x0a5c, B:613:0x0a76, B:617:0x0a7e, B:625:0x0a8d, B:644:0x0aca, B:646:0x0ad1, B:647:0x0ad7, B:657:0x0ae9, B:661:0x0af1, B:670:0x0b02, B:672:0x0b23, B:676:0x0b3e, B:678:0x0b55, B:679:0x0b59, B:671:0x0b05, B:632:0x0a9b, B:637:0x0aa8, B:641:0x0ab4, B:550:0x09e4, B:554:0x09ec, B:558:0x09f4, B:570:0x0a0f, B:578:0x0a1f, B:582:0x0a27, B:586:0x0a2f, B:600:0x0a51, B:589:0x0a35, B:561:0x09fa, B:680:0x0b5d, B:681:0x0b66, B:682:0x0b6b, B:684:0x0b8a, B:686:0x0bb9, B:689:0x0bd1, B:691:0x0bea, B:693:0x0bf7, B:692:0x0bef, B:694:0x0bfb, B:696:0x0bff, B:698:0x0c08, B:700:0x0c0c, B:702:0x0c14, B:704:0x0c2f, B:706:0x0c33, B:708:0x0c37, B:710:0x0c3b, B:712:0x0c42, B:714:0x0c77, B:716:0x0c81, B:717:0x0c86, B:718:0x0c8a, B:720:0x0cab, B:722:0x0caf, B:724:0x0cb6, B:726:0x0cda, B:728:0x0cdf, B:729:0x0d29, B:730:0x0d31, B:732:0x0d35, B:734:0x0d51, B:735:0x0d6c, B:737:0x0dfe, B:740:0x0e1e, B:742:0x0e28, B:744:0x0e3a, B:745:0x0e3f, B:749:0x0e56, B:750:0x0e5d, B:751:0x0e8e, B:753:0x0e94, B:755:0x0e98, B:756:0x0ea0, B:758:0x0ea5, B:760:0x0eb6, B:761:0x0ebc, B:762:0x0ec3, B:764:0x0ec9, B:856:0x1046, B:860:0x104d, B:863:0x1054, B:865:0x1057, B:781:0x0ef7, B:783:0x0eff, B:785:0x0f03, B:787:0x0f0d, B:788:0x0f14, B:789:0x0f19, B:793:0x0f24, B:797:0x0f34, B:799:0x0f37, B:800:0x0f3e, B:801:0x0f51, B:803:0x0f57, B:804:0x0f5e, B:805:0x0f63, B:807:0x0f74, B:811:0x0f7d, B:812:0x0f8d, B:816:0x0fa2, B:820:0x0fa9, B:822:0x0fac, B:832:0x0fc1, B:834:0x0fc5, B:836:0x0fcf, B:837:0x0fd5, B:839:0x0fdd, B:840:0x0fe3, B:829:0x0fbc, B:831:0x0fbf, B:841:0x0fe9, B:843:0x0ff7, B:845:0x0ffb, B:847:0x1005, B:849:0x100f, B:851:0x1013, B:848:0x100a, B:852:0x1019, B:854:0x102f, B:855:0x1033, B:866:0x105d, B:868:0x1062, B:870:0x1068, B:871:0x1082, B:878:0x1090, B:881:0x1094, B:883:0x109b, B:887:0x10a6, B:891:0x10b0, B:895:0x10b8, B:897:0x10bb, B:898:0x10bd, B:899:0x10c0, B:901:0x10c4, B:902:0x10c9, B:903:0x10ce, B:905:0x10d2, B:907:0x10d6, B:909:0x10dd, B:911:0x10e3, B:908:0x10da, B:912:0x10ea, B:914:0x10ee, B:916:0x10f2, B:917:0x10fe, B:918:0x1103, B:920:0x1107, B:921:0x110b, B:923:0x110f, B:924:0x1114, B:926:0x1118, B:927:0x1121, B:929:0x1128, B:930:0x112c, B:932:0x1130, B:933:0x113b, B:935:0x113f, B:936:0x1147, B:938:0x114b, B:942:0x1153, B:943:0x1159, B:945:0x115d, B:946:0x1162, B:948:0x1166, B:949:0x116a, B:951:0x1170, B:952:0x1178, B:954:0x117c, B:955:0x117f, B:957:0x1183, B:959:0x118d, B:960:0x1195, B:962:0x1199, B:964:0x11a3, B:966:0x11ae, B:967:0x11b2, B:969:0x11b6, B:971:0x11c0, B:972:0x11c9, B:973:0x11de, B:975:0x11e2, B:979:0x11f4, B:981:0x1200, B:983:0x1204, B:984:0x120d, B:986:0x1211, B:987:0x1214, B:989:0x1218, B:990:0x1224, B:992:0x1228, B:993:0x1230, B:994:0x1234, B:995:0x125b, B:997:0x1261, B:999:0x1270, B:1003:0x1277, B:1005:0x127a, B:1007:0x1284, B:1010:0x128b, B:1012:0x1296, B:1013:0x12a4, B:1014:0x12a8, B:1015:0x12bc, B:1019:0x12c9, B:1021:0x12d2, B:1023:0x12d6, B:1024:0x12e5, B:1025:0x12f3, B:1029:0x12ff, B:1031:0x1303, B:1047:0x1324, B:1048:0x132d, B:1113:0x1460, B:1049:0x1334, B:1050:0x133d, B:1054:0x134b, B:1055:0x1350, B:1057:0x1356, B:1058:0x1366, B:1059:0x136e, B:1060:0x137b, B:1062:0x1383, B:1064:0x1389, B:1068:0x1392, B:1070:0x1396, B:1071:0x139e, B:1073:0x13a8, B:1074:0x13b6, B:1075:0x13c3, B:1076:0x13d0, B:1078:0x13d6, B:1079:0x13df, B:1081:0x13e4, B:1083:0x13ea, B:1086:0x13f2, B:1088:0x13f8, B:1089:0x13fd, B:1091:0x1401, B:1093:0x1406, B:1094:0x140b, B:1095:0x140e, B:1097:0x1413, B:1098:0x1416, B:1099:0x1419, B:1101:0x141d, B:1105:0x142d, B:1108:0x1437, B:1111:0x144a, B:1112:0x1450, B:1116:0x1468, B:1118:0x146c, B:1120:0x1474, B:1121:0x1489, B:1123:0x148f, B:1125:0x1497, B:1127:0x149e, B:1128:0x14a3, B:1129:0x14bb, B:1130:0x14d7, B:1131:0x14f3, B:1138:0x14fe, B:1140:0x1502), top: B:1147:0x02cb }] */
    /* JADX WARN: Code duplicated, block: B:674:0x0b3a  */
    /* JADX WARN: Code duplicated, block: B:675:0x0b3d  */
    /* JADX WARN: Code duplicated, block: B:678:0x0b55 A[Catch: Exception -> 0x150b, TryCatch #0 {Exception -> 0x150b, blocks: (B:224:0x02cb, B:268:0x032c, B:272:0x0339, B:274:0x033c, B:276:0x0347, B:295:0x036f, B:296:0x0371, B:297:0x0376, B:298:0x037c, B:302:0x0385, B:306:0x0392, B:308:0x0395, B:309:0x039d, B:311:0x03a1, B:312:0x03a6, B:315:0x03ae, B:316:0x03b3, B:319:0x03b8, B:320:0x03be, B:321:0x03c2, B:323:0x03c9, B:324:0x03cd, B:325:0x03d2, B:327:0x03d9, B:329:0x03e1, B:330:0x03fe, B:331:0x0403, B:332:0x041a, B:334:0x041e, B:335:0x0436, B:337:0x043a, B:339:0x0442, B:340:0x0458, B:344:0x0461, B:348:0x0469, B:350:0x046c, B:351:0x0483, B:352:0x049a, B:353:0x049e, B:354:0x04a2, B:355:0x04a7, B:356:0x04ab, B:357:0x04c4, B:360:0x04ca, B:361:0x04ce, B:365:0x04db, B:366:0x04e0, B:367:0x04e4, B:369:0x04ff, B:371:0x050a, B:372:0x050e, B:373:0x0513, B:374:0x0518, B:375:0x051b, B:376:0x0525, B:377:0x0529, B:379:0x052e, B:381:0x0536, B:383:0x053a, B:385:0x0542, B:386:0x054a, B:387:0x054e, B:389:0x0552, B:390:0x0563, B:391:0x0568, B:392:0x057a, B:394:0x0582, B:396:0x0586, B:397:0x059f, B:399:0x05a3, B:401:0x05a9, B:403:0x05b1, B:404:0x05b5, B:406:0x05bb, B:407:0x05bf, B:408:0x05e8, B:410:0x05ec, B:411:0x05ff, B:412:0x0625, B:414:0x062d, B:416:0x0633, B:418:0x0637, B:420:0x0641, B:422:0x0645, B:424:0x064f, B:426:0x0688, B:430:0x0693, B:427:0x068d, B:429:0x0691, B:431:0x069e, B:433:0x06a2, B:435:0x06e1, B:434:0x06cd, B:436:0x06f9, B:438:0x06fd, B:440:0x0705, B:442:0x0711, B:444:0x071f, B:446:0x0735, B:447:0x074a, B:449:0x0752, B:451:0x0756, B:453:0x075a, B:454:0x075e, B:455:0x0763, B:457:0x076c, B:458:0x0787, B:441:0x0708, B:443:0x0718, B:459:0x07a4, B:461:0x07aa, B:480:0x07d6, B:482:0x07db, B:483:0x07fd, B:484:0x0803, B:485:0x0808, B:487:0x0825, B:489:0x082e, B:490:0x0838, B:492:0x0852, B:494:0x0856, B:496:0x085a, B:500:0x0864, B:502:0x0868, B:505:0x08b1, B:506:0x08c8, B:510:0x08d6, B:512:0x08e0, B:514:0x08eb, B:524:0x08fd, B:525:0x0900, B:526:0x092f, B:528:0x0944, B:530:0x094f, B:532:0x0956, B:536:0x0965, B:538:0x099f, B:539:0x09a6, B:541:0x09c5, B:601:0x0a53, B:605:0x0a5c, B:613:0x0a76, B:617:0x0a7e, B:625:0x0a8d, B:644:0x0aca, B:646:0x0ad1, B:647:0x0ad7, B:657:0x0ae9, B:661:0x0af1, B:670:0x0b02, B:672:0x0b23, B:676:0x0b3e, B:678:0x0b55, B:679:0x0b59, B:671:0x0b05, B:632:0x0a9b, B:637:0x0aa8, B:641:0x0ab4, B:550:0x09e4, B:554:0x09ec, B:558:0x09f4, B:570:0x0a0f, B:578:0x0a1f, B:582:0x0a27, B:586:0x0a2f, B:600:0x0a51, B:589:0x0a35, B:561:0x09fa, B:680:0x0b5d, B:681:0x0b66, B:682:0x0b6b, B:684:0x0b8a, B:686:0x0bb9, B:689:0x0bd1, B:691:0x0bea, B:693:0x0bf7, B:692:0x0bef, B:694:0x0bfb, B:696:0x0bff, B:698:0x0c08, B:700:0x0c0c, B:702:0x0c14, B:704:0x0c2f, B:706:0x0c33, B:708:0x0c37, B:710:0x0c3b, B:712:0x0c42, B:714:0x0c77, B:716:0x0c81, B:717:0x0c86, B:718:0x0c8a, B:720:0x0cab, B:722:0x0caf, B:724:0x0cb6, B:726:0x0cda, B:728:0x0cdf, B:729:0x0d29, B:730:0x0d31, B:732:0x0d35, B:734:0x0d51, B:735:0x0d6c, B:737:0x0dfe, B:740:0x0e1e, B:742:0x0e28, B:744:0x0e3a, B:745:0x0e3f, B:749:0x0e56, B:750:0x0e5d, B:751:0x0e8e, B:753:0x0e94, B:755:0x0e98, B:756:0x0ea0, B:758:0x0ea5, B:760:0x0eb6, B:761:0x0ebc, B:762:0x0ec3, B:764:0x0ec9, B:856:0x1046, B:860:0x104d, B:863:0x1054, B:865:0x1057, B:781:0x0ef7, B:783:0x0eff, B:785:0x0f03, B:787:0x0f0d, B:788:0x0f14, B:789:0x0f19, B:793:0x0f24, B:797:0x0f34, B:799:0x0f37, B:800:0x0f3e, B:801:0x0f51, B:803:0x0f57, B:804:0x0f5e, B:805:0x0f63, B:807:0x0f74, B:811:0x0f7d, B:812:0x0f8d, B:816:0x0fa2, B:820:0x0fa9, B:822:0x0fac, B:832:0x0fc1, B:834:0x0fc5, B:836:0x0fcf, B:837:0x0fd5, B:839:0x0fdd, B:840:0x0fe3, B:829:0x0fbc, B:831:0x0fbf, B:841:0x0fe9, B:843:0x0ff7, B:845:0x0ffb, B:847:0x1005, B:849:0x100f, B:851:0x1013, B:848:0x100a, B:852:0x1019, B:854:0x102f, B:855:0x1033, B:866:0x105d, B:868:0x1062, B:870:0x1068, B:871:0x1082, B:878:0x1090, B:881:0x1094, B:883:0x109b, B:887:0x10a6, B:891:0x10b0, B:895:0x10b8, B:897:0x10bb, B:898:0x10bd, B:899:0x10c0, B:901:0x10c4, B:902:0x10c9, B:903:0x10ce, B:905:0x10d2, B:907:0x10d6, B:909:0x10dd, B:911:0x10e3, B:908:0x10da, B:912:0x10ea, B:914:0x10ee, B:916:0x10f2, B:917:0x10fe, B:918:0x1103, B:920:0x1107, B:921:0x110b, B:923:0x110f, B:924:0x1114, B:926:0x1118, B:927:0x1121, B:929:0x1128, B:930:0x112c, B:932:0x1130, B:933:0x113b, B:935:0x113f, B:936:0x1147, B:938:0x114b, B:942:0x1153, B:943:0x1159, B:945:0x115d, B:946:0x1162, B:948:0x1166, B:949:0x116a, B:951:0x1170, B:952:0x1178, B:954:0x117c, B:955:0x117f, B:957:0x1183, B:959:0x118d, B:960:0x1195, B:962:0x1199, B:964:0x11a3, B:966:0x11ae, B:967:0x11b2, B:969:0x11b6, B:971:0x11c0, B:972:0x11c9, B:973:0x11de, B:975:0x11e2, B:979:0x11f4, B:981:0x1200, B:983:0x1204, B:984:0x120d, B:986:0x1211, B:987:0x1214, B:989:0x1218, B:990:0x1224, B:992:0x1228, B:993:0x1230, B:994:0x1234, B:995:0x125b, B:997:0x1261, B:999:0x1270, B:1003:0x1277, B:1005:0x127a, B:1007:0x1284, B:1010:0x128b, B:1012:0x1296, B:1013:0x12a4, B:1014:0x12a8, B:1015:0x12bc, B:1019:0x12c9, B:1021:0x12d2, B:1023:0x12d6, B:1024:0x12e5, B:1025:0x12f3, B:1029:0x12ff, B:1031:0x1303, B:1047:0x1324, B:1048:0x132d, B:1113:0x1460, B:1049:0x1334, B:1050:0x133d, B:1054:0x134b, B:1055:0x1350, B:1057:0x1356, B:1058:0x1366, B:1059:0x136e, B:1060:0x137b, B:1062:0x1383, B:1064:0x1389, B:1068:0x1392, B:1070:0x1396, B:1071:0x139e, B:1073:0x13a8, B:1074:0x13b6, B:1075:0x13c3, B:1076:0x13d0, B:1078:0x13d6, B:1079:0x13df, B:1081:0x13e4, B:1083:0x13ea, B:1086:0x13f2, B:1088:0x13f8, B:1089:0x13fd, B:1091:0x1401, B:1093:0x1406, B:1094:0x140b, B:1095:0x140e, B:1097:0x1413, B:1098:0x1416, B:1099:0x1419, B:1101:0x141d, B:1105:0x142d, B:1108:0x1437, B:1111:0x144a, B:1112:0x1450, B:1116:0x1468, B:1118:0x146c, B:1120:0x1474, B:1121:0x1489, B:1123:0x148f, B:1125:0x1497, B:1127:0x149e, B:1128:0x14a3, B:1129:0x14bb, B:1130:0x14d7, B:1131:0x14f3, B:1138:0x14fe, B:1140:0x1502), top: B:1147:0x02cb }] */
    /* JADX WARN: Code duplicated, block: B:679:0x0b59 A[Catch: Exception -> 0x150b, TryCatch #0 {Exception -> 0x150b, blocks: (B:224:0x02cb, B:268:0x032c, B:272:0x0339, B:274:0x033c, B:276:0x0347, B:295:0x036f, B:296:0x0371, B:297:0x0376, B:298:0x037c, B:302:0x0385, B:306:0x0392, B:308:0x0395, B:309:0x039d, B:311:0x03a1, B:312:0x03a6, B:315:0x03ae, B:316:0x03b3, B:319:0x03b8, B:320:0x03be, B:321:0x03c2, B:323:0x03c9, B:324:0x03cd, B:325:0x03d2, B:327:0x03d9, B:329:0x03e1, B:330:0x03fe, B:331:0x0403, B:332:0x041a, B:334:0x041e, B:335:0x0436, B:337:0x043a, B:339:0x0442, B:340:0x0458, B:344:0x0461, B:348:0x0469, B:350:0x046c, B:351:0x0483, B:352:0x049a, B:353:0x049e, B:354:0x04a2, B:355:0x04a7, B:356:0x04ab, B:357:0x04c4, B:360:0x04ca, B:361:0x04ce, B:365:0x04db, B:366:0x04e0, B:367:0x04e4, B:369:0x04ff, B:371:0x050a, B:372:0x050e, B:373:0x0513, B:374:0x0518, B:375:0x051b, B:376:0x0525, B:377:0x0529, B:379:0x052e, B:381:0x0536, B:383:0x053a, B:385:0x0542, B:386:0x054a, B:387:0x054e, B:389:0x0552, B:390:0x0563, B:391:0x0568, B:392:0x057a, B:394:0x0582, B:396:0x0586, B:397:0x059f, B:399:0x05a3, B:401:0x05a9, B:403:0x05b1, B:404:0x05b5, B:406:0x05bb, B:407:0x05bf, B:408:0x05e8, B:410:0x05ec, B:411:0x05ff, B:412:0x0625, B:414:0x062d, B:416:0x0633, B:418:0x0637, B:420:0x0641, B:422:0x0645, B:424:0x064f, B:426:0x0688, B:430:0x0693, B:427:0x068d, B:429:0x0691, B:431:0x069e, B:433:0x06a2, B:435:0x06e1, B:434:0x06cd, B:436:0x06f9, B:438:0x06fd, B:440:0x0705, B:442:0x0711, B:444:0x071f, B:446:0x0735, B:447:0x074a, B:449:0x0752, B:451:0x0756, B:453:0x075a, B:454:0x075e, B:455:0x0763, B:457:0x076c, B:458:0x0787, B:441:0x0708, B:443:0x0718, B:459:0x07a4, B:461:0x07aa, B:480:0x07d6, B:482:0x07db, B:483:0x07fd, B:484:0x0803, B:485:0x0808, B:487:0x0825, B:489:0x082e, B:490:0x0838, B:492:0x0852, B:494:0x0856, B:496:0x085a, B:500:0x0864, B:502:0x0868, B:505:0x08b1, B:506:0x08c8, B:510:0x08d6, B:512:0x08e0, B:514:0x08eb, B:524:0x08fd, B:525:0x0900, B:526:0x092f, B:528:0x0944, B:530:0x094f, B:532:0x0956, B:536:0x0965, B:538:0x099f, B:539:0x09a6, B:541:0x09c5, B:601:0x0a53, B:605:0x0a5c, B:613:0x0a76, B:617:0x0a7e, B:625:0x0a8d, B:644:0x0aca, B:646:0x0ad1, B:647:0x0ad7, B:657:0x0ae9, B:661:0x0af1, B:670:0x0b02, B:672:0x0b23, B:676:0x0b3e, B:678:0x0b55, B:679:0x0b59, B:671:0x0b05, B:632:0x0a9b, B:637:0x0aa8, B:641:0x0ab4, B:550:0x09e4, B:554:0x09ec, B:558:0x09f4, B:570:0x0a0f, B:578:0x0a1f, B:582:0x0a27, B:586:0x0a2f, B:600:0x0a51, B:589:0x0a35, B:561:0x09fa, B:680:0x0b5d, B:681:0x0b66, B:682:0x0b6b, B:684:0x0b8a, B:686:0x0bb9, B:689:0x0bd1, B:691:0x0bea, B:693:0x0bf7, B:692:0x0bef, B:694:0x0bfb, B:696:0x0bff, B:698:0x0c08, B:700:0x0c0c, B:702:0x0c14, B:704:0x0c2f, B:706:0x0c33, B:708:0x0c37, B:710:0x0c3b, B:712:0x0c42, B:714:0x0c77, B:716:0x0c81, B:717:0x0c86, B:718:0x0c8a, B:720:0x0cab, B:722:0x0caf, B:724:0x0cb6, B:726:0x0cda, B:728:0x0cdf, B:729:0x0d29, B:730:0x0d31, B:732:0x0d35, B:734:0x0d51, B:735:0x0d6c, B:737:0x0dfe, B:740:0x0e1e, B:742:0x0e28, B:744:0x0e3a, B:745:0x0e3f, B:749:0x0e56, B:750:0x0e5d, B:751:0x0e8e, B:753:0x0e94, B:755:0x0e98, B:756:0x0ea0, B:758:0x0ea5, B:760:0x0eb6, B:761:0x0ebc, B:762:0x0ec3, B:764:0x0ec9, B:856:0x1046, B:860:0x104d, B:863:0x1054, B:865:0x1057, B:781:0x0ef7, B:783:0x0eff, B:785:0x0f03, B:787:0x0f0d, B:788:0x0f14, B:789:0x0f19, B:793:0x0f24, B:797:0x0f34, B:799:0x0f37, B:800:0x0f3e, B:801:0x0f51, B:803:0x0f57, B:804:0x0f5e, B:805:0x0f63, B:807:0x0f74, B:811:0x0f7d, B:812:0x0f8d, B:816:0x0fa2, B:820:0x0fa9, B:822:0x0fac, B:832:0x0fc1, B:834:0x0fc5, B:836:0x0fcf, B:837:0x0fd5, B:839:0x0fdd, B:840:0x0fe3, B:829:0x0fbc, B:831:0x0fbf, B:841:0x0fe9, B:843:0x0ff7, B:845:0x0ffb, B:847:0x1005, B:849:0x100f, B:851:0x1013, B:848:0x100a, B:852:0x1019, B:854:0x102f, B:855:0x1033, B:866:0x105d, B:868:0x1062, B:870:0x1068, B:871:0x1082, B:878:0x1090, B:881:0x1094, B:883:0x109b, B:887:0x10a6, B:891:0x10b0, B:895:0x10b8, B:897:0x10bb, B:898:0x10bd, B:899:0x10c0, B:901:0x10c4, B:902:0x10c9, B:903:0x10ce, B:905:0x10d2, B:907:0x10d6, B:909:0x10dd, B:911:0x10e3, B:908:0x10da, B:912:0x10ea, B:914:0x10ee, B:916:0x10f2, B:917:0x10fe, B:918:0x1103, B:920:0x1107, B:921:0x110b, B:923:0x110f, B:924:0x1114, B:926:0x1118, B:927:0x1121, B:929:0x1128, B:930:0x112c, B:932:0x1130, B:933:0x113b, B:935:0x113f, B:936:0x1147, B:938:0x114b, B:942:0x1153, B:943:0x1159, B:945:0x115d, B:946:0x1162, B:948:0x1166, B:949:0x116a, B:951:0x1170, B:952:0x1178, B:954:0x117c, B:955:0x117f, B:957:0x1183, B:959:0x118d, B:960:0x1195, B:962:0x1199, B:964:0x11a3, B:966:0x11ae, B:967:0x11b2, B:969:0x11b6, B:971:0x11c0, B:972:0x11c9, B:973:0x11de, B:975:0x11e2, B:979:0x11f4, B:981:0x1200, B:983:0x1204, B:984:0x120d, B:986:0x1211, B:987:0x1214, B:989:0x1218, B:990:0x1224, B:992:0x1228, B:993:0x1230, B:994:0x1234, B:995:0x125b, B:997:0x1261, B:999:0x1270, B:1003:0x1277, B:1005:0x127a, B:1007:0x1284, B:1010:0x128b, B:1012:0x1296, B:1013:0x12a4, B:1014:0x12a8, B:1015:0x12bc, B:1019:0x12c9, B:1021:0x12d2, B:1023:0x12d6, B:1024:0x12e5, B:1025:0x12f3, B:1029:0x12ff, B:1031:0x1303, B:1047:0x1324, B:1048:0x132d, B:1113:0x1460, B:1049:0x1334, B:1050:0x133d, B:1054:0x134b, B:1055:0x1350, B:1057:0x1356, B:1058:0x1366, B:1059:0x136e, B:1060:0x137b, B:1062:0x1383, B:1064:0x1389, B:1068:0x1392, B:1070:0x1396, B:1071:0x139e, B:1073:0x13a8, B:1074:0x13b6, B:1075:0x13c3, B:1076:0x13d0, B:1078:0x13d6, B:1079:0x13df, B:1081:0x13e4, B:1083:0x13ea, B:1086:0x13f2, B:1088:0x13f8, B:1089:0x13fd, B:1091:0x1401, B:1093:0x1406, B:1094:0x140b, B:1095:0x140e, B:1097:0x1413, B:1098:0x1416, B:1099:0x1419, B:1101:0x141d, B:1105:0x142d, B:1108:0x1437, B:1111:0x144a, B:1112:0x1450, B:1116:0x1468, B:1118:0x146c, B:1120:0x1474, B:1121:0x1489, B:1123:0x148f, B:1125:0x1497, B:1127:0x149e, B:1128:0x14a3, B:1129:0x14bb, B:1130:0x14d7, B:1131:0x14f3, B:1138:0x14fe, B:1140:0x1502), top: B:1147:0x02cb }] */
    /* JADX WARN: Instruction removed from duplicated block: B:671:0x0b05, please report this as an issue */
    @SuppressLint({"DefaultLocale"})
    /* JADX INFO: renamed from: Ub */
    private static void m9160Ub(byte[] bArr, boolean z) throws Throwable {
        byte[] bArr2;
        boolean z2;
        int i;
        int i2;
        byte[] bArr3;
        int i3;
        byte b2;
        int i4;
        int i5;
        int i6;
        int i7;
        int i8;
        EnumC2294y enumC2294y;
        MainActivity mainActivity;
        byte b3;
        int iM9123Ke;
        int i9;
        float f;
        String str;
        String str2;
        boolean z3;
        boolean z4;
        boolean z5;
        boolean z6;
        String str3;
        String str4;
        int i10;
        int iM9148Rb;
        MainActivity mainActivity2;
        String str5;
        MainActivity mainActivity3;
        int i11;
        int i12;
        byte b4;
        int i13 = 0;
        int i14 = z ? 0 : 2;
        int i15 = i14 + 4;
        if (bArr.length < i15) {
            return;
        }
        boolean z7 = true;
        if (z && f8992vd == EnumC2294y.MODE_TPMS_STATUS) {
            if (MainActivity.f7252s9) {
                f8783Cg.m8726C6(false);
                return;
            }
            f8783Cg.m8752Z8("0D");
            if (((bArr[2] == 16 ? 1 : 0) | (bArr[2] == 0 ? 1 : 0)) != 0) {
                boolean zM8891Eb = f8788Dg.m8891Eb(bArr, 2);
                boolean z8 = MainActivity.f7292x6;
                if (zM8891Eb != z8) {
                    boolean z9 = !z8;
                    MainActivity.f7292x6 = z9;
                    LedBar.m8097j(z9 ? 2 : 1);
                    return;
                }
                return;
            }
            return;
        }
        if (z && f8992vd == EnumC2294y.MODE_TPMS) {
            byte b5 = bArr[2];
            if (b5 != -127) {
                if (b5 != -125) {
                    if (b5 == 0) {
                        b4 = 10;
                        if (f8998we <= 0) {
                            if ((MainActivity.f6957La == 1) || ((MainActivity.f6975Na & 13) > 0)) {
                                m9177Yc(f8864Sh, (byte) 0);
                                return;
                            } else if (MainActivity.f6957La == 2) {
                                f8783Cg.m8723B6(false);
                                return;
                            } else if (MainActivity.f6966Ma >= 16) {
                                f8783Cg.m8725Ba();
                            } else if (MainActivity.f6975Na == 2) {
                                f8783Cg.m8729Ea();
                            }
                        }
                        m9177Yc(null, b4);
                        return;
                    }
                    if (b5 != 2) {
                        if (b5 != 3) {
                            if (b5 != 4) {
                                switch (b5) {
                                    case 9:
                                        b4 = -125;
                                        break;
                                    case 10:
                                        if (bArr[8] == 1 && f8998we > 0) {
                                            z7 = (bArr[5] & 128) == 128;
                                            MainActivity.f7050W4 = z7;
                                            MainActivity.f7032U4 = z7;
                                            f8783Cg.m8729Ea();
                                        } else if (MainActivity.f6957La == 1) {
                                            boolean z10 = MainActivity.f7032U4;
                                            boolean z11 = MainActivity.f7050W4;
                                            if (z10 != z11) {
                                                m9226oe(z11);
                                            } else {
                                                MainActivity.f6957La = 2;
                                            }
                                        }
                                        break;
                                    case 11:
                                        if (bArr[3] == 64) {
                                            m9177Yc(f8864Sh, (byte) 0);
                                        }
                                        LedBar.m8097j(2);
                                        break;
                                }
                                return;
                            }
                            int i16 = MainActivity.f6975Na;
                            if (i16 >= 16) {
                                MainActivity.f6966Ma = i16;
                            }
                            if (bArr[3] == 0) {
                                int i17 = MainActivity.f6975Na;
                                if (i17 == 1) {
                                    MainActivity.f6985Ob = m9124Lb(bArr, 4, 4, false, false).toUpperCase();
                                    m9177Yc(f8879Vh, (byte) 0);
                                    f8783Cg.m8803xa();
                                } else if ((i17 & 40) > 0) {
                                    m9177Yc(f8879Vh, (byte) 0);
                                } else if ((i17 & 4) == 4) {
                                    m9214ke(MainActivity.f6985Ob, 0);
                                } else {
                                    m9177Yc(null, (byte) 0);
                                }
                                if (MainActivity.f6975Na != 16) {
                                    return;
                                }
                            } else {
                                if (bArr[3] != 16) {
                                    return;
                                }
                                int i18 = MainActivity.f6975Na;
                                if ((i18 & 4) == 4) {
                                    m9214ke(MainActivity.f6985Ob, 0);
                                } else if ((i18 & 8) == 8) {
                                    m9214ke(MainActivity.f6994Pb, 16);
                                } else {
                                    MainActivity.f6994Pb = m9124Lb(bArr, 4, 4, false, false).toUpperCase();
                                    m9177Yc(null, (byte) 0);
                                }
                                if (MainActivity.f6975Na < 32) {
                                    return;
                                }
                            }
                            MainActivity.f6975Na = 0;
                            return;
                        }
                        if (bArr[3] == 0 && (MainActivity.f6975Na & 8) == 8) {
                            m9214ke(MainActivity.f6994Pb, 16);
                            return;
                        }
                        b4 = -127;
                    } else {
                        if (bArr[3] != 40) {
                            return;
                        }
                        int i19 = MainActivity.f6975Na;
                        if ((i19 == 1) || ((i19 & 20) > 0)) {
                            m9177Yc(f8874Uh, (byte) 0);
                            return;
                        } else {
                            if ((i19 & 40) > 0) {
                                m9177Yc(f8879Vh, (byte) 0);
                                return;
                            }
                            b4 = 10;
                        }
                    }
                    m9177Yc(null, b4);
                    return;
                    m9177Yc(null, (byte) 0);
                    return;
                }
                if (bArr[3] == 0) {
                    m9177Yc(null, (byte) 10);
                    MainActivity.f6957La = 2;
                    return;
                } else if (bArr[3] != 3) {
                    return;
                }
            } else if (bArr[3] == 0) {
                m9177Yc(f8864Sh, (byte) 0);
                MainActivity.f6975Na *= 4;
                return;
            } else if (bArr[3] != 3) {
                return;
            }
            f8783Cg.m8723B6(true);
            return;
        }
        int i20 = i14 + 2;
        if ((bArr[i20] & 240) == 0) {
            if (bArr.length <= 12) {
                i11 = 0;
            } else if (((f8992vd == EnumC2294y.MODE_CLEAR_CODES) || (f8992vd == EnumC2294y.MODE_REQ_ERASE)) || (f8992vd == EnumC2294y.MODE_UPDATE_YMD)) {
                int length = bArr.length;
                while (true) {
                    i12 = length - 1;
                    if (length <= 1 || ((bArr[i12] & 255) == 218 && (bArr[i12 - 1] & 255) == 24)) {
                        break;
                    } else {
                        length = i12;
                    }
                }
                i11 = i12 - 1;
            } else {
                i11 = 0;
            }
            int i21 = bArr[i14 + i11 + 2];
            f8838Ng = i21;
            int i22 = i21 + i14 + 3;
            bArr3 = new byte[i22];
            System.arraycopy(bArr, i11, bArr3, 0, i22);
        } else {
            if (bArr[i20] == 48) {
                m9130Md();
            } else {
                if (bArr[i20] >= 16) {
                    int i23 = ((bArr[i20] & 15) << 8) | (bArr[i14 + 3] & 255);
                    f8838Ng = i23;
                    bArr2 = new byte[i23 + i14 + 3];
                    System.arraycopy(bArr, 0, bArr2, 0, i20);
                    z2 = true;
                }
                i = 0;
                i2 = 0;
                while (z2) {
                    i3 = i14 + i + 2;
                    if ((bArr[i3] & 240) > 0) {
                        b2 = bArr[i3];
                        if (b2 < 32) {
                            b2 = 0;
                        }
                        f8843Og = (b2 & 15) + i2;
                        if (b2 == 47) {
                            i2 += 16;
                        }
                        i4 = 0;
                        i6 = 0;
                        for (i5 = 7; i4 < i5; i5 = 7) {
                            i8 = f8843Og;
                            bArr2[(i8 * 7) + i6 + i14 + 2] = bArr[i14 + i + 3];
                            i6++;
                            i4++;
                            i++;
                            if ((i8 * 7) + i6 > f8838Ng) {
                                z2 = false;
                                break;
                            }
                        }
                        i += i14 + 3;
                        if (i + 5 >= bArr.length) {
                            i7 = f8843Og;
                            if ((i7 * 7) + i6 + i14 + 3 >= bArr2.length && i7 < 15) {
                                return;
                            } else {
                                z2 = false;
                            }
                        }
                    } else {
                        z2 = false;
                    }
                }
                bArr3 = bArr2;
            }
            bArr2 = null;
            z2 = false;
            i = 0;
            i2 = 0;
            while (z2) {
                i3 = i14 + i + 2;
                if ((bArr[i3] & 240) > 0) {
                    b2 = bArr[i3];
                    if (b2 < 32) {
                        b2 = 0;
                    }
                    f8843Og = (b2 & 15) + i2;
                    if (b2 == 47) {
                        i2 += 16;
                    }
                    i4 = 0;
                    i6 = 0;
                    while (i4 < i5) {
                        i8 = f8843Og;
                        bArr2[(i8 * 7) + i6 + i14 + 2] = bArr[i14 + i + 3];
                        i6++;
                        i4++;
                        i++;
                        if ((i8 * 7) + i6 > f8838Ng) {
                            z2 = false;
                            break;
                        }
                    }
                    i += i14 + 3;
                    if (i + 5 >= bArr.length) {
                        i7 = f8843Og;
                        if ((i7 * 7) + i6 + i14 + 3 >= bArr2.length) {
                        }
                        z2 = false;
                    }
                } else {
                    z2 = false;
                }
            }
            bArr3 = bArr2;
        }
        try {
            byte b6 = bArr3[i14 + 3];
            if (b6 != -31) {
                if (b6 == -28) {
                    MainActivity.f7269ua = false;
                    m9135Ne(EnumC2294y.MODE_NULL);
                    f8783Cg.m8734K9(null, null, f8778Bg.m9079Tb(EnumC2281x.REPROG_DONE), 0, 3, 2, 19);
                    return;
                }
                if (b6 == -26) {
                    f8855Rd = (byte) 0;
                    MainActivity.f7278va = true;
                    f8880Wd = new byte[]{(byte) (i >> 16), (byte) (i >> 8), (byte) i};
                    int i24 = f8786De;
                    enumC2294y = EnumC2294y.MODE_UPDATE_YMD;
                } else {
                    if (b6 != 84) {
                        if (b6 == 110) {
                            if (bArr3[i15] == 1) {
                                if (bArr3[i14 + 5] == -127) {
                                    f8998we = 0;
                                    MainActivity.f7276v8 = 8;
                                    MainActivity.f7125e8 = 65536;
                                    f8957mf = true;
                                    f8783Cg.m8756b5(12, 0);
                                    return;
                                }
                                return;
                            }
                            if (bArr3[i15] == -15) {
                                if (bArr3[i14 + 5] != -103) {
                                    m9209jc();
                                    return;
                                } else {
                                    f8855Rd = (byte) 2;
                                    m9253xe(2);
                                    return;
                                }
                            }
                            return;
                        }
                        if (b6 == 113) {
                            boolean z12 = (f8980se >> 8) == 8227;
                            if (bArr3[i15] == 1) {
                                MainActivity.f7268u9 = false;
                                byte b7 = bArr3[i14 + 6];
                                if (b7 != 0) {
                                    if (b7 == 2) {
                                        MainActivity.f7286w9 = true;
                                        f8930ge = f8925fe;
                                        f8783Cg.m8746Sa(1, false);
                                    } else if (b7 == 7) {
                                        MainActivity.f7286w9 = true;
                                        f8930ge = f8925fe;
                                        if (MainActivity.f6884D9) {
                                            f8783Cg.m8756b5(20, f8925fe);
                                            MainActivity.m8199D9(15000);
                                        } else {
                                            MainActivity.f7125e8 = 65536;
                                            f8957mf = true;
                                            f8783Cg.m8732H9();
                                        }
                                    } else if (b7 == 9) {
                                        MainActivity.f7286w9 = true;
                                        f8930ge = f8925fe;
                                        if (z12) {
                                            EnumC2294y enumC2294y2 = f8992vd;
                                            EnumC2294y enumC2294y3 = EnumC2294y.MODE_EXBV_ADJ;
                                            if (enumC2294y2 != enumC2294y3) {
                                                m9135Ne(enumC2294y3);
                                                MainActivity mainActivity4 = f8783Cg;
                                                if (!z12) {
                                                    i13 = 1;
                                                }
                                                mainActivity4.m8731G9(i13);
                                                return;
                                            }
                                            return;
                                        }
                                        MainActivity.f7125e8 = 131072;
                                        f8957mf = true;
                                    } else if (b7 == 11) {
                                        MainActivity.f7286w9 = true;
                                        byte b8 = f8925fe;
                                        f8930ge = b8;
                                        f8783Cg.m8756b5(20, b8);
                                    } else if (b7 == 13) {
                                        MainActivity.f7286w9 = true;
                                        if (MainActivity.f6875C9) {
                                            byte b9 = f8925fe;
                                            f8930ge = b9;
                                            f8783Cg.m8756b5(20, b9);
                                            MainActivity.m8199D9(10000);
                                        } else {
                                            f8930ge = (byte) 0;
                                            f8783Cg.m8746Sa(1, false);
                                        }
                                    } else if (b7 == 25) {
                                        m9212kc(500);
                                        m9198fd(f9005xg ? 1122 : 311);
                                    } else if (b7 == 19 || b7 == 20) {
                                        f8783Cg.m8756b5(3, f8925fe);
                                    } else {
                                        MainActivity.f7286w9 = true;
                                        f8930ge = (byte) 0;
                                        f8783Cg.m8746Sa(1, false);
                                    }
                                    MainActivity.m8211E9(10000);
                                } else {
                                    f8930ge = (byte) 0;
                                    if (MainActivity.f7002Qa == 0) {
                                        MainActivity.f7286w9 = true;
                                        MainActivity.m8199D9(1500);
                                    }
                                }
                            } else if (bArr3[i15] == 2) {
                                f8930ge = (byte) 0;
                                if (MainActivity.f6875C9) {
                                    if (f8925fe == 9) {
                                        if (z12) {
                                            MainActivity.m8199D9(3000);
                                            return;
                                        }
                                        f8925fe = (byte) 13;
                                    }
                                } else if (MainActivity.f6884D9) {
                                    if (f8925fe == 7) {
                                        f8925fe = (byte) 11;
                                    } else {
                                        f8925fe = (byte) 7;
                                    }
                                } else if (MainActivity.f7002Qa == 4) {
                                    f8925fe = (byte) 0;
                                } else {
                                    MainActivity.f7268u9 = false;
                                }
                            } else if (bArr3[i15] == 3) {
                                int i25 = bArr3[i14 + 7] & 255;
                                if (f8925fe == 25) {
                                    if (i25 == 128) {
                                        m9198fd(311);
                                    } else if (i25 == 98) {
                                        MainActivity.f6984Oa = 4;
                                        m9198fd(1125);
                                        f8783Cg.m8757b9(5);
                                    } else if (i25 == 100) {
                                        f8783Cg.m8757b9(6);
                                    }
                                }
                            } else {
                                MainActivity.f7286w9 = true;
                                MainActivity.f7268u9 = false;
                                f8930ge = (byte) 0;
                                f8783Cg.m8746Sa(1, false);
                                MainActivity.m8211E9(8000);
                            }
                            if (f8992vd == EnumC2294y.MODE_CRANK_ADAPT) {
                                return;
                            }
                        } else if (b6 == 116) {
                            f8815Jd = 1;
                            f8841Oe = 256;
                            f8818Jg = 16;
                            enumC2294y = EnumC2294y.MODE_REQ_PROGRAM;
                        } else if (b6 == 67) {
                            f8956me = 0;
                            short s = bArr3[i15];
                            f8803Gg = s;
                            MainActivity mainActivity5 = f8783Cg;
                            if (s <= 0) {
                                z7 = false;
                            }
                            mainActivity5.m8788p8(z7, f8822Kf);
                            if (MainActivity.f6925I5 && f8822Kf) {
                                m9091Ce(f8803Gg);
                                m9194ec(bArr3, 0, f8838Ng);
                                m9206ic();
                            }
                        } else if (b6 == 68) {
                            f8952le = 0;
                            MainActivity.f6857A9 = false;
                            f8783Cg.m8734K9(null, null, null, R.string.error_erased, 1, 2, 5);
                        } else if (b6 == 80) {
                            byte b10 = f8850Qd;
                            if (b10 == 96) {
                                f8835Nd = (byte) 5;
                                f8850Qd = (byte) 3;
                                f8841Oe = 256;
                                m9135Ne(EnumC2294y.MODE_SEED);
                                return;
                            }
                            if ((b10 == 3) && f8857Rf) {
                                f8840Od = (byte) 22;
                                m9135Ne(EnumC2294y.MODE_READ_ECU_INFOS);
                                return;
                            }
                            f8847Pf = false;
                            f8835Nd = (byte) (bArr3[i15] == 3 ? 1 : 3);
                            f8841Oe = 256;
                            if (f8886Xe) {
                                MainActivity.f6930Ia = 1;
                                LedBar.m8097j(2);
                                f8812If = true;
                                f8817Jf = false;
                                f8840Od = (byte) 17;
                                m9170Wd((byte) 17);
                                return;
                            }
                            enumC2294y = EnumC2294y.MODE_SEED;
                        } else if (b6 == 81) {
                            f8850Qd = (byte) 3;
                            MainActivity.f7261ta = true;
                            f8783Cg.m8791qa(true, -1);
                            m9212kc(600);
                            f8783Cg.m8806ya(MainActivity.f7299y4.getText(R.string.wait).toString(), 10000L);
                            enumC2294y = EnumC2294y.MODE_SESSION;
                        } else if (b6 != 89) {
                            if (b6 == 90) {
                                int i26 = f8838Ng;
                                byte[] bArr4 = new byte[i26 + i14 + 3];
                                System.arraycopy(bArr3, 0, bArr4, 0, i26 + i14 + 3);
                                m9248wc(bArr4, i20);
                                f8807Hf = true;
                                f8822Kf = true;
                                return;
                            }
                            String str6 = "";
                            if (b6 != 98) {
                                if (b6 == 99) {
                                    byte[] bArr5 = f8900ae;
                                    if (bArr5 == null) {
                                        System.arraycopy(bArr3, i15, ActivityC2225t.f8442Cd, f8826Le + (MainActivity.f7180k9 ? f8816Je : (f8816Je & 65535) | ActivityC2225t.f8477Ud), f8841Oe);
                                    } else {
                                        System.arraycopy(bArr3, i15, bArr5, f8826Le, f8841Oe);
                                    }
                                    int i27 = f8821Ke;
                                    int i28 = f8841Oe;
                                    f8821Ke = i27 + i28;
                                    f8826Le += i28;
                                    f8836Ne = 0;
                                    f8882Wf = false;
                                    ActivityC2266vc.f8574Fd = 0;
                                    if (f8900ae == null) {
                                        f8826Le = ActivityC2225t.m9050xc(f8816Je, f8826Le);
                                        f8783Cg.m8793r9(f8821Ke, f8831Me, f8825Ld);
                                    }
                                    ActivityC2266vc.f8571Cd = 0;
                                    if (f8821Ke >= f8831Me || f8958mg) {
                                        m9135Ne(EnumC2294y.MODE_NULL);
                                        if (f8958mg) {
                                            f8783Cg.m8734K9(null, null, f8778Bg.m9079Tb(EnumC2281x.ERR_ABORT), 0, 3, 2, 10);
                                            f8783Cg.m8739N5(false);
                                            return;
                                        } else {
                                            String strM9079Tb = f8778Bg.m9079Tb(EnumC2281x.END_READ);
                                            MainActivity.f6969N4 = false;
                                            f8783Cg.m8734K9(null, null, strM9079Tb, 0, 3, 2, 19);
                                            f8783Cg.m8781mb();
                                            return;
                                        }
                                    }
                                    if (!f8812If) {
                                        m9178Yd();
                                        return;
                                    }
                                    enumC2294y = EnumC2294y.MODE_SESSION;
                                } else {
                                    if (b6 == 103) {
                                        byte b11 = bArr3[i15];
                                        f8835Nd = b11;
                                        switch (b11) {
                                            case 1:
                                                if (f8886Xe) {
                                                    m9250we(m9144Qb(((bArr3[i14 + 8] & 255) << 24) | ((bArr3[i14 + 7] & 255) << 16) | ((bArr3[i14 + 6] & 255) << 8) | (bArr3[i14 + 5] & 255)));
                                                } else {
                                                    m9114Id(m9152Sb((bArr3[i14 + 5] << 8) | (bArr3[i14 + 6] & 255)));
                                                }
                                                f8812If = false;
                                                f8817Jf = false;
                                                f8926ff = false;
                                                f8807Hf = false;
                                                f8891Ye = false;
                                                f8822Kf = false;
                                                f8901af = false;
                                                f8896Ze = false;
                                                f8977rf = false;
                                                f8973qf = false;
                                                f8969pf = false;
                                                break;
                                            case 2:
                                                f8812If = true;
                                                f8817Jf = false;
                                                if (f8857Rf) {
                                                    m9135Ne(EnumC2294y.MODE_DIS_CAN);
                                                } else if (f8867Tf) {
                                                    f8850Qd = (byte) 96;
                                                    m9135Ne(EnumC2294y.MODE_SESSION);
                                                } else if (f8886Xe) {
                                                    LedBar.m8097j(2);
                                                    m9135Ne(EnumC2294y.MODE_READ_SENSORS);
                                                } else {
                                                    f8960ne = 0;
                                                    f8840Od = (byte) 16;
                                                    f8772Af = true;
                                                    f8787Df = false;
                                                    f8792Ef = false;
                                                    f8797Ff = false;
                                                    f8802Gf = false;
                                                    f8827Lf = false;
                                                    f8837Nf = false;
                                                    f8981sf = false;
                                                    f8989uf = false;
                                                    f8994vf = false;
                                                    f8985tf = false;
                                                    f8999wf = false;
                                                    f9004xf = false;
                                                    f9009yf = false;
                                                    f9014zf = false;
                                                    f8965of = false;
                                                    f8931gf = false;
                                                    MainActivity.f6930Ia = 1;
                                                    MainActivity.m8169Ab(18, "");
                                                    MainActivity.f6889E5 = true;
                                                    LedBar.m8097j(2);
                                                    if (MainActivity.f7261ta) {
                                                        f8840Od = (byte) 21;
                                                    } else if (MainActivity.f7226pa) {
                                                        f8840Od = (byte) 17;
                                                    }
                                                    MainActivity.f7218ob = "?";
                                                    MainActivity.f7030Tb = null;
                                                    enumC2294y = EnumC2294y.MODE_READ_ECU_INFOS;
                                                }
                                                break;
                                            case 3:
                                                if (f8812If) {
                                                    iM9148Rb = m9148Rb((bArr3[i14 + 5] << 8) | (bArr3[i14 + 6] & 255));
                                                    m9114Id(iM9148Rb);
                                                } else {
                                                    m9114Id(m9152Sb((bArr3[i14 + 5] << 8) | (bArr3[i14 + 6] & 255)));
                                                    f8812If = false;
                                                    f8817Jf = false;
                                                    f8926ff = false;
                                                    f8807Hf = false;
                                                    f8891Ye = false;
                                                    f8822Kf = false;
                                                    f8896Ze = false;
                                                    f8977rf = false;
                                                }
                                                break;
                                            case 4:
                                                LedBar.m8097j(2);
                                                if (!f8812If) {
                                                    f8960ne = 0;
                                                    f8840Od = (byte) 8;
                                                    f8827Lf = false;
                                                    f8837Nf = false;
                                                    f8981sf = false;
                                                    f8989uf = false;
                                                    f8994vf = false;
                                                    f8985tf = false;
                                                    f8999wf = false;
                                                    f9004xf = false;
                                                    f9009yf = false;
                                                    f9014zf = false;
                                                    MainActivity.f6930Ia = 3;
                                                    f8773Ag = "";
                                                    MainActivity.m8169Ab(18, "");
                                                    MainActivity.f6889E5 = true;
                                                    enumC2294y = EnumC2294y.MODE_READ_ECU_INFOS;
                                                } else if (MainActivity.f7068Y4) {
                                                    MainActivity.f7068Y4 = false;
                                                    f8783Cg.m8734K9(null, null, f8778Bg.m9079Tb(EnumC2281x.SECURITY_ACCESS), 0, 3, 2, 0);
                                                    mainActivity = f8783Cg;
                                                    mainActivity.m8805y8(false);
                                                } else if (f8857Rf) {
                                                    if (ActivityC2225t.m9006Ob()) {
                                                        if (f9013ze == ActivityC2225t.m9030dc()) {
                                                            enumC2294y = EnumC2294y.MODE_REQ_ERASE;
                                                        }
                                                    } else if (f8992vd != EnumC2294y.MODE_NULL) {
                                                        enumC2294y = EnumC2294y.MODE_ECU_ALIVE;
                                                    }
                                                }
                                                break;
                                            case 5:
                                                iM9148Rb = f8812If ? m9156Tb((bArr3[i14 + 5] << 8) | (bArr3[i14 + 6] & 255)) : m9152Sb((bArr3[i14 + 5] << 8) | (bArr3[i14 + 6] & 255));
                                                m9114Id(iM9148Rb);
                                                break;
                                            case 6:
                                                LedBar.m8097j(2);
                                                if (f8812If && f8867Tf && ((f8821Ke >> 8) & 1) == 0) {
                                                    MainActivity.f7151h7 = 4;
                                                    mainActivity2 = f8783Cg;
                                                    str5 = "ATSHDB33F1";
                                                    mainActivity2.m8752Z8(str5);
                                                } else {
                                                    enumC2294y = EnumC2294y.MODE_READ_MEM;
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                        return;
                                    }
                                    if (b6 == 104) {
                                        f8840Od = (byte) 17;
                                        MainActivity.f7218ob = "?";
                                        enumC2294y = EnumC2294y.MODE_READ_ECU_INFOS;
                                    } else if (b6 == 118) {
                                        int i29 = MainActivity.f7169j7 + f8841Oe;
                                        MainActivity.f7169j7 = i29;
                                        f8815Jd++;
                                        f8783Cg.m8793r9(i29, MainActivity.f7178k7, f8825Ld);
                                        if (MainActivity.f7169j7 < MainActivity.f7178k7) {
                                            int i30 = (MainActivity.f7196m7 % 45) + 1;
                                            MainActivity.f7196m7 = i30;
                                            if (i30 != 45) {
                                                m9222nd();
                                                return;
                                            }
                                            mainActivity2 = f8783Cg;
                                            str5 = "ATRV";
                                            mainActivity2.m8752Z8(str5);
                                            return;
                                        }
                                        enumC2294y = EnumC2294y.MODE_DOWNLOAD_EXIT;
                                    } else {
                                        if (b6 != 119) {
                                            if (b6 != 126) {
                                                if (b6 != 127) {
                                                    return;
                                                }
                                                if (f8822Kf && (bArr3[bArr3.length - 1] == 33)) {
                                                    m9212kc(5000);
                                                    f8783Cg.m8805y8(false);
                                                    return;
                                                }
                                                byte b12 = bArr3[i15];
                                                if (b12 != -95) {
                                                    if (b12 == -90) {
                                                        ActivityC2266vc.f8571Cd = 0;
                                                        MainActivity.f7235qa = false;
                                                        f8783Cg.m8734K9(null, null, null, R.string.unlock_failed, 2, 2, 0);
                                                        f8783Cg.m8805y8(true);
                                                        return;
                                                    }
                                                    if (b12 == 0) {
                                                        ActivityC2266vc.f8571Cd = 0;
                                                    } else if (b12 == 20) {
                                                        f8952le = 0;
                                                        enumC2294y = EnumC2294y.MODE_READ_SENSORS;
                                                    } else if (b12 == 34) {
                                                        f8960ne = 3;
                                                    } else {
                                                        if (b12 == 39) {
                                                            MainActivity.m8169Ab(19, "");
                                                            if (MainActivity.f7068Y4) {
                                                                MainActivity.f7068Y4 = false;
                                                                mainActivity = f8783Cg;
                                                                mainActivity.m8805y8(false);
                                                                return;
                                                            }
                                                            if (f8857Rf || f8954lg) {
                                                                int i31 = MainActivity.f6876Ca;
                                                                MainActivity.f6876Ca = i31 + 1;
                                                                if (i31 > 1) {
                                                                    f8783Cg.m8734K9(null, null, null, R.string.secure_locked, 20, 3, 23);
                                                                    f8850Qd = (byte) 3;
                                                                    MainActivity.f6876Ca = 0;
                                                                    f8857Rf = false;
                                                                    f8954lg = false;
                                                                    mainActivity3 = f8783Cg;
                                                                } else {
                                                                    f8783Cg.m8734K9(null, null, f8778Bg.m9079Tb(EnumC2281x.ERR_AUTHENTIFY), 0, 36, 1, 0);
                                                                    mainActivity3 = f8783Cg;
                                                                }
                                                            } else if (f8867Tf) {
                                                                f8867Tf = false;
                                                                f8783Cg.m8734K9(null, null, f8778Bg.m9079Tb(EnumC2281x.ERR_AUTHENTIFY), 0, 2, 2, 0);
                                                                mainActivity3 = f8783Cg;
                                                            } else if (f8901af && bArr3[i14 + 5] == 18) {
                                                                f8783Cg.m8734K9(null, null, f8778Bg.m9079Tb(EnumC2281x.UNSUPPORTED_ECU), 0, 2, 2, 0);
                                                                mainActivity3 = f8783Cg;
                                                            } else {
                                                                int i32 = i14 + 5;
                                                                boolean z13 = bArr3[i32] == 19;
                                                                if (bArr3[i32] != 53) {
                                                                    z7 = false;
                                                                }
                                                                if (!z13 && !z7) {
                                                                    f8783Cg.m8734K9(null, null, f8778Bg.m9079Tb(EnumC2281x.ERR_OFFON), 0, 40, 3, 15);
                                                                    return;
                                                                } else {
                                                                    f8783Cg.m8734K9(null, null, f8778Bg.m9079Tb(EnumC2281x.ERR_AUTHENTIFY), 0, 2, 2, 0);
                                                                    mainActivity3 = f8783Cg;
                                                                }
                                                            }
                                                            mainActivity3.m8782n6(false);
                                                            return;
                                                        }
                                                        if (b12 != 46) {
                                                            if (b12 == 49) {
                                                                int i33 = i14 + 5;
                                                                if ((f8992vd == EnumC2294y.MODE_EXBV_ADJ) && ((bArr3[i33] & 255) == 34)) {
                                                                    f8783Cg.m8761cb(-1, 0);
                                                                    return;
                                                                } else if (MainActivity.f7276v8 == 0) {
                                                                    m9139Oe(true);
                                                                    return;
                                                                } else {
                                                                    m9108Hb(true, bArr3[i33] == 34 ? 14 : 0);
                                                                    return;
                                                                }
                                                            }
                                                            if (b12 == 51) {
                                                                MainActivity.m8169Ab(19, "");
                                                                ActivityC2266vc.f8571Cd = 0;
                                                            } else if (b12 != 62) {
                                                                return;
                                                            } else {
                                                                ActivityC2266vc.f8571Cd = 0;
                                                            }
                                                        } else if (f8998we <= 0) {
                                                            MainActivity.f7235qa = false;
                                                            MainActivity.f7244ra = false;
                                                            MainActivity.f7253sa = false;
                                                        }
                                                    }
                                                } else if (ActivityC2225t.f8449Fe) {
                                                    return;
                                                }
                                                ActivityC2266vc.f8571Cd = 0;
                                                return;
                                            }
                                            ActivityC2266vc.f8571Cd = 0;
                                            m9129Mc();
                                            return;
                                        }
                                        f8857Rf = false;
                                        f8954lg = false;
                                        f8783Cg.m8752Z8(MainActivity.f7142g7 == 0 ? "STPTO 80" : "ATST 14");
                                    }
                                }
                            } else if (bArr3[i15] == -15) {
                                byte b13 = bArr3[i14 + 5];
                                if (b13 != -128) {
                                    if (b13 == -116) {
                                        String str7 = String.format("%04x", Integer.valueOf((bArr3[9] & 255) | ((bArr3[8] & 255) << 8)));
                                        int i34 = ((bArr3[10] & 255) << 16) | ((bArr3[11] & 255) << 8) | (bArr3[12] & 255);
                                        f8781Ce = i34;
                                        String[] strArr = f8860Sd;
                                        strArr[64] = String.format("%06x", Integer.valueOf(i34));
                                        MainActivity.f7012Rb = strArr[64] + ":" + String.format("%08x", Integer.valueOf(f9003xe)) + ";";
                                        StringBuilder sb = new StringBuilder();
                                        sb.append(str7);
                                        sb.append(strArr[64]);
                                        MainActivity.f7030Tb = sb.toString();
                                        if (f9003xe > 0) {
                                            while (true) {
                                                int iIndexOf = MainActivity.f7003Qb.indexOf(f8860Sd[64] + ":");
                                                if (iIndexOf < 0) {
                                                    break;
                                                }
                                                int i35 = iIndexOf + 16;
                                                if (MainActivity.f7003Qb.length() >= i35) {
                                                    MainActivity.f7003Qb = MainActivity.f7003Qb.replace(MainActivity.f7003Qb.substring(iIndexOf, i35), "");
                                                    i13 = 1;
                                                }
                                            }
                                        }
                                        if (i13 != 0) {
                                            f8783Cg.m8772gb();
                                        }
                                        byte b14 = (byte) (f8840Od + 1);
                                        f8840Od = b14;
                                        m9170Wd(b14);
                                        f8783Cg.m8794t5();
                                        MainActivity.m8169Ab(MainActivity.f7127ea ? 28 : 29, MainActivity.f7030Tb);
                                        return;
                                    }
                                    if (b13 == -112) {
                                        if (MainActivity.f7261ta) {
                                            f8954lg = false;
                                            MainActivity.f7261ta = false;
                                            MainActivity.f7278va = true;
                                            MainActivity.f7253sa = true;
                                            f8880Wd = ActivityC2225t.m9019Uc(3, 0);
                                            f8855Rd = (byte) 0;
                                            m9135Ne(EnumC2294y.MODE_UPDATE_YMD);
                                            f8783Cg.m8791qa(true, 5);
                                            return;
                                        }
                                        f8860Sd[63] = m9124Lb(bArr3, 8, 17, true, false);
                                        MainActivity.m8169Ab(0, m9124Lb(bArr3, 19, 6, true, false));
                                        b3 = (byte) (f8840Od + 1);
                                        f8840Od = b3;
                                    } else if (b13 == -103) {
                                        byte b15 = bArr3[i14 + 6];
                                        byte b16 = bArr3[i14 + 7];
                                        int i36 = bArr3[i14 + 8] & 255;
                                        int i37 = (b15 << 16) | (b16 << 8) | i36;
                                        f8786De = i37;
                                        String[] strArr2 = f8860Sd;
                                        strArr2[68] = null;
                                        if (i37 == -1 && MainActivity.f7116d8 == 0 && (MainActivity.f7301y6 || MainActivity.f7310z6)) {
                                            MainActivity.f7244ra = true;
                                            f8880Wd = ActivityC2225t.m9019Uc(3, 0);
                                            f8855Rd = (byte) 0;
                                            m9135Ne(EnumC2294y.MODE_UPDATE_YMD);
                                            f8783Cg.m8792r6(MainActivity.f7299y4.getText(R.string.update_progress).toString(), 0, Boolean.FALSE);
                                            return;
                                        }
                                        if (f8786De != -1) {
                                            strArr2[68] = String.format("%02x", Integer.valueOf(b15)) + "/" + String.format("%02x", Integer.valueOf(b16)) + "/" + String.format("%02x", Integer.valueOf(i36));
                                        }
                                        b3 = (byte) (f8840Od + 1);
                                        f8840Od = b3;
                                    } else if (b13 == -101) {
                                        if (f8857Rf) {
                                            f8850Qd = (byte) 2;
                                            m9135Ne(EnumC2294y.MODE_SESSION);
                                            return;
                                        }
                                        if (MainActivity.f7226pa) {
                                            MainActivity.f7226pa = false;
                                            MainActivity.f7235qa = true;
                                            m9162Ud();
                                            return;
                                        }
                                        int i38 = (bArr3[i14 + 6] << 16) | (bArr3[i14 + 7] << 8) | (bArr3[i14 + 8] & 255);
                                        f8791Ee = i38;
                                        if (i38 != f8786De && MainActivity.f7278va && MainActivity.f7116d8 == 0 && MainActivity.f6876Ca == 0 && (MainActivity.f7301y6 || MainActivity.f7310z6)) {
                                            f8855Rd = (byte) 2;
                                            MainActivity.f7278va = false;
                                            MainActivity.f7244ra = true;
                                            f8880Wd = new byte[]{(byte) (i >> 16), (byte) (i >> 8), (byte) i};
                                            int i39 = f8786De;
                                            m9135Ne(EnumC2294y.MODE_UPDATE_YMD);
                                            f8783Cg.m8792r6(MainActivity.f7299y4.getText(R.string.update_progress).toString(), 0, Boolean.FALSE);
                                            return;
                                        }
                                        byte b17 = (byte) (f8840Od + 1);
                                        f8840Od = b17;
                                        if (f8954lg) {
                                            f8840Od = (byte) (b17 + 2);
                                        }
                                        b3 = f8840Od;
                                    } else if (b13 == -96) {
                                        int i40 = ((bArr3[i14 + 6] & 255) << 16) | (bArr3[i14 + 7] << 8) | (bArr3[i14 + 8] & 255);
                                        MainActivity.f7236qb = "---";
                                        MainActivity.f6968Mc = 0;
                                        if (i40 == 0) {
                                            iM9123Ke = (m9123Ke(f8915de, 0) << 16) | (m9123Ke(f8915de, 2) << 8) | (m9123Ke(f8915de, 4) & 255);
                                            ActivityC2225t.m9047uc(String.format("%x", Integer.valueOf(iM9123Ke)));
                                        } else {
                                            iM9123Ke = i40;
                                        }
                                        f9003xe = iM9123Ke;
                                        String str8 = String.format("%x", Integer.valueOf(iM9123Ke));
                                        if (str8.equals("0")) {
                                            str8 = "???";
                                        }
                                        f8860Sd[65] = str8;
                                        byte[] bArr6 = f8905be;
                                        bArr6[20] = (byte) (iM9123Ke >> 8);
                                        bArr6[21] = (byte) (iM9123Ke & 255);
                                        MainActivity.m8169Ab(20, str8);
                                        if (i40 == 0) {
                                            f8840Od = (byte) 24;
                                        } else {
                                            f9008ye = 0;
                                            f8840Od = (byte) (f8840Od + 1);
                                        }
                                        b3 = f8840Od;
                                    } else {
                                        if (b13 == -94) {
                                            f9008ye = bArr3[i14 + 8];
                                            f8840Od = (byte) 17;
                                            m9170Wd((byte) 17);
                                            return;
                                        }
                                        if (b13 == -89) {
                                            int i41 = (bArr3[i14 + 6] << 16) | (bArr3[i14 + 7] << 8) | (bArr3[i14 + 8] & 255);
                                            f8980se = i41;
                                            f8886Xe = false;
                                            if (f8857Rf) {
                                                if (ActivityC2225t.m9000Lb(i41, 0, C2184q0.f8267a) >= 4) {
                                                    m9135Ne(EnumC2294y.MODE_NULL);
                                                    f8783Cg.m8734K9(null, null, f8778Bg.m9079Tb(EnumC2281x.ERR_VERSION_MAP), 0, 2, 1, 8);
                                                    return;
                                                } else {
                                                    byte b18 = (byte) (f8840Od + 1);
                                                    f8840Od = b18;
                                                    m9170Wd(b18);
                                                    return;
                                                }
                                            }
                                            if (MainActivity.f7269ua) {
                                                m9213kd();
                                                return;
                                            }
                                            boolean z14 = f8980se >= 2106115;
                                            f8886Xe = z14;
                                            if (z14) {
                                                MainActivity.f7236qb = "---";
                                                int iM9123Ke2 = (m9123Ke(f8915de, 0) << 16) | (m9123Ke(f8915de, 2) << 8) | (m9123Ke(f8915de, 4) & 255);
                                                ActivityC2225t.m9047uc(String.format("%x", Integer.valueOf(iM9123Ke2)));
                                                f9003xe = iM9123Ke2;
                                                String str9 = String.format("%x", Integer.valueOf(iM9123Ke2));
                                                if (str9.equals("0")) {
                                                    str9 = "???";
                                                }
                                                f8860Sd[65] = str9;
                                                byte[] bArr7 = f8905be;
                                                bArr7[20] = (byte) (iM9123Ke2 >> 8);
                                                bArr7[21] = (byte) (iM9123Ke2 & 255);
                                                MainActivity.m8169Ab(20, str9);
                                            }
                                            int i42 = f8980se >> 8;
                                            f9010yg = (i42 & 8210) != 8210;
                                            String[] strArr3 = f8860Sd;
                                            if (strArr3[63] != null && strArr3[63].length() > 4) {
                                                if (!MainActivity.f7091aa) {
                                                    MainActivity.f7091aa = (i42 == 8208) | (i42 == 8209);
                                                }
                                                MainActivity.f7218ob = ":" + String.format("%2x", Integer.valueOf(i42 & 255)) + strArr3[63].substring(3, 4);
                                            }
                                            String str10 = MainActivity.f7218ob;
                                            MainActivity.m8169Ab(30, str10.substring(1, str10.length()));
                                            boolean z15 = strArr3[65] != null && strArr3[65].length() > 4 && f8980se == 2102016 && strArr3[65].startsWith("9000");
                                            String str11 = Integer.toHexString(f8980se >> 8) + "-" + Integer.toHexString(f8980se & 255);
                                            String strConcat = "Cdn";
                                            int i43 = f8980se;
                                            long[] jArr = C2184q0.f8267a;
                                            MainActivity.f7251s8 = ActivityC2225t.m9000Lb(i43, 2, jArr) & 127;
                                            if (z15) {
                                                MainActivity.f7259t8 = 7;
                                                MainActivity.f7267u8 = 0;
                                                MainActivity.f7251s8 = 0;
                                            }
                                            strArr3[62] = str11;
                                            MainActivity.m8169Ab(21, str11);
                                            MainActivity.f6900F7 = 0;
                                            float fM9145Qc = m9145Qc(f9003xe & 65535, f8980se, jArr);
                                            MainActivity.f6973N8 = fM9145Qc;
                                            if (fM9145Qc > 0.0f) {
                                                MainActivity.f6910G8 = Math.min((((int) (fM9145Qc + 25.0f)) / 20) * 20, 160);
                                            } else {
                                                if ((((i42 == 8212) || (i42 == 8214)) || (i42 == 8225)) || (i42 == 8226)) {
                                                    i9 = 80;
                                                } else if ((65534 & i42) == 8210 || i42 == 8224) {
                                                    i9 = 140;
                                                } else {
                                                    i9 = z15 ? 160 : 120;
                                                }
                                                MainActivity.f6910G8 = i9;
                                                if ((((i42 == 8212) || (i42 == 8214)) || (i42 == 8225)) || (i42 == 8226)) {
                                                    f = 70.0f;
                                                } else if ((65534 & i42) == 8210) {
                                                    f = 140.0f;
                                                } else if (i42 == 8224) {
                                                    f = 120.0f;
                                                } else if (i42 == 8210) {
                                                    f = 128.0f;
                                                } else {
                                                    f = z15 ? 155.0f : 100.0f;
                                                }
                                                MainActivity.f6973N8 = f;
                                            }
                                            MainActivity.f6958Lb = "t";
                                            f8846Pe = i42 == 8210 ? 2 : 0;
                                            f8921ef = false;
                                            f8961nf = false;
                                            f8965of = false;
                                            f8953lf = false;
                                            f8945jf = false;
                                            f8949kf = (i42 == 8212) | (i42 == 8214) | (i42 == 8225);
                                            if ((i42 == 8210) || (i42 == 8211)) {
                                                strConcat = "Zqn";
                                            } else if (i42 == 8215) {
                                                strConcat = "Cqdn";
                                            } else if ((i42 & 8225) == 8224) {
                                                strConcat = "CKqs";
                                            } else {
                                                if (i42 == 8227) {
                                                    strConcat = f8980se == 2106115 ? "Cs" : "CKs";
                                                    str = (MainActivity.f7236qb.equals(":10B") || MainActivity.f7236qb.equals(":10C")) ? "e" : "";
                                                }
                                                if (f8980se > 201700) {
                                                    strConcat = strConcat.concat("y");
                                                }
                                                str2 = f8949kf ? "DH" : "S9GQV";
                                                if (i42 == 8210) {
                                                    z3 = true;
                                                } else {
                                                    z3 = false;
                                                }
                                                if (i42 == 8211) {
                                                    z4 = true;
                                                } else {
                                                    z4 = false;
                                                }
                                                z5 = z3 | z4;
                                                if (i42 == 8212) {
                                                    z6 = true;
                                                } else {
                                                    z6 = false;
                                                }
                                                if (z5 || z6) {
                                                    str3 = "";
                                                } else {
                                                    str3 = i42 == 8209 ? "O" : "";
                                                    str6 = "c";
                                                }
                                                if (z15) {
                                                    str4 = "Aagb5789PQUVuXvf";
                                                } else {
                                                    str4 = "AtFagb5678lPUuXvfL" + str + strConcat + str2 + str6 + str3;
                                                }
                                                MainActivity.f7223p7 = str4;
                                                f8788Dg.f7799vd = MainActivity.f7223p7;
                                                MainActivity.f7242r8 = 262144;
                                                m9099Ee("0");
                                                MainActivity.f7051W5 = false;
                                                MainActivity mainActivity6 = f8783Cg;
                                                if (MainActivity.f6970N5) {
                                                    i10 = 1000;
                                                } else {
                                                    i10 = 0;
                                                }
                                                mainActivity6.m8778kb(i10);
                                                f8783Cg.m8780m9();
                                                m9111He(MainActivity.f7116d8);
                                                ActivityC2266vc.f8578Jd = 0;
                                                MainActivity.f6925I5 = false;
                                                f8956me = 1;
                                                if (f8886Xe) {
                                                    enumC2294y = EnumC2294y.MODE_SEED;
                                                } else {
                                                    enumC2294y = EnumC2294y.MODE_READ_SENSORS;
                                                }
                                            }
                                            if (f8980se > 201700) {
                                                strConcat = strConcat.concat("y");
                                            }
                                            if (f8949kf) {
                                            }
                                            if (i42 == 8210) {
                                                z3 = true;
                                            } else {
                                                z3 = false;
                                            }
                                            if (i42 == 8211) {
                                                z4 = true;
                                            } else {
                                                z4 = false;
                                            }
                                            z5 = z3 | z4;
                                            if (i42 == 8212) {
                                                z6 = true;
                                            } else {
                                                z6 = false;
                                            }
                                            if (z5 || z6) {
                                                str3 = "";
                                            } else {
                                                str3 = i42 == 8209 ? "O" : "";
                                                str6 = "c";
                                            }
                                            if (z15) {
                                                str4 = "Aagb5789PQUVuXvf";
                                            } else {
                                                str4 = "AtFagb5678lPUuXvfL" + str + strConcat + str2 + str6 + str3;
                                            }
                                            MainActivity.f7223p7 = str4;
                                            f8788Dg.f7799vd = MainActivity.f7223p7;
                                            MainActivity.f7242r8 = 262144;
                                            m9099Ee("0");
                                            MainActivity.f7051W5 = false;
                                            MainActivity mainActivity7 = f8783Cg;
                                            if (MainActivity.f6970N5) {
                                                i10 = 1000;
                                            } else {
                                                i10 = 0;
                                            }
                                            mainActivity7.m8778kb(i10);
                                            f8783Cg.m8780m9();
                                            m9111He(MainActivity.f7116d8);
                                            ActivityC2266vc.f8578Jd = 0;
                                            MainActivity.f6925I5 = false;
                                            f8956me = 1;
                                            if (f8886Xe) {
                                                enumC2294y = EnumC2294y.MODE_SEED;
                                            } else {
                                                enumC2294y = EnumC2294y.MODE_READ_SENSORS;
                                            }
                                        } else {
                                            if (b13 != -82) {
                                                return;
                                            }
                                            if (bArr3[i20] > 4) {
                                                f8860Sd[66] = String.format("%d", Integer.valueOf((bArr3[i14 + 6] << 8) | (bArr3[i14 + 7] & 255)));
                                            }
                                            b3 = (byte) (f8840Od + 1);
                                            f8840Od = b3;
                                        }
                                    }
                                    m9170Wd(b3);
                                    return;
                                }
                                f9013ze = (bArr3[i14 + 9] << 16) | ((bArr3[i14 + 10] & 15) << 12) | ((bArr3[i14 + 11] & 15) << 8) | ((bArr3[i14 + 12] & 15) << 4) | (bArr3[i14 + 13] & 15);
                                f8835Nd = (byte) 1;
                                enumC2294y = EnumC2294y.MODE_SEED;
                            } else {
                                if (f8992vd == EnumC2294y.MODE_EXBV_ADJ && bArr3[i15] == 17) {
                                    int i44 = (bArr3[i14 + 5] & 255) | 4352;
                                    switch (i44) {
                                        case 4496:
                                            break;
                                        case 4497:
                                            m9219md(i44 + 2);
                                            return;
                                        case 4498:
                                        default:
                                            return;
                                        case 4499:
                                        case 4500:
                                        case 4501:
                                            int i45 = (i44 & 7) - 3;
                                            f8783Cg.m8761cb(i45, bArr3[i14 + 7] & 255);
                                            if (i45 >= 2) {
                                                return;
                                            }
                                            break;
                                    }
                                    m9219md(i44 + 1);
                                    return;
                                }
                                if (f8992vd == EnumC2294y.MODE_CRANK_ADAPT) {
                                    int i46 = (bArr3[i15] << 8) | (bArr3[i14 + 5] & 255);
                                    if (i46 == 265) {
                                        f8783Cg.m8758c5(bArr3[i14 + 7] & 255, 8);
                                        m9198fd(512);
                                    } else if (i46 == 289) {
                                        MainActivity.f7260t9 = false;
                                        f9005xg = false;
                                        f8830Md = 0L;
                                        if (f8783Cg.m8763d6(1, bArr3[i14 + 7] & 255)) {
                                            m9134Nd();
                                        }
                                    } else if (i46 == 311) {
                                        boolean zM8439Za = MainActivity.m8439Za(bArr3[i14 + 7] & 255);
                                        f9005xg = zM8439Za;
                                        if (zM8439Za || !MainActivity.f7313z9 || System.currentTimeMillis() <= MainActivity.f6903Fa) {
                                            m9198fd(1122);
                                        } else {
                                            m9203hc(7);
                                        }
                                        if (f9005xg) {
                                            MainActivity.m8199D9(10000);
                                        }
                                    } else if (i46 == 512) {
                                        int i47 = (bArr3[i14 + 6] << 8) | (bArr3[i14 + 7] & 255);
                                        boolean z16 = i47 > 2500;
                                        int i48 = MainActivity.f6984Oa;
                                        if (z16 && (i48 == 1)) {
                                            f8783Cg.m8757b9(3);
                                        } else if ((i47 == 0) & (i48 > 1)) {
                                            MainActivity.f6984Oa = 0;
                                        }
                                        if (!MainActivity.f7313z9 || System.currentTimeMillis() <= MainActivity.f6903Fa) {
                                            if (f8830Md == 0) {
                                                f8830Md = System.currentTimeMillis();
                                            }
                                            m9198fd(1121);
                                        } else {
                                            m9203hc(7);
                                        }
                                    } else if (i46 != 768) {
                                        if (i46 != 1125) {
                                            if (i46 == 1121) {
                                                if (((bArr3[i14 + 7] & 255) == 0) || (System.currentTimeMillis() - f8830Md < 3000)) {
                                                    m9198fd(265);
                                                } else {
                                                    MainActivity.f6984Oa = 4;
                                                    f8783Cg.m8757b9(4);
                                                    MainActivity.m8199D9(60000);
                                                    f8925fe = (byte) 25;
                                                    m9235re();
                                                }
                                            } else if (i46 == 1122) {
                                                f8930ge = f8925fe;
                                                if (f9005xg && MainActivity.f7313z9 && System.currentTimeMillis() > MainActivity.f6903Fa) {
                                                    m9203hc(8);
                                                } else {
                                                    m9235re();
                                                }
                                            }
                                        } else if (bArr3[i14 + 7] == 0) {
                                            m9198fd(1125);
                                        } else {
                                            m9203hc(6);
                                        }
                                    } else if (f8783Cg.m8763d6(2, (bArr3[i14 + 7] & 255) ^ 255)) {
                                        f8783Cg.m8757b9(MainActivity.f7143g8 > 0 ? 3 : 2);
                                        m9198fd(265);
                                        MainActivity.m8199D9(60000);
                                    }
                                    if (((MainActivity.f6984Oa == 0 ? 1 : 0) & (f8992vd != EnumC2294y.MODE_NULL ? 1 : 0)) != 0) {
                                        m9203hc(7);
                                        return;
                                    }
                                    return;
                                }
                                if (bArr.length == 24 && bArr[17] == 84) {
                                    f8783Cg.m8734K9(null, null, null, R.string.error_erased, 1, 2, 5);
                                    f8992vd = EnumC2294y.MODE_READ_SENSORS;
                                    MainActivity.f6857A9 = false;
                                }
                                short[] sArr = f8873Ug;
                                if ((sArr != null) & (sArr == f8868Tg)) {
                                    int i49 = 0;
                                    while (true) {
                                        short[] sArr2 = f8873Ug;
                                        if (i49 >= sArr2.length / 2) {
                                            break;
                                        }
                                        int i50 = i49 * 2;
                                        boolean z17 = sArr2[i50] == f8798Fg;
                                        int i51 = i50 + 1;
                                        if (z17 & (sArr2[i51] < 4) & (sArr2[i51] != 0)) {
                                            sArr2[i51] = 3;
                                        }
                                        i49++;
                                    }
                                }
                                if (f8957mf) {
                                    m9111He(MainActivity.f7116d8);
                                } else {
                                    if (f8956me > 0) {
                                        if (f8812If) {
                                            m9207id();
                                        } else {
                                            m9169Wc();
                                        }
                                        if (f8992vd == EnumC2294y.MODE_READ_SENSORS) {
                                            f8788Dg.m8890Cb(bArr3, i15);
                                            return;
                                        }
                                        return;
                                    }
                                    if (f8952le > 0) {
                                        if (!f8812If) {
                                            m9186bd();
                                            return;
                                        } else {
                                            m9135Ne(EnumC2294y.MODE_CLEAR_CODES);
                                            f8783Cg.m8728D6();
                                            return;
                                        }
                                    }
                                    if (!MainActivity.f7260t9) {
                                        if (MainActivity.f7268u9) {
                                            m9235re();
                                            return;
                                        }
                                        int i52 = f8998we;
                                        if (i52 > 0) {
                                            f8783Cg.m8738Ma(i52 & 127);
                                            return;
                                        }
                                        if (f8970pg || f8974qg) {
                                            mainActivity = f8783Cg;
                                        } else {
                                            if (f8887Xf) {
                                                f8835Nd = (byte) 5;
                                                m9103Fe(null, 0, MainActivity.f7178k7);
                                                return;
                                            }
                                            if (f8892Yf) {
                                                f8892Yf = false;
                                                f8857Rf = true;
                                                mainActivity = f8783Cg;
                                            } else if (MainActivity.f7252s9) {
                                                MainActivity.f6939Ja = MainActivity.f6970N5 ? 16 : 1;
                                                mainActivity = f8783Cg;
                                            } else {
                                                if (MainActivity.f7068Y4) {
                                                    LedBar.m8097j(0);
                                                    return;
                                                }
                                                if (!MainActivity.f7226pa) {
                                                    if (f8992vd != EnumC2294y.MODE_EXBV_ADJ) {
                                                        m9217le();
                                                        f8788Dg.m8890Cb(bArr3, i15);
                                                    }
                                                    if (MainActivity.f7304y9) {
                                                        MainActivity.m8546jb(false);
                                                    }
                                                    if (MainActivity.f6857A9 && System.currentTimeMillis() > MainActivity.f6921Ha) {
                                                        MainActivity.f6857A9 = false;
                                                        f8783Cg.m8741O5(7);
                                                    }
                                                    if (!MainActivity.f6866B9 || System.currentTimeMillis() <= MainActivity.f6903Fa) {
                                                        if (!MainActivity.f7313z9 || System.currentTimeMillis() <= MainActivity.f6903Fa) {
                                                            return;
                                                        }
                                                        f8783Cg.m8756b5(20, f8925fe);
                                                        return;
                                                    }
                                                    f8783Cg.m8746Sa(4, false);
                                                    if (f8930ge == 2) {
                                                        MainActivity.f7268u9 = true;
                                                        return;
                                                    }
                                                    return;
                                                }
                                                mainActivity = f8783Cg;
                                            }
                                        }
                                        mainActivity.m8805y8(false);
                                        return;
                                    }
                                    enumC2294y = EnumC2294y.MODE_CRANK_ADAPT;
                                }
                            }
                        } else if (bArr3[i15] == 1) {
                            f8956me = 0;
                            short s2 = (short) (bArr3[i14 + 8] & 255);
                            f8803Gg = s2;
                            MainActivity mainActivity8 = f8783Cg;
                            if (s2 <= 0) {
                                z7 = false;
                            }
                            mainActivity8.m8788p8(z7, false);
                            m9091Ce(f8803Gg);
                            if (f8803Gg <= 0 || !MainActivity.f6925I5) {
                                if (MainActivity.f6925I5) {
                                    m9206ic();
                                }
                                if (MainActivity.f7116d8 == 3) {
                                    f8783Cg.m8737M6(97, f8803Gg);
                                }
                            } else {
                                m9091Ce(f8803Gg);
                                enumC2294y = EnumC2294y.MODE_READ_CODES;
                            }
                        } else {
                            if (MainActivity.f6925I5) {
                                m9194ec(bArr3, 0, f8838Ng);
                                m9206ic();
                            }
                            enumC2294y = EnumC2294y.MODE_READ_SENSORS;
                        }
                        m9217le();
                        return;
                    }
                    f8952le = 0;
                    MainActivity.f6857A9 = false;
                    ActivityC2266vc.f8571Cd = 0;
                    f8783Cg.m8734K9(null, null, null, R.string.error_erased, 1, 2, 5);
                    enumC2294y = EnumC2294y.MODE_READ_SENSORS;
                }
                m9135Ne(enumC2294y);
                return;
            }
            byte b19 = bArr3[i15];
            if (((b19 == 1 ? 1 : 0) | (b19 == 2 ? 1 : 0)) == 0) {
                return;
            } else {
                f8783Cg.m8752Z8("STPTO 40");
            }
            MainActivity.f7015S5 = true;
        } catch (Exception e) {
            if (f8785Dd) {
                Log.e("ISORead", Log.getStackTraceString(e));
            }
        }
    }

    /* JADX INFO: renamed from: Uc */
    private static void m9161Uc() {
        m9098Ed(new byte[]{19, 64, -1}, 6, false);
    }

    /* JADX INFO: renamed from: Ud */
    private static void m9162Ud() {
        m9098Ed(new byte[]{-90, 84, 82, 75, 78}, -1, false);
    }

    /* JADX INFO: renamed from: Ue */
    public static void m9163Ue() {
        if (f8816Je == f8940ie) {
            f8771Ae[14] = 0;
            f8816Je = 131070;
        }
    }

    /* JADX WARN: Code duplicated, block: B:266:0x00ca A[SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:33:0x0088  */
    /* JADX WARN: Code duplicated, block: B:35:0x008d  */
    /* JADX WARN: Code duplicated, block: B:37:0x0097  */
    /* JADX WARN: Code duplicated, block: B:40:0x00a2  */
    /* JADX WARN: Code duplicated, block: B:43:0x00aa  */
    /* JADX WARN: Code duplicated, block: B:46:0x00cc A[LOOP:5: B:42:0x00a8->B:46:0x00cc, LOOP_END] */
    /* JADX WARN: Code duplicated, block: B:49:0x00d6  */
    /* JADX WARN: Code duplicated, block: B:54:0x00e6  */
    /* JADX INFO: renamed from: Vb */
    private static void m9164Vb(byte[] bArr) {
        int i;
        byte[] bArr2;
        int i2;
        boolean z;
        int i3;
        byte[] bArr3;
        int i4;
        int i5;
        byte b2;
        int i6;
        int i7;
        int i8;
        int i9;
        EnumC2294y enumC2294y;
        byte b3;
        if (bArr.length < 3) {
            return;
        }
        int i10 = 7;
        int i11 = 0;
        if (bArr.length > 10 && bArr[2] == 3 && bArr[3] == 127 && bArr[5] == 120) {
            i = 6;
            while (true) {
                int i12 = 0 + i;
                if (bArr[i12] == 7 && (bArr[i12 + 1] & 255) == 232) {
                    break;
                } else {
                    i++;
                }
            }
        } else {
            i = 0;
        }
        int i13 = i + 2;
        if ((bArr[i13] & 240) == 0) {
            int i14 = bArr[i + 0 + 2];
            f8838Ng = i14;
            int i15 = i14 + 3;
            bArr3 = new byte[i15];
            System.arraycopy(bArr, i, bArr3, 0, i15);
            i3 = 0;
        } else {
            if (bArr[i13] == 48) {
                m9130Md();
            } else {
                if (bArr[i13] >= 16) {
                    int i16 = ((bArr[i13] & 15) << 8) | (bArr[i + 3] & 255);
                    f8838Ng = i16;
                    bArr2 = new byte[i16 + 4];
                    System.arraycopy(bArr, i, bArr2, 0, 10);
                    i2 = 1;
                    z = true;
                }
                if ((bArr[i + 0 + 2] & 240) > 0) {
                    i4 = 0;
                    i5 = 0;
                    while (z) {
                        b2 = bArr[i + i4 + 2];
                        if (b2 < 32) {
                            b2 = 0;
                        }
                        f8843Og = (b2 & 15) + i5;
                        if (b2 == 47) {
                            i5 += 16;
                        }
                        i4 += 3;
                        i6 = 0;
                        i7 = 0;
                        while (i6 < i10) {
                            i9 = f8843Og;
                            bArr2[(i9 * 7) + i7 + 3] = bArr[i + i4];
                            i7++;
                            i6++;
                            i4++;
                            if ((i9 * 7) + i7 + 3 > f8838Ng + 3) {
                                z = false;
                                break;
                            }
                            i10 = 7;
                        }
                        if (i4 + i + 5 >= bArr.length) {
                            i8 = f8843Og;
                            if ((i8 * 7) + i7 + 3 >= bArr2.length && i8 < 15) {
                                return;
                            }
                            i10 = 7;
                            z = false;
                        } else {
                            i10 = 7;
                        }
                    }
                }
                i3 = i2;
                bArr3 = bArr2;
            }
            bArr2 = null;
            i2 = 0;
            z = false;
            if ((bArr[i + 0 + 2] & 240) > 0) {
                i4 = 0;
                i5 = 0;
                while (z) {
                    b2 = bArr[i + i4 + 2];
                    if (b2 < 32) {
                        b2 = 0;
                    }
                    f8843Og = (b2 & 15) + i5;
                    if (b2 == 47) {
                        i5 += 16;
                    }
                    i4 += 3;
                    i6 = 0;
                    i7 = 0;
                    while (i6 < i10) {
                        i9 = f8843Og;
                        bArr2[(i9 * 7) + i7 + 3] = bArr[i + i4];
                        i7++;
                        i6++;
                        i4++;
                        if ((i9 * 7) + i7 + 3 > f8838Ng + 3) {
                            z = false;
                            break;
                        }
                        i10 = 7;
                    }
                    if (i4 + i + 5 >= bArr.length) {
                        i8 = f8843Og;
                        if ((i8 * 7) + i7 + 3 >= bArr2.length) {
                        }
                        i10 = 7;
                        z = false;
                    } else {
                        i10 = 7;
                    }
                }
            }
            i3 = i2;
            bArr3 = bArr2;
        }
        try {
            byte b4 = bArr3[i3 + 3];
            if (b4 == 80) {
                MainActivity.f6930Ia = 10;
                f8817Jf = true;
                f8835Nd = (byte) 3;
                f8850Qd = (byte) 3;
                enumC2294y = bArr3[i3 + 4] == 1 ? EnumC2294y.MODE_SESSION : EnumC2294y.MODE_SEED;
            } else if (b4 == 84) {
                f8952le = 0;
                ActivityC2266vc.f8571Cd = 0;
                f8783Cg.m8734K9(null, null, null, R.string.error_erased, 1, 2, 5);
                enumC2294y = EnumC2294y.MODE_READ_SENSORS;
            } else if (b4 != 89) {
                if (b4 == 98) {
                    EnumC2294y enumC2294y2 = f8992vd;
                    EnumC2294y enumC2294y3 = EnumC2294y.MODE_READ_SENSORS;
                    if (enumC2294y2 == enumC2294y3) {
                        short[] sArr = f8873Ug;
                        if ((sArr != null) & (sArr == f8868Tg)) {
                            int i17 = 0;
                            while (true) {
                                short[] sArr2 = f8873Ug;
                                if (i17 >= sArr2.length / 2) {
                                    break;
                                }
                                int i18 = i17 * 2;
                                boolean z2 = sArr2[i18] == f8798Fg;
                                int i19 = i18 + 1;
                                if (z2 & (sArr2[i19] < 4)) {
                                    sArr2[i19] = 3;
                                }
                                i17++;
                            }
                        }
                        if (f8957mf) {
                            m9111He(MainActivity.f7116d8);
                            m9217le();
                        } else if (f8956me > 0) {
                            m9207id();
                        } else if (f8952le > 0) {
                            m9135Ne(EnumC2294y.MODE_CLEAR_CODES);
                        } else if (MainActivity.f7268u9 || MainActivity.f7277v9) {
                            m9235re();
                        } else {
                            int i20 = f8998we;
                            if (i20 > 0) {
                                f8783Cg.m8738Ma(i20 & 127);
                            } else if (f8970pg) {
                                f8783Cg.m8805y8(false);
                            } else {
                                m9217le();
                                f8788Dg.m8890Cb(bArr3, i3 + 4);
                            }
                        }
                        if (MainActivity.f7304y9) {
                            MainActivity.m8546jb(false);
                        }
                        if (MainActivity.f6866B9) {
                            boolean z3 = System.currentTimeMillis() > MainActivity.f6903Fa;
                            boolean z4 = MainActivity.f7118da;
                            if (z3 || z4) {
                                f8783Cg.m8746Sa(z4 ? 2 : 4, false);
                                if ((f8930ge & 1) == 1) {
                                    MainActivity.f7268u9 = true;
                                    return;
                                }
                                return;
                            }
                            return;
                        }
                        return;
                    }
                    byte b5 = bArr3[i3 + 4];
                    if (b5 != -15) {
                        if (b5 == 37 && bArr3[i3 + 5] == 2) {
                            if (bArr3.length > 10) {
                                f8860Sd[66] = String.valueOf((bArr3[i3 + 9] & 255) | ((bArr3[i3 + 8] & 255) << 8));
                            }
                            b3 = (byte) (f8840Od + 1);
                            f8840Od = b3;
                        }
                        return;
                    }
                    byte b6 = bArr3[i3 + 5];
                    if (b6 == -116) {
                        String str = String.format("%02x", Integer.valueOf(bArr3[14] & 255));
                        int i21 = 0;
                        for (int i22 = 0; i22 < 4; i22++) {
                            i21 |= (bArr3[18 - i22] & 255) << (i22 * 8);
                        }
                        f8860Sd[64] = str.concat(String.format("%08x", Integer.valueOf(i21)));
                        b3 = (byte) (f8840Od + 1);
                        f8840Od = b3;
                    } else if (b6 == -112) {
                        String strM9124Lb = m9124Lb(bArr3, i3 + 6, 17, true, false);
                        f8860Sd[63] = strM9124Lb;
                        MainActivity.m8169Ab(0, m9124Lb(bArr3, 19, 6, true, false));
                        MainActivity.f7030Tb = strM9124Lb.substring(strM9124Lb.length() - 10);
                        f8783Cg.m8794t5();
                        MainActivity.m8169Ab(MainActivity.f7127ea ? 28 : 29, "");
                        b3 = (byte) (f8840Od + 1);
                        f8840Od = b3;
                    } else {
                        if (b6 != -103) {
                            if (b6 != 17) {
                                return;
                            }
                            String strM9124Lb2 = m9124Lb(bArr3, i3 + 6, 8, true, false);
                            String[] strArr = f8860Sd;
                            strArr[65] = strM9124Lb2;
                            f9008ye = bArr3[i3 + 15] & 15;
                            MainActivity.f7236qb = "---";
                            MainActivity.m8169Ab(20, strM9124Lb2);
                            int i23 = Integer.parseInt(strM9124Lb2.substring(1), 16);
                            f8980se = i23;
                            int i24 = i23 >> 8;
                            if (strArr[63] != null && strArr[63].length() > 4) {
                                MainActivity.f7218ob = ":" + String.format("%2x", Integer.valueOf(i24 & 255)) + strArr[63].substring(3, 4);
                            }
                            MainActivity.f7091aa = true;
                            String str2 = MainActivity.f7218ob;
                            MainActivity.m8169Ab(30, str2.substring(1, str2.length()));
                            String str3 = Integer.toHexString(f8980se >> 8) + "-" + Integer.toHexString(f8980se & 255);
                            strArr[62] = "BOSCH-EPM44";
                            MainActivity.m8169Ab(21, strArr[62]);
                            MainActivity.f6900F7 = 11;
                            MainActivity.f6910G8 = 130;
                            MainActivity.f6973N8 = 120.0f;
                            MainActivity.f6958Lb = "e";
                            MainActivity.f7251s8 = ActivityC2225t.m9000Lb(i24, 2, C2184q0.f8267a) & 127;
                            MainActivity.f7223p7 = "A1357JUXgvtho";
                            f8788Dg.f7799vd = "A1357JUXgvtho";
                            MainActivity.f7242r8 = 262144;
                            m9099Ee("P");
                            MainActivity.f7051W5 = false;
                            f8783Cg.m8778kb(20);
                            f8783Cg.m8780m9();
                            m9111He(MainActivity.f7116d8);
                            m9135Ne(enumC2294y3);
                            ActivityC2266vc.f8578Jd = 0;
                            MainActivity.f6925I5 = false;
                            f8956me = 1;
                            return;
                        }
                        byte b7 = bArr3[i3 + 6];
                        byte b8 = bArr3[i3 + 7];
                        int i25 = bArr3[i3 + 8] & 255;
                        int i26 = (b7 << 16) | (b8 << 8) | i25;
                        f8786De = i26;
                        String[] strArr2 = f8860Sd;
                        strArr2[68] = null;
                        if (i26 != -1) {
                            strArr2[68] = String.format("%02d", Integer.valueOf(b7)) + "/" + String.format("%02d", Integer.valueOf(b8)) + "/" + String.format("%02d", Integer.valueOf(i25));
                        }
                        b3 = (byte) (f8840Od + 1);
                        f8840Od = b3;
                    }
                    m9170Wd(b3);
                    return;
                }
                if (b4 != 103) {
                    if (b4 == 111) {
                        if (bArr3[i3 + 4] != -88) {
                            return;
                        }
                        MainActivity.f7268u9 = false;
                        MainActivity.f7286w9 = false;
                        f8783Cg.m8746Sa(4, false);
                        return;
                    }
                    if (b4 == 113) {
                        MainActivity.f7277v9 = false;
                        MainActivity.f7286w9 = false;
                        f8783Cg.m8756b5(16, 20);
                        return;
                    }
                    if (b4 == 126) {
                        ActivityC2266vc.f8571Cd = 0;
                        m9129Mc();
                        return;
                    }
                    if (b4 != 127) {
                        return;
                    }
                    byte b9 = bArr3[i3 + 4];
                    if (b9 == -88) {
                        MainActivity.f7268u9 = false;
                        MainActivity.f7286w9 = false;
                        f8783Cg.m8746Sa(0, false);
                        return;
                    }
                    if (b9 != 39) {
                        if (b9 != 49) {
                            return;
                        }
                        MainActivity.f7286w9 = false;
                        MainActivity.f7277v9 = false;
                        f8930ge = (byte) 0;
                        f8783Cg.m8756b5(0, 20);
                        return;
                    }
                    if (bArr3[i3 + 5] != 55) {
                        f8783Cg.m8734K9(null, null, MainActivity.f7299y4.getResources().getStringArray(R.array.eMessage)[5], 0, 12, 1, 0);
                        MainActivity.f6939Ja = 10;
                        f8783Cg.m8805y8(false);
                        return;
                    } else {
                        ActivityC2266vc.f8593Yd = true;
                        f8992vd = EnumC2294y.MODE_SESSION;
                        m9212kc(1000);
                        f8783Cg.m8752Z8("021003");
                        ActivityC2266vc.f8593Yd = false;
                        return;
                    }
                }
                byte b10 = bArr3[i3 + 4];
                if (b10 == 3) {
                    if (bArr3.length < 14) {
                        return;
                    }
                    int i27 = 0;
                    for (int i28 = 3; i28 >= 0; i28--) {
                        int i29 = i3 + i28;
                        int i30 = i28 * 8;
                        i11 |= (bArr3[i29 + 5] & 255) << i30;
                        i27 |= (bArr3[i29 + 9] & 255) << i30;
                    }
                    m9210jd(ActivityC2127m.m8939Cb(i11, i27));
                    return;
                }
                if (b10 != 4) {
                    return;
                }
                LedBar.m8097j(2);
                MainActivity.f7218ob = "?";
                MainActivity.f7030Tb = null;
                f8840Od = (byte) 56;
                enumC2294y = EnumC2294y.MODE_READ_ECU_INFOS;
            } else if (bArr3[i3 + 4] == 1) {
                short s = (short) (bArr3[i3 + 8] & 255);
                f8803Gg = s;
                if (s > 15) {
                    f8803Gg = (short) 15;
                }
                f8783Cg.m8788p8(f8803Gg > 0, false);
                m9091Ce(f8803Gg);
                f8956me = 0;
                if (f8803Gg <= 0 || !MainActivity.f6925I5) {
                    if (MainActivity.f6925I5) {
                        m9206ic();
                    }
                    if (MainActivity.f7116d8 == 3) {
                        f8783Cg.m8737M6(97, f8803Gg);
                    }
                    m9217le();
                    return;
                }
                m9091Ce(f8803Gg);
                enumC2294y = EnumC2294y.MODE_READ_CODES;
            } else {
                if (MainActivity.f6925I5) {
                    m9197fc(bArr3, i3, f8838Ng);
                    m9206ic();
                }
                enumC2294y = EnumC2294y.MODE_READ_SENSORS;
            }
            m9135Ne(enumC2294y);
        } catch (Exception e) {
            if (f8785Dd) {
                Log.e("ISORead", Log.getStackTraceString(e));
            }
        }
    }

    /* JADX INFO: renamed from: Vc */
    private static void m9165Vc() {
        m9098Ed(new byte[]{19, 64, 0}, (MainActivity.f7170j8 * 2) + 5, false);
    }

    /* JADX INFO: renamed from: Vd */
    private static void m9166Vd() {
        int i = f8816Je + f8826Le;
        int i2 = i / 16384;
        boolean z = f8787Df;
        if (!z) {
            i %= 16384;
        }
        if (i == 0 && i2 != f8805Hd && !z) {
            m9154Sd();
            return;
        }
        byte[] bArr = new byte[6];
        bArr[0] = 54;
        bArr[1] = 33;
        bArr[2] = z ? (byte) (i >> 16) : (byte) 0;
        bArr[3] = (byte) ((i >> 8) + (z ? 0 : 64));
        bArr[4] = (byte) i;
        bArr[5] = (byte) f8841Oe;
        m9098Ed(bArr, -1, true);
    }

    /* JADX INFO: renamed from: Ve */
    public static boolean m9167Ve(String str, String str2) {
        boolean z;
        if (str == null || str.equals("") || f8934gi[28] != 48) {
            z = false;
        } else {
            byte[] bytes = str.getBytes();
            for (int i = 0; i < bytes.length; i++) {
                int iM9128Mb = m9128Mb(bytes[i]);
                byte[] bArr = f8934gi;
                int i2 = i * 2;
                bArr[i2 + 28] = (byte) (iM9128Mb >> 8);
                bArr[i2 + 29] = (byte) (iM9128Mb & 255);
            }
            z = true;
        }
        if (str2 == null || str2.equals("") || f8934gi[68] != 48) {
            return z;
        }
        byte[] bytes2 = str2.getBytes();
        for (int i3 = 0; i3 < bytes2.length; i3++) {
            int iM9128Mb2 = m9128Mb(bytes2[i3]);
            byte[] bArr2 = f8934gi;
            int i4 = i3 * 2;
            bArr2[i4 + 68] = (byte) (iM9128Mb2 >> 8);
            bArr2[i4 + 69] = (byte) (iM9128Mb2 & 255);
        }
        return true;
    }

    /* JADX INFO: renamed from: Wb */
    private static boolean m9168Wb(byte[] bArr, int i, int i2) {
        int i3;
        try {
            if (MainActivity.f6862B5 || MainActivity.f6871C5) {
                if (bArr.length < 5) {
                    return false;
                }
                i3 = (f8876Ve ? bArr[i + 3] + 4 : bArr[i + 3] == 67 ? 10 : i2 - 1) & 255;
            } else {
                i3 = i2 - 1;
            }
            int i4 = 0;
            for (int i5 = 0; i5 < i3; i5++) {
                i4 += bArr[i + i5];
            }
            return ((byte) i4) == bArr[i + i3];
        } catch (Exception e) {
            if (f8785Dd) {
                Log.e("ISORead", Log.getStackTraceString(e));
            }
            return false;
        }
    }

    /* JADX INFO: renamed from: Wc */
    private static void m9169Wc() {
        byte[] bArr;
        if (f8777Bf) {
            bArr = new byte[]{3, 25, 2, -1};
        } else {
            bArr = f8812If ? new byte[]{25, 2, 8} : new byte[]{3};
        }
        m9098Ed(bArr, f8876Ve ? 12 : 11, false);
    }

    /* JADX INFO: renamed from: Wd */
    private static void m9170Wd(byte b2) {
        byte[] bArr;
        int i;
        if (!f8812If) {
            if (f8817Jf) {
                bArr = new byte[]{3, 34, -15, (byte) (f8853Qg[b2] & 255)};
            } else {
                short[] sArr = f8853Qg;
                i = 8;
                bArr = new byte[]{(byte) (sArr[b2] >> 8), (byte) (sArr[b2] & 255)};
                boolean z = bArr[1] == 4;
                boolean z2 = f8926ff;
                if (!(z & z2)) {
                    if (!(bArr[1] > 8) || !z2) {
                        i = 11;
                    } else if (f8936hf) {
                        i = 9;
                    }
                }
            }
            m9098Ed(bArr, i, false);
        }
        bArr = new byte[]{34, -15, (byte) (f8853Qg[b2] & 255)};
        i = 0;
        m9098Ed(bArr, i, false);
    }

    /* JADX INFO: renamed from: We */
    public static void m9171We() {
        int iM9128Mb = m9128Mb((byte) MainActivity.f6941Jc);
        int iM9128Mb2 = m9128Mb((byte) MainActivity.f6950Kc);
        byte[] bArr = f8929fi;
        bArr[12] = (byte) (iM9128Mb >> 8);
        bArr[13] = (byte) (iM9128Mb & 255);
        bArr[14] = (byte) (iM9128Mb2 >> 8);
        bArr[15] = (byte) (iM9128Mb2 & 255);
        f8972qe = 1;
    }

    /* JADX INFO: renamed from: Xb */
    private static int m9172Xb(int i) {
        int length;
        int i2;
        long[] jArr = C2198r0.f8292a;
        int i3 = 0;
        if (!MainActivity.f7019S9) {
            f8980se = 0;
        }
        f9010yg = false;
        int i4 = 0;
        while (i4 < jArr.length / 8 && jArr[(i4 * 8) + 4] <= 15) {
            i4++;
        }
        if (f8926ff) {
            MainActivity.f7259t8 = 30;
            MainActivity.f7267u8 = 16;
            length = i4;
            i4 = 0;
        } else {
            length = jArr.length / 8;
            MainActivity.f7259t8 = 127;
            MainActivity.f7267u8 = 3;
        }
        int i5 = i4;
        while (i5 < length && (65535 & i) != (((int) (jArr[i5 * 8] >> 16)) & 65535)) {
            i5++;
        }
        if (i5 < length) {
            MainActivity.f7251s8 = 0;
            int i6 = i5 * 8;
            f8980se = (int) jArr[i6 + 3];
            i3 = (int) jArr[i6 + 4];
            int i7 = i6 + 5;
            MainActivity.f7259t8 = 16777215 & ((int) jArr[i7]);
            MainActivity.f7267u8 = (int) (255 & (jArr[i7] >> 24));
            if (i3 > 16 && i3 < 80 && (MainActivity.f6862B5 | MainActivity.f6871C5)) {
                MainActivity.f7251s8 = (int) jArr[i6 + 6];
            }
        } else if (f8980se > 0) {
            while (i4 < length) {
                if (f8980se == ((int) (jArr[(i4 * 8) + 3] >> 16))) {
                    break;
                }
                i4++;
            }
            if (i4 < length) {
                MainActivity.f7251s8 = 0;
                int i8 = i4 * 8;
                int i9 = (int) jArr[i8 + 4];
                int i10 = i8 + 5;
                MainActivity.f7259t8 = 16777215 & ((int) jArr[i10]);
                MainActivity.f7267u8 = (int) (255 & (jArr[i10] >> 24));
                if (i9 > 16 && i9 < 80 && (MainActivity.f6862B5 | MainActivity.f6871C5)) {
                    MainActivity.f7251s8 = (int) jArr[i8 + 6];
                }
                i5 = i4;
                i3 = i9;
            } else {
                i5 = i4;
            }
        }
        if (i5 < length) {
            int i11 = i5 * 8;
            if (f8926ff) {
                i2 = C2182pc.f8204E[(int) (jArr[i11 + 7] / 100)];
            } else {
                i2 = C1973b.f7817a[(((int) jArr[i11 + 1]) * 48) + 2];
            }
            MainActivity.f6973N8 = i2 / 100;
        }
        return i3;
    }

    /* JADX INFO: renamed from: Xc */
    public static void m9173Xc(byte b2) {
        byte[] bArr = new byte[3];
        bArr[0] = -95;
        boolean z = f8946jg;
        bArr[1] = z ? (byte) 1 : (byte) -80;
        if (!z) {
            b2 = -1;
        }
        bArr[2] = b2;
        m9098Ed(bArr, 7, false);
    }

    /* JADX INFO: renamed from: Xd */
    private static void m9174Xd() {
        f8818Jg = 9;
        int i = f8816Je + f8826Le;
        m9177Yc(new byte[]{16, 9, 35, 37, 0, 0, (byte) (i >> 16), (byte) (i >> 8)}, (byte) 0);
    }

    /* JADX INFO: renamed from: Xe */
    public static void m9175Xe(int i, int i2) {
        int iM9128Mb = m9128Mb((byte) i2);
        byte[] bArr = f8929fi;
        int i3 = f8976re;
        bArr[i + i3 + 16] = (byte) (iM9128Mb >> 8);
        bArr[i + i3 + 17] = (byte) (iM9128Mb & 255);
        f8972qe = 2;
    }

    /* JADX INFO: renamed from: Yb */
    private static String m9176Yb(String str) {
        String str2;
        String str3;
        String[] strArr;
        int i;
        int i2;
        int i3;
        String str4;
        int i4;
        String str5;
        long[] jArr = C2198r0.f8292a;
        ActivityC2225t.f8509wd = null;
        int i5 = 0;
        while (true) {
            String[] strArr2 = f8829Lh;
            if (i5 >= strArr2.length / 2) {
                str2 = str;
                str3 = str2;
                break;
            }
            int i6 = i5 * 2;
            str2 = str;
            if (str.equals(strArr2[i6])) {
                str3 = strArr2[i6 + 1];
                break;
            }
            i5++;
        }
        int i7 = 0;
        while (true) {
            strArr = f8824Kh;
            if (i7 >= strArr.length || str3.equals(strArr[i7])) {
                break;
            }
            i7++;
        }
        if (i7 < strArr.length) {
            i = f8834Mh[i7];
        } else {
            i = -1;
            str3 = str2;
        }
        int i8 = 0;
        while (true) {
            if (i8 >= jArr.length / 8) {
                i2 = 0;
                i3 = 0;
                break;
            }
            int i9 = i8 * 8;
            if (((int) jArr[i9]) == i) {
                i2 = ((int) (jArr[i9 + 2] % 100)) * 32;
                i3 = (int) jArr[i9 + 4];
                MainActivity.f6973N8 = (jArr[i9 + 6] * 0.95f) / 100.0f;
                break;
            }
            i8++;
        }
        if (i2 != 0) {
            str4 = str3;
            i4 = 0;
            break;
        }
        int i10 = (f8980se & 16773120) == 7680000 ? 16776975 : 16777215;
        int i11 = 0;
        while (true) {
            if (i11 >= jArr.length / 8) {
                str4 = str3;
                i4 = 0;
                break;
            }
            int i12 = i11 * 8;
            int i13 = i12 + 3;
            str4 = str3;
            if (((int) (((long) i10) & jArr[i13])) == (f8980se & i10)) {
                i4 = ((int) (jArr[i12 + 2] % 100)) * 32;
                f8832Mf = jArr[i13] == 7680800;
                break;
            }
            i11++;
            str3 = str4;
        }
        if (i2 <= 0) {
            i2 = i4;
        }
        if ((i2 > 0) & (!f8787Df)) {
            int i14 = i2;
            int i15 = 0;
            while (C1973b.f7818b[i14 + 1] != 0) {
                i14 += 2;
                i15 += 2;
            }
            if (i15 > 0) {
                ActivityC2225t.f8509wd = new int[i15];
                for (int i16 = 0; i16 < i15; i16++) {
                    ActivityC2225t.f8509wd[i16] = (int) C1973b.f7818b[i2 + i16];
                }
            }
        }
        int i17 = 65280 & i3;
        boolean z = i17 == 4608;
        f8989uf = z;
        boolean z2 = i17 == 5120;
        f8994vf = z2;
        boolean z3 = i17 == 6144;
        f8985tf = z3;
        boolean z4 = i17 == 6656;
        f8999wf = z4;
        int i18 = 65520 & i3;
        boolean z5 = i18 == 8352;
        f9004xf = z5;
        boolean z6 = i18 == 8320;
        f9009yf = z6;
        boolean z7 = i18 == 8576;
        f9014zf = z7;
        boolean z8 = f8797Ff;
        boolean z9 = f8802Gf;
        boolean z10 = true ^ ((((((z | z2) | z3) | z4) | z8) | z9) | f8837Nf);
        f8981sf = z10;
        if (z2) {
            str5 = "E";
        } else if (z) {
            str5 = "D";
        } else if (z3) {
            str5 = "C";
        } else if (z8) {
            str5 = "G";
        } else if (z9) {
            if (z5) {
                str5 = "H";
            } else if (z6) {
                str5 = "F";
            } else {
                str5 = z7 ? "L" : "9";
            }
        } else if (z4) {
            str5 = "5";
        } else {
            str5 = z10 ? "8" : "";
        }
        m9099Ee(str5);
        System.arraycopy(m9096Eb(i), 0, f8905be, 20, 4);
        return str4;
    }

    /* JADX INFO: renamed from: Yc */
    public static void m9177Yc(byte[] bArr, byte b2) {
        byte[] bArr2;
        int i = 0;
        if (bArr == null) {
            bArr = new byte[]{b2};
            bArr2 = new byte[8];
        } else {
            bArr2 = new byte[Math.max(bArr.length, 8)];
        }
        byte[] bArr3 = new byte[(bArr2.length * 2) + 1];
        System.arraycopy(bArr, 0, bArr2, 0, bArr.length);
        while (i < bArr2.length) {
            byte b3 = (byte) ((bArr2[i] >> 4) & 15);
            int i2 = i * 2;
            bArr3[i2] = (byte) (b3 > 9 ? b3 + 55 : b3 + 48);
            byte b4 = (byte) (bArr2[i] & 15);
            bArr3[i2 + 1] = (byte) (b4 > 9 ? b4 + 55 : b4 + 48);
            i++;
        }
        bArr3[i * 2] = 13;
        f8783Cg.m8755a9(bArr3);
    }

    /* JADX WARN: Type inference failed for: r2v1, types: [boolean] */
    /* JADX INFO: renamed from: Yd */
    private static void m9178Yd() {
        if (f8867Tf && f8812If) {
            m9174Xd();
            return;
        }
        int i = f8841Oe;
        int i2 = f8816Je + f8826Le;
        ?? r2 = f8881We;
        int[] iArr = ActivityC2225t.f8450Gd;
        if (f8837Nf && f8867Tf && iArr != null) {
            int i3 = f8841Oe + i2;
            int i4 = MainActivity.f7169j7;
            if (i3 > iArr[i4] + iArr[i4 + 1]) {
                i = (iArr[i4] + iArr[i4 + 1]) - i2;
            }
        }
        byte[] bArr = new byte[(f8837Nf ? 5 : 6) + (r2 == true ? 1 : 0)];
        bArr[0] = 35;
        if (r2 > 0) {
            bArr[1] = 0;
        }
        bArr[(r2 == true ? 1 : 0) + 1] = (byte) ((i2 >> 16) + ((f8867Tf && f8911cf) ? 8 : 0));
        bArr[(r2 == true ? 1 : 0) + 2] = (byte) (i2 >> 8);
        bArr[(r2 == true ? 1 : 0) + 3] = (byte) i2;
        bArr[(r2 == true ? 1 : 0) + 4] = (byte) i;
        m9098Ed(bArr, -1, false);
    }

    /* JADX INFO: renamed from: Zb */
    private static String m9179Zb(String str) {
        int i;
        long[] jArr = C2198r0.f8292a;
        int i2 = 0;
        while (true) {
            if (i2 >= jArr.length / 8) {
                i = 0;
                break;
            }
            int i3 = i2 * 8;
            if (((int) jArr[i3 + 3]) == f8980se) {
                i = ((int) (jArr[i3 + 2] % 100)) * 32;
                break;
            }
            i2++;
        }
        if (i <= 0) {
            return "";
        }
        int i4 = 0;
        int i5 = i;
        while (C1973b.f7818b[i5 + 1] != 0) {
            i5 += 2;
            i4 += 2;
        }
        if (i4 <= 0) {
            return "";
        }
        ActivityC2225t.f8509wd = new int[i4];
        for (int i6 = 0; i6 < i4; i6++) {
            ActivityC2225t.f8509wd[i6] = (int) C1973b.f7818b[i + i6];
        }
        return "";
    }

    /* JADX INFO: renamed from: Zc */
    public static void m9180Zc(byte[] bArr, int i, boolean z) {
        ActivityC2266vc.f8573Ed = i;
        if (bArr != null && z) {
            int i2 = 0;
            int i3 = 0;
            while (i2 < bArr.length - 1) {
                i3 += bArr[i2];
                i2++;
            }
            if (i2 > 0) {
                bArr[i2] = (byte) (i3 & 255);
            }
        }
        ActivityC2266vc.m9074Xb(bArr, i, false, true);
    }

    /* JADX INFO: renamed from: Zd */
    private static void m9181Zd() {
        m9177Yc(new byte[]{3, 40, 1, 1}, (byte) 0);
    }

    /* JADX INFO: renamed from: ac */
    private static void m9182ac(String str) {
        String[] strArr;
        String str2;
        MainActivity.m8169Ab(0, str + "\n");
        int i = 0;
        while (true) {
            strArr = f8804Gh;
            if (i >= strArr.length || str.equals(strArr[i])) {
                break;
            } else {
                i++;
            }
        }
        int i2 = i < strArr.length ? f8809Hh[i] : 0;
        if (ActivityC2225t.m9000Lb(i2, 0, null) >= 4) {
            if (i2 == 7680256) {
                str2 = "7SMHW1xx";
            } else if (i2 == 7680768) {
                str2 = "7SMHW3xx";
            } else {
                str2 = i2 == 5522432 ? "5DMHW4xx" : "???";
            }
            m9155Se(str2);
            return;
        }
        f8857Rf = true;
        f8954lg = false;
        byte[] bArrM9041oc = ActivityC2225t.m9041oc();
        f8875Vd = bArrM9041oc;
        if (bArrM9041oc != null) {
            m9135Ne(EnumC2294y.MODE_REQ_UPLOAD);
        }
    }

    /* JADX INFO: renamed from: ad */
    public static void m9183ad() {
        byte[] bArr;
        if (f8917dg && f8992vd == EnumC2294y.MODE_READ_SENSORS) {
            m9217le();
            return;
        }
        if (f8817Jf) {
            bArr = new byte[]{2, 62, 0};
        } else if (f8812If) {
            bArr = new byte[]{62, 0};
        } else {
            bArr = new byte[1];
            bArr[0] = (byte) ((!(f8876Ve | f8871Ue) && !f8827Lf && !f8837Nf) ? 63 : 62);
        }
        m9098Ed(bArr, 6, false);
    }

    /* JADX INFO: renamed from: ae */
    private static void m9184ae() {
        byte[] bArr = new byte[3];
        bArr[0] = 2;
        bArr[1] = -95;
        bArr[2] = (byte) (f8842Of ? 2 : 1);
        m9177Yc(bArr, (byte) 0);
    }

    /* JADX INFO: renamed from: bc */
    public static int m9185bc(String str) {
        String[] strArr;
        int i = 0;
        while (true) {
            strArr = f8824Kh;
            if (i >= strArr.length || str.equals(strArr[i])) {
                break;
            }
            i++;
        }
        if (i >= strArr.length) {
            return 0;
        }
        int i2 = 0;
        while (true) {
            String[] strArr2 = f8824Kh;
            if (i2 >= strArr2.length) {
                return 0;
            }
            if (strArr2[i2].equals("RSV4") && i > i2) {
                return f8839Nh[(i - i2) - 1];
            }
            i2++;
        }
    }

    /* JADX INFO: renamed from: bd */
    private static void m9186bd() {
        m9098Ed(new byte[]{4}, 5, false);
    }

    /* JADX INFO: renamed from: be */
    private static void m9187be() {
        m9098Ed(new byte[]{53, 0, 95, -32, 0, 0, 0, 32}, -1, true);
    }

    /* JADX INFO: renamed from: cc */
    public static int m9188cc(String str, int i) {
        String[] strArr;
        int[] iArr = i == 0 ? f8844Oh : f8849Ph;
        int i2 = 0;
        while (true) {
            strArr = f8824Kh;
            if (i2 >= strArr.length || str.equals(strArr[i2])) {
                break;
            }
            i2++;
        }
        if (i2 >= strArr.length) {
            return 0;
        }
        int i3 = 0;
        while (true) {
            String[] strArr2 = f8824Kh;
            if (i3 >= strArr2.length) {
                return 0;
            }
            if (strArr2[i3].equals("RSV4") && i2 > i3) {
                return iArr[(i2 - i3) - 1];
            }
            i3++;
        }
    }

    /* JADX INFO: renamed from: cd */
    private static void m9189cd() {
        int i;
        if (f8827Lf || f8837Nf) {
            i = 3;
        } else {
            i = f8817Jf ? 5 : 4;
        }
        byte[] bArr = new byte[i];
        if (f8817Jf) {
            bArr[0] = 4;
            bArr[1] = 20;
            bArr[2] = -1;
            bArr[3] = -1;
            bArr[4] = -1;
        } else {
            bArr[0] = 20;
            bArr[1] = -1;
            if (i < 4) {
                bArr[2] = 0;
            } else {
                bArr[2] = -1;
                bArr[3] = -1;
            }
        }
        m9098Ed(bArr, -1, false);
    }

    /* JADX INFO: renamed from: ce */
    private static void m9190ce() {
        int i = ActivityC2225t.f8450Gd[MainActivity.f7169j7 + 1];
        byte[] bArr = new byte[8];
        bArr[0] = 53;
        int i2 = f8816Je;
        bArr[1] = (byte) (i2 < 32768 ? 0 : (i2 / 65536) + 1);
        bArr[2] = (byte) (i2 >> 8);
        bArr[3] = (byte) (((byte) i2) & 255);
        bArr[4] = 0;
        bArr[5] = (byte) (i >> 16);
        bArr[6] = (byte) (i >> 8);
        bArr[7] = (byte) (i & 255);
        m9098Ed(bArr, -1, true);
    }

    /* JADX INFO: renamed from: dc */
    public static void m9191dc(boolean z) {
        int i = 0;
        while (true) {
            if (i >= (z ? f8860Sd.length : 60)) {
                MainActivity.f7195m6.m8829b();
                return;
            } else {
                f8860Sd[i] = "";
                i++;
            }
        }
    }

    /* JADX INFO: renamed from: dd */
    private static void m9192dd() {
        m9098Ed(new byte[]{32}, -1, false);
    }

    /* JADX INFO: renamed from: de */
    private static void m9193de() {
        f8828Lg = Boolean.TRUE;
        int i = f8806He;
        m9177Yc(new byte[]{16, 9, 52, 0, 3, (byte) (i >> 16), (byte) (i >> 8), 0}, (byte) 0);
    }

    /* JADX INFO: renamed from: ec */
    private static void m9194ec(byte[] bArr, int i, int i2) {
        char[] cArr = {'P', 'C', 'B', 'U'};
        char[] cArr2 = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};
        int i3 = i2 - i;
        int i4 = f8881We ? f8822Kf ? 5 : 8 : 0;
        int i5 = f8876Ve ? 12 : 11;
        if (!(MainActivity.f6862B5 | MainActivity.f6871C5)) {
            ActivityC2266vc.f8575Gd = 0;
            ActivityC2266vc.f8572Dd = 0;
        }
        if (f8881We) {
            while (f8808Hg < f8813Ig) {
                short s = (short) ((bArr[i4] << 8) | (bArr[i4 + 1] & 255));
                if (s != 0) {
                    StringBuilder sb = new StringBuilder();
                    sb.append(cArr[0]);
                    sb.append(cArr2[(s >> 12) & 3]);
                    sb.append(cArr2[(s >> 8) & 15]);
                    sb.append(cArr2[(s >> 4) & 15]);
                    sb.append(cArr2[s & 15]);
                    if (!f8833Mg.contains(sb.toString())) {
                        f8833Mg.add(sb.toString());
                    }
                }
                f8808Hg++;
                i4 += f8822Kf ? 2 : 4;
            }
            return;
        }
        while (i3 >= 0) {
            for (int i6 = 0; i6 < 3; i6++) {
                if (f8808Hg < f8813Ig) {
                    int i7 = (i6 * 2) + i + i4;
                    short s2 = (short) ((bArr[i7 + 1] & 255) | (bArr[i7] << 8));
                    if (s2 != 0) {
                        StringBuilder sb2 = new StringBuilder();
                        sb2.append(cArr[(s2 >> 14) & 3]);
                        sb2.append(cArr2[(s2 >> 12) & 3]);
                        sb2.append(cArr2[(s2 >> 8) & 15]);
                        sb2.append(cArr2[(s2 >> 4) & 15]);
                        sb2.append(cArr2[s2 & 15]);
                        if (!f8833Mg.contains(sb2.toString())) {
                            f8833Mg.add(sb2.toString());
                        }
                        f8808Hg++;
                    }
                }
            }
            i3 -= i5;
            i4 += i5;
        }
    }

    /* JADX INFO: renamed from: ed */
    private static void m9195ed(boolean z) {
        byte[] bArr = new byte[4];
        bArr[0] = 48;
        bArr[1] = 21;
        bArr[2] = (byte) (z ? 5 : 7);
        bArr[3] = (byte) f8780Cd;
        m9098Ed(bArr, -1, false);
    }

    /* JADX INFO: renamed from: ee */
    private static void m9196ee() {
        m9098Ed(new byte[]{52}, -1, !f8876Ve);
        f8783Cg.m8791qa(false, 1);
    }

    /* JADX INFO: renamed from: fc */
    private static void m9197fc(byte[] bArr, int i, int i2) {
        char[] cArr = {'P', 'C', 'B', 'U'};
        char[] cArr2 = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};
        int i3 = 6;
        while (f8808Hg < f8813Ig) {
            int i4 = i + i3;
            short s = (short) ((bArr[i4 + 1] & 255) | (bArr[i4] << 8));
            if (s != 0) {
                StringBuilder sb = new StringBuilder();
                sb.append(cArr[(s >> 14) & 3]);
                sb.append(cArr2[(s >> 12) & 3]);
                sb.append(cArr2[(s >> 8) & 15]);
                sb.append(cArr2[(s >> 4) & 15]);
                sb.append(cArr2[s & 15]);
                if (!f8833Mg.contains(sb.toString())) {
                    f8833Mg.add(sb.toString());
                }
                f8808Hg++;
                i3 += 4;
            }
        }
    }

    /* JADX INFO: renamed from: fd */
    private static void m9198fd(int i) {
        m9098Ed(new byte[]{34, (byte) ((i >> 8) & 255), (byte) (i & 255)}, -1, false);
    }

    /* JADX INFO: renamed from: fe */
    private static void m9199fe() {
        int i;
        int i2;
        byte[] bArr = new byte[8];
        bArr[0] = 52;
        boolean z = f8792Ef;
        boolean z2 = f8842Of;
        bArr[1] = (byte) ((z || z2) ? 0 : 8);
        if (z) {
            i = 64;
        } else {
            i = z2 ? 96 : 0;
        }
        bArr[2] = (byte) i;
        int i3 = 3;
        bArr[3] = 0;
        bArr[4] = (byte) (z ? 51 : 1);
        if (z) {
            i3 = 4;
        } else if (z2) {
            i3 = 10;
        }
        bArr[5] = (byte) i3;
        if (z) {
            i2 = 192;
        } else {
            i2 = z2 ? 160 : 0;
        }
        bArr[6] = (byte) i2;
        bArr[7] = 0;
        m9098Ed(bArr, -1, false);
    }

    @SuppressLint({"DefaultLocale"})
    /* JADX INFO: renamed from: gc */
    private static void m9200gc(byte[] bArr) {
        for (int i = 0; i < 16; i++) {
            byte b2 = (byte) (bArr[i + 20] - 48);
            if (b2 > 16) {
                b2 = (byte) (b2 - 7);
            }
            for (byte b3 = 0; b3 < 4; b3 = (byte) (b3 + 1)) {
                if ((((byte) (b2 >> b3)) & 1) != 0) {
                    int i2 = f8939hi[(i * 4) + b3];
                    f8833Mg.add(i2 == 0 ? "P????" : "P" + String.format("%04d", Integer.valueOf(i2)));
                }
            }
        }
    }

    /* JADX INFO: renamed from: gd */
    private static void m9201gd() {
        byte[] bArr = f8880Wd;
        byte[] bArr2 = new byte[bArr.length + 2];
        bArr2[0] = 59;
        bArr2[1] = -103;
        System.arraycopy(bArr, 0, bArr2, 2, bArr.length);
        m9098Ed(bArr2, -1, false);
    }

    /* JADX INFO: renamed from: ge */
    private static void m9202ge() {
        m9098Ed(new byte[]{17, 1}, 5, true);
    }

    /* JADX INFO: renamed from: hc */
    private static void m9203hc(int i) {
        f8930ge = (byte) 0;
        f8778Bg.m9079Tb(EnumC2281x.ERR_NULL);
        f8992vd = EnumC2294y.MODE_NULL;
        f8783Cg.m8757b9(i);
    }

    /* JADX INFO: renamed from: hd */
    private static void m9204hd() {
        byte[] bArr = f8819Jh;
        byte[] bArr2 = new byte[bArr.length + 2];
        bArr2[0] = 59;
        bArr2[1] = -104;
        System.arraycopy(bArr, 0, bArr2, 2, bArr.length);
        m9098Ed(bArr2, -1, false);
    }

    /* JADX INFO: renamed from: he */
    private static void m9205he() {
        byte[] bArr = new byte[3];
        int i = 0;
        bArr[0] = 49;
        bArr[1] = -112;
        if (!f8842Of) {
            i = f8926ff ? 17 : 1;
        }
        bArr[2] = (byte) i;
        m9098Ed(bArr, -1, true);
    }

    /* JADX INFO: renamed from: ic */
    private static void m9206ic() {
        List list = f8833Mg;
        if (list != null) {
            Collections.sort(list);
            f8783Cg.m8783n7(f8833Mg);
        }
    }

    /* JADX INFO: renamed from: id */
    private static void m9207id() {
        byte[] bArr;
        if (f8777Bf) {
            bArr = new byte[]{3, 25, 1, -1};
        } else {
            bArr = f8812If ? new byte[]{25, 1, 8} : new byte[]{1, 1};
        }
        m9098Ed(bArr, 10, false);
    }

    /* JADX INFO: renamed from: ie */
    private static void m9208ie() {
        int i = f8770Ad;
        int i2 = f8775Bd;
        m9098Ed(new byte[]{-93, (byte) (i >> 8), (byte) (i & 255), (byte) (i2 >> 8), (byte) (i2 & 255)}, 9, false);
    }

    /* JADX INFO: renamed from: jc */
    private static void m9209jc() {
        if (MainActivity.f7244ra) {
            f8783Cg.m8792r6(MainActivity.f7299y4.getText(R.string.update_done).toString(), 0, Boolean.FALSE);
            MainActivity.f7244ra = false;
        } else {
            if (MainActivity.f7235qa) {
                f8783Cg.m8782n6(false);
                f8783Cg.m8734K9(null, null, f8778Bg.m9079Tb(EnumC2281x.SECURITY_UNLOCK), 0, 3, 2, 46);
                return;
            }
            MainActivity.f7269ua = true;
            f8783Cg.m8793r9(10, 10, 0L);
        }
        m9212kc(400);
        f8783Cg.m8805y8(true);
    }

    /* JADX INFO: renamed from: jd */
    private static void m9210jd(int[] iArr) {
        f8818Jg = 18;
        f8820Kd = iArr[1];
        byte[] bArr = new byte[8];
        bArr[0] = 16;
        bArr[1] = 10;
        bArr[2] = 39;
        bArr[3] = 4;
        for (int i = 0; i < 4; i++) {
            bArr[i + 4] = (byte) ((iArr[0] >> (i * 8)) & 255);
        }
        m9098Ed(bArr, -1, false);
    }

    /* JADX INFO: renamed from: je */
    private static void m9211je() {
        boolean z = f8876Ve | f8797Ff | f8802Gf | f8812If | f8817Jf;
        byte b2 = f8835Nd;
        if (!(z | (b2 != 3))) {
            b2 = 5;
        }
        ActivityC2266vc.f8590Vd = false;
        if (f8847Pf) {
            m9098Ed(new byte[]{39, 3, 2}, 9, false);
        } else if (f8817Jf) {
            m9098Ed(new byte[]{2, 39, 3}, -1, false);
        } else {
            m9098Ed(new byte[]{39, b2}, 8, false);
        }
    }

    /* JADX INFO: renamed from: kc */
    private static void m9212kc(int i) {
        try {
            Thread.sleep(i);
        } catch (InterruptedException e) {
            if (f8785Dd) {
                Log.e("ISORead", Log.getStackTraceString(e));
            }
        }
    }

    /* JADX INFO: renamed from: kd */
    private static void m9213kd() {
        m9098Ed(new byte[]{-92, 2}, -1, false);
    }

    /* JADX INFO: renamed from: ke */
    private static void m9214ke(String str, int i) {
        byte[] bArr = new byte[8];
        bArr[0] = 3;
        bArr[1] = (byte) i;
        System.arraycopy(m9143Pe(str, 8), 0, bArr, 2, 4);
        m9177Yc(bArr, (byte) 0);
    }

    /* JADX INFO: renamed from: lc */
    public static void m9215lc(boolean z) {
        EnumC2294y enumC2294y;
        f8937hg = z;
        f8942ig = z;
        f8892Yf = false;
        f8857Rf = true;
        f8867Tf = false;
        f9002xd = 0;
        if (f8931gf) {
            enumC2294y = EnumC2294y.MODE_WALBRO_BREAK;
        } else {
            if (ActivityC2266vc.f8576Hd == 8) {
                return;
            }
            String strSubstring = MainActivity.f7030Tb;
            if (strSubstring == null) {
                strSubstring = "";
            }
            if (strSubstring.endsWith(";")) {
                strSubstring = strSubstring.substring(0, strSubstring.length() - 1);
            }
            if (MainActivity.f7115d7 == 4) {
                strSubstring = f8860Sd[63];
            }
            if (strSubstring == null || strSubstring.equals("")) {
                strSubstring = "----";
            }
            if (MainActivity.f7115d7 > 0 && !MainActivity.f6904Fb.equals(strSubstring)) {
                f8857Rf = false;
                f8783Cg.m8734K9(null, null, f8778Bg.m9079Tb(EnumC2281x.UNAUTHORIZED_MAP), 0, 2, 1, 41);
            } else {
                if (!f8807Hf) {
                    f8992vd = EnumC2294y.MODE_NULL;
                    if (!MainActivity.f6862B5 && !MainActivity.f6871C5) {
                        m9254yc(213);
                        return;
                    } else {
                        MainActivity.f6939Ja = 20;
                        f8783Cg.m8805y8(false);
                        return;
                    }
                }
                if (!f8954lg) {
                    f8988ue = (MainActivity.f7133f7 & 65520) == 1024 ? 1 : 0;
                }
                ActivityC2266vc.m9072Ub(8);
            }
            enumC2294y = EnumC2294y.MODE_NULL;
        }
        m9135Ne(enumC2294y);
    }

    /* JADX INFO: renamed from: ld */
    private static void m9216ld() {
        byte[] bArr = new byte[2];
        bArr[0] = 51;
        bArr[1] = (byte) (f8792Ef ? 2 : 196);
        m9098Ed(bArr, -1, false);
    }

    /* JADX INFO: renamed from: le */
    private static void m9217le() {
        short[] sArr;
        char c2;
        int i;
        int i2;
        byte[] bArr;
        int i3 = f8935he;
        short[] sArr2 = f8873Ug;
        if (sArr2 == null) {
            return;
        }
        if (i3 >= sArr2.length) {
            i3 = 0;
        }
        int length = i3;
        do {
            sArr = f8873Ug;
            c2 = 1;
            if (sArr[length + 1] >= 1) {
                break;
            } else {
                length = (length + 2) % sArr.length;
            }
        } while (length != i3);
        short s = sArr[length];
        f8935he = (length + 2) % sArr.length;
        MainActivity.f7080Z7 = System.currentTimeMillis() - MainActivity.f7071Y7;
        f8783Cg.m8770g9(MainActivity.f7116d8 > 0, MainActivity.f7080Z7);
        byte b2 = 33;
        if (!f8871Ue) {
            if (f8827Lf) {
                bArr = new byte[]{33, 0};
            } else {
                if (f8917dg) {
                    m9098Ed(new byte[]{33, (byte) ((s / 256) & 127), (byte) (s & 255)}, 7, false);
                    f8798Fg = s;
                    return;
                }
                if (f8777Bf) {
                    int i4 = s / 256;
                    if ((i4 & 240) != 0) {
                        f8783Cg.m8752Z8("ATSH7DF");
                        MainActivity.f7160i7 = s & 4095;
                        MainActivity.f7151h7 = 1;
                        return;
                    } else {
                        bArr = new byte[]{3, 34, (byte) (i4 & 127), 0};
                        i2 = 0;
                        c2 = 3;
                        i = 0;
                    }
                } else {
                    int i5 = s >> 12;
                    int i6 = (i5 & 4) != 0 ? i5 - 3 : 0;
                    i = i6 == 0 ? 3 : 0;
                    byte[] bArr2 = new byte[i == 0 ? 2 : 3];
                    if (i == 3) {
                        bArr2[0] = 34;
                        bArr2[1] = (byte) (((s / 256) & 127) + (f8812If ? 1 : 0));
                        i2 = i6;
                        bArr = bArr2;
                        c2 = 2;
                    } else {
                        bArr2[0] = (byte) ((s / 256) & 15);
                        i2 = i6;
                        bArr = bArr2;
                    }
                }
            }
            bArr[c2] = (byte) (s & 255);
            m9098Ed(bArr, i + i2 + 6, false);
            f8798Fg = s;
        }
        bArr = new byte[2];
        if (f8956me > 0) {
            s = 84;
            f8956me = 0;
        } else if (f8952le > 0) {
            b2 = 20;
            f8952le = 0;
            s = 1;
        }
        bArr[0] = b2;
        i2 = 0;
        i = 0;
        bArr[c2] = (byte) (s & 255);
        m9098Ed(bArr, i + i2 + 6, false);
        f8798Fg = s;
    }

    /* JADX INFO: renamed from: mc */
    private static byte[] m9218mc(byte[] bArr) {
        byte[] bArr2;
        boolean z;
        if ((bArr[4] & 240) == 0) {
            boolean z2 = f8782Cf;
            int i = bArr[(z2 ? 2 : 4) + 0];
            f8838Ng = i;
            int i2 = i + (z2 ? 3 : 5);
            byte[] bArr3 = new byte[i2];
            System.arraycopy(bArr, 0, bArr3, 0, i2);
            return bArr3;
        }
        if (bArr[4] == 48) {
            m9130Md();
            return null;
        }
        if (bArr[4] == 16) {
            int i3 = bArr[5] & 255;
            f8838Ng = i3;
            bArr2 = new byte[i3 + 5];
            System.arraycopy(bArr, 0, bArr2, 0, 4);
            z = true;
        } else {
            bArr2 = null;
            z = false;
        }
        int i4 = 0;
        int i5 = 0;
        while (z) {
            int i6 = i4 + 4;
            if ((bArr[i6] & 240) > 0) {
                byte b2 = bArr[i6];
                f8843Og = (b2 & 15) + i5;
                if (b2 == 47) {
                    i5 += 16;
                }
                int i7 = 0;
                int i8 = 0;
                while (i7 < 7) {
                    int i9 = f8843Og;
                    bArr2[(i9 * 7) + i8 + 4] = bArr[i4 + 5];
                    i8++;
                    i7++;
                    i4++;
                    if ((i9 * 7) + i8 > f8838Ng) {
                        z = false;
                        break;
                    }
                }
                i4 += 5;
                if (i4 + 5 >= bArr.length) {
                    int i10 = f8843Og;
                    if ((i10 * 7) + i8 + 5 < bArr2.length && i10 < 15) {
                        return bArr2;
                    }
                } else {
                    continue;
                }
            }
            z = false;
        }
        return bArr2;
    }

    /* JADX INFO: renamed from: md */
    private static void m9219md(int i) {
        m9098Ed(new byte[]{34, (byte) ((i >> 8) & 255), (byte) (i & 255)}, -1, false);
    }

    /* JADX INFO: renamed from: me */
    private static void m9220me() {
        int i;
        boolean z = f8876Ve;
        char c2 = 2;
        byte[] bArr = new byte[z ? 3 : 2];
        bArr[0] = (byte) (z ? 165 : 162);
        if (z) {
            bArr[1] = 74;
        } else {
            c2 = 1;
        }
        if (MainActivity.f6862B5 || MainActivity.f6871C5) {
            i = 128;
        } else {
            i = f8926ff ? 129 : 130;
        }
        bArr[c2] = (byte) i;
        m9098Ed(bArr, -1, !f8876Ve);
    }

    /* JADX INFO: renamed from: nc */
    public static byte[] m9221nc(byte[] bArr, String str, int i, int i2, int i3) {
        long[] jArr = i3 == 0 ? C2198r0.f8292a : C2184q0.f8267a;
        int i4 = i * 8;
        int i5 = (int) jArr[i4];
        int i6 = ((int) (jArr[i4 + 2] % 100)) * 32;
        int i7 = (int) jArr[i4 + 4];
        int i8 = i6;
        int i9 = 0;
        int i10 = 0;
        while (true) {
            long[] jArr2 = C1973b.f7818b;
            int i11 = i8 + 1;
            if (jArr2[i11] <= 0) {
                break;
            }
            i9 = (int) (((long) i9) + jArr2[i11]);
            i8 += 2;
            i10 += 2;
        }
        int i12 = ((i2 * 4) + 402920305) - (i7 < 80 ? 6 : 0);
        String strM9033gc = ActivityC2225t.m9033gc(str, 49151 & i7, 0);
        int length = strM9033gc.length() * 2;
        byte[] bArr2 = new byte[i9 + length + (i10 * 4) + 42];
        System.arraycopy(ActivityC2225t.m9017Tc(i12), 0, bArr2, 0, 4);
        System.arraycopy(ActivityC2225t.m9017Tc(length), 0, bArr2, 28, 2);
        for (int i13 = 0; i13 < 4; i13++) {
            bArr2[23 - i13] = (byte) (i5 >> (i13 * 8));
        }
        if (i7 < 80) {
            System.arraycopy(ActivityC2225t.m9017Tc(13684944), 0, bArr2, 8, 3);
            System.arraycopy(ActivityC2225t.m9017Tc(13684944), 0, bArr2, 16, 3);
            System.arraycopy(bArr, 393209, bArr2, 11, 3);
            System.arraycopy(bArr, 393214, bArr2, 14, 2);
            bArr2[19] = (byte) (bArr2[11] & 247);
            int iIndexOf = "0123456789ABCDEFGHIJKLMNOPQRSTUV".indexOf(ActivityC2225t.m9033gc(str, i7, 2));
            if (iIndexOf > 0) {
                bArr2[27] = (byte) iIndexOf;
            }
        }
        StringBuilder sb = new StringBuilder(str);
        for (int i14 = 0; i14 < sb.length(); i14++) {
            bArr2[i14 + 4] = (byte) String.valueOf(sb).charAt(i14);
        }
        System.arraycopy(MainActivity.m8319Oa(strM9033gc), 0, bArr2, 30, length);
        int i15 = length + 30;
        System.arraycopy(ActivityC2225t.m9017Tc(7300718), 0, bArr2, i15, 3);
        int i16 = i15 + 3;
        int i17 = i16 + 1;
        int i18 = i10 / 2;
        bArr2[i16] = (byte) i18;
        int i19 = i6;
        int i20 = 0;
        while (i20 < i10) {
            System.arraycopy(ActivityC2225t.m9017Tc((int) C1973b.f7818b[i19]), 0, bArr2, (i20 * 4) + i17, 4);
            i20++;
            i19++;
        }
        int i21 = i17 + (i20 * 4);
        for (int i22 = 0; i22 < i18; i22++) {
            long[] jArr3 = C1973b.f7818b;
            int i23 = (i22 * 2) + i6;
            int i24 = (int) jArr3[i23];
            int i25 = (int) jArr3[i23 + 1];
            System.arraycopy(bArr, i24, bArr2, i21, i25);
            i21 += i25;
        }
        return bArr2;
    }

    /* JADX INFO: renamed from: nd */
    public static void m9222nd() {
        if (MainActivity.f7142g7 == 1) {
            m9225od();
            return;
        }
        int i = f8841Oe + 2;
        f8828Lg = Boolean.TRUE;
        f8968pe = 0;
        int i2 = f8806He;
        if (MainActivity.f7169j7 + i2 >= f8856Re) {
            i2 += f8861Se;
        }
        byte[] bArr = new byte[8];
        bArr[0] = (byte) ((i / 256) | 16);
        bArr[1] = (byte) (i & 255);
        bArr[2] = 54;
        bArr[3] = (byte) (f8815Jd & 255);
        int i3 = 0;
        int i4 = 4;
        while (i3 < 4) {
            bArr[i4] = ActivityC2225t.f8442Cd[MainActivity.f7169j7 + i2 + i3];
            i3++;
            i4++;
        }
        ActivityC2266vc.f8571Cd = 0;
        f8968pe = i3;
        m9177Yc(bArr, (byte) 0);
    }

    /* JADX WARN: Multi-variable type inference failed */
    /* JADX INFO: renamed from: ne */
    public static void m9223ne(byte b2, String str) {
        boolean z = (b2 & 20) == 20;
        byte[] bArr = new byte[z ? 7 : 4];
        bArr[0] = 46;
        bArr[1] = 2;
        bArr[2] = b2;
        if (z) {
            System.arraycopy(m9143Pe(str, 8), 0, bArr, 3, 4);
        } else {
            bArr[3] = str.equals("1") ? (byte) 1 : (byte) 0;
        }
        m9098Ed(bArr, -1, true);
    }

    @SuppressLint({"DefaultLocale"})
    /* JADX INFO: renamed from: oc */
    public static String m9224oc(boolean z) {
        String str;
        String str2 = "1";
        if (f8777Bf) {
            str = "P";
        } else if (f8797Ff) {
            str = "F";
        } else if (f8802Gf) {
            str = "E";
        } else if (f8969pf) {
            str = "D";
        } else if (f8973qf) {
            str = "C";
        } else if (f8901af) {
            str = "J";
        } else if (f8896Ze) {
            str = "N";
        } else if (f8977rf) {
            str = "B";
        } else if (f8999wf) {
            str = "A";
        } else if (f8985tf) {
            str = "8";
        } else if (f8994vf) {
            str = "7";
        } else if (f8989uf) {
            str = "6";
        } else if (f8981sf) {
            str = "5";
        } else if (f8871Ue) {
            str = "4";
        } else if (f8965of) {
            str = "3";
        } else if (f8822Kf) {
            str = "2";
        } else if (f8961nf) {
            str = "1";
        } else {
            str = f8772Af ? "0" : " ";
        }
        StringBuilder sb = new StringBuilder(str);
        if (z) {
            if (f8931gf) {
                str2 = "2";
            } else if (!f8926ff) {
                str2 = "0";
            }
            sb.append(str2);
            sb.append(String.format("%03d", Integer.valueOf((int) MainActivity.f6973N8)));
            sb.append(String.format("%03d", Integer.valueOf(MainActivity.f6910G8)));
        }
        return sb.toString();
    }

    /* JADX INFO: renamed from: od */
    public static void m9225od() {
        f8968pe = 0;
        int i = f8806He;
        if (MainActivity.f7169j7 + i >= f8856Re) {
            i += f8861Se;
        }
        byte[] bArr = new byte[8];
        bArr[0] = 17;
        bArr[1] = 2;
        bArr[2] = 54;
        bArr[3] = (byte) (f8815Jd & 255);
        int i2 = 0;
        int i3 = 4;
        while (i2 < 4) {
            bArr[i3] = ActivityC2225t.f8442Cd[MainActivity.f7169j7 + i + i2];
            i2++;
            i3++;
        }
        f8968pe = 4;
        m9177Yc(bArr, (byte) 0);
    }

    /* JADX INFO: renamed from: oe */
    private static void m9226oe(boolean z) {
        byte[] bArr = (byte[]) f8869Th.clone();
        bArr[3] = (byte) (z ? 136 : 0);
        m9177Yc(bArr, (byte) 0);
    }

    /* JADX INFO: renamed from: pc */
    private static String m9227pc(String str) {
        int identifier = f8783Cg.getResources().getIdentifier("K" + str, "string", f8783Cg.getPackageName());
        if (identifier != 0) {
            try {
                return f8783Cg.getString(identifier);
            } catch (Throwable th) {
                th.printStackTrace();
            }
        }
        return "";
    }

    /* JADX INFO: renamed from: pd */
    private static void m9228pd() {
        m9098Ed(new byte[]{34, 1, 33}, -1, false);
    }

    /* JADX INFO: renamed from: pe */
    private static void m9229pe(byte b2) {
        m9098Ed(new byte[]{34, 2, b2}, -1, true);
    }

    /* JADX INFO: renamed from: qc */
    private static String m9230qc(byte[] bArr) {
        String strM9120Kb;
        int i = 532480;
        while (true) {
            if (i >= 589824) {
                i = 0;
                break;
            }
            if (MainActivity.m8498f5(bArr, i, 4) == 1163018573 && MainActivity.m8498f5(bArr, i + 4, 4) == 541674572) {
                break;
            }
            i++;
        }
        String strM9120Kb2 = "";
        if (i > 532480) {
            int i2 = i - 14;
            while (bArr[i2] != 10) {
                i2++;
            }
            strM9120Kb2 = m9120Kb(bArr, i2 + 1, 8, "p");
            strM9120Kb = m9120Kb(bArr, i2 + 32, 4, "p");
        } else {
            strM9120Kb = "";
        }
        return strM9120Kb2 + strM9120Kb;
    }

    /* JADX INFO: renamed from: qd */
    private static void m9231qd() {
        boolean z = f8857Rf;
        boolean z2 = f8797Ff;
        boolean z3 = f8802Gf;
        byte[] bArr = new byte[(z | z2) | z3 ? 3 : 2];
        bArr[0] = 16;
        bArr[1] = -123;
        if (z2 || z3) {
            bArr[2] = 7;
        } else if (z) {
            bArr[2] = 3;
        }
        m9098Ed(bArr, -1, false);
    }

    /* JADX INFO: renamed from: qe */
    public static void m9232qe() {
        m9098Ed(new byte[]{46, 1, -127, -1, -1}, -1, false);
    }

    /* JADX INFO: renamed from: rc */
    private static void m9233rc(byte[] bArr, int i) {
        char[] cArr = {'P', 'C', 'B', 'U'};
        char[] cArr2 = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};
        while (f8808Hg < f8813Ig) {
            short s = (short) ((bArr[i] << 8) | (bArr[i + 1] & 255));
            if (s != 0) {
                StringBuilder sb = new StringBuilder();
                sb.append(cArr[(s >> 14) & 3]);
                sb.append(cArr2[(s >> 12) & 3]);
                sb.append(cArr2[(s >> 8) & 15]);
                sb.append(cArr2[(s >> 4) & 15]);
                sb.append(cArr2[s & 15]);
                if (!f8833Mg.contains(sb.toString())) {
                    f8833Mg.add(sb.toString());
                }
            }
            f8808Hg++;
            i += 3;
        }
    }

    /* JADX INFO: renamed from: rd */
    private static void m9234rd(int i, int i2) {
        ActivityC2266vc.f8590Vd = false;
        byte[] bArr = new byte[6];
        bArr[0] = 39;
        bArr[1] = (byte) (f8797Ff | f8802Gf ? 4 : 2);
        bArr[2] = (byte) (i / 256);
        bArr[3] = (byte) (i & 255);
        bArr[4] = (byte) (i2 / 256);
        bArr[5] = (byte) (i2 & 255);
        m9098Ed(bArr, -1, false);
    }

    /* JADX INFO: renamed from: re */
    private static void m9235re() {
        int i;
        int i2;
        byte[] bArr;
        int i3;
        int i4 = 3;
        int i5 = 2;
        if (f8812If) {
            i = 4;
        } else {
            boolean z = f8871Ue | f8876Ve;
            boolean z2 = f8827Lf;
            boolean z3 = MainActivity.f7276v8 == 0;
            byte b2 = f8925fe;
            i = z | (z2 & ((z3 | (b2 == 32)) | (b2 == 126))) ? 3 : 2;
        }
        byte[] bArr2 = new byte[i];
        if (!f8812If) {
            if (f8817Jf) {
                if (MainActivity.f7277v9) {
                    int i6 = f8863Sg[f8925fe];
                    int i7 = i6 & 255;
                    int i8 = i7 != 254 ? 5 : 4;
                    bArr = new byte[i8 + 1];
                    bArr[0] = (byte) i8;
                    bArr[1] = 49;
                    i2 = i8 - (i7 != 254 ? 2 : 1);
                    int i9 = 0;
                    while (i9 < i2) {
                        bArr[i5] = (byte) ((i6 >> ((i2 - i9) * 8)) & 255);
                        i9++;
                        i5++;
                    }
                } else {
                    int i10 = f8858Rg[f8925fe];
                    int i11 = i10 & 255;
                    int i12 = i11 == 254 ? 5 : 6;
                    bArr = new byte[i12 + 1];
                    bArr[0] = (byte) i12;
                    bArr[1] = 47;
                    bArr[2] = -88;
                    i2 = i12 - (i11 != 254 ? 3 : 2);
                    int i13 = 0;
                    while (i13 < i2) {
                        bArr[i4] = (byte) ((i10 >> ((i2 - i13) * 8)) & 255);
                        i13++;
                        i4++;
                    }
                }
                bArr2 = bArr;
            } else if (f8871Ue) {
                bArr2[0] = 49;
                bArr2[1] = -127;
                bArr2[2] = f8925fe;
            } else if (f8827Lf) {
                bArr2[0] = (byte) ((i == 2 ? MainActivity.f7276v8 : 0) + 48);
                byte b3 = f8930ge;
                if (b3 == 0) {
                    byte b4 = f8925fe;
                    bArr2[1] = b4;
                    if (i > 2) {
                        bArr2[2] = (byte) (b4 != 126 ? 7 : 4);
                    }
                } else {
                    bArr2[1] = b3;
                    if (i > 2) {
                        bArr2[2] = 0;
                    }
                }
            } else {
                byte b5 = f8930ge;
                if (b5 == 0) {
                    bArr2[0] = 49;
                    if (f8876Ve) {
                        byte b6 = f8925fe;
                        bArr2[1] = (byte) (((b6 & 240) >> 4) | 160);
                        bArr2[2] = (byte) (b6 & 15);
                    } else {
                        bArr2[1] = f8925fe;
                    }
                } else {
                    bArr2[0] = 50;
                    if (f8876Ve) {
                        bArr2[1] = (byte) (((b5 & 240) >> 4) | 160);
                        bArr2[2] = (byte) (b5 & 15);
                    } else {
                        bArr2[1] = b5;
                    }
                }
                i2 = ((f8925fe == 0 ? 1 : 0) | (b5 == 0 ? 0 : 1)) != 0 ? 7 : 6;
            }
            m9098Ed(bArr2, i2, false);
        }
        bArr2[0] = 49;
        if (f8930ge == 0) {
            i3 = 1;
        } else {
            i3 = (f8925fe == 25) & (MainActivity.f6984Oa >= 4) ? 3 : 2;
        }
        bArr2[1] = (byte) i3;
        byte b7 = f8925fe;
        bArr2[2] = (byte) (b7 == 25 ? 113 : 112);
        bArr2[3] = b7;
        i2 = 0;
        m9098Ed(bArr2, i2, false);
    }

    /* JADX WARN: Code duplicated, block: B:43:0x007c  */
    /* JADX WARN: Code duplicated, block: B:511:0x09c5  */
    /* JADX WARN: Code duplicated, block: B:512:0x09c8  */
    /* JADX INFO: renamed from: sc */
    private static void m9236sc(byte[] bArr, int i, int i2) throws Throwable {
        EnumC2294y enumC2294y;
        boolean z;
        ActivityC2266vc activityC2266vc;
        int i3;
        int i4;
        int i5;
        String strM9079Tb;
        MainActivity mainActivity;
        String str;
        String[] strArr;
        int i6;
        int i7;
        int i8;
        int i9;
        int i10;
        int i11;
        int i12 = i;
        byte b2 = 1;
        if (bArr[(i12 + i2) - 1] == m9132Nb(bArr, i12, i2 - 1)) {
            boolean z2 = f8922eg;
            if ((bArr[i12] == -128) | z2) {
                i12++;
            }
            byte b3 = bArr[i12 + 3];
            if (b3 != -61) {
                if (b3 != 80) {
                    if (b3 == 84) {
                        f8952le = 0;
                        MainActivity.f6857A9 = false;
                        f8783Cg.m8734K9(null, null, null, R.string.error_erased, 1, 2, 5);
                    } else {
                        if (b3 != 88) {
                            if (b3 == 90) {
                                int i13 = i12 + 4;
                                if (bArr[i13] == -128) {
                                    MainActivity.f6930Ia = 5;
                                    MainActivity.f7030Tb = null;
                                    MainActivity.m8169Ab(18, "");
                                    MainActivity.f6889E5 = true;
                                    LedBar.m8097j(2);
                                    f8960ne = 0;
                                    MainActivity.f6958Lb = "";
                                    ActivityC2266vc.f8576Hd = 8;
                                    MainActivity.f6900F7 = 8;
                                    ActivityC2266vc.f8582Nd = 0;
                                    MainActivity.f6973N8 = 0.0f;
                                    int i14 = i12 + 28;
                                    String strM9120Kb = m9120Kb(bArr, i14, 11, "");
                                    String strM9124Lb = m9124Lb(bArr, i12 + 16, 11, true, false);
                                    if (strM9124Lb.contains("5AMHW610")) {
                                        i4 = 5953040;
                                    } else if (strM9124Lb.contains("5AMHW103")) {
                                        i4 = 5951747;
                                    } else {
                                        i4 = strM9124Lb.contains("59MHW010") ? 5885968 : 0;
                                    }
                                    f8980se = i4;
                                    f8787Df = i4 == 5885968;
                                    f8792Ef = (i4 == 5951747) | (i4 == 5953040);
                                    if (strM9120Kb.equals("")) {
                                        i14 = i12 + 5;
                                        strM9120Kb = m9116Jb(bArr, i14, 11);
                                    }
                                    String strM9176Yb = m9176Yb(strM9120Kb);
                                    if (strM9176Yb.equals("")) {
                                        strM9176Yb = "NoName";
                                    }
                                    System.arraycopy(bArr, i14, f8905be, 4, strM9176Yb.length());
                                    MainActivity.m8169Ab(21, strM9124Lb);
                                    MainActivity.m8169Ab(20, strM9176Yb);
                                    String[] strArr2 = f8860Sd;
                                    strArr2[62] = strM9124Lb;
                                    strArr2[63] = "";
                                    strArr2[65] = strM9176Yb;
                                    StringBuilder sb = new StringBuilder();
                                    sb.append("At3B567JNZvi");
                                    sb.append(f8787Df ? "" : "anb");
                                    String string = sb.toString();
                                    MainActivity.f7223p7 = string;
                                    f8788Dg.f7799vd = string;
                                    MainActivity.f7242r8 = 131072;
                                    if (f8787Df) {
                                        b2 = 1;
                                        f8840Od = (byte) (f8840Od + 1);
                                    } else {
                                        b2 = 1;
                                    }
                                    byte b4 = (byte) (f8840Od + b2);
                                    f8840Od = b4;
                                    m9170Wd(b4);
                                    return;
                                }
                                if (bArr[i13] != -101) {
                                    return;
                                }
                                String strM9124Lb2 = m9124Lb(bArr, i12 + 39, 4, true, false);
                                String str2 = m9120Kb(bArr, i12 + 5, 8, "p") + m9120Kb(bArr, i12 + 17, 4, "p");
                                int i15 = strM9124Lb2.contains("5DM") ? 5522432 : strM9124Lb2.contains("7SM2") ? 7680784 : 7680256;
                                f8980se = i15;
                                f8797Ff = i15 == 5522432;
                                f8802Gf = (16773120 & i15) == 7680000;
                                ActivityC2225t.m9000Lb(i15, 2, null);
                                m9176Yb(str2);
                                int length = str2.length();
                                byte[] bArr2 = new byte[length];
                                for (int i16 = 0; i16 < length; i16++) {
                                    bArr2[i16] = (byte) str2.charAt(i16);
                                }
                                System.arraycopy(bArr2, 0, f8905be, 4, str2.length());
                                MainActivity.m8169Ab(21, strM9124Lb2);
                                MainActivity.m8169Ab(20, str2);
                                String[] strArr3 = f8860Sd;
                                strArr3[62] = strM9124Lb2;
                                strArr3[63] = "";
                                strArr3[65] = str2;
                                boolean z3 = f9014zf;
                                String str3 = f8832Mf | z3 ? "Bi" : "Sk";
                                boolean z4 = f8802Gf;
                                String str4 = "Atc568ljPUanbgvf" + ((!z4 || z3) ? "" : "QRq") + str3 + (z4 ? "VW" : "");
                                MainActivity.f7223p7 = str4;
                                f8788Dg.f7799vd = str4;
                                MainActivity.f7242r8 = 131072;
                                MainActivity.f6973N8 = f8797Ff | f9014zf ? 120.0f : 140.0f;
                                if (f8797Ff || f9014zf) {
                                    i5 = 120;
                                } else {
                                    i5 = 140;
                                }
                            } else if (b3 == 103) {
                                int i17 = i12 + 4;
                                if (bArr[i17] == 3) {
                                    m9234rd((((bArr[i12 + 5] << 8) | (bArr[i12 + 6] & 255)) + 27263) & 65535, (((bArr[i12 + 8] & 255) | (bArr[i12 + 7] << 8)) + 1443) & 65535);
                                    return;
                                }
                                if (bArr[i17] == 1) {
                                    int i18 = ((bArr[i12 + 8] << 8) | (bArr[i12 + 7] & 255)) & 65535;
                                    int i19 = ((bArr[i12 + 6] & 255) | (bArr[i12 + 5] << 8)) & 65535;
                                    m9234rd(((((byte) (i19 - (((i19 + 1) / 200) * 200))) & 255) | (((byte) (i18 / 161)) << 8)) & 65535, 26919);
                                    return;
                                }
                                LedBar.m8097j(2);
                                if (f8867Tf) {
                                    m9131Me(true);
                                    return;
                                }
                                if (f8954lg && (f8797Ff || f8802Gf)) {
                                    enumC2294y = EnumC2294y.MODE_IAW_READ;
                                } else {
                                    if (!f8857Rf) {
                                        return;
                                    }
                                    f8954lg = false;
                                    ActivityC2266vc.f8580Ld = 0;
                                    f8997wd = -1;
                                    int i20 = f8980se;
                                    if (i20 == 5953040) {
                                        byte[] bArrM9040nc = ActivityC2225t.m9040nc();
                                        f8880Wd = bArrM9040nc;
                                        if (bArrM9040nc == null) {
                                            return;
                                        } else {
                                            enumC2294y = EnumC2294y.MODE_WRITE_TESTER;
                                        }
                                    } else {
                                        if (!((16773120 & i20) == 7680000) && !(i20 == 5522432)) {
                                            m9135Ne(EnumC2294y.MODE_NULL);
                                            strM9079Tb = f8778Bg.m9079Tb(EnumC2281x.UNSUPPORTED_ECU);
                                            mainActivity = f8783Cg;
                                            str = null;
                                            strArr = null;
                                            i6 = 0;
                                            i7 = 2;
                                            i8 = 1;
                                            i9 = 8;
                                            mainActivity.m8734K9(str, strArr, strM9079Tb, i6, i7, i8, i9);
                                            return;
                                        }
                                        byte[] bArrM9041oc = ActivityC2225t.m9041oc();
                                        f8875Vd = bArrM9041oc;
                                        if (bArrM9041oc == null) {
                                            return;
                                        }
                                        enumC2294y = EnumC2294y.MODE_REQ_UPLOAD;
                                    }
                                }
                            } else if (b3 == 123) {
                                byte b5 = bArr[i12 + 4];
                                if (b5 != -104) {
                                    if (b5 != -103) {
                                        return;
                                    }
                                    enumC2294y = EnumC2294y.MODE_ERASE_MEM;
                                } else {
                                    enumC2294y = EnumC2294y.MODE_WRITE_DATE;
                                }
                            } else if (b3 == 96) {
                                m9212kc(100);
                                f9002xd = 0;
                                if (f8857Rf) {
                                    f8783Cg.m8734K9(null, null, f8778Bg.m9079Tb(EnumC2281x.END_DOWNLOAD), 0, 3, 2, 19);
                                } else if (!f8958mg) {
                                    String strM9079Tb2 = f8778Bg.m9079Tb(EnumC2281x.END_READ);
                                    MainActivity.f6969N4 = false;
                                    f8783Cg.m8734K9(null, null, strM9079Tb2, 0, 3, 2, 19);
                                    f8783Cg.m8781mb();
                                }
                                f8778Bg.m9078Rb(10400, true);
                                enumC2294y = EnumC2294y.MODE_NULL;
                            } else if (b3 != 97) {
                                if (b3 == 112) {
                                    MainActivity.f7268u9 = false;
                                    byte b6 = bArr[i12 + 4];
                                    if (b6 == 21) {
                                        MainActivity.f7277v9 = false;
                                    } else if (b6 != 32 && b6 != 126) {
                                        MainActivity.f7286w9 = true;
                                        if (bArr[i12 + 5] == 7) {
                                            f8930ge = f8925fe;
                                            f8783Cg.m8746Sa(1, false);
                                            MainActivity.m8211E9(6000);
                                        } else {
                                            f8925fe = (byte) 0;
                                            f8930ge = (byte) 0;
                                            f8783Cg.m8746Sa(4, false);
                                        }
                                    }
                                } else {
                                    if (b3 != 113) {
                                        if (b3 != 126) {
                                            if (b3 == 127) {
                                                byte b7 = bArr[i12 + 4];
                                                if (b7 == 1 || b7 == 2) {
                                                    ActivityC2266vc.f8571Cd = 0;
                                                    f8778Bg.m9079Tb(EnumC2281x.ERR_NULL);
                                                    m9212kc(1500);
                                                    ActivityC2266vc.f8590Vd = true;
                                                    ActivityC2266vc.m9072Ub(8);
                                                    return;
                                                }
                                                if (b7 == 12) {
                                                    f8990ug = true;
                                                    m9239tc();
                                                    return;
                                                }
                                                if (b7 == 33) {
                                                    f9002xd = 0;
                                                    MainActivity.m8169Ab(15, String.format("%x", Integer.valueOf(f8997wd)));
                                                    m9192dd();
                                                    LedBar.m8097j(0);
                                                    f8992vd = EnumC2294y.MODE_NULL;
                                                    int i21 = f8997wd;
                                                    if (i21 > 2) {
                                                        f8783Cg.m8786o8();
                                                        return;
                                                    }
                                                    if (i21 >= 0) {
                                                        f8997wd = i21 + 1;
                                                        ActivityC2266vc.f8579Kd = 0;
                                                        strM9079Tb = f8778Bg.m9079Tb(EnumC2281x.ERR_OFFON);
                                                        mainActivity = f8783Cg;
                                                        str = null;
                                                        strArr = null;
                                                        i6 = 0;
                                                        i7 = 40;
                                                        i8 = 2;
                                                        i9 = 11;
                                                        mainActivity.m8734K9(str, strArr, strM9079Tb, i6, i7, i8, i9);
                                                        return;
                                                    }
                                                    return;
                                                }
                                                if (b7 == 51) {
                                                    int i22 = i12 + 5;
                                                    boolean z5 = bArr[i22] == 120;
                                                    boolean z6 = f8857Rf;
                                                    if (!z5 || !z6) {
                                                        if ((bArr[i22] == 35) && z6) {
                                                            int iCurrentTimeMillis = (int) (System.currentTimeMillis() - f8825Ld);
                                                            int i23 = f8810Id;
                                                            if (iCurrentTimeMillis > i23 * 100) {
                                                                iCurrentTimeMillis = i23 * 100;
                                                            }
                                                            f8783Cg.m8793r9(iCurrentTimeMillis / 100, i23, 0L);
                                                            m9212kc(100);
                                                            if (f8992vd != EnumC2294y.MODE_ERASE_CMD) {
                                                                if (f8992vd != EnumC2294y.MODE_IAW_PROGRAM) {
                                                                    return;
                                                                }
                                                            }
                                                            m9216ld();
                                                            return;
                                                        }
                                                        if ((bArr[i22] == 33) && z6) {
                                                            if (f8992vd != EnumC2294y.MODE_ERASE_CMD) {
                                                                if (f8992vd != EnumC2294y.MODE_IAW_PROGRAM) {
                                                                    return;
                                                                }
                                                            }
                                                            m9216ld();
                                                            return;
                                                        }
                                                        if (bArr[i22] != 16) {
                                                            EnumC2294y enumC2294y2 = f8992vd;
                                                            EnumC2294y enumC2294y3 = EnumC2294y.MODE_SELF_LEARN;
                                                            if (enumC2294y2 != enumC2294y3) {
                                                                return;
                                                            }
                                                            int i24 = MainActivity.f7179k8;
                                                            MainActivity.f7179k8 = i24 - 1;
                                                            if (i24 >= 1) {
                                                                m9135Ne(enumC2294y3);
                                                                return;
                                                            }
                                                            f8992vd = EnumC2294y.MODE_READ_SENSORS;
                                                        }
                                                        m9135Ne(EnumC2294y.MODE_NULL);
                                                        String strM9079Tb3 = f8778Bg.m9079Tb(EnumC2281x.ERR_FAILED);
                                                        MainActivity.f6969N4 = false;
                                                        f8783Cg.m8734K9(null, null, strM9079Tb3, 0, 2, 2, 19);
                                                        return;
                                                    }
                                                    int iCurrentTimeMillis2 = (int) (System.currentTimeMillis() - f8825Ld);
                                                    int i25 = f8810Id;
                                                    if (iCurrentTimeMillis2 > i25 * 100) {
                                                        iCurrentTimeMillis2 = i25 * 100;
                                                    }
                                                    f8783Cg.m8793r9(iCurrentTimeMillis2 / 100, i25, 0L);
                                                    if (f8992vd != EnumC2294y.MODE_IAW_PROGRAM || !f8792Ef) {
                                                        ActivityC2266vc.f8571Cd = 0;
                                                        return;
                                                    }
                                                    m9237sd();
                                                    return;
                                                }
                                                if (b7 != 63) {
                                                    if (b7 == 48 || b7 == 49) {
                                                        if (!f8857Rf) {
                                                            if (MainActivity.f7277v9) {
                                                                MainActivity.f7277v9 = false;
                                                                f8783Cg.m8792r6(MainActivity.f7299y4.getText(R.string.no_condition).toString(), 0, Boolean.FALSE);
                                                                return;
                                                            } else if (f8992vd == EnumC2294y.MODE_SELF_LEARN) {
                                                                f8992vd = EnumC2294y.MODE_READ_SENSORS;
                                                            } else if ((bArr[i12 + 5] & 254) == 34) {
                                                                return;
                                                            }
                                                        }
                                                        m9135Ne(EnumC2294y.MODE_NULL);
                                                        String strM9079Tb4 = f8778Bg.m9079Tb(EnumC2281x.ERR_FAILED);
                                                        MainActivity.f6969N4 = false;
                                                        f8783Cg.m8734K9(null, null, strM9079Tb4, 0, 2, 2, 19);
                                                        return;
                                                    }
                                                    return;
                                                }
                                                m9108Hb(true, 0);
                                                return;
                                            }
                                            switch (b3) {
                                                case 115:
                                                    f8783Cg.m8793r9(100, 100, 0L);
                                                    int i26 = i12 + 4;
                                                    byte b8 = bArr[i26];
                                                    if (b8 == -60) {
                                                        enumC2294y = EnumC2294y.MODE_IAW_CODE;
                                                    } else if (b8 == -59 || b8 == 1) {
                                                        enumC2294y = EnumC2294y.MODE_CLOSE_SESSION;
                                                    } else if (b8 == 2) {
                                                        enumC2294y = EnumC2294y.MODE_REQ_UPLOAD;
                                                    } else if (b8 == 34 || b8 == 35) {
                                                        MainActivity.f7268u9 = false;
                                                        MainActivity.f7286w9 = true;
                                                        if (MainActivity.f7179k8 < 0) {
                                                            MainActivity.f7179k8 = 0;
                                                        }
                                                        MainActivity.m8199D9(bArr[i26] == 35 ? (MainActivity.f7179k8 + 1) * 1000 : 500);
                                                        enumC2294y = EnumC2294y.MODE_READ_SENSORS;
                                                    }
                                                    break;
                                                case 116:
                                                    if (f8792Ef) {
                                                        f8990ug = true;
                                                        f8783Cg.m8791qa(true, 3);
                                                        enumC2294y = EnumC2294y.MODE_DOWNLOAD;
                                                    } else {
                                                        enumC2294y = EnumC2294y.MODE_ERASE_MEM;
                                                    }
                                                    break;
                                                case 117:
                                                    enumC2294y = EnumC2294y.MODE_7SM_READ;
                                                    break;
                                                case 118:
                                                    if (f8867Tf) {
                                                        if (f8797Ff || f8802Gf) {
                                                            byte b9 = (byte) (bArr[i12] - 129);
                                                            System.arraycopy(bArr, i12 + 4, ActivityC2225t.f8442Cd, f8826Le + f8816Je, b9);
                                                            f8821Ke += b9;
                                                            f8826Le += b9;
                                                            ActivityC2266vc.f8574Fd = 0;
                                                            f8826Le = ActivityC2225t.m9050xc(f8816Je, f8826Le);
                                                            ActivityC2266vc.f8571Cd = 0;
                                                            if (f8958mg) {
                                                                f9002xd = 0;
                                                                m9135Ne(EnumC2294y.MODE_NULL);
                                                                f8783Cg.m8734K9(null, null, f8778Bg.m9079Tb(EnumC2281x.ERR_ABORT), 0, 3, 2, 46);
                                                                f8783Cg.m8739N5(false);
                                                            } else if (f8826Le == 0) {
                                                                m9190ce();
                                                            } else if (f8821Ke < f8831Me) {
                                                                m9238se();
                                                            } else {
                                                                m9135Ne(EnumC2294y.MODE_DOWNLOAD_EXIT);
                                                            }
                                                            f8783Cg.m8793r9(f8821Ke, f8831Me, f8825Ld);
                                                        } else {
                                                            int i27 = i12 + 4;
                                                            if (bArr[i27] == 17) {
                                                                m9212kc(250);
                                                                f8805Hd = (f8816Je + f8826Le) / 16384;
                                                            } else if (bArr[i27] == 33) {
                                                                byte[] bArr3 = f8900ae;
                                                                int i28 = i12 + 9;
                                                                if (bArr3 == null) {
                                                                    System.arraycopy(bArr, i28, ActivityC2225t.f8442Cd, f8826Le + f8816Je, f8841Oe);
                                                                } else {
                                                                    System.arraycopy(bArr, i28, bArr3, f8826Le, f8841Oe);
                                                                }
                                                                int i29 = f8821Ke;
                                                                int i30 = f8841Oe;
                                                                f8821Ke = i29 + i30;
                                                                f8826Le += i30;
                                                                ActivityC2266vc.f8574Fd = 0;
                                                                if (f8900ae == null) {
                                                                    f8826Le = ActivityC2225t.m9050xc(f8816Je, f8826Le);
                                                                    f8783Cg.m8793r9(f8821Ke, f8831Me, f8825Ld);
                                                                }
                                                                ActivityC2266vc.f8571Cd = 0;
                                                                if (f8821Ke >= f8831Me || f8958mg) {
                                                                    if (f8958mg) {
                                                                        f9002xd = 0;
                                                                        m9135Ne(EnumC2294y.MODE_NULL);
                                                                        f8783Cg.m8734K9(null, null, f8778Bg.m9079Tb(EnumC2281x.ERR_ABORT), 0, 3, 2, 10);
                                                                        f8783Cg.m8739N5(false);
                                                                    }
                                                                    enumC2294y = EnumC2294y.MODE_CLOSE_SESSION;
                                                                }
                                                            }
                                                            m9166Vd();
                                                        }
                                                    } else if (f8954lg && (f8797Ff || f8802Gf)) {
                                                        m9182ac(m9124Lb(bArr, i12 + 19, 16, true, false));
                                                    } else if (f8992vd == EnumC2294y.MODE_IAW_CODE) {
                                                        f8783Cg.m8791qa(true, 3);
                                                        enumC2294y = EnumC2294y.MODE_DOWNLOAD;
                                                    } else {
                                                        int i31 = MainActivity.f7169j7 + f8841Oe;
                                                        MainActivity.f7169j7 = i31;
                                                        if (i31 < ActivityC2225t.f8440Bd.length) {
                                                            f8783Cg.m8793r9(MainActivity.f7169j7, ActivityC2225t.f8440Bd.length, f8825Ld);
                                                            m9244ue();
                                                        } else {
                                                            enumC2294y = EnumC2294y.MODE_DOWNLOAD_EXIT;
                                                        }
                                                    }
                                                    break;
                                                case 119:
                                                    if (f8867Tf && (f8797Ff || f8802Gf)) {
                                                        enumC2294y = EnumC2294y.MODE_CLOSE_SESSION;
                                                    } else {
                                                        f8783Cg.m8793r9(100, 100, 0L);
                                                        enumC2294y = EnumC2294y.MODE_IAW_WRITE;
                                                    }
                                                    break;
                                            }
                                        }
                                        ActivityC2266vc.f8571Cd = 0;
                                        m9129Mc();
                                        return;
                                    }
                                    byte b10 = bArr[i12 + 4];
                                    if (b10 != -60) {
                                        if (b10 != -59) {
                                            if (b10 != 1) {
                                                if (b10 != 2) {
                                                    switch (b10) {
                                                        case 33:
                                                            MainActivity.f7268u9 = false;
                                                            break;
                                                        case 34:
                                                        case 35:
                                                            MainActivity.f7286w9 = true;
                                                            MainActivity.f7276v8 = 3;
                                                            MainActivity.f7179k8 = 6;
                                                            enumC2294y = EnumC2294y.MODE_SELF_LEARN;
                                                            break;
                                                    }
                                                }
                                                if (!f8857Rf) {
                                                    return;
                                                } else {
                                                    i11 = 170;
                                                }
                                            } else {
                                                if (!f8857Rf) {
                                                    return;
                                                }
                                                f8990ug = false;
                                                f8810Id = 60;
                                            }
                                        } else if (!f8857Rf) {
                                            return;
                                        } else {
                                            f8810Id = 120;
                                        }
                                        f8783Cg.m8791qa(true, 4);
                                        enumC2294y = EnumC2294y.MODE_IAW_PROGRAM;
                                    } else if (!f8857Rf) {
                                        return;
                                    } else {
                                        i11 = f8842Of ? 150 : 50;
                                    }
                                    f8810Id = i11;
                                    f8783Cg.m8791qa(true, 2);
                                    enumC2294y = EnumC2294y.MODE_ERASE_CMD;
                                }
                                MainActivity.f7286w9 = true;
                                MainActivity.m8199D9(1500);
                            } else {
                                int i32 = i12 + 4;
                                byte b11 = bArr[i32];
                                if ((b11 == -102) || (b11 == -90 && f8787Df)) {
                                    int iM9000Lb = ActivityC2225t.m9000Lb(f8980se, 2, null);
                                    if (iM9000Lb > 8000 && MainActivity.f6973N8 == 0.0f) {
                                        MainActivity.f6973N8 = iM9000Lb / 100;
                                    }
                                    MainActivity.f6910G8 = 120;
                                    MainActivity.f7051W5 = false;
                                    f8783Cg.m8778kb(40);
                                    f8783Cg.m8780m9();
                                    String[] strArr4 = f8860Sd;
                                    strArr4[64] = m9124Lb(bArr, i12 + 5, 9, true, false);
                                    String str5 = strArr4[64];
                                    MainActivity.f7030Tb = str5;
                                    if (str5.equals("")) {
                                        MainActivity.f7030Tb = "_PASS";
                                    }
                                    m9111He(MainActivity.f7116d8);
                                    f8783Cg.m8794t5();
                                    MainActivity.m8169Ab(MainActivity.f7127ea ? 28 : 29, MainActivity.f7030Tb);
                                    m9135Ne(EnumC2294y.MODE_READ_SENSORS);
                                    f8956me = 1;
                                    return;
                                }
                                if (b11 == -80) {
                                    MainActivity.f6930Ia = 5;
                                    MainActivity.m8169Ab(18, "");
                                    MainActivity.f6889E5 = true;
                                    LedBar.m8097j(2);
                                    f8960ne = 0;
                                    MainActivity.f6958Lb = "d";
                                    ActivityC2266vc.f8576Hd = 8;
                                    MainActivity.f6900F7 = 8;
                                    ActivityC2266vc.f8582Nd = 0;
                                    String[] strArr5 = f8860Sd;
                                    strArr5[64] = m9124Lb(bArr, i12 + 57, 9, true, false);
                                    MainActivity.f7030Tb = strArr5[64];
                                    f8783Cg.m8794t5();
                                    MainActivity.m8169Ab(MainActivity.f7127ea ? 28 : 29, MainActivity.f7030Tb);
                                    String strM9124Lb3 = m9124Lb(bArr, i12 + 16, 11, true, false);
                                    if (strM9124Lb3.equals("")) {
                                        strM9124Lb3 = "7SM";
                                    }
                                    int i33 = i12 + 28;
                                    String strM9120Kb2 = m9120Kb(bArr, i33, 11, "");
                                    if (!strM9120Kb2.equals("")) {
                                        if (strM9124Lb3.contains("5DMHW4")) {
                                            i10 = 5522432;
                                        } else if (strM9124Lb3.contains("7SMHW31")) {
                                            i10 = 7680784;
                                        } else {
                                            i10 = strM9124Lb3.contains("7SMHW32") ? 7680800 : 7680256;
                                        }
                                        f8980se = i10;
                                        f8797Ff = i10 == 5522432;
                                        f8802Gf = (i10 & 16773120) == 7680000;
                                        boolean zContains = strM9124Lb3.contains("7SMHW11");
                                        String str6 = strM9124Lb3.contains("7SMHW32") | zContains ? "Bi" : "Sk";
                                        boolean z7 = f8802Gf;
                                        String str7 = (!z7 || zContains) ? "" : "QRq";
                                        String str8 = z7 ? "VW" : "";
                                        ActivityC2225t.m9000Lb(f8980se, 2, null);
                                        m9176Yb(strM9120Kb2);
                                        System.arraycopy(bArr, i33, f8905be, 4, strM9120Kb2.length());
                                        MainActivity.m8169Ab(21, strM9124Lb3);
                                        MainActivity.m8169Ab(20, strM9120Kb2);
                                        strArr5[62] = strM9124Lb3;
                                        strArr5[63] = "";
                                        strArr5[65] = strM9120Kb2;
                                        String str9 = "Atc568ljPUanbgvf" + str7 + str6 + str8;
                                        MainActivity.f7223p7 = str9;
                                        f8788Dg.f7799vd = str9;
                                        MainActivity.f7242r8 = 131072;
                                        MainActivity.f6973N8 = f8797Ff | zContains ? 120.0f : 140.0f;
                                        if (f8797Ff || zContains) {
                                            i5 = 120;
                                        } else {
                                            i5 = 140;
                                        }
                                    }
                                    byte b12 = (byte) (f8840Od + b2);
                                    f8840Od = b12;
                                    m9170Wd(b12);
                                    return;
                                }
                                short[] sArr = f8873Ug;
                                if ((sArr != null) & (sArr == f8868Tg)) {
                                    int i34 = 0;
                                    while (true) {
                                        short[] sArr2 = f8873Ug;
                                        if (i34 >= sArr2.length / 2) {
                                            break;
                                        }
                                        int i35 = i34 * 2;
                                        boolean z8 = sArr2[i35] == f8798Fg;
                                        int i36 = i35 + 1;
                                        if (z8 & (sArr2[i36] < 4)) {
                                            sArr2[i36] = 3;
                                        }
                                        i34++;
                                    }
                                }
                                if (!f8957mf) {
                                    if (f8956me > 0) {
                                        m9240td();
                                        return;
                                    }
                                    if (f8952le > 0) {
                                        m9189cd();
                                        return;
                                    }
                                    if (MainActivity.f7268u9) {
                                        m9235re();
                                        return;
                                    }
                                    if (MainActivity.f7277v9) {
                                        m9195ed(MainActivity.f7155hb == null);
                                        return;
                                    }
                                    if (f8887Xf) {
                                        m9103Fe(null, 0, MainActivity.f7178k7);
                                        return;
                                    }
                                    if (f8892Yf) {
                                        m9113Ic();
                                        return;
                                    }
                                    m9217le();
                                    f8788Dg.m8890Cb(bArr, i32);
                                    if (MainActivity.f7304y9) {
                                        MainActivity.m8546jb(false);
                                    }
                                    if (MainActivity.f6866B9 && System.currentTimeMillis() > MainActivity.f6903Fa) {
                                        if (f8930ge > 0) {
                                            MainActivity.f7268u9 = true;
                                            return;
                                        }
                                        return;
                                    } else {
                                        if (!MainActivity.f7313z9 || System.currentTimeMillis() <= MainActivity.f6903Fa) {
                                            return;
                                        }
                                        f8783Cg.m8756b5(20, f8925fe);
                                        return;
                                    }
                                }
                                m9111He(MainActivity.f7116d8);
                            }
                            MainActivity.f6910G8 = i5;
                            MainActivity.f7051W5 = false;
                            f8783Cg.m8778kb(60);
                            f8783Cg.m8780m9();
                            m9111He(MainActivity.f7116d8);
                            m9135Ne(EnumC2294y.MODE_READ_SENSORS);
                            f8956me = 1;
                            return;
                        }
                        f8956me = 0;
                        short s = (short) (bArr[i12 + 4] & 255);
                        f8803Gg = s;
                        f8783Cg.m8788p8(s > 0, false);
                        if (MainActivity.f6925I5) {
                            m9091Ce(f8803Gg);
                            m9233rc(bArr, i12 + 5);
                            m9206ic();
                        }
                    }
                    m9217le();
                    return;
                }
                if (f8867Tf) {
                    if (f8797Ff || f8802Gf) {
                        f8990ug = false;
                        activityC2266vc = f8778Bg;
                        i3 = 38400;
                        z = true;
                    } else {
                        z = true;
                        if (z2) {
                            f8990ug = false;
                            activityC2266vc = f8778Bg;
                            i3 = 62500;
                        } else {
                            f8922eg = true;
                            enumC2294y = EnumC2294y.MODE_IAW_SWITCH;
                        }
                    }
                    activityC2266vc.m9078Rb(i3, z);
                } else {
                    f8778Bg.m9078Rb(38400, true);
                    enumC2294y = EnumC2294y.MODE_QUERY_PROG;
                }
                m9135Ne(enumC2294y);
            }
            f8922eg = !(f8797Ff | f8802Gf);
            enumC2294y = EnumC2294y.MODE_SEED;
            m9135Ne(enumC2294y);
        }
    }

    /* JADX INFO: renamed from: sd */
    private static void m9237sd() {
        byte[] bArr = new byte[2];
        bArr[0] = 51;
        bArr[1] = (byte) (f8792Ef ? 1 : 197);
        m9098Ed(bArr, -1, false);
    }

    /* JADX INFO: renamed from: se */
    private static void m9238se() {
        m9098Ed(new byte[]{54}, -1, true);
    }

    /* JADX INFO: renamed from: tc */
    private static void m9239tc() {
        m9098Ed(new byte[]{16, 12, 12, 9}, -1, false);
    }

    /* JADX INFO: renamed from: td */
    private static void m9240td() {
        m9098Ed(new byte[]{24, 0, -1, 0}, -1, false);
    }

    /* JADX INFO: renamed from: te */
    private static void m9241te() {
        byte[] bArr = new byte[9];
        bArr[0] = 54;
        System.arraycopy(f8875Vd, 0, bArr, 1, 8);
        m9098Ed(bArr, -1, true);
    }

    /* JADX INFO: renamed from: uc */
    public static int m9242uc(int i) {
        int i2 = 0;
        while (true) {
            int[] iArr = f8799Fh;
            if (i2 >= iArr.length / 2) {
                return 0;
            }
            int i3 = i2 * 2;
            if (iArr[i3] == i) {
                return iArr[i3 + 1];
            }
            i2++;
        }
    }

    /* JADX INFO: renamed from: ud */
    private static void m9243ud() {
        m9098Ed(new byte[]{33, -128}, -1, false);
    }

    /* JADX INFO: renamed from: ue */
    private static void m9244ue() {
        int iM8498f5;
        int i;
        int i2 = MainActivity.f7169j7;
        if (f8807Hf) {
            i = (short) ((ActivityC2225t.f8440Bd[i2 + 4] + 8) & 255);
        } else {
            if (f8827Lf) {
                int i3 = f8841Oe + i2;
                int i4 = MainActivity.f7178k7;
                iM8498f5 = i3 > i4 ? i4 - i2 : f8841Oe;
            } else {
                iM8498f5 = (int) ((MainActivity.m8498f5(ActivityC2225t.f8440Bd, i2 + 4, 2) + 6) & 255);
            }
            i = (short) iM8498f5;
        }
        byte[] bArr = new byte[i];
        System.arraycopy(ActivityC2225t.f8440Bd, i2, bArr, 0, i);
        m9098Ed(bArr, -1, true);
    }

    /* JADX INFO: renamed from: vc */
    public static byte[] m9245vc(byte[] bArr, int i) {
        String strM9116Jb;
        int i2;
        long[] jArr;
        if (i == 0) {
            int i3 = 0;
            for (int i4 = 0; i4 < 16384; i4++) {
                i3 += bArr[i4];
            }
            if ((65535 & i3) != 56306) {
                return null;
            }
            int iM8498f5 = (int) MainActivity.m8498f5(bArr, 294816, 2);
            if (iM8498f5 == 21930) {
                strM9116Jb = m9116Jb(bArr, 294806, 10);
            } else if (iM8498f5 == 43605) {
                String strM9116Jb2 = m9116Jb(bArr, 294820, 12);
                String strM9116Jb3 = m9116Jb(bArr, 294918, 8);
                String str = strM9116Jb2 + strM9116Jb3;
                strM9116Jb = ((!str.equals("v2.1LA") && !str.equals("2.1SCLA")) || bArr[294920] != 0) ? str : strM9116Jb2 + strM9116Jb3 + m9116Jb(bArr, 294921, 6);
            } else {
                strM9116Jb = "";
            }
            if (strM9116Jb.length() < 8) {
                return null;
            }
        } else if (i == 2) {
            int i5 = 131072;
            if (MainActivity.m8498f5(bArr, 131072, 4) != 131072) {
                i5 = 196608;
                if (MainActivity.m8498f5(bArr, 196608, 4) != 131072) {
                    i5 = 0;
                }
            }
            String strM9124Lb = m9124Lb(bArr, i5 + 41, 7, true, false);
            if (strM9124Lb.length() < 6) {
                return null;
            }
            strM9116Jb = strM9124Lb;
        } else {
            strM9116Jb = ((int) MainActivity.m8498f5(bArr, 524130, 2)) == 21930 ? m9116Jb(bArr, 524160, 10) : m9230qc(bArr);
            if (strM9116Jb.length() < 5) {
                return null;
            }
        }
        int i6 = 0;
        while (true) {
            String[] strArr = f8824Kh;
            if (i6 >= strArr.length) {
                i2 = -1;
                break;
            }
            if (strM9116Jb.equals(strArr[i6])) {
                i2 = f8834Mh[i6];
                break;
            }
            i6++;
        }
        int i7 = 0;
        while (true) {
            jArr = C2198r0.f8292a;
            if (i7 >= jArr.length / 8 || i2 == jArr[i7 * 8]) {
                break;
            }
            i7++;
        }
        if ((i2 < 0) || (i7 >= jArr.length / 8)) {
            return null;
        }
        return m9221nc(bArr, strM9116Jb, i7, i, 0);
    }

    /* JADX INFO: renamed from: vd */
    private static void m9246vd() {
        boolean z = f8782Cf;
        final byte[] bArr = new byte[z ? 4 : 3];
        short s = z ? f8794Eh[f8948ke] : f8789Dh[f8948ke];
        int i = 0;
        if (z) {
            bArr[0] = 4;
            i = 1;
        }
        int i2 = i + 1;
        bArr[i] = 34;
        bArr[i2] = (byte) (s >> 8);
        bArr[i2 + 1] = (byte) (s & 255);
        new Thread(new Runnable() { // from class: com.tuneecu.a
            @Override // java.lang.Runnable
            public final void run() {
                ActivityC2307z.m9105Gc(bArr);
            }
        }).start();
    }

    /* JADX INFO: renamed from: ve */
    private static void m9247ve() {
        m9098Ed(new byte[]{55}, -1, !(f8797Ff | f8802Gf));
    }

    /* JADX WARN: Code duplicated, block: B:127:0x02b8  */
    /* JADX WARN: Code duplicated, block: B:128:0x02bb  */
    /* JADX WARN: Code duplicated, block: B:199:0x0448  */
    /* JADX WARN: Code duplicated, block: B:200:0x044b  */
    /* JADX INFO: renamed from: wc */
    private static void m9248wc(byte[] bArr, int i) throws CloneNotSupportedException {
        byte b2;
        int i2;
        int i3;
        int i4;
        String str;
        String str2;
        byte b3 = bArr[i + 2];
        if (b3 == 1) {
            LedBar.m8097j(2);
            if (f8867Tf) {
                if (f8860Sd[63].equals(m9124Lb(bArr, i + 3, 17, true, false))) {
                    m9131Me(!f8882Wf);
                    return;
                }
                m9135Ne(EnumC2294y.MODE_NULL);
                String strM9079Tb = f8778Bg.m9079Tb(EnumC2281x.ERR_FAILED);
                MainActivity.f6969N4 = false;
                f8783Cg.m8734K9(null, null, strM9079Tb, 0, 2, 2, 19);
                return;
            }
            if (f8988ue == 0) {
                f8860Sd[63] = m9124Lb(bArr, i + 3, 17, true, false);
            }
            String[] strArr = f8860Sd;
            strArr[(f8988ue * 20) + 64] = m9124Lb(bArr, i + 11, 9, true, false);
            if ((f8988ue == 1) & (strArr[64] == "")) {
                strArr[64] = strArr[84];
            }
            MainActivity.f7030Tb = strArr[64];
        } else if (b3 == 2) {
            if (f8988ue == 0) {
                int i5 = ((bArr[i + 3] & 15) << 20) | ((bArr[i + 4] & 15) << 16) | ((bArr[i + 5] & 15) << 12) | ((bArr[i + 14] & 15) << 8) | ((bArr[i + 15] & 15) << 4) | ((!f8822Kf ? (bArr[i + 6] & 16) >> 4 : bArr[i + 12] - 1) & 15);
                f8980se = i5;
                f8891Ye = (i5 & 16773120) == 6369280;
                f8906bf = i5 == 7667712;
                f8969pf = i5 == 6500352;
                f8977rf = (i5 == 6488081) | (i5 == 6492177) | (i5 == 6496257);
                f8973qf = (i5 == 6496256) | (i5 == 6488096);
                f8911cf = ((i5 & 16773120) == 7954432) | ((i5 & 16773120) == 8462336);
                f8916df = (i5 & 16773120) == 7954432;
                MainActivity.m8169Ab(21, Integer.toHexString(i5));
                ActivityC2225t.m9000Lb(f8980se, 1, null);
                f8941if = f8906bf;
                f8896Ze = (f8980se & 16773120) == 7733248;
            } else {
                f8984te = ((bArr[i + 3] & 15) << 20) | ((bArr[i + 4] & 15) << 16) | ((bArr[i + 5] & 15) << 12) | ((bArr[i + 14] & 15) << 8) | ((bArr[i + 15] & 15) << 4) | ((bArr[i + 12] - 1) & 15);
            }
            f8860Sd[(f8988ue * 20) + 62] = m9124Lb(bArr, i + 3, 14, true, false);
            if (f8822Kf) {
                f8783Cg.m8794t5();
                if (MainActivity.f7127ea) {
                    i2 = 28;
                } else {
                    i2 = 29;
                }
            } else {
                MainActivity.f7030Tb = m9124Lb(bArr, i + 6, 9, true, false);
                f8783Cg.m8794t5();
                if (MainActivity.f7127ea) {
                    i2 = 28;
                } else {
                    i2 = 29;
                }
            }
            MainActivity.m8169Ab(i2, MainActivity.f7030Tb);
        } else {
            if (b3 != 5) {
                if (b3 == 8) {
                    String strM9124Lb = m9124Lb(bArr, i + 3, bArr.length - (i + 4), true, false);
                    f8953lf = false;
                    f8945jf = false;
                    f8961nf = false;
                    f8965of = false;
                    f8772Af = false;
                    f8777Bf = false;
                    f8949kf = false;
                    f8921ef = false;
                    MainActivity.f6958Lb = f8906bf | f8911cf ? "b" : "";
                    if (f8906bf) {
                        str = "M";
                    } else if (f8901af) {
                        str = "J";
                    } else if (f8896Ze) {
                        str = "N";
                    } else if (f8891Ye) {
                        str = "K";
                    } else if (f8969pf) {
                        str = "7";
                    } else if (f8973qf) {
                        str = "A";
                    } else if (f8977rf) {
                        str = "6";
                    } else {
                        str = f8911cf ? "I" : "2";
                    }
                    m9099Ee(str);
                    if (f8973qf || f8911cf) {
                        str2 = "At367JMGNXn";
                    } else if (f8901af) {
                        str2 = "At367JMGNXT";
                    } else if (f8896Ze) {
                        str2 = "A37JMGNX";
                    } else if (f8969pf || f8977rf) {
                        str2 = "At367JMGNXTn";
                    } else if (f8906bf) {
                        str2 = "At367JMpGNXn";
                    } else if (str.equals("K")) {
                        str2 = "A4268jBHPUVWr";
                    } else {
                        str2 = f8891Ye ? "A468jBHPUr" : "At48jlBHPZTn";
                    }
                    String str3 = "5ab" + str2;
                    MainActivity.f7223p7 = str3;
                    f8788Dg.f7799vd = str3;
                    MainActivity.f6973N8 = f8891Ye ? 120.0f : ActivityC2225t.m9035ic(strM9124Lb, 0, 80) / 100;
                    MainActivity.f7242r8 = 131072;
                    MainActivity.f7051W5 = false;
                    f8783Cg.m8778kb(20);
                } else {
                    if (b3 == 18) {
                        System.arraycopy(bArr, i + 3, f8988ue == 0 ? f8905be : f8910ce, 22, 2);
                        int i6 = f8988ue;
                        if (i6 == 0) {
                            String[] strArr2 = f8860Sd;
                            byte[] bArr2 = f8905be;
                            strArr2[72] = Integer.toHexString(((bArr2[23] & 255) | (bArr2[22] << 8)) & 65535);
                        } else {
                            byte[] bArr3 = f8910ce;
                            f8860Sd[(i6 * 20) + 72] = Integer.toHexString(((bArr3[23] & 255) | (bArr3[22] << 8)) & 65535);
                        }
                        MainActivity.m8169Ab(23, f8860Sd[(f8988ue * 20) + 72]);
                        f8840Od = (byte) 14;
                        m9170Wd((byte) 14);
                        return;
                    }
                    if (b3 == 32) {
                        if (((!f8852Qf) & f8941if) && (!(MainActivity.f6862B5 | MainActivity.f6871C5))) {
                            f8852Qf = true;
                            m9125Lc(1);
                            return;
                        }
                        if (f8852Qf && (f8988ue == 1)) {
                            m9125Lc(0);
                            return;
                        }
                        m9111He(MainActivity.f7116d8);
                        m9135Ne(EnumC2294y.MODE_READ_SENSORS);
                        ActivityC2266vc.f8578Jd = 0;
                        MainActivity.f6925I5 = false;
                        f8783Cg.m8776j9(16);
                        f8956me = 1;
                        return;
                    }
                    if (b3 != 49) {
                        return;
                    }
                    if (f8857Rf) {
                        int i7 = i + 3;
                        int i8 = i + 6;
                        int i9 = i + 10;
                        MainActivity.m8169Ab(22, Integer.toHexString((bArr[i7] << 32) | (bArr[i7] << 16) | (bArr[i8] << 8) | (bArr[i9] & 255)));
                        if (((bArr[i9] & 255) | (bArr[i + 4] << 16) | (bArr[i7] << 32) | (bArr[i8] << 8)) == f8814Ih[C2182pc.f8244j]) {
                            f8842Of = f8937hg | (MainActivity.m8498f5(f8988ue == 0 ? f8905be : f8910ce, 20, 4) != MainActivity.m8498f5(ActivityC2225t.f8446Ed, 20, 4));
                            m9119Je();
                            m9135Ne(EnumC2294y.MODE_SPEED_COM);
                            return;
                        } else {
                            f8857Rf = false;
                            m9135Ne(EnumC2294y.MODE_NULL);
                            f8783Cg.m8734K9(null, null, f8778Bg.m9079Tb(EnumC2281x.ERR_VERSION_MAP), 0, 2, 1, 8);
                            return;
                        }
                    }
                    b2 = 13;
                }
                f8840Od = b2;
                m9170Wd(b2);
            }
            if (f8988ue == 0) {
                MainActivity.f7037U9 = f8906bf | f8969pf | f8901af | f8977rf | f8973qf | f8911cf;
                if (!f8977rf || f8773Ag.length() <= 0) {
                    f8865Td = m9124Lb(bArr, i + 10, 5, true, false);
                    System.arraycopy(bArr, i + 3, f8905be, 4, 16);
                } else {
                    String str4 = f8773Ag;
                    f8865Td = str4;
                    StringBuilder sb = new StringBuilder(str4);
                    for (int i10 = 0; i10 < Math.min(f8773Ag.length(), 16); i10++) {
                        f8905be[i10 + 4] = (byte) String.valueOf(sb).charAt(i10);
                    }
                }
                if (!f8901af) {
                    i4 = f8896Ze ? 14680068 : 14680100;
                    f8783Cg.m8780m9();
                    MainActivity.m8169Ab(20, f8865Td);
                    byte[] bArr4 = f8905be;
                    bArr4[20] = (byte) (((bArr[i + 10] & 15) << 4) | (bArr[i + 11] & 15));
                    bArr4[21] = bArr[i + 14];
                    if (f8906bf) {
                        i3 = 100;
                    } else {
                        i3 = 120;
                    }
                    MainActivity.f6910G8 = i3;
                }
                MainActivity.f7259t8 = i4;
                f8783Cg.m8780m9();
                MainActivity.m8169Ab(20, f8865Td);
                byte[] bArr5 = f8905be;
                bArr5[20] = (byte) (((bArr[i + 10] & 15) << 4) | (bArr[i + 11] & 15));
                bArr5[21] = bArr[i + 14];
                if (f8906bf) {
                    i3 = 100;
                } else {
                    i3 = 120;
                }
                MainActivity.f6910G8 = i3;
            } else {
                int i11 = i + 10;
                f8870Ud = m9124Lb(bArr, i11, 5, true, false);
                System.arraycopy(bArr, i + 3, f8910ce, 4, 16);
                byte[] bArr6 = f8910ce;
                bArr6[20] = (byte) (((bArr[i11] & 15) << 4) | (bArr[i + 11] & 15));
                bArr6[21] = bArr[i + 14];
                MainActivity.m8169Ab(20, f8870Ud);
            }
            if (f8773Ag.length() > 0) {
                f8860Sd[65] = f8773Ag;
            } else {
                f8860Sd[(f8988ue * 20) + 65] = m9124Lb(bArr, i + 3, 16, true, false);
            }
        }
        b2 = (byte) (f8840Od + 1);
        f8840Od = b2;
        m9170Wd(b2);
    }

    /* JADX INFO: renamed from: wd */
    private static void m9249wd() {
        m9098Ed(new byte[]{26}, -1, false);
    }

    /* JADX INFO: renamed from: we */
    private static void m9250we(int i) {
        m9098Ed(new byte[]{39, (byte) (f8835Nd + 1), (byte) (i & 255), (byte) ((i >> 8) & 255), (byte) ((i >> 16) & 255), (byte) ((i >> 24) & 255)}, -1, false);
    }

    /* JADX INFO: renamed from: xc */
    private static void m9251xc(int i, int i2) throws CloneNotSupportedException {
        String str;
        String str2;
        int i3;
        String str3;
        String str4;
        String string;
        if (MainActivity.f7019S9) {
            f8865Td = String.format("%x", Integer.valueOf(i));
        } else {
            i = f8926ff ? m9242uc(i2) : 0;
            if (i == 0) {
                i = i2;
            }
        }
        int iM9172Xb = m9172Xb(i);
        String str5 = ((iM9172Xb >= 8) && (iM9172Xb <= 12)) ? "%06x" : "%x";
        int i4 = 2;
        String str6 = "";
        if (!f8926ff) {
            if ((i2 >> 16) == 5) {
                i2 -= 196608;
            }
            str = String.format(str5, Integer.valueOf(i2));
            int i5 = f8980se >> 8;
            String[] strArr = f8860Sd;
            if (strArr[63] != null && strArr[63].length() > 4) {
                MainActivity.f7218ob = ":" + String.format("%2x", Integer.valueOf(i5 & 255)) + strArr[63].substring(3, 4);
            }
            if (i5 != 2012) {
                i4 = (i5 == 8194) | (i5 == 8200) ? 1 : 0;
            }
            f8846Pe = i4;
            int i6 = f8980se;
            String str7 = (i6 == 2098945) | (i6 == 2098689) ? "" : "v";
            MainActivity.f7236qb = null;
            boolean z = i5 == 8192;
            f8921ef = z;
            boolean z2 = (i5 == 8200) | (i5 == 8198) | (i5 == 8199);
            f8949kf = z2;
            f8961nf = false;
            f8965of = false;
            f8772Af = true;
            boolean z3 = (65400 & iM9172Xb) == 64;
            f8953lf = z3;
            boolean z4 = (65320 & iM9172Xb) == 40;
            f8945jf = z4;
            boolean z5 = (i5 == 8196) | (i5 == 8193) | (i5 == 8195);
            String str8 = z3 ? "T" : "";
            String str9 = z4 ? "EY" : "";
            String str10 = z5 ? "g" : "";
            if (z) {
                str2 = "Atanb567JTSPQRUuVWXZvfLS";
            } else if (z2) {
                str2 = "AtanbF678ljDHPUuXD" + str7;
            } else {
                str2 = "AtanbF5678lS9GPQUuVXZvfLS" + str8 + str9 + str10;
            }
        } else {
            if (f8980se == 0) {
                MainActivity.f7019S9 = true;
                MainActivity.f7028T9 = true;
                if (MainActivity.f6862B5 || MainActivity.f6871C5) {
                    f8783Cg.m8805y8(false);
                    return;
                } else {
                    f8992vd = EnumC2294y.MODE_NULL;
                    m9254yc(51);
                    return;
                }
            }
            LedBar.m8097j(2);
            str = str5.equals("%06x") ? String.format(str5, Integer.valueOf(i2)) : String.format(str5, Integer.valueOf(i));
            f8953lf = false;
            f8945jf = false;
            boolean zEquals = str5.equals("%06x");
            f8961nf = zEquals;
            boolean z6 = (65534 & iM9172Xb) == 14;
            f8965of = z6;
            f8772Af = !(z6 | zEquals);
            f8777Bf = false;
            f8949kf = false;
            f8921ef = false;
            f8927fg = (iM9172Xb < 5) | (iM9172Xb == 7);
            boolean z7 = (iM9172Xb == 3) | (iM9172Xb == 4) | (iM9172Xb == 7);
            f8866Te = z7;
            f8852Qf = true;
            if (zEquals || z7) {
                StringBuilder sb = new StringBuilder();
                sb.append("W");
                sb.append(f8866Te ? "QR" : "");
                string = sb.toString();
            } else {
                string = "Q";
            }
            str2 = "Atan12345P" + string + (!f8927fg ? "vf" : "");
        }
        MainActivity.f7223p7 = str2;
        f8788Dg.f7799vd = MainActivity.f7223p7;
        MainActivity.f7242r8 = 0;
        if (f8906bf || f8911cf) {
            str6 = "b";
        } else if (f8965of) {
            str6 = "a";
        }
        MainActivity.f6958Lb = str6;
        if ((((65312 & iM9172Xb) == 32) | f8921ef) || f8866Te) {
            i3 = 140;
        } else {
            i3 = (65360 & iM9172Xb) == 64 ? 100 : 120;
        }
        MainActivity.f6910G8 = i3;
        if (f8980se > 0) {
            str3 = Integer.toHexString(f8980se >> 8) + "-" + Integer.toHexString(f8980se & 255);
        } else {
            str3 = "????";
        }
        String[] strArr2 = f8860Sd;
        strArr2[62] = str3;
        strArr2[65] = str;
        MainActivity.m8169Ab(20, str);
        if (f8961nf) {
            str4 = "4";
        } else if (f8965of) {
            str4 = "B";
        } else {
            str4 = f8926ff ? "1" : "0";
        }
        m9099Ee(str4);
        MainActivity.f7051W5 = false;
        f8783Cg.m8778kb(f8926ff ? 10 : 0);
        f8783Cg.m8780m9();
        m9111He(MainActivity.f7116d8);
        if (MainActivity.f7019S9) {
            return;
        }
        m9135Ne(EnumC2294y.MODE_READ_SENSORS);
        ActivityC2266vc.f8578Jd = 0;
        MainActivity.f6925I5 = false;
        f8956me = 1;
    }

    /* JADX INFO: renamed from: xd */
    private static void m9252xd() {
        ActivityC2266vc.m9074Xb(new byte[]{(byte) f9007yd}, 1, true, false);
    }

    /* JADX INFO: renamed from: xe */
    public static void m9253xe(int i) {
        f8855Rd = (byte) i;
        ActivityC2266vc.f8570Bd = 0;
        byte[] bArr = f8880Wd;
        byte[] bArr2 = new byte[bArr.length + 3];
        bArr2[0] = 46;
        bArr2[1] = -15;
        bArr2[2] = (byte) (i + 153);
        System.arraycopy(bArr, 0, bArr2, 3, bArr.length);
        m9098Ed(bArr2, -1, false);
    }

    /* JADX INFO: renamed from: yc */
    public static void m9254yc(int i) {
        int i2;
        String strM9079Tb;
        MainActivity mainActivity;
        String str;
        String[] strArr;
        int i3;
        int i4;
        int i5;
        if (f9002xd == -2) {
            return;
        }
        f8942ig = false;
        f8787Df = false;
        f8792Ef = false;
        f8797Ff = false;
        f8802Gf = false;
        f8827Lf = false;
        f8837Nf = false;
        f8902ag = false;
        f8907bg = false;
        f8912cg = false;
        ActivityC2266vc.f8583Od = 0;
        f8778Bg.m9078Rb(10400, true);
        LedBar.m8101n(true);
        LedBar.m8097j(0);
        int i6 = f9002xd;
        if (i6 <= 5) {
            if (i6 >= 4) {
                if ((MainActivity.f7133f7 < 16) & f8847Pf & (!(MainActivity.f6862B5 | MainActivity.f6871C5))) {
                    f8942ig = true;
                    i = 213;
                }
            }
            if (f8857Rf | f8867Tf | MainActivity.f7028T9) {
                i = 213;
            }
            int i7 = f9002xd;
            if (i7 == -1) {
                f9002xd = i7 + 1;
            }
            f9002xd++;
            if (i == 67) {
                i2 = 13;
            } else {
                i2 = i == 213 ? 9 : 8;
            }
            MainActivity.m8169Ab(i2, "");
            new Thread(new RunnableC2253v(i)).start();
            return;
        }
        f9002xd = -1;
        if (!f8857Rf) {
            if (MainActivity.f6862B5 && MainActivity.f6880D5) {
                f8783Cg.m8734K9(null, null, f8778Bg.m9079Tb(EnumC2281x.ERR_BAD_DEVICE), 0, 20, 1, 0);
                f8783Cg.m8739N5(false);
            } else if (!MainActivity.f6929I9) {
                strM9079Tb = f8778Bg.m9079Tb(EnumC2281x.ERR_NO_ECU);
                mainActivity = f8783Cg;
                str = null;
                strArr = null;
                i3 = 0;
                i4 = 3;
                i5 = 3;
            }
            ActivityC2266vc.f8581Md = 0;
        }
        strM9079Tb = f8778Bg.m9079Tb(EnumC2281x.ERR_FAILED);
        mainActivity = f8783Cg;
        str = null;
        strArr = null;
        i3 = 0;
        i4 = 2;
        i5 = 2;
        mainActivity.m8734K9(str, strArr, strM9079Tb, i3, i4, i5, 10);
        ActivityC2266vc.f8581Md = 0;
    }

    /* JADX INFO: renamed from: yd */
    private static void m9255yd() {
        int i;
        if (f8907bg) {
            i = 50;
        } else {
            i = !(f8802Gf | f8797Ff) ? 25 : 20;
        }
        m9212kc(i);
        m9098Ed(new byte[]{-127}, -1, false);
    }

    /* JADX INFO: renamed from: ye */
    private static void m9256ye() {
        boolean z = f8842Of;
        byte[] bArr = new byte[(z ? 8 : 0) + 10];
        bArr[0] = 49;
        bArr[1] = -111;
        if (z) {
            System.arraycopy(ActivityC2225t.f8444Dd, 0, bArr, 2, 16);
        } else {
            System.arraycopy(ActivityC2225t.f8448Fd, 0, bArr, 2, 8);
        }
        m9098Ed(bArr, -1, true);
    }

    /* JADX INFO: renamed from: zc */
    private static void m9257zc(byte[] bArr) {
        EnumC2294y enumC2294y;
        int i;
        int i2 = 0;
        if ((bArr.length < 5) || (f8992vd == EnumC2294y.MODE_NULL)) {
            return;
        }
        byte[] bArrM9218mc = m9218mc(bArr);
        byte b2 = bArrM9218mc[3];
        if (b2 != 80) {
            if (b2 == 98) {
                if (MainActivity.f7234q9) {
                    MainActivity.f6939Ja = MainActivity.f6930Ia;
                    f8783Cg.m8805y8(false);
                    return;
                }
                int i3 = MainActivity.f7011Ra;
                if (i3 == 4) {
                    m9110Hd();
                    return;
                }
                if (i3 > 0) {
                    m9102Fd(i3);
                    return;
                }
                if (MainActivity.f7243r9) {
                    MainActivity.f7243r9 = false;
                    return;
                }
                if (bArrM9218mc[4] != 1) {
                    return;
                }
                byte b3 = bArrM9218mc[5];
                if (b3 != 1) {
                    if (b3 == 6) {
                        f8783Cg.m8773i7(new byte[]{bArrM9218mc[6]}, 2);
                    } else if (b3 == 9) {
                        byte[] bArr2 = new byte[3];
                        for (int i4 = 0; i4 < 3; i4++) {
                            bArr2[i4] = (byte) Integer.parseInt(String.format("%02X", Byte.valueOf(bArrM9218mc[i4 + 6])));
                        }
                        f8783Cg.m8773i7(bArr2, 5);
                        f8948ke = 3;
                    } else if (b3 == 32) {
                        byte[] bArr3 = new byte[3];
                        System.arraycopy(bArrM9218mc, 6, bArr3, 0, 3);
                        f8783Cg.m8773i7(bArr3, 3);
                        f8948ke = 5;
                    } else {
                        if (b3 != 33) {
                            return;
                        }
                        byte[] bArr4 = new byte[2];
                        System.arraycopy(bArrM9218mc, 6, bArr4, 0, 2);
                        f8783Cg.m8773i7(bArr4, 0);
                    }
                    f8948ke = 2;
                } else {
                    f8783Cg.m8773i7(new byte[]{bArrM9218mc[6]}, 4);
                }
                m9246vd();
                return;
            }
            if (b2 != 103) {
                if (b2 != 110) {
                    if (b2 != 127) {
                        return;
                    }
                    byte b4 = bArrM9218mc[4];
                    if (b4 == 39) {
                        f8783Cg.m8734K9(null, null, MainActivity.f7299y4.getResources().getStringArray(R.array.eMessage)[5], 0, 12, 1, 0);
                        i = 10;
                    } else {
                        if (b4 != 46) {
                            return;
                        }
                        if (bArrM9218mc[5] == 33) {
                            MainActivity.f7011Ra = 0;
                            f8783Cg.m8756b5(0, 0);
                            i = MainActivity.f6930Ia;
                        } else {
                            if (bArrM9218mc[5] != 6) {
                                return;
                            }
                            MainActivity.f7011Ra = 0;
                        }
                    }
                    MainActivity.f6939Ja = i;
                    f8783Cg.m8805y8(false);
                    return;
                }
                if (bArrM9218mc[5] == 33) {
                    MainActivity.f7011Ra = 0;
                    f8783Cg.m8756b5(7, 0);
                    i = MainActivity.f6930Ia;
                    MainActivity.f6939Ja = i;
                    f8783Cg.m8805y8(false);
                    return;
                }
                if (bArrM9218mc[5] != 6) {
                    return;
                }
                MainActivity.f7011Ra = 0;
                m9246vd();
                return;
            }
            byte b5 = bArrM9218mc[4];
            if (b5 == 3) {
                for (int i5 = 3; i5 >= 0; i5--) {
                    i2 |= (bArrM9218mc[i5 + 5] & 255) << (i5 * 8);
                }
                m9106Gd(ActivityC2127m.m8940Db(i2));
                return;
            }
            if (b5 != 4) {
                return;
            }
            LedBar.m8097j(2);
            enumC2294y = EnumC2294y.MODE_INSTR_READ;
            f8948ke = 1;
            m9246vd();
            return;
        }
        f8835Nd = (byte) 3;
        MainActivity.f7234q9 = false;
        enumC2294y = EnumC2294y.MODE_SEED;
        m9135Ne(enumC2294y);
    }

    /* JADX INFO: renamed from: zd */
    private static void m9258zd(int i) {
        int i2 = i & 65535;
        int i3 = (i >> 16) & 65535;
        m9098Ed(new byte[]{39, 2, (byte) (i2 & 255), (byte) (i2 / 256), (byte) (i3 & 255), (byte) (i3 / 256)}, -1, false);
    }

    /* JADX INFO: renamed from: ze */
    private static void m9259ze(byte b2, int i) {
        if (i > 0) {
            m9212kc(i);
        }
        m9098Ed(new byte[]{b2}, -1, true);
    }
}
