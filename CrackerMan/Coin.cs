using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackerMan
{
    public class Coin: Entity
    {

        private static int id = 0;

        int amount;

        public Coin(Vector2 pos, int amount = 5): base($"coin_{id}")
        {
            id++;
            transform.setLocalPosition(pos);
            this.amount = amount;
        }

        public int Amount { get => amount; }

        public override void onAddedToScene()
        {
            addComponent(new Sprite(scene.content.Load<Texture2D>("Sprites/Coin")));
            addComponent(new BoxCollider(12, 12) {
                isTrigger = true
            });
        }

    }
}
