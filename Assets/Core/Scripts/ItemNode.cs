using System;
using UnityEngine;

namespace HGO
{
    namespace core
    {
        
        public class ItemNode : Node
        {
            internal bool activated { private set;  get; }

            [System.Serializable]
            public struct NodeStyle
            {
                [Tooltip("Sprite NORMALE: nessun'azione usando questo nodo")]
                public Sprite normal;
                [Tooltip("Sprite FOCUS: il giocatore clicca o passa il mouse sopra questo nodo")]
                public Sprite focus;
                [Tooltip("Sprite USED: Il nodo esaurisce il proprio effetto (pickup oggetto effettuato)")]
                public Sprite used;
                
                [Space(5)]
                public AudioClip sfx_pickup;

                internal Action OnFocus;
                internal Action OnPickup;
            }
            [Space(5)]
            public NodeStyle style;

            protected new void Awake()
            {
                base.Awake();

                Enable();
                
            }

            protected new void OnTriggerEnter(Collider other)
            {
                base.OnTriggerEnter(other);

                var item = other.gameObject.GetComponent<Item>();
                if(item)
                {
                    Debug.Log("Projectile");
                }
            }

            /// <summary>
            /// Abilita il nodo alla procedura di lancio di un'oggetto
            /// </summary>
            public void Enable()
            {
                activated = true;
            }

            public void Disable()
            {
                activated = false;
            }

        }
    }
}