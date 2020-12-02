using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlatformSet")]
public class PlatformSet : ScriptableObject
{
    [SerializeField]
    private List<GameObject> m_PlatformPrefabs = new List<GameObject>();

    public GameObject GetRandom()
    {
        int randomPrefabIndex = Random.Range(0,m_PlatformPrefabs.Count);
        return m_PlatformPrefabs[randomPrefabIndex];
    }
}
