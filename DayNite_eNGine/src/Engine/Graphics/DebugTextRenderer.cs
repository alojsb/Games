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

    public void Draw(SpriteBatch spriteBatch, string text, int x, int y)
    {
        _font.DrawString(
            spriteBatch,
            text,
            new Vector2(x, y),
            Color.White
        );
    }
}
