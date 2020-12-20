/// <summary>
///Fate.cs
/// </summary>
[System.Serializable]
public class Fates
{
    public Fate[] fates;


}



[System.Serializable]
public class Fate
{
    public  int id;
    public string info;
    public string need;
    public string success;
    public string successEffect;
    public string fail;
    public string failEffect;

    public int Id { get => id; set => id = value; }
    public string Info { get => info; set => info = value; }
    public string Need { get => need; set => need = value; }
    
    public string Fail { get => fail; set => fail = value; }
    public string FailEffect { get => failEffect; set => failEffect = value; }
    public string Success { get => success; set => success = value; }
    public string SuccessEffect { get => successEffect; set => successEffect = value; }
}
