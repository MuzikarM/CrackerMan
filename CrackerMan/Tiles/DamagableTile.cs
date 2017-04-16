using CrackerMan.Components;
using CrackerMan.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace CrackerMan.Tiles
{
    public class DamagableTile : Tile
    {


        public DamagableTile(int x, int y) : base(x, y)
        {
        }

        public override void AddComponents()
        {
            addComponent(new Sprite(scene.content.Load<Texture2D>("Sprites/Tiles/TestTile")));
            addComponent(new Health(Random.range(2, 10)));
        }

        public override void onRemovedFromScene()
        {
            scene.addEntity(new Coin(transform.position + new Vector2(128, 0), Random.range(1, 10)));
            base.onRemovedFromScene();

        }
    }
}
