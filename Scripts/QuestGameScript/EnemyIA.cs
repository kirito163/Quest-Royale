using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIA : MonoBehaviour
{
    List<GameObject> monsterList = new List<GameObject>();
    public GameObject warriorMonster;
    public GameObject ponchyMonster;
    public GameObject sparrowMonster;
    public GameObject robotMonster;
    public GameObject rhinoMonster;
    public GameObject wrestlerMonster;
    public GameObject endCanvas;
    public GameObject selectMonsterCanvas;
    Animator animator;
    float ene = 0;
    float energy = 0;
    int maxEnergy = 10;
    int time = 180;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        endCanvas = GameObject.Find("CanvasEndGame");
        selectMonsterCanvas = GameObject.Find("RedGrabCanv");
        endCanvas.SetActive(false);
        selectMonsterCanvas.SetActive(true);
        createMonsterList();
        setRandomMonsterList();
        FightSystem.isPlay = true;
    }

    // Update is called once per frame
    void Update()
    {
        setEnergy();
        instantiateMonster();
        loopGame();

    }

    public void setEnergy()
    {
        ene = ene += Time.deltaTime;
        if (ene >= maxEnergy)
        {
            ene = 10;
        }
        energy = Mathf.Round(ene);

    }
    public void setRandomMonsterList()
    {
        for (int i = 0; i < monsterList.Count; i++)
        {
            GameObject temp = monsterList[i];
            int randomIndex = Random.Range(i, monsterList.Count);
            monsterList[i] = monsterList[randomIndex];
            monsterList[randomIndex] = temp;

        }
    }

    public void createMonsterList()
    {

        monsterList.Add(warriorMonster);
        monsterList.Add(ponchyMonster);
        monsterList.Add(sparrowMonster);
        monsterList.Add(robotMonster);
        monsterList.Add(rhinoMonster);
        monsterList.Add(wrestlerMonster);
    }

    public void instantiateMonster()
    {

        if (energy > 5)
        {

            animator.SetBool("isThrow", true);
        }
        else
        {
            animator.SetBool("isThrow", false);

        }

    }




    public void createMonster()
    {
        if (animator.GetBool("isThrow") && FightSystem.isPlay)
        {


            GameObject monst = monsterList[Random.Range(0, 3)];
            int monstPrice = monst.GetComponent<Monster>().getPrice();
            if (monstPrice <= energy)
            {
                Vector3 pos = new Vector3(Random.Range(245, 276), 0, Random.Range(145, 188));
                Instantiate(monst, pos, Quaternion.identity);
                this.ene = this.energy -= monstPrice;
                monsterList[0] = monsterList[4];
                swapList(monst);

            }

        }
    }
    public void swapList(GameObject monst)
    {
        monsterList[4] = monsterList[5];
        monsterList[5] = monst;


    }


    public void loopGame()
    {
        if (FightSystem.isPlay && (FightSystem.countdown.Equals("00:00") || FightSystem.player1TowerLife <= 0 || FightSystem.player2TowerLife <= 0))
        {
            FightSystem.isPlay = false;
            if (FightSystem.player1TowerLife <= 0)
            {
                animator.SetBool("isVictory", true);
                FightSystem.isPlayer2win = true;
                FightSystem.isPlayer1win = false;
            }
            else if (FightSystem.player2TowerLife <= 0)
            {
                animator.SetBool("isLose", true);
                FightSystem.isPlayer1win = true;
                FightSystem.isPlayer2win = false;
            }
            else if (FightSystem.countdown.Equals("00:00"))
            {
                if (FightSystem.player1TowerLife > FightSystem.player2TowerLife)
                {
                    animator.SetBool("isLose", true);
                    FightSystem.isPlayer1win = true;
                    FightSystem.isPlayer2win = false;
                }
                else
                {
                    animator.SetBool("isVictory", true);
                    FightSystem.isPlayer2win = true;
                    FightSystem.isPlayer1win = false;
                }
            }
            selectMonsterCanvas.SetActive(false);
            endCanvas.SetActive(true);
            ene = energy = 0;
            




        }
    }

}
