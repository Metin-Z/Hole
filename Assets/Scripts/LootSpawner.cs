using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LootSpawner : MonoBehaviour
{
    public List<GameObject> ObjectTypes;
    public int object1Count;
    void Start()
    {
        for (int i = 0; i < object1Count; i++)
        {
            var RandomSpawnPos = new Vector3(Random.Range(-8.42f, -1.3f),2, Random.Range(1.3f, 8.45f));
            Instantiate(ObjectTypes[0], RandomSpawnPos,Quaternion.identity);
        }
    }

    void Update()
    {
        
    }
}
