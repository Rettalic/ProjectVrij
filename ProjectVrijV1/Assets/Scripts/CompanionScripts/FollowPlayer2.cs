using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer2 : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;
    public Transform player2;


    public int companionHealth;
    public int companionDamageGive;

    public bool canFollow;
    public bool isFollowing;

    //patrolling
    public Vector3 walkPoint;
    public float walkPointRange;

    //states
    public float sightRange;
    bool playerInsightRange;

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        canFollow = true;
        isFollowing = true;
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        StayPut();
        ComeWithPlayer();
        playerInsightRange = Physics.CheckSphere(player.transform.position, sightRange);


        if (playerInsightRange && canFollow == true) ChasePlayer();


        if (companionHealth <= 0)
        {
            Destroy(gameObject);
            GoldPoints.Instance.dropGold(5);
        }
    }

    private void ChasePlayer()
    {
        StartCoroutine(ChasePlayerNum());
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerProjectile"))
        {
            companionTakeDamage(50);
        }
    }

    public void companionTakeDamage(int companionDamageTake)
    {
        companionHealth -= companionDamageTake;
    }

    private void StayPut()
    {
        if (Input.GetKeyDown(KeyCode.F) && isFollowing == true && Vector3.Distance(player2.transform.position, transform.position) < 4)
        {
            isFollowing = false;
            canFollow = false;
        }
    }

    private void ComeWithPlayer()
    {
        if (Input.GetKeyDown(KeyCode.E) && isFollowing == false && Vector3.Distance(player2.transform.position, transform.position) < 4)
        {
            isFollowing = true;
            canFollow = true;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    IEnumerator ChasePlayerNum()
    {
        agent.SetDestination(player.position);
        yield return new WaitForSeconds(0.5f);
    }
}
