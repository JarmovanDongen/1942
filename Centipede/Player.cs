using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Centipede
{
    class Player : RotatingSpriteGameObject
    {

        public Player() : base("Player")
        {

        }

        public override void Reset()
        {

            base.Reset();
            position.X = GameEnvironment.Screen.X;
            position.Y = GameEnvironment.Screen.Y;
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
