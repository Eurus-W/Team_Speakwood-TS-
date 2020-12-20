using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIdemo : MonoBehaviour
{
    
    const int StartMoney = 20000;
    public int GameTurn;
    private int DiceValue;
    private bool needDice;
    public float playerFeet;

    /// <summary>
    /// 考虑改成形如public GameObject model1 = new GameObject;
    /// </summary>

    public GameObject model1, model2, model3, model4;


    public Player player0,player1, player2, player3, player4;
    public Players players;

    public GameObject PlayerName;
    public GameObject MoneyRank1, MoneyRank2, MoneyRank3, MoneyRank4;
    
    public GameObject Capsule;
    private int outPlayers;

    

    public bool NeedDice { get => needDice; set => needDice = value; }

    // Start is called before the first frame update
    void Start()
    {
        
        GameTurn = 1;
        NeedDice = true;
        DiceValue = 0;
        player1 = new Player(101, ref model1);
        player2 = new Player(103, ref model2);
        player3 = new Player(104, ref model3);
        player4 = new Player(106, ref model4);

        player0 = new Player(105, ref model1);
        players = new Players();
        

        players.playerlist[0] = player0;
        players.playerlist[1] = player1;
        players.playerlist[2] = player2;
        players.playerlist[3] = player3;
        players.playerlist[4] = player4;

        Application.targetFrameRate = 120;
        PlayerName.GetComponent<Text>().text = "Player1";
        //players.playerlist[1].Money = 0;
        MoneyRank1.GetComponent<Text>().text = StartMoney.ToString();
        MoneyRank2.GetComponent<Text>().text = StartMoney.ToString();
        MoneyRank3.GetComponent<Text>().text = StartMoney.ToString();
        MoneyRank4.GetComponent<Text>().text = StartMoney.ToString();
        player1.Model.GetComponent<Animator>().SetBool("IsHappy", true);

    }

    // Update is called once per frame
    void Update()
    {
        
        keepball();//或者放在fixupdate中，定时执行，增加执行间隔。
 
        DiceButtonOnClicked();
        TurnOver();
        //GameOver();
    }

    public void keepball()
    {
        for (int i = 1; i < 5; i++)
        {
            if (players.playerlist[i].Name == "贝恩")
            {
                int average = (int)((players.playerlist[i].Strength + players.playerlist[i].Agility + players.playerlist[i].Intelligence + players.playerlist[i].Toughness + players.playerlist[i].Luck) / 5);
                players.playerlist[i].Strength = average;
                players.playerlist[i].Agility = average;
                players.playerlist[i].Intelligence = average;
                players.playerlist[i].Toughness = average;
                players.playerlist[i].Luck = average;
            }
        }
    }

    public void GameOver()
    {
        Debug.Log("游戏结束！！！！！！！！");
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
        if (GameObject.Find("Player" + GameTurn).GetComponent<PlayerMove>().isMoving)
        {
            return;
        }
        if (players.playerlist[GameTurn].IsInhos)
        {
            players.playerlist[GameTurn].NeedOutHos = true;
        }

        if (NeedDice) return;
        players.playerlist[GameTurn].Model.GetComponent<Animator>().SetBool("IsHappy", false);
        GameTurn++;
        if (GameTurn == 5)
        {
            GameTurn = 1;
        }
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

       
        players.playerlist[GameTurn].Model.GetComponent<Animator>().SetBool("IsHappy", true);
        //if(players)
        NeedDice = true;
        //GameObject.Find("Blocks").GetComponent<BlocksChange>().canUpdate = true;

    }

    public void DiceButtonOnClicked()
    {
        if (players.playerlist[GameTurn].Money <= 0)
        {
           
            outPlayers = 0;
            foreach (var player in players.playerlist)
            {
                if (player.Money<=0)
                {
                    outPlayers++;
                }
            }

            if (outPlayers>=3)
            {
                GameOver();
            }



            
            needDice = false;
            EndButtonOnClick();
            return;
        }
        if (players.playerlist[GameTurn].IsInhos&& players.playerlist[GameTurn].NeedOutHos)
        {

            
            
            return;
        }

        if (players.playerlist[GameTurn].IsInhos)
        {

            needDice = false;
            EndButtonOnClick();
            return;
        }


        if (!NeedDice) return;
        if (GameObject.Find("DiceCube").GetComponent<Rolldice>().DiceSum == 0) return;
        DiceValue = GameObject.Find("DiceCube").GetComponent<Rolldice>().DiceSum;
        GameObject.Find("DiceCube").GetComponent<Rolldice>().DiceSum = 0;
     
        string dialog = "";
        switch (GameTurn)
        {
            case 1:
                
                player1.Model.GetComponent<PlayerMove>().MoveByDice(player1.Position, DiceValue);
                player1.MovePlayer(DiceValue);
                
                break;
            case 2:
                
                player2.Model.GetComponent<PlayerMove>().MoveByDice(player2.Position, DiceValue);
                player2.MovePlayer(DiceValue);
                
                break;
            case 3:
                
                player3.Model.GetComponent<PlayerMove>().MoveByDice(player3.Position, DiceValue);
                player3.MovePlayer(DiceValue);
                
                break;
            case 4:
                
                player4.Model.GetComponent<PlayerMove>().MoveByDice(player4.Position, DiceValue);
                player4.MovePlayer(DiceValue);
                
                break;
            default: break;
        }
        NeedDice = false;
        GameObject.Find("Player").GetComponent<DialogShow>().DialogAdd(dialog);
        GameObject.Find("TimeCount").GetComponent<CountDown>().ResetTime();
    }
}
