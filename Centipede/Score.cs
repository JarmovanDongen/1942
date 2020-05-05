using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centipede
{
    class Score : TextGameObject
    {
        
        public int score;
        public const int _posY = 25;
        public Score() : base("Score")
        {
            position.X = GameEnvironment.Screen.X / 2;
            position.Y = _posY;
        }

        public override void Reset()
        {
            base.Reset();
            score = 0;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            this.Text = score.ToString();
        }

        public int getScore
        {
            get { return score; }
            set { score = value; }
        }
    }
}
