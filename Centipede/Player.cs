using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Centipede
{
    class Player : RotatingSpriteGameObject
    {
       
        public Player() : base("Player")
        {
            position.X = GameEnvironment.Screen.X / 2;
            position.Y = GameEnvironment.Screen.Y / 2;
        }

        public override void Reset()
        {

            base.Reset();
<<<<<<< HEAD

=======
>>>>>>> parent of 38f7d0d... Movement Added
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

    }
}
