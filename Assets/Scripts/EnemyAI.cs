using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.SceneManagement;


public class EnemyAI : MonoBehaviour
{

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;
        destPoint = 1;
    }

    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
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
        
        agent.speed = 5;
    }

    public void PursuePlayer(Transform playerTransform)
    {
        agent.destination = playerTransform.position;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            print("ghost got you");
            SceneManager.LoadScene("LoseScene");
        }
    }
}