using System;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snow
{
    public class Particle
    {
        private int size;
        private Color color;
        private float minFallSpeed = 50;
        private float maxFallSpeed = 150;
        private float fallSpeed;
        private Vector2 position;

        private Vector2 velocity = new Vector2();
        private Texture2D texture;

        private float time;
        public Vector2 Position{
            get(return position;)
        }

        public Particle(int size, Color color, Vector2 position, Texture2D texture){
            this.size = size;
            this.color = color;
            this.position = position;
            this.texture = texture;
            Random rand = new Random();
            time = (float)(rand.NextDouble())*MathF.Tau;

            float fallSpeedDifference = maxFallSpeed - minFallSpeed;
            float sizePercent = size/20f;
            fallSpeed = minFallSpeed + (fallSpeedDifference * sizePercent);
        }

        public void Update(){
            float dt = 1f / 60f;
            time += dt;
            velocity.Y = fallSpeed*dt;
            velocity.X += MathF.Sin(time*4)*2;
        }

        public void Draw(SpriteBatch spriteBatch){
            Rectangle r = new Rectangle((int)position.X,(int)position.Y,size,size);
            spriteBatch.Draw(texture,r,color);
        }
    }
}