using Microsoft.Xna.Framework;

namespace DayNite.Engine.Core;

public abstract class Entity
{
    public Vector2 Position { get; set; }
    public float Rotation { get; set; } = 0f;
    public Vector2 Scale { get; set; } = Vector2.One;
    public FacingDirection Facing { get; protected set; } = FacingDirection.Down;


    protected Entity(Vector2 position)
    {
        Position = position;
    }

    public virtual void Update(GameTime gameTime) { }
    public virtual void Draw(GameTime gameTime) { }
}
