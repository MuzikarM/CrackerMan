using Nez;

namespace CrackerMan.Tiles
{
    public abstract class Tile: Entity
    {
        const int TileSize = 16;


        public Tile(int x, int y): base($"tile{x}_{y}")
        {
            transform.setPosition(x * TileSize + TileSize/2f, y * TileSize + TileSize/2f);
        }

        public override void onAddedToScene()
        {
            addComponent(new BoxCollider(TileSize, TileSize));
            AddComponents();
        }

        public abstract void AddComponents();
    }
}
