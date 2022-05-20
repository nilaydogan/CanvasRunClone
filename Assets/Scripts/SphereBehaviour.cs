using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereBehaviour : MonoBehaviour
{
    #region Variables

    public SphereBehaviour SphereLeft;
    public SphereBehaviour SphereRight;
    public SphereBehaviour SphereColumn;
    public bool IsHead;
    public bool IsMoving;

    

    #endregion
    
    #region Properties

    

    #endregion
    
    #region Unity Methods

    private void Start()
    {
        
    }

    private void Update()
    {
        if (!IsHead)
        {
            
        }

        if (IsHead && !IsMoving)
        {
            
        }
    }

    #endregion
    
    #region Public Methods

    

    #endregion
    
    #region Private Methods

    

    #endregion
}
