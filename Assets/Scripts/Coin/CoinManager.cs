using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public float InstanceSpeed = 1f;
    public Transform CoinInstantPos;
    public CoinPool CoinPool;
    void Start()
    {
        StartCoroutine(CoinInstantEnum());
        InvokeRepeating(nameof(InstanceFast), 30f, 60f);
    }
    IEnumerator CoinInstantEnum()
    {
        while (true)
        {
            var Coin = CoinPool.GetPooledObject();
            Coin.transform.position = new Vector3(Random.Range(-2,2), 1, CoinInstantPos.position.z);
            yield return new WaitForSeconds(InstanceSpeed);
        }
    }
    void InstanceFast()
    {
        if (InstanceSpeed > 0)
        {
            InstanceSpeed -= 0.1f;
        }
    }
}
