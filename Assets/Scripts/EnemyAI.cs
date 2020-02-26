using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class EnemyAI : MonoBehaviour
{

    public Transform[] points;
    public GameObject player;
    public Transform playertransform;
    public bool isPursuing;
    public bool canSeePlayer;

    private int destPoint = 0;
    private NavMeshAgent agent;
    private float pursueTimer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;
        destPoint = 1;
    }

    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (!isPursuing && !agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }

        if(isPursuing)
        {
            PursuePlayer(player);
            Debug.Log(playertransform.transform);
        }
    }

    void GotoNextPoint()
    {
        
        // Returns if no points have been set up
        if (agent.destination != points[destPoint].position)
        {
            StartCoroutine(MyWaitMethod());
            agent.destination = points[destPoint].position;
        }

        // Set the agent to go to the currently selected destination.
        
        //Debug.Log("I'm headed to: " + agent.destination);

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
        Debug.Log("I'm at: " + destPoint);
    }

    IEnumerator MyWaitMethod()
    {
        agent.speed = 0;
        Debug.Log("wait 1");
        yield return new WaitForSeconds(1);
        
        agent.speed = 3;
    }

    public void StartPursuingPlayer(GameObject playerHit)
    {
        isPursuing = true;
        canSeePlayer = true;
        player = playerHit;
        playertransform = player.transform;
        agent.destination = playertransform.position;
    }

    void PursuePlayer(GameObject player)
    {
        agent.destination = player.transform.position;
        if (!canSeePlayer)
        {
            pursueTimer += Time.deltaTime;
            if(pursueTimer == 3.0f)
            {
                isPursuing = false;
                pursueTimer = 0.0f;
            }
        }
        else if(canSeePlayer && pursueTimer >= 0.0f)
        {
            pursueTimer = 0.0f;
        }
        
    }
}