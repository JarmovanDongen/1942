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

        public const int _AmountOfEnemies = 20;
       // public List<Enemy> Enemies = new List<Enemy>();
        Player thePlayer;

        GameObjectList Bullets = new GameObjectList();
        GameObjectList Enemies = new GameObjectList();
        
        public PlayingState()
        {
            this.Add(new SpriteGameObject("Background"));

            thePlayer = new Player();
            this.Add(thePlayer);

            for (int i = 0; i < _AmountOfEnemies; i++)
            {
                Enemies.Add(new Enemy());
            }
            
            
        }   
        public override void Reset()
        {
            base.Reset();

            foreach (Bullet bullets in Bullets.Children)
            {
                bullets.Reset();
            }
            foreach (Enemy Enemies in Enemies.Children)
            {
                Enemies.Reset();
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

                if (bullets.offScreen)
                {
                    bulletRemove.Add(bullets);
                }
            }
            List<Enemy> enemyRemove = new List<Enemy>();

            foreach (Enemy Enemies in Enemies.Children)
            {
                Enemies.Update(gameTime);

                foreach (Bullet BulletHit in Bullets.Children)
                {
                    if (BulletHit.CollidesWith(Enemies))
                    {
                        bulletRemove.Add(BulletHit);
                        enemyRemove.Add(Enemies);
                    }
                }
            }
            foreach (Enemy enemy in enemyRemove)
            {
                Enemies.Remove(enemy);
            }
            foreach (Bullet bullets in bulletRemove)
            {
                Bullets.Remove(bullets);
            }

            for (int i = Enemies.Children.Count; i < _AmountOfEnemies; i++)
            {
                Enemies.Add(new Enemy());
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            

            foreach (Bullet bullets in Bullets.Children)
            {
                bullets.Draw(gameTime, spriteBatch);
            }

            foreach (Enemy Enemies in Enemies.Children)
            {
                Enemies.Draw(gameTime, spriteBatch);
            }
        }


    }
}
