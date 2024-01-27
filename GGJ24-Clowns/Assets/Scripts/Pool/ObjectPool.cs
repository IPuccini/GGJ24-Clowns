using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();

        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate<GameObject>(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject(bool activeObject = false)
    {

        if (activeObject)
        {
            // returns first active object
            for(int i = amountToPool - 1; i >= 0; i--)
            {
                if (pooledObjects[i].activeInHierarchy)
                {
                    return pooledObjects[i];
                }
            }
        }
        else
        {
            // returns first inactive object
            for(int i = 0; i < amountToPool; i++)
            {
                if (!pooledObjects[i].activeInHierarchy)
                {
                    return pooledObjects[i];
                }
            }            
        }

        // failed to find any free objects
        return null;
    }

    public GameObject GetActiveObject()
    {
        // returns first inactive object
        for(int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        // failed to find any free objects
        return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
