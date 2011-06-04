using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using MyEngine;

using AlienRaid.Screens;

namespace AlienRaid {

	public class AlienRaidGame : Microsoft.Xna.Framework.Game {
		GraphicsDeviceManager graphics;
        Engine engine;


        /* Todo: Remove
		SpriteBatch spriteBatch;
		Texture2D _playerShip;
		Vector2 _pos = new Vector2(400, 530);
        */

		public AlienRaidGame() {
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			graphics.PreferredBackBufferHeight = 600;
			graphics.PreferredBackBufferWidth = 800;
			graphics.IsFullScreen = false;
			Window.Title = "Alien Raid Demo Game";
		}

		protected override void Initialize() {
			base.Initialize();
		}

		protected override void LoadContent() {
            engine = new Engine(graphics);
            
            // Create our game screens
            Screens.Background background = new Screens.Background(Window.ClientBounds.Width, Window.ClientBounds.Height);
            Screens.Play playing = new Screens.Play(Window.ClientBounds.Width, Window.ClientBounds.Height);
            engine.PushGameScreen(background);
            engine.PushGameScreen(playing);
		}

		protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

			base.Update(gameTime);
            engine.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime) {
			GraphicsDevice.Clear(Color.Black);
            /* TODO: move to screen
			spriteBatch.Begin();
			spriteBatch.Draw(_playerShip, _pos, null, Color.White, 0, Vector2.Zero, 2, SpriteEffects.None, 0);
			spriteBatch.End();
            */
            engine.Draw(gameTime);
			base.Draw(gameTime);
		}
	}
}
