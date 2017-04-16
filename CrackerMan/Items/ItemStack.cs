using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackerMan.Items
{
    public class ItemStack
    {
        Item item;
        int amount;

        public int Amount { get => amount; set => amount = value; }
        public Item Item { get => item; set => item = value; }

        public ItemStack(Item item, int amount = 1)
        {
            this.item = item;
            this.amount = amount;
        }


    }
}
