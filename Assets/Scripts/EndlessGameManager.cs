using System.Collections.Generic;
using UnityEngine;

public class EndlessGameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject endlessPrefab;
    
    internal List<GameObject> endlessPrefabs;

    private int endlessPrefabzPos;

    private void Start()
    {
        endlessPrefabzPos = 100;
    }

    internal void GenerateEndlessPrefab()
    {
        GameObject generateEndlessPrefab = Instantiate(endlessPrefab);
        generateEndlessPrefab.transform.position = new Vector3(0, 0, endlessPrefabzPos);
        endlessPrefabzPos+=100;
    }
}
