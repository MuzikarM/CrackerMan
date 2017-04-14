using Nez.Samples.Scenes;

namespace Nez.Samples
{
	public class Game1 : Core
	{
		protected override void Initialize()
		{
			base.Initialize();

            
			Window.AllowUserResizing = true;
			scene = new TestScene();
		}
	}
}

