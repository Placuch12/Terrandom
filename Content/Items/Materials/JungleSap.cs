using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Terrandom.Content.Items.Materials
{
	public class JungleSap : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 25;
			ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<Flint>();
		}

		public override void SetDefaults() {
			Item.maxStack = Item.CommonMaxStack;
			Item.width = 24;
			Item.height = 24;
			Item.value = Item.buyPrice(copper: 95);
		}
	}
}