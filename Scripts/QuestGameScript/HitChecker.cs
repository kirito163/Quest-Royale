using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitChecker : MonoBehaviour
{


    // private void OnTriggerEnter(Collider other)
    // {
    //     if (FightSystem.isPlay && FightSystem.isFight)
    //     {
    //         if (other.gameObject.layer == 7)
    //         {
    //             FightSystem.monsterEnemyInGame[other.gameObject.tag]
    //             .setLife(FightSystem.monsterEnemyInGame[other.gameObject.tag].getLife() - 
    //             FightSystem.monsterPlayerInGame[this.gameObject.tag].getAttack());

    //             if (FightSystem.monsterEnemyInGame[other.gameObject.tag].getLife() <= 0)
    //             {
    //                 Destroy(FightSystem.monsterEnemyInGame[other.gameObject.tag].getMonstersObj());
    //             }
    //         }
    //         else if (other.gameObject.layer == 6)
    //         {
    //             FightSystem.monsterPlayerInGame[other.gameObject.tag]
    //            .setLife(FightSystem.monsterPlayerInGame[other.gameObject.tag].getLife() - 
    //            FightSystem.monsterEnemyInGame[this.gameObject.tag].getAttack());

    //             if (FightSystem.monsterPlayerInGame[other.gameObject.tag].getLife() <= 0)
    //             {
    //                 Destroy(FightSystem.monsterPlayerInGame[other.gameObject.tag].getMonstersObj());
    //             }
    //         }
    //         else if (other.gameObject.layer == 9)
    //         {
    //             FightSystem.player1TowerLife -= FightSystem.monsterEnemyInGame[this.gameObject.tag].getAttack();

    //         }
    //         else if (other.gameObject.layer == 8)
    //         {
    //             FightSystem.player2TowerLife -= FightSystem.monsterPlayerInGame[this.gameObject.tag].getAttack();
    //             Debug.Log("tower enemy life: "+FightSystem.player2TowerLife);

    //         }


    //     }
    // }

    



}
