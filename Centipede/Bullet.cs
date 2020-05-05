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
    
    class Bullet : SpriteGameObject
    {
        public const int BulletSpeed = 3;
        public bool isFired;
        public bool offScreen;
        public Bullet(Vector2 startPosition) : base("Bullet") {
        
            Position = startPosition;
            Reset();
        }
        public override void Reset()
        {
            velocity.Y = BulletSpeed;
        }



        public override void Update(GameTime gameTime)
        {
            Console.WriteLine(velocity.Y + " " + position.Y);
            if (isFired)
            {
                position.Y -= velocity.Y;
            }

            if(position.Y < 0)
            {
                offScreen = true;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
            if (isFired)
            {
                base.Draw(gameTime, spriteBatch);
            }
        }

        
    }
    }

