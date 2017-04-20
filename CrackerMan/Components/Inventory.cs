using CrackerMan.Items;
using Nez;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CrackerMan.Managers;
using Microsoft.Xna.Framework.Input;

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
        Texture2D coinTexture;

        public Inventory()
        {
            items = new List<ItemStack>();
            items.Add(new ItemStack(ShopManager.HandItem));
            slot = 0;
        }

        public Inventory(List<ItemStack> items, Keys key)
        {
            this.items = items;
            items.addIfNotPresent(new ItemStack(ShopManager.HandItem));
        }

        public void NextItem()
        {
            slot++;
            if (slot >= items.Count)
                slot = 0;
        }

        public void PreviousItem()
        {
            slot--;
            if (slot < 0)
                slot = items.Count - 1;
        }

        public void UseItem()
        {
            if (!items[slot].Item.IsPasive)
                items[slot].Item.UseItem(entity as Player);
        }

        public void AddMoney(int amount)
        {
            money += amount;
            Console.WriteLine($"Added {amount} to {money}");
        }

        public override void onAddedToEntity()
        {
            var bmfont = entity.scene.content.Load<SpriteFont>("Fonts/font");
            font = new NezSpriteFont(bmfont);
            coinTexture = entity.scene.content.Load<Texture2D>("Sprites/Coin");
        }

        public void AddItem(ItemStack item)
        {
            if (item.Item.IsPasive)
            {
                item.Item.OnPickup(entity as Player);
                return;
            }
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
            graphics.batcher.drawRect(bounds, Color.Gray);
            graphics.batcher.draw(coinTexture, bounds.location);
            graphics.batcher.drawString(font, money.ToString(), bounds.location + new Vector2(16, 0), Color.White);
            var margin = new Vector2(5, 5);
            var pos = bounds.location + margin + new Vector2(0, 18);
            var i = 0;
            foreach (var item in items)
            {
                if (i == slot)
                    graphics.batcher.drawHollowRect(pos, 36, 36, Color.Red, 3);
                else
                    graphics.batcher.drawHollowRect(pos, 36, 36, Color.White, 2);
                graphics.batcher.draw(item.Item.Sprite, new RectangleF(pos, new Vector2(32, 32)));
                if (!item.Item.IsPasive)
                {
                    var size = font.measureString(item.Amount.ToString());
                    var p = new Vector2(pos.X + 36 - size.X, pos.Y + 36 - size.Y);
                    graphics.batcher.drawString(font, item.Amount.ToString(), p, Color.White);
                }
                pos.X += margin.X + 36;
                if (pos.X + 36 > bounds.x + bounds.width)
                {
                    pos.Y += margin.Y + 36;
                    pos.X = bounds.x + margin.X;
                }
                i++;
            }
        }

        public override bool isVisibleFromCamera(Camera camera) => true;

    }
}
