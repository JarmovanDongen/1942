using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;



namespace Centipede
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Centipede : GameEnvironment
    {
        Song song;
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            screen = new Point(470, 550);
            ApplyResolutionSettings();

            GameStateManager.AddGameState("Start", new StartScreen());
            GameStateManager.AddGameState("PlayingState", new PlayingState());
            GameStateManager.AddGameState("GameOver", new GameOverScreen());

            GameStateManager.SwitchTo("Start");

            this.song = Content.Load<Song>("BestSongEver");
            MediaPlayer.Volume = 0.20f;
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
            // TODO: use this.Content to load your game content here
        }
        
    }
}
