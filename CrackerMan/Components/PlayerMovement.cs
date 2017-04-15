using System;
using Microsoft.Xna.Framework.Input;
using Nez;
using Microsoft.Xna.Framework;

namespace CrackerMan.Components
{
    public class PlayerMovement: Component, IUpdatable
    {

        Keys left, up, right, down;
        Collider collider;

        public PlayerMovement(Keys left, Keys up, Keys right, Keys down)
        {
            this.left = left;
            this.right = right;
            this.up = up;
            this.down = down;
        }

        public override void onAddedToEntity()
        {
            collider = this.getComponent<Collider>();
        }

        public void update()
        {
            if (collider == null)
                return;
            var speed = new Vector2(0, 0);
            if (Input.isKeyDown(left))
                speed.X -= 1;
            if (Input.isKeyDown(right))
                speed.X += 1;
            if (Input.isKeyDown(up))
                speed.Y -= 1;
            if (Input.isKeyDown(down))
                speed.Y += 1;
            collider.collidesWithAny(ref speed, out var result);
            transform.position += speed;

        }
    }
}
