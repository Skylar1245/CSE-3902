using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Scripts;

namespace Sprint0
{
    public class Main : Game
    {
        //Default
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        //Sprites
        private AnimatedSprite animatedSprite;
        private StaticSprite staticSprite;
        private MobileAnimatedSprite mobileAnimatedSprite;
        private MobileStaticSprite mobileStaticSprite;
        //Text
        private Text screenText;
        //Controllers
        private KeyboardActions keyboardActions;
        private MouseActions mouseActions;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 900;
            graphics.PreferredBackBufferWidth = 1600;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            //Keys
            keyboardActions = new KeyboardActions();
            keyboardActions.mappings.Add(Keys.D0, Exit);
            //TODO: Make this more coherent
            keyboardActions.mappings.Add(Keys.D1, () => { staticSprite.IsVisible = !staticSprite.IsVisible; });
            keyboardActions.mappings.Add(Keys.D2, () => { animatedSprite.IsVisible = !animatedSprite.IsVisible; });
            keyboardActions.mappings.Add(Keys.D3, () => { mobileStaticSprite.IsVisible = !mobileStaticSprite.IsVisible; });
            keyboardActions.mappings.Add(Keys.D4, () => { mobileAnimatedSprite.IsVisible = !mobileAnimatedSprite.IsVisible; });
            //Mouse
            mouseActions = new MouseActions();
            mouseActions.mappings.Add("RightClick", Exit);
            mouseActions.mappings.Add("Quad1", () => { staticSprite.IsVisible = !staticSprite.IsVisible; });
            mouseActions.mappings.Add("Quad2", () => { animatedSprite.IsVisible = !animatedSprite.IsVisible; });
            mouseActions.mappings.Add("Quad3", () => { mobileStaticSprite.IsVisible = !mobileStaticSprite.IsVisible; });
            mouseActions.mappings.Add("Quad4", () => { mobileAnimatedSprite.IsVisible = !mobileAnimatedSprite.IsVisible; });
            //Default
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //Font
            SpriteFont label = Content.Load<SpriteFont>("Label");
            screenText = new Text(label, "Credits\nProgram made by: Skylar Stephens\nSprites from: https://arks.itch.io/dino-characters");
            //Sprites
            //Animated, No movement
            Texture2D vita = Content.Load<Texture2D>("Sprites/Sheets/Vita");
            animatedSprite = new AnimatedSprite(vita, new Vector2(700, 400), 1, 24);
            //No animation, No movement
            Texture2D mort = Content.Load<Texture2D>("Sprites/Singles/Idle Mort");
            staticSprite = new StaticSprite(mort, new Vector2(800, 400));
            //Animated, moves
            Texture2D doux = Content.Load<Texture2D>("Sprites/Sheets/Doux");
            mobileAnimatedSprite = new MobileAnimatedSprite(doux, new Vector2(750, 400), 1, 24);
            //No animation, moves
            Texture2D tart = Content.Load<Texture2D>("Sprites/Singles/Idle Tart");
            mobileStaticSprite = new MobileStaticSprite(tart, new Vector2(750, 800));
        }

        protected override void Update(GameTime gameTime)
        {
            animatedSprite.Update(gameTime);
            mobileAnimatedSprite.Update(gameTime);
            mobileStaticSprite.Update(gameTime);
            //Checks if the window is in focus, stops input when game not on screen
            if (IsActive)
            {
                keyboardActions.Update(gameTime);
                mouseActions.Update(gameTime);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            //Font
            screenText.Draw(spriteBatch, new Vector2(400, 700));
            //Sprites
            staticSprite.Draw(spriteBatch);
            animatedSprite.Draw(spriteBatch);
            mobileAnimatedSprite.Draw(spriteBatch);
            mobileStaticSprite.Draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}
