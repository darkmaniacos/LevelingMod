using Microsoft.Xna.Framework;
using Terraria.UI;

namespace LevelingMod
{
	public class StatsUI
	{
		public static StatsUI instance;
		public static float padding = 14;
		public UIState uiState;

		public static Vector2 defaultPosition = new Vector2(125, 275);

		public ImageUI backgroundImage;
		public LabelUI levelLabel;
		public LabelUI expLabel;
		public LabelUI damageBoostLabel;
		public LabelUI healthBoostLabel;
		public LabelUI defenseBoost;
		public LabelUI minionsBoost;

		public LabelUI mousePositionLabel;

		public StatsUI(UIState uiState, UserInterface uiInterface, bool visibility)
		{
			backgroundImage = new ImageUI("LevelingMod/Assets/UIBackground", defaultPosition.X, defaultPosition.Y, uiState);
			backgroundImage.scale = 1.2f;
			
			levelLabel = new LabelUI("Level: 0", defaultPosition.X, defaultPosition.Y, uiState);
			levelLabel.origin.Y = -(padding);
			levelLabel.origin.X = -(padding);

			expLabel = new LabelUI("Exp: 0", defaultPosition.X, defaultPosition.Y, uiState);
			expLabel.origin.Y = -(padding*3);
			expLabel.origin.X = -(padding);

			minionsBoost = new LabelUI("Minion boost: 0", defaultPosition.X, defaultPosition.Y, uiState);
			minionsBoost.origin.Y = -(padding*5);
			minionsBoost.origin.X = -(padding);

			damageBoostLabel = new LabelUI("Damage boost: 0", defaultPosition.X, defaultPosition.Y, uiState);
			damageBoostLabel.origin.Y = -(padding*7);
			damageBoostLabel.origin.X = -(padding);

			healthBoostLabel = new LabelUI("Health boost: 0", defaultPosition.X, defaultPosition.Y, uiState);
			healthBoostLabel.origin.Y = -(padding*9);
			healthBoostLabel.origin.X = -(padding);

			defenseBoost = new LabelUI("Defense boost: 0", defaultPosition.X, defaultPosition.Y, uiState);
			defenseBoost.origin.Y = -(padding*11);
			defenseBoost.origin.X = -(padding);


			mousePositionLabel = new LabelUI("X: 0 Y: 0", defaultPosition.X, defaultPosition.Y, uiState);
			mousePositionLabel.origin.Y = -(padding*7);
			mousePositionLabel.origin.X = -(padding);
			mousePositionLabel.overlayColor = new Color(255, 0, 0);

			backgroundImage.visible = visibility;
			levelLabel.visible = visibility;
			expLabel.visible = visibility;
			damageBoostLabel.visible = visibility;
			healthBoostLabel.visible = visibility;
			defenseBoost.visible = visibility;
			minionsBoost.visible = visibility;
			mousePositionLabel.visible = visibility;

			uiInterface.SetState(uiState);

			instance = this;
		}

		public void Move(float x, float y)
		{
			backgroundImage.Move(x, y);
			levelLabel.Move(x, y);
			expLabel.Move(x, y);
			damageBoostLabel.Move(x, y);
			healthBoostLabel.Move(x, y);
			defenseBoost.Move(x, y);
			minionsBoost.Move(x, y);
			mousePositionLabel.Move(x, y);
		}

		public void SetVisibility(bool visibility)
		{
			backgroundImage.visible = visibility;
			levelLabel.visible = visibility;
			expLabel.visible = visibility;
			damageBoostLabel.visible = visibility;
			healthBoostLabel.visible = visibility;
			defenseBoost.visible = visibility;
			minionsBoost.visible = visibility;
			mousePositionLabel.visible = visibility;
		}

		public bool GetVisibility()
		{
			return backgroundImage.visible;
		}
	}
}