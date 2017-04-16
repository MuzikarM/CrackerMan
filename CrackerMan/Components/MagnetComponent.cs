﻿using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackerMan.Components
{
    public class MagnetComponent: Component, IUpdatable
    {

        Collider collider;
        const float bounds = 16f * 3f;

        public override void onAddedToEntity()
        {
            collider = this.getComponent<Collider>();
        }

        public void update()
        {
            if (collider == null)
                return;
            var colliders = Physics.boxcastBroadphaseExcludingSelf(collider, bounds, bounds);
            var coins = colliders.Select((col) => col.entity as Coin);
            foreach (var coin in coins)
            {
                if (coin == null)
                    continue;
                var mov = entity.transform.position - coin.transform.position;
                mov /= 10;
                coin.position += mov;
            }
        }
    }
}
