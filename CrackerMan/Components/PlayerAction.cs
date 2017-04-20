using System;
using Microsoft.Xna.Framework.Input;
using Nez;
using Microsoft.Xna.Framework;

namespace CrackerMan.Components
{
    public class PlayerAction: Component, IUpdatable
    {

        Keys key;
        Inventory inventory;

        public PlayerAction(Keys actionKey)
        {
            key = actionKey;
        }

        public override void onAddedToEntity()
        {
            inventory = this.getComponent<Inventory>();
        }

        private void DoAction()
        {
            inventory.UseItem();
        }

        public void update()
        {
            if (Input.isKeyPressed(key))
                DoAction();
        }
    }
}
