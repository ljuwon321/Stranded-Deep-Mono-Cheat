using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Beam;
using Beam.AI;

namespace StrandardDeep_Cheat
{
    public class FoodESP : MonoBehaviour
    {
        private void Start()
        {

        }
        IEnumerator SleepFor(float Time)
        {
            yield return new WaitForSeconds(Time);
        }

        Player localplayer = FindObjectsOfType<Player>()[0];
        private void OnGUI()
        {
            if (Menu.LootESP == true)
            {
                if (Menu.FoodESP)
                {
                    IEnumerable<InteractiveObject_FOOD> playerProxies = FindObjectsOfType<InteractiveObject_FOOD>();
                    foreach (InteractiveObject_FOOD playerProxy in playerProxies)
                    {
                       
                        Vector3 pos = playerProxy.transform.position;
                        Vector3 posScreen = Camera.main.WorldToScreenPoint(pos);

                        if (posScreen.z > 0 & posScreen.y < Screen.width - 2)
                        {
                            float dist = Vector3.Distance(pos, localplayer.transform.position);
                            if (dist < Menu.LoopDist)
                            {
                                posScreen.y = Screen.height - (posScreen.y + 1f);
                                Render.DrawString(new Vector2(posScreen.x, posScreen.y), ("   Food" + string.Format(" [{0:0}m]", (object)dist)), Color.green);
                            }
                        }
                        SleepFor(0.300f);
                    }
                    SleepFor(0.300f);
                }
                SleepFor(0.300f);

            }
        }


        private void Update()
        {

        }
    }
}
