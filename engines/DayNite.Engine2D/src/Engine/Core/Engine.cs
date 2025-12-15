using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DayNite.Engine.Input;
using DayNite.Engine.Screens;
using DayNite.Engine.Graphics;
using Microsoft.Xna.Framework.Content;


namespace DayNite.Engine.Core;

public class Engine
{
    private readonly GraphicsDevice _graphicsDevice;
    private readonly SpriteBatch _spriteBatch;
    private readonly InputManager _input;
    public InputManager Input => _input;
    private readonly ScreenManager _screenManager;
    public ScreenManager Screens => _screenManager;
    private DebugTextRenderer _debugText;
    private readonly Camera2D _camera;
    public Camera2D Camera => _camera;


    public Engine(GraphicsDevice graphicsDevice, ContentManager content)
    {
        _graphicsDevice = graphicsDevice;
        _spriteBatch = new SpriteBatch(graphicsDevice);

        _input = new InputManager();
        _screenManager = new ScreenManager();

        var fontTexture = content.Load<Texture2D>("Fonts/font");
        var bitmapFont = new BitmapFont(
            texture: fontTexture,
            cellSize: 32,
            baselineOffset: 4 // tweak between 3–6 if needed
        );
        _debugText = new DebugTextRenderer(bitmapFont);
        _camera = new Camera2D(graphicsDevice.Viewport);

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

        _spriteBatch.Begin(
            transformMatrix: _camera.ViewMatrix,
            samplerState: SamplerState.PointClamp
        );
        _debugText.Draw(_spriteBatch, "DayNite Engine running", new Vector2(10, 10));
        _screenManager.Draw(_spriteBatch);
        _spriteBatch.End();
    }
}
