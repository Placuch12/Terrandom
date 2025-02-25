using Terrandom.Content.NPCs.ElderGamumuht;
using Terraria;
using System;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Terrandom.Content.Items.BossSpawn
{
	public class AncientTabelau : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 3;
			ItemID.Sets.SortingPriorityBossSpawns[Type] = 12;
		}

		public override void SetDefaults() {
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 20;
			Item.value = 5500;
			Item.rare = ItemRarityID.Blue;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.consumable = true;
		}

		public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup) {
			itemGroup = ContentSamples.CreativeHelper.ItemGroup.BossSpawners;
		}

		public override bool CanUseItem(Player player) {
			return !NPC.AnyNPCs(ModContent.NPCType<ElderGamumuht>());
		}

		public override bool? UseItem(Player player) {
			if (player.whoAmI == Main.myPlayer) {
				SoundEngine.PlaySound(SoundID.Roar, player.position);

				int type = ModContent.NPCType<ElderGamumuht>();

				if (Main.netMode != NetmodeID.MultiplayerClient) {
					NPC.SpawnOnPlayer(player.whoAmI, type);
				}
				else {
					NetMessage.SendData(MessageID.SpawnBossUseLicenseStartEvent, number: player.whoAmI, number2: type);
				}
			}

			return true;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(null, "Flint", 5)
				.AddIngredient(null, "JungleSap", 5)
				.AddIngredient(null, "FrozenDroplet", 5)
				.AddTile(TileID.DemonAltar)
				.Register();

			/* CreateRecipe()
				.AddIngredient(null, "TranslatedRunes", 1)
				.AddCondition(Condition.InGraveyard)
				.Register(); */
		}
	}
}