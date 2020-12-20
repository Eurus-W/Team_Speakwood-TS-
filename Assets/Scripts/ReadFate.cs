///
///ReadFate.cs
///



using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class ReadFate : MonoBehaviour
{
    public Text showText;
    public string fileName;
    private Fates loadedFate;
    private bool isRead = false;


    public bool IsRead { get => isRead; set => isRead = value; }
    public Fates LoadedFate { get; set; }

    //public static string Readjson()
    //{
    //    string path = "/Users/stephenwang/Desktop/软件工程/数据/character.json";
    //    using (System.IO.StreamReader file = System.IO.File.OpenText(path))
    //    {
    //        return file.ReadToEnd();
    //    }

    //}
    //// Start is called before the first frame update
    void Start()
    {
        IsRead = false;
        //string jsonStr = Readjson();
        //Persons newPersons = JsonUtility.FromJson<Persons>(jsonStr);
        //Debug.Log(Readjson());
        //Debug.Log(newPersons.persons[0].name);
        LoadJsonDateText();
        IsRead = true;
        //showAllJsonData();
    }

    private void LoadJsonDateText()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            Debug.Log(dataAsJson);

            loadedFate = JsonUtility.FromJson<Fates>(dataAsJson);
            Debug.Log(loadedFate.fates);
            ///Debug.Log(loadedData.items[0].intro);
        }


        else
        {
            Debug.LogError("Cannot find file! Make sure file in\"Assets/StreamingAssets\" path. And file suffix should be\".json \"");

        }
    }

    //public void showAllJsonData()
    //{
    //    showText.text = "";
    //    for(int i = 0; i < loadedData.heroes.Length; ++i)
    //    {
    //        showText.text += loadedData.heroes[i].Heroid + " : " + loadedData.heroes[i].Name + "\n";
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
