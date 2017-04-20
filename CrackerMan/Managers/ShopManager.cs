using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using CrackerMan.Items;
using Microsoft.Xna.Framework.Content;

namespace CrackerMan.Managers
{
    public class ShopManager : IUpdatableManager
    {

        List<Item> items;

        public List<Item> Items { get => items; }

        public static Item TestItem;
        public static Item MagnetItem;
        public static Item HandItem;

        public ShopManager(Scene scene)
        {
            items = new List<Item>();
            RegisterItems(scene.content);
        }

        public void RegisterItem(Item item) => items.addIfNotPresent(item);

        private void RegisterItems(ContentManager content)
        {
            TestItem = new TestItem(content);
            MagnetItem = new MagnetItem(content);
            HandItem = new Hand(content);
            RegisterItem(TestItem);
            RegisterItem(MagnetItem);
            RegisterItem(HandItem);
        }


        public void update()
        {

        }
    }
}
