using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePooling : MonoBehaviour
{
    [SerializeField]
    private List<ObjectPool> pools = new List<ObjectPool>();
    private List<GameObject> gameObjects = new List<GameObject>();

    private void Awake()
    {
        foreach(var pool in pools)
        {
            for(int i = 0; i < pool.poolCount; i++)
            {
                GameObject obj = (GameObject)Instantiate(pool.pool);
                obj.SetActive(false);
                gameObjects.Add(obj);
            }
        }
    }

    public Vector3 GetPoolPos(string tag)
    {
        for(var i = 0; i < gameObjects.Count; i++)
        {
            if (gameObjects[i].activeInHierarchy && gameObjects[i].tag == tag)
            {
                return gameObjects[i].transform.position;
            }
        }
        return Vector3.zero;
    }

    public GameObject GetPooledObject(string tag, Vector3 pos)
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            if (!gameObjects[i].activeInHierarchy && gameObjects[i].tag == tag)
            {
                gameObjects[i].transform.position = pos;
                gameObjects[i].SetActive(true);
                return gameObjects[i];
            }
        }
        return null;
    }

    public GameObject RemovePooledObject(string tag)
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            if (gameObjects[i].activeInHierarchy && gameObjects[i].tag == tag)
            {
                gameObjects[i].SetActive(false);
                return gameObjects[i];
            }
        }
        return null;
    }
}

[System.Serializable]
public class ObjectPool
{
    public GameObject pool;
    public int poolCount = 0;
}
