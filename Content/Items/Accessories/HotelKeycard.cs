using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terrandom.Content.Items.Accessories;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Terrandom.Content.Items.Accessories
{
	public class HotelKeycard : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 30;
			Item.value = Item.sellPrice(0, 0, 25, 0);
			Item.rare = ItemRarityID.Green;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.maxMinions += 1;
		}

		public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player) {

			int[] restrictedKeycards = {
                        ModContent.ItemType<CyanKeycard>(), 
                        ModContent.ItemType<PurpleKeycard>(), 
                        ModContent.ItemType<OrangeKeycard>(),
						ModContent.ItemType<VIPKeycard>()
            };

			return !restrictedKeycards.Contains(incomingItem.type);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.IronBar, 5)
				.AddIngredient(ItemID.Lens, 2)
				.AddIngredient(ItemID.Wire, 1)
				.AddIngredient(ItemID.GoldBar, 1)
				.AddTile(TileID.Anvils)
				.Register();

			CreateRecipe()
				.AddIngredient(ItemID.LeadBar, 5)
				.AddIngredient(ItemID.Lens, 2)
				.AddIngredient(ItemID.Wire, 1)
				.AddIngredient(ItemID.GoldBar, 1)
				.AddTile(TileID.Anvils)
				.Register();

			CreateRecipe()
				.AddIngredient(ItemID.IronBar, 5)
				.AddIngredient(ItemID.Lens, 2)
				.AddIngredient(ItemID.Wire, 1)
				.AddIngredient(ItemID.PlatinumBar, 1)
				.AddTile(TileID.Anvils)
				.Register();

			CreateRecipe()
				.AddIngredient(ItemID.LeadBar, 5)
				.AddIngredient(ItemID.Lens, 2)
				.AddIngredient(ItemID.Wire, 1)
				.AddIngredient(ItemID.PlatinumBar, 1)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}