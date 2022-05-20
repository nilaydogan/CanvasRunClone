using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    #region Variables

    public float LerpDuration;
    public float MaxBorder;
    public float MinBorder;
    public float ForwardSpeed;
    
    private Vector3 m_StartPosition;
    private Vector3 m_EndPosition;
    private Vector3 m_PreviousPosition;
    private Vector3 m_EndTouchPosition;

    public int Width;
    public int HeightLeft;
    public int HeightRight;

    private bool m_IsWidth;
    private bool m_IsHeight;
    private bool m_CanMove;
    private float m_Dpi;

    public SphereBehaviour LeftHead;
    public SphereBehaviour RightHead;

    public List<List<SphereBehaviour>> Spheres;

    private float m_Speed = 2f;
    private float m_ForwardOffset = .08f;
    private float Lerp = .4f;
    private float m_LateralOffset = .08f;
    
    #endregion
    
    #region Properties

    

    #endregion
    
    #region Unity Methods
    
    private void OnEnable()
    {
        EventManager.Instance.OnTapToStart.AddListener(OnCanMove);
        EventManager.Instance.OnLevelEnd.AddListener(OnLevelEnd);
    }

    private void OnDisable()
    {
        EventManager.Instance.OnTapToStart.RemoveListener(OnCanMove);
        EventManager.Instance.OnLevelEnd.RemoveListener(OnLevelEnd);
    }

    private void Awake()
    {
        m_Dpi = Screen.dpi;
        if (m_Dpi <= 0) m_Dpi = 200;
    }

    private void Start()
    {
        m_StartPosition = transform.position;
    }

    private void Update()
    {
        if (!m_CanMove) return;

        transform.position += transform.forward * (ForwardSpeed * Time.deltaTime);
        
        if (Input.GetMouseButtonDown(0))
        {
            m_PreviousPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            var mousePosition = Input.mousePosition;
            var diff = (mousePosition - m_PreviousPosition).x / m_Dpi;

            if (mousePosition.x > m_PreviousPosition.x)
            {
                LerpMovement(diff, false);
            }
            if (mousePosition.x < m_PreviousPosition.x)
            {
                LerpMovement(diff, true);
            }
            
            m_PreviousPosition = mousePosition;
        }
        else
        {
            LerpMovement(0,false);
        }
    }

    #endregion
    
    #region Public Methods

    public void SetHeads(SphereBehaviour left, SphereBehaviour right)
    {
        LeftHead = left;
        RightHead = right;
    }

    #endregion
    
    #region Private Methods

    private void LerpMovement(float diff, bool isLeft)
    {
        if (isLeft)  //left
        {
            for (int i = 0; i < Spheres.Count; i++)
            {
                for (int j = 0; j < Spheres[i].Count; j++)
                {
                    if (j == 0 && i == 0)
                    {
                        var position = Spheres[i][j].transform.position;
                        //Spheres[i][j].transform.position += Vector3.forward * (m_Speed * Time.deltaTime);
                        position.x = Mathf.Clamp(position.x + diff, MinBorder, MaxBorder);
                        Spheres[i][j].transform.position = position;
                    }
                    else
                    {
                        if (i == 0)
                        {
                            var position = Spheres[i][j].transform.position;
                            //position.z += m_ForwardOffset;
                            position.x = Mathf.Lerp(position.x, Spheres[i][j - 1].transform.position.x, Lerp);
                            Spheres[i][j].transform.position = position;
                        }
                        else
                        {
                            Spheres[i][j].transform.position = Spheres[0][j].transform.position +
                                                               Vector3.right * (m_LateralOffset * i);
                        }
                    }
                }
            }
        }
        else
        {
            for (int i = Spheres.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < Spheres[i].Count; j++)
                {
                    if (j == 0 && i == Spheres.Count - 1)
                    {
                        var position = Spheres[i][j].transform.position;
                        //Spheres[i][j].transform.position += Vector3.forward * (m_Speed * Time.deltaTime);
                        position.x = Mathf.Clamp(position.x + diff, MinBorder, MaxBorder);
                        Spheres[i][j].transform.position = position;
                    }
                    else
                    {
                        if (i == Spheres.Count - 1)
                        {
                            var position = Spheres[i][j].transform.position;
                            //position.z += m_ForwardOffset;
                            position.x = Mathf.Lerp(position.x, Spheres[i][j - 1].transform.position.x, Lerp);
                            Spheres[i][j].transform.position = position;
                        }
                        else
                        {
                            Spheres[i][j].transform.position = Spheres[Spheres.Count - 1][j].transform.position +
                                                               Vector3.left * (m_LateralOffset * (Spheres.Count - 1 - i));
                        }
                    }
                }
            }
        }
    }

    private void OnCanMove()
    {
        m_CanMove = true;
    }

    private void OnLevelEnd()
    {
        m_CanMove = false;
    }

    #endregion
}
