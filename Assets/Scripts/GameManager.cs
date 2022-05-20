using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    public static GameManager Instance;

    public int CurrentLevel;

    public Transform CurrentLevelTransform;

    #endregion
    
    #region Properties

    

    #endregion
    
    #region Unity Methods

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    #endregion
    
    #region Public Methods

    

    #endregion
    
    #region Private Methods

    

    #endregion
}
