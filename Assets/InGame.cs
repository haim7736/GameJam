using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{

    public int myNum = 10;
    public Text CountText;
    public Text FavorabilityText;
    public Text moneyText;


    public GameObject pit;
    public GameObject one;
    public GameObject two;

    float timer;
    float waitingTime;

    public int damage = 1;

    private bool FoodCheck;
    public int Favorability;
    public int money;



    private int FavorabilityCh;
    bool check;



    void Start()
    {
        CountText.text = "Count:" + myNum;
        pit.SetActive(false);
        two.SetActive(false);

        timer = 0.0f;
        waitingTime = 2f;

        FoodCheck = false;

        check = false;
    }

    void Update()
    {
        Debug.Log(damage);
        CountText.text = "Count:" + myNum;
        FavorabilityText.text = "호감도:" + Favorability;
        moneyText.text = money + "원";
        if (myNum <= 0)
        {
            one.SetActive(false);
            two.SetActive(true);
            myNum = 50;
        }
        if (FoodCheck)
        {
            timer += Time.deltaTime;
            if (timer > waitingTime)
            {
                pit.SetActive(false);
                timer = 0;
                FoodCheck = false;
            }
        }

        if(FavorabilityCh / 100 > 0)
        {
            check = true;
            FavorabilityCh = 0;
        }

        if(check)
        {
            damage = damage + (Favorability / 100);
            check = false;
        }
    
    }

    public void Click()
    {
        myNum-= damage;
        money += 10;
    }

    public void Foood()
    {

        if (money >= 50)
        {
           
            if (timer <= 0)
            {
                pit.SetActive(true);
                FoodCheck = true;
                Favorability += 50;
                FavorabilityCh += 50;
                money -= 50;

            }
        }
      

      
    }
}
