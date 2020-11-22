using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Block
{
    public int price = 100;
    public string type = "none";
    public int owner = 0;
    public int house = 0;
    public int color = 0;
    public void ActionPort() { }
    public void ActionBlock() { }
    public void ActionHospital() { }
    public void ActionSpecial() { }
    public void ActionChance() { }
    public void ActionFate() { }
    public void ActionStart() { }



}
public class test : MonoBehaviour
{
    // Start is called before the first frame update
    Block[] all_blocks = new Block[36];
    void Start()
    {
        
        int i = 0;
        while (i <= 35)
        {
            if (i==4 || i== 12 || i== 22 || i == 30)
            {
                all_blocks[i].price = 1200;
                all_blocks[i].type = "port";
            }
            
            
            switch (i)
            {
                case 0 : all_blocks[i].price = 0; all_blocks[i].type = "start";break;
                case 1: all_blocks[i].price = 600; all_blocks[i].type = "blocks"; all_blocks[i].color = 1; break;
                case 2: all_blocks[i].price = 720; all_blocks[i].type = "blocks"; all_blocks[i].color = 1; break;
                case 3: all_blocks[i].price = 800; all_blocks[i].type = "blocks"; all_blocks[i].color = 1; break;
                case 5: all_blocks[i].price = 930; all_blocks[i].type = "blocks"; all_blocks[i].color = 2; break;
                case 6: all_blocks[i].price = 0; all_blocks[i].type = "chance";break;
                case 7: all_blocks[i].price = 1000; all_blocks[i].type = "blocks"; all_blocks[i].color = 2; break;
                case 8: all_blocks[i].price = 1070; all_blocks[i].type = "blocks"; all_blocks[i].color = 2; break;
                case 9: all_blocks[i].price = 0; all_blocks[i].type = "hospital"; break;
                case 10: all_blocks[i].price = 1130; all_blocks[i].type = "blocks"; all_blocks[i].color = 3; break;
                case 11: all_blocks[i].price = 1200; all_blocks[i].type = "blocks"; all_blocks[i].color = 3; break;
                case 13: all_blocks[i].price = 1300; all_blocks[i].type = "blocks"; all_blocks[i].color = 3; break;
                case 14: all_blocks[i].price = 2500; all_blocks[i].type = "special";break;
                case 15: all_blocks[i].price = 1410; all_blocks[i].type = "blocks"; all_blocks[i].color = 4; break;
                case 16: all_blocks[i].price = 1500; all_blocks[i].type = "blocks"; all_blocks[i].color = 4; break;
                case 17: all_blocks[i].price = 1600; all_blocks[i].type = "blocks"; all_blocks[i].color = 4; break;
                case 18: all_blocks[i].price = 0;all_blocks[i].type = "store";break;
                case 19: all_blocks[i].price = 1630; all_blocks[i].type = "blocks"; all_blocks[i].color = 5; break;
                case 20: all_blocks[i].price = 1690; all_blocks[i].type = "blocks"; all_blocks[i].color = 5; break;
                case 21: all_blocks[i].price = 1700; all_blocks[i].type = "blocks"; all_blocks[i].color = 5; break;
                case 23: all_blocks[i].price = 1830; all_blocks[i].type = "blocks"; all_blocks[i].color = 6; break;
                case 24: all_blocks[i].price = 0;all_blocks[i].type = "fate";break;
                case 25: all_blocks[i].price = 1960; all_blocks[i].type = "blocks"; all_blocks[i].color = 6; break;
                case 26: all_blocks[i].price = 2000; all_blocks[i].type = "blocks"; all_blocks[i].color = 6; break;
                case 27: all_blocks[i].price = 0;all_blocks[i].type = "hospital";break;
                case 28: all_blocks[i].price = 2210; all_blocks[i].type = "blocks"; all_blocks[i].color = 7; break;
                case 29: all_blocks[i].price = 2300; all_blocks[i].type = "blocks"; all_blocks[i].color = 7; break;
                case 30: all_blocks[i].price = 2500; all_blocks[i].type = "special";break;
                case 31: all_blocks[i].price = 2310; all_blocks[i].type = "blocks"; all_blocks[i].color = 7; break;
                case 33: all_blocks[i].price = 1930; all_blocks[i].type = "blocks"; all_blocks[i].color = 8; break;
                case 34: all_blocks[i].price = 1800; all_blocks[i].type = "blocks"; all_blocks[i].color = 8; break;
                case 35: all_blocks[i].price = 1700; all_blocks[i].type = "blocks"; all_blocks[i].color = 8; break;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        int pos = Random.Range(0,35);
        switch (all_blocks[pos].type)
        {
            case "block": all_blocks[pos].ActionBlock();break;
            case "port": all_blocks[pos].ActionPort();break;
            case "hospital": all_blocks[pos].ActionHospital();break;
            case "chance": all_blocks[pos].ActionChance();break;
            case "fate": all_blocks[pos].ActionFate();break;
            case "special": all_blocks[pos].ActionSpecial();break;
            case "start": all_blocks[pos].ActionStart();break;
        }
    }
}
