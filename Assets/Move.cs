using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Move : MonoBehaviour, IDragHandler
{
    #region IDragHandler implementation
    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position += (Vector3)eventData.delta;
    }
    #endregion
}