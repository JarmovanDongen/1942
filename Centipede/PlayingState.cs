using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centipede
{
    class PlayingState : GameObjectList
    {
        public PlayingState()
        {
            this.Add(new SpriteGameObject("Background"));
        }
    }
}
