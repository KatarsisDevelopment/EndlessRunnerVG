using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsManager : MonoBehaviour
{
    public float InstanceSpeed = 1f;
    public Transform ObsInstantPos;
    public ObsPool ObsPool;
    void Start()
    {
        StartCoroutine(ObsInstantEnum());
        InvokeRepeating(nameof(InstanceFast), 30f, 60f);
    }
    IEnumerator ObsInstantEnum()
    {
        while (true)
        {
            var Obs = ObsPool.GetPooledObject();
            Obs.transform.position = new Vector3(0, 0, ObsInstantPos.position.z);
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
