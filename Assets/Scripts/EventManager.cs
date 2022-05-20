using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    private static EventManager m_Instance;

    public static EventManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = FindObjectOfType(typeof(EventManager)) as EventManager;
            }

            return m_Instance;
        }
    }

    public class HitObstacleEvent : UnityEvent<SphereBehaviour>{};
    public class TapToStartEvent : UnityEvent{}
    public class LevelEndEvent : UnityEvent{}
    
    public HitObstacleEvent OnHitObstacle = new HitObstacleEvent();
    public TapToStartEvent OnTapToStart = new TapToStartEvent();
    public LevelEndEvent OnLevelEnd = new LevelEndEvent();
}


