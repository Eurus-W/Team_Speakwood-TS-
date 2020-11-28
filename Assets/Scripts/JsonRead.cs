using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person
{
    public string name;
    public int age;
}

public class Persons
{
    public Person[] persons;
}

public class JsonRead : MonoBehaviour
{
    public static string Readjson()
    {
        string jsonfile = "D://testjson.json";

        using (System.IO.StreamReader file = System.IO.File.OpenText(jsonfile))
        {
            
            return file.ReadToEnd();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Person p1 = new Person();
               p1.name = "李逍遥";
               p1.age = 25;
               string jsonStr = JsonUtility.ToJson(p1);
               Debug.Log(jsonStr);
       
       Person p2 = new Person();
               p2.name = "王小虎";
               p2.age = 7;
               Person[] ps = new Person[] { p1, p2 };
      
       Persons persons = new Persons();
               persons.persons = ps;
               jsonStr = Readjson();
        //jsonStr = "{ 'persons':[{'name':'李逍遥','age':25},{'name':'王小虎','age':7}]}";
        //Debug.Log(jsonStr);

        //解析Json
        Persons newPersons = JsonUtility.FromJson<Persons>(jsonStr);
        Debug.Log(Readjson());
        Debug.Log(newPersons.persons[0].name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
