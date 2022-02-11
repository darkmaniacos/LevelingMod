using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace LevelingMod
{
	public class ImageUI : DrawableUI
	{
		public Texture2D texture;

		public ImageUI(string texturePath, float x, float y, UIState state)
		{
			visible = true;
			texture = ModContent.GetTexture(texturePath);
			origin = new Vector2();
			position = new Vector2(x, y);
			overlayColor = new Color(255, 255, 255);
			orientation = 0.0f;
			scale = 1.0f;
			parent = state;
			
			state.Append(this);

		}

		public void Move(float x, float y)
		{
			position.X = x;
			position.Y = y;
			parent.Append(this);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			if (visible)
			{
				Main.spriteBatch.Draw(texture, position, null, overlayColor, orientation, origin, scale, SpriteEffects.None, 0f);
			}
		}
	}
}