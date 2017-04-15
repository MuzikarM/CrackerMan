﻿using System;
using Microsoft.Xna.Framework.Input;
using Nez;
using Microsoft.Xna.Framework;
using Nez.Sprites;

namespace CrackerMan.Components
{
    public class PlayerMovement: Component, IUpdatable
    {

        Keys left, up, right, down;
        Collider collider;
        Direction direction;
        Sprite sprite;

        public PlayerMovement(Keys left, Keys up, Keys right, Keys down)
        {
            this.left = left;
            this.right = right;
            this.up = up;
            this.down = down;
            direction = Direction.RIGHT;
        }

        public override void onAddedToEntity()
        {
            collider = this.getComponent<Collider>();
            sprite = this.getComponent<Sprite>();
        }

        private void UpdateSpriteRotation()
        {
            if (sprite == null)
                return;
            sprite.transform.setRotationDegrees(DirectionHelper.GetRotation(direction));
        }

        public void update()
        {
            if (collider == null)
                return;
            var speed = new Vector2(0, 0);
            var prevDir = direction;
            if (Input.isKeyDown(left))
            {
                speed.X -= 1;
                direction = Direction.LEFT;
            }
            if (Input.isKeyDown(right))
            {
                speed.X += 1;
                direction = Direction.RIGHT;
            }
            if (Input.isKeyDown(up))
            {
                speed.Y -= 1;
                direction = Direction.UP;
            }
            if (Input.isKeyDown(down))
            {
                speed.Y += 1;
                direction = Direction.DOWN;
            }
            if (prevDir != direction)
                UpdateSpriteRotation();
            collider.collidesWithAny(ref speed, out var result);
            transform.position += speed;

        }
    }
}
