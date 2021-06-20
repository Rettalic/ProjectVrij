using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistributeAir : MonoBehaviour
{
    public GameObject companion;
    public GameObject player;

    public LayerMask whatIsPlayer;
    public int airRange;
    public bool range;

    public Slider airAmount;
    public int airStart;
    public int airCurrent;
    public int airSubtract;
    public int airAdd;

    // Start is called before the first frame update
    void Start()
    {
        
    
    }

    // Update is called once per frame
    void Update()
    {


        range = Physics.CheckSphere(companion.transform.position, airRange, whatIsPlayer);

        if(range == true)
        {
            airCurrent += airAdd;

            if(airCurrent > airStart)
            {
                airCurrent = airStart;
            }
        }
        else
        {
            airCurrent -= airSubtract;
        }
    }
}
