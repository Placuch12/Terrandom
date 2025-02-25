using Terraria;
using System.Linq;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace Terrandom.Content.Items.Accessories
{
	public class VIPKeycard : ModItem
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
			Item.rare = ItemRarityID.Orange;
			Item.accessory = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "OrangeKeycard", 1)
				.AddIngredient(null, "PurpleKeycard", 1)
				.AddIngredient(null, "CyanKeycard", 1)
				.AddIngredient(ItemID.GoldDust, 15)
				.AddTile(TileID.TinkerersWorkbench)
				.Register();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.maxMinions += 2;
			player.GetDamage(DamageClass.Generic) += 0.09f;
		}

		public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player) {

			int[] restrictedKeycards = {
                        ModContent.ItemType<HotelKeycard>(), 
                        ModContent.ItemType<PurpleKeycard>(), 
                        ModContent.ItemType<OrangeKeycard>(),
						ModContent.ItemType<CyanKeycard>()
            };

			return !restrictedKeycards.Contains(incomingItem.type);
		}
	}
}