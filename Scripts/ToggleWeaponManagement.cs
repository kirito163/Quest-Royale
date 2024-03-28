using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToggleWeaponManagement : MonoBehaviour
{   
    
    [SerializeField] TextMeshProUGUI coltPriceText;
    [SerializeField] TextMeshProUGUI mgSmallPriceText;
    [SerializeField] TextMeshProUGUI mgLargePriceText;
    [SerializeField] TextMeshProUGUI axPriceText;
    [SerializeField] GameObject coltCheckArmy;
    [SerializeField] GameObject mgSmallCheckArmy;
    [SerializeField] GameObject mgLargeCheckArmy;
    [SerializeField] GameObject axCheckArmy;

    
    private void Start() {
        coltCheckArmy.SetActive(false);
        mgSmallCheckArmy.SetActive(false);
        axCheckArmy.SetActive(false);
        mgLargeCheckArmy.SetActive(false);

    }
    
        public void EnableImgPrice(List<GameArmy> playerArmy){
            foreach(GameArmy army in playerArmy){
                if(army.Name == "colt"){
                coltPriceText.GetComponent<TextMeshProUGUI>().enabled = false;
                coltCheckArmy.SetActive(true);
                } else if(army.Name == "machineGunSmall"){
                mgSmallPriceText.GetComponent<TextMeshProUGUI>().enabled = false;
                mgSmallCheckArmy.SetActive(true);

                } else if(army.Name == "ax"){
                axPriceText.GetComponent<TextMeshProUGUI>().enabled = false;
                axCheckArmy.SetActive(true);

                } else if(army.Name == "machineGunLarge"){
                mgLargePriceText.GetComponent<TextMeshProUGUI>().enabled = false;
                mgLargeCheckArmy.SetActive(true);
                } 
            }
        
        }
        
        


    
}
