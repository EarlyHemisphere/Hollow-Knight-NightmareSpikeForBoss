using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using ModCommon;
using ModCommon.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace NightmareSpike
{
    class Boss : MonoBehaviour
    {
        public void Start()
        {
            
            NightmareSpike.spikeHolder.SetActive(true);
            if (HeroController.instance != null)
                HeroController.instance.AddMPCharge(999);

            NightmareSpike.Settings.SceneName = GameManager.instance.GetSceneNameString();
            Polors current = BossSceneData.GetPolorsByScenes(NightmareSpike.Settings.SceneName);
            NightmareSpike.Settings.MinX = current.minX;
            NightmareSpike.Settings.MaxX = current.maxX;
            NightmareSpike.Settings.floorY = current.floorY;
            if (current.minX > -1f)
                Log("Add Spikes Success");
            else
                Log("Something Error on Start");
        }
        public void Update()
        {
            NightmareSpike.SpikeAttack();
        }
        public void OnDestroy()
        {
            //NightmareSpike.spikeHolder.SetActive(false);
            var currentScene = GameManager.instance.GetSceneNameString();
            if (currentScene.Contains("GG_Mantis_Lords") && gameObject.name == "Mantis Lord")
            {
                HeroController.instance.StartCoroutine(Mantis());
            }

        }
        private static IEnumerator Mantis()
        {
            yield return new WaitForSeconds(3);

            var mantis1 = GameObject.Find("Mantis Lord S1");
            while(mantis1 == null)
            {
                mantis1 = GameObject.Find("Mantis Lord S1");
                yield return null;
            }
            Modding.Logger.LogDebug(mantis1.name);
            if(mantis1)
            {
                mantis1.AddComponent<Boss>();
            }
        }
        private static void Log(object msg) => Modding.Logger.Log($"[Boss] {msg}");
    }
}
