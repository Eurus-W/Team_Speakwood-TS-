using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private int player1Money = 20000;
    private int player2Money = 20000;
    private int player3Money = 20000;
    private int player4Money = 20000;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player1Money > 0)
        {
            player1Money = GameObject.Find("Player").GetComponent<UIdemo>().player1.Money;
        }
        else
        {
            //UI宣布玩家破产
            //弹出玩家头像，玩家破产的消息。 该消息的具体内容的表述有待考虑。

            //玩家模型消失
            //模型从地图中移除（移到很远的地方）

            //地块进行回收
            //地块的owner=-1，原来盖的房子？？？

            //排行榜变更
            //=0沉底？

        }
        if (player2Money > 0)
        {
            player2Money = GameObject.Find("Player").GetComponent<UIdemo>().player2.Money;
        }
        else
        {
            //UI宣布玩家破产

            //玩家模型消失

            //地块进行回收

            //排行榜变更

        }

        if (player3Money > 0)
        {
            player3Money = GameObject.Find("Player").GetComponent<UIdemo>().player3.Money;
        }
        else
        {
            //UI宣布玩家破产
            //玩家模型消失
            //地块进行回收
            //排行榜变更
        }

        if (player4Money > 0)
        {
            player4Money = GameObject.Find("Player").GetComponent<UIdemo>().player4.Money;
        }
        else
        {
            //UI宣布玩家破产
            //玩家模型消失
            //地块进行回收
            //排行榜变更
        }


    }
}
