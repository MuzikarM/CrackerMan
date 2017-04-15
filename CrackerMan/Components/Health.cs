using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Nez.Sprites;
using Microsoft.Xna.Framework;

namespace CrackerMan.Components
{
    public class Health: Component
    {

        private int maxHealth;
        private int health;

        private Sprite sprite;

        public Health(int maxHealth = 10)
        {
            health = maxHealth;
            this.maxHealth = maxHealth;
        }

        public override void onAddedToEntity()
        {
            base.onAddedToEntity();
            sprite = this.getComponent<Sprite>();
        }

        public void Damage(int damage = 1)
        {
            health -= damage;
            if (sprite == null)
            {
                sprite = this.getComponent<Sprite>();
                if (sprite == null)
                    return;
                sprite.tweenColorTo(Color.Red).setNextTween(sprite.tweenColorTo(Color.White));
            }
        }

        public override void debugRender(Graphics graphics)
        {
            if (maxHealth == health)
                return;
            var pos = transform.position - new Vector2(8, 16);
            graphics.batcher.drawRect(pos, 16, 5, Color.Red);
            graphics.batcher.drawRect(pos, health / maxHealth * 16, 5, Color.Green);
        }


    }
}
