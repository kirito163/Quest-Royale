using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using System.Linq;
using UnityEngine.InputSystem;

public class TogglesSetMonster : MonoBehaviour
{
    public InputActionProperty leftInputController;
    public InputActionProperty rightInputController;
    public GameObject warriorMonster;
    public GameObject ponchyMonster;
    public GameObject sparrowMonster;
    public GameObject robotMonster;
    public GameObject rhinoMonster;
    public GameObject wrestlerMonster;
    ToggleGroup toggleGroup;
    GameObject monsterSeelcted;


    Slider sliderEnergy;
    Image toggleImg1;
    Image toggleImg2;
    Image toggleImg3;
    Image toggleImg4;

    float timeToInstance;

    float energy = 0;
    int maxEnergy = 10;
    List<GameObject> monsterList = new List<GameObject>();
    public XRRayInteractor leftRayInteractor;
    public XRRayInteractor rightRayInteractor;

    public void createMonsterList()
    {

        monsterList.Add(warriorMonster);
        monsterList.Add(ponchyMonster);
        monsterList.Add(sparrowMonster);
        monsterList.Add(robotMonster);
        monsterList.Add(rhinoMonster);
        monsterList.Add(wrestlerMonster);
    }

    private void serchToggleImg()
    {
        sliderEnergy = GameObject.Find("Slider").GetComponent<Slider>();
        toggleImg1 = GameObject.Find("Toggle4/Background").GetComponent<Image>();
        toggleImg2 = GameObject.Find("Toggle3/Background").GetComponent<Image>();
        toggleImg3 = GameObject.Find("Toggle2/Background").GetComponent<Image>();
        toggleImg4 = GameObject.Find("Toggle1/Background").GetComponent<Image>();
    }

    public void triggerOnbuttonSelect()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        serchToggleImg();
        toggleGroup = GetComponent<ToggleGroup>();
        toggleGroup.SetAllTogglesOff();
        createMonsterList();
        setRandomMonsterList();
        setMonsterToggle();

    }

    // Update is called once per frame
    void Update()
    {
        setEnergy();
        instantiateMonsterToggleSelected();

    }

    public void setMonsterToggle()
    {
        toggleImg1.sprite = monsterList[0].GetComponent<Monster>().getToggleImg();
        toggleImg2.sprite = monsterList[1].GetComponent<Monster>().getToggleImg();
        toggleImg3.sprite = monsterList[2].GetComponent<Monster>().getToggleImg();
        toggleImg4.sprite = monsterList[3].GetComponent<Monster>().getToggleImg();


    }

    public void setEnergy()
    {
        energy = energy += Time.deltaTime;
        if (energy >= maxEnergy)
        {
            energy = 10;
        }
        sliderEnergy.value = Mathf.Round(energy) / 10;
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

    public void swapList(GameObject monst)
    {
        monsterList[4] = monsterList[5];
        monsterList[5] = monst;
       

    }

    public void instantiateMonsterToggleSelected()
    {
        RaycastHit res;

        GameObject monst;
        Toggle toggleSelected;
        if (toggleGroup.AnyTogglesOn())
        { Debug.Log("toggleon");
            //  && res.collider.gameObject.tag == "Plane"
            //  && rightInputController.action.IsPressed()
            // (Dropdown.isPistoRighHand && leftRayInteractor.TryGetCurrent3DRaycastHit(out res) && res.collider.gameObject.tag == "Plane" && leftInputController.action.IsPressed())
            toggleSelected = toggleGroup.ActiveToggles().FirstOrDefault();
            if ((!Dropdown.isPistoRighHand && rightRayInteractor.TryGetCurrent3DRaycastHit(out res) && res.collider.gameObject.tag == "Plane" && rightInputController.action.IsPressed())
            || (Dropdown.isPistoRighHand && leftRayInteractor.TryGetCurrent3DRaycastHit(out res) && res.collider.gameObject.tag == "Plane" && leftInputController.action.IsPressed()))
            {
                int monstPrice;
                Sprite monstImage = monsterList[4].GetComponent<Monster>().getToggleImg();

                switch (toggleSelected.name)
                {
                    case "Toggle4":
                    Debug.Log("ciao");
                        monst = monsterList[0];
                        monstPrice = monst.GetComponent<Monster>().getPrice();
                        if (monstPrice <= energy)
                        {
                            energy -= monstPrice;
                            Instantiate(monst, res.point, Quaternion.identity);
                            toggleImg1.sprite = monstImage;
                            monsterList[0] = monsterList[4];
                            swapList(monst);
                        }
                        break;

                    case "Toggle3":
                        monst = monsterList[1];
                        monstPrice = monst.GetComponent<Monster>().getPrice();
                        if (monstPrice <= energy)
                        {
                            energy -= monstPrice;
                            Instantiate(monst, res.point, Quaternion.identity);
                            toggleImg2.sprite = monstImage;
                            monsterList[1] = monsterList[4];
                            swapList(monst);
                        }
                        break;

                    case "Toggle2":
                        monst = monsterList[2];
                        monstPrice = monst.GetComponent<Monster>().getPrice();

                        if (monstPrice <= energy)
                        {
                            energy -= monstPrice;
                            Instantiate(monst, res.point, Quaternion.identity);
                            toggleImg3.sprite = monstImage;
                            monsterList[2] = monsterList[4];
                            swapList(monst);
                        }
                        break;

                    case "Toggle1":
                        monst = monsterList[3];
                                                monstPrice = monst.GetComponent<Monster>().getPrice();

                        if (monstPrice <= energy)
                        {
                            energy -= monstPrice;
                            Instantiate(monst, res.point, Quaternion.identity);
                            toggleImg4.sprite = monstImage;
                            monsterList[3] = monsterList[4];
                            swapList(monst);
                        }
                        break;
                }
                toggleGroup.SetAllTogglesOff();
            }
        }
    }
}
