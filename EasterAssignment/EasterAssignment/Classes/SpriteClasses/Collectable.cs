﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EasterAssignment.Classes.ServiceClasses;
using EasterAssignment.Classes.ContentManagerClasses;

namespace EasterAssignment.Classes.SpriteClasses
{
    public class Collectable : ISpriteWithBounds
    {
        public Rectangle Bounds { get; set; }

        public string SpriteID { get; set; }

        public Vector2 SpritePosition { get; set; }

        public string SpriteTextureKey { get; set; }

        public bool HasCollidedWithPlayer { get; set; }

        public Collectable(string ID ,Vector2 Position, string TextureKey)
        {
            SpriteID = ID;
            SpritePosition = Position;
            SpriteTextureKey = TextureKey;
            HasCollidedWithPlayer = false;
            Bounds = new Rectangle((int)Position.X, (int)Position.Y, TextureManager.AllTextures[TextureKey].Width, TextureManager.AllTextures[TextureKey].Height);

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Camera.CurrentCameraTranslation);
            spriteBatch.Draw(TextureManager.AllTextures[SpriteTextureKey], SpritePosition, Color.White);
            spriteBatch.End();
        }

        public void Update(GameTime gameTime)
        {
            HasCollidedWithPlayer = CheckIfCollidedWithPlayer();
            if (HasCollidedWithPlayer)
            {
                Helper.currentPlayer.Score += 10;
                Console.WriteLine(Helper.currentPlayer.Score);
            }
        }

        public bool CheckIfCollidedWithPlayer()
        {
            return Helper.currentPlayer.Bounds.Intersects(Bounds);
        }
    }
}
