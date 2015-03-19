using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StupideVautour.DrawTools;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace StupideVautour
{
    public class MainMenuState : GameState
    {
        public static MainMenuState instance;

        private MainMenuState(GraphicsDeviceManager graphics)
        {
            _graphics = graphics;
            nextGameState = instance = this;
        }

        public static GameState getInstance(GraphicsDeviceManager graphics)
        {
            if (instance == null)
                instance = new MainMenuState(graphics);
            instance.nextGameState = instance;
            return instance;
        }

        public override void Initialize()
        {
        }

        public override void LoadContent(ContentManager content, SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            _content = content;
        }


        public override void UnloadContent()
        {
            instance = null;
        }

        public override void Update(GameTime gameTime, KeyboardState keyboardState, KeyboardState oldKeyboardState)
        {

        }
        public override void Draw(GameTime gameTime)
        {

        }

    }
}
