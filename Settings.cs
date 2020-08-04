using System;
using Modding;

namespace NightmareSpike
{
    [Serializable]
    public class SaveModSettings : ModSettings
    {

    }

    [Serializable]
    public class GlobalModSettings : ModSettings
    {
        public string SceneName = "GG_Hollow_Knight";
        //public string BossName = "HK Prime";
        public float MinX = 29f;
        public float MaxX = 62f;
        public float floorY = 6.4f;
        public float delay = 5f;
        public int randomFactory = 3;
        public float MinBaseGap = 3f;
        public float attackFrequence = 0.8f;
    }
}
