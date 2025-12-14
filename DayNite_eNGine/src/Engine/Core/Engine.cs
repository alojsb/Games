using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DayNite.Engine.Input;
using DayNite.Engine.Screens;

namespace DayNite.Engine.Core;

public class Engine
{
    private readonly GraphicsDevice _graphicsDevice;
    private readonly SpriteBatch _spriteBatch;
    private readonly InputManager _input;
    public InputManager Input => _input;
    private readonly ScreenManager _screenManager;
    public ScreenManager Screens => _screenManager;

    public Engine(GraphicsDevice graphicsDevice)
    {
        _graphicsDevice = graphicsDevice;
        _spriteBatch = new SpriteBatch(graphicsDevice);
        _input = new InputManager();
        _screenManager = new ScreenManager();
    }

    public void Update(GameTime gameTime)
    {
        _input.Update();

        if (_input.IsPressed(GameAction.Pause))
        {
            System.Diagnostics.Debug.WriteLine("Pause pressed");
        }
        _screenManager.Update(gameTime);
    }

    public void Draw(GameTime gameTime)
    {
        _graphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin();
        _screenManager.Draw(_spriteBatch);
        _spriteBatch.End();
    }
}
