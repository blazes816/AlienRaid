using System;
using Microsoft.Xna.Framework;

using Xanx;
using AlienRaid;
using AlienRaid.Sprites;

namespace AlienRaid.Screens
{
    public class Background : GameScreen
    {
        private Star[] stars;
        Random random = new Random();

        public Background(int width, int height)
            : base(width, height)
        {

        }

        // Setup the background
        protected override void Load()
        {
            stars = new Star[128];

            for (int i = 0; i < stars.Length; i++)
            {
                Star star = new Star(0, 0, "Content/Images/star");
                star.Position = new Vector2(random.Next(this.windowWidth), random.Next(this.windowHeight));
                star.Color = new Color(random.Next(256), random.Next(256), random.Next(256), 128);
                star.Velocity = new Vector2(0, (float)random.NextDouble() * 5 + 2);
                AddComponent(star);
                stars[i] = star;
            }

            base.Load();
        }

        public override void Update()
        {
            for (int i = 0; i < stars.Length; i++)
            {
                if ((stars[i].Position += stars[i].Velocity).Y > this.windowHeight)
                {
                    stars[i].Position = new Vector2(random.Next(this.windowWidth), random.Next(this.windowHeight + 200));
                    stars[i].Color = new Color(random.Next(256), random.Next(256), random.Next(256), 128);
                    stars[i].Velocity = new Vector2(0, (float)random.NextDouble() * 5 + 2);
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
