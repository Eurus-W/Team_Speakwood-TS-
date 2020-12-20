using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlocksChange : MonoBehaviour
{
    // Start is called before the first frame update
    public Block[] all_blocks;
    public bool canUpdate;
    void Start()
    {
        canUpdate = false;
        GameObject obj= GameObject.Find("Cube");
        all_blocks = new Block[36];
        Block b;
        for (int i =0;i<=35;i++)
        {
            b=new Block(i,obj);
            all_blocks[i] = b;
        }
        Debug.Log(all_blocks[0].price);
        
        
    }
    public void DoubleGroundRent(Block[] all_blocks, int b1, int b2, int b3)
    {
        if (all_blocks[b1].owner == all_blocks[b2].owner && all_blocks[b1].owner == all_blocks[b3].owner && all_blocks[b1].owner != 0)
        {
            all_blocks[b1].TribleRent();
            all_blocks[b2].TribleRent();
            all_blocks[b3].TribleRent();
        }
        else if (all_blocks [b1].owner !=all_blocks [b2].owner && all_blocks [b1].owner != all_blocks [b3].owner && all_blocks [b2].owner != all_blocks [b3].owner )
        {
            all_blocks[b1].DoubleRent();
            all_blocks[b2].DoubleRent();
            all_blocks[b3].DoubleRent();

        }
        else
        {
            all_blocks[b1].RecoverRent();
            all_blocks[b2].RecoverRent();
            all_blocks[b3].RecoverRent();
        }
        
            

        
    }
    public void ShowBlock(int pos)
    {
        Text blockname, ownername, price, housenumber, blockrent;
        BlocksChange bc = (BlocksChange)GetComponent(typeof(BlocksChange));
        blockname = GameObject.Find("GameUI/ShowBlock/BlockName").GetComponent<Text>();
        ownername = GameObject.Find("GameUI/ShowBlock/OwnerName").GetComponent<Text>();
        price = GameObject.Find("GameUI/ShowBlock/Price").GetComponent<Text>();
        housenumber = GameObject.Find("GameUI/ShowBlock/HouseNumber").GetComponent<Text>();
        blockrent = GameObject.Find("GameUI/ShowBlock/Rent").GetComponent<Text>();

        blockname.text = "地块" + pos.ToString();
        ownername.text = all_blocks[pos].ownername.ToString();
        price.text = all_blocks[pos].price.ToString();
        housenumber.text = all_blocks[pos].house.ToString();
        blockrent.text = all_blocks[pos].rent.ToString();

    }
    public void ChangeOwnerImage(int pos, int owner)
    {
        string panelpath = "Panel" + pos.ToString();
        string imagepath = "Image" + pos.ToString();
        switch (owner)
        {

            case 0: GameObject.Find(panelpath).GetComponent<Image>().color = new Color(255, 255, 255, 0); break;
            case 1: GameObject.Find(panelpath).GetComponent<Image>().color = new Color(255, 0, 0, 255); break;
            case 2: GameObject.Find(panelpath).GetComponent<Image>().color = new Color(255, 255, 0, 255); break;
            case 3: GameObject.Find(panelpath).GetComponent<Image>().color = new Color(0, 0, 255, 255); break;
            case 4: GameObject.Find(panelpath).GetComponent<Image>().color = new Color(0, 255, 0, 255); break;
        }



    }
    // Update is called once per frame
    void Update()
    {
        DoubleGroundRent(all_blocks, 1, 2, 3);
        DoubleGroundRent(all_blocks, 5, 7, 8);
        DoubleGroundRent(all_blocks, 10, 11, 13);
        DoubleGroundRent(all_blocks, 15, 16, 17);
        DoubleGroundRent(all_blocks, 19, 20, 21);
        DoubleGroundRent(all_blocks, 23, 25, 26);
        DoubleGroundRent(all_blocks, 28, 29, 31);
        DoubleGroundRent(all_blocks, 33, 34, 35);

        

        if (all_blocks[14].owner == all_blocks[30].owner && all_blocks[14].owner != 0)
        {
            all_blocks[14].rent = 2000;
            all_blocks[30].rent = 2000;
        }
        else
        {
            all_blocks[14].rent = 1000;
            all_blocks[30].rent = 2000;
        }
        Dictionary<int, int> port=new Dictionary<int, int> ();
        port[all_blocks[4].owner] = 0;
        port[all_blocks[12].owner] = 0;
        port[all_blocks[22].owner] = 0;
        port[all_blocks[30].owner] = 0;
        port[all_blocks[4].owner] += 1;
        port[all_blocks[12].owner] += 1;
        port[all_blocks[22].owner] += 1;
        port[all_blocks[30].owner] += 1;

        foreach (KeyValuePair<int,int> kvp in port)
        {
            if (all_blocks[4].owner == kvp.Key) { all_blocks[4].rent = 240 + (kvp.Value - 1) * 500; }
            if (all_blocks[12].owner == kvp.Key) { all_blocks[12].rent = 240 + (kvp.Value - 1) * 500; }
            if (all_blocks[22].owner == kvp.Key) { all_blocks[22].rent = 240 + (kvp.Value - 1) * 500; }
            if (all_blocks[30].owner == kvp.Key) { all_blocks[30].rent = 240 + (kvp.Value - 1) * 500; }
        }
        for (int i = 1; i <= 35; i++)
        {
            
            ChangeOwnerImage(i, all_blocks[i].owner);
        }

        int pos;
        pos = GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[GameObject.Find("Player").GetComponent<UIdemo>().GameTurn].Position;
        //缺：当前玩家的当前位置
        if (!canUpdate)
        {
            return;
        }

        

        ShowBlock(pos);
        if(all_blocks[pos].owner == 0)
        {
            return;
        }
        all_blocks[pos].ownername = GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[all_blocks[pos].owner].Name;
        canUpdate = false;
    }
}
