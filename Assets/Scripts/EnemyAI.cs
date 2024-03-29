﻿using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;


public class EnemyAI : MonoBehaviour
{

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private bool isPursuing;
    private Transform playerTrans;
    private float pursueTimer;
    private TextMeshPro text;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        text = GetComponentInChildren<TextMeshPro>();
        text.fontSize = 0;

        agent.autoBraking = false;
        destPoint = 1;
    }

    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (!agent.pathPending && agent.remainingDistance < 0.5f && !isPursuing)
            GotoNextPoint();
        if(isPursuing)
            Pursue();

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
        Debug.Log("wait 1");
        yield return new WaitForSeconds(0);
    }

    public void PursuePlayer(Transform playerTransform)
    {
        playerTrans = playerTransform;
        agent.destination = playerTrans.position;
        isPursuing = true;
        pursueTimer = 4.0f;
        text.fontSize = 20;
        if(!GetComponent<AudioSource>().isPlaying)
            GetComponent<AudioSource>().Play(0);
    }

    void Pursue()
    {
        Debug.Log("pursuing!!!");
        pursueTimer -= Time.deltaTime;
        if(pursueTimer <= 0.0f)
        {
            Debug.Log("ending pursuit");
            isPursuing = false;
            GetComponent<AudioSource>().Stop();
            text.fontSize = 0;
        }
        agent.destination = playerTrans.position;
    }
}