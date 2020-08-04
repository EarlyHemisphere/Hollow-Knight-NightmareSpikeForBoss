using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NightmareSpike
{
    public class BossSceneData
    {
        private static readonly Dictionary<string, Polors> data = new Dictionary<string, Polors>()
        {
{"GG_Mage_Knight",new Polors (35.0,59.0,5.4)},
{"GG_Mage_Knight_V",new Polors (35.01002,58.93629,5.4)},
{"GG_Soul_Master",new Polors (5.267499,36.7325,29.4)},
{"GG_Soul_Tyrant",new Polors (3.267499,36.7325,29.4)},
{"GG_Dung_Defender",new Polors (60.26749,91.7325,7.4)},
{"GG_White_Defender",new Polors (60.26749,91.7325,7.4)},
{"GG_Watcher_Knights",new Polors (24.2675,62.73142,70.3)},
{"GG_Ghost_No_Eyes_V",new Polors (34.2675,63.73251,2.4)},
{"GG_Ghost_Marmu_V",new Polors (57.26749,80.7325,10.4)},
{"GG_Ghost_Xero_V",new Polors (79.76157,126.0782,11.1)},
{"GG_Ghost_Markoth_V",new Polors (9.267498,41.73251,8.0)},
{"GG_Ghost_Galien",new Polors (34.2675,70.7325,14.4)},
{"GG_Ghost_Gorb_V",new Polors (38.8819,75.5197,33.0)},
{"GG_Ghost_Hu",new Polors (32.26749,65.7325,3.4)},
{"GG_Nailmasters",new Polors (30.01002,62.9353,5.4)},
{"GG_Painter",new Polors (32.01002,60.9353,5.4)},
{"GG_Sly",new Polors (32.01002,60.93531,5.4)},
{"GG_Grimm_Nightmare",new Polors (68.7821,103.157,6.4)},
{"GG_Grimm",new Polors (69.26749,102.7325,6.4)},
{"GG_Grey_Prince_Zote",new Polors (6.267499,46.73251,6.4)},
{"GG_Traitor_Lord",new Polors (20.2675,59.73251,29.4)},
{"GG_Crystal_Guardian_2",new Polors (19.2675,40.73251,11.4)},
{"GG_Crystal_Guardian",new Polors (15.2675,43.73251,11.4)},
{"GG_God_Tamer",new Polors (85.26749,119.7325,6.4)},
{"GG_Collector_V",new Polors (39.26749,69.73251,95.4)},
{"GG_Nosk_Hornet",new Polors (29.32999,60.12608,13.4)},
{"GG_Broken_Vessel",new Polors (15.18253,37.90747,28.4)},
{"GG_Nosk_V",new Polors (71.26749,117.7325,5.4)},
{"GG_Lost_Kin",new Polors (15.18253,37.90747,28.4)},
{"GG_Hive_Knight",new Polors (57.26749,80.73251,27.4)},
{"GG_Oblobbles",new Polors (85.26749,119.7325,6.4)},
{"GG_Mantis_Lords",new Polors (17.23699,42.73976,7.4)},
{"GG_Flukemarm",new Polors (3.26749,37.7325,5.4)},
{"GG_Mega_Moss_Charger",new Polors (28.30437,69.73562,7.4)},
{"GG_Mantis_Lords_V",new Polors (17.23699,42.73976,7.4)},
{"GG_Hornet_2",new Polors (15.2675,37.73251,28.4)},
{"GG_False_Knight",new Polors (11.18712,45.70288,27.4)},
{"GG_Hornet_1",new Polors (15.2675,37.73251,28.4)},
{"GG_Failed_Champion",new Polors (42.22553,76.75058,27.4)},
{"GG_Brooding_Mawlek_V",new Polors (51.2359,71.71217,4.4)},
{"GG_Gruz_Mother_V",new Polors (86.26749,102.7325,15.4)},
{"GG_Uumuu_V",new Polors (35.26749,70.73251,106.4)},
{"GG_Vengefly_V",new Polors (33.1946,63.21641,13.2)},
{"GG_Radiance",new Polors (48.30999,73.02834,21.4)},
{"GG_Hollow_Knight",new Polors (29,62,6.4)},
        };
        public static bool Contains(string scenesName)
        {
            return data.ContainsKey(scenesName);
        }
        public static Polors GetPolorsByScenes(string scenesName)
        {
            if (data.ContainsKey(scenesName))
                return data[scenesName];
            else
                return new Polors(-1, -1, -1);
        }
    }
    public struct Polors
    {
        public float minX { get; private set; }
        public float maxX { get; private set; }
        public float floorY { get; private set; }

        public Polors(float minx,float maxx,float floory)
        {
            minX = minx;
            maxX = maxx;
            floorY = floory;
        }
        public Polors(double minx, double maxx, double floory)
        {
            minX = (float)minx;
            maxX = (float)maxx;
            floorY = (float)floory;
        }
    }
}
