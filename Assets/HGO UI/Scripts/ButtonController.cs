using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [Tooltip("Valore da modificare per decidere la dimensione del bottone quando il mouse è su di esso")]
    public float dimension;

    public void OnMouseEnter()
    {
        transform.localScale += new Vector3(dimension, dimension, dimension); 
    }

    public void OnMouseExit()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
}
