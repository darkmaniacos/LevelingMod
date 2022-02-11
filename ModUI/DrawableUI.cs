using Microsoft.Xna.Framework;
using Terraria.UI;

namespace LevelingMod
{
	public abstract class DrawableUI : UIElement
	{
		internal UIState parent;

		public Vector2 origin;
		public Color overlayColor;
		public Vector2 position;
		public float orientation;
		public float scale;

		public bool visible;
	}
}