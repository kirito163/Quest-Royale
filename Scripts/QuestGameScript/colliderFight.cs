using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class colliderFight : MonoBehaviour
{
    Transform towerEnemy;

    public GameObject monster;
    public Animator animator;
    public Collider other;
    public NavMeshAgent agent;
    
    void Start()
    {
        towerEnemy = GameObject.Find("enemyBase").GetComponent<Transform>();

    }
    void Update()
    {
           
    }

    // provare a fixare l ingresso dell trigger perche una volta entrato non controlla piu, quindi provare a utilizzare onTriggerStay
    void OnTriggerStay(Collider other)
    {
        if ((monster.tag == "Player1Monster" && (other.gameObject.tag == "Player2Monster" || other.gameObject.tag == "Player2Tower"))
         || (monster.tag == "Player2Monster" && (other.gameObject.tag == "Player1Monster" || other.gameObject.tag == "Player1Tower")))
        {
            this.other = other;
            agent.isStopped = true;
            animator.SetBool("isFight", true);
        }
    }





}
