using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour
{
    Queue<GameObject> CoinQueue = new Queue<GameObject>();
    public int CoinCount;
    public GameObject[] CoinObj;
    private void Awake()
    {
        for (int i = 0; i < CoinCount; i++)
        {
            GameObject obj = Instantiate(CoinObj[Random.Range(0, CoinObj.Length)]);
            obj.transform.SetParent(transform);
            obj.SetActive(false);
            CoinQueue.Enqueue(obj);
        }
    }
    public GameObject GetPooledObject()
    {
        GameObject obj = CoinQueue.Dequeue();
        obj.SetActive(true);
        CoinQueue.Enqueue(obj);
        return obj;
    }
}
