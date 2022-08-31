using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootCLAMP : MonoBehaviour
{
    private void Update()
    {
        Clamp();
    }
    public void Clamp()
    {
        float minX = -9.42f;
        float maxX = 9.42f;
        float minZ = -9.45f;
        float maxZ = 9.45f;
        float xPos = Mathf.Clamp(transform.position.x, minX, maxX);
        float zPos = Mathf.Clamp(transform.position.z, minZ, maxZ);
        transform.position = new Vector3(xPos, transform.position.y, zPos);
    }
}
