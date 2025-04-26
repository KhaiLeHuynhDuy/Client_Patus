public class MotherCanvas2
{
    public static MotherCanvas2 instance;

    public GameCanvas2 tCanvas;

    public int zoomLevel = 1;

    public Image2 imgCache;

    private int[] imgRGBCache;

    private int newWidth;

    private int newHeight;

    private int[] output;

    public MotherCanvas2()
    {
        checkZoomLevel(getWidth(), getHeight());
    }

    public void checkZoomLevel(int w, int h)
    {
        if (Main2.isWindowsPhone)
        {
            mGraphics2.zoomLevel = 2;
            if (w * h >= 2073600)
            {
                mGraphics2.zoomLevel = 4;
            }
            else if (w * h > 384000)
            {
                mGraphics2.zoomLevel = 3;
            }
        }
        else if (Main2.isIPhone)
        {
            if (Main2.isIpod)
            {
                mGraphics2.zoomLevel = 2;
            }
            else if (w * h >= 2073600)
            {
                mGraphics2.zoomLevel = 4;
            }
            else if (w * h >= 691200)
            {
                mGraphics2.zoomLevel = 3;
            }
            else if (w * h > 153600)
            {
                mGraphics2.zoomLevel = 2;
            }
        }
        else
        {
            mGraphics2.zoomLevel = 2;
            if (w * h < 480000)
            {
                mGraphics2.zoomLevel = 1;
            }
        }
    }

    public int getWidth()
    {
        return (int)ScaleGUI2.WIDTH;
    }

    public int getHeight()
    {
        return (int)ScaleGUI2.HEIGHT;
    }

    public void setChildCanvas(GameCanvas2 tCanvas)
    {
        this.tCanvas = tCanvas;
    }

    protected void paint(mGraphics2 g)
    {
        tCanvas.paint(g);
    }

    protected void keyPressed(int keyCode)
    {
        tCanvas.keyPressedz(keyCode);
    }

    protected void keyReleased(int keyCode)
    {
        tCanvas.keyReleasedz(keyCode);
    }

    protected void pointerDragged(int x, int y)
    {
        x /= mGraphics2.zoomLevel;
        y /= mGraphics2.zoomLevel;
        tCanvas.pointerDragged(x, y);
    }

    protected void pointerPressed(int x, int y)
    {
        x /= mGraphics2.zoomLevel;
        y /= mGraphics2.zoomLevel;
        tCanvas.pointerPressed(x, y);
    }

    protected void pointerReleased(int x, int y)
    {
        x /= mGraphics2.zoomLevel;
        y /= mGraphics2.zoomLevel;
        tCanvas.pointerReleased(x, y);
    }

    public int getWidthz()
    {
        int width = getWidth();
        return width / mGraphics2.zoomLevel + width % mGraphics2.zoomLevel;
    }

    public int getHeightz()
    {
        int height = getHeight();
        return height / mGraphics2.zoomLevel + height % mGraphics2.zoomLevel;
    }
}
