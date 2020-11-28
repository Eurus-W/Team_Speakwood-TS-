using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    //持有金钱数
    private int money;
    //绑定场景中的物体
    private GameObject model;





    //五项属性值
    private double strength, agility, intelligence, luck, toughness;//力、敏、智、幸运、体质
    //武德
    private int wood;//武德
    //持有的6个装备的id
    private int item1_id, item2_id, item3_id, item4_id, item5_id, item6_id;
    //当前所在的格子的序号
    private int position;

    private string intro;

    private string skillName;

    private string skillIntro;

    private bool isMoving = false;

    private bool haveMoved = false;

    public Player(int heroid, ref GameObject obj)
    {

        //按钮选择不同英雄，不同的按钮对应不同的英雄id的赋予，进而对应不同的初始化。
        //根据不同的英雄id对玩家进行初始化

        if (heroid == -1)//当前测试阶段的的default初始化
        {
            money = 20000;
            Strength = 30;
            agility = 30;
            intelligence = 30;
            luck = 30;
            toughness = 60;
            wood = 10;
            //没有任何装备
            item1_id = -1;
            item2_id = -1;
            item3_id = -1;
            item4_id = -1;
            item5_id = -1;
            item6_id = -1;
            //出生在在起始位置
            Position = 0;

            model = obj;

        }
        //else {
        //    for (int i = 0; i < 8; i++)
        //    {
        //        if(heroid == data[i][0])
        //        {
        //            money = data[i][1];
        //            strength = data[i][2];
        //            agility = data[i][3];
        //            intelligence = data[i][4];
        //            luck = data[i][5];
        //            toughness = data[i][6];
        //            wood = data[i][7];
        //        }
        //    } 

        //}


    }
    //与场景中的一个物体模型相连接
    public int Money { get => money; set => money = value; }
    public double Strength { get => strength; set => strength = value; }
    public double Agility { get => agility; set => agility = value; }
    public double Intelligence { get => intelligence; set => intelligence = value; }
    public double Intelligence1 { get => intelligence; set => intelligence = value; }
    public double Luck { get => luck; set => luck = value; }
    public double Toughness { get => toughness; set => toughness = value; }
    public int Wood { get => wood; set => wood = value; }
    public GameObject Model { get => model; set => model = value; }
    public string Intro { get => intro; set => intro = value; }
    public string SkillName { get => skillName; set => skillName = value; }
    public string SkillIntro { get => skillIntro; set => skillIntro = value; }
    public bool IsMoving { get => isMoving; set => isMoving = value; }
    public bool HaveMoved { get => haveMoved; set => haveMoved = value; }
    public int Position { get => position; set => position = value; }

    //构造函数


    //得到玩家当前的位置
    public int getposition()
    {
        return Position;
    }
    //根据骰子值移动玩家
    public void MovePlayer(int DiceValue)
    {
        Position = (Position + DiceValue) % 36;
        //then move to the position physically
    }

    //属性变更
    public void AtrributeChange(string attribute, double change)
    {
        switch (attribute)
        {
            case "Money":
                Money += (int)change;
                break;
            case "Strength":
                Strength += change;
                break;
            case "Agility":
                Agility += change;
                break;
            case "Intelligence":
                Intelligence += change;
                break;
            case "Luck":
                Luck += change;
                break;
            case "Toughness":
                Toughness += change;
                break;
            case "Wood":
                Wood += (int)change;
                break;
            default:
                Debug.Log("An unexpected attribute was called:" + attribute);
                break;
        }
    }

    //玩家模型的动作

}

public class Item
{
    int item_id;
    //物品图片路径+名字等于其导入路径，存放在统一路径下
    string item_name;
    //物品简介
    string item_intro_text;

}


