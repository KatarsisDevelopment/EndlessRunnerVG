using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsPool : MonoBehaviour
{
    Queue<GameObject> ObsQueue = new Queue<GameObject>();
    public int ObsCount;
    public GameObject[] ObsObj;
    private void Awake()
    {
        for (int i = 0; i < ObsCount; i++)
        {
            GameObject obj = Instantiate(ObsObj[Random.Range(0, ObsObj.Length)]);
            obj.transform.SetParent(transform);
            obj.SetActive(false);
            ObsQueue.Enqueue(obj);
        }
    }
    public GameObject GetPooledObject()
    {
        GameObject obj = ObsQueue.Dequeue();
        obj.SetActive(true);
        ObsQueue.Enqueue(obj);
        return obj;
    }
}
