using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.ID;

using Microsoft.Xna.Framework.Input;

namespace LevelingMod
{
	public class LevelingMod : Mod
	{
		public static LevelingMod instance;
		public LevelingModUI mainUI;
		internal ModHotKey openUIKey;

		public override void Load()
		{
			if (!Main.dedServ)
			{
				mainUI = new LevelingModUI();
				openUIKey = RegisterHotKey("Toggle LevelingMod HUD", "P");
			}
			
			instance = this;
		}

		public override void Unload()
		{

			StatsUI.instance.backgroundImage.texture = null;
			StatsUI.instance = null;
			LevelingModUI.instance = null;
			instance = null;
		}

		public override void HotKeyPressed(string keyname)
		{
			if (openUIKey.JustPressed)
			{
				StatsUI.instance.SetVisibility(!StatsUI.instance.GetVisibility());
			}
		}

		public override void UpdateUI(GameTime gameTime)
		{
			if (Main.dedServ)
			{
				return;
			}

			mainUI.uiInterface?.Update(gameTime);
			//StatsUI.instance.Move(Main.mouseX, Main.mouseY);
			//StatsUI.instance.mousePositionLabel.text = "X: " + Main.mouseX + " Y: " + Main.mouseY;
			mainUI.UpdateFunnySecret();
		}

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			int inventoryLayerIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (inventoryLayerIndex != -1) {
				layers.Insert(inventoryLayerIndex, new LegacyGameInterfaceLayer(
					"LevelingMod: UI",
					delegate {
						mainUI.uiInterface.Draw(Main.spriteBatch, new GameTime());
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
		}
	}
}