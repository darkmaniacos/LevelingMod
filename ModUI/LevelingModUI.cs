using Microsoft.Xna.Framework;
using Terraria.UI;
using Terraria;
using System;
using System.Threading.Tasks;

namespace LevelingMod
{
	public class LevelingModUI
	{
		public static LevelingModUI instance;
		public UserInterface uiInterface;
		public UIState uiState;
		
		public StatsUI statsUI;

		public LevelingModUI()
		{
			uiInterface = new UserInterface();
			uiState = new UIState();
			uiState.Activate();

			statsUI = new StatsUI(uiState, uiInterface, false);
			secretImage = new ImageUI("LevelingMod/Assets/Funny", 700, Main.screenHeight, uiState);

			uiInterface.SetState(uiState);

			instance = this;
		}

		public int funnySecretTimer = 0;
		public int funnySecretOffset = 0;
		public bool goingUp = false;
		public bool goingDown = false;
		public ImageUI secretImage;

		public void UpdateFunnySecret()
		{
			if (funnySecretTimer % 30000 == 0 && funnySecretTimer != 0)
			{
				Random rnd = new Random();
				if (rnd.Next(11) == 1)
				{
					goingUp = true;
					funnySecretTimer++;
				}
				else
				{
					funnySecretTimer = 0;
				}
			}
			else if (funnySecretTimer % 30450 == 0 && funnySecretTimer != 0)
			{
				goingDown = true;
			}

			if (goingUp && funnySecretOffset < 470)
			{
				funnySecretOffset++;
				secretImage.Move(700, Main.screenHeight - funnySecretOffset);
			}
			else if (goingUp)
			{
				goingUp = false;
			}
			else if (goingDown && funnySecretOffset > 0)
			{
				funnySecretOffset -= 12;
				secretImage.Move(700, Main.screenHeight - funnySecretOffset);
			}
			else if (goingDown)
			{
				goingDown = false;
				funnySecretTimer = 0;
			}
			else
			{
				funnySecretTimer++;
			}
		}
	}
}