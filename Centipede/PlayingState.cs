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
        public int _space = 50;
        public int _healtPoints = 3;
        public bool _healthRemove = false;
        public bool _hit = false;
        public int _scoreUp = 10;
        public int _frameCounter = 0;
        public const int _hpDown = 1;
        public const int _amountOfEnemies = 20;
       
        Player thePlayer;
        Score score;
        GameObjectList Bullets = new GameObjectList();
        GameObjectList Enemies = new GameObjectList();
        GameObjectList Health = new GameObjectList();
        GameObjectList KillList = new GameObjectList();

        public PlayingState()
        {
            this.Add(new SpriteGameObject("Background"));
           
            score = new Score();
            thePlayer = new Player();
            
            this.Add(thePlayer);
            this.Add(score);
            this.Add(Health);

            for (int i = 0; i < _healtPoints; i++)
            {
                Health.Add(new Health(new Vector2(150-(i*_space),10)));
                
            }
            for (int i = 0; i < _amountOfEnemies; i++)
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
                        score.getScore = score.getScore + _scoreUp;
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

            for (int i = Enemies.Children.Count; i < _amountOfEnemies; i++)
            {
                Enemies.Add(new Enemy());
            }

            if(_hit == true) 
            { 
            _frameCounter++;
            }
            foreach (Enemy EnemyHit in Enemies.Children)
            {
                if (EnemyHit.CollidesWith(thePlayer))
                {
                    if(_hit == false)
                    {
                        foreach (Health health in Health.Children)
                        {
                            if (_healthRemove == false)
                            {
                                KillList.Add(health);
                                _healthRemove = true;
                            }
                        }
                        _healthRemove = false;
                        _hit = true;
                    
                    thePlayer.HEALTH = thePlayer.HEALTH - _hpDown;
                   }
                }
            }
            if (_frameCounter >= 60)
            {
                _hit = false;
                _frameCounter = 0;
            }
            foreach (Health health in Health.Children)
            {

            }

            foreach (var aObject in KillList.Children)
            {
                Health.Remove(aObject);
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
