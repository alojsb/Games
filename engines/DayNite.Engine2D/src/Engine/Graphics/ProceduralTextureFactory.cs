using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DayNite.Engine.Graphics;

public static class ProceduralTextureFactory
{
    public static Texture2D CreateSolid(GraphicsDevice gd, int w, int h, Color color)
    {
        var tex = new Texture2D(gd, w, h);
        var data = new Color[w * h];
        for (int i = 0; i < data.Length; i++) data[i] = color;
        tex.SetData(data);
        return tex;
    }
}
