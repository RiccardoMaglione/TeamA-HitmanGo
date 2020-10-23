using UnityEngine;

namespace HGO
{
    namespace core
    {
        public class Item : MonoBehaviour
        {
            internal bool hitCell = false;
            private void OnCollisionEnter(Collision collision)
            {
                hitCell = true;
            }
        }
    }
}