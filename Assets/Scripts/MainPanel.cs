using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MainPanel : MonoBehaviour
{
    #region Variables

    [SerializeField] private RectTransform m_TapToStartButton;
    [SerializeField] private RectTransform m_TapToStartText;

    private Vector3 m_InitialSize;

    #endregion
    
    #region Properties

    

    #endregion
    
    #region Unity Methods

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
    
    private void Start()
    {
        m_InitialSize = m_TapToStartText.localScale;
        ScaleInAndOutText();    //todo: on level load da yapılmalı
    }

    private void Update()
    {
        
    }
    
    #endregion
    
    #region Public Methods

    public void OnTapToStartClick()
    {
        m_TapToStartText.DOKill();
        m_TapToStartText.localScale = m_InitialSize;
        m_TapToStartButton.gameObject.SetActive(false);
        EventManager.Instance.OnTapToStart.Invoke();
    }

    #endregion
    
    #region Private Methods

    private void ScaleInAndOutText()
    {
        var endSize = m_InitialSize * .8f;
        m_TapToStartText.DOScale(endSize, 1f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    #endregion
}
