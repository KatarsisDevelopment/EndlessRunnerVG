using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retrogressive : MonoBehaviour
{
    [SerializeField] float Speed = 5f;
    private void Start()
    {
    }
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * Speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            transform.localPosition = new Vector3(0, 0, 100);
        }
    }
}
