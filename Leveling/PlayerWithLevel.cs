using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LevelingMod
{
	public class PlayerWithLevel : ModPlayer
	{
		public float level = 1;
		public float exp = 0;

		public float expMultiplier = 0f;

		public float lifeRegenBoost = 0f;
		public float manaRegenBoost = 0f;
		public float damageBoost = 0f;
		public float healthBoost = 0f;
		public float manaBoost = 0f;
		public float defenseBoost = 0f;
		public int minionsBoost = 0;

		public override void Load(TagCompound tag)
		{
			try
			{
				level = tag.GetFloat("Level");
				exp = tag.GetFloat("Exp");
			}
			catch (Exception e)
			{
				LevelingMod.instance.Logger.Warn("Failed to get level and exp! setting to 0.");
				level = 1;
				exp = 0;
			}

			CalculateBoosts();
			UpdateStatsUI();
		}

		public override TagCompound Save()
		{
			return new TagCompound
			{
				{"Level", level},
				{"Exp", exp},
			};
		}

		public override void OnEnterWorld(Player player)
		{
			UpdateStatsUI();
		}

		public override void PlayerDisconnect(Player player)
		{
			StatsUI.instance.SetVisibility(false);
		}

		public void CalculateBoosts()
		{
			damageBoost = (level / 6);
			healthBoost = (level / 45);
			defenseBoost = level / 15;
			manaBoost = (level / 4);
			lifeRegenBoost = level / 2;
			manaRegenBoost = level / 8;
			minionsBoost = 50 % (((int)level / 2) + 1);

			expMultiplier = level * 0.010f;
		}

		public float MaxExp()
		{
			return (expMultiplier * 1536) * level * 20;
		}

		public void CalculateExp()
		{
			if (exp >= MaxExp())
			{
				Rectangle textPosition = new Rectangle((int) player.bodyPosition.X, (int) player.bodyPosition.Y, 20, 20);
				Terraria.CombatText.NewText(textPosition, Colors.CoinGold, "LEVEL UP!", true);

				exp -= MaxExp();
				level += 1;

				CalculateExp();
				CalculateBoosts();
			}

			UpdateStatsUI();
		}

		public void AddExp(float mexp)
		{
			if (mexp <= 0 )
			{
				return;
			}
			
			exp = exp + mexp;
			CalculateExp();
		}

		public void UpdateStatsUI()
		{
			StatsUI.instance.levelLabel.text = "Level: " + level;
			StatsUI.instance.expLabel.text = "Exp: " + exp + " / " + MaxExp();
			StatsUI.instance.damageBoostLabel.text = "Damage boost: " + damageBoost;
			StatsUI.instance.healthBoostLabel.text = "Health boost: " + healthBoost;
			StatsUI.instance.defenseBoost.text = "Defense boost: " + defenseBoost;
			StatsUI.instance.minionsBoost.text = "Minion boost: " + minionsBoost + " / " + 50;
		}

		public override void ModifyWeaponDamage(Item item, ref float add, ref float mult, ref float flat)
		{
			flat += item.damage * damageBoost;
		}

		public override void PostUpdateEquips()
		{
			Main.LocalPlayer.statDefense += (int) (Main.LocalPlayer.statDefense * defenseBoost);
			Main.LocalPlayer.statLifeMax2 += (int) (Main.LocalPlayer.statLifeMax2 * healthBoost);
			Main.LocalPlayer.statManaMax2 += (int) (Main.LocalPlayer.statManaMax2 * manaBoost);
			Main.LocalPlayer.lifeRegen += (int) (Main.LocalPlayer.lifeRegen * lifeRegenBoost);
			Main.LocalPlayer.lifeRegenCount += (int) (lifeRegenBoost * 2);
			Main.LocalPlayer.manaRegen += (int) (Main.LocalPlayer.manaRegen * manaRegenBoost);
			Main.LocalPlayer.maxMinions += minionsBoost;
		}
	}
}