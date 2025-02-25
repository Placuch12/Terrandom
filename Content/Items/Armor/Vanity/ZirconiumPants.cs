using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Terrandom.Content.Items.Armor.Vanity
{
	[AutoloadEquip(EquipType.Legs)]
	public class ZirconiumPants : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(silver: 50);
			Item.vanity = true;
			Item.rare = ItemRarityID.Green;
		}
	}
}