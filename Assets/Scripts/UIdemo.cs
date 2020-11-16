using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIdemo : MonoBehaviour
{
    struct Player
    {
        public int Money;

        public Player(int money)
        {
            Money = money;
        }
    }

    const int StartMoney = 20000;
    private int GameTurn;

    Player player1 = new Player(StartMoney), player2 = new Player(StartMoney), player3 = new Player(StartMoney), player4 = new Player(StartMoney);

    public GameObject PlayerName;
    public GameObject MoneyRank1, MoneyRank2, MoneyRank3, MoneyRank4;
    public GameObject DiceNum;
    public GameObject Capsule;

    public float rotateSpeed = 30f;

    // Start is called before the first frame update
    void Start()
    {
        GameTurn = 1;
        Application.targetFrameRate = 120;
        PlayerName.GetComponent<Text>().text = "Player1";
        MoneyRank1.GetComponent<Text>().text = StartMoney.ToString();
        MoneyRank2.GetComponent<Text>().text = StartMoney.ToString();
        MoneyRank3.GetComponent<Text>().text = StartMoney.ToString();
        MoneyRank4.GetComponent<Text>().text = StartMoney.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Capsule.transform.Rotate(new Vector3(Time.deltaTime * rotateSpeed, Time.deltaTime * rotateSpeed, Time.deltaTime * rotateSpeed));
        if (player1.Money <= 0)
        {

        }
    }

    public void EndButtonOnClick()
    {
        Application.Quit();
    }

    public void DiceButtonOnClicked()
    {
        int dice = Random.Range(1, 10);
        DiceNum.GetComponent<Text>().text = dice.ToString();
        switch (GameTurn)
        {
            case 1:
                player1.Money -= dice * 1000;
                MoneyRank1.GetComponent<Text>().text = player1.Money.ToString();
                PlayerName.GetComponent<Text>().text = "Player2";
                break;
            case 2:
                player2.Money -= dice * 1000;
                MoneyRank2.GetComponent<Text>().text = player2.Money.ToString();
                PlayerName.GetComponent<Text>().text = "Player3";
                break;
            case 3:
                player3.Money -= dice * 1000;
                MoneyRank3.GetComponent<Text>().text = player3.Money.ToString();
                PlayerName.GetComponent<Text>().text = "Player4";
                break;
            case 4:
                player4.Money -= dice * 1000;
                MoneyRank4.GetComponent<Text>().text = player4.Money.ToString();
                PlayerName.GetComponent<Text>().text = "Player1";
                break;
            default:break;
        }
        GameTurn++;
        if(GameTurn == 5)
        {
            GameTurn = 1;
        }
        
    }
}
