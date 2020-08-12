using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }

    [SerializeField] private GameObject m_LastPlatform;

    private List<GameObject> _pooledPlatforms;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _pooledPlatforms = new List<GameObject>();
    }

    private void AssignPosition(GameObject currentSpawnedPlatform)
    {
        if (m_LastPlatform)
        {
            if (m_LastPlatform.TryGetComponent(out Platform movePlatform))
            {
                currentSpawnedPlatform.transform.localPosition = new Vector3(movePlatform.GetEndPosition().x + UnityEngine.Random.Range(1.5f, 2f), 0, 0);
                if (currentSpawnedPlatform.TryGetComponent(out Platform currentMovePlatform))
                {
                    currentMovePlatform.StartTranslate();
                }
            }
            m_LastPlatform = currentSpawnedPlatform;
        }
    }

    public void AddToPool(GameObject platform)
    {
        _pooledPlatforms.Add(platform);
        if (_pooledPlatforms.Count > 2)
        {
            GameObject poolPlatform = _pooledPlatforms[UnityEngine.Random.Range(0, _pooledPlatforms.Count)];
            AssignPosition(poolPlatform);
            _pooledPlatforms.Remove(poolPlatform);
        }
    }
    
}
