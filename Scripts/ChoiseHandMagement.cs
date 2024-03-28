using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ChoiseHandMagement : MonoBehaviour
{
 
   /* 

    
    */
    ToggleGroup handsToggleGroup;
    Toggle toggleHand;

    
    // Start is called before the first frame update
    void Start()
    {
        handsToggleGroup = this.gameObject.GetComponent<ToggleGroup>();

    }

    // Update is called once per frame
    void Update()
    {
        selectHand();
    }

    public void selectHand(){
        toggleHand = handsToggleGroup.ActiveToggles().FirstOrDefault();
      
            if(toggleHand.gameObject.name == "LeftHandToggle"){
                Player.player.isRightHand = false;

 /*
                
                leftHandInteractor.enabled = false;
                rightHandInteractor.enabled = true;
*/
            } else {
               
                Player.player.isRightHand = true;

            }
        
    }
}
