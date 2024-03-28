using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MonsterDestination : MonoBehaviour
{
    Transform towerEnemy;
    Transform towerPlayer;
    NavMeshAgent agent;
    public Transform spawnPoint;
    public float fireSpeed = 20;
    Animator animator;
    public GameObject colliderFight;
    AudioSource monsterAudio;
    int attack;

    void Start()
    {
        monsterAudio = this.gameObject.GetComponent<AudioSource>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        towerEnemy = GameObject.Find("enemyBase").GetComponent<Transform>();
        towerPlayer = GameObject.Find("PlayerBase").GetComponent<Transform>();
        animator = this.gameObject.GetComponent<Animator>();
        attack = this.gameObject.GetComponent<Monster>().attack;

        if (this.gameObject.tag == "Player1Monster")
        {
            agent.SetDestination(towerEnemy.position);

        }
        else if (this.gameObject.tag == "Player2Monster")
        {
            agent.SetDestination(towerPlayer.position);

        }

    }


    // Update is called once per frame
    void Update()
    {
    }



    private void OnTriggerStay(Collider other)
    {
        if ((this.gameObject.tag == "Player1Monster" && other.gameObject.tag == "Player2Monster")
         || (this.gameObject.tag == "Player2Monster" && other.gameObject.tag == "Player1Monster"))
        {
            agent.SetDestination(other.gameObject.transform.position);
        }
        else
        {


        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (this.gameObject.tag == "Player1Monster" && other.gameObject.tag == "Player2Monster")
        {
            agent.SetDestination(towerEnemy.position);
        }
        else if (this.gameObject.tag == "Player2Monster" && other.gameObject.tag == "Player1Monster")
        {
            agent.SetDestination(towerPlayer.position);

        }
    }

    public void shootBulletAnim()
    {
        
    }

    void hitAnim()
    {   
        monsterAudio.Play();
        Collider other = colliderFight.GetComponent<colliderFight>().other;
        int otherLife;
        if (animator.GetBool("isFight") && other != null)
        {
            if ((this.gameObject.tag == "Player1Monster" && other.gameObject.tag == "Player2Monster")
             || (this.gameObject.tag == "Player2Monster" && other.gameObject.tag == "Player1Monster"))
            {
                if(other.gameObject != null){
                otherLife = other.gameObject.GetComponent<Monster>().getLife();
                other.gameObject.GetComponent<Monster>().setLife(otherLife -= attack);
                }
            }

            else if (other.gameObject.tag == "Player1Tower")
            {
                FightSystem.player1TowerLife -= attack;

            }
            else if (other.gameObject.tag == "Player2Tower")
            {
                FightSystem.player2TowerLife -= attack;

            }
        }
        else
        {
            animator.SetBool("isFight", false);
            agent.isStopped = false;

            if (this.gameObject.tag == "Player1Monster")
            {
                agent.SetDestination(towerEnemy.position);
            }
            else if (this.gameObject.tag == "Player2Monster")
            {
                agent.SetDestination(towerPlayer.position);

            }
        }
    }
}
