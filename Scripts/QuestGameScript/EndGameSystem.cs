using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class EndGameSystem : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void endGameButtonYes()
    {
        SceneManager.LoadScene("QuestRoyaleScene", LoadSceneMode.Single);
        this.gameObject.SetActive(false);
        FightSystem.isPlay = true;
        FightSystem.player1TowerLife = 1000;
        FightSystem.player2TowerLife = 1000;
    }

    public void endGameButtonNo()
    {
        SceneManager.LoadScene("InitialScene", LoadSceneMode.Single);
        this.gameObject.SetActive(false);

    }







}
