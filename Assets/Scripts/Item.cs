///
///Item.cs
///


[System.Serializable]
public class Items
{
    public Item[] items;
}



[System.Serializable]
public class Item
{
    public int ID;
    //物品图片路径+名字等于其导入路径，存放在统一路径下
    public string name;
    //物品简介
    public double strength, agility, intelligence, toughness, luck;
    public int wood;
    public int price;
    public int round;
    public string effect;
    public string intro;

    public int ID1 { get => ID; set => ID = value; }
    public string Name { get => name; set => name = value; }
    public double Strength { get => strength; set => strength = value; }
    public double Agility { get => agility; set => agility = value; }
    public double Intelligence { get => intelligence; set => intelligence = value; }
    public double Toughness { get => toughness; set => toughness = value; }
    public double Luck { get => luck; set => luck = value; }
    public int Wood { get => wood; set => wood = value; }
    public int Price { get => price; set => price = value; }
    public int Round { get => round; set => round = value; }
    public string Effect { get => effect; set => effect = value; }
    public string Intro { get => intro; set => intro = value; }
}

