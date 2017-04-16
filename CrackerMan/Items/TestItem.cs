using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Microsoft.Xna.Framework.Content;

namespace CrackerMan.Items
{

    public class TestItem : Item
    {
        public TestItem(ContentManager manager) : base("testItem", 20, .5f, manager.Load<Texture2D>("Sprites/Items/Test"))
        {
        }

        public override void UseItem(Player player)
        {
            Console.WriteLine($"{player} used the TestItem");
        }
    }
}
