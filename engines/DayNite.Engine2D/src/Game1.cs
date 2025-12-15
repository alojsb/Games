using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DayNite.Engine.Core;
using DayNite.Game.Screens;


namespace src;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private Engine _engine;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _engine = new Engine(GraphicsDevice, Content);

        _engine.Screens.SetScreen(
            new TitleScreen(_engine.Input)
        );

        base.Initialize();
    }

    protected override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _engine.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        _engine.Draw(gameTime);
        base.Draw(gameTime);
    }
}
