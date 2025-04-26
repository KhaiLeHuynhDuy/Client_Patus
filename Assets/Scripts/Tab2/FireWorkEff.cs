public class FireWorkEff2
{
    private static int w;

    private static int h;

    private static MyRandom2 r = new MyRandom2();

    private static MyVector2 mg = new MyVector2();

    private static int x;

    private static int y;

    private static int ag;

    private static int x0;

    private static int y0;

    private static int t;

    private static int v;

    private static float a;

    private static int[] mang_x = new int[3];

    private static int[] mang_y = new int[3];

    private static bool st = false;

    private static long last = 0L;

    private static long delay = 150L;

    public static void preDraw()
    {
        if (st)
        {
            animate();
        }
        if (t > 32 && st)
        {
            st = false;
            mg.removeAllElements();
            mg.addElement(new FireWorkMn2(Res2.random(50, GameCanvas2.w - 50), Res2.random(GameCanvas2.h - 100, GameCanvas2.h), 5, 72));
        }
    }

    public static void paint(mGraphics2 g)
    {
        preDraw();
        g.setColor(0);
        g.fillRect(0, 0, w, h);
        g.setColor(16711680);
        for (int i = 0; i < mg.size(); i++)
        {
            ((FireWorkMn2)mg.elementAt(i)).paint(g);
        }
        if (!st)
        {
            keyPressed(-(Math2.abs(r.nextInt() % 3) + 5));
        }
    }

    public static void keyPressed(int k)
    {
        if (k == -5 && !st)
        {
            x0 = w / 2;
            ag = 80;
            st = true;
            add();
        }
        else if (k == -7 && !st)
        {
            ag = 60;
            x0 = 0;
            st = true;
            add();
        }
        else if (k == -6 && !st)
        {
            ag = 120;
            x0 = w;
            st = true;
            add();
        }
    }

    public static void add()
    {
        y0 = 0;
        v = 16;
        t = 0;
        a = 0f;
        for (int i = 0; i < 3; i++)
        {
            mang_y[i] = 0;
            mang_x[i] = x0;
        }
        st = true;
    }

    public static void animate()
    {
        mang_y[2] = mang_y[1];
        mang_x[2] = mang_x[1];
        mang_y[1] = mang_y[0];
        mang_x[1] = mang_x[0];
        mang_y[0] = y;
        mang_x[0] = x;
        x = Res2.cos((int)((double)ag * System.Math.PI / 180.0)) * v * t + x0;
        y = (int)((float)(v * Res2.sin((int)((double)ag * System.Math.PI / 180.0)) * t) - a * (float)t * (float)t / 2f) + y0;
        if (time() - last >= delay)
        {
            t++;
            last = time();
        }
    }

    public static long time()
    {
        return mSystem2.currentTimeMillis();
    }
}
