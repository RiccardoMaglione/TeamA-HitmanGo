using UnityEngine;

namespace HGO
{
    namespace core
    {
        public class PlayerController : CharacterController
        {
            public PlayerMovementPM PM;

            private void Awake()
            {
                PM = GetComponent<PlayerMovementPM>();
            }
        }
    }
}