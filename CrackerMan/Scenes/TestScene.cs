using Nez;
using CrackerMan.Tiles;
using CrackerMan.Components;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using CrackerMan.Managers;
using System.Collections.Generic;
using CrackerMan.Items;
using Microsoft.Xna.Framework.Graphics;

namespace CrackerMan.Scenes
{
    public class TestScene: Scene
    {
        Entity game;

        public TestScene()
        {
            addRenderer(new DefaultRenderer());
        }

        public override void initialize()
        {
            Core.registerGlobalManager(new ShopManager(this));
            game = addEntity(new Entity("game"));
            game.transform.position += new Vector2(128, 0);
            bool[,] tiles = new bool[20, 20];

            for (int y = 0; y <= 20; y++)
            {
                if (y == 0 || y == 20)
                {
                    for (int x = 0; x <= 20; x++)
                    {
                        addEntity(new TestTile(x, y) {
                            parent = game.transform
                        });
                    }
                }
                else
                {
                    addEntity(new TestTile(0, y)
                    {
                        parent = game.transform
                    });
                    addEntity(new TestTile(20, y)
                    {
                        parent = game.transform
                    });
                }
            }
            for (int y = 1; y < 20; y++)
            {
                for (int x = 1; x<20; x++)
                {
                    if (Random.chance(.7f))
                    {
                        addEntity(new DamagableTile(x, y) {
                            parent = game.transform
                        });
                        tiles[x, y] = true;
                    }
                }
            }
            bool lookingForSpot = true;
            while (lookingForSpot)
            {
                var x = Random.range(1, 20);
                var y = Random.range(1, 20);
                if (!tiles[x, y])
                {
                    var player = new Player(x * 16, y * 16, 1) {
                        parent = game.transform
                    };
                    player.addComponent(new PlayerMovement(Keys.Left, Keys.Up, Keys.Right, Keys.Down, Keys.V));
                    player.addComponent(new PlayerAction(Keys.Space));
                    addEntity(player);
                    lookingForSpot = false;
                }

            }

        }
 
    }
}
