using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BagOpen : MonoBehaviour
{
    // Start is called before the first frame updateublip
    [SerializeField] private GameObject panel;
    public void Bag_Click()
    {
        if (panel.activeSelf)
        {
            Sequence seq = DOTween.Sequence();
            seq
                .Append(panel.GetComponent<RectTransform>().DOScale(new Vector3(0f,1f,1f),1f))
                .OnComplete(() =>
                {
                    panel.SetActive(false);
                })
                .Play();
        }
        else
        {
            panel.SetActive(true);
            panel.transform.localScale = new Vector3(0f,1f,1f);
            Sequence seq = DOTween.Sequence();
            seq
                .Append(panel.GetComponent<RectTransform>().DOScale(new Vector3(1f,1f,1f),1f))
                
                .Play();
        }
        
    }
}