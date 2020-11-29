///
///ReadData.cs
///



using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ReadData : MonoBehaviour
{
    public Text showText;
    public string fileName;
    private Heroes loadedData;
    private bool isRead = false; 

    public Heroes LoadedData { get => loadedData; set => loadedData = value; }
    public bool IsRead { get => isRead; set => isRead = value; }

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
        if(File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);

            LoadedData = JsonUtility.FromJson<Heroes>(dataAsJson);
            Debug.Log("Data loaded, dictionary contains: " + LoadedData.heroes.Length + " entries");
            ///Debug.Log(loadedData.heroes[1].Info);
            Debug.Log(loadedData.heroes[0].Heroid);
            Debug.Log(LoadedData.heroes[0].Info);
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
