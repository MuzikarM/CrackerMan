using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Nez.Sprites;
using Microsoft.Xna.Framework.Graphics;

namespace CrackerMan.Tiles
{
    public class TestTile: Tile
    {
        public TestTile(int x, int y) : base(x, y)
        {

        }

        public override void AddComponents()
        {
            addComponent(new Sprite(scene.content.Load<Texture2D>("Sprites/Tiles/TestTile")));
        }
    }
}
