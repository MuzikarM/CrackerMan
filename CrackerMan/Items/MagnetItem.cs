using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using CrackerMan.Components;

namespace CrackerMan.Items
{
    public class MagnetItem : Item
    {
        public MagnetItem(ContentManager manager) : base("magnet", 50, -1, manager.Load<Texture2D>("Sprites/Items/Magnet"), true)
        {

        }

        public override void OnPickup(Player player)
        {
            player.addComponent(new MagnetComponent());
        }


    }
}
