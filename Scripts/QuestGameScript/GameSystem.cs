using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameSystem : MonoBehaviour
{
    public Button startButton;
    public GameObject LoadingCanvas;
    public Slider loadingSlider;


    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartOnClick);

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void StartOnClick()
    {
        // StartCoroutine(LoadScene());
        SceneManager.LoadScene("QuestRoyaleScene", LoadSceneMode.Single);
        FightSystem.isPlay = true;
        FightSystem.player1TowerLife = 1000;
        FightSystem.player2TowerLife = 1000;
    }

    // IEnumerator LoadScene()
    // {

    //     AsyncOperation operation = SceneManager.LoadSceneAsync("QuestRoyaleScene", LoadSceneMode.Single);
    //     LoadingCanvas.SetActive(true);
    //     while (!operation.isDone)
    //     {
    //         float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
    //         loadingSlider.value = progressValue;
    //         yield return null;

    //     }
    //     LoadingCanvas.SetActive(false);
    //     FightSystem.isPlay = true;
    //     FightSystem.time = 180;
    //     FightSystem.startTimeout();
    //     FightSystem.player1TowerLife = 1000;
    //     FightSystem.player2TowerLife = 1000;

    // }



}
