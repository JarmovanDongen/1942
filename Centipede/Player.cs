using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (inputHelper.IsKeyDown(Keys.W))
            {
                position.Y = position.Y - 5;
            }
            if (inputHelper.IsKeyDown(Keys.S))
            {
                position.Y = position.Y + 5;
            }
            if (inputHelper.IsKeyDown(Keys.A))
            {
                position.X = position.X - 5;
            }
            if (inputHelper.IsKeyDown(Keys.D))
            {
                position.X = position.X + 5;
            }
        }
    }
}
