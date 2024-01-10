using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Scripts;
using Sprint0.Scripts.Interfaces;
using System.Collections.Generic;

namespace Sprint0
{
    public class Main : Game
    {
        //Default
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        //All sprites go in here
        private List<ISprite> sprites;
        //Controllers
        private IController keyboardActions;
        private IController mouseActions;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferHeight = 900,
                PreferredBackBufferWidth = 1600
            };
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            //Keys
            keyboardActions = new KeyboardActions();
            keyboardActions.Add(Keys.D0, Exit);
            keyboardActions.Add(Keys.D1, () => { sprites[5].Focus(sprites); });
            keyboardActions.Add(Keys.D2, () => { sprites[6].Focus(sprites); });
            keyboardActions.Add(Keys.D3, () => { sprites[7].Focus(sprites); });
            keyboardActions.Add(Keys.D4, () => { sprites[8].Focus(sprites); });
            //Extra
            keyboardActions.Add(Keys.A, () => { foreach (ISprite sprite in sprites) sprite.IsVisible = true; });
            keyboardActions.Add(Keys.N, () => { foreach (ISprite sprite in sprites) sprite.IsVisible = false; });
            //Mouse
            mouseActions = new MouseActions();
            mouseActions.Add(MouseActions.MouseButtons.Right, Exit);
            mouseActions.Add(MouseActions.MousePositions.Quad1, () => { sprites[5].Focus(sprites); });
            mouseActions.Add(MouseActions.MousePositions.Quad2, () => { sprites[6].Focus(sprites); });
            mouseActions.Add(MouseActions.MousePositions.Quad3, () => { sprites[7].Focus(sprites); });
            mouseActions.Add(MouseActions.MousePositions.Quad4, () => { sprites[8].Focus(sprites); });
            //Default
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //Font
            SpriteFont label = Content.Load<SpriteFont>("Label");
            ISprite screenText = new Text(label, "Credits\nProgram made by: Skylar Stephens\nSprites from: https://arks.itch.io/dino-characters\n https://www.spriters-resource.com/nes/legendofzelda/sheet/31805/", new Vector2(400, 700));
            //Sprites I got before seeing not to use an Atlas
            Texture2D vita = Content.Load<Texture2D>("Sprites/Sheets/Vita");
            ISprite animatedVita = new AnimatedSprite(vita, new Vector2(700, 400), 1, 24);
            Texture2D mort = Content.Load<Texture2D>("Sprites/Singles/Idle Mort");
            ISprite staticMort = new StaticSprite(mort, new Vector2(800, 400));
            Texture2D doux = Content.Load<Texture2D>("Sprites/Sheets/Doux");
            ISprite mobileAnimatedDoux = new MobileAnimatedSprite(doux, new Vector2(750, 400), 1, 24);
            Texture2D tart = Content.Load<Texture2D>("Sprites/Singles/Idle Tart");
            ISprite mobileStaticTart = new MobileStaticSprite(tart, new Vector2(950, 800));
            //Sprites I got after seeing not to use an Atlas
            Texture2D overworldEnemies = Content.Load<Texture2D>("Overworld Enemies");
            ISprite staticOctorok = new StaticSprite(overworldEnemies, new Vector2(800, 300), new Rectangle(1, 11, 16, 16));
            ISprite mobileStaticOctorok = new MobileStaticSprite(overworldEnemies, new Vector2(650, 100), new Rectangle(1, 28, 16, 16));
            ISprite animatedMoblin = new AnimatedSprite(overworldEnemies, new Vector2(1000, 300), 2, 4, new Rectangle(82, 11, 64, 32), 1);
            ISprite mobileAnimatedTektite = new MobileAnimatedSprite(overworldEnemies, new Vector2(400, 300), 1, 4, new Rectangle(162, 90, 64, 16), 1);

            sprites = new List<ISprite>()
            {
                screenText,
                staticMort, mobileStaticTart, animatedVita, mobileAnimatedDoux,
                staticOctorok, mobileStaticOctorok, animatedMoblin, mobileAnimatedTektite
            };
            //Default state
            sprites[5].Focus(sprites);
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (ISprite sprite in sprites)
            {
                sprite.Update(gameTime);
            };
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
            //Overloaded with samplerState, fixes blurry sprites from upscaling
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            foreach (ISprite sprite in sprites)
            {
                sprite.Draw(spriteBatch);
            };
            //Default
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
