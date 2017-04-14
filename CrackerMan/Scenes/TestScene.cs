using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nez.Samples.Scenes
{
    public class TestScene: Scene
    {
        public TestScene()
        {
            addRenderer(new DefaultRenderer());
        }
    }
}
