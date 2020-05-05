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
    class PlayingState : GameObjectList
    {
       // public List<Enemy> Enemies = new List<Enemy>();
        Player thePlayer;
        Bullet theBullet;

        GameObjectList Bullets = new GameObjectList();
        
        public PlayingState()
        {
            this.Add(new SpriteGameObject("Background"));

            thePlayer = new Player();
            
            theBullet = new Bullet(thePlayer.Position);
            this.Add(thePlayer);
            this.Add(theBullet);

            
        }   
        public override void Reset()
        {
            base.Reset();

            foreach (Bullet bullets in Bullets.Children)
            {
                bullets.Reset();
            }
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Space))
            {
                Bullet bulletObject = new Bullet(thePlayer.Position);
                bulletObject.isFired = true;
                Bullets.Add(bulletObject);
            }

        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            List<Bullet> bulletRemove = new List<Bullet>();
            foreach (Bullet bullets in Bullets.Children)
            {
                bullets.Update(gameTime);
                if (!theBullet.isFired)
                {
                    theBullet.Position = thePlayer.Position;
                }

                if (bullets.offScreen)
                {
                    bulletRemove.Add(bullets);
                }
            }
            foreach (Bullet bullets in bulletRemove)
            {
                Bullets.Remove(bullets);
            }

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            

            foreach (Bullet bullets in Bullets.Children)
            {
                bullets.Draw(gameTime, spriteBatch);
            }
        }


    }
}
