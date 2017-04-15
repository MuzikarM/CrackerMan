using CrackerMan.Components;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace CrackerMan
{
    public class Player: Entity
    {

        public Player(int x, int y, int id): base($"Player{id}")
        {
            this.transform.setPosition(x,y);
        }

        public override void onAddedToScene()
        {
            addComponent(new BoxCollider(12, 12));
            addComponent(new Sprite(scene.content.Load<Texture2D>("Sprites/PlayerOne")));
            addComponent(new Health(12));
        }

    }
}
