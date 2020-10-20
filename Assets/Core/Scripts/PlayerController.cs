using UnityEngine;

namespace HGO
{
    namespace core
    {
        public class PlayerController : CharacterController
        {
            public PlayerMovementPM PM;
            // Dove sono
            // Dove devo andare
            // Fermo/ In Movimeno/.../ altro

            private void Awake()
            {
                PM = GetComponent<PlayerMovementPM>();
            }
        }
    }
}