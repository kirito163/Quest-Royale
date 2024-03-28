using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FightSystem : MonoBehaviour
{
    public static FightSystem fightSystem;

    
    public static bool isPlay = false;
    public static int player1TowerLife = 1000;
    public static int player2TowerLife = 1000;
    public static string countdown;
   
    public static bool isPlayer1win = false;
    public static bool isPlayer2win = false;
    

   
   

      public static void startTimeout(float time){
        if (time <= 0)
        {
            time = 0;
        }
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        countdown = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
