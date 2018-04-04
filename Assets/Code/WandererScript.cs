using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WandererScript : MonoBehaviour {

    NavMeshAgent agent;
    public Transform[] targets;
    private Transform target;
    private float timer;

    public float wanderTime;


	void Start () {

        agent = GetComponent<NavMeshAgent>();
        timer = 0f;

        target = targets[Random.Range(0, targets.Length)];

    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if(timer > wanderTime)
        {
            target = targets[Random.Range(0, targets.Length)];
            timer = 0f;
        }

        agent.SetDestination(target.position);
	}
}
