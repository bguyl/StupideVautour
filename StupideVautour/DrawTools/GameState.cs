using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StupideVautour.DrawTools
{
    public abstract class GameState
    {
        public SpriteBatch _spriteBatch;
        public GraphicsDeviceManager _graphics;
        public GameState nextGameState;
        public ContentManager _content;

        public abstract void Initialize();
        public abstract void LoadContent(ContentManager content, SpriteBatch spriteBatch);
        public abstract void UnloadContent();
        public abstract void Update(GameTime gameTime, KeyboardState keyboardState, KeyboardState oldKeyboardState);
        public abstract void Draw(GameTime gameTime);
    }
}
 