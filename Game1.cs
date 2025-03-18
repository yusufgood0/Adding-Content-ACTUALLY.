using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Adding_Content
{
    public class Game1 : Game
    {
        Texture2D mario;
        Texture2D background;
        Texture2D moon;
        Texture2D megaman;
        int megamanFrame = 0;
        Rectangle megaman_rectangle = new Rectangle(40, 30, 100, 100);
        Vector2 megamanPosition = new Vector2(100, 700);
        float moonAngle = 0f;
        float seconds;
        SpriteFont titleFont;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 660; // Sets the width of the window
            _graphics.PreferredBackBufferHeight = 880; // Sets the height of the window
            _graphics.ApplyChanges(); // Applies the new dimensions
            seconds = 0f;
            titleFont = Content.Load<SpriteFont>("titleFont");
            this.Window.Title = "Adding Things";
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            mario = Content.Load<Texture2D>("mario");
            background = Content.Load<Texture2D>("background");
            moon = Content.Load<Texture2D>("moon");
            megaman = Content.Load<Texture2D>("megaman");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            seconds += gameTime.ElapsedGameTime.Milliseconds;
            if (seconds > 500)
            {
                megamanPosition.X += 40;
                if (megamanPosition.X > _graphics.PreferredBackBufferWidth)
                {
                    megamanPosition.X -= _graphics.PreferredBackBufferWidth + megaman_rectangle.Width;
                }
                megaman_rectangle.X += 120;
                if (megaman_rectangle.X > 500)
                {
                    megaman_rectangle.X = 40;
                }
                seconds = 0;
            }
            moonAngle += gameTime.ElapsedGameTime.Milliseconds;

            

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin();
            _spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(mario, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(megaman, megamanPosition, megaman_rectangle, Color.White);
            _spriteBatch.Draw(moon, new Vector2(100, 100), null, Color.White, moonAngle/100000, new Vector2(moon.Width / 2, moon.Height / 2), 1.0f, SpriteEffects.None, 0f);
            _spriteBatch.DrawString(titleFont, megamanFrame.ToString(), new Vector2(10, 10), Color.White);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
