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
	public class GuardianHeart : ModItem
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
			Item.defense = 2;

			if(player.statLife/(float)player.statLifeMax2 <= 0.5f) {
				Item.lifeRegen = 5;
			}
		}
	}
}