using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DayNite.Engine.Screens;
using DayNite.Engine.Input;
using System.Diagnostics;

namespace DayNite.Game.Screens;

public class TitleScreen : IScreen
{
    private readonly InputManager _input;

    public TitleScreen(InputManager input)
    {
        _input = input;
    }

    public void Update(GameTime gameTime)
    {
        if (_input.IsPressed(GameAction.Confirm))
        {
            Debug.WriteLine("Start game!");
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // Later: draw logo, menu, etc.
    }
}
