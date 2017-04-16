using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackerMan.Items
{
    public abstract class Item
    {

        public const int MaxAmount = 16;

        string name;
        int price;
        float cooldown;
        bool isPasive;
        Texture2D sprite;

        public int Price { get => price; }
        public string Name { get => name; }
        public float Cooldown { get => cooldown; }
        public Texture2D Sprite { get => sprite; }
        public bool IsPasive { get => isPasive; }

        public Item(string name, int price, float cooldown, Texture2D sprite, bool pasive = true)
        {
            this.name = name;
            this.cooldown = cooldown;
            this.price = price;
            this.sprite = sprite;
            this.isPasive = pasive;
        }

        public virtual void UseItem(Player player) { }

        public virtual void OnPickup(Player player) { }


    }
}
