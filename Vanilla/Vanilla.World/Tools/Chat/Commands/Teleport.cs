using System;
using System.Collections.Generic;
using System.Linq;
using Vanilla.World.Communication.Outgoing.Players;
using Vanilla.World.Tools.Database.Helpers;

namespace Vanilla.World.Tools.Chat.Commands
{
	public class TeleportEntry
	{
		public string Name;
		public int MapID;
		public float X;
		public float Y;
		public float Z;

		public TeleportEntry(string name, int mapID, float x, float y, float z)
		{
			Name = name;
			mapID = MapID;
			X = x;
			Y = y;
			Z = z;
		}
	}

	public class DistanceTeleportEntry
	{
		public int Distance;
		public TeleportEntry Entry;

	}
	[ChatCommandNode("tele", "Tele commands")]
    public class Teleport
    {
		public static List<TeleportEntry> Teleports;

		[ChatCommand("warp", "")]
		public static void Warp(WorldSession session, string[] args)
		{
			if (Teleports == null) AddTeleports();

			string locationName = args[0];

			DistanceTeleportEntry location = FetchList(locationName).First();

			session.Character.MapID = location.Entry.MapID;
			session.Character.X = location.Entry.X;
			session.Character.Y = location.Entry.Y;
			session.Character.Z = location.Entry.Z;
			session.Character.Rotation = 0;
			DBCharacters.UpdateCharacter(session.Character);

			session.sendPacket(new PSTransferPending(location.Entry.MapID));
			session.sendPacket(new PSNewWorld(location.Entry.MapID, location.Entry.X, location.Entry.Y, location.Entry.Z, 0));
		}

        [ChatCommand("list", "")]
        public static void Lookup(WorldSession session, string[] args)
        {
			if(Teleports == null) AddTeleports();

            string locationName = args[0];

			List<DistanceTeleportEntry> locations  = FetchList(locationName);

			if(locations.Count > 10) locations = locations .GetRange(0, 10);

			session.sendMessage("-- Tele List --");
			locations.ForEach(e => session.sendMessage(e.Distance + " - " + e.Entry.Name));
			session.sendMessage(" ");
		}



		public static List<DistanceTeleportEntry> FetchList(string name)
		{
			List<DistanceTeleportEntry> pow = new List<DistanceTeleportEntry>();

			foreach (TeleportEntry tele in Teleports)
			{
				try
				{
					if (tele.Name.ToLower().Contains(name.ToLower()))
					{
						pow.Add(new DistanceTeleportEntry() { Distance = LevenshteinDistance(name.ToLower(), tele.Name.ToLower()), Entry = tele });
					}
				}
				catch (Exception e)
				{
					Console.Write("D");
				}
			}


			return pow.Count <= 1 ? pow : pow.OrderBy(d => d.Distance).ToList();
		}

		public static int LevenshteinDistance(string s, string t)
		{
			int n = s.Length;
			int m = t.Length;
			int[,] d = new int[n + 1, m + 1];
			if (n == 0)
			{
				return m;
			}
			if (m == 0)
			{
				return n;
			}
			for (int i = 0; i <= n; d[i, 0] = i++)
				;
			for (int j = 0; j <= m; d[0, j] = j++)
				;
			for (int i = 1; i <= n; i++)
			{
				for (int j = 1; j <= m; j++)
				{
					int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;
					d[i, j] = Math.Min(
						Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
						d[i - 1, j - 1] + cost);
				}
			}
			return d[n, m];
		}

		public static void AddTeleports()
		{
			Teleports = new List<TeleportEntry>();

			Teleports.Add(new TeleportEntry("AbyssalSands", 1, -8109.34f, -3067.48f, 39.9773f));
			Teleports.Add(new TeleportEntry("AddlesStead", 0, -10992.6f, 268.794f, 28.5101f));
			Teleports.Add(new TeleportEntry("AeriePeak", 0, 327.814f, -1959.99f, 198.724f));
			Teleports.Add(new TeleportEntry("AgamandMills", 0, 2803.27f, 847.119f, 112.841f));
			Teleports.Add(new TeleportEntry("AgmondsEnd", 0, -7027.81f, -3330.11f, 242.51f));
			Teleports.Add(new TeleportEntry("AgolWatha", 0, 339.304f, -3469.39f, 119.433f));
			Teleports.Add(new TeleportEntry("AlcazIsland", 1, -2657.63f, -4896.05f, 22.3726f));
			Teleports.Add(new TeleportEntry("Aldrassil", 1, 10455.7f, 798.455f, 1347.75f));
			Teleports.Add(new TeleportEntry("AlexstonFarmsted", 0, -10644.8f, 1681.3f, 43.0338f));
			Teleports.Add(new TeleportEntry("AlgazStation", 0, -4909.52f, -2726.76f, 330.06f));
			Teleports.Add(new TeleportEntry("AltarOfStormsA", 0, -11272.8f, -2547.59f, 103.02f));
			Teleports.Add(new TeleportEntry("AltarOfStormsB", 0, -7613.13f, -761.492f, 191.807f));
			Teleports.Add(new TeleportEntry("AltarOfZul", 0, -295.384f, -3459.12f, 195.005f));
			Teleports.Add(new TeleportEntry("AlteracValley", 30, 628.53f, -207.67f, 40.0523f));
			Teleports.Add(new TeleportEntry("AlthersMill", 0, -9168.66f, -2726.31f, 91.0426f));
			Teleports.Add(new TeleportEntry("Ambermill", 0, -126.954f, 815.624f, 67.0224f));
			Teleports.Add(new TeleportEntry("AmethAran", 1, 5732.53f, 116.359f, 32.5681f));
			Teleports.Add(new TeleportEntry("AngorFortress", 0, -6380.77f, -3139.89f, 302.111f));
			Teleports.Add(new TeleportEntry("Anvilmar", 0, -6110.8f, 388.517f, 396.542f));
			Teleports.Add(new TeleportEntry("ApocryphansRest", 0, -6894.29f, -2465.82f, 248.978f));
			Teleports.Add(new TeleportEntry("ArathiBasin", 529, 1181.62f, 1183.39f, -44.329f));
			Teleports.Add(new TeleportEntry("ArathiHighlands", 0, -907.865f, -3534.24f, 84.7878f));
			Teleports.Add(new TeleportEntry("AridensCamp", 0, -10443.6f, -2140.79f, 91.7795f));
			Teleports.Add(new TeleportEntry("Ashenvale", 1, 3469.43f, 847.62f, 6.36476f));
			Teleports.Add(new TeleportEntry("Astranaar", 1, 2745.85f, -378.33f, 109.253f));
			Teleports.Add(new TeleportEntry("Auberdine", 1, 6438.69f, 485.38f, 8.382f));
			Teleports.Add(new TeleportEntry("Azshara", 1, 2717.1f, -5968.91f, 107.4f));
			Teleports.Add(new TeleportEntry("AzureloadHumanTown", 0, -11033f, -3095.22f, 90.8189f));
			Teleports.Add(new TeleportEntry("BaelDunDigside", 1, -1897.98f, 400.675f, 135.787f));
			Teleports.Add(new TeleportEntry("BaelModan", 1, -4074.33f, -2094.19f, 94.2936f));
			Teleports.Add(new TeleportEntry("BallalRuins", 0, -11977.4f, 332.254f, 4.20626f));
			Teleports.Add(new TeleportEntry("BalnirFarmstead", 0, 2032.01f, -432.954f, 36.4329f));
			Teleports.Add(new TeleportEntry("Balwark", 0, 1716.02f, -788.217f, 57.844f));
			Teleports.Add(new TeleportEntry("BaradinBay", 0, -2955f, -1022.21f, 11.0919f));
			Teleports.Add(new TeleportEntry("Barrens", 1, 90.1003f, -1943.44f, 80.4727f));
			Teleports.Add(new TeleportEntry("BarrensGnollOutpost", 1, -4319.38f, -2110.38f, 81.8662f));
			Teleports.Add(new TeleportEntry("BashalAran", 1, 6735.43f, 6.71422f, 43.7028f));
			Teleports.Add(new TeleportEntry("BeezilsZepellinsWreck", 1, -4006.19f, -3777.83f, 41.6804f));
			Teleports.Add(new TeleportEntry("BeggarsHaunt", 0, -10359.9f, -1531.75f, 92.5352f));
			Teleports.Add(new TeleportEntry("BehindTheGreymaneWall", 0, -987.449f, 1585.69f, 54.4298f));
			Teleports.Add(new TeleportEntry("BlackfathomDeep", 48, -152.984f, 106.33f, -39.0953f));
			Teleports.Add(new TeleportEntry("BlackMorass", 269, -2061.12f, 6635.97f, -143.596f));
			Teleports.Add(new TeleportEntry("BlackMorassPortal", 269, -2033.5f, 7120.97f, 24.5189f));
			Teleports.Add(new TeleportEntry("BlackMorassUndergroundEntrance", 269, -2014.12f, 6583.5f, -153.654f));
			Teleports.Add(new TeleportEntry("BlackphantomDeeps", 1, 4252.37f, 756.974f, -22.0632f));
			Teleports.Add(new TeleportEntry("BlackrockCamp", 0, -9713.81f, -3188.39f, 59.6835f));
			Teleports.Add(new TeleportEntry("BlackrockDepths", 230, 596.432f, -188.498f, -49f));
			Teleports.Add(new TeleportEntry("BlackrockMountain", 0, -7317.34f, -1072.33f, 278.069f));
			Teleports.Add(new TeleportEntry("BlackRockMountainTop", 0, -7468f, -1082f, 901f));
			Teleports.Add(new TeleportEntry("BlackrockSpire", 229, 73.5083f, -215.044f, 53.3869f));
			Teleports.Add(new TeleportEntry("BlackrockStronghold", 0, -7728.12f, -1504.22f, 133.837f));
			Teleports.Add(new TeleportEntry("BlackrokMountain", 0, -7813.25f, -1133.33f, 215.069f));
			Teleports.Add(new TeleportEntry("BlackwingLair", 469, -7665.55f, -1102.49f, 400.679f));
			Teleports.Add(new TeleportEntry("BlackwolfRiver", 1, 1160.25f, 51.3229f, 2.072f));
			Teleports.Add(new TeleportEntry("BlackwoodDen", 1, 4641.19f, 55.3801f, 67.6307f));
			Teleports.Add(new TeleportEntry("BlackwoodLake", 0, 2515.84f, -4251.86f, 77.3568f));
			Teleports.Add(new TeleportEntry("BladefistBay", 1, 1525.73f, -4968.13f, 18.1397f));
			Teleports.Add(new TeleportEntry("BlastedLands", 0, -11204.5f, -2730.61f, 15.8972f));
			Teleports.Add(new TeleportEntry("BloodhoofVillage", 1, -2326.44f, -367.682f, -7.8497f));
			Teleports.Add(new TeleportEntry("BloodsailCompound", 0, -13274.4f, 769.951f, 3.45505f));
			Teleports.Add(new TeleportEntry("BloodvenomFalls", 1, 5280.03f, -713.61f, 347.129f));
			Teleports.Add(new TeleportEntry("BootyBay", 0, -14406.6f, 419.353f, 23.3907f));
			Teleports.Add(new TeleportEntry("BoughShadow", 1, 3141.82f, -3707.34f, 122.05f));
			Teleports.Add(new TeleportEntry("BoulderfistHall", 0, -1969.08f, -2789.04f, 82.2105f));
			Teleports.Add(new TeleportEntry("BouldersideRavine", 1, -122.391f, 388.013f, 95.4856f));
			Teleports.Add(new TeleportEntry("BrackenwallOrcVillage", 1, -3129.38f, -2864.51f, 35.8711f));
			Teleports.Add(new TeleportEntry("BrackwellPumpkinPatch", 0, -9772.44f, -869.693f, 40.5096f));
			Teleports.Add(new TeleportEntry("BramblebladeRavine", 1, -3037.04f, -1050.56f, 50.1447f));
			Teleports.Add(new TeleportEntry("BrewnallVillage", 0, -5368.81f, 319.498f, 395.123f));
			Teleports.Add(new TeleportEntry("BrightwaterLake", 0, 2685.13f, -198.851f, 32.4095f));
			Teleports.Add(new TeleportEntry("BrightwoodGrove", 0, -10649.7f, -884.01f, 51.8196f));
			Teleports.Add(new TeleportEntry("Brill", 0, 2255.5f, 288.511f, 35.1138f));
			Teleports.Add(new TeleportEntry("Bulwark", 0, 1636.09f, -1011.36f, 77.1124f));
			Teleports.Add(new TeleportEntry("CaerDarrow", 0, 1025.59f, -2517f, 60.1416f));
			Teleports.Add(new TeleportEntry("CaerDarrowTheDarkPortal", 0, 1125.31f, -2541.35f, 79.3562f));
			Teleports.Add(new TeleportEntry("CampBoff", 0, -7033.94f, -3669.89f, 246.91f));
			Teleports.Add(new TeleportEntry("CampCagg", 0, -7147.67f, -2430.87f, 241.51f));
			Teleports.Add(new TeleportEntry("CampCosh", 0, -6247.73f, -3776.6f, 250.06f));
			Teleports.Add(new TeleportEntry("CampMojache", 1, -4369.68f, 242.294f, 26.4133f));
			Teleports.Add(new TeleportEntry("CampNarache", 1, -2893.04f, -240.87f, 54.5445f));
			Teleports.Add(new TeleportEntry("CampTaurajo", 1, -2372.51f, -1991.64f, 121.975f));
			Teleports.Add(new TeleportEntry("Cauldron", 0, -6892.24f, -1342.38f, 240.913f));
			Teleports.Add(new TeleportEntry("CavernsOfTime", 1, -8195.94f, -4500.13f, 9.60819f));
			Teleports.Add(new TeleportEntry("CenarionEnclave", 1, 10118.4f, 2538.5f, 1322.52f));
			Teleports.Add(new TeleportEntry("CenarionHold", 1, -6824.15f, 821.273f, 50.6675f));
			Teleports.Add(new TeleportEntry("ChampionHall", 449, -0.199573f, -1.59112f, 0.744116f));
			Teleports.Add(new TeleportEntry("CharredVale", 1, 821.99f, 1599.07f, -20.1896f));
			Teleports.Add(new TeleportEntry("ChillwindPoint", 0, 322.373f, -1487.85f, 44.7201f));
			Teleports.Add(new TeleportEntry("CircleOfEastBinding", 0, -842.604f, -3270.04f, 79.3588f));
			Teleports.Add(new TeleportEntry("CircleOfInnerBinding", 0, -1529.75f, -2166.7f, 18.3717f));
			Teleports.Add(new TeleportEntry("CircleOfOuterBinding", 0, -1354.4f, -2738.07f, 59.9657f));
			Teleports.Add(new TeleportEntry("CircleOfWestBinding", 0, -863.118f, -1784.72f, 40.6118f));
			Teleports.Add(new TeleportEntry("CleftOfShadow", 1, 1805.41f, -4337.11f, -10.1877f));
			Teleports.Add(new TeleportEntry("CliffspringRiver", 1, 6931.74f, -569.077f, 45.8192f));
			Teleports.Add(new TeleportEntry("ColdHearthManor", 0, 2146.99f, 658.485f, 34.59f));
			Teleports.Add(new TeleportEntry("ColdridgeValley", 0, -6229.25f, 333.733f, 384.206f));
			Teleports.Add(new TeleportEntry("Commons", 0, -4920.61f, -955.967f, 502.51f));
			Teleports.Add(new TeleportEntry("CorinsCrossing", 0, 2039.73f, -4511.63f, 74.6218f));
			Teleports.Add(new TeleportEntry("CraftmensTerrace", 1, 10094.3f, 2319.44f, 1330.17f));
			Teleports.Add(new TeleportEntry("CragpoolLake", 1, 1618.33f, 161.796f, 134.084f));
			Teleports.Add(new TeleportEntry("Crossroads", 1, -456.263f, -2652.7f, 96.615f));
			Teleports.Add(new TeleportEntry("CrownGuardTower", 0, 1868.66f, -3678.97f, 156.231f));
			Teleports.Add(new TeleportEntry("CrystalLake", 0, -9462.99f, -161.312f, 61.7274f));
			Teleports.Add(new TeleportEntry("DabyriesFarmstead", 0, -1065.89f, -2905.56f, 43.0958f));
			Teleports.Add(new TeleportEntry("DaggerHills", 0, -11275.5f, 1448.2f, 90.0785f));
			Teleports.Add(new TeleportEntry("Dalaran", 0, 258f, 351f, 42.9076f));
			Teleports.Add(new TeleportEntry("DalaranRuins", 0, 386.938f, 212.299f, 44.6994f));
			Teleports.Add(new TeleportEntry("DalsonsTears", 0, 1855.13f, -1569.22f, 60.1825f));
			Teleports.Add(new TeleportEntry("DandredsFold", 0, 1239.12f, -286.705f, 43.4764f));
			Teleports.Add(new TeleportEntry("DarkcloudPinnacle", 1, -5096.02f, -1945.14f, 89.7375f));
			Teleports.Add(new TeleportEntry("DarkenedBank", 0, -10015.9f, -575.457f, 43.7515f));
			Teleports.Add(new TeleportEntry("DarkPortal", 0, -11853.6f, -3197.44f, -26.2186f));
			Teleports.Add(new TeleportEntry("Darkshire", 0, -10559.7f, -1189.02f, 29.0698f));
			Teleports.Add(new TeleportEntry("Darkshore", 1, 6207.5f, -152.833f, 80.8185f));
			Teleports.Add(new TeleportEntry("DarkwhisperGorge", 1, 5018.91f, -4563.94f, 852.75f));
			Teleports.Add(new TeleportEntry("Darnassus", 1, 8795.8f, 969.427f, 31.1955f));
			Teleports.Add(new TeleportEntry("DarrowHillsCorners", 0, -434.575f, -587.045f, 54.6605f));
			Teleports.Add(new TeleportEntry("DarrowmereLake", 0, 1234.83f, -2118.49f, 51.8011f));
			Teleports.Add(new TeleportEntry("DawningIsles", 0, 982.34f, 201.239f, 35.9509f));
			Teleports.Add(new TeleportEntry("DeadAcre", 0, -10776.2f, 881.872f, 34.9199f));
			Teleports.Add(new TeleportEntry("DeadeyeShore", 1, 918.715f, -5115.69f, 3.85835f));
			Teleports.Add(new TeleportEntry("DeadField", 0, 1035.91f, 1540.85f, 31.525f));
			Teleports.Add(new TeleportEntry("DeadmansCrossing", 0, -10460.6f, -1717.5f, 84.5969f));
			Teleports.Add(new TeleportEntry("Deadmines", 0, -11156.8f, 1528.99f, 20.4102f));
			Teleports.Add(new TeleportEntry("DeadwindPass", 0, -10435.4f, -1809.28f, 101f));
			Teleports.Add(new TeleportEntry("Deathknell", 0, 1871.14f, 1587.91f, 92.2143f));
			Teleports.Add(new TeleportEntry("DecrepitFairy", 0, 675.698f, 974.873f, 35.8849f));
			Teleports.Add(new TeleportEntry("DeepElemMine", 0, 374.222f, 1083.9f, 107.509f));
			Teleports.Add(new TeleportEntry("DeeprunTram", 369, 69.2542f, 10.257f, -3.29664f));
			Teleports.Add(new TeleportEntry("DeepwaterTavern", 0, -3823.06f, -834.526f, 19.2789f));
			Teleports.Add(new TeleportEntry("DemonFallCanyon", 1, 1798.75f, -3179.82f, 93.0128f));
			Teleports.Add(new TeleportEntry("Den", 1, -604.922f, -4156.99f, 44.2112f));
			Teleports.Add(new TeleportEntry("DenOfFlame", 1, -4336.82f, -3018.67f, 34.1744f));
			Teleports.Add(new TeleportEntry("DesertOutpostWaterfall", 1, 10389f, -1886.06f, 184.379f));
			Teleports.Add(new TeleportEntry("Desolace", 1, -93.1614f, 1691.15f, 90.0649f));
			Teleports.Add(new TeleportEntry("DireforgeHill", 0, -2833.45f, -2880.43f, 33.8865f));
			Teleports.Add(new TeleportEntry("DireMaul", 429, 254.588f, -24.7395f, -1.56062f));
			Teleports.Add(new TeleportEntry("Donalaar", 1, 9809.05f, 959.188f, 1316.35f));
			Teleports.Add(new TeleportEntry("DordanilBarrowDen", 1, 1775.1f, -2679.19f, 112.666f));
			Teleports.Add(new TeleportEntry("DracoDar", 0, -8222.08f, -1174.15f, 143.557f));
			Teleports.Add(new TeleportEntry("DraenorDarkPortal", 0, -14958.5f, 12761.6f, 37.0388f));
			Teleports.Add(new TeleportEntry("Drag", 1, 1860.46f, -4513.91f, 24.657f));
			Teleports.Add(new TeleportEntry("DragonmawGarrison", 469, -7621.59f, -1071.48f, 409.49f));
			Teleports.Add(new TeleportEntry("DragonmawGates", 0, -3465.16f, -3727.56f, 65.5778f));
			Teleports.Add(new TeleportEntry("Dragonmurk", 1, -4197.56f, -2873.76f, 45.6771f));
			Teleports.Add(new TeleportEntry("DreadmaulHold", 0, -10859f, -2663.38f, 8.80049f));
			Teleports.Add(new TeleportEntry("DreadmaulPost", 0, -11528.2f, -2863.73f, 10.9925f));
			Teleports.Add(new TeleportEntry("DreadmaulRock", 0, -7924.68f, -2624.44f, 221.958f));
			Teleports.Add(new TeleportEntry("DreadmurkShore", 1, -3012.72f, -4345.51f, 7.83608f));
			Teleports.Add(new TeleportEntry("DreamBough", 1, -2871.76f, 1885.29f, 53.6501f));
			Teleports.Add(new TeleportEntry("DrownedReef", 0, -2200.52f, -1685.18f, -33.4569f));
			Teleports.Add(new TeleportEntry("DunAlgaz", 0, -4088.67f, -2663.71f, 36.1151f));
			Teleports.Add(new TeleportEntry("DunBaldar", 30, 654.691f, -31.7338f, 49.6277f));
			Teleports.Add(new TeleportEntry("DunBaldarPass", 30, 757.831f, -489.322f, 96.8441f));
			Teleports.Add(new TeleportEntry("DunemaulCompound", 1, -8492.54f, -3022.39f, 10.374f));
			Teleports.Add(new TeleportEntry("DunGarok", 0, -1266.15f, -1198.95f, 41.1765f));
			Teleports.Add(new TeleportEntry("DunModr", 0, -2605.21f, -2341.09f, 84.3551f));
			Teleports.Add(new TeleportEntry("DunMorogh", 0, -5660.33f, 755.299f, 390.605f));
			Teleports.Add(new TeleportEntry("DurnholdeKeep", 0, -489.832f, -1391.35f, 54.3854f));
			Teleports.Add(new TeleportEntry("Durotar", 1, 341.42f, -4684.7f, 31.9493f));
			Teleports.Add(new TeleportEntry("Duskwood", 0, -10517f, -1158.39f, 40.0542f));
			Teleports.Add(new TeleportEntry("DustfireValley", 0, -6634.28f, -1876.38f, 245.144f));
			Teleports.Add(new TeleportEntry("DustPlains", 0, -11116.3f, 585.337f, 35.4177f));
			Teleports.Add(new TeleportEntry("DustwallowMarsh", 1, -3463.26f, -4123.13f, 18.1043f));
			Teleports.Add(new TeleportEntry("EasternStrand", 0, -1234.91f, -943.205f, 9.62585f));
			Teleports.Add(new TeleportEntry("EastmoonRuins", 1, -8867.71f, -3435.86f, 14.3515f));
			Teleports.Add(new TeleportEntry("EastvaleLoggingCamp", 0, -9549f, -1407.04f, 55.7673f));
			Teleports.Add(new TeleportEntry("EastwallTower", 0, 2545.24f, -4773.8f, 108.254f));
			Teleports.Add(new TeleportEntry("EchoIsles", 1, -1124.19f, -5535.02f, 9.62076f));
			Teleports.Add(new TeleportEntry("ElderRise", 1, -1056.81f, -239.942f, 160.03f));
			Teleports.Add(new TeleportEntry("ElwynnForest", 0, -9465.58f, 16.8472f, 66.921f));
			Teleports.Add(new TeleportEntry("EmeraldForestStatue", 169, 3105.41f, 3096.78f, 28.0032f));
			Teleports.Add(new TeleportEntry("EmeraldForestTrees", 169, 2732.93f, -3319.63f, 102.284f));
			Teleports.Add(new TeleportEntry("EmeraldSanctuary", 1, 3989.18f, -1292.13f, 252.131f));
			Teleports.Add(new TeleportEntry("Everlook", 1, 6721.44f, -4659.09f, 721.893f));
			Teleports.Add(new TeleportEntry("FaldinsCove", 0, -2086.88f, -2074.57f, 6.72927f));
			Teleports.Add(new TeleportEntry("FalfarrenRiver", 1, 1979.07f, -1968.07f, 100.103f));
			Teleports.Add(new TeleportEntry("FallowSactuary", 0, -9980.38f, -3568.28f, 23.0569f));
			Teleports.Add(new TeleportEntry("FargodeepMine", 0, -9811.76f, 130.16f, 7.86f));
			Teleports.Add(new TeleportEntry("FeathermoonStronghold", 1, -4411.09f, 3228.02f, 13.1294f));
			Teleports.Add(new TeleportEntry("FelfireHill", 1, 1992.85f, -2989.66f, 108.111f));
			Teleports.Add(new TeleportEntry("FelstoneField", 0, 1756.79f, -1200.15f, 61.7352f));
			Teleports.Add(new TeleportEntry("Felwood", 1, 5483.9f, -749.881f, 335.621f));
			Teleports.Add(new TeleportEntry("FenrisIsle", 0, 731.866f, 727.793f, 38.0975f));
			Teleports.Add(new TeleportEntry("FenrisKeep", 0, 960.45f, 689.611f, 60.7365f));
			Teleports.Add(new TeleportEntry("Feralas", 1, -4458.93f, 243.415f, 65.6136f));
			Teleports.Add(new TeleportEntry("FeralasCoast", 1, -4522.22f, 2038.54f, 51.1436f));
			Teleports.Add(new TeleportEntry("FieldOfGiants", 1, -3120.86f, -2327.89f, 94.1243f));
			Teleports.Add(new TeleportEntry("FieldOfStrife", 30, -187.386f, -293.948f, 7.66753f));
			Teleports.Add(new TeleportEntry("FirePlumeRidge", 1, -7171.68f, -1279.85f, -183.424f));
			Teleports.Add(new TeleportEntry("FirewatchRidge", 0, -6646.51f, -829.166f, 245.161f));
			Teleports.Add(new TeleportEntry("ForestSong", 1, 2943.75f, -3304.34f, 155.067f));
			Teleports.Add(new TeleportEntry("ForgottenCoast", 1, -4508.92f, 2041.68f, 52.3872f));
			Teleports.Add(new TeleportEntry("ForgottenPools", 1, 110.197f, -1891.39f, 94.5444f));
			Teleports.Add(new TeleportEntry("ForlornCavern", 0, -4637.04f, -1101.53f, 502.281f));
			Teleports.Add(new TeleportEntry("ForstriderLodge", 0, -5675.42f, -4244.87f, 408.002f));
			Teleports.Add(new TeleportEntry("FrayIsland", 1, -1679.3f, -4328.96f, 3.58591f));
			Teleports.Add(new TeleportEntry("FreewindPost", 1, -5437.4f, -2437.47f, 90.3083f));
			Teleports.Add(new TeleportEntry("FrostfireHotSprings", 1, 6831.96f, -2494.93f, 559.434f));
			Teleports.Add(new TeleportEntry("FrostmaneHold", 0, -5584.21f, 759.832f, 385.29f));
			Teleports.Add(new TeleportEntry("FrostsaberRock", 1, 8070.18f, -3859.56f, 689.782f));
			Teleports.Add(new TeleportEntry("FrostwishperGorge", 1, 5274.15f, -4712.21f, 692.124f));
			Teleports.Add(new TeleportEntry("FrostWolfKeep", 30, -1326.63f, -297.884f, 91.536f));
			Teleports.Add(new TeleportEntry("FrostWolfVillage", 30, -1201.05f, -366.444f, 55.0976f));
			Teleports.Add(new TeleportEntry("FrostwyrmLair", 533, 3498.27f, -5349.45f, 145.967f));
			Teleports.Add(new TeleportEntry("FungalRocks", 1, -6401.51f, -1755.86f, -271.256f));
			Teleports.Add(new TeleportEntry("FungalVale", 0, 2448.25f, -3703.94f, 180.083f));
			Teleports.Add(new TeleportEntry("FurlbrowsPumpkinPatch", 0, -9903.53f, 1245.26f, 43.0563f));
			Teleports.Add(new TeleportEntry("Gadgetzan", 1, -7154.86f, -3817.94f, 9.39779f));
			Teleports.Add(new TeleportEntry("GahrronsWithering", 0, 1738.52f, -2319.93f, 60.5751f));
			Teleports.Add(new TeleportEntry("GapingChasm", 1, -9311.04f, -3945.9f, 11.6628f));
			Teleports.Add(new TeleportEntry("GarrensHaunt", 0, 2861.67f, 398.526f, 22.1504f));
			Teleports.Add(new TeleportEntry("GelkisVillage", 1, -2222.47f, 2522.4f, 69.4424f));
			Teleports.Add(new TeleportEntry("GhostWalkerPost", 1, -1156.34f, 1894.49f, 87.2854f));
			Teleports.Add(new TeleportEntry("GiantOrcStatue", 0, -8066.68f, -1621.66f, 133.982f));
			Teleports.Add(new TeleportEntry("GilijimsIsle", 0, -13693.5f, 2806.3f, 57.6918f));
			Teleports.Add(new TeleportEntry("GM1", 1, -11805.5f, -4754.13f, 6.96693f));
			Teleports.Add(new TeleportEntry("GM2", 1, -10735.8f, 2463.19f, 7.8301f));
			Teleports.Add(new TeleportEntry("GMIsland", 1, 16222.6f, 16265.9f, 14.2085f));
			Teleports.Add(new TeleportEntry("GnarlpineHold", 1, 9114.65f, 1846.06f, 1328.5f));
			Teleports.Add(new TeleportEntry("Gnomeregan", 0, -5189.22f, 524.796f, 389.107f));
			Teleports.Add(new TeleportEntry("GnomereganTrainDepot", 0, -4858.27f, 756.435f, 245.923f));
			Teleports.Add(new TeleportEntry("GoblinObeservatory", 1, -10082.2f, -5656.43f, 7.24787f));
			Teleports.Add(new TeleportEntry("GolakkaHotSprings", 1, -7196.37f, -630.695f, -232.64f));
			Teleports.Add(new TeleportEntry("GolBolarQuarry", 0, -5826.35f, -1586.57f, 365.269f));
			Teleports.Add(new TeleportEntry("Goldshire", 0, -9460.25f, 63.0612f, 56.8335f));
			Teleports.Add(new TeleportEntry("GoShekFarm", 0, -1505.51f, -3030.52f, 13.627f));
			Teleports.Add(new TeleportEntry("GreatForge", 0, -4795.88f, -1113.26f, 499.807f));
			Teleports.Add(new TeleportEntry("GreatLift", 1, -4619.15f, -1850.91f, 87.0563f));
			Teleports.Add(new TeleportEntry("GreatwoodVale", 1, -87.9634f, -565.775f, -11.1339f));
			Teleports.Add(new TeleportEntry("GreenBelt", 0, -3256.88f, -2718.36f, 10.4121f));
			Teleports.Add(new TeleportEntry("GreenpawVillage", 1, 2265.59f, -1475.33f, 91.8082f));
			Teleports.Add(new TeleportEntry("GreymaneWall", 0, -757.376f, 1527.28f, 18.2465f));
			Teleports.Add(new TeleportEntry("GrimBatol", 0, -4053.99f, -3450.62f, 284.383f));
			Teleports.Add(new TeleportEntry("GrimeslitDigSite", 0, -6986.92f, -1705.54f, 242.667f));
			Teleports.Add(new TeleportEntry("GromGolBaseCamp", 0, -12352.8f, 211.452f, 5.5846f));
			Teleports.Add(new TeleportEntry("GrommashHold", 1, 1926.92f, -4220.35f, 41.9464f));
			Teleports.Add(new TeleportEntry("GroveOfTheAncients", 1, 4995.94f, 82.9197f, 55.3857f));
			Teleports.Add(new TeleportEntry("GunthersRetreat", 0, 2563.98f, -51.7975f, 32.7441f));
			Teleports.Add(new TeleportEntry("GurubashiArena", 0, -13152.9f, 342.729f, 53.1328f));
			Teleports.Add(new TeleportEntry("HallOfBlackhand", 229, -78.5819f, -401.395f, 39.9428f));
			Teleports.Add(new TeleportEntry("HallOfExplorers", 0, -4697.59f, -1229.28f, 502.659f));
			Teleports.Add(new TeleportEntry("HallOfLegends", 1, 1639.22f, -4238.83f, 57.166f));
			Teleports.Add(new TeleportEntry("Hammerfall", 0, -950.584f, -3533.13f, 72.8318f));
			Teleports.Add(new TeleportEntry("HammertoesDigsite", 0, -6411.58f, -3409.85f, 242.537f));
			Teleports.Add(new TeleportEntry("Headland", 0, 15.1686f, -337.262f, 131.995f));
			Teleports.Add(new TeleportEntry("HelmsBedLake", 0, -5607.39f, -1984.16f, 397.373f));
			Teleports.Add(new TeleportEntry("HeroesVigil", 0, -9136.28f, -1053.89f, 71.624f));
			Teleports.Add(new TeleportEntry("HiddenGrove", 1, 7641.78f, -4935.77f, 697.609f));
			Teleports.Add(new TeleportEntry("HiddenPath", 1, -844.333f, -4217.06f, 89.6684f));
			Teleports.Add(new TeleportEntry("Highperch", 1, -5000.46f, -940.209f, -4.58816f));
			Teleports.Add(new TeleportEntry("HillsbradFields", 0, -501.505f, 91.4121f, 60.0582f));
			Teleports.Add(new TeleportEntry("HillsbradFoothill", 0, -852.854f, -576.712f, 21.0293f));
			Teleports.Add(new TeleportEntry("HiveAshi", 1, -6543.32f, 800.877f, 3.60826f));
			Teleports.Add(new TeleportEntry("HiveRegal", 1, -7681.92f, 795.932f, -2.05396f));
			Teleports.Add(new TeleportEntry("HiveZora", 1, -7250.49f, 1472.88f, -2.97554f));
			Teleports.Add(new TeleportEntry("HunterRise", 1, -1403.11f, -78.5278f, 159.935f));
			Teleports.Add(new TeleportEntry("Hyjal", 1, 4674.88f, -3638.37f, 966.264f));
			Teleports.Add(new TeleportEntry("HyjalCoolAncientStatue", 1, 4491.35f, -3201.77f, 1027.57f));
			Teleports.Add(new TeleportEntry("HyjalPlainsUnifinishedLocation", 1, 5300.18f, -2292.83f, 945.186f));
			Teleports.Add(new TeleportEntry("IcebloodGarrison", 30, -476.417f, -196.086f, 55.7934f));
			Teleports.Add(new TeleportEntry("IceflowLake", 0, -5090.17f, 71.2283f, 395.33f));
			Teleports.Add(new TeleportEntry("IcewingBunker", 30, 234.481f, -395.528f, 44.2359f));
			Teleports.Add(new TeleportEntry("IcewingPass", 30, 281.568f, 46.1705f, 20.1913f));
			Teleports.Add(new TeleportEntry("Illidan", 564, 691.882f, 305.004f, 278.443f));
			Teleports.Add(new TeleportEntry("IronbandsExcavationSite", 0, -5755.53f, -3998.42f, 331.436f));
			Teleports.Add(new TeleportEntry("IronbeadsTomb", 0, -2849.21f, -2220.06f, 32.3835f));
			Teleports.Add(new TeleportEntry("Ironforge", 0, -4981.25f, -881.542f, 502.66f));
			Teleports.Add(new TeleportEntry("IslandOfDoctorLapidis", 0, -12380.3f, 3400.92f, 49.865f));
			Teleports.Add(new TeleportEntry("IsleOfDread", 1, -6498.47f, 3011.38f, 8.43054f));
			Teleports.Add(new TeleportEntry("IvarPatch", 0, 1285.69f, 1242.33f, 53.6914f));
			Teleports.Add(new TeleportEntry("Jaedenar", 1, 4878.32f, -614.219f, 361.391f));
			Teleports.Add(new TeleportEntry("JagueroIsle", 0, -14740.7f, -432.482f, 5.00624f));
			Teleports.Add(new TeleportEntry("JaneirosPoint", 0, -14178.2f, 712.03f, 30.1868f));
			Teleports.Add(new TeleportEntry("jangolodemine", 0, -10029.2f, 1456.24f, 42.7707f));
			Teleports.Add(new TeleportEntry("JasperlodeMine", 0, -9077.34f, -552.93f, 61.35f));
			Teleports.Add(new TeleportEntry("JinthaAlor", 0, -678.757f, -4018.61f, 239.351f));
			Teleports.Add(new TeleportEntry("Kalimdor", 1, 6744.98f, 41.12f, 48.6f));
			Teleports.Add(new TeleportEntry("karazhan", 532, -11106.9f, -2001.8f, 49.8913f));
			Teleports.Add(new TeleportEntry("KarazhanEntrance", 532, -11106.5f, -2001.64f, 50.8927f));
			Teleports.Add(new TeleportEntry("Kargath", 0, -6657.35f, -2157.1f, 265.133f));
			Teleports.Add(new TeleportEntry("KargathiaOrcOutpost", 1, 2439.16f, -3500.08f, 99.5954f));
			Teleports.Add(new TeleportEntry("KargathOrcOutpost", 0, -6675.96f, -2188.29f, 247.152f));
			Teleports.Add(new TeleportEntry("Kharanos", 0, -5582.32f, -463.982f, 403f));
			Teleports.Add(new TeleportEntry("KodoGraveyard", 1, -1305.19f, 1837.56f, 56.731f));
			Teleports.Add(new TeleportEntry("KolkarCrag", 1, -1028.63f, -4599.8f, 26.5756f));
			Teleports.Add(new TeleportEntry("KolkarVillage", 1, -939.787f, 1091.4f, 94.8119f));
			Teleports.Add(new TeleportEntry("KurzensCompound", 0, -11586.5f, -657.662f, 33.9941f));
			Teleports.Add(new TeleportEntry("LakeAlAmeth", 1, 9534.08f, 730.105f, 1254.42f));
			Teleports.Add(new TeleportEntry("LakeEverstill", 0, -9319f, -1937.94f, 59.0698f));
			Teleports.Add(new TeleportEntry("Lakeshire", 0, -9282.98f, -2269.64f, 70.39f));
			Teleports.Add(new TeleportEntry("LakkariTarPits", 1, -6478.21f, -1129.33f, -274.909f));
			Teleports.Add(new TeleportEntry("LethlorRavine", 0, -6935.86f, -4092.06f, 286.906f));
			Teleports.Add(new TeleportEntry("LiftsToGround", 1, -1035.63f, -24.082f, 141.694f));
			Teleports.Add(new TeleportEntry("LightsHopeChapel", 0, 2278.36f, -5311.16f, 88.201f));
			Teleports.Add(new TeleportEntry("LittleCrater", 0, -12238.3f, -2475.1f, -1.82331f));
			Teleports.Add(new TeleportEntry("LochLake", 0, -5201.86f, -3136.59f, 299.761f));
			Teleports.Add(new TeleportEntry("LochModan", 0, -4939.1f, -3423.74f, 306.595f));
			Teleports.Add(new TeleportEntry("Longshore", 0, -10513.9f, 2075.23f, 13.1819f));
			Teleports.Add(new TeleportEntry("LongWash", 1, 5028.14f, 534.745f, 8.28397f));
			Teleports.Add(new TeleportEntry("LordamereInternmentCamp", 0, -74.6376f, 201.212f, 54.2755f));
			Teleports.Add(new TeleportEntry("LordamereLake", 0, 762.653f, 909.072f, 32.2142f));
			Teleports.Add(new TeleportEntry("LostPoint", 1, -3922.24f, -2839.21f, 45.6212f));
			Teleports.Add(new TeleportEntry("LushwaterOasis", 1, -964.776f, -2039.74f, 82.3491f));
			Teleports.Add(new TeleportEntry("MaclureVineyards", 0, -9881.4f, 88.8972f, 34.3196f));
			Teleports.Add(new TeleportEntry("MaestrasPost", 1, 3229.99f, 198.252f, 9.06151f));
			Teleports.Add(new TeleportEntry("MageQuarter", 0, -8979.44f, 851.161f, 106.584f));
			Teleports.Add(new TeleportEntry("MagicQuarter", 0, 1733.62f, 103.444f, -60.857f));
			Teleports.Add(new TeleportEntry("MagramVillage", 1, -1754.33f, 967.89f, 93.5626f));
			Teleports.Add(new TeleportEntry("Magtheridon", 544, 187.535f, 31.6609f, 68.923f));
			Teleports.Add(new TeleportEntry("MakersTerrace", 0, -6092.32f, -3214.55f, 263.727f));
			Teleports.Add(new TeleportEntry("MalakaJin", 1, -191.661f, -301.87f, 13.2698f));
			Teleports.Add(new TeleportEntry("MaldensOrchard", 0, 1414.28f, 1073.22f, 53.4649f));
			Teleports.Add(new TeleportEntry("MannorocCoven", 1, -1879.28f, 1745.49f, 79.8892f));
			Teleports.Add(new TeleportEntry("ManorothCorpse", 0, -13946.7f, 12416.7f, 99.4378f));
			Teleports.Add(new TeleportEntry("Maraudon", 349, 419.84f, 11.3365f, -131.079f));
			Teleports.Add(new TeleportEntry("MardenholdeKeep", 0, 2918.72f, -1439.39f, 151.782f));
			Teleports.Add(new TeleportEntry("MarrisStead", 0, 1868.96f, -3223.39f, 124.065f));
			Teleports.Add(new TeleportEntry("MarshalsRefuge", 1, -6186.57f, -1106.83f, -216.06f));
			Teleports.Add(new TeleportEntry("Marshlands", 1, -7353.57f, -1792.67f, -265.037f));
			Teleports.Add(new TeleportEntry("MastersGlaive", 1, 4565.22f, 438.446f, 33.9133f));
			Teleports.Add(new TeleportEntry("Mazthoril", 1, 6155.21f, -4444.95f, 660.788f));
			Teleports.Add(new TeleportEntry("MenethilBay", 0, -3754.19f, -1087.3f, -0.71875f));
			Teleports.Add(new TeleportEntry("MenethilHarbor", 0, -3740.29f, -755.08f, 11.9643f));
			Teleports.Add(new TeleportEntry("MerchantCoast", 1, -1719.08f, -3824.99f, 13.0836f));
			Teleports.Add(new TeleportEntry("MilitartWard", 0, -4970.65f, -1210.7f, 502.829f));
			Teleports.Add(new TeleportEntry("MirageRaceway", 1, -6202.16f, -3901.68f, -59.2858f));
			Teleports.Add(new TeleportEntry("MirkfallonLake", 1, 1570.64f, 1030.23f, 139.019f));
			Teleports.Add(new TeleportEntry("MirrorLake", 0, -9405.99f, 364.768f, 50.6483f));
			Teleports.Add(new TeleportEntry("MirrorLakeOrchard", 0, -9469.08f, 467.583f, 55.0913f));
			Teleports.Add(new TeleportEntry("MistsEdge", 1, 7742.92f, -769.867f, 6.22102f));
			Teleports.Add(new TeleportEntry("MistyPineRefuge", 0, -5353.18f, -1043.02f, 395.772f));
			Teleports.Add(new TeleportEntry("MistyReedPost", 0, -10849.6f, -4088.17f, 22.7445f));
			Teleports.Add(new TeleportEntry("MistyreedStrand", 0, -10022.2f, -4266.67f, 8.26064f));
			Teleports.Add(new TeleportEntry("MistyValley", 0, -10103.4f, -2431.61f, 29.4491f));
			Teleports.Add(new TeleportEntry("MoGroshStronghold", 0, -4871.78f, -4025.77f, 314.141f));
			Teleports.Add(new TeleportEntry("MoltenBridge", 230, 1097.99f, -466.494f, -95.0719f));
			Teleports.Add(new TeleportEntry("MoltenCore", 409, 1115.22f, -462.959f, -94.0148f));
			Teleports.Add(new TeleportEntry("Moonbrook", 0, -11018.4f, 1513.69f, 44.0152f));
			Teleports.Add(new TeleportEntry("Moonglade", 1, 7999.68f, -2670.2f, 512.2f));
			Teleports.Add(new TeleportEntry("MorgansPlot", 0, -11094.2f, -1829.64f, 73.9926f));
			Teleports.Add(new TeleportEntry("MorgansVigil", 0, -8355.88f, -2752.16f, 185.755f));
			Teleports.Add(new TeleportEntry("Mulgore", 1, -1840.75f, -456.561f, -7.845f));
			Teleports.Add(new TeleportEntry("MulgoreMine", 1, -1915.66f, -1107.44f, 88.572f));
			Teleports.Add(new TeleportEntry("MurlocCamp", 0, -9614.89f, -2613.58f, 58.5311f));
			Teleports.Add(new TeleportEntry("MysticWard", 0, -4678.19f, -968.721f, 502.659f));
			Teleports.Add(new TeleportEntry("MystralLake", 1, 2058.47f, -998.369f, 96.6764f));
			Teleports.Add(new TeleportEntry("Naxxramas", 533, 3005.87f, -3435.01f, 294.882f));
			Teleports.Add(new TeleportEntry("NerubianPits", 1, -7245.6f, 1678.94f, -64.9066f));
			Teleports.Add(new TeleportEntry("NethergardeKeep", 0, -11015.9f, -3326.09f, 62.7594f));
			Teleports.Add(new TeleportEntry("NightElfPortal", 1, 3155f, -3702f, 122f));
			Teleports.Add(new TeleportEntry("Nighthaven", 1, 7978.95f, -2501.13f, 489.986f));
			Teleports.Add(new TeleportEntry("NightSongWood", 1, 2454.38f, -2943.27f, 125f));
			Teleports.Add(new TeleportEntry("NightsongWoods", 1, 2046.82f, -1874.25f, 99.5036f));
			Teleports.Add(new TeleportEntry("NijelsPoint", 1, 147.011f, 1231.58f, 166.476f));
			Teleports.Add(new TeleportEntry("NorthanderStead", 0, -898.266f, -1044.33f, 31.3478f));
			Teleports.Add(new TeleportEntry("NorthCoast", 0, 2955.79f, 99.8215f, 4.32947f));
			Teleports.Add(new TeleportEntry("NorthDale", 0, 3011.49f, -4941.44f, 104.586f));
			Teleports.Add(new TeleportEntry("NorthfoldManor", 0, -797.235f, -2068.95f, 34.8337f));
			Teleports.Add(new TeleportEntry("NorthGateOutpost", 0, -5231.95f, -2366.98f, 399.807f));
			Teleports.Add(new TeleportEntry("NorthpassTower", 0, 3181.78f, -4331.39f, 138.689f));
			Teleports.Add(new TeleportEntry("NorthPointTower", 1, -2855.96f, -3422.66f, 37.7473f));
			Teleports.Add(new TeleportEntry("NorthridgeLumberCamp", 0, 2423.42f, -1646.44f, 105.51f));
			Teleports.Add(new TeleportEntry("Northshire", 0, -9015.92f, -79.4411f, 88.1198f));
			Teleports.Add(new TeleportEntry("NorthshireValley", 0, -9043.76f, -41.5906f, 89.3589f));
			Teleports.Add(new TeleportEntry("NorthshireVineyards", 0, -9092.38f, -368.684f, 74.6163f));
			Teleports.Add(new TeleportEntry("NorthTidesRun", 0, 873.391f, 1852.5f, 6.0548f));
			Teleports.Add(new TeleportEntry("NorthwatchHold", 1, -1986.58f, -3688.25f, 19.3162f));
			Teleports.Add(new TeleportEntry("NoxiousGlade", 0, 2714.32f, -5455.48f, 160.145f));
			Teleports.Add(new TeleportEntry("NoxiousLair", 1, -7779.9f, -2691.72f, 10.1465f));
			Teleports.Add(new TeleportEntry("OldTown", 0, -8722.22f, 409.911f, 98.8349f));
			Teleports.Add(new TeleportEntry("OlsensFarthing", 0, 134.209f, 1496.64f, 115.394f));
			Teleports.Add(new TeleportEntry("OnyxiasLair", 249, 29.4548f, -68.9609f, -5.98402f));
			Teleports.Add(new TeleportEntry("Opthecarium", 0, 1457.61f, 382.548f, -58.2747f));
			Teleports.Add(new TeleportEntry("OracleGlade", 1, 10661.2f, 1875.75f, 1324.46f));
			Teleports.Add(new TeleportEntry("OrcOutpost", 0, -8687.39f, -2330.38f, 156.916f));
			Teleports.Add(new TeleportEntry("Orgrimmar", 1, 1502.71f, -4415.42f, 22.5512f));
			Teleports.Add(new TeleportEntry("OutlandDarkPortal", 0, -11894.8f, -3206.52f, -13.62f));
			Teleports.Add(new TeleportEntry("OutsideHyjalCave", 1, 4817f, -1742f, 1169f));
			Teleports.Add(new TeleportEntry("OverlookCliffs", 0, -69.8514f, -4536f, 18.2892f));
			Teleports.Add(new TeleportEntry("OwlWingThicket", 1, 5671.61f, -4963.66f, 807.429f));
			Teleports.Add(new TeleportEntry("PillarsOfAsh", 0, -8068.39f, -1603.97f, 140.572f));
			Teleports.Add(new TeleportEntry("Plaguewood", 0, 3130.17f, -3401.76f, 140.478f));
			Teleports.Add(new TeleportEntry("PoolOfTears", 0, -10303.5f, -3972.28f, 21.2882f));
			Teleports.Add(new TeleportEntry("PoolsOfArilthrien", 1, 9561.33f, 1743f, 1292.91f));
			Teleports.Add(new TeleportEntry("PoolsOfVision", 1, -1003.42f, 261.579f, 113.153f));
			Teleports.Add(new TeleportEntry("ProgrammerIsland", 451, 16304.2f, 16318.1f, 70.4444f));
			Teleports.Add(new TeleportEntry("PurgationIsle", 0, -1310.1f, 567.088f, 107.402f));
			Teleports.Add(new TeleportEntry("PyrewoodVillage", 0, -416.466f, 1543.87f, 18.5941f));
			Teleports.Add(new TeleportEntry("QuelDanilLodge", 0, 266.941f, -2751.41f, 123.544f));
			Teleports.Add(new TeleportEntry("RagefireChasm", 389, 1.7849f, -14.3685f, -16.5533f));
			Teleports.Add(new TeleportEntry("RandomBayRuins", 0, -11712.7f, -1758.67f, 23.4509f));
			Teleports.Add(new TeleportEntry("RaptorRidge", 0, -3142.5f, -3239.81f, 63.4612f));
			Teleports.Add(new TeleportEntry("Ratchet", 1, -943.935f, -3715.49f, 12.8385f));
			Teleports.Add(new TeleportEntry("RavenHill", 0, -10741.1f, 316.202f, 40.8644f));
			Teleports.Add(new TeleportEntry("RavenHillCemetery", 0, -10316.7f, 342.295f, 60.6454f));
			Teleports.Add(new TeleportEntry("RaynewoodRetreat", 1, 2563.47f, -1698.84f, 155.018f));
			Teleports.Add(new TeleportEntry("RazorfenDowns", 129, 2591.99f, 1101.25f, 52.8593f));
			Teleports.Add(new TeleportEntry("RazorfenKraul", 1, -4464.92f, -1666.24f, 91f));
			Teleports.Add(new TeleportEntry("RazorfenKraulEntrance", 47, 1941.79f, 1543.69f, 82.6615f));
			Teleports.Add(new TeleportEntry("RazorHill", 1, 315.721f, -4743.4f, 10.4867f));
			Teleports.Add(new TeleportEntry("RazorwindCayon", 1, 900.677f, -4634.82f, 18.7876f));
			Teleports.Add(new TeleportEntry("RebelCamp", 0, -11311.5f, -195.19f, 77.3198f));
			Teleports.Add(new TeleportEntry("RedCloudMesa", 1, -2928.26f, -46.1054f, 189.892f));
			Teleports.Add(new TeleportEntry("RedridgeMountains", 0, -9219.37f, -2149.94f, 71.606f));
			Teleports.Add(new TeleportEntry("RedRocks", 1, -1008.68f, -1115.72f, 47.046f));
			Teleports.Add(new TeleportEntry("RefugePointe", 0, -1262.79f, -2521.75f, 21.8021f));
			Teleports.Add(new TeleportEntry("RethressSanctum", 1, 2209.15f, -6439.12f, 2.82327f));
			Teleports.Add(new TeleportEntry("RockOfDurotan", 30, -896.41f, -525.78f, 55.2313f));
			Teleports.Add(new TeleportEntry("RogueQuarter", 0, 1456.44f, 104.917f, -60.8538f));
			Teleports.Add(new TeleportEntry("RottingOrchard", 0, -11069.3f, -927.315f, 64.502f));
			Teleports.Add(new TeleportEntry("RuinsOfAlterac", 0, 522.608f, -275.392f, 151.689f));
			Teleports.Add(new TeleportEntry("RuinsOfAnderhol", 0, 1386.47f, -1518.8f, 73.4034f));
			Teleports.Add(new TeleportEntry("RuinsOfEldarath", 1, 3546.8f, -5287.96f, 110.935f));
			Teleports.Add(new TeleportEntry("RuinsOfIsildien", 1, -5566.04f, 1449.82f, 21.1135f));
			Teleports.Add(new TeleportEntry("RuinsOfJubuwal", 0, -13382.6f, 2.10815f, 22.8683f));
			Teleports.Add(new TeleportEntry("RuinsOfKelTheril", 1, 6476.2f, -4255.87f, 666.203f));
			Teleports.Add(new TeleportEntry("RuinsOfLordaeron", 0, 1801.58f, 237.355f, 63.7537f));
			Teleports.Add(new TeleportEntry("RuinsOfMathystra", 1, 7373.38f, -938.331f, 33.6196f));
			Teleports.Add(new TeleportEntry("RuinsOfRavenwind", 1, -2858.35f, 2611.48f, 59.3777f));
			Teleports.Add(new TeleportEntry("RuinsOfSolarsal", 1, -4861.19f, 3516.7f, 23.8659f));
			Teleports.Add(new TeleportEntry("RuinsOfStardust", 1, 2178.01f, -288.45f, 98.3499f));
			Teleports.Add(new TeleportEntry("RuinsOfThaurissan", 0, -7798.32f, -2171.41f, 134.01f));
			Teleports.Add(new TeleportEntry("RuinsOfZulKunda", 0, -11693.9f, 702.532f, 50.9689f));
			Teleports.Add(new TeleportEntry("RumoredEntrance", 0, -10377.2f, -421.704f, 64.6252f));
			Teleports.Add(new TeleportEntry("RustmaulDigSite", 1, -6495.56f, -3472.69f, -57.7786f));
			Teleports.Add(new TeleportEntry("RuttheranVillage", 1, 8697.15f, 954.138f, 13.4829f));
			Teleports.Add(new TeleportEntry("SacrificeAltar", 0, -11685.2f, -2384.64f, 0.80816f));
			Teleports.Add(new TeleportEntry("SaldeansFarm", 0, -10171.8f, 1195.41f, 37.4345f));
			Teleports.Add(new TeleportEntry("SandsorrowWatch", 1, -7164.64f, -3142.55f, 12.072f));
			Teleports.Add(new TeleportEntry("Sargeron", 1, -242.347f, 764.848f, 99.7113f));
			Teleports.Add(new TeleportEntry("SarTherisStrand", 1, -592.792f, 2592.84f, 16.467f));
			Teleports.Add(new TeleportEntry("Satyrnaar", 1, 2757.59f, -2967.58f, 144.882f));
			Teleports.Add(new TeleportEntry("ScarabWall", 1, -8108.6f, 1528.42f, 3.13028f));
			Teleports.Add(new TeleportEntry("ScarletMonastery", 0, 2843.57f, -692.134f, 140.33f));
			Teleports.Add(new TeleportEntry("ScarletMonasteryEntrance", 189, 269.191f, -211.791f, 20.201f));
			Teleports.Add(new TeleportEntry("ScarletWatchPost", 0, 3040.8f, -552.374f, 123.216f));
			Teleports.Add(new TeleportEntry("Scholomance", 289, 199.427f, 126.464f, 135.912f));
			Teleports.Add(new TeleportEntry("ScreechingCanyon", 1, -5467.33f, -1633.45f, 30.4245f));
			Teleports.Add(new TeleportEntry("ScuttleCoast", 1, 242.548f, -5151.46f, 2.60441f));
			Teleports.Add(new TeleportEntry("SearingGorge", 0, -7176.63f, -937.667f, 171.206f));
			Teleports.Add(new TeleportEntry("SenjinVillage", 1, -827.924f, -4924.43f, 20.9659f));
			Teleports.Add(new TeleportEntry("SentinelHill", 0, -10510f, 1046.89f, 61.518f));
			Teleports.Add(new TeleportEntry("SentryPoint", 1, -3459.39f, -4130.3f, 17.3786f));
			Teleports.Add(new TeleportEntry("Sepulcher", 0, 507.784f, 1611.33f, 125.921f));
			Teleports.Add(new TeleportEntry("Seradene", 0, 724.846f, -3996.11f, 150.735f));
			Teleports.Add(new TeleportEntry("Sewers", 0, 1652.9f, 732.491f, 81.3365f));
			Teleports.Add(new TeleportEntry("ShadowfangKeep", 0, -202.557f, 1666.88f, 80.7641f));
			Teleports.Add(new TeleportEntry("Shadowglen", 1, 10696f, 765.934f, 1322.33f));
			Teleports.Add(new TeleportEntry("ShadowpreyVillage", 1, -1596.16f, 3145.26f, 68.8338f));
			Teleports.Add(new TeleportEntry("ShadraAlor", 0, -464.208f, -2837.23f, 111.073f));
			Teleports.Add(new TeleportEntry("ShadyRestInn", 1, -3719.26f, -2530.63f, 70.58f));
			Teleports.Add(new TeleportEntry("ShaolWatha", 0, 222.281f, -4312.26f, 118.769f));
			Teleports.Add(new TeleportEntry("ShatteredStrand", 1, 4260.73f, -6273.64f, 91.2289f));
			Teleports.Add(new TeleportEntry("ShatterScarVale", 1, 5483.9f, -749.881f, 335.621f));
			Teleports.Add(new TeleportEntry("ShrineOfAessina", 1, 2681.05f, 377.693f, 68.8608f));
			Teleports.Add(new TeleportEntry("ShrineOfRemulos", 1, 7849.78f, -2196.98f, 474.579f));
			Teleports.Add(new TeleportEntry("SilverpineForest", 0, 511.536f, 1638.63f, 121.417f));
			Teleports.Add(new TeleportEntry("SilverwindRefuge", 1, 2135.27f, -1189.9f, 99.8206f));
			Teleports.Add(new TeleportEntry("SkitteringDark", 0, 1293.65f, 1957.71f, 20.5619f));
			Teleports.Add(new TeleportEntry("SkullRock", 1, 1452.83f, -4877.14f, 12.8788f));
			Teleports.Add(new TeleportEntry("Slaughterhouse", 0, 2719.29f, -5479.3f, 160.542f));
			Teleports.Add(new TeleportEntry("SleepingGorge", 0, -10592.5f, -2131.21f, 92.4703f));
			Teleports.Add(new TeleportEntry("SlitheringScar", 1, -7849.33f, -1366.02f, -271.196f));
			Teleports.Add(new TeleportEntry("SludgeFen", 1, 1059.54f, -3003.53f, 92.6441f));
			Teleports.Add(new TeleportEntry("SollidenFarmstead", 0, 2268.03f, 1333.63f, 35.7835f));
			Teleports.Add(new TeleportEntry("SorrowHill", 0, 1064.09f, -1718.04f, 62.1348f));
			Teleports.Add(new TeleportEntry("SouthfuryRiver", 1, 114.769f, -3758.95f, 18.8907f));
			Teleports.Add(new TeleportEntry("SouthGateOutpost", 0, -5475.44f, -2425.32f, 414.455f));
			Teleports.Add(new TeleportEntry("Southshore", 0, -821.604f, -544.654f, 16.0387f));
			Teleports.Add(new TeleportEntry("SouthTidesRun", 0, -577.865f, 1807.08f, 9.2492f));
			Teleports.Add(new TeleportEntry("SouthwindVillage", 1, -7200.2f, 392.124f, 25.9073f));
			Teleports.Add(new TeleportEntry("SpiritRise", 1, -1009.29f, 231.283f, 135.587f));
			Teleports.Add(new TeleportEntry("SpiritRock", 1, -861.457f, -4283.67f, 78.7991f));
			Teleports.Add(new TeleportEntry("SplinterspearJunction", 0, -10382.5f, -2605.1f, 22.6849f));
			Teleports.Add(new TeleportEntry("SplintertreePost", 1, 2188.61f, -2514.28f, 82.0246f));
			Teleports.Add(new TeleportEntry("StagnantOasis", 1, -1330.17f, -3120.07f, 92.6667f));
			Teleports.Add(new TeleportEntry("StarBreezeVillage", 1, 9859.09f, 588.761f, 1301.61f));
			Teleports.Add(new TeleportEntry("StarfallVillage", 1, 7166.17f, -3986.87f, 743.872f));
			Teleports.Add(new TeleportEntry("SteamwidlePort", 1, -6942.47f, -4847.1f, 1.66785f));
			Teleports.Add(new TeleportEntry("SteelgrillsDepot", 0, -5470.37f, -662.312f, 393.674f));
			Teleports.Add(new TeleportEntry("Stockades", 34, 49.8212f, 0.870144f, -15.7136f));
			Teleports.Add(new TeleportEntry("Stonard", 0, -10487.3f, -3256.87f, 40.8964f));
			Teleports.Add(new TeleportEntry("StonebullLake", 1, -2543.98f, -327.013f, -13.2089f));
			Teleports.Add(new TeleportEntry("StoneCairnLake", 0, -9325.33f, -1038.92f, 66.3535f));
			Teleports.Add(new TeleportEntry("StonefiledFarm", 0, -9964.72f, 391.509f, 36.6555f));
			Teleports.Add(new TeleportEntry("StoneheartOutpost", 30, 24.9432f, -304.787f, 15.5986f));
			Teleports.Add(new TeleportEntry("StonemaulRuins", 1, -4354.46f, -3275.34f, 47.0475f));
			Teleports.Add(new TeleportEntry("StonesplinterValley", 0, -5930.62f, -2939.03f, 370.491f));
			Teleports.Add(new TeleportEntry("Stonetalon", 1, 898.482f, 922.688f, 127.788f));
			Teleports.Add(new TeleportEntry("StonetalonMountains", 1, 1145.85f, 664.812f, 143f));
			Teleports.Add(new TeleportEntry("StonetalonPeak", 1, 2506.3f, 1470.14f, 263.722f));
			Teleports.Add(new TeleportEntry("Stonewatch", 0, -9385.46f, -3039.27f, 140.437f));
			Teleports.Add(new TeleportEntry("StonewatchFalls", 0, -9482.57f, -3325.85f, 9.74276f));
			Teleports.Add(new TeleportEntry("StonewroughDam", 0, -4771.99f, -3329.01f, 346.504f));
			Teleports.Add(new TeleportEntry("StonewroughtPass", 0, -6356.7f, -2079.11f, 244.571f));
			Teleports.Add(new TeleportEntry("StormgardeKeep", 0, -1661.42f, -1804.2f, 84.0723f));
			Teleports.Add(new TeleportEntry("StormrageBarrowDens", 1, 7565.92f, -2898.29f, 461.126f));
			Teleports.Add(new TeleportEntry("Stormwind", 0, -8913.23f, 554.633f, 94.7944f));
			Teleports.Add(new TeleportEntry("StormwindBank", 0, -8937.08f, 640.4f, 101.645f));
			Teleports.Add(new TeleportEntry("StormwindCanals", 0, -8675.39f, 635.774f, 97.9275f));
			Teleports.Add(new TeleportEntry("StormwindCastle", 0, -8437.41f, 349.017f, 121.886f));
			Teleports.Add(new TeleportEntry("StormwindCathedralOfLight", 0, -8513.49f, 861.197f, 112.039f));
			Teleports.Add(new TeleportEntry("StormwindCathedralSquare", 0, -8635.62f, 762.727f, 104.667f));
			Teleports.Add(new TeleportEntry("StormwindDwarvenDistrict", 0, -8434.69f, 605.975f, 95.9669f));
			Teleports.Add(new TeleportEntry("StormwindKeep", 0, -8491.71f, 397.008f, 109.386f));
			Teleports.Add(new TeleportEntry("StormwindMageQuarter", 0, -8896.36f, 834.148f, 100.521f));
			Teleports.Add(new TeleportEntry("StormwindOldTown", 0, -8662.9f, 498.212f, 101.833f));
			Teleports.Add(new TeleportEntry("StormwindStockadesEntrance", 0, -8764.83f, 846.075f, 88.4842f));
			Teleports.Add(new TeleportEntry("StormwindTradeDistrict", 0, -8852.03f, 652.878f, 97.46f));
			Teleports.Add(new TeleportEntry("StormwindVaultEntrance", 0, -8667.56f, 623.563f, 86.4054f));
			Teleports.Add(new TeleportEntry("StormwindWizardsSanctum", 0, -9007.65f, 870.424f, 149.618f));
			Teleports.Add(new TeleportEntry("StoutlagerInn", 0, -5390.18f, -2953.93f, 323.03f));
			Teleports.Add(new TeleportEntry("Strahnbrad", 0, 679.813f, -965.173f, 165.598f));
			Teleports.Add(new TeleportEntry("StranglethornVale", 0, -11634.8f, -54.0697f, 14.4439f));
			Teleports.Add(new TeleportEntry("Stratholme", 0, 3176.63f, -4039.28f, 106.464f));
			Teleports.Add(new TeleportEntry("SunkenTemple", 0, -10349.1f, -3849.67f, -24.6078f));
			Teleports.Add(new TeleportEntry("SunkenTempleInside", 109, -314.229f, 99.88f, -130.849f));
			Teleports.Add(new TeleportEntry("SunRockRetreat", 1, 948.365f, 955.29f, 105.506f));
			Teleports.Add(new TeleportEntry("TaintedScar", 0, -12134.7f, -2455.53f, 20.61f));
			Teleports.Add(new TeleportEntry("TalondeepPath", 1, 1943.14f, -741.766f, 114.11f));
			Teleports.Add(new TeleportEntry("Tanaris", 1, -7373.69f, -2950.2f, 11.7598f));
			Teleports.Add(new TeleportEntry("TarrenMills", 0, -7.3559f, -936.734f, 63.3336f));
			Teleports.Add(new TeleportEntry("Teldrassil", 1, 10708.8f, 762.092f, 1322.37f));
			Teleports.Add(new TeleportEntry("TempleGardens", 1, 9935.34f, 2506.11f, 1318.82f));
			Teleports.Add(new TeleportEntry("TempleOfArkkoran", 1, 4060.07f, -7258.75f, 8.64345f));
			Teleports.Add(new TeleportEntry("TempleOfAtalHakkar", 0, -10429.4f, -3828.84f, -30.63f));
			Teleports.Add(new TeleportEntry("TempleOfTheMoon", 1, 9674.56f, 2524.82f, 1334.9f));
			Teleports.Add(new TeleportEntry("TerraceOfRepose", 0, 2922.59f, -740.071f, 154.983f));
			Teleports.Add(new TeleportEntry("Terrordale", 0, 2963.22f, -2791.65f, 111.827f));
			Teleports.Add(new TeleportEntry("TerrorRun", 1, -7817.09f, -1036.34f, -264.721f));
			Teleports.Add(new TeleportEntry("TerrorwebTunnel", 0, 2741.58f, -2471.74f, 75.78f));
			Teleports.Add(new TeleportEntry("Thalanaar", 1, -4517.1f, -780.415f, -39.736f));
			Teleports.Add(new TeleportEntry("ThandolSpan", 0, -2336.47f, -2509.82f, 86.2212f));
			Teleports.Add(new TeleportEntry("Thelsamar", 0, -5335.61f, -2982.58f, 333.669f));
			Teleports.Add(new TeleportEntry("TheramoreIsle", 1, -3729.36f, -4421.41f, 31.4474f));
			Teleports.Add(new TeleportEntry("TheramoreIsleLighthouse", 1, -3688.18f, -4760.14f, 1.90968f));
			Teleports.Add(new TeleportEntry("thevice", 0, -10931.4f, -2282.57f, 117.132f));
			Teleports.Add(new TeleportEntry("ThoradinsWall", 0, -839.599f, -1590.32f, 55.1962f));
			Teleports.Add(new TeleportEntry("ThoriumPoint", 0, -6492.69f, -1035.33f, 347.993f));
			Teleports.Add(new TeleportEntry("ThousandNeedles", 1, -4932.53f, -1596.05f, 85.8157f));
			Teleports.Add(new TeleportEntry("ThreeCorners", 0, -3239.78f, -2461.01f, 16.6003f));
			Teleports.Add(new TeleportEntry("ThreeFrozenAncients", 1, 6200f, -1035f, 388f));
			Teleports.Add(new TeleportEntry("ThroneRoom", 0, 1628.3f, 239.925f, 65.5006f));
			Teleports.Add(new TeleportEntry("ThunderAxeFortress", 1, -439.192f, 1708.22f, 126.856f));
			Teleports.Add(new TeleportEntry("Thunderbluff", 1, -1285.42f, 176.523f, 130.994f));
			Teleports.Add(new TeleportEntry("Thunderbrew", 0, -5601.46f, -530.747f, 396.483f));
			Teleports.Add(new TeleportEntry("ThunderhornWaterWell", 1, -1829.21f, -231.982f, -8.42481f));
			Teleports.Add(new TeleportEntry("ThunderRidge", 1, 925.127f, -4038.29f, -12.338f));
			Teleports.Add(new TeleportEntry("TimbermawHold", 1, 6794.4f, -2076.2f, 625.165f));
			Teleports.Add(new TeleportEntry("TimbermawPost", 1, 6485.09f, -3158.42f, 571.607f));
			Teleports.Add(new TeleportEntry("TinkerTown", 0, -4830.77f, -1271.9f, 502.868f));
			Teleports.Add(new TeleportEntry("TiragardeKeep", 1, -141.195f, -4987.04f, 22.7237f));
			Teleports.Add(new TeleportEntry("TirisfalGlades", 0, 2019.35f, 1904.36f, 106.144f));
			Teleports.Add(new TeleportEntry("TowerOfAlgalor", 0, -9281.94f, -3332.11f, 116.566f));
			Teleports.Add(new TeleportEntry("TowerOfAlthalaxx", 1, 7177.46f, -761.607f, 60.6101f));
			Teleports.Add(new TeleportEntry("TowerOfAzora", 0, -9527.48f, -686.064f, 63.2502f));
			Teleports.Add(new TeleportEntry("TowerPoint", 30, -695.936f, -427.201f, 88.9976f));
			Teleports.Add(new TeleportEntry("TradesmensTerrace", 1, 9764.55f, 2313.62f, 1328.68f));
			Teleports.Add(new TeleportEntry("TranquilGardenCemetery", 0, -10993.3f, -1331.19f, 53.7805f));
			Teleports.Add(new TeleportEntry("TwilightGrove", 0, -10385f, -424.696f, 64.534f));
			Teleports.Add(new TeleportEntry("TwilightPost", 1, -6750.62f, 1593.26f, 7.71623f));
			Teleports.Add(new TeleportEntry("TwilightShore", 1, 4988.97f, 547.002f, 6.37929f));
			Teleports.Add(new TeleportEntry("TwilightVale", 1, 4916.99f, 328.43f, 37.7678f));
			Teleports.Add(new TeleportEntry("TyrsHand", 0, 1683.56f, -5329.52f, 74.6664f));
			Teleports.Add(new TeleportEntry("Uldaman", 70, -228.193f, 46.1602f, -45.0186f));
			Teleports.Add(new TeleportEntry("Undercity", 0, 1831.26f, 238.53f, 61.52f));
			Teleports.Add(new TeleportEntry("UndercityApothecarium", 0, 1410.31f, 430.512f, -79.3588f));
			Teleports.Add(new TeleportEntry("UndercityCaves", 0, 1614.68f, 643.289f, 38.0547f));
			Teleports.Add(new TeleportEntry("UndercityMagic", 0, 1786.82f, 47.9279f, -28.1457f));
			Teleports.Add(new TeleportEntry("UndercityRogues", 0, 1466.11f, 49.6445f, -61.2932f));
			Teleports.Add(new TeleportEntry("UndercityTrade", 0, 1586.48f, 239.562f, -51.149f));
			Teleports.Add(new TeleportEntry("UndercityWar", 0, 1658.95f, 303.76f, -41.6923f));
			Teleports.Add(new TeleportEntry("Undercroft", 0, 1718.68f, -3281.46f, 90.6587f));
			Teleports.Add(new TeleportEntry("UnGoroCrater", 1, -7932.49f, -2139.61f, -229.728f));
			Teleports.Add(new TeleportEntry("Ursolan", 1, 4219.37f, -5609.95f, 119.166f));
			Teleports.Add(new TeleportEntry("UthersTomb", 0, 981.477f, -1821.84f, 81.4872f));
			Teleports.Add(new TeleportEntry("ValgansField", 0, 964.877f, 1238.75f, 49.0979f));
			Teleports.Add(new TeleportEntry("ValleyOfHeroes", 0, -8951.62f, 524.373f, 97.6275f));
			Teleports.Add(new TeleportEntry("ValleyOfHonor", 1, 2002.99f, -4698.97f, 25.646f));
			Teleports.Add(new TeleportEntry("ValleyOfKings", 0, -5840.93f, -2577.82f, 311.546f));
			Teleports.Add(new TeleportEntry("ValleyofSpears", 1, -1270.57f, 2849.63f, 114.745f));
			Teleports.Add(new TeleportEntry("ValleyOfSpirits", 1, 1551.21f, -4180.58f, 41.3741f));
			Teleports.Add(new TeleportEntry("ValleyOfStrength", 1, 1719.05f, -3948.28f, 50.0563f));
			Teleports.Add(new TeleportEntry("ValleyOfTheWatchers", 1, -9418.25f, -2761.61f, 20.9639f));
			Teleports.Add(new TeleportEntry("ValleyOfTrials", 1, -598.204f, -4330.15f, 38.6841f));
			Teleports.Add(new TeleportEntry("ValleyOfWisdom", 1, 1931.81f, -4282.29f, 30.0671f));
			Teleports.Add(new TeleportEntry("ValorsRest", 1, -6379.74f, -304.357f, -0.86658f));
			Teleports.Add(new TeleportEntry("VentureCoBaseCamp", 0, -12026.1f, -524.549f, 11.8818f));
			Teleports.Add(new TeleportEntry("VentureCoMine", 1, -1445.53f, -1064.14f, 144.596f));
			Teleports.Add(new TeleportEntry("VerdantFields", 169, -2128.12f, -1005.89f, 133.213f));
			Teleports.Add(new TeleportEntry("Vice", 0, -10889.8f, -2291.2f, 118.131f));
			Teleports.Add(new TeleportEntry("ViceCorners", 0, -10853f, -2087.44f, 122.918f));
			Teleports.Add(new TeleportEntry("VileReef", 0, -12133.7f, 938.409f, 3.74307f));
			Teleports.Add(new TeleportEntry("Village", 0, 2016.11f, -4486.36f, 74.6226f));
			Teleports.Add(new TeleportEntry("WailingCaverns", 1, -746.207f, -2213.18f, 15.8909f));
			Teleports.Add(new TeleportEntry("WallingCavernsEntrance", 43, -164.996f, 135.503f, -72.2155f));
			Teleports.Add(new TeleportEntry("WarQuarters", 0, 1775.76f, 418.224f, -57.0309f));
			Teleports.Add(new TeleportEntry("WarriorsTerrace", 1, 9951.55f, 2279.6f, 1342.39f));
			Teleports.Add(new TeleportEntry("WarsongLumberCamp", 1, 2690.32f, -3452.45f, 114.582f));
			Teleports.Add(new TeleportEntry("WarsonGulch", 48, -152.984f, 106.33f, -39.0953f));
			Teleports.Add(new TeleportEntry("WeaselsCrater", 1, -5878.11f, -3864.68f, -60.0863f));
			Teleports.Add(new TeleportEntry("WebwinderPath", 1, 591.836f, 327.223f, 47.658f));
			Teleports.Add(new TeleportEntry("WellspringLake", 1, 10376.8f, 1625.69f, 1289.91f));
			Teleports.Add(new TeleportEntry("WestbrookGarrison", 0, -9646.46f, 679.589f, 38.4136f));
			Teleports.Add(new TeleportEntry("WesternStrand", 0, -1019.67f, -359.442f, 6.13463f));
			Teleports.Add(new TeleportEntry("Westfall", 0, -10645.9f, 1179.06f, 49.1781f));
			Teleports.Add(new TeleportEntry("WestfallLighthouse", 0, -11399.2f, 1947.85f, 11.1451f));
			Teleports.Add(new TeleportEntry("Wetlands", 0, -4086.36f, -2610.95f, 47.0143f));
			Teleports.Add(new TeleportEntry("WhelgarsExcavationSite", 0, -3522.96f, -1848.58f, 26.1502f));
			Teleports.Add(new TeleportEntry("WhisperingGardens", 0, 2795.02f, -753.797f, 139.036f));
			Teleports.Add(new TeleportEntry("WhisperingShore", 0, 2538.92f, 1407.01f, 6.69061f));
			Teleports.Add(new TeleportEntry("WildhammerKeep", 0, 357.22f, -2106.09f, 122.839f));
			Teleports.Add(new TeleportEntry("WildmaneWaterWell", 1, -758.744f, -149.474f, -26.712f));
			Teleports.Add(new TeleportEntry("WildpawRidge", 30, -419.025f, -532.699f, 85.0135f));
			Teleports.Add(new TeleportEntry("WildShore", 0, -14692.4f, 506.162f, 2.78241f));
			Teleports.Add(new TeleportEntry("WindshearCrag", 1, 1160.25f, 51.3229f, 2.072f));
			Teleports.Add(new TeleportEntry("WinteraxHold", 30, -149.652f, 26.6353f, 78.0384f));
			Teleports.Add(new TeleportEntry("WinterSpring", 1, 6107.62f, -4181.6f, 853.322f));
			Teleports.Add(new TeleportEntry("WitherbarkVillage", 0, -1763.41f, -3371.67f, 41.609f));
			Teleports.Add(new TeleportEntry("WorldTree", 1, 5622.56f, -3378.82f, 1585.45f));
			Teleports.Add(new TeleportEntry("WrithingHaunt", 0, 1487.77f, -1884.87f, 60.2039f));
			Teleports.Add(new TeleportEntry("Wyrmbog", 1, -4682.97f, -3607.63f, 59.45f));
			Teleports.Add(new TeleportEntry("Xavian", 1, 2926.99f, -2817.98f, 212.872f));
			Teleports.Add(new TeleportEntry("YorgenFarmstead", 0, -11105.4f, -500.791f, 33.8518f));
			Teleports.Add(new TeleportEntry("ZiataJaiRuins", 0, -12697.1f, -462.157f, 30.9788f));
			Teleports.Add(new TeleportEntry("Ziggaraut", 0, 2433.31f, -3782.06f, 186.472f));
			Teleports.Add(new TeleportEntry("ZoramsStand", 1, 3652.24f, 928.308f, 8.01517f));
			Teleports.Add(new TeleportEntry("ZulFarrak", 209, 1221.82f, 840.746f, 9.97647f));
			Teleports.Add(new TeleportEntry("ZulGurub", 309, -11942.6f, -1544.28f, 40.5945f));
			Teleports.Add(new TeleportEntry("ZulGurubVillage", 0, -12332.5f, -1859.81f, 131.321f));
			Teleports.Add(new TeleportEntry("ZulMashar", 0, 3386.86f, -4931.45f, 162.093f));
			Teleports.Add(new TeleportEntry("ZunWatha", 0, -35.7245f, -2479.51f, 121.423f));
			Teleports.Add(new TeleportEntry("ZuuldaiaRuins", 0, -11683.1f, 925.209f, 4.64735f));
		}


	}

	
}
