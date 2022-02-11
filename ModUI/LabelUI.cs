using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using ReLogic.Graphics;

namespace LevelingMod
{
	public class LabelUI : DrawableUI
	{
		public string text;
		public DynamicSpriteFont font;

		public LabelUI(string text, float x, float y, UIState state)
		{
			visible = true;
			this.text = text;
			origin = new Vector2();
			position = new Vector2(x, y);
			parent = state;
			overlayColor = new Color(222, 255, 196);
			orientation = 0;
			scale = 1.0f;
			font = Main.fontMouseText;
			parent.Append(this);
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
				spriteBatch.DrawString(font, text, position, overlayColor, orientation, origin, scale, SpriteEffects.None, 0f);
			}
		}
	}
}