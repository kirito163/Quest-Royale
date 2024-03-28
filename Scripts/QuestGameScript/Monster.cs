using UnityEngine;

public class Monster : MonoBehaviour
{
    public int price;
    public string monsterName;
    public int life;
    public float velocity;
    public int number;
    public int attack;
    public bool towerTargetOnly;
    public Sprite toggleImg;
    






    public void setToggleImg(Sprite toggleImg)
    {
        this.toggleImg = toggleImg;

    }
    public Sprite getToggleImg()
    {
        return toggleImg;

    }

    public void setPrice(int price)
    {
        this.price = price;

    }
    public int getPrice()
    {
        return price;

    }
    public void setNumber(int number)
    {
        this.number = number;

    }
    public int getNumber()
    {
        return number;

    }
    public void setLife(int life)
    {
        this.life = life;

    }
    public int getLife()
    {
        return life;

    }
    public void setAttack(int attack)
    {
        this.attack = attack;

    }
    public int getAttack()
    {
        return attack;

    }
    public void setMonsterName(string monsterName)
    {
        this.monsterName = monsterName;

    }
    public string getMonsterName()
    {
        return this.monsterName;

    }

    void destroyMonster()
    {
        if (life <= 0)
        {
            Destroy(this.gameObject);
        }

    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        destroyMonster();
    }

}
