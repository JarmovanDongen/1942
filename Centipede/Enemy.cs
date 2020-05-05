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
        public bool offScreen;

        public Enemy() : base("Enemy")
        {
            Reset();
        }

        public override void Reset()
        {
            position.X = GameEnvironment.Random.Next(0, GameEnvironment.Screen.X - sprite.Width);
            position.Y = GameEnvironment.Random.Next(-2000, 0);

            velocity.X = GameEnvironment.Random.Next(-3, 3);
            velocity.Y = GameEnvironment.Random.Next(1, 6);
        }

        public override void Update(GameTime gameTime)
        {
            if ((position.X > GameEnvironment.Screen.X - sprite.Width) || (position.X < 0))
            {
                position.X -= velocity.X;
                velocity.X = -velocity.X;
                position.Y += velocity.Y;
            }
            position.Y += velocity.Y;

            if (position.Y < GameEnvironment.Screen.Y + sprite.Height)
            {
                offScreen = true;

            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
    }
}
