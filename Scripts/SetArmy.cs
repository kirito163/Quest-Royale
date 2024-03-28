using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class SetArmy : MonoBehaviour
{
    public XRDirectInteractor leftHandInteractor;
    public XRDirectInteractor rightHandInteractor;
    public GameObject revolverPrefab;
    public GameObject knifePrefab;
    public GameObject coltPrefab;
    public GameObject mgSmallPrefab;
    public GameObject axPrefab;
    public GameObject mgLargePrefab;
    public Transform rightRevolverPoint;
    public Transform leftRevolverPoint;
    public Transform rightKnifePoint;
    public Transform leftKnifePoint;
    public Transform rightColtPoint;
    public Transform leftColtPoint;
    public Transform rightAxPoint;
    public Transform leftAxPoint;
    public Transform rightMGSmallPoint;
    public Transform leftMGSmallPoint;
    public Transform rightMGLargePoint;
    public Transform leftMGLargePoint;
    



    // Start is called before the first frame update
    void Start()
    {
       setHandleWeapon();
       createArmy();
        
       
        
    }


    public void setHandleWeapon(){
         if(Player.player.isRightHand){
            rightHandInteractor.enabled =false;
            leftHandInteractor.enabled =true;
        } else {
            rightHandInteractor.enabled =true;
            leftHandInteractor.enabled =false;
        }
    }
     
    public void createArmy(){
        Transform handPosition;
        GameObject armyPrefab;
        if(Player.player.army.Name == "revolver"){
            if(Player.player.isRightHand){
                handPosition = rightRevolverPoint;
            } else {
                handPosition = leftRevolverPoint;
            }
            
            armyPrefab = Instantiate(revolverPrefab, handPosition.position, handPosition.rotation, handPosition);

        } else if(Player.player.army.Name == "knife"){
            if(Player.player.isRightHand){
                handPosition = rightKnifePoint;
            } else {
                handPosition = leftKnifePoint;
            }
            
            armyPrefab = Instantiate(knifePrefab, handPosition.position, handPosition.rotation, handPosition);
        
        } else if(Player.player.army.Name == "machineGunSmall"){
            if(Player.player.isRightHand){
                handPosition = rightMGSmallPoint;
            } else {
                handPosition = leftMGSmallPoint;
            }
            
            armyPrefab = (GameObject)Instantiate(mgSmallPrefab, handPosition.position, handPosition.rotation, handPosition);
        
        } else if(Player.player.army.Name == "ax"){
            if(Player.player.isRightHand){
                handPosition = rightAxPoint;
            } else {
                handPosition = leftAxPoint;
            }
            
            armyPrefab = (GameObject)Instantiate(axPrefab, handPosition.position, handPosition.rotation, handPosition);
                 
        
        } else if(Player.player.army.Name == "machineGunLarge"){
            if(Player.player.isRightHand){
                handPosition = rightMGLargePoint;
            } else {
                handPosition = leftMGLargePoint;
            }
            
            armyPrefab = (GameObject)Instantiate(mgLargePrefab, handPosition.position, handPosition.rotation, handPosition);
              
        }
    }
    
}
