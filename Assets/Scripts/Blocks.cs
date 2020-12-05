using UnityEngine;
using System.Collections.Generic;
public class Block
{
    public GameObject blockModel;

    public int price;
    public string type;
    public int owner ;
    public int house ;
    public int color;
    public int rent;
    public Block(int i ,GameObject obj)
    {
        blockModel = obj;
        if (i == 4 || i == 12 || i == 22 || i == 30)
        {
            price = 1200;
            type = "port";
            rent = 240;
        }
        else
        {
            switch (i)
            {
                case 0: price = 0; type = "start"; break;
                case 1: price = 600; type = "blocks"; color = 1; rent = 120; owner = 0; break;
                case 2: price = 720; type = "blocks"; color = 1; rent = 144; owner = 0; break;
                case 3: price = 800; type = "blocks"; color = 1; rent = 160; owner = 0; break;
                case 5: price = 930; type = "blocks"; color = 2; rent = 186; owner = 0; break;
                case 6: price = 0; type = "chance"; break;
                case 7: price = 1000; type = "blocks"; color = 2; rent = 200; owner = 0; break;
                case 8: price = 1070; type = "blocks"; color = 2; rent = 214; owner = 0; break;
                case 9: price = 0; type = "hospital"; break;
                case 10: price = 1130; type = "blocks"; color = 3; rent = 226; owner = 0; break;
                case 11: price = 1200; type = "blocks"; color = 3; rent = 240; owner = 0; break;
                case 13: price = 1300; type = "blocks"; color = 3; rent = 260; owner = 0; break;
                case 14: price = 2500; type = "special"; rent = 500; owner = 0; break;
                case 15: price = 1410; type = "blocks"; color = 4; rent = 282; owner = 0; break;
                case 16: price = 1500; type = "blocks"; color = 4; rent = 300; owner = 0; break;
                case 17: price = 1600; type = "blocks"; color = 4; rent = 320; owner = 0; break;
                case 18: price = 0; type = "store"; break;
                case 19: price = 1630; type = "blocks"; color = 5; rent = 326; owner = 0; break;
                case 20: price = 1690; type = "blocks"; color = 5; rent = 338; owner = 0; break;
                case 21: price = 1700; type = "blocks"; color = 5; rent = 340; owner = 0; break;
                case 23: price = 1830; type = "blocks"; color = 6; rent = 366; owner = 0; break;
                case 24: price = 0; type = "fate"; break;
                case 25: price = 1960; type = "blocks"; color = 6; rent = 392; owner = 0; break;
                case 26: price = 2000; type = "blocks"; color = 6; rent = 400; owner = 0; break;
                case 27: price = 0; type = "hospital"; break;
                case 28: price = 2210; type = "blocks"; color = 7; rent = 442; owner = 0; break;
                case 29: price = 2300; type = "blocks"; color = 7; rent = 460; owner = 0; break;
                case 30: price = 2500; type = "special"; rent = 500; owner = 0; break;
                case 31: price = 2310; type = "blocks"; color = 7; rent = 462; owner = 0; break;
                case 33: price = 1930; type = "blocks"; color = 8; rent = 386; owner = 0; break;
                case 34: price = 1800; type = "blocks"; color = 8; rent = 360; owner = 0; break;
                case 35: price = 1700; type = "blocks"; color = 8; rent = 340; owner = 0; break;

            }
        }
        
    }
    
    public void RecoverRent()
    {
        rent = (int)((house + 1) * price * 0.2);
    }
    public void DoubleRent()
    {       
        rent = (int)((house + 1) * price * 0.4);
    }
    public void TribleRent()
    {
        rent = (int)((house + 1) * price * 0.6);
    }
    public int GetRent()
    {
        return rent;
    }

}
public class Blocks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
        
        
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }

}
