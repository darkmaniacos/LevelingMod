using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LevelingMod
{
	public class NPCExpGiver : GlobalNPC
	{
		public void GivePlayerDamageXP(ref Player player, ref NPC npc)
		{
			if (npc.life <= 0)
			{
				PlayerWithLevel modPlr = player.GetModPlayer<PlayerWithLevel>();
				
				float boss_xp_debuf = npc.boss ? 1f : 1.5f;
				float exp = ((npc.lifeMax + (npc.defense / 10) + npc.damage) / 2) * boss_xp_debuf;
				modPlr.AddExp(exp);

				Rectangle textPosition = new Rectangle((int)npc.position.X, (int)npc.position.Y, 10, 10);
				Terraria.CombatText.NewText(textPosition, Colors.RarityPurple, exp + " exp!", false);
			}
		}


		public override void OnHitByItem(NPC npc, Player player, Item item, int damage, float knockback, bool crit)
		{
			GivePlayerDamageXP(ref player, ref npc);
		}

		public override void OnHitByProjectile(NPC npc, Projectile projectile, int damage, float knockback, bool crit)
		{
			if (projectile.owner == Main.myPlayer)
			{
				GivePlayerDamageXP(ref Main.player[projectile.owner], ref npc);
			}
		}
	}
}