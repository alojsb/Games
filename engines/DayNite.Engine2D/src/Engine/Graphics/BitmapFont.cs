using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace DayNite.Engine.Graphics;

public class BitmapFont
{
    private readonly Texture2D _texture;
    private readonly int _cellSize;
    private readonly int _baselineOffset;
    private readonly Dictionary<char, Point> _glyphMap;

    public BitmapFont(Texture2D texture, int cellSize, int baselineOffset)
    {
        _texture = texture;
        _cellSize = cellSize;
        _baselineOffset = baselineOffset;

        _glyphMap = new Dictionary<char, Point>();
        BuildGlyphMap();
    }

    private void BuildGlyphMap()
    {
        string[] rows =
        {

            "▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒",
            "▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒",
            "!\"#$%&'()*+,-./0",
            "123456789:;<=>?@",
            "ABCDEFGHIJKLMNOP",
            "QRSTUVWXYZ[\\]^_ ",
            "`abcdefghijklmno",
            "pqrstuvwxyz{|}~■"
        };

        for (int row = 0; row < rows.Length; row++)
        {
            for (int col = 0; col < rows[row].Length; col++)
            {
                char c = rows[row][col];
                _glyphMap[c] = new Point(col, row);
            }
        }
    }

public void DrawString(SpriteBatch spriteBatch, string text, Vector2 position, Color color)
    {
        Vector2 cursor = position;

        foreach (char c in text)
        {
            if (c == '\n')
            {
                cursor.X = position.X;
                cursor.Y += _cellSize;
                continue;
            }

            if (c == ' ')
            {
                cursor.X += _cellSize;
                continue;
            }

            if (!_glyphMap.TryGetValue(c, out Point gridPos))
            {
                cursor.X += _cellSize;
                continue;
            }

            Rectangle source = new Rectangle(
                gridPos.X * _cellSize,
                gridPos.Y * _cellSize,
                _cellSize,
                _cellSize
            );

            spriteBatch.Draw(
                _texture,
                new Vector2(cursor.X, cursor.Y - _baselineOffset),
                source,
                color
            );

            cursor.X += _cellSize;
        }
    }
}
