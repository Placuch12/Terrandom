using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria.ModLoader;
using Terrandom;
using Terrandom.Content.NPCs.ElderGamumuht;
using Terrandom.Common.Systems;

namespace Terrandom.Common.Systems
{
	public class ModIntegrationsSystem : ModSystem
	{
		public override void PostSetupContent() {
			DoBossChecklistIntegration();
		}

		private void DoBossChecklistIntegration() {
			if (!ModLoader.TryGetMod("BossChecklist", out Mod bossChecklistMod)) {
				return;
			}

			string internalName = "ElderGamumuht"; // i put a space so it said "Elder Gamumuht" here and debugging it took away countless hours of my life

			float weight = 4.5f;

			Func<bool> downed = () => DownedBossSystem.downedElderGamumuht;

			int bossType = ModContent.NPCType<Content.NPCs.ElderGamumuht.ElderGamumuht>();

			int spawnItem = ModContent.ItemType<Content.Items.BossSpawn.AncientTabelau>();

			List<int> collectibles = new List<int>()
			{
				ModContent.ItemType<Content.Items.Weapons.Ranged.ThrowingAxe>(),
				ModContent.ItemType<Content.Items.Weapons.Magic.RuneBlaster>(),
				ModContent.ItemType<Content.Items.Weapons.Melee.EldersEdge>(),
				ModContent.ItemType<Content.Items.Weapons.Summon.AeromuhtStaff>(),
				// ModContent.ItemType<Content.Items.Misc.TranslatedRunes>(),
				ModContent.ItemType<Content.Items.Placeable.Furniture.ElderGamumuhtRelic>(),
				ModContent.ItemType<Content.Items.Placeable.Furniture.ElderGamumuhtTrophy>(),
				ModContent.ItemType<Content.Items.Armor.Vanity.ElderGamumuhtMask>(),
				ModContent.ItemType<Content.Items.Armor.Vanity.ZirconiumPants>(),
				ModContent.ItemType<Content.Items.Accessories.GuardianHeart>(),
				ModContent.ItemType<Content.Items.Accessories.ArchaeologistsCharm>()
			};

			bossChecklistMod.Call(
				"LogBoss",
				Mod,
				internalName,
				weight,
				downed,
				bossType,
				new Dictionary<string, object>() {
					["spawnItems"] = spawnItem,
					["collectibles"] = collectibles,
				}
			);
		}
	}
}