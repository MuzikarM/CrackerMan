using System;
using Microsoft.Xna.Framework.Input;
using Nez;
using Microsoft.Xna.Framework;

namespace CrackerMan.Components
{
    public class PlayerAction: Component, IUpdatable
    {

        Keys key;

        public PlayerAction(Keys actionKey)
        {
            key = actionKey;
        }

        private void DoAction()
        {
            var block = Physics.linecast(transform.position, transform.position + DirectionHelper.GetVector((entity as Player).Direction) * 16);
            var health = block.collider?.getComponent<Health>();
            health?.Damage(1);
        }

        public void update()
        {
            if (Input.isKeyPressed(key))
                DoAction();
        }
    }
}
