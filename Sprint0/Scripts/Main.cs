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
        //Sprites from atlas
        private AnimatedSprite animatedVita;
        private StaticSprite staticMort;
        private MobileAnimatedSprite mobileAnimatedDoux;
        private MobileStaticSprite mobileStaticTart;
        //Sprites from big file
        private StaticSprite staticOctorok;
        private MobileStaticSprite mobileStaticOctorok;
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
            keyboardActions.Add(Keys.D1, () => { staticMort.IsVisible = !staticMort.IsVisible; });
            keyboardActions.Add(Keys.D2, () => { animatedVita.IsVisible = !animatedVita.IsVisible; });
            keyboardActions.Add(Keys.D3, () => { mobileStaticTart.IsVisible = !mobileStaticTart.IsVisible; });
            keyboardActions.Add(Keys.D4, () => { mobileAnimatedDoux.IsVisible = !mobileAnimatedDoux.IsVisible; });
            //Mouse
            mouseActions = new MouseActions();
            mouseActions.Add(MouseActions.MouseButtons.Right, Exit);
            mouseActions.Add(MouseActions.MousePositions.Quad1, () => { staticMort.IsVisible = !staticMort.IsVisible; });
            mouseActions.Add(MouseActions.MousePositions.Quad2, () => { animatedVita.IsVisible = !animatedVita.IsVisible; });
            mouseActions.Add(MouseActions.MousePositions.Quad3, () => { mobileStaticTart.IsVisible = !mobileStaticTart.IsVisible; });
            mouseActions.Add(MouseActions.MousePositions.Quad4, () => { mobileAnimatedDoux.IsVisible = !mobileAnimatedDoux.IsVisible; });
            //Default
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //Font
            SpriteFont label = Content.Load<SpriteFont>("Label");
            screenText = new Text(label, "Credits\nProgram made by: Skylar Stephens\nSprites from: https://arks.itch.io/dino-characters\n https://www.spriters-resource.com/nes/legendofzelda/sheet/31805/");
            //Sprites I got before seeing not to use an Atlas
            Texture2D vita = Content.Load<Texture2D>("Sprites/Sheets/Vita");
            animatedVita = new AnimatedSprite(vita, new Vector2(700, 400), 1, 24);
            Texture2D mort = Content.Load<Texture2D>("Sprites/Singles/Idle Mort");
            staticMort = new StaticSprite(mort, new Vector2(800, 400));
            Texture2D doux = Content.Load<Texture2D>("Sprites/Sheets/Doux");
            mobileAnimatedDoux = new MobileAnimatedSprite(doux, new Vector2(750, 400), 1, 24);
            Texture2D tart = Content.Load<Texture2D>("Sprites/Singles/Idle Tart");
            mobileStaticTart = new MobileStaticSprite(tart, new Vector2(950, 800));
            //Sprites I got after seeing not to use an Atlas
            Texture2D overworldEnemies = Content.Load<Texture2D>("Overworld Enemies");
            staticOctorok = new StaticSprite(overworldEnemies, new Vector2(800, 300), new Rectangle(1, 11, 16, 16));
            mobileStaticOctorok = new MobileStaticSprite(overworldEnemies, new Vector2(650, 100), new Rectangle(1, 28, 16, 16));

        }

        protected override void Update(GameTime gameTime)
        {
            animatedVita.Update(gameTime);
            mobileAnimatedDoux.Update(gameTime);
            mobileStaticTart.Update(gameTime);
            //New sprites
            mobileStaticOctorok.Update(gameTime);
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
            //Overloaded with samplterState, fixes blurry sprites from upscaling
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            //Font
            screenText.Draw(spriteBatch, new Vector2(400, 700));
            //Sprites
            staticMort.Draw(spriteBatch);
            animatedVita.Draw(spriteBatch);
            mobileAnimatedDoux.Draw(spriteBatch);
            mobileStaticTart.Draw(spriteBatch);
            //New Sprites
            staticOctorok.Draw(spriteBatch);
            mobileStaticOctorok.Draw(spriteBatch);
            //Default
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
