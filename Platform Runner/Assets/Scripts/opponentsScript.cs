using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class opponentsScript : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator anim;
    private bool agentIsFinish;



    void Update()
    {
        if (agentIsFinish == false)
        {
            agent.destination = target.position;

        }
        if (agentIsFinish == false)
        {
            if (transform.position.z >= target.position.z - 1.5f)
            {
                anim.SetBool("dance", true);
                agentIsFinish = true;
                target.position = target.position + new Vector3(3, 0, 0);
                gameObject.GetComponent<CapsuleCollider>().enabled = false;
                gameObject.GetComponent<NavMeshAgent>().enabled = false;

            }
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle" ||  collision.gameObject.tag == "human")
        {
            basaDon();
        }
       
    }

    void basaDon()
    {
        transform.position = new Vector3(0, 0, 0);
    }
}
