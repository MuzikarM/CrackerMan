using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackerMan.Components
{
    public class PlayerPickup: Component, IUpdatable
    {

        Collider collider;
        Inventory inventory;

        public override void onAddedToEntity()
        {
            collider = this.getComponent<Collider>();
            inventory = this.getComponent<Inventory>();
        }



        public void update()
        {
            if (collider == null || inventory == null)
                return;
            var colliders = Physics.boxcastBroadphaseExcludingSelf(collider);
            var coins = colliders.Select((c) => c.entity as Coin);
            foreach(var coin in coins)
            {
                if (coin == null)
                    continue;
                inventory.AddMoney(coin.Amount);
                coin.destroy();
            }
        }
    }
}
