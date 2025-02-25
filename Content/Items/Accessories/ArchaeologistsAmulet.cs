using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using System;
using Terraria.ID;
using Terrandom.Content.Items.Accessories;

namespace Terrandom.Content.Items.Accessories
{
	public class ArchaeologistsAmulet : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 30;
			Item.value = 3000;
			Item.rare = ItemRarityID.Green;
			Item.accessory = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<ArchaeologistsCharm>()
				.AddIngredient(ItemID.LifeCrystal, 1)
				.AddIngredient(ItemID.Emerald, 5)
				.AddTile(TileID.Anvils)
				.Register();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			 player.AddBuff(BuffID.Dangersense, 2);
			 player.moveSpeed *= 1.15f;
			 player.maxRunSpeed *= 1.15f;
			 player.pickSpeed *= 0.85f;
		}
	}
}