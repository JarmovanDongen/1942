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
        public int SPEED = 5;
        public Player() : base("Player")
        {
            position.X = GameEnvironment.Screen.X / 2;
            position.Y = GameEnvironment.Screen.Y / 2;
        }

        public override void Reset()
        {

            base.Reset();
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (inputHelper.IsKeyDown(Keys.W))
            {
                if(position.Y + sprite.Height > sprite.Height) 
                { 
                position.Y = position.Y - SPEED;
                }
            }
            if (inputHelper.IsKeyDown(Keys.S))
            {
                if(position.Y < GameEnvironment.Screen.Y - sprite.Height)
                { 
                position.Y = position.Y + SPEED;
                }
            }
            if (inputHelper.IsKeyDown(Keys.A))
            {
                if (position.X + sprite.Width > sprite.Width)
                {
                position.X = position.X - SPEED;
                }
            }
            if (inputHelper.IsKeyDown(Keys.D))
            {
                if (position.X  < GameEnvironment.Screen.X - sprite.Width)
                {
                    position.X = position.X + SPEED;
                }
            }
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
