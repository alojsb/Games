using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace DayNite.Engine.Input;

public class InputManager
{
    private KeyboardState _current;
    private KeyboardState _previous;

    private readonly Dictionary<GameAction, Keys> _bindings = new()
    {
        { GameAction.MoveUp, Keys.W },
        { GameAction.MoveDown, Keys.S },
        { GameAction.MoveLeft, Keys.A },
        { GameAction.MoveRight, Keys.D },
        { GameAction.Confirm, Keys.Enter },
        { GameAction.Cancel, Keys.Escape },
        { GameAction.Pause, Keys.Space },
        { GameAction.ZoomIn, Keys.E },
        { GameAction.ZoomOut, Keys.Q },
        { GameAction.CameraReset, Keys.R }

    };

    public void Update()
    {
        _previous = _current;
        _current = Keyboard.GetState();
    }

    public bool IsDown(GameAction action)
        => _current.IsKeyDown(_bindings[action]);

    public bool IsPressed(GameAction action)
        => _current.IsKeyDown(_bindings[action]) &&
           !_previous.IsKeyDown(_bindings[action]);

    public bool IsReleased(GameAction action)
        => !_current.IsKeyDown(_bindings[action]) &&
            _previous.IsKeyDown(_bindings[action]);
}
