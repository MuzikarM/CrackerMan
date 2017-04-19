using CrackerMan.Items;
using Nez;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrackerMan.Components
{
    public class Inventory: RenderableComponent
    {

        List<ItemStack> items;
        int slot;
        const int Width = 128;
        const int Height = 256;
        NezSpriteFont font;
        public override RectangleF bounds => GetRectangleFromId(entity.name[entity.name.Length-1]);
        int money;

        public Inventory()
        {
            items = new List<ItemStack>();
            slot = 0;
        }

        public Inventory(List<ItemStack> items)
        {
            this.items = items;
        }

        public void addMoney(int amount)
        {
            money += amount;
            Console.WriteLine($"Added {amount} to {money}");
        }

        public override void onAddedToEntity()
        {
            var bmfont = entity.scene.content.Load<SpriteFont>("Fonts/font");
            font = new NezSpriteFont(bmfont);
        }

        public void AddItem(ItemStack item)
        {
            if (!items.addIfNotPresent(item))
            {
                var stack = items.Find((it) => item.Item == it.Item);
                stack.Amount += item.Amount;
            }
            item.Item.OnPickup(entity as Player);
        }

        public void RemoveItem(Item item)
        {
            var stack = items.FindIndex((it) => it.Item == item);
            items.RemoveAt(stack);
        }

        public void UseItem()
        {
            //TODO
        }

        public void TakeItem(Item item)
        {
            var stack = items.Find((it) => it.Item == item);
            stack.Amount--;
        }

        private RectangleF GetRectangleFromId(char id)
        {
            switch (id)
            {
                case ('1'):
                    return new RectangleF(0, 0, Width, Height);
                case ('2'):
                    return new RectangleF(0, Height, Width, Height);
            }
            return new RectangleF(0, 0, Width, Height);
        }

        public override void render(Graphics graphics, Camera camera)
        {
            var id = entity.name[entity.name.Length - 1];
            RectangleF rect = GetRectangleFromId(id);
            graphics.batcher.drawRect(rect, Color.Gray);
            var margin = new Vector2(5, 5);
            var pos = bounds.location + margin;
            foreach(var item in items)
            {
                graphics.batcher.drawHollowRect(pos, 36, 36, Color.White, 2);
                graphics.batcher.draw(item.Item.Sprite, new RectangleF(pos, new Vector2(32, 32)));
                var size = font.measureString(item.Amount.ToString());
                var p = new Vector2(pos.X + 36 - size.X, pos.Y + 36 - size.Y);
                graphics.batcher.drawString(font, item.Amount.ToString(), p, Color.White);
            }
        }

        public override bool isVisibleFromCamera(Camera camera) => true;
    }
}
