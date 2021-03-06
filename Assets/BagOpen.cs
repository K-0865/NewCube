using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BagOpen : MonoBehaviour
{
    // Start is called before the first frame updateublip
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject log;
    private bool open;
    /// <summary>
    /// カバンクリックされる時のアニメション
    /// </summary>
    public void Bag_Click()
    {
        if (open)
        {
            log.SetActive(true);
            Sequence seq = DOTween.Sequence();
            seq
                .Append(panel.GetComponent<RectTransform>().DOScale(new Vector3(0f,1f,1f),1f))
                .OnComplete(() =>
                {
                    //panel.SetActive(false);
                    open = false;
                })
                .Play();
        }
        else
        {
            open = true;
            log.SetActive(false);
            panel.transform.localScale = new Vector3(0f,1f,1f);
            Sequence seq = DOTween.Sequence();
            seq
                .Append(panel.GetComponent<RectTransform>().DOScale(new Vector3(1f,1f,1f),1f))
                .OnComplete(() =>
                {
                   
                })
                
                .Play();
        }
    }
}
