using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LootSpawner : MonoBehaviour
{
    public List<GameObject> ObjectTypes;
    public GameObject BonusGem;
    public int object1Count;
    int randomGemInt;
    void Start()
    {
        for (int i = 0; i < object1Count; i++)
        {
            var RandomSpawnPos = new Vector3(Random.Range(-8.42f, -1.3f),2, Random.Range(1.3f, 8.45f));
            GameObject obj = Instantiate(ObjectTypes[0], RandomSpawnPos,Quaternion.identity);
            obj.transform.parent = transform;
        }
        randomGemInt = Random.Range(0, 5);
        if (randomGemInt == 2)
        {
            StartCoroutine(GetBonusGem());
        }
    }
    public IEnumerator GetBonusGem()
    {
        yield return new WaitForSeconds(1);
        var BonusSpawnPos = new Vector3(Random.Range(-3, 3f), 2, Random.Range(-3f, 3f));
        GameObject obj = Instantiate(BonusGem, BonusSpawnPos, Quaternion.identity);
        obj.transform.parent = transform;


    }

}
