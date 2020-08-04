using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using ModCommon;
using Modding;
using ModCommon.Util;
using UnityEngine;
using UnityEngine.SceneManagement;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using System.Collections;
using IL.InControl;

namespace NightmareSpike
{
    public class NightmareSpike : Mod,ITogglableMod
    {
        //public GameObject boss;
        public static double _rngfactory;
        public static GameObject spikeHolder;
        public static PlayMakerFSM spikeCtrl;
        public static System.Random random;
        private static bool firstLoad = true;
        public override List<(string, string)> GetPreloadNames()
        {
            return new List<(string, string)>
            {
                ("GG_Grimm_Nightmare","Grimm Spike Holder"),
            };
        }
        private static void RandomSpike()
        {

            
            float RangeX = Settings.MaxX - Settings.MinX;
            if(RangeX<0)
            {
                throw new Exception("x坐标有误");
            }
            float gap = RangeX / 15f;
            if (gap < Settings.MinBaseGap)
                gap = Settings.MinBaseGap;
            
            var father = spikeHolder.GetComponentsInChildren<Transform>();
            int i = 0;
            foreach (var c in father)
            {
                if (c.name.Contains("Nightmare Spike"))
                {
                    var rgap = gap  + ((random.NextDouble() * random.Next(-1, 2))/_rngfactory);
                    var x = Settings.MinX + i * rgap;
                    var y = Settings.floorY - 2f;
                    var z = HeroController.instance.transform.position.z;
                    c.position = new Vector3((float)x, y, z);
                    i++;
                    //Modding.Logger.Log($"{c.gameObject.transform.position}");
                }
            }
        }
        public static void SpikeAttack()
        {
            
            if (spikeCtrl.ActiveStateName == "Idle")
            {
                RandomSpike();
                spikeCtrl.SetState("Ready");
            }
        }
        public override void Initialize(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
        {
            random = new System.Random();
            //GameManager.instance.gameObject.AddComponent<BossFinder>();
            spikeHolder = preloadedObjects["GG_Grimm_Nightmare"]["Grimm Spike Holder"];
            spikeCtrl = spikeHolder.LocateMyFSM("Spike Control");
            if(firstLoad)
            {
                spikeCtrl.AddAction("Down", new Wait
                {
                    time = Settings.attackFrequence,
                    finishEvent = FsmEvent.Finished
                });
                var father = spikeHolder.GetComponentsInChildren<Transform>();

                foreach (var c in father)
                {
                    if (c.name.Contains("Nightmare Spike"))
                    {
                        var spikefsm = c.gameObject.LocateMyFSM("Control");
                        spikefsm.ChangeTransition("Dormant", "SPIKES READY", "Ready");
                    }
                }

                if (Settings.randomFactory == 0)
                {
                    _rngfactory = 999;
                }
                else if (Settings.randomFactory > 0 && Settings.randomFactory < 10)
                {
                    _rngfactory = (10.0 - (double)Settings.randomFactory) / 2.0;
                }
                else
                {
                    _rngfactory = 0.1;
                }

                firstLoad = false;
            }

            UnityEngine.SceneManagement.SceneManager.sceneLoaded += FindBoss;

        }

        private void FindBoss(Scene arg0, LoadSceneMode arg1)
        {
            if (arg0.name != Settings.SceneName && !BossSceneData.Contains(arg0.name))
                return;

            //GameManager.instance.StartCoroutine(FindBoss(Settings.BossName));
            GameManager.instance.StartCoroutine(FindBoss());
        }
        private IEnumerator FindBoss(string bossName = null)
        {
            HealthManager[] hms = null;

            yield return new WaitForSeconds(Settings.delay);

            yield return new WaitUntil(() => {
                //boss = GameObject.Find(bossName);
                hms = GameObject.FindObjectsOfType<HealthManager>();
                return hms.Length>0;
                });

            

            //boss.AddComponent<Boss>();
            foreach(var hm in hms)
            {
                Log($"Find GameObject With HM,{hm.gameObject.name}");
                hm.gameObject.AddComponent<Boss>();
            }
        }
        

        public void Unload()
        {
            UnityEngine.SceneManagement.SceneManager.sceneLoaded -= FindBoss;
            if (BossSceneData.Contains(GameManager.instance.GetSceneNameString()))
            {
                var hms = GameObject.FindObjectsOfType<HealthManager>();
                if (hms.Length > 0)
                {
                    foreach(var hm in hms)
                    {
                        var bossspike = hm.gameObject.GetComponent<Boss>();
                        if(bossspike)
                        {
                            UnityEngine.Object.DestroyImmediate(bossspike);
                        }
                    }
                }
            }
        }
        public override string GetVersion() => "2.9";

        public static GlobalModSettings Settings = new GlobalModSettings();
        public override ModSettings GlobalSettings { get => Settings; set => Settings = (GlobalModSettings)value; }
    }
}
