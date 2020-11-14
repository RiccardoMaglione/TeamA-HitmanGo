using HGO.ai;
using System.Collections.Generic;
using UnityEngine;

namespace HGO.core
{
    public sealed class NoiseAreaCollisions : MonoBehaviour
    {
        LevelManager lm;

        private void Awake()
        {
            lm = FindObjectOfType<LevelManager>();
        }
        void OnTriggerEnter(Collider other)
        {
            var ai = other.gameObject.GetComponent<AI_Controller>();
           
            if(ai)
            {
                lm.ThrowingSystemManager.enemiesNoised.Add(ai);
            }
            else
            {
                Debug.LogError(other.gameObject.name);
            }
        }
    }
}