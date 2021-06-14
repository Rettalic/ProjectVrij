using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    private float interactRayLength;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InteractRaycast();   
    }

    public void InteractRaycast()
    {
        Vector3 playerPos  = transform.position;
        Vector3 forwardDir = transform.forward;

        Ray interactRay = new Ray(playerPos, forwardDir);
        RaycastHit interactRayHit;

        Vector3 interactRayEndpoint = forwardDir * interactRayLength;
        Debug.DrawLine(playerPos, interactRayEndpoint);

        bool hitFound = Physics.Raycast(interactRay, out interactRayHit, interactRayLength);
        if (hitFound)
        {

        }

    }
}
