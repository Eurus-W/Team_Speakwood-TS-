

///
///Hero.cs
///

using System;
using UnityEngine;

[System.Serializable]
public class Heroes
{
    public Hero[] heroes;
}



[System.Serializable]
public class Hero
{
    //private GameObject model;
    public int heroid;
    public string name;
    //五项属性值
    public double strength, agility, intelligence, toughness, luck;//力、敏、智、幸运、体质
    //武德
    public int wood;
    public string info;
    public string skillName;
    public string skillIntro;




    public double Strength { get => strength; set => strength = value; }
    public double Agility { get => agility; set => agility = value; }
    public double Intelligence { get => intelligence; set => intelligence = value; }
    public double Luck { get => luck; set => luck = value; }
    public double Toughness { get => toughness; set => toughness = value; }
    public int Wood { get => wood; set => wood = value; }
    public int Heroid { get => heroid; set => heroid = value; }
    public string Info { get => info; set => info = value; }
    public string Name { get => name; set => name = value; }
    public string SkillName { get => skillName; set => skillName = value; }
    public string SkillIntro { get => skillIntro; set => skillIntro = value; }
}


