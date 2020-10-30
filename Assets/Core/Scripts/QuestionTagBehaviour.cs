using UnityEngine;

namespace HGO.core
{
    public class QuestionTagBehaviour : MonoBehaviour
    {
        private void Update()
        {
            gameObject.transform.rotation = Quaternion.LookRotation(Camera.main.gameObject.transform.position, Vector3.up) * new Quaternion(0, 181, 0, 0);
        }
    }
}
