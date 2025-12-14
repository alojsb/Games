using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DayNite.Engine.Input;


namespace DayNite.Engine.Core;

public class Engine
{
    private readonly GraphicsDevice _graphicsDevice;
    private readonly SpriteBatch _spriteBatch;
    private readonly InputManager _input;

    public Engine(GraphicsDevice graphicsDevice)
    {
        _graphicsDevice = graphicsDevice;
        _spriteBatch = new SpriteBatch(graphicsDevice);
        _input = new InputManager();
    }

    public void Update(GameTime gameTime)
    {
        _input.Update();

        if (_input.IsPressed(GameAction.Pause))
        {
            System.Diagnostics.Debug.WriteLine("Pause pressed");
        }
    }

    public void Draw(GameTime gameTime)
    {
        _graphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin();
        // Engine rendering will live here
        _spriteBatch.End();
    }
}
