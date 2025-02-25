using Terrandom.Content.Items.Weapons.Melee;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;

namespace Terrandom.Common.Systems
{
	class VanillaDropsItem : GlobalItem{
		
		public override void ModifyItemLoot(Item item, ItemLoot itemLoot) {
			if (item.type == ItemID.SkeletronBossBag) {
				itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SkullSmasher>(), 2));
			}

			if (item.type == ItemID.KingSlimeBossBag) {
				itemLoot.Add(ItemDropRule.Common(ItemID.SlimeStaff, 3));
			}

			if (item.type == ItemID.GolemBossBag) {
				itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Monolith>(), 7));
			}
			// more items go here
		}
	}
}