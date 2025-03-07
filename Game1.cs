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
        Rectangle sourceRectangle = new Rectangle(50, 50, 150, 150);


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
            _spriteBatch.Draw(megaman, new Vector2(0, 0), sourceRectangle, Color.White);
            _spriteBatch.Draw(moon, new Vector2(0, 0), Color.White);

            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
