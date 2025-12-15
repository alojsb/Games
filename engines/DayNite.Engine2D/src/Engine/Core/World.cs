using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace DayNite.Engine.Core;

public class World
{
    private readonly List<Entity> _entities = new();

    public void Add(Entity entity) => _entities.Add(entity);

    public void Update(GameTime gameTime)
    {
        foreach (var entity in _entities)
            entity.Update(gameTime);
    }

    public void Draw(GameTime gameTime)
    {
        foreach (var entity in _entities)
            entity.Draw(gameTime);
    }
}
