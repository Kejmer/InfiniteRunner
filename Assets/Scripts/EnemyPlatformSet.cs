using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemyPlatformSet")]
public class EnemyPlatformSet : ScriptableObject
{
    [SerializeField]
    private List<GameObject> m_EnemyPlatformPrefabs = new List<GameObject>();

    public GameObject GetRandom()
    {
        int randomPrefabIndex = Random.Range(0,m_EnemyPlatformPrefabs.Count);
        return m_EnemyPlatformPrefabs[randomPrefabIndex];
    }
}
