using SimpleExternalCheatCSGO.Structs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleExternalCheatCSGO.Settings
{
    public enum GlowType
    {
        Color = 0,
        Vis_Color,
        Health,
    };

    public enum BoneSelector
    {
        Head = (1 << 0),
        Chest = (1 << 1),
        Stomach = (1 << 2),
        Neck = (1 << 3),
    };

    public static class WeaponConfig
    {
        #region AimBot
        public static bool bAimbotEnabled = false;
        public static bool bVisibleCheck = false;
        public static bool bTargetOnGroundCheck = false;
        public static int iAimbotDeathBreak = 350;
        public static float flAimbotFov = 3f;
        public static float flAimbotSmooth = 20f;
        #endregion
        #region RecoilControlSystem
        public static int iBones = (int)BoneSelector.Head;
        public static float Vertical = 7f;
        public static float Horizontal = 7f;
        public static bool bRCS = false;
        #endregion
    }

    public static class Config
    {
        public static bool bBhopEnabled = false;
        public static bool bTriggerbotEnabled = false;
        public static bool bTriggerbotCheckWall = false;


        #region GlobalsConfig
        public static bool AimbotEnabled = true;
        public static bool MiscEnabled = false;
        public static bool ESPEnabled = true;
        public static int iAimbotKey = 1;
        public static int iPanicKey = 0x2E; //delete
        #endregion

        #region GlowESP
        public static bool bGlowEnabled = false;
        public static bool bGlowEnemy = false;
        public static bool bGlowAlly = false;
        public static bool bInnerGlow = false;
        public static bool bFullRender = false;
        public static bool bGlowAfterDeath = false;
        public static bool bGlowWeapons = false;
        public static bool bGlowBomb = false;
        public static GlowType iGlowType = GlowType.Health;
        public static int iGlowToogleKey = -1;
        public static Color bGlowEnemyColor = new Color(200, 0, 0, 200);
        public static Color bGlowEnemyVisibleColor = new Color(255, 0, 65, 150);
        public static Color bGlowAllyColor = new Color(200, 200, 0, 200);
        public static Color bGlowAllyVisibleColor = new Color(0, 169, 251, 150);

        #endregion

        #region AutoAccept&ShowRanks
        public static bool bAutoAccept = false;
        public static bool bShowRanks = false;
        #endregion

        #region ClantagChanger
        public static bool bClanTagChangerEnabled = false;
        public static int iClanTagChanger = 0;
        public static string szClanTag = "saintware";
        public static int iClantTagDelay = 250;
        #endregion
    }
}
