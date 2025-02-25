using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Terrandom.Content.Items.Materials
{
	public class LeFisheAuChocolat : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults() {
			Item.maxStack = Item.CommonMaxStack;
			Item.width = 24;
			Item.height = 24;
			Item.value = Item.buyPrice(platinum: 95);
		}
	}
}