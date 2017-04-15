using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackerMan.Components
{
    public enum Direction
    {
        LEFT,
        UP,
        RIGHT,
        DOWN,
    }

    public static class DirectionHelper
    {
        public static Vector2 GetVector(Direction dir)
        {
            switch (dir)
            {
                case Direction.DOWN:
                    return new Vector2(0, -1);
                case Direction.UP:
                    return new Vector2(0, 1);
                case Direction.LEFT:
                    return new Vector2(-1, 0);
                case Direction.RIGHT:
                    return new Vector2(1, 0);
                default:
                    throw new NotSupportedException();
            }
        }

        public static float GetRotation(Direction dir)
        {
            switch (dir)
            {
                case Direction.DOWN:
                    return 90f;
                case Direction.UP:
                    return 270f;
                case Direction.LEFT:
                    return 180f;
                case Direction.RIGHT:
                    return 0;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
