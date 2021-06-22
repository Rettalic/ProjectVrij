using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawn;
    public ParticleSystem partSy;



    private static ShootController _instance;

    public static ShootController Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.F))
        {
            partSy.Play();
            ShootBullet();
            Debug.Log("YEET");
        }
    }

    public void ShootBullet()
    {
        Debug.Log("shoot");
        Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
    }

    
}

