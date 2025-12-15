using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DayNite.Engine.Graphics;

public class Camera2D
{
    public Vector2 Position { get; set; } = Vector2.Zero;
    public float Rotation { get; set; } = 0f;
    public float Zoom { get; set; } = 1f;

    private readonly Viewport _viewport;

    public Camera2D(Viewport viewport)
    {
        _viewport = viewport;
    }

    public Matrix ViewMatrix =>
        Matrix.CreateTranslation(new Vector3(-Position, 0f)) *
        Matrix.CreateRotationZ(Rotation) *
        Matrix.CreateScale(Zoom, Zoom, 1f) *
        Matrix.CreateTranslation(
            _viewport.Width * 0.5f,
            _viewport.Height * 0.5f,
            0f
        );

    public Vector2 ScreenToWorld(Vector2 screenPosition)
    {
        Matrix inverse = Matrix.Invert(ViewMatrix);
        return Vector2.Transform(screenPosition, inverse);
    }

    public Vector2 WorldToScreen(Vector2 worldPosition)
    {
        return Vector2.Transform(worldPosition, ViewMatrix);
    }
}
