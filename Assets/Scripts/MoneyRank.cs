using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MoneyRank : MonoBehaviour
{
    public GameObject rank1, rank2, rank3, rank4;
    private List<Vector3> pos;
    private List<int>money;
    private List<string> color;
    
    // Start is called before the first frame update
    void Start()
    {
        pos = new List<Vector3>();
        color = new List<string>();
        money = new List<int>();
        pos.Add(rank1.transform.position);
        pos.Add(rank2.transform.position);
        pos.Add(rank3.transform.position);
        pos.Add(rank4.transform.position);
        color.Add("red");
        color.Add("yellow");
        color.Add("blue");
        color.Add("green");

        for (int i = 0; i < 4; i++)
        {
            money.Add(20000);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 1; i<5; i++)
        {
            
            if (money[i-1] != GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[i].Money)
            {
                string temp = "玩家<color=" + color[i - 1] + ">" + GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[i].Name + "</color><color=";
                int M = money[i - 1] - GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[i].Money;
                if (M > 0)
                {
                    temp += "purple>损失";
                }
                else
                {
                    temp += "pink>获得";
                    M = -M;
                }
                temp += "</color>金钱<color=orange>" + M.ToString() + "</color>\n";
                GameObject.Find("Player").GetComponent<DialogShow>().DialogAdd(temp);

                money[i - 1] = GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[i].Money;
                ReRank();
            }
        }
    }

    void ReRank()
    {
        rank1.GetComponentInChildren <Text>().text = money[0].ToString();
        rank2.GetComponentInChildren<Text>().text = money[1].ToString();
        rank3.GetComponentInChildren<Text>().text = money[2].ToString();
        rank4.GetComponentInChildren<Text>().text = money[3].ToString();

       
    }
}
