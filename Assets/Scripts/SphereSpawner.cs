using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    #region Variables

    [SerializeField] private PlayerBehaviour m_PlayerBehaviour;
    [SerializeField] private GameObject m_SpherePrefab;
    [SerializeField] private Vector3 m_FirstSpherePosition;

    public float Radius = .08f;

    public int StartWidth;
    public int StartHeight;
    
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
        InitializeSphereList();
        InstantiateSphereForStart();
    }

    private void Update()
    {
        
    }

    #endregion
    
    #region Public Methods

    /*public void InstantiateSpheresInGame(bool isWidth, int amount)
    {
        if (isWidth)
        {
            //todo: height must stay the same
            int additionRowAmount = amount / m_PlayerBehaviour.Height;

            for (int i = 0; i < m_PlayerBehaviour.Height; i++)
            {
                var first = m_PlayerBehaviour.Spheres[i][0].transform.position;
                var last = m_PlayerBehaviour.Spheres[i][m_PlayerBehaviour.Width - 1].transform.position;
                PlaceSpheresAccordingToWidth(first, last, additionRowAmount, i);
            }
        }
        else
        {
            //todo: width must stay the same
            int additionColumnAmount = amount / m_PlayerBehaviour.Width;
        }
    }*/

    public void DestroySpheres()
    {
        
    }

    #endregion
    
    #region Private Methods

    private void ColorSphere()
    {
        //todo: color spheres according to their Z axis
    }

    /*private void PlaceSpheresAccordingToWidth(Vector3 first, Vector3 last, int amount, int row)
    {
        //todo: cameranın height a göre adjust edilmesi lazım ki en sondakiler de görebilelim
        //row equals to sphere matrix height
        Vector3 pos;
        Vector3 lastPos;
        pos = lastPos = first;
        for (int i = 0; i < amount/2; i++)
        {
           lastPos.x = pos.x - Radius;
           var instantiatedSphere = Instantiate(m_SpherePrefab, lastPos, Quaternion.identity, GameManager.Instance.CurrentLevelTransform).GetComponent<SphereBehaviour>();
           m_PlayerBehaviour.Spheres[row].Add(instantiatedSphere);
           pos = lastPos;
        }

        pos = lastPos = last;
        for (int i = amount/2; i < amount; i++)
         {
            lastPos.x = pos.x + Radius; 
            var instantiatedSphere = Instantiate(m_SpherePrefab, lastPos, Quaternion.identity, GameManager.Instance.CurrentLevelTransform).GetComponent<SphereBehaviour>(); 
            m_PlayerBehaviour.Spheres[row].Add(instantiatedSphere); 
            pos = lastPos;
         }
        
    }*/

    /*private void PlaceSphereAccordingToHeight(Vector3 position, int amount)
    {
        //height equals to row
        //width equals to coloumn
        
        var row = m_PlayerBehaviour.Height;
        Vector3 pos;
        Vector3 lastPos;
        
        for (int i = 0; i < amount; i++)
        {
            pos = m_PlayerBehaviour.Spheres[row - 1][0].transform.position;
            lastPos = pos;
            
            row++;
            lastPos.z -= Radius;
            for (int j = 0; j < m_PlayerBehaviour.Width; j++)
            {
                lastPos.x = pos.x + Radius;
                var instantiatedSphere = Instantiate(m_SpherePrefab, lastPos, Quaternion.identity, GameManager.Instance.CurrentLevelTransform)
                    .GetComponent<SphereBehaviour>();
                m_PlayerBehaviour.Spheres[row].Add(instantiatedSphere);
                pos = lastPos;
            }
        }
    }*/
    
    /*private void Instantiate()
    {
        Vector3 pos = m_FirstSpherePosition;;
        Vector3 lastPos;
        for (int i = 0; i < m_PlayerBehaviour.Height; i++)
        {
            lastPos = pos;
            for (int j = 0; j < m_PlayerBehaviour.Width; j++)
            {
                var instantiatedSphere = Instantiate(m_SpherePrefab, lastPos, Quaternion.identity, GameManager.Instance.CurrentLevelTransform)
                    .GetComponent<SphereBehaviour>();
                m_PlayerBehaviour.Spheres[i].Add(instantiatedSphere);
            }
            lastPos.z -= Radius;
        }
    }*/

    private void InstantiateSphereForStart()
    {
        Vector3 pos = m_FirstSpherePosition;
        Vector3 lastPos = pos;
        
        for (int i = 0; i < StartWidth; i++)
        {
            for (int j = 0; j < StartHeight; j++)
            {
                //var instantiatedSphere = Instantiate(m_SpherePrefab, pos, Quaternion.identity, GameManager.Instance.CurrentLevelTransform).GetComponent<SphereBehaviour>();
                var instantiatedSphere = Instantiate(m_SpherePrefab, pos, Quaternion.identity, m_PlayerBehaviour.transform).GetComponent<SphereBehaviour>();
                m_PlayerBehaviour.Spheres[i].Add(instantiatedSphere);
                
                pos.z -= Radius;
            }

            pos = lastPos;
            pos.x -= Radius;
            lastPos.x = pos.x;
        }

        //m_PlayerBehaviour.LeftHead = m_PlayerBehaviour.Spheres[0][0];
        //m_PlayerBehaviour.RightHead = m_PlayerBehaviour.Spheres[0][m_PlayerBehaviour.Spheres[0].Count - 1];
        
        m_PlayerBehaviour.SetHeads(m_PlayerBehaviour.Spheres[0][0],m_PlayerBehaviour.Spheres[0][m_PlayerBehaviour.Spheres[0].Count - 1]);
    }

    private void InitializeSphereList()
    {
        m_PlayerBehaviour.Spheres = new List<List<SphereBehaviour>>();
        for (int i = 0; i < StartWidth; i++)
        {
            m_PlayerBehaviour.Spheres.Add(new List<SphereBehaviour>());
        }
    }

    #endregion
}
