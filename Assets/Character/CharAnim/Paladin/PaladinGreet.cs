using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Greet : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    public GameObject target;
    public AudioSource src;
    public AudioClip sfx0,sfx1;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.G) )//greet
        {
            animator.SetInteger("State", 1);
            src.clip = sfx0;
            src.Play();
        }
        else if (Input.GetKey(KeyCode.F))//walk 
        {
            animator.SetInteger("State", 2);
            src.clip = sfx1;
            src.Play();
            agent.SetDestination(target.transform.position);
            
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            animator.SetInteger("State", 0);
            src.Stop();
        }
    }
}
