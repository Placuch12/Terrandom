using Terrandom.Content.NPCs.ElderGamumuht;
using Terrandom.Content.Items.Placeable.Furniture;
using Terrandom.Content.Items.Armor.Vanity;
using Terrandom.Content.Items;
using Terrandom.Content.Items.Accessories;
using Terrandom.Content.Items.Weapons.Ranged;
using Terrandom.Content.Items.Weapons.Magic;
using Terrandom.Content.Items.Weapons.Melee;
using Terrandom.Content.Items.Weapons.Summon;
// using Terrandom.Content.Items.Misc;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Terrandom.Content.Items.BossBags
{
	public class ElderGamumuhtBag : ModItem
	{
		public override void SetStaticDefaults() {
			ItemID.Sets.BossBag[Type] = true;
			ItemID.Sets.PreHardmodeLikeBossBag[Type] = true;

			Item.ResearchUnlockCount = 3;
		}

		public override void SetDefaults() {
			Item.maxStack = Item.CommonMaxStack;
			Item.consumable = true;
			Item.width = 24;
			Item.height = 24;
			Item.rare = ItemRarityID.Purple;
			Item.expert = true;
		}

		public override bool CanRightClick() {
			return true;
		}

		public override void ModifyItemLoot(ItemLoot itemLoot) {
			itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<ElderGamumuhtMask>(), 7)); //btw that only applies to the mask use regular drop rule for others
			itemLoot.Add(ItemDropRule.OneFromOptions(1, ModContent.ItemType<ThrowingAxe>(), ModContent.ItemType<RuneBlaster>(), ModContent.ItemType<EldersEdge>(), ModContent.ItemType<AeromuhtStaff>()));
			itemLoot.Add(ItemDropRule.OneFromOptions(1, ModContent.ItemType<GuardianHeart>(), ModContent.ItemType<ArchaeologistsCharm>()));
			// itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<TranslatedRunes>(), 1));
			itemLoot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<Items.Armor.Vanity.ZirconiumPants>()));
		}
	}
}