using CrackerMan.Scenes;
using Nez;

namespace CrackerMan
{
	public class Game1 : Core
	{
		protected override void Initialize()
		{
			base.Initialize();
            debugRenderEnabled = true;
			Window.AllowUserResizing = false;
			scene = new TestScene();
		}
	}
}

