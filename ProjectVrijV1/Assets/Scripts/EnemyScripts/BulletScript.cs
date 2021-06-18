using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;

    void Start()
    {
        Debug.Log(transform.rotation);
    }

    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            return;
        }

        Destroy(gameObject);
    }
}
