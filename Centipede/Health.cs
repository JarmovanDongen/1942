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
    class Health : SpriteGameObject
    {
        public int _posX = 10;
        public int _posY = 10;
        public Health(Vector2 startPosition) : base("Health")
        {
            this.position = startPosition;
        }
        public override void Reset()
        {
            base.Reset();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
