using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : MonoBehaviour
{   
    public static Player player;
    public float life = 2000;
    public float money = 200000;
    public List<GameArmy> usableArmy = new List<GameArmy>();
    public GameArmy army;
    public bool isRightHand = true;
     public void Awake(){
        if(player != null && player != this){
            player = this;
        } else {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        

    }
    // Start is called before the first frame update
    void Start()
    {
        

        


        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
