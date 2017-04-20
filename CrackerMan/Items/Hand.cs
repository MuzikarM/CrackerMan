using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using CrackerMan.Components;
using Microsoft.Xna.Framework.Content;

namespace CrackerMan.Items
{
    public class Hand : Item
    {
        public Hand(ContentManager manager) : base("hand", 0, 0.3f, manager.Load<Texture2D>("Sprites/Items/Hand"), false)
        {
        }

        public override void UseItem(Player player)
        {
            var transform = player.transform;
            var block = Physics.linecast(transform.position, transform.position + DirectionHelper.GetVector(player.Direction) * 16);
            var health = block.collider?.getComponent<Health>();
            health?.Damage(1);
        }
    }
}
