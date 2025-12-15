using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DayNite.Engine.Screens;

public interface IScreen
{
    void Update(GameTime gameTime);
    void Draw(SpriteBatch spriteBatch);
}
