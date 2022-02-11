using Terraria;
using Terraria.ModLoader;

namespace LevelingMod.DebugSword
{
	public class DebugSword : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Death rose");
        }

		public override void SetDefaults()
		{
			item.autoReuse = true;
			item.useStyle = 1;
			item.useAnimation = 10;
			item.useTime = 100;
			item.width = 40;
			item.height = 40;
			item.damage = 999999;
			item.melee = true;
			item.rare = -12;
			item.value = 100000;
		}
	}
}