using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksChange : MonoBehaviour
{
    // Start is called before the first frame update
    Block[] all_blocks;
    void Start()
    {
        
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
        all_blocks[14].RecoverRent();
        all_blocks[30].RecoverRent();
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
        
    }
}
