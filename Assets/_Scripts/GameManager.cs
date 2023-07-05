using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Default
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
         
        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
                return;
            }
            
            Debug.LogError("More than one Sigleton in scene, Singleton: -> GameManager <-");
        }
    }
}