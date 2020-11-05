using UnityEngine;
using DG.Tweening;

public class ButtonController : MonoBehaviour
{
    public void OnMouseEnter()
    {
        transform.DOScale(1.25f, 0.2f);
    }

    public void OnMouseExit()
    {
        transform.DOScale(1f, 0.2f);
    }
}
