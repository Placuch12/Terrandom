using Terrandom.Content.NPCs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace Terrandom.Content.Tiles
{
    public class Banner : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom | AnchorType.PlanterBox, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.DrawYOffset = -2;
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.Platform, TileObjectData.newTile.Width, 0);
            TileObjectData.newAlternate.DrawYOffset = -10;
            TileObjectData.addAlternate(0);
            TileObjectData.addTile(Type);
            DustType = -1;
            TileID.Sets.DisableSmartCursor[Type] = true;
            AddMapEntry(new Color(13, 88, 130), Language.GetText("MapObject.Banner"));
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (!closer)
                return;
            Player player = Main.LocalPlayer;
            if (player is null || !player.active || player.dead)
                return;

            int style = Main.tile[i, j].TileFrameX / 18;
            int npc = GetBannerNPC(style);
            if (npc != -1)
            {
                Main.SceneMetrics.NPCBannerBuff[npc] = true;
                Main.SceneMetrics.hasBanner = true;
            }
        }

        public static int GetBannerNPC(int style)
        {
            int npc = -1;
            switch (style)
            {
                case 0:
                    npc = NPCType<Gamumuht>();
                    break;
                case 1:
                    npc = NPCType<Jamumuht>();
                    break;
                case 2:
                    npc = NPCType<Finmoot>();
                    break;
                case 3:
                    npc = NPCType<Rotball>();
                    break;
                default:
                    break;
            }
            return npc;
        }
    }
}