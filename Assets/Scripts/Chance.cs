using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Chances
{
    public Chance[] chances;
}



[System.Serializable]
public class Chance
{
    public int id;
    public int quality;
    public string info,aintro,aResultIntro, aEffect, bintro, bResultIntro, bEffect;

    public int Id { get => id; set => id = value; }
    public int Quality { get => quality; set => quality = value; }
    public string Info { get => info; set => info = value; }
    public string Aintro { get => aintro; set => aintro = value; }
    public string AResultIntro { get => aResultIntro; set => aResultIntro = value; }
    public string AEffect { get => aEffect; set => aEffect = value; }
    public string Bintro { get => bintro; set => bintro = value; }
    public string BResultIntro { get => bResultIntro; set => bResultIntro = value; }
    public string BEffect { get => bEffect; set => bEffect = value; }
}
