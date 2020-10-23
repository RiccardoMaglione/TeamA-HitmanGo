using UnityEngine;

namespace HGO
{
    namespace core
    {
        public class PlayerController : CharacterController
        {
            internal PlayerMovement movementComponent;
            internal LevelManager lm;
            public Node currentNode;
            

            private void Awake()
            {
                Init();
            }

            void Init()
            {
                if (!lm) lm = FindObjectOfType<LevelManager>();

                if (!movementComponent) movementComponent = GetComponent<PlayerMovement>();
                if(movementComponent)
                {
                    movementComponent.Init(ref lm, ref currentNode);
                }
            }
        }
    }
}