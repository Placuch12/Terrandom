using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using System;
using Terraria.ID;

namespace Terrandom.Content.Items.Accessories
{
	public class ArchaeologistsCharm : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 30;
			Item.value = 2500;
			Item.rare = ItemRarityID.Blue;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			 player.AddBuff(BuffID.Dangersense, 2);
			 player.statLifeMax2 -= 20;
			 player.moveSpeed *= 1.1f;
			 player.maxRunSpeed *= 1.1f;
			 player.pickSpeed *= 0.90f;
		}
	}
}