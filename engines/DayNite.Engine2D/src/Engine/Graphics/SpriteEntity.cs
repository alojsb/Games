using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DayNite.Engine.Core;

namespace DayNite.Engine.Graphics;

public class SpriteEntity : Entity
{
    protected readonly Texture2D Texture;
    protected readonly SpriteRenderer Renderer;

    public SpriteEntity(
        Texture2D texture,
        SpriteRenderer renderer,
        Vector2 position
    ) : base(position)
    {
        Texture = texture;
        Renderer = renderer;
    }

    public override void Draw(GameTime gameTime)
    {
        Renderer.Draw(
            Texture,
            Position,
            rotation: Rotation,
            scale: Scale
        );
    }
}
