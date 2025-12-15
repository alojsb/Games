using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DayNite.Engine.Graphics;
using DayNite.Engine.Input;

public class Player : SpriteEntity
{
    private readonly InputManager _input;
    private readonly float _speed = 120f;

    public Player(
        Texture2D texture,
        SpriteRenderer renderer,
        InputManager input,
        Vector2 startPosition
    ) : base(texture, renderer, startPosition)
    {
        _input = input;
    }

    public override void Update(GameTime gameTime)
    {
        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
        Vector2 move = Vector2.Zero;

        if (_input.IsDown(GameAction.MoveUp)) move.Y -= 1;
        if (_input.IsDown(GameAction.MoveDown)) move.Y += 1;
        if (_input.IsDown(GameAction.MoveLeft)) move.X -= 1;
        if (_input.IsDown(GameAction.MoveRight)) move.X += 1;

        if (move != Vector2.Zero)
        {
            move.Normalize();
            Position += move * _speed * dt;
        }
    }
}
