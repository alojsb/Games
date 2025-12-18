using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DayNite.Engine.Graphics;

public class DebugGridRenderer
{
    private readonly Texture2D _pixel;
    private readonly int _cellSize;
    private readonly Color _color;

    public DebugGridRenderer(GraphicsDevice device, int cellSize, Color color)
    {
        _cellSize = cellSize;
        _color = color;

        _pixel = new Texture2D(device, 1, 1);
        _pixel.SetData(new[] { Color.White });
    }

    public void Draw(SpriteBatch spriteBatch, Camera2D camera, int radius = 20)
    {
        Vector2 camPos = camera.Position;

        int startX = ((int)camPos.X / _cellSize - radius) * _cellSize;
        int endX   = ((int)camPos.X / _cellSize + radius) * _cellSize;

        int startY = ((int)camPos.Y / _cellSize - radius) * _cellSize;
        int endY   = ((int)camPos.Y / _cellSize + radius) * _cellSize;

        for (int x = startX; x <= endX; x += _cellSize)
        {
            spriteBatch.Draw(_pixel, new Rectangle(x, startY, 1, endY - startY), _color);
        }

        for (int y = startY; y <= endY; y += _cellSize)
        {
            spriteBatch.Draw(_pixel, new Rectangle(startX, y, endX - startX, 1), _color);
        }
    }
}
