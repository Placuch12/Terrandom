using Terraria;
using System.Linq;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace Terrandom.Content.Items.Accessories
{
	public class PurpleKeycard : ModItem
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
				.AddIngredient(null, "HotelKeycard", 1)
				.AddIngredient(ItemID.DemoniteBar, 5)
				.AddIngredient(ItemID.FallenStar, 5)
				.AddIngredient(ItemID.JungleSpores, 10)
				.AddTile(TileID.Anvils)
				.Register();

			CreateRecipe()
				.AddIngredient(null, "HotelKeycard", 1)
				.AddIngredient(ItemID.CrimtaneBar, 5)
				.AddIngredient(ItemID.FallenStar, 5)
				.AddIngredient(ItemID.JungleSpores, 10)
				.AddTile(TileID.Anvils)
				.Register();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.maxMinions += 1;
			player.GetDamage(DamageClass.Magic) += 0.05f;
			player.GetCritChance(DamageClass.Magic) += 4f;
		}

		public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player) {

			int[] restrictedKeycards = {
                        ModContent.ItemType<HotelKeycard>(), 
                        ModContent.ItemType<CyanKeycard>(), 
                        ModContent.ItemType<OrangeKeycard>(),
						ModContent.ItemType<VIPKeycard>()
            };

			return !restrictedKeycards.Contains(incomingItem.type);
		}
	}
}