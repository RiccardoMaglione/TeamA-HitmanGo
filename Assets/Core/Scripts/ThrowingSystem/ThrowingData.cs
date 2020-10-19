
using UnityEngine;

namespace HGO
{
    namespace core
    {
        namespace data
        {
            [CreateAssetMenu(fileName = "ThrowingData", menuName = "data/Throwing System/data")]
            public class ThrowingData : ScriptableObject
            {
                [Tooltip("Indica quanto grande e' l'area dove si puo lanciare un'oggetto - 1: un cella di distanze, 2: due celle di distance, etc.")]
                public float throw_area;
                [Tooltip("Indica quanto tempo dura il lancio in secondi")]
                public float throw_duration;
                [Tooltip("Indica la forza con cui viene lanciato l'oggetto")]
                public float launch_force = 5f;
            }
        }
    }
}