using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer2 : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    /* public int companionHealth;


     public LayerMask whatIsGround, whatIsPlayer;

     //patrolling
     public Vector3 walkPoint;
     public float walkPointRange;

     //states
     public float sightRange, followRange;
     bool playerInsightRange, playerInAttackRange;

     void Start()
     {
         agent = gameObject.GetComponent<NavMeshAgent>();
     }

     private void Awake()
     {
         player = GameObject.Find("Player").transform;
         agent = GetComponent<NavMeshAgent>();
     }

     private void Update()
     {
         playerInsightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
         playerInAttackRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

         if (playerInsightRange && !playerInAttackRange) ChasePlayer();

         if (companionHealth <= 0)
         {
             Destroy(gameObject);

         }
     }

     private void ChasePlayer()
     {
         agent.SetDestination(player.position);

     }

     void OnTriggerEnter(Collider other)
     {
         if (other.CompareTag("PlayerProjectile"))
         {
             CompanyTakeDamage(50);
         }
     }

     public void CompanyTakeDamage(int companionDamageTake)
     {
         companionHealth -= companionDamageTake;
     }


     private void OnDrawGizmosSelected()
     {
         Gizmos.color = Color.red;
         Gizmos.DrawWireSphere(transform.position, sightRange);
         Gizmos.color = Color.blue;
         Gizmos.DrawWireSphere(transform.position, sightRange);
     } */

    private void Update()
    {
        agent.SetDestination(player.position);
    }
}
