﻿using Microsoft.Xna.Framework;
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
        /// <summary>
        /// Focuses on <paramref name="spriteToFocus"/> and sets all sprites in <paramref name="sprites"/> to invisible
        /// </summary>
        /// <param name="spriteToFocus"></param>
        /// <param name="sprites"></param>
        private static void Focus(ISprite spriteToFocus, List<ISprite> sprites)
        {
            foreach (ISprite sprite in sprites)
            {
                sprite.IsVisible = false;

            }
            spriteToFocus.IsVisible = true;
        }


        protected override void Initialize()
        {
            //Keys
            keyboardActions = new KeyboardActions();
            keyboardActions.Add(Keys.D0, Exit);
            keyboardActions.Add(Keys.D1, () => { Focus(sprites[5], sprites); });
            keyboardActions.Add(Keys.D3, () => { Focus(sprites[6], sprites); });
            keyboardActions.Add(Keys.D2, () => { Focus(sprites[7], sprites); });
            keyboardActions.Add(Keys.D4, () => { Focus(sprites[8], sprites); });
            //Extra
            keyboardActions.Add(Keys.A, () => { foreach (ISprite sprite in sprites) sprite.IsVisible = true; });
            keyboardActions.Add(Keys.N, () => { foreach (ISprite sprite in sprites) sprite.IsVisible = false; });
            //Mouse
            mouseActions = new MouseActions();
            mouseActions.Add(MouseActions.MouseButtons.Right, Exit);
            mouseActions.Add(MouseActions.MousePositions.Quad1, () => { Focus(sprites[5], sprites); });
            mouseActions.Add(MouseActions.MousePositions.Quad3, () => { Focus(sprites[6], sprites); });
            mouseActions.Add(MouseActions.MousePositions.Quad2, () => { Focus(sprites[7], sprites); });
            mouseActions.Add(MouseActions.MousePositions.Quad4, () => { Focus(sprites[8], sprites); });
            //Default
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Vector2 ScreenCenter = new(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);

            spriteBatch = new SpriteBatch(GraphicsDevice);
            //Font
            SpriteFont label = Content.Load<SpriteFont>("Label");
            ISprite screenText = new Text(label, "Credits\nProgram made by: Skylar Stephens\nSprites from: https://arks.itch.io/dino-characters" +
                "\n https://www.spriters-resource.com/nes/legendofzelda/sheet/31805/", new Vector2(400, 700));
            //Sprites I got before seeing not to use an Atlas
            Texture2D mort = Content.Load<Texture2D>("Sprites/Singles/Idle Mort");
            Texture2D tart = Content.Load<Texture2D>("Sprites/Singles/Idle Tart");
            Texture2D vita = Content.Load<Texture2D>("Sprites/Sheets/Vita");
            Texture2D doux = Content.Load<Texture2D>("Sprites/Sheets/Doux");
            ISprite Mort = new StaticSprite(mort, new Vector2(ScreenCenter.X + 50, ScreenCenter.Y));
            ISprite Tart = new MobileStaticSprite(tart, new Vector2(ScreenCenter.X + 300, ScreenCenter.Y - 100), millisecondsPerFrame: 0);
            ISprite Vita = new AnimatedSprite(vita, new Vector2(ScreenCenter.X + 200, ScreenCenter.Y), 1, 24, millisecondsPerFrame: 200);
            ISprite Doux = new MobileAnimatedSprite(doux, new Vector2(ScreenCenter.X + 300, ScreenCenter.Y - 250), 1, 24, millisecondsPerFrame: 150);
            //Sprites I got after seeing not to use an Atlas
            Texture2D OverworldEnemies = Content.Load<Texture2D>("Overworld Enemies");
            ISprite Octorok = new StaticSprite(OverworldEnemies, new Vector2(ScreenCenter.X - 50, ScreenCenter.Y), new Rectangle(1, 11, 16, 16));
            ISprite BlueOctorok = new MobileStaticSprite(
                OverworldEnemies,
                new Vector2(ScreenCenter.X - 300, ScreenCenter.Y + 100),
                new Rectangle(1, 28, 16, 16),
                millisecondsPerFrame: 500
                );
            ISprite Moblin = new AnimatedSprite(
                texture: OverworldEnemies,
                position: new Vector2(ScreenCenter.X - 200, ScreenCenter.Y),
                rows: 2, columns: 4,
                texturePosition: new Rectangle(82, 11, 64, 32),
                gap: 1,
                millisecondsPerFrame: 500
                );
            ISprite Tektite = new MobileAnimatedSprite(
                texture: OverworldEnemies,
                position: new Vector2(ScreenCenter.X - 300, ScreenCenter.Y + 250),
                rows: 1, columns: 4,
                texturePosition: new Rectangle(162, 90, 64, 16),
                gap: 1,
                millisecondsPerFrame: 500
                );
            sprites = new List<ISprite>()
            {
                screenText,
                Mort, Tart, Vita, Doux,
                Octorok, BlueOctorok, Moblin, Tektite
            };
            //Default state
            Focus(sprites[5], sprites);
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
