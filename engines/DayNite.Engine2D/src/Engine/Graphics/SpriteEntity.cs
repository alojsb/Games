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
        Vector2 origin = new Vector2(
            Texture.Width / 2f,
            Texture.Height / 2f
        );

        Renderer.Draw(
            Texture,
            Position,
            rotation: Rotation,
            scale: Scale,
            origin: origin
        );
    }
}
