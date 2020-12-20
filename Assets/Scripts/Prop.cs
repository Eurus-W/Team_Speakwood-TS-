using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Props
{
    public Prop[] props;

    
}



[System.Serializable]
public class Prop
{
    public int id;
    public string name;
    public string usage;
    public string info;

    public int Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public string Usage { get => usage; set => usage = value; }
    public string Info { get => info; set => info = value; }
}

