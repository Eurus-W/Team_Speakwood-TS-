using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIdemo : MonoBehaviour
{
    
    public int StartMoney = 20000;
    public int GameTurn;
    private int DiceValue;
    private bool needDice;
    public float playerFeet;


    public GameObject model1, model2, model3, model4;


    public Player player1, player2, player3, player4;

    public GameObject PlayerName;
    public GameObject MoneyRank1, MoneyRank2, MoneyRank3, MoneyRank4;
    public GameObject DiceNum;
    public GameObject Capsule;

    public float rotateSpeed = 30f;

    public bool NeedDice { get => needDice; set => needDice = value; }

    // Start is called before the first frame update
    void Start()
    {
        
        GameTurn = 1;
        NeedDice = true;
        DiceValue = 0;
        player1 = new Player(101, ref model1);
        player2 = new Player(102, ref model2);
        player3 = new Player(103, ref model3);
        player4 = new Player(104, ref model4);
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
        DiceButtonOnClicked();
        TurnOver();
        GameOver();
    }

    public void GameOver()
    {

    }

    public void TurnOver()
    {
        if (GameObject.Find("TimeCount").GetComponent<CountDown>().TotalTime == 0)
        {
            if (NeedDice)
            {
                DiceButtonOnClicked();
                NeedDice = false;
            }
            else
            {
                EndButtonOnClick();
            }
        }
    }

    public void EndButtonOnClick()
    {
        if (NeedDice) return;
        GameTurn++;
        switch (GameTurn)
        {
            case 1:
                PlayerName.GetComponent<Text>().text = "Player1";
                break;
            case 2:
                PlayerName.GetComponent<Text>().text = "Player2";
                break;
            case 3:
                PlayerName.GetComponent<Text>().text = "Player3";
                break;
            case 4:
                PlayerName.GetComponent<Text>().text = "Player4";
                break;
            default: break;
        }
        GameObject.Find("TimeCount").GetComponent<CountDown>().ResetTime();
        if (GameTurn == 5)
        {
            GameTurn = 1;
        }
        NeedDice = true;
    }

    public void DiceButtonOnClicked()
    {
        if (!NeedDice) return;
        if (GameObject.Find("DiceCube").GetComponent<Rolldice>().DiceSum == 0) return;
        DiceValue = GameObject.Find("DiceCube").GetComponent<Rolldice>().DiceSum;
        Debug.Log(GameObject.Find("DiceCube").GetComponent<Rolldice>().DiceSum);
        GameObject.Find("DiceCube").GetComponent<Rolldice>().DiceSum = 0;
        string dialog = "";
        switch (GameTurn)
        {
            case 1:
                player1.Money -= DiceValue * 1000;
                //odel1.
                player1.Model.GetComponent<PlayerMove>().MoveByDice(player1.Position, DiceValue);
                player1.MovePlayer(DiceValue);
                dialog = "玩家<color=blue>player1</color> <color=red>损失</color> <color=yellow>" + (DiceValue * 1000).ToString() + "</color>\n";
                MoneyRank1.GetComponent<Text>().text = player1.Money.ToString();
                break;
            case 2:
                player2.Money -= DiceValue * 1000;
                player2.Model.GetComponent<PlayerMove>().MoveByDice(player2.Position, DiceValue);
                player2.MovePlayer(DiceValue);
                dialog = "玩家<color=blue>player2</color> <color=red>损失</color> <color=yellow>" + (DiceValue * 1000).ToString() + "</color>\n";
                MoneyRank2.GetComponent<Text>().text = player2.Money.ToString();
                break;
            case 3:
                player3.Money -= DiceValue * 1000;
                player3.Model.GetComponent<PlayerMove>().MoveByDice(player3.Position, DiceValue);
                player3.MovePlayer(DiceValue);
                dialog = "玩家<color=blue>player3</color> <color=red>损失</color> <color=yellow>" + (DiceValue * 1000).ToString() + "</color>\n";
                MoneyRank3.GetComponent<Text>().text = player3.Money.ToString();
                break;
            case 4:
                player4.Money -= DiceValue * 1000;
                player4.Model.GetComponent<PlayerMove>().MoveByDice(player4.Position, DiceValue);
                player4.MovePlayer(DiceValue);
                dialog = "玩家<color=blue>player4</color> <color=red>损失</color> <color=yellow>" + (DiceValue * 1000).ToString() + "</color>\n";
                MoneyRank4.GetComponent<Text>().text = player4.Money.ToString();
                break;
            default: break;
        }
        NeedDice = false;
        GameObject.Find("Player").GetComponent<DialogShow>().DialogAdd(dialog);
        GameObject.Find("TimeCount").GetComponent<CountDown>().ResetTime();
    }
}
