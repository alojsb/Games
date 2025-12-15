using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DayNite.Engine.Graphics;

public sealed class SpriteRenderer
{
    private readonly SpriteBatch _spriteBatch;

    public SpriteRenderer(SpriteBatch spriteBatch)
    {
        _spriteBatch = spriteBatch;
    }

    public void BeginWorld(Camera2D camera)
    {
        _spriteBatch.Begin(
            transformMatrix: camera.ViewMatrix,
            samplerState: SamplerState.PointClamp
        );
    }

    public void End()
    {
        _spriteBatch.End();
    }

    public void Draw(
        Texture2D texture,
        Vector2 position,
        Rectangle? sourceRect = null,
        Color? color = null,
        float rotation = 0f,
        Vector2? origin = null,
        Vector2? scale = null,
        SpriteEffects effects = SpriteEffects.None,
        float layerDepth = 0f)
    {
        _spriteBatch.Draw(
            texture,
            position,
            sourceRect,
            color ?? Color.White,
            rotation,
            origin ?? Vector2.Zero,
            scale ?? Vector2.One,
            effects,
            layerDepth
        );
    }
}
