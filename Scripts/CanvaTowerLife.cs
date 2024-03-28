using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CanvaTowerLife : MonoBehaviour
{

    public TextMeshProUGUI enemyLifeText;
    public TextMeshProUGUI playerLifeText;
    public TextMeshProUGUI timeText;
    public float time = 180;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 
        if(time > 0){
            time -= Time.deltaTime;
        } else {
            time = 0;
        }

        FightSystem.startTimeout(time);

        timeText.text = FightSystem.countdown;

        if(FightSystem.player1TowerLife <= 0){
            playerLifeText.text = "Player Life: 0";
        } else {
            playerLifeText.text = "Player Life: " + FightSystem.player1TowerLife.ToString();
        }
        if(FightSystem.player2TowerLife <= 0){
            enemyLifeText.text = "Enemy Life: 0";
        } else {
            enemyLifeText.text = "Enemy Life: " + FightSystem.player2TowerLife.ToString();
        }
      
    }
}
