public class Small2
{
    public Image2 img;

    public int id;

    public int timePaint;

    public int timeUpdate;

    public Small2(Image2 img, int id)
    {
        this.img = img;
        this.id = id;
        timePaint = 0;
        timeUpdate = 0;
    }

    public void paint(mGraphics2 g, int transform, int x, int y, int anchor)
    {
        g.drawRegion(img, 0, 0, mGraphics2.getImageWidth(img), mGraphics2.getImageHeight(img), transform, x, y, anchor);
        if (GameCanvas2.gameTick % 1000 == 0)
        {
            timePaint++;
            timeUpdate = timePaint;
        }
    }

    public void paint(mGraphics2 g, int transform, int f, int x, int y, int w, int h, int anchor)
    {
        paint(g, transform, f, x, y, w, h, anchor, isClip: false);
    }

    public void paint(mGraphics2 g, int transform, int f, int x, int y, int w, int h, int anchor, bool isClip)
    {
        if (mGraphics2.getImageWidth(img) != 1)
        {
            g.drawRegion(img, 0, f * w, w, h, transform, x, y, anchor, isClip);
            if (GameCanvas2.gameTick % 1000 == 0)
            {
                timePaint++;
                timeUpdate = timePaint;
            }
        }
    }

    public void update()
    {
        //timeUpdate++;
        //if (timeUpdate - timePaint > 1 && !Char.myCharz().isCharBodyImageID(id))
        //{
        //	SmallImage.imgNew[id] = null;
        //}
    }
}