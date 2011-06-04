using System;
using Microsoft.Xna.Framework;

using MyEngine;
using AlienRaid;
using AlienRaid.Sprites;

namespace AlienRaid.Screens
{
	public class Background : GameScreen
    {
		Star[] _stars = new Star[128];
		Random _rnd = new Random();

        private int width;
        private int height;

		public Background(int width, int height)
        {
            // Window size
            this.width = width;
            this.height = height;
		}

        // Setup the background
		protected override void Load() {
			for(int i = 0; i < _stars.Length; i++) {
				Star star = new Star(_rnd.Next(this.width), _rnd.Next(this.height), "Content/Images/star");
				star.Color = new Color(_rnd.Next(256), _rnd.Next(256), _rnd.Next(256), 128);
				star.Velocity = new Vector2(0, (float)_rnd.NextDouble() * 5 + 2);
				_stars[i] = star;
                AddComponent(star);
			}
		}

        public override void Update()
        {
			for(int i = 0; i < _stars.Length; i++) {
				var star = _stars[i];
				if((star.Position += star.Velocity).Y > this.height) {
					// "generate" a new star
					star.Position = new Vector2(_rnd.Next(this.width), -_rnd.Next(20));
                    star.Velocity = new Vector2(0, (float)_rnd.NextDouble() * 5 + 2);
					star.Color = new Color(_rnd.Next(256), _rnd.Next(256), _rnd.Next(256), 128);
				}
			}

			base.Update();
		}

		public override void Draw()
        {
			base.Draw();
		}
	}
}
