using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DayNite.Engine.Graphics;

public class DebugTextRenderer
{
    private readonly BitmapFont _font;
    private readonly float _scale;

    public DebugTextRenderer(BitmapFont font, float scale = 1f)
    {
        _font = font;
        _scale = scale;
    }

    public void Draw(
        SpriteBatch spriteBatch,
        string text,
        Vector2 position,
        Color color)
    {
        _font.DrawString(spriteBatch, text, position, color, _scale);
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

