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
    private readonly SpriteRenderer _renderer;
    public SpriteRenderer Renderer => _renderer;
    private readonly World _world;



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
        _debugText = new DebugTextRenderer(bitmapFont, scale: 0.375f);
        _camera = new Camera2D(graphicsDevice.Viewport);
        _renderer = new SpriteRenderer(_spriteBatch);
        _world = new World();

        // temporary player creation
        var playerTexture = ProceduralTextureFactory.CreateSolid(
            graphicsDevice,
            32,
            32,
            Color.CornflowerBlue
        );

        var player = new Player(
            playerTexture,
            _renderer,
            _input,
            new Vector2(100, 100)
        );

        _world.Add(player);

    }

    public void Update(GameTime gameTime)
    {
        _input.Update();

        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

        float panSpeed = 300f;
        float zoomSpeed = 1.5f;

        Vector2 pan = Vector2.Zero;

        if (_input.IsDown(GameAction.MoveUp)) pan.Y -= 1f;
        if (_input.IsDown(GameAction.MoveDown)) pan.Y += 1f;
        if (_input.IsDown(GameAction.MoveLeft)) pan.X -= 1f;
        if (_input.IsDown(GameAction.MoveRight)) pan.X += 1f;

        if (pan != Vector2.Zero)
        {
            pan.Normalize();
            _camera.Position += pan * panSpeed * dt / _camera.Zoom;
        }

        // Zoom
        if (_input.IsDown(GameAction.ZoomIn))
            _camera.Zoom *= 1f + zoomSpeed * dt;

        if (_input.IsDown(GameAction.ZoomOut))
            _camera.Zoom *= 1f - zoomSpeed * dt;

        _camera.Zoom = MathHelper.Clamp(_camera.Zoom, 0.25f, 6f);

        // Reset
        if (_input.IsPressed(GameAction.CameraReset))
        {
            _camera.Position = Vector2.Zero;
            _camera.Zoom = 1f;
            _camera.Rotation = 0f;
        }

        if (_input.IsDown(GameAction.MoveLeft))
        {
            System.Diagnostics.Debug.WriteLine("LEFT is held");
        }

        _world.Update(gameTime);

    }

    public void Draw(GameTime gameTime)
    {
        _graphicsDevice.Clear(Color.Black);


        // World pass (camera)
        _renderer.BeginWorld(_camera);
        _world.Draw(gameTime);
        _renderer.End();


        // UI/Debug pass (no camera)
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        _debugText.Draw(_spriteBatch, "DayNite Engine running", new Vector2(10, 10));
        _debugText.Draw(
            _spriteBatch,
            $"CamPos: {_camera.Position} Zoom: {_camera.Zoom:0.00}",
            new Vector2(10, 40),
            Color.White
        );
        
        _screenManager.Draw(_spriteBatch);
        _spriteBatch.End();
    }
}
