using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Vector3[] pathPoint;
    public int[] pathid;
    public float Player_Y;
    public float moveSpeed;
    public float stopTime;
    public bool isMoving;

    

    void Start()
    {
        isMoving = false;
        Player_Y = 1.0f;
    }

    void Update()
    {
        if (pathid.Length != 0)
        {
            getPathPoint();
            pathid = new int[0];
            isMoving = true;
            StartCoroutine(MoveOnPath(false));
           
        }
        //根据回合数选择player和model

        //默认：
        //MoveByDice(ref player1);


        //可以读取在其他脚本中记录的回合数，用new and old来存储，如果不一样，则说明新的回合开始了
        //当新的回合开始时，将haveMoved置为false


    }

    public void getPathPoint()
    {
        pathPoint = new Vector3[pathid.Length];
        for(int i=0; i<=pathid.Length-1; i++)
        {
            pathPoint[i] = getPoint(pathid[i]);
        }
    }

    public Vector3 getPoint(int id)
    {
        if (id < 0 || id > 35)
        {
            Debug.Log("point id error!" + id.ToString());
        }
        Vector3 point = new Vector3(0, Player_Y, 0);
        if (id>0 && id<= 8)
        {
            point = new Vector3(2 + id * 12, Player_Y, 0);
        }
        if (id == 9)
        {
            point = new Vector3(112, Player_Y, 0);
        }
        if (id > 9 && id <= 17)
        {
            point = new Vector3(112, Player_Y, -2 - (id - 9) * 12);
        }
        if (id == 18)
        {
            point = new Vector3(112, Player_Y, -112);
        }
        if (id > 18 && id <= 26)
        {
            point = new Vector3(110 - (id - 18) * 12, Player_Y, -112);
        }
        if (id == 27)
        {
            point = new Vector3(0, Player_Y, -112);
        }
        if (id > 27 && id <= 35)
        {
            point = new Vector3(0, Player_Y, -110 + (id - 27) * 12);
        }
        return point;
    }

    //构造函数
    IEnumerator MoveOnPath(bool loop)
    {
        do
        {
            foreach (var point in pathPoint)
            {
                if(point == new Vector3(14.0f, Player_Y, 0.0f)|| point == new Vector3(112.0f, Player_Y, -14.0f) || point == new Vector3(98.0f, Player_Y, -112.0f) || point == new Vector3(0.0f, Player_Y, -98.0f))
                {
                    if (point != pathPoint[0])
                    {
                        transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 90, 0));
                    }
                }
                
                GetComponent<Animator>().SetBool("IsWalk", true);
                yield return StartCoroutine(MoveToPosition(point));
                yield return new WaitForSeconds(stopTime);
            }
        }
        while (loop);
        GetComponent<Animator>().SetBool("IsWalk", false);
        
        isMoving = false;
        GameObject.Find("Blocks").GetComponent<BlocksChange>().canUpdate = true;
        GameObject.Find("EventUI").GetComponent<BlockEvent>().NeedWindow = true;
    }

    IEnumerator MoveToPosition(Vector3 target)
    {
        while (transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            yield return 0;
        }
    }
    IEnumerator TransferToPosition(Vector3 target)
    {
        while (transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 10*moveSpeed * Time.deltaTime);
            yield return 0;
        }
    }

    public void MoveByDice(int from, int dice)
    {
        int[] idArray = new int[dice + 1];
        for (int id=0; id<=dice; id++)
        {
            idArray[id] = (from + id)%36;
        }
        pathid = idArray;
    }
    public void Transfer(int target)
    {
        StartCoroutine(TransferToPosition(getPoint(target)));
        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[GameObject.Find("Player").GetComponent<UIdemo>().GameTurn].Position = target;
    }
}
