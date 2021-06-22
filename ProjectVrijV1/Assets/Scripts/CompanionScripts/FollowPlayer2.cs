using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer2 : MonoBehaviour
{
    public NavMeshAgent agent;

    public Animator animator;
    public float InputX;
    public float InputY;

    public Transform player;

    public int companionHealth;
    public int companionDamageGive;

    public bool canFollow;
    public bool isFollowing;

    public int commandDistance = 6;

    //patrolling
    public Vector3 walkPoint;
    public float walkPointRange;

    //states
    public float sightRange; 
    bool playerInsightRange;

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        animator = this.gameObject.GetComponent<Animator>();

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
        }

        if (isFollowing == false)
        {
            InputX = 0;
            InputY = 0;
           animator.SetFloat("InputX", InputX);
           animator.SetFloat("InputY", InputY);
        }

        if(Vector3.Distance(player.transform.position, transform.position) < 0.6f)
        {
            InputX = 0;
            InputY = 0;
            animator.SetFloat("InputX", InputX);
            animator.SetFloat("InputY", InputY);
        }
        else if(isFollowing == true)
        {
            InputX = 1;
            InputY = 1;
            animator.SetFloat("InputX", InputX);
            animator.SetFloat("InputY", InputY);
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
        if (Input.GetKeyDown(KeyCode.F) && isFollowing == true && Vector3.Distance(player.transform.position, transform.position) < commandDistance)
        {
            isFollowing = false;
            canFollow = false;
        }
    }

    private void ComeWithPlayer()
    {
        if (Input.GetKeyDown(KeyCode.E) && isFollowing == false && Vector3.Distance(player.transform.position, transform.position) < commandDistance)
        {
            isFollowing = true;
            canFollow = true;

            InputX = 1;
            InputY = 1;
            animator.SetFloat("InputX", InputX);
            animator.SetFloat("InputY", InputY);

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
