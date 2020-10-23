using DG.Tweening;
using HGO.ai;
using HGO.core.data;
using UnityEngine;

namespace HGO.core
{
    public class NoiseArea : MonoBehaviour
    {
        [Header("Settings"), Space(5)]
        public ThrowingData data;
        public Color areaColor;                 // Il colore dell'area che indica la propagazione del rumore
        public float expansionTime;             // In quanto tempo l'area raggiunge la dimensione finale
        public float lifetime;                  // Indica quanto tempo questa sprite resta attiva primo di distruggersi da quando raggiunge la massima dimensione

        BoxCollider bc;                         // Trigger 
        SpriteRenderer sr;                      // Sprite Renderer  
        float currentTime = 0;                  // delay corrente

        #region UnityCallbacks
        public void OnEnable()
        {
            bc = gameObject.GetComponentInChildren<BoxCollider>();
            sr = gameObject.GetComponentInChildren<SpriteRenderer>();

            /* INITIAL SETUP */
            sr.color = areaColor;

            bc.transform.DOScale(new Vector3(data.throw_area/2f, 1, data.throw_area/2f), expansionTime);
            sr.transform.DOScale(new Vector3(5 + data.throw_area * 2f, 5 + data.throw_area * 2f, 1), expansionTime);
        }

        public void Update()
        {
            if(bc.transform.localScale == new Vector3(data.throw_area/2f, 1, data.throw_area/2f))
            {
                currentTime += Time.deltaTime;

                if (currentTime >= lifetime) Destroy(gameObject);
            }
        }
        #endregion
    }
}