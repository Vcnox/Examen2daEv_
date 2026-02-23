using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private GameObject prefab;
    private Queue<GameObject> availableObjects = new Queue<GameObject>();
    private List<GameObject> allObjects = new List<GameObject>();

    
    public ObjectPool(GameObject prefab, int initialSize)
    {
        this.prefab = prefab;
       
        for (int i = 0; i < initialSize; i++)
        {
            CreateNewObject();
        }


    }
    private GameObject CreateNewObject()
    {
        GameObject newObject = GameObject.Instantiate(prefab);
        newObject.SetActive(false);

        if(newObject.GetComponent<Bullet>() == null)
        {
            newObject.AddComponent<Bullet>();
        }

        allObjects.Add(newObject);
        availableObjects.Enqueue(newObject);

        return newObject;
    }

    public GameObject GetObject()
    {
        if(availableObjects.Count == 0)
        {
            CreateNewObject();
        }

        GameObject objectToGet = availableObjects.Dequeue();
        return objectToGet;
    }

    public void ReturnObject (GameObject objectToReturn)
    {
        objectToReturn.SetActive(false);
        availableObjects.Enqueue(objectToReturn);
    }
}
