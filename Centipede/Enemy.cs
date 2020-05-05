using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Centipede
{
    class Enemy : RotatingSpriteGameObject
    {
        public Enemy() : base("Enemy")
        {

        }

        public override void Reset()
        {
            position.X = GameEnvironment.Random.Next(0, Width);
            position.Y = GameEnvironment.Random.Next(0 - 1000);

            velocity.X = GameEnvironment.Random.Next(-3, 3);
            velocity.Y = GameEnvironment.Random.Next(1, 3);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if ((position.X > GameEnvironment.Screen.X - sprite.Width) || (position.X < 0))
            {
                position.X -= velocity.X;
                velocity.X = -velocity.X;
                position.Y += velocity.Y;
            }
        }
    }
}
