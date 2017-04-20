using CrackerMan.Components;
using CrackerMan.Items;
using CrackerMan.Managers;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using System;
using System.Collections.Generic;

namespace CrackerMan
{
    public class Player: Entity
    {

        PlayerMovement move;

        public Player(int x, int y, int id): base($"Player{id}")
        {
            this.transform.setPosition(x,y);
        }

        public override void onAddedToScene()
        {
            addComponent(new BoxCollider(12, 12));
            addComponent(new Sprite(scene.content.Load<Texture2D>("Sprites/PlayerOne")));
            addComponent(new Health(12));
            var inv = new Inventory();
            inv.AddItem(new ItemStack(ShopManager.TestItem, 12));
            addComponent(inv);
            inv.AddItem(new ItemStack(ShopManager.MagnetItem));
            inv.addComponent(new PlayerPickup());

        }

        public Components.Direction Direction
        {
            get
            {
                if (move == null)
                    move = this.getComponent<PlayerMovement>();
                return move.Direction;
            }
        }
    }
}
