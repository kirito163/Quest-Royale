using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class GameManager : MonoBehaviour
{   
    //SavingShoppedArmy savingShoppedArmy;
    Player player;
    GameArmy revolver;
    GameArmy knife;
    GameArmy colt;
    GameArmy machineGunSmall;
    GameArmy ax;
    GameArmy machineGunLarge;
    Toggle toggleArmySelected;
    public Button shopButton;
    public Button startButton;
    public TextMeshProUGUI textArmySelected;
    public TextMeshProUGUI textPlayerMoney;
    public GameObject LoadingCanvas;
    public Slider loadingSlider;
    GameArmy armySelected;
    GameObject shopButtonObject;
    public GameObject toggleGroupObjectArmy;
    ToggleWeaponManagement toggleWeaponManagement;
    ToggleGroup toggleGroup;
    
   
    // Start is called before the first frame update
    void Start()
    {
        shopButtonObject = shopButton.gameObject;
        player = Player.player;
        toggleWeaponManagement = toggleGroupObjectArmy.GetComponent<ToggleWeaponManagement>();
        toggleGroup = toggleGroupObjectArmy.GetComponent<ToggleGroup>();
        revolver = new GameArmy("revolver", 0);
        knife = new GameArmy("knife", 0);
        player.usableArmy.Add(revolver);
        player.usableArmy.Add(knife);
        
       
       // savingShoppedArmy.Save(player);
        //player = savingShoppedArmy.Load();
        colt = new GameArmy("colt", 20000);
        machineGunSmall = new GameArmy("machineGunSmall", 70000);
        ax = new GameArmy("ax", 95500);
        machineGunLarge = new GameArmy("machineGunLarge", 150000);
        shopButton.onClick.AddListener(TaskOnClick);
        startButton.onClick.AddListener(StartOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
        toggleArmySelected = toggleGroup.ActiveToggles().FirstOrDefault();
        toggleWeaponManagement.EnableImgPrice(player.usableArmy);
        SetSelectedWeapon();
        SelectedGameArmy();
        textPlayerMoney.text = "MONEY: " + player.money.ToString();

    }
    public void StartOnClick(){
        Player.player.army = armySelected;
        StartCoroutine(LoadScene());
        
    }

    IEnumerator LoadScene(){
        
        AsyncOperation operation = SceneManager.LoadSceneAsync("GameScene", LoadSceneMode.Single);
        LoadingCanvas.SetActive(true);
        while (!operation.isDone){
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            loadingSlider.value = progressValue;
            yield return null;
            
        }
        LoadingCanvas.SetActive(false);
    }

    

    public void SelectedGameArmy(){
        if(toggleArmySelected.name == "RevolverToggle"){
            armySelected = revolver;
        } else if(toggleArmySelected.name == "KnifeToggle"){
            armySelected = knife;
        } else if(toggleArmySelected.name == "ColtToggle" && player.usableArmy.Contains(colt)){
            armySelected = colt;
        } else if(toggleArmySelected.name == "MachineGunSmallToggle" && player.usableArmy.Contains(machineGunSmall)){
            armySelected = machineGunSmall;
        } else if(toggleArmySelected.name == "AxToggle" && player.usableArmy.Contains(ax)){
            armySelected = ax;
        } else if(toggleArmySelected.name == "MachineGunLargeToggle" && player.usableArmy.Contains(machineGunLarge)){
            armySelected = machineGunLarge;
    } 
    textArmySelected.text = "ARMY SELECTED: " + armySelected.Name;
    }
 
   
    public void SetSelectedWeapon(){

        if(toggleGroup.AnyTogglesOn()){

            if(toggleArmySelected.name == "RevolverToggle"){
                shopButtonObject.SetActive(false);
                
            } else if(toggleArmySelected.name == "KnifeToggle"){
                shopButtonObject.SetActive(false);
                
            } else if(toggleArmySelected.name == "ColtToggle"){
                if(!player.usableArmy.Contains(colt) && player.money > colt.Price){
                shopButtonObject.SetActive(true);
                } else {
                shopButtonObject.SetActive(false);
                }
            } else if(toggleArmySelected.name == "MachineGunSmallToggle"){
                if(!player.usableArmy.Contains(machineGunSmall) && player.money > machineGunSmall.Price){
                shopButtonObject.SetActive(true);
                } else {
                shopButtonObject.SetActive(false);
                }
            } else if(toggleArmySelected.name == "AxToggle"){
                if(!player.usableArmy.Contains(ax) && player.money > ax.Price){
                shopButtonObject.SetActive(true);
                } else {
                shopButtonObject.SetActive(false);
                }
            } else if(toggleArmySelected.name == "MachineGunLargeToggle"){
                if(!player.usableArmy.Contains(machineGunLarge) && player.money > machineGunLarge.Price){
                shopButtonObject.SetActive(true);
                } else {
                shopButtonObject.SetActive(false);
            }
        } 
    }else {
            shopButtonObject.SetActive(false);
        }
    }



     void TaskOnClick(){
        
        if(toggleArmySelected.name == "ColtToggle"){
            if(!player.usableArmy.Contains(colt) && player.money > colt.Price){
                player.usableArmy.Add(colt);
                player.money -= colt.Price;
               // savingShoppedArmy.Save(player);  
            }
        } else if(toggleArmySelected.name == "MachineGunSmallToggle"){
            if(!player.usableArmy.Contains(machineGunSmall) && player.money > machineGunSmall.Price){
                player.usableArmy.Add(machineGunSmall);
                player.money -= machineGunSmall.Price; 
                //savingShoppedArmy.Save(player);  
            }
        } else if(toggleArmySelected.name == "AxToggle"){
            if(!player.usableArmy.Contains(ax) && player.money > ax.Price){
                player.usableArmy.Add(ax);
                player.money -= ax.Price;  
               // savingShoppedArmy.Save(player); 
            } 
        } else if(toggleArmySelected.name == "MachineGunLargeToggle"){
            if(!player.usableArmy.Contains(machineGunLarge) && player.money > machineGunLarge.Price){
                player.usableArmy.Add(machineGunLarge);
                player.money -= machineGunLarge.Price;  
               // savingShoppedArmy.Save(player); 
            }
        }
    }

}
