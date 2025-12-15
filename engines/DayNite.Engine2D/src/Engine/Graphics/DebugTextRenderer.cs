using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DayNite.Engine.Graphics;

public class DebugTextRenderer
{
    private readonly BitmapFont _font;

    public DebugTextRenderer(BitmapFont font)
    {
        _font = font;
    }

    public void Draw(
        SpriteBatch spriteBatch,
        string text,
        Vector2 position,
        Color color)
    {
        _font.DrawString(spriteBatch, text, position, color);
    }

    public void Draw(SpriteBatch spriteBatch, string text, int x, int y)
    {
        Draw(spriteBatch, text, new Vector2(x, y), Color.White);
    }

    public void Draw(SpriteBatch spriteBatch, string text, Vector2 position)
    {
        Draw(spriteBatch, text, position, Color.White);
    }
}

