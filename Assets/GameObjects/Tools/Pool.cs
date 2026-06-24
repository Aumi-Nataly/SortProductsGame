using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    private Queue<GameObject> _pool = new Queue<GameObject>();

    public Pool(GameObject prefab, int size)
    { 
        for(int i = 0; i < size; i++) 
        {
            GameObject obj = Object.Instantiate(prefab);
            obj.SetActive(false);
            _pool.Enqueue(obj);
        }
    }


    public GameObject GetFromPool()
    {
        GameObject obj = _pool.Dequeue();
        obj.SetActive(true);
        return obj;
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        _pool.Enqueue(obj);
    }

}
    

