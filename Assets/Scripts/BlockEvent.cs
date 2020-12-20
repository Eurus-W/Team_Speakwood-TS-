using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BlockEvent : MonoBehaviour
{
    private int lastTurn;
    private int currentTurn;
    private int currentposition;
    private int currentPrice;
    private string currentType;
    private int currentOwner;
    private int currentHouse;
    private int currentColor;
    private int currentRent;
    private int windowtype;
    private bool needWindow;
    public GameObject mid;
    public GameObject leftTop;
    public GameObject leftBottom;
    public GameObject rightTop;
    public GameObject rightBottom;
    public GameObject FCtext;
    public GameObject Title;
    public GameObject Panel;
    public GameObject sWindow;
    public GameObject confirm;
    public GameObject sign;
    public int chanceid;
    public bool chancesign;
    public int fateid;
    public bool fatesign;
    private bool outHosJud;
    private int tempTurn;

    public bool NeedWindow { get => needWindow; set => needWindow = value; }


    // Start is called before the first frame update
    void Start()
    {
       
        lastTurn = 0;
        currentTurn = 0;
        currentposition = -1;
        outHosJud = false;
        NeedWindow = false;

        Panel.SetActive(false);
        leftTop.SetActive(false);
        leftBottom.SetActive(false);
        rightBottom.SetActive(false);
        rightTop.SetActive(false);
        Title.SetActive(false);
        FCtext.SetActive(false);
        mid.SetActive(false);
        sWindow.SetActive(false);
        confirm.SetActive(false);
        sign.SetActive(false);
        chancesign = false;
        fatesign = false;



    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Model.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name == "backflip")
        {
            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Model.GetComponent<Animator>().SetBool("IsBackFlip", false);

        }

        if (!needWindow)
        {
            
            return;
        }

        tempTurn = GameObject.Find("Player").GetComponent<UIdemo>().GameTurn;
        if (GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[tempTurn].IsInhos)
        {
            leftTop.SetActive(true);
            leftBottom.SetActive(false);
            rightBottom.SetActive(false);
            rightTop.SetActive(true);
            Title.SetActive(true);
            FCtext.SetActive(false);
            mid.SetActive(false);

            leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "进行出院的体质判定";
            rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "直接花费500金钱出院";
            Title.GetComponentInChildren<TMPro.TMP_Text>().text = "出院判定！";
            outHosJud = true;
            return;
        }



        currentTurn = GameObject.Find("Player").GetComponent<UIdemo>().GameTurn;
  
            EventEncountered();
            PopupWindow();
            NeedWindow = false;
            
        
    }

    private void EventEncountered()
    {
        switch (currentTurn)
        {
            case 1:
                currentposition = GameObject.Find("Player").GetComponent<UIdemo>().player1.getposition();
                
                break;
            case 2:
                currentposition = GameObject.Find("Player").GetComponent<UIdemo>().player2.getposition();
                break;
            case 3:
                currentposition = GameObject.Find("Player").GetComponent<UIdemo>().player3.getposition();
                break;
            case 4:
                currentposition = GameObject.Find("Player").GetComponent<UIdemo>().player4.getposition();
                break;
            default:
                break;
        }
        Debug.Log(currentTurn + " " + currentposition);
        currentPrice = GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[currentposition].price;
        currentType = GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[currentposition].type;
        currentOwner = GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[currentposition].owner;
        currentHouse = GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[currentposition].house;
        currentColor = GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[currentposition].color;
        currentRent = GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[currentposition].rent;
        if (GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentOwner].Name == "杰克霍斯")
        {
            currentRent = (int)(currentRent * 1.5);
        }
        
    }

    private void PopupWindow()
    {
        //根据当前地块信息结合当前玩家判定要弹出的窗口形式
        //同时动态地设置文字

        switch (currentType)
        {

            case "hospital":

                

                Panel.SetActive(true);
                //botton激活与禁用
                leftTop.SetActive(false);
                leftBottom.SetActive(false);
                rightBottom.SetActive(false);
                rightTop.SetActive(false);
                Title.SetActive(true);
                FCtext.SetActive(false);
                mid.SetActive(true);

                mid.GetComponentInChildren<TMPro.TMP_Text>().text = "确认";
                Title.GetComponentInChildren<TMPro.TMP_Text>().text = "你路过了医院，无事发生";
                break;

            case "go_hospital":
                Panel.SetActive(true);
                //botton激活与禁用
                leftTop.SetActive(false);
                leftBottom.SetActive(false);
                rightBottom.SetActive(false);
                rightTop.SetActive(false);
                Title.SetActive(true);
                FCtext.SetActive(false);
                mid.SetActive(true);

                mid.GetComponentInChildren<TMPro.TMP_Text>().text = "确认";
                Title.GetComponentInChildren<TMPro.TMP_Text>().text = "你遇到了一起意外事故并被送进了医院。";
                break;


            case "start":

                //测试
                //string aaa= leftTop.GetComponent<Button>().name;
                //Debug.Log(aaa);
                Panel.SetActive(true);
                //botton激活与禁用
                leftTop.SetActive(false);
                leftBottom.SetActive(false);
                rightBottom.SetActive(false);
                rightTop.SetActive(false);
                Title.SetActive(true);
                FCtext.SetActive(false);
                mid.SetActive(true);

                //botton文本修改
                mid.GetComponentInChildren<TMPro.TMP_Text>().text = "确认";
                Title.GetComponentInChildren<TMPro.TMP_Text>().text = "你回到了梦开始的地方！";



                //只显示到了起点，还不包括路过起点，这里暂时先不加钱，考虑统一加钱
                //UI背景更改为图片start.jpg
                //

                break;
                //数值修改示例：

                //修改地块所有者
                //GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[currentposition].owner = currentTurn;

                //修改玩家属性或金钱
                //Method 1.
                //switch (currentTurn)
                //{
                //    case 1:
                //         GameObject.Find("Player").GetComponent<UIdemo>().player1.getposition()=;
                //        break;
                //    case 2:
                //         GameObject.Find("Player").GetComponent<UIdemo>().player2.getposition()=;
                //        break;
                //    case 3:
                //         GameObject.Find("Player").GetComponent<UIdemo>().player3.getposition()=;
                //        break;
                //    case 4:
                //         GameObject.Find("Player").GetComponent<UIdemo>().player4.getposition()=;
                //        break;
                //    default:
                //        break;
                //}

                //Method2.
                //定义一个新函数，传入string 为要改变的变量，函数里switch这个string来决定要改变的变量，函数内也通过switch
                //currentTurn的方法来确定要修改的玩家。
                //对于双方交易，单独在外面写一个switch也不算太麻烦。

            case "chance":

                Panel.SetActive(true);
                leftTop.SetActive(true);
                leftBottom.SetActive(false);
                rightBottom.SetActive(false);
                rightTop.SetActive(true);
                Title.SetActive(true);
                FCtext.SetActive(true);
                ///先false，后true，要在此脚本处额外写代码
                mid.SetActive(false);
                Title.GetComponentInChildren<TMPro.TMP_Text>().text = "命运";


                //根据玩家的属性值，随机生成一个chanceid

                chanceid = Random.Range(401, 431);

                switch (chanceid)
                {
                    case 401:
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "选金色的";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "选银色的";
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "虽然你什么都没有掉下去，但是河神还是给了你两个选择";
                        break;
                    case 402:
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "恭敬不如从命";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "恭敬不如从命";
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "你是商店的第99个客户，老板要送你一些东西";
                        break;
                    case 403:
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "我寻思也没人要";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "交给警察叔叔";
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "你在马路边看到一个皮夹";
                        break;
                    case 404:
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "意外之喜";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "意外之喜";
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "你在许久未穿的大衣里摸出了100块";
                        break;
                    case 405:
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "可以试试（金币-100）";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "算了算了";
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "有人在兜售奇怪的饮料";
                        break;
                    case 406:
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "可以试试（金币-100）";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "算了算了";
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "有人在兜售奇怪的饮料";
                        break;
                    case 407:
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "可以试试（金币-100）";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "算了算了";
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "有人在兜售奇怪的饮料";
                        break;
                    case 408:
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "可以试试（金币-100）";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "算了算了";
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "有人在兜售奇怪的饮料";
                        break;
                    case 409:
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "可以试试（金币-100）";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "算了算了";
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "有人在兜售奇怪的饮料";
                        break;
                    case 410:
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "可以试试（金币-100）";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "算了算了";
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "有人在兜售奇怪的饮料";
                        break;
                    case 411:
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "久违地吃一顿好的（金币-500）";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "不了，省点钱";
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "遇上了一家知名饭店";
                        break;
                    case 412:
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "久违地吃一顿好的（金币-500）";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "不了，省点钱";
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "遇上了一家知名饭店";

                        break;
                    case 413:
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "久违地吃一顿好的（金币-500）";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "不了，省点钱";
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "遇上了一家知名饭店";
                        break;
                    case 414:
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "久违地吃一顿好的（金币-500）";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "不了，省点钱";
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "遇上了一家知名饭店";
                        break;
                    case 415:
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "久违地吃一顿好的（金币-500）";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "不了，省点钱";
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "遇上了一家知名饭店";
                        break;
                    case 416:
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "久违地吃一顿好的（金币-500）";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "不了，省点钱";
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "遇上了一家知名饭店";
                        break;
                    case 417:
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "久违地吃一顿好的（金币-500）";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "不了，省点钱";
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "遇上了一家知名饭店";
                        break;
                    case 418:
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "买，都可以买（金币-300）";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "不了不了";
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "一个流浪汉神秘兮兮的要卖给你东西";
                        break;
                    case 419:
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "买，都可以买（金币-300）";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "不了不了";
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "一个流浪汉神秘兮兮的要卖给你东西";
                        break;
                    case 420:
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "买，都可以买（金币-300）";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "不了不了";
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "一个流浪汉神秘兮兮的要卖给你东西";
                        break;
                    case 421:
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "买，都可以买（金币-300）";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "不了不了";
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "一个流浪汉神秘兮兮的要卖给你东西";
                        break;
                    case 422:
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "买，都可以买（金币-300）";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "不了不了";
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "一个流浪汉神秘兮兮的要卖给你东西";
                        break;
                    case 423:
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "买，都可以买（金币-300）";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "不了不了";
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "一个流浪汉神秘兮兮的要卖给你东西";
                        break;
                    case 424:
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "买，都可以买（金币-300）";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "不了不了";
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "一个流浪汉神秘兮兮的要卖给你东西";
                        break;
                    case 425:
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "买，都可以买（金币-300）";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "不了不了";
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "一个流浪汉神秘兮兮的要卖给你东西";
                        break;
                    case 426:
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "买，都可以买（金币-300）";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "不了不了";
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "一个流浪汉神秘兮兮的要卖给你东西";
                        break;
                    case 427:
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "买，都可以买（金币-300）";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "不了不了";
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "一个流浪汉神秘兮兮的要卖给你东西";
                        break;
                    case 428:
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "买，都可以买（金币-300）";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "不了不了";
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "一个流浪汉神秘兮兮的要卖给你东西";
                        break;
                    case 429:
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "买，都可以买（金币-300）";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "不了不了";
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "一个流浪汉神秘兮兮的要卖给你东西";
                        break;
                    case 430:
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "我逐渐理解一切";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "这书可以拿来卖钱";
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "你阅读了一本好书";
                        break;


                    default:
                        break;
                }

                chancesign = true;
                //此时说明此chanceid可用


                //给定一个随机的机会文档
                //GameObject.Find("ChanceOrFate").GetComponent<TMPro.TextMeshPro>().text = "";
                //给出反馈



                //机会!
                //给出文字和图片，给出两个选项
                //选择结束后，对玩家的属性进行更改。
                //并弹出窗口提示玩家，玩家可以点确认键以关闭此窗口。


                break;

            case "fate":

                Panel.SetActive(true);
                leftTop.SetActive(false);
                leftBottom.SetActive(false);
                rightBottom.SetActive(false);
                rightTop.SetActive(false);
                Title.SetActive(true);
                FCtext.SetActive(true);
                mid.SetActive(true);

                //
                fateid = Random.Range(501, 519);
                switch (fateid)
                {
                    case 501:
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "不知道从哪里飞来一块小石头";
                        mid.GetComponentInChildren<TMPro.TMP_Text>().text = "进行敏捷判定！";

                        //具体的敏捷判定
                        //if (Random.Range(0, 100) > 50)
                        //{
                        //    //成功
                        //    Panel.SetActive(false);
                        //    sWindow.SetActive(true);
                        //    confirm.SetActive(true);
                        //    sign.SetActive(true);
                        //    //effect要不要显示？

                        //    sign.GetComponentInChildren<TMPro.TMP_Text>().text = "你轻松地躲了过去";
                        //    GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Agility += 2;
                        //}
                        //else
                        //{
                        //    //失败
                        //    Panel.SetActive(false);
                        //    sWindow.SetActive(true);
                        //    confirm.SetActive(true);
                        //    sign.SetActive(true);

                        //    sign.GetComponentInChildren<TMPro.TMP_Text>().text = "你没来得及躲开";
                        //    GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Agility += 2;
                        //}
                        ////


                        break;

                    case 502:
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "一辆AE86冲了过来";
                        mid.GetComponentInChildren<TMPro.TMP_Text>().text = "进行敏捷判定！";//敏捷判定-20


                        break;
                    case 503:
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "黑色轿车上下来了三个暗杀兵";
                        mid.GetComponentInChildren<TMPro.TMP_Text>().text = "进行敏捷判定！";//敏捷判定-40
                        break;
                    case 504:
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "你找到了一个搬重物的临时工作";
                        mid.GetComponentInChildren<TMPro.TMP_Text>().text = "进行力量判定！";//力量判定
                        break;
                    case 505:
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "被人抢劫了";
                        mid.GetComponentInChildren<TMPro.TMP_Text>().text = "进行力量判定！";//力量判定-20
                        break;
                    case 506:
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "几个普通人打得过一个秦森？";
                        mid.GetComponentInChildren<TMPro.TMP_Text>().text = "进行力量判定！";//力量判定-40
                        break;
                    case 507:
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "你尝试处理一段代码中的一个问题";
                        mid.GetComponentInChildren<TMPro.TMP_Text>().text = "进行智力判定！";//智力判定
                        break;
                    case 508:
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "一个教徒试图说服你加入飞天意面神教";
                        mid.GetComponentInChildren<TMPro.TMP_Text>().text = "进行智力判定！";//智力判定-20
                        break;
                    case 509:
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "【难题】机器学习";
                        mid.GetComponentInChildren<TMPro.TMP_Text>().text = "进行智力判定！";//智力判定-40
                        break;
                    case 510:
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "今天的晚饭是华菜土";
                        mid.GetComponentInChildren<TMPro.TMP_Text>().text = "进行体质判定！";//体质判定
                        break;
                    case 511:
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "尝试跑长跑";
                        mid.GetComponentInChildren<TMPro.TMP_Text>().text = "进行体质判定！";//体质判定-20
                        break;
                    case 512:
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "你的对手雇人对你进行真人快打";
                        mid.GetComponentInChildren<TMPro.TMP_Text>().text = "进行体质判定！";//体质判定-40
                        break;
                    case 513:
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "你得到了一个奇怪的灯";
                        mid.GetComponentInChildren<TMPro.TMP_Text>().text = "进行幸运判定！";//幸运判定
                        break;
                    case 514:
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "你得到了一个奇怪的灯";
                        mid.GetComponentInChildren<TMPro.TMP_Text>().text = "进行幸运判定！";//幸运判定-10
                        break;
                    case 515:
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "你得到了一个奇怪的灯";
                        mid.GetComponentInChildren<TMPro.TMP_Text>().text = "进行幸运判定！";//幸运判定-10
                        break;
                    case 516:
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "你得到了一个奇怪的灯";
                        mid.GetComponentInChildren<TMPro.TMP_Text>().text = "进行幸运判定！";//幸运判定-10
                        break;
                    case 517:
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "你得到了一个奇怪的灯";
                        mid.GetComponentInChildren<TMPro.TMP_Text>().text = "进行幸运判定！";//幸运判定-10
                        break;
                    case 518:
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "你得到了一个奇怪的灯";
                        mid.GetComponentInChildren<TMPro.TMP_Text>().text = "进行幸运判定！";//幸运判定-30
                        break;
                    
                    default:
                        break;
                }

                fatesign = true;


               // mid.GetComponentInChildren<TMPro.TMP_Text>().text = "这就是我的命运嘛。。。";
                Title.GetComponentInChildren<TMPro.TMP_Text>().text = "命运";

                //命运
                //对玩家的属性进行更改
                //给出文字和图片，给出确认按钮
                break;
            case "port":

                Panel.SetActive(true);
                if (currentOwner != currentTurn)
                {
                    //不是自己的地

                    leftTop.SetActive(true);
                    leftBottom.SetActive(true);
                    rightBottom.SetActive(true);
                    rightTop.SetActive(true);
                    Title.SetActive(true);
                    FCtext.SetActive(false);
                    mid.SetActive(false);
                    //根据是无主之地或是别人的地，判断UI上显示的文字，以及进行的处理操作。

                    if (currentOwner == 0)
                    {
                        Title.GetComponent<TMPro.TMP_Text>().text = "你走到了一块中立的传送点";
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "买买买！！！";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "下次一定。";
                        //给出花费
                        leftBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "需要花费" + GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[currentposition].price;
                        rightBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "你的剩余金钱" + GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money;
                        //显示点啥呢？
                        int num = 0;
                        if (GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[4].owner==currentTurn)
                        {
                            num += 1;
                        }
                        if (GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[12].owner == currentTurn)
                        {
                            num += 1;
                        }
                        if (GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[22].owner == currentTurn)
                        {
                            num += 1;
                        }
                        if (GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[30].owner == currentTurn)
                        {
                            num += 1;
                        }

                        rightBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "你已经拥有"+num+"个传送点";
                    }

                    //别人的地
                    else
                    {
                        Title.GetComponent<TMPro.TMP_Text>().text = "你走到了属于" + GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentOwner].Name + "的传送点";
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "忍气吞声付下过路费！！！";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "传送点无法被攻击！";
                        leftBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "过路费为:" + currentRent;

                        rightBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "你的剩余金钱" + GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money;


                        //给出过路费金额
                        //leftBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "买买买！！！";

                        //给出当前武德及你将消耗的武德？
                        //rightBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "下次一定。";
                    }

                    //根据选项，进行全局信息的更改：
                    //双方玩家的金钱、block的信息等等。
                }
                else
                {
                    //是自己的地， 是否前往下一个传送点
                    leftTop.SetActive(true);
                    leftBottom.SetActive(false);
                    rightBottom.SetActive(false);
                    rightTop.SetActive(true);
                    Title.SetActive(true);
                    FCtext.SetActive(false);
                    mid.SetActive(false);
                    Title.GetComponent<TMPro.TMP_Text>().text = "你走到了自己的传送点！";
                    leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "传送到下一个传送点！！！";


                    rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "啥都不想干。";
                    
                }



                //判断是否是无主之地 购买or啥也不做
                //判断是否是对手的 付过路费orPK
                //如果是自己的，检测有无其他传送点
                //选择要去的传送点or直接传送到下一个传送点


                break;

            case "store":
                Panel.SetActive(true);
                leftTop.SetActive(false);
                leftBottom.SetActive(false);
                rightBottom.SetActive(false);
                rightTop.SetActive(false);
                Title.SetActive(true);
                FCtext.SetActive(true);
                mid.SetActive(true);

                Title.GetComponentInChildren<TMPro.TMP_Text>().text = "商店";
                FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "你来到了商店，但这里可能还要一些时间才会开门";
                mid.GetComponentInChildren<TMPro.TMP_Text>().text = "好的";

                break;
            case "blocks":
                
                int currentWood = (int)(GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Wood);

                Panel.SetActive(true);
                if (currentOwner != currentTurn)
                {
                    //不是自己的地

                    leftTop.SetActive(true);
                    leftBottom.SetActive(true);
                    rightBottom.SetActive(true);
                    rightTop.SetActive(true);
                    Title.SetActive(true);
                    FCtext.SetActive(false);
                    mid.SetActive(false);
                    //根据是无主之地或是别人的地，判断UI上显示的文字，以及进行的处理操作。
                    

                    //无主之地
                    if (currentOwner == 0)
                    {
                        Title.GetComponent<TMPro.TMP_Text>().text = "你走到了一块无主之地";
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "买买买！！！";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "下次一定。";
                        //
                        leftBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "需要花费"+currentPrice;
                        //显示点啥呢？
                        //设置一个以player1,2,3,4为参数的函数
                        //or gameobject数组
                        rightBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "你的剩余金钱"+ GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money;
                    }

                    //别人的地
                    else
                    {
                        Title.GetComponent<TMPro.TMP_Text>().text = "你走到了属于" + GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentOwner].Name + "的土地";
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "忍气吞声付下过路费！！！";
                        

                        //给出过路费金额
                        leftBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "过路费为:"+currentRent;
                        rightBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "你的剩余金钱" + GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money;

                        //给出当前武德及你将消耗的武德？
                        //给出玩家当前的武德
                        if (GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Wood <= 0)
                        {
                            
                            rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "武德不足，无法决斗";
                            return;
                        }

                        int currentAgility = (int)(GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Agility);
                        int currentStrength = (int)(GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Strength);
                        int currentIntelligence = (int)(GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Intelligence);

                        int ownerAgility = (int)(GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentOwner].Agility);
                        int ownerStrength = (int)(GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentOwner].Strength);
                        int ownerIntelligence = (int)(GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentOwner].Intelligence);

                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Wood -= 1;
                        int att, def;

                        if (GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Name == "杰克霍斯")
                        {
                            att = (int)((currentStrength + currentIntelligence) / 2);
                        }
                        else
                        {
                            att = (int)(currentStrength);
                        }
                        if (GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentOwner].Name == "杰克霍斯")
                        {
                            def = (int)((ownerStrength + ownerIntelligence) / 2);
                        }
                        else if (GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentOwner].Name == "阿哈利姆")
                        {
                            def = (int)(ownerIntelligence);
                        }
                        else
                        {
                            def = (int)(ownerAgility);
                        }
                        int condition = (int)(att * (1 - def / 200.0));
                        int condition3 = (int)((att - 23) * (1 - def / 200.0));
                        
                        int prob = 0;

                        
                        switch (currentHouse)
                        {
                            case 0:
                                
                                prob = condition;
                                break;
                            case 1:
                                
                                prob = (int)(condition * 0.9);
                                break;
                            case 2:
                                
                                prob = (int)(condition * 1.0 * condition / 100);
                                break;
                            case 3:
                                
                                prob = (int)(condition3 * 1.0 * condition3 / 100);
                                break;
                            default:
                                
                                break;
                        }
                        

                        if (prob < 0)
                        {
                            prob = 0;
                        }
                        
                        
                            rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "重拳出击。"+"(预估获胜概率为:"+prob+"%)";
                            rightBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "你的当前武德为:"+currentWood;
                        
                        
                    }

                    

                    //根据选项，进行全局信息的更改：
                    //双方玩家的金钱、block的信息等等。
                }
                else
                {
                    //是自己的地， 是否升级
                    leftTop.SetActive(true);
                    leftBottom.SetActive(true);
                    rightBottom.SetActive(true);
                    rightTop.SetActive(true);
                    Title.SetActive(true);
                    FCtext.SetActive(false);
                    mid.SetActive(false);

                    Title.GetComponent<TMPro.TMP_Text>().text = "你来到了" + "自己" + "的土地";

                    //可能盖不了楼了，加一个判断不能盖楼的if分支，不能盖楼时改成你已经不能再盖楼了
                    if (GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[currentposition].house == 3)
                    {
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "你无法建造更高的楼了";
                    }
                    else
                    {

                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "我要盖楼！！！";
                    }

                    rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "理性消费，算了算了。";

                    leftBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "你的剩余金钱" + GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money;

                    rightBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "盖楼需要" + GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[currentposition].price;
                }


                //判断是否是无主之地 花xxx购买or啥也不做
                //判断是否是对手的 付xxx过路费orPK
                //如果是自己的，花xxx钱盖房子使得房子的租金变成xxxor啥也不干



                break;

            case "special":

                Panel.SetActive(true);
                if (currentOwner != currentTurn)
                {
                    //不是自己的地

                    leftTop.SetActive(true);
                    leftBottom.SetActive(true);
                    rightBottom.SetActive(true);
                    rightTop.SetActive(true);
                    Title.SetActive(true);
                    FCtext.SetActive(false);
                    mid.SetActive(false);
                    //根据是无主之地或是别人的地，判断UI上显示的文字，以及进行的处理操作。

                    if (currentOwner == 0)
                    {
                        Title.GetComponent<TMPro.TMP_Text>().text = "你走到了一块中立的圣地";
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "买买买！！！";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "下次一定。";
                        //给出花费
                        leftBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "需要花费" + GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[currentposition].price;
                        rightBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "你的剩余金钱" + GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money;
                        //显示点啥呢？
                        int num = 0;
                        if (GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[14].owner == currentTurn)
                        {
                            num += 1;
                        }
                        if (GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[30].owner == currentTurn)
                        {
                            num += 1;
                        }
                        

                        rightBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "你已经拥有" + num + "个圣地";
                    }

                    //别人的地
                    else
                    {
                        Title.GetComponent<TMPro.TMP_Text>().text = "你走到了属于" + GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentOwner].Name + "的圣地";
                        leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "忍气吞声付下过路费！！！";
                        rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "圣地无法被攻击！";
                        leftBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "过路费为:" + currentRent;

                        rightBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "你的剩余金钱" + GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money;


                        //给出过路费金额
                        //leftBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "买买买！！！";

                        //给出当前武德及你将消耗的武德？
                        //rightBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "下次一定。";
                    }

                    //根据选项，进行全局信息的更改：
                    //双方玩家的金钱、block的信息等等。
                }
                else
                {
                    //是自己的地， 是否前往下一个传送点
                    leftTop.SetActive(false);
                    leftBottom.SetActive(false);
                    rightBottom.SetActive(false);
                    rightTop.SetActive(false);
                    Title.SetActive(true);
                    FCtext.SetActive(false);
                    mid.SetActive(true);
                    Title.GetComponent<TMPro.TMP_Text>().text = "你走到了自己的圣地，圣地无法被升级";
                    
                }



                //判断是否是无主之地 购买or啥也不做
                //判断是否是对手的 付过路费orPK
                //如果是自己的，检测有无其他传送点
                //选择要去的传送点or直接传送到下一个传送点


                break;
            default:
                break;

        ///利用SetActive()函数控制button的是否显示，并根据情况给button上赋予不同的文本。
        }
    }

    public void LeftTopBottonOnClicked()
    {
        int currentAgility = (int)(GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Agility);
        int currentStrength = (int)(GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Strength);
        int currentIntelligence = (int)(GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Intelligence);
        int currentLuck = (int)(GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Luck);
        int currentToughness = (int)(GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Toughness);
        int currentWood = (int)(GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Wood);

        if (outHosJud)
        {
            int qqq = Random.Range(1, 101);
            if(qqq< (int)(GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[tempTurn].Toughness))
            {
                Panel.SetActive(false);
                sWindow.SetActive(true);
                confirm.SetActive(true);
                sign.SetActive(true);
                sign.GetComponentInChildren<TMPro.TMP_Text>().text = "恭喜！出院成功";
                GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[tempTurn].IsInhos = false;
                
                GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[GameObject.Find("Player").GetComponent<UIdemo>().GameTurn].Model.GetComponent<Animator>().SetBool("IsWeak", false);
                GameObject.Find("Player").GetComponent<UIdemo>().NeedDice = true;
            }
            else
            {
                Panel.SetActive(false);
                sWindow.SetActive(true);
                confirm.SetActive(true);
                sign.SetActive(true);
                sign.GetComponentInChildren<TMPro.TMP_Text>().text = "出院失败";
                

                needWindow = false;

                
            }
            outHosJud = false;
            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].NeedOutHos = false;

            return;
        }






        switch (currentType)
        {
           
            case "chance":
                Panel.SetActive(false);
                sWindow.SetActive(true);
                confirm.SetActive(true);
                sign.SetActive(true);
                int chanceid_2;
                if (chancesign == true)
                {
                    chancesign = false;
                    chanceid_2 = chanceid;
                }
                else { chanceid_2 = 0; }
                switch (chanceid_2)
                {
                    case 401:
                        
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money += 700;
                        sign.GetComponentInChildren<TMPro.TMP_Text>().text = "获得700金币";
                        
                        break;
                    case 402:
                        //GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money += 700;
                        sign.GetComponentInChildren<TMPro.TMP_Text>().text = "获得随机装备";
                        break;
                    case 403:
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money += 1200;
                        sign.GetComponentInChildren<TMPro.TMP_Text>().text = "获得1200金币";
                        break;
                    case 404:
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money += 100;
                        sign.GetComponentInChildren<TMPro.TMP_Text>().text = "获得100金币";
                        break;
                    case 405:
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Strength+=2;
                        sign.GetComponentInChildren<TMPro.TMP_Text>().text = "你的力量提升了"+ System.Environment.NewLine+"力量+2";
                        break;
                    case 406:
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Agility += 2;
                        sign.GetComponentInChildren<TMPro.TMP_Text>().text = "你的敏捷提升了" + System.Environment.NewLine + "敏捷+2";
                        break;
                    case 407:
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Intelligence += 2;
                        sign.GetComponentInChildren<TMPro.TMP_Text>().text = "你的智力提升了" + System.Environment.NewLine + "智力+2";
                        break;
                    case 408:
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Strength -= 1;
                        sign.GetComponentInChildren<TMPro.TMP_Text>().text = "呕。。" + System.Environment.NewLine + "力量-1";
                        break;
                    case 409:
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Agility -= 1;
                        sign.GetComponentInChildren<TMPro.TMP_Text>().text = "呕。。" + System.Environment.NewLine + "敏捷-1";
                        break;
                    case 410:
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Intelligence -= 1;
                        sign.GetComponentInChildren<TMPro.TMP_Text>().text = "呕。。" + System.Environment.NewLine + "智力-1";
                        break;
                    case 411:
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Strength += 4;
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Agility += 4;
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Intelligence += 4;
                        //武德满是多少？？？？
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Wood = 10;

                        sign.GetComponentInChildren<TMPro.TMP_Text>().text = "武德恢复满，全属性+4";
                        break;
                    case 412:
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Strength += 4;
                        sign.GetComponentInChildren<TMPro.TMP_Text>().text = "力量+4";

                        break;
                    case 413:
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Agility += 4;
                        sign.GetComponentInChildren<TMPro.TMP_Text>().text = "敏捷+4";
                        break;
                    case 414:
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Intelligence += 4;
                        sign.GetComponentInChildren<TMPro.TMP_Text>().text = "智力+4";
                        break;
                    case 415:
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Toughness += 1;
                        sign.GetComponentInChildren<TMPro.TMP_Text>().text = "然而饭店名不符实" + System.Environment.NewLine + "体质+1";
                        break;
                    case 416:
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Strength -= 1;
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Agility -= 1;
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Intelligence -= 1;
                        sign.GetComponentInChildren<TMPro.TMP_Text>().text = "甚至还撞上了雷" + System.Environment.NewLine + "力敏智-1";
                        break;
                    case 417:
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Wood -= 2;
                        sign.GetComponentInChildren<TMPro.TMP_Text>().text = "你想投诉，被店家打了一顿" + System.Environment.NewLine + "武德-2";
                        break;
                    case 418:
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money -= 300;
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Luck += 4;
                        sign.GetComponentInChildren<TMPro.TMP_Text>().text = "幸运+4";
                        break;
                    case 419:
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money -= 300;
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Strength += 3;
                        sign.GetComponentInChildren<TMPro.TMP_Text>().text = "力量+3";
                        break;
                    case 420:
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money -= 300;
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Agility += 3;
                        sign.GetComponentInChildren<TMPro.TMP_Text>().text = "敏捷+3";
                        break;
                    case 421:
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money -= 300;
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Intelligence += 3;
                        sign.GetComponentInChildren<TMPro.TMP_Text>().text = "智力+3";
                        break;
                    case 422:
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money -= 300;
                        //获得一件10回合以下装备
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "随机获得一件10回合以下装备";
                        break;
                    case 423:
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money -= 300;
                        //获得随机道具
                        FCtext.GetComponentInChildren<TMPro.TMP_Text>().text = "随机获得一件道具";
                        break;
                    case 424:
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money -= 300;
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Strength += 1;
                        sign.GetComponentInChildren<TMPro.TMP_Text>().text = "然而东西很一般" + System.Environment.NewLine + "力量+1";
                        break;
                    case 425:
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money -= 300;
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Agility += 1;
                        sign.GetComponentInChildren<TMPro.TMP_Text>().text = "然而东西很一般" + System.Environment.NewLine + "敏捷+1";
                        break;
                    case 426:
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money -= 300;
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Intelligence += 1;
                        sign.GetComponentInChildren<TMPro.TMP_Text>().text = "然而东西很一般" + System.Environment.NewLine + "智力+1";
                        break;
                    case 427:
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money -= 300;
                        sign.GetComponentInChildren<TMPro.TMP_Text>().text = "一顿垃圾";
                        break;
                    case 428:
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money -= 300;
                        sign.GetComponentInChildren<TMPro.TMP_Text>().text = "一顿垃圾";
                        break;
                    case 429:
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money -= 300;
                        sign.GetComponentInChildren<TMPro.TMP_Text>().text = "一顿垃圾";
                        break;
                    case 430:
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Intelligence += 4;
                        sign.GetComponentInChildren<TMPro.TMP_Text>().text = "智力+4";
                        break;
                    default:
                        break;
                }

                //给定一个随机的机会文档
                //GameObject.Find("ChanceOrFate").GetComponent<TMPro.TextMeshPro>().text = "";
                //给出反馈

                //你选了试一试
                //给出抽到的事件对应的结果

                //弹出新的框

                Panel.SetActive(false);
                break;

            
            case "port":

                if (currentOwner != currentTurn)
                {
                    //不是自己的地

                    
                    //根据是无主之地或是别人的地，判断UI上显示的文字，以及进行的处理操作。

                    if (currentOwner == 0)
                    {

                        //给出花费
                        //leftBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "买买买！！！";
                        //显示点啥呢？
                        //rightBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "下次一定。";
                        //买地减钱！
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money -= GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[currentposition].price;
                        //成为！地的主人
                        GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[currentposition].owner = currentTurn;

                        Panel.SetActive(false);
                        sWindow.SetActive(true);
                        confirm.SetActive(true);
                        sign.SetActive(true);
                        sign.GetComponentInChildren<TMPro.TMP_Text>().text = "传送点"+""+currentposition+"现在属于"+GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Name+"!";
                        GameObject.Find("Player").GetComponent<DialogShow>().DialogAdd("<color=blue>传送点" + "" + currentposition + "</color>现在属于<color=red>" + GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Name + "</color>!" + System.Environment.NewLine);


                    }

                    //别人的地
                    else
                    {
                        int nnn = Random.Range(1, 101);
                        if (nnn < (int)(GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Luck / 5f))
                        {
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Name + "幸运地躲过了过路费的收取  (" + "以" + (int)GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Luck + "的概率)";
                        }

                        //给出过路费金额
                        //地块主人获得金钱
                        else
                        {
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentOwner].Money += currentRent;

                            //当前玩家减少金钱
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money -= currentRent;
                            //给出当前武德及你将消耗的武德？
                            //rightBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "下次一定。";
                        }
                    }

                    //根据选项，进行全局信息的更改：
                    //双方玩家的金钱、block的信息等等。
                }
                else
                {
                    int target;
                    switch (currentposition)
                    {
                        case 4:
                            target = 12;
                            break;
                        case 12:
                            target = 22;
                            break;
                        case 22:
                            target = 30;
                            break;
                        case 30:
                            target = 4;
                            break;
                        default:
                            target = 0;
                            break;

                    }
                    GameObject.Find("Player" + currentTurn).GetComponent<PlayerMove>().Transfer(target);

                    if (GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[target].owner != currentTurn)
                    {
                        currentposition = target;
                        Panel.SetActive(true);
                        if (currentOwner != currentTurn)
                        {
                            //不是自己的地

                            leftTop.SetActive(true);
                            leftBottom.SetActive(true);
                            rightBottom.SetActive(true);
                            rightTop.SetActive(true);
                            Title.SetActive(true);
                            FCtext.SetActive(false);
                            mid.SetActive(false);
                            //根据是无主之地或是别人的地，判断UI上显示的文字，以及进行的处理操作。

                            if (currentOwner == 0)
                            {
                                Title.GetComponent<TMPro.TMP_Text>().text = "你走到了一块中立的传送点";
                                leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "买买买！！！";
                                rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "下次一定。";
                                //给出花费
                                leftBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "需要花费" + GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[currentposition].price;
                                rightBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "你的剩余金钱" + GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money;
                                //显示点啥呢？
                                int num = 0;
                                if (GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[4].owner == currentTurn)
                                {
                                    num += 1;
                                }
                                if (GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[12].owner == currentTurn)
                                {
                                    num += 1;
                                }
                                if (GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[22].owner == currentTurn)
                                {
                                    num += 1;
                                }
                                if (GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[30].owner == currentTurn)
                                {
                                    num += 1;
                                }

                                rightBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "你已经拥有" + num + "个传送点";
                            }

                            //别人的地
                            else
                            {
                                Title.GetComponent<TMPro.TMP_Text>().text = "你走到了属于" + GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentOwner].Name + "的传送点";
                                leftTop.GetComponentInChildren<TMPro.TMP_Text>().text = "忍气吞声付下过路费！！！";
                                rightTop.GetComponentInChildren<TMPro.TMP_Text>().text = "传送点无法被攻击！";
                                leftBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "过路费为:" + currentRent;

                                rightBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "你的剩余金钱" + GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money;


                                //给出过路费金额
                                //leftBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "买买买！！！";

                                //给出当前武德及你将消耗的武德？
                                //rightBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "下次一定。";
                            }

                            //根据选项，进行全局信息的更改：
                            //双方玩家的金钱、block的信息等等。
                        }

                    }

                    //go to target position



                    //前往地图上的下一个传送点
                    //是自己的地， 是否前往下一个传送点

                    //人物直接移动到自己的下一个传送点


                }


                Panel.SetActive(false);
                break;
            case "blocks":

                if (currentOwner != currentTurn)
                {
                    //不是自己的地

                    
                    //根据是无主之地或是别人的地，判断UI上显示的文字，以及进行的处理操作。


                    //无主之地
                    if (currentOwner == 0)
                    {
                        //买地减钱！
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money -= GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[currentposition].price;
                        //成为！地的主人
                        GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[currentposition].owner = currentTurn;

                        Panel.SetActive(false);
                        sWindow.SetActive(true);
                        confirm.SetActive(true);
                        sign.SetActive(true);
                        sign.GetComponentInChildren<TMPro.TMP_Text>().text = "地块" + "" + currentposition + "现在属于" + GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Name + "!";
                        GameObject.Find("Player").GetComponent<DialogShow>().DialogAdd("<color=yellow>地块" + "" + currentposition + "</color>现在属于<color=red>" + GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Name + "</color>!" + System.Environment.NewLine);


                    }

                    //别人的地
                    else
                    {
                        int nnn = Random.Range(1, 101);
                        if (nnn < (int)(GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Luck / 5f))
                        {
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Name + "幸运地躲过了过路费的收取  (" + "以" + (int)GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Luck + "的概率)";
                        }
                        //地主加钱
                        else
                        {
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentOwner].Money += currentRent;

                            //当前玩家减少金钱
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money -= currentRent;
                        }
 
                    }



                    //根据选项，进行全局信息的更改：
                    //双方玩家的金钱、block的信息等等。
                }
                else
                {
                    //是自己的地， 点击升级
                   

                    //房子盖起来
                    //物理上实现
                    if (GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[currentposition].house == 3)
                    {
                        return;
                    }
                    GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money -= GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[currentposition].price;
                    GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[currentposition].house += 1;
                    GameObject.Find("Cube").GetComponent<BuiltHouse>().builtHouseIn(currentposition, 1);
                }


                //判断是否是无主之地 花xxx购买or啥也不做
                //判断是否是对手的 付xxx过路费orPK
                //如果是自己的，花xxx钱盖房子使得房子的租金变成xxxor啥也不干


                Panel.SetActive(false);
                break;
            default:
                Panel.SetActive(false);
                break;

            ///利用SetActive()函数控制button的是否显示，并根据情况给button上赋予不同的文本。
            case "special":

                if (currentOwner != currentTurn)
                {
                    //不是自己的地


                    //根据是无主之地或是别人的地，判断UI上显示的文字，以及进行的处理操作。

                    if (currentOwner == 0)
                    {

                        //给出花费
                        //leftBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "买买买！！！";
                        //显示点啥呢？
                        //rightBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "下次一定。";
                        //买地减钱！
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money -= GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[currentposition].price;
                        //成为！地的主人
                        GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[currentposition].owner = currentTurn;

                        Panel.SetActive(false);
                        sWindow.SetActive(true);
                        confirm.SetActive(true);
                        sign.SetActive(true);
                        sign.GetComponentInChildren<TMPro.TMP_Text>().text = "圣地" + "" + currentposition + "现在属于" + GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Name + "!";
                        GameObject.Find("Player").GetComponent<DialogShow>().DialogAdd("<color=orange>圣地" + "" + currentposition + "</color>现在属于<color=red>" + GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Name + "</color>!" + System.Environment.NewLine);



                    }

                    //别人的地
                    else
                    {
                        int nnn = Random.Range(1, 101);
                        if (nnn < (int)(GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Luck / 5f))
                        {
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Name + "幸运地躲过了过路费的收取  (" + "以" + (int)GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Luck + "的概率)";
                        }

                        //给出过路费金额
                        //地块主人获得金钱
                        else
                        {
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentOwner].Money += currentRent;

                            //当前玩家减少金钱
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money -= currentRent;
                            //给出当前武德及你将消耗的武德？
                            //rightBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "下次一定。";
                        }
                    }

                    //根据选项，进行全局信息的更改：
                    //双方玩家的金钱、block的信息等等。
                }
                else
                {
                    

                    //go to target position



                    //前往地图上的下一个传送点
                    //是自己的地， 是否前往下一个传送点

                    //人物直接移动到自己的下一个传送点


                }


                Panel.SetActive(false);
                break;
        }
    }

    public void RightTopBottonOnClicked()
    {
        //根据当前地块信息结合当前玩家判定要弹出的窗口形式
        //同时动态地设置文字

        if (GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[tempTurn].IsInhos)
        {


            Panel.SetActive(false);
            sWindow.SetActive(true);
            confirm.SetActive(true);
            sign.SetActive(true);
            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "恭喜！出院成功";
            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[tempTurn].IsInhos = false;
            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[tempTurn].NeedOutHos = false;
            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[GameObject.Find("Player").GetComponent<UIdemo>().GameTurn].Model.GetComponent<Animator>().SetBool("IsWeak", false);
            return;
        }

            switch (currentType)
            {

                //数值修改示例：

                //修改地块所有者
                //GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[currentposition].owner = currentTurn;

                //修改玩家属性或金钱
                //Method 1.
                //switch (currentTurn)
                //{
                //    case 1:
                //         GameObject.Find("Player").GetComponent<UIdemo>().player1.getposition()=;
                //        break;
                //    case 2:
                //         GameObject.Find("Player").GetComponent<UIdemo>().player2.getposition()=;
                //        break;
                //    case 3:
                //         GameObject.Find("Player").GetComponent<UIdemo>().player3.getposition()=;
                //        break;
                //    case 4:
                //         GameObject.Find("Player").GetComponent<UIdemo>().player4.getposition()=;
                //        break;
                //    default:
                //        break;
                //}

                //Method2.
                //定义一个新函数，传入string 为要改变的变量，函数里switch这个string来决定要改变的变量，函数内也通过switch
                //currentTurn的方法来确定要修改的玩家。
                //对于双方交易，单独在外面写一个switch也不算太麻烦。

                case "chance":

                    Panel.SetActive(false);
                    sWindow.SetActive(true);
                    confirm.SetActive(true);
                    sign.SetActive(true);
                    int chanceid_2;
                    if (chancesign == true)
                    {
                        chancesign = false;
                        chanceid_2 = chanceid;
                    }
                    else { chanceid_2 = 0; }
                    switch (chanceid_2)
                    {
                        case 401:
                            //获得随机道具
                            //GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money += 700;
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "获得随机道具";



                            break;
                        case 402:
                            //GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money += 700;
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "获得随机道具";
                            break;
                        case 403:
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Strength += 3;
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Agility += 3;
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Intelligence += 3;
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Toughness += 3;
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Luck += 3;
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "力敏智体质幸运各+3";
                            break;
                        case 404:
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money += 100;
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "意外之喜";
                            break;
                        case 405:

                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "无事发生";
                            break;
                        case 406:
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "无事发生";
                            break;
                        case 407:
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "无事发生";
                            break;
                        case 408:
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "无事发生";
                            break;
                        case 409:
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "无事发生";
                            break;
                        case 410:
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "无事发生";
                            break;
                        case 411:
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "不了，省点钱";
                            break;
                        case 412:
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "不了，省点钱";
                            break;
                        case 413:
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "不了，省点钱";
                            break;
                        case 414:
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "不了，省点钱";
                            break;
                        case 415:
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "不了，省点钱";
                            break;
                        case 416:
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "不了，省点钱";
                            break;
                        case 417:
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "不了，省点钱";
                            break;
                        case 418:
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "不了不了";
                            break;
                        case 419:
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "不了不了";
                            break;
                        case 420:
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "不了不了";
                            break;
                        case 421:
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "不了不了";
                            break;
                        case 422:
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "不了不了";
                            break;
                        case 423:
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "不了不了";
                            break;
                        case 424:
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "不了不了";
                            break;
                        case 425:
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "不了不了";
                            break;
                        case 426:
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "不了不了";
                            break;
                        case 427:
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "不了不了";
                            break;
                        case 428:
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "不了不了";
                            break;
                        case 429:
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "不了不了";
                            break;
                        case 430:
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money += 200;
                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "这书可以拿来卖钱";
                            break;
                        default:
                            break;
                    }

                    Panel.SetActive(false);


                    break;


                case "port":


                    if (currentOwner != currentTurn)
                    {
                        //不是自己的地


                        //根据是无主之地或是别人的地，判断UI上显示的文字，以及进行的处理操作。

                        if (currentOwner == 0)
                        {

                        }

                        //别人的地
                        else
                        {
                            return;
                            //无法挑战
                        }

                        //根据选项，进行全局信息的更改：
                        //双方玩家的金钱、block的信息等等。

                        Panel.SetActive(false);
                    }
                    else
                    {

                        //是自己的地， 是否前往下一个传送点
                        Panel.SetActive(false);

                    }



                    //判断是否是无主之地 购买or啥也不做
                    //判断是否是对手的 付过路费orPK
                    //如果是自己的，检测有无其他传送点
                    //选择要去的传送点or直接传送到下一个传送点


                    break;
                case "blocks":


                    if (currentOwner != currentTurn)
                    {
                        //不是自己的地


                        //根据是无主之地或是别人的地，判断UI上显示的文字，以及进行的处理操作。


                        //无主之地
                        if (currentOwner == 0)
                        {

                        }

                        //别人的地
                        else
                        {
                            //撒打算发
                            if (GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Wood <= 0)
                            {
                                
                                return;
                            }

                            int currentAgility = (int)(GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Agility);
                            int currentStrength = (int)(GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Strength);
                            int currentIntelligence = (int)(GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Intelligence);

                            int ownerAgility = (int)(GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentOwner].Agility);
                            int ownerStrength = (int)(GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentOwner].Strength);
                            int ownerIntelligence = (int)(GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentOwner].Intelligence);

                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Wood -= 1;
                            int att, def;

                            if (GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Name == "杰克霍斯")
                            {
                                att = (int)((currentStrength + currentIntelligence) / 2);
                            }
                            else
                            {
                                att = (int)(currentStrength);
                            }
                            if (GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentOwner].Name == "杰克霍斯")
                            {
                                def = (int)((ownerStrength + ownerIntelligence) / 2);
                            }
                            else if (GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentOwner].Name == "阿哈利姆")
                            {
                                def = (int)(ownerIntelligence);
                            }
                            else
                            {
                                def = (int)(ownerAgility);
                            }
                            int condition = (int)(att * (1 - def / 200.0));
                            int condition3 = (int)((att - 23) * (1 - def / 200.0));
                            int num1 = Random.Range(1, 101);
                            int num2 = Random.Range(1, 101);
                            int prob = 0;

                            bool result;
                            switch (currentHouse)
                            {
                                case 0:
                                    result = (num1 < condition);
                                    prob = condition;
                                    break;
                                case 1:
                                    result = (num1 < condition * 0.9);
                                    prob = (int)(condition * 0.9);
                                    break;
                                case 2:
                                    result = (num1 < condition && num2 < condition);
                                    prob = (int)(condition * 1.0 * condition / 100);
                                    break;
                                case 3:
                                    result = (num1 < condition3 && num2 < condition3);
                                    prob = (int)(condition3 * 1.0 * condition3 / 100);
                                    break;
                                default:
                                    result = false;
                                    Debug.Log("决斗系统出错");
                                    break;
                            }
                            Panel.SetActive(false);
                            sWindow.SetActive(true);
                            confirm.SetActive(true);
                            sign.SetActive(true);

                            if (prob < 0)
                            {
                                prob = 0;
                            }
                        if (result)
                        {
                                sign.GetComponentInChildren<TMPro.TMP_Text>().text = "挑战成功!" + "(以" + prob + "%的概率)";
                                GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[currentposition].house = 0;
                                GameObject.Find("Cube").GetComponent<BuiltHouse>().DeleteHouse(currentposition);
                            if (GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Name == "乐兹壬")
                            {
                                GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[currentposition].owner = 0;
                                
                            }
                            else
                            {
                                GameObject.Find("Blocks").GetComponent<BlocksChange>().all_blocks[currentposition].owner = currentTurn;
                            }

                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Model.GetComponent<Animator>().SetBool("IsBackFlip", true);
                            
                            //若决斗成功
                        }
                        else
                            {

                                int nnn = Random.Range(1, 101);
                                if (nnn < (int)(GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Luck / 5f))
                                {
                                    sign.GetComponentInChildren<TMPro.TMP_Text>().text = GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Name + "幸运地躲过了过路费的收取  (" + "以" + (int)GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Luck + "的概率)";
                                }

                                else
                                {

                                    sign.GetComponentInChildren<TMPro.TMP_Text>().text = "挑战失败!" + "(以" + (100 - prob) + "%的概率)" + System.Environment.NewLine + "并且付了双倍的过路费" + "(" + currentRent * 2 + ")";
                                    GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentOwner].Money += 2 * currentRent;

                                    //当前玩家减少金钱
                                    GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money -= 2 * currentRent;
                                }
                                //若决斗失败
                            }
                            //给出当前武德及你将消耗的武德？
                            //给出玩家当前的武德
                            //rightBottom.GetComponentInChildren<TMPro.TMP_Text>().text = "下次一定。";
                        }



                        //根据选项，进行全局信息的更改：
                        //双方玩家的金钱、block的信息等等。
                        Panel.SetActive(false);
                    }
                    else
                    {
                        Panel.SetActive(false);
                    }


                    //判断是否是无主之地 花xxx购买or啥也不做
                    //判断是否是对手的 付xxx过路费orPK
                    //如果是自己的，花xxx钱盖房子使得房子的租金变成xxxor啥也不干



                    break;
                default:
                    break;

                    ///利用SetActive()函数控制button的是否显示，并根据情况给button上赋予不同的文本。
            }
        }

        public void MidBigBottonOnClicked()
        {
            //根据当前地块信息结合当前玩家判定要弹出的窗口形式
            //同时动态地设置文字

            Panel.SetActive(false);
            if (currentType == "go_hospital")
            {
                //入院
                GameObject.Find("Player" + currentTurn).GetComponent<PlayerMove>().Transfer(9);
                GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].IsInhos = true;
            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].NeedOutHos = true;
            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[GameObject.Find("Player").GetComponent<UIdemo>().GameTurn].Model.GetComponent<Animator>().SetBool("IsWeak", true);
        }

            if (currentType == "fate")
            {
                Panel.SetActive(false);
                sWindow.SetActive(true);
                confirm.SetActive(true);
                sign.SetActive(true);
                int fateid_2;
                if (fatesign == true)
                {
                    fatesign = false;
                    fateid_2 = fateid;
                }
                else { fateid_2 = 0; }
                int currentAgility = (int)(GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Agility);
                int currentStrength = (int)(GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Strength);
                int currentIntelligence = (int)(GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Intelligence);
                int currentLuck = (int)(GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Luck);
                int currentToughness = (int)(GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Toughness);
                int currentResult = Random.Range(0, 100);
                switch (fateid_2)
                {


                    case 501:

                        //具体的判定
                        if (currentResult < currentAgility)
                        {
                            //成功

                            //effect要不要显示？


                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "你轻松地躲了过去" + System.Environment.NewLine + "敏捷+2";
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Agility += 2;
                        }
                        else
                        {
                            //失败


                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "你没来得及躲开" + System.Environment.NewLine + "武德-1";
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Agility += 2;
                        }



                        break;

                    case 502:
                        if (currentResult < (currentAgility - 20))
                        {
                            //成功

                            //effect要不要显示？

                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "你一个腰子翻身过去" + System.Environment.NewLine + "敏捷+7";
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Agility += 7;
                        }
                        else
                        {
                            //失败


                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "De javu（交通事故）" + System.Environment.NewLine + "武德-4";
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Wood -= 4;
                        }



                        break;
                    case 503:
                        if (currentResult < (currentAgility - 40))
                        {
                            //成功

                            //effect要不要显示？

                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "什么吗，我打的还是挺准的" + System.Environment.NewLine + "金币+1200，敏捷+5";
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money += 1200;
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Agility += 5;
                        }
                        else
                        {
                            //失败


                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "不要停下来啊" + System.Environment.NewLine + "武德清空并入院";
                            //后续将添加update检测武德进行入院。
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Wood = 0;
                            GameObject.Find("Player" + currentTurn).GetComponent<PlayerMove>().Transfer(9);
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].IsInhos = true;
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].NeedOutHos = true;
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[GameObject.Find("Player").GetComponent<UIdemo>().GameTurn].Model.GetComponent<Animator>().SetBool("IsWeak", true);
                    }

                        break;
                    case 504:
                        if (currentResult < (currentStrength))
                        {
                            //成功

                            //effect要不要显示？

                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "你出色地完成了任务" + System.Environment.NewLine + "金币+300";
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money += 300;
                        }
                        else
                        {
                            //失败


                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "搬不动的你只能划水" + System.Environment.NewLine + "金币+100";
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Agility += 100;
                        }

                        break;
                    case 505:
                        if (currentResult < (currentStrength - 20))
                        {
                            //成功

                            //effect要不要显示？

                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "那人不如你健壮，还给了你一些东西求饶" + System.Environment.NewLine + "获得10回合以下装备";
                            //获得10回合以下装备
                        }
                        else
                        {
                            //失败


                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "技不如人，只能乖乖交钱" + System.Environment.NewLine + "金币-300";
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money -= 300;
                        }

                        break;
                    case 506:
                        if (currentResult < (currentStrength - 40))
                        {
                            //成功

                            //effect要不要显示？

                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "你大概可以打十个" + System.Environment.NewLine + "力量+7，体质+4";
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Strength += 7;
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Toughness += 4;
                        }
                        else
                        {
                            //失败


                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "显然一个你不够" + System.Environment.NewLine + "武德-2";
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Wood -= 2;
                            //直接进行一个院的入
                        }

                        break;
                    case 507:
                        if (currentResult < (currentIntelligence))
                        {
                            //成功

                            //effect要不要显示？

                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "这个问题成功被修复了" + System.Environment.NewLine + "智力+2";
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Intelligence += 2;
                        }
                        else
                        {
                            //失败


                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "运行时报了更多的错误" + System.Environment.NewLine + "金币-100";
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money -= 100;
                        }

                        break;
                    case 508:
                        if (currentResult < (currentIntelligence - 20))
                        {
                            //成功

                            //effect要不要显示？

                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "你只觉得意面好吃" + System.Environment.NewLine + "体质+4，智力+4";
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Intelligence += 4;
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Toughness += 4;
                        }
                        else
                        {
                            //失败


                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "你敬仰起了飞天意面" + System.Environment.NewLine + "金币-400";
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money -= 400;
                        }

                        break;
                    case 509:
                        if (currentResult < (currentIntelligence - 40))
                        {
                            //成功

                            //effect要不要显示？

                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "你比机器学的快" + System.Environment.NewLine + "智力+7，获得大装备箱（314）";
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Intelligence += 7;
                            //获得大装备箱
                        }
                        else
                        {
                            //失败


                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "准确率20%（悲）" + System.Environment.NewLine + "跳过一回合";
                            //跳过一回合
                        }

                        break;
                    case 510:
                        if (currentResult < (currentToughness))
                        {
                            //成功

                            //effect要不要显示？

                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "鸡盒香香" + System.Environment.NewLine + "体质+2";
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Toughness += 2;
                        }
                        else
                        {
                            //失败


                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "大 喷 射" + System.Environment.NewLine + "体质-2";
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Toughness -= 2;
                        }

                        break;
                    case 511:
                        if (currentResult < (currentToughness - 20))
                        {
                            //成功

                            //effect要不要显示？

                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "你支持到了终点" + System.Environment.NewLine + "体质+3，金币+900";
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Toughness += 3;
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Money += 900;
                        }
                        else
                        {
                            //失败


                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "希 望 之 花" + System.Environment.NewLine + "武德-2";
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Wood -= 2;
                        }

                        break;
                    case 512:
                        if (currentResult < (currentToughness - 40))
                        {
                            //成功

                            //effect要不要显示？

                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "还有谁？" + System.Environment.NewLine + "体质+13";
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Toughness += 13;
                        }
                        else
                        {
                            //失败


                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "满身疮痍" + System.Environment.NewLine + "武德清空并入院";
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].Wood = 0;
                            GameObject.Find("Player" + currentTurn).GetComponent<PlayerMove>().Transfer(9);
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].IsInhos = true;
                        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[currentTurn].NeedOutHos = true;
                            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[GameObject.Find("Player").GetComponent<UIdemo>().GameTurn].Model.GetComponent<Animator>().SetBool("IsWeak", true);
                        //入院
                    }

                        break;
                    case 513:
                        if (currentResult < (currentLuck))
                        {
                            //成功

                            //effect要不要显示？

                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "里面装着一些药" + System.Environment.NewLine + "获得大力（304）";
                            //获得道具大力（304)
                        }
                        else
                        {
                            //失败


                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "只是一个普通的灯" + System.Environment.NewLine + "什么都没发生。。。";

                        }

                        break;
                    case 514:
                        if (currentResult < (currentLuck - 10))
                        {
                            //成功

                            //effect要不要显示？

                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "里面装着看上去可以吃的东西" + System.Environment.NewLine + "获得力量食物（317）";
                            //获得力量食物（317)
                        }
                        else
                        {
                            //失败


                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "只是一个普通的灯" + System.Environment.NewLine + "什么都没发生。。。";

                        }

                        break;
                    case 515:
                        if (currentResult < (currentLuck - 10))
                        {
                            //成功

                            //effect要不要显示？

                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "里面装着看上去可以吃的东西" + System.Environment.NewLine + "获得敏捷食物（317）";
                            //获得敏捷食物（317)
                        }
                        else
                        {
                            //失败


                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "只是一个普通的灯" + System.Environment.NewLine + "什么都没发生。。。";

                        }

                        break;
                    case 516:
                        if (currentResult < (currentLuck - 10))
                        {
                            //成功

                            //effect要不要显示？

                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "里面装着看上去可以吃的东西" + System.Environment.NewLine + "获得智力食物（317）";
                            //获得智力食物（317)
                        }
                        else
                        {
                            //失败


                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "只是一个普通的灯" + System.Environment.NewLine + "什么都没发生";

                        }

                        break;
                    case 517:
                        if (currentResult < (currentLuck - 10))
                        {
                            //成功

                            //effect要不要显示？

                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "里面装着看上去可以吃的东西" + System.Environment.NewLine + "获得体质食物（317）";
                            //获得体质食物（317)
                        }
                        else
                        {
                            //失败


                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "只是一个普通的灯" + System.Environment.NewLine + "什么都没发生";

                        }

                        break;
                    case 518:
                        if (currentResult < (currentLuck - 30))
                        {
                            //成功

                            //effect要不要显示？

                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "里面真的住着灯神" + System.Environment.NewLine + "随机获得两个道具";
                            //随机获得两个道具
                        }
                        else
                        {
                            //失败


                            sign.GetComponentInChildren<TMPro.TMP_Text>().text = "只是一个普通的灯" + System.Environment.NewLine + "什么都没发生";

                        }

                        break;

                    default:
                        break;
                }


            }
        }
        public void ConfirmBottonOnClicked()
        {
            sWindow.SetActive(false);
        }
    }



