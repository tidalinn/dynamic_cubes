using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlacementController : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    public int total = 10;
    public bool isInstantiated = false;

    Vector3 RandomPosition(Vector3 touchPosition)
    {
        float x = Random.Range(touchPosition.x - 0.5f, touchPosition.x + 0.5f);
        float y = Random.Range(touchPosition.y + 0.1f, touchPosition.y + 0.2f);
        float z = Random.Range(touchPosition.z - 0.5f, touchPosition.z + 0.5f);
        return new Vector3(x, y, z);
    }

    Quaternion RandomRotation()
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);
        return new Quaternion(x, y, z, 1);
    }

    public void InstantiateStaticObjects(Vector3 touchPosition)
    {
        GameObject parent = Instantiate(new GameObject("Static Objects"));

        for (int i = 0; i < total; i++)
        {
            Instantiate(prefab, RandomPosition(touchPosition), RandomRotation(), parent.transform);
        }

        isInstantiated = true;
    }
}
