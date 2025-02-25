using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using Terrandom.Content.Tiles;

namespace Terrandom
{
	public class ModRecipes : ModSystem
	{
		public override void AddRecipes()
		{
			// SPEAR
			Recipe.Create(ItemID.Spear)
				.AddIngredient(null, "Flint", 3)
				.AddRecipeGroup(RecipeGroupID.IronBar, 5)
				.AddIngredient(null, "JungleSap", 2)
				.AddTile(TileID.Anvils)
				.Register();

			// HERMES BOOTS
			Recipe.Create(ItemID.HermesBoots)
				.AddIngredient(ItemID.Silk, 20)
				.AddIngredient(ItemID.Feather, 2)
				.AddIngredient(ItemID.GoldBar, 5)
				.AddIngredient(null, "JungleSap", 5)
				.AddTile(TileID.Loom)
				.Register();

			// HERMES BOOTS 2
			Recipe.Create(ItemID.HermesBoots)
				.AddIngredient(ItemID.Silk, 20)
				.AddIngredient(ItemID.Feather, 2)
				.AddIngredient(ItemID.PlatinumBar, 5)
				.AddIngredient(null, "JungleSap", 5)
				.AddTile(TileID.Loom)
				.Register();

			// LIFE CRYSTAL
			Recipe.Create(ItemID.LifeCrystal)
				.AddIngredient(ItemID.Ruby, 5)
				.AddIngredient(ItemID.FallenStar, 3)
				.AddIngredient(ItemID.HealingPotion, 2)
				.AddTile(TileID.DemonAltar)
				.Register();

			// ICE MIRROR
			Recipe.Create(ItemID.IceMirror)
				.AddIngredient(null, "FrozenDroplet", 4)
				.AddIngredient(ItemID.GoldBar, 8)
				.AddIngredient(ItemID.Diamond, 3)
				.AddTile(TileID.Furnaces)
				.Register();

			// ICE MIRROR 2
			Recipe.Create(ItemID.IceMirror)
				.AddIngredient(null, "FrozenDroplet", 4)
				.AddIngredient(ItemID.PlatinumBar, 8)
				.AddIngredient(ItemID.Diamond, 3)
				.AddTile(TileID.Furnaces)
				.Register();

			// ICE SKATES
			Recipe.Create(ItemID.IceSkates)
				.AddIngredient(ItemID.Silk, 10)
				.AddRecipeGroup(RecipeGroupID.IronBar, 5)
				.AddIngredient(null, "FrozenDroplet", 5)
				.AddTile(TileID.Loom)
				.Register();

			// DUNERIDER BOOTS
			Recipe.Create(ItemID.SandBoots)
				.AddIngredient(ItemID.HermesBoots, 1)
				.AddIngredient(null, "Flint", 5)
				.AddTile(TileID.Loom)
				.Register();

			// NATURE'S GIFT
			Recipe.Create(ItemID.NaturesGift)
				.AddIngredient(ItemID.Moonglow, 3)
				.AddIngredient(ItemID.ManaCrystal, 1)
				.AddIngredient(ItemID.JungleSpores, 10)
				.Register();

			// STEP STOOL
			Recipe.Create(ItemID.PortableStool)
				.AddRecipeGroup(RecipeGroupID.Wood, 8)
				.AddTile(TileID.Sawmill)
				.Register();

			// LIVING LOOM 
			Recipe.Create(ItemID.LivingLoom)
				.AddRecipeGroup(RecipeGroupID.Wood, 20)
				.AddIngredient(ItemID.LifeCrystal, 1)
				.AddTile(TileID.WorkBenches)
				.Register();

			// BLACK LENS
			Recipe.Create(ItemID.BlackLens)
				.AddIngredient(ItemID.Lens, 1)
				.AddIngredient(ItemID.BlackInk, 1)
				.AddTile(TileID.WorkBenches)
				.Register();

			/* ========================
			TRANSMUTATION TABLE RECIPES
			======================== */

			// TISSUE SAMPLE
			Recipe.Create(ItemID.TissueSample)
				.AddIngredient(ItemID.ShadowScale, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// SHADOW SCALE
			Recipe.Create(ItemID.ShadowScale)
				.AddIngredient(ItemID.TissueSample, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// COPPER ORE
			Recipe.Create(ItemID.CopperOre)
				.AddIngredient(ItemID.TinOre, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// TIN ORE
			Recipe.Create(ItemID.TinOre)
				.AddIngredient(ItemID.CopperOre, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// IRON ORE
			Recipe.Create(ItemID.IronOre)
				.AddIngredient(ItemID.LeadOre, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// LEAD ORE
			Recipe.Create(ItemID.LeadOre)
				.AddIngredient(ItemID.IronOre, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// SILVER ORE
			Recipe.Create(ItemID.SilverOre)
				.AddIngredient(ItemID.TungstenOre, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// TUNGSTEN ORE
			Recipe.Create(ItemID.TungstenOre)
				.AddIngredient(ItemID.SilverOre, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// GOLD ORE
			Recipe.Create(ItemID.GoldOre)
				.AddIngredient(ItemID.PlatinumOre, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// PLATINUM ORE
			Recipe.Create(ItemID.PlatinumOre)
				.AddIngredient(ItemID.GoldOre, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// DEMONITE ORE
			Recipe.Create(ItemID.DemoniteOre)
				.AddIngredient(ItemID.CrimtaneOre, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// CRIMTANE ORE
			Recipe.Create(ItemID.CrimtaneOre)
				.AddIngredient(ItemID.DemoniteOre, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// COBALT ORE
			Recipe.Create(ItemID.CobaltOre)
				.AddIngredient(ItemID.PalladiumOre, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// PALLADIUM ORE
			Recipe.Create(ItemID.PalladiumOre)
				.AddIngredient(ItemID.CobaltOre, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// MYTHRIL ORE
			Recipe.Create(ItemID.MythrilOre)
				.AddIngredient(ItemID.OrichalcumOre, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// ORICHALCUM ORE
			Recipe.Create(ItemID.OrichalcumOre)
				.AddIngredient(ItemID.MythrilOre, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// TITANIUM ORE
			Recipe.Create(ItemID.TitaniumOre)
				.AddIngredient(ItemID.AdamantiteOre, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// ADAMANTITE ORE
			Recipe.Create(ItemID.TitaniumOre)
				.AddIngredient(ItemID.AdamantiteOre, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// BLUE BRICK
			Recipe.Create(ItemID.BlueBrick)
				.AddIngredient(ItemID.PinkBrick, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// GREEN BRICK
			Recipe.Create(ItemID.GreenBrick)
				.AddIngredient(ItemID.BlueBrick, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// PINK BRICK
			Recipe.Create(ItemID.PinkBrick)
				.AddIngredient(ItemID.GreenBrick, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// CURSED FLAMES
			Recipe.Create(ItemID.CursedFlames)
				.AddIngredient(ItemID.Ichor, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// ICHOR
			Recipe.Create(ItemID.Ichor)
				.AddIngredient(ItemID.CursedFlames, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// CORRUPT SEEDS
			Recipe.Create(ItemID.CorruptSeeds)
				.AddIngredient(ItemID.CrimsonSeeds, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// CRIMSON SEEDS
			Recipe.Create(ItemID.CrimsonSeeds)
				.AddIngredient(ItemID.CorruptSeeds, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// VILE MUSHROOM
			Recipe.Create(ItemID.VileMushroom)
				.AddIngredient(ItemID.ViciousMushroom, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// VICIOUS MUSHROOM
			Recipe.Create(ItemID.ViciousMushroom)
				.AddIngredient(ItemID.VileMushroom, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// ROTTEN CHUNK
			Recipe.Create(ItemID.RottenChunk)
				.AddIngredient(ItemID.Vertebrae, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// VERTEBRA
			Recipe.Create(ItemID.Vertebrae)
				.AddIngredient(ItemID.RottenChunk, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// MUSKET
			Recipe.Create(ItemID.Musket)
				.AddIngredient(ItemID.TheUndertaker, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// THE UNDERTAKER
			Recipe.Create(ItemID.TheUndertaker)
				.AddIngredient(ItemID.Musket, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// SHADOW ORB
			Recipe.Create(ItemID.ShadowOrb)
				.AddIngredient(ItemID.CrimsonHeart, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// CRIMSON HEART
			Recipe.Create(ItemID.CrimsonHeart)
				.AddIngredient(ItemID.ShadowOrb, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// BAND OF STARPOWER
			Recipe.Create(ItemID.BandofStarpower)
				.AddIngredient(ItemID.PanicNecklace, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// PANIC NECKLACE
			Recipe.Create(ItemID.PanicNecklace)
				.AddIngredient(ItemID.BandofStarpower, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// VILETHORN
			Recipe.Create(ItemID.Vilethorn)
				.AddIngredient(ItemID.CrimsonRod, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// CRIMSON ROD
			Recipe.Create(ItemID.CrimsonRod)
				.AddIngredient(ItemID.Vilethorn, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// BALL O' HURT
			Recipe.Create(ItemID.BallOHurt)
				.AddIngredient(ItemID.TheRottedFork, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// THE ROTTED FORK
			Recipe.Create(ItemID.TheRottedFork)
				.AddIngredient(ItemID.BallOHurt, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// DART RIFLE
			Recipe.Create(ItemID.DartRifle)
				.AddIngredient(ItemID.DartPistol, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// DART PISTOL
			Recipe.Create(ItemID.DartPistol)
				.AddIngredient(ItemID.DartRifle, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// WORM HOOK
			Recipe.Create(ItemID.WormHook)
				.AddIngredient(ItemID.TendonHook, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// TENDON HOOK
			Recipe.Create(ItemID.TendonHook)
				.AddIngredient(ItemID.WormHook, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// CLINGER STAFF
			Recipe.Create(ItemID.ClingerStaff)
				.AddIngredient(ItemID.SoulDrain, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// LIFE DRAIN
			Recipe.Create(ItemID.SoulDrain)
				.AddIngredient(ItemID.ClingerStaff, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// PUTRID SCENT
			Recipe.Create(ItemID.PutridScent)
				.AddIngredient(ItemID.FetidBaghnakhs, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// FETID BAGHNAKHS
			Recipe.Create(ItemID.FetidBaghnakhs)
				.AddIngredient(ItemID.PutridScent, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// CHAIN GUILLOTINES
			Recipe.Create(ItemID.ChainGuillotines)
				.AddIngredient(ItemID.FleshKnuckles, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// FLESH KNUCKLES
			Recipe.Create(ItemID.FleshKnuckles)
				.AddIngredient(ItemID.ChainGuillotines, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// SCOURGE OF THE CORRUPTOR
			Recipe.Create(ItemID.ScourgeoftheCorruptor)
				.AddIngredient(ItemID.VampireKnives, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();

			// VAMPIRE KNIVES
			Recipe.Create(ItemID.VampireKnives)
				.AddIngredient(ItemID.ScourgeoftheCorruptor, 1)
				.AddTile(ModContent.TileType<TransmutationTable>())
				.Register();
		}
	}
}