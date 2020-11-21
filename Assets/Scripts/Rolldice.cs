using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Rolldice : MonoBehaviour
{
    public GameObject Bottom;
    private string dicetype = "d6-white";
    //private GameObject spwanpoint = null;
   
    private Vector3 center = new Vector3(5,18,-5);
    private Vector3 temp = new Vector3(0, 1, 0);
    private int sum;
    private float time;
    
    public int rollvalue = 0;

    public int DiceSum { get => sum; set => sum = value; }

    // Start is called before the first frame update
    void Start()
    {
        sum = -1;
        time = 0;
        center = Bottom.transform.position;
        center = center + temp;
        Application.targetFrameRate = 120;
        
    }

    private Vector3 Force()
    {
        Vector3 rollTarget = Vector3.zero + new Vector3(2 + 7 * Random.value, .5F + 4 * Random.value, -2 - 3 * Random.value);
        return Vector3.Lerp(center, rollTarget, 1).normalized * (-35 - Random.value * 20);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        bool label = true;
        if (Input.GetMouseButtonDown(Dice.MOUSE_LEFT_BUTTON)&&label)
        {
            Dice.Clear();
            Dice.Roll("1d6", "d6-white-dots", center, -Force() * (Random.value * 2 - 1));
            Dice.Roll("1d6", "d6-black-dots", center, -Force() * (Random.value * 2 - 1));
            time += Time.deltaTime; ;
        }
        if (time > 0) {
            time += Time.deltaTime;
            
        }
        if (time > 2)
        {
            Debug.Log(Dice.Value("d6"));
            sum = Dice.Value("d6");
            time = 0;
        }

    }


    void OnGUI()
    {


       
        if (Dice.Count("") > 0)
        {
            // we have rolling dice so display rolling status
            GUI.Box(new Rect(10, Screen.height - 75, Screen.width - 20, 30), "");
            GUI.Label(new Rect(20, Screen.height - 70, Screen.width, 20), Dice.AsString(""));
        }
        

    }

   

               
    
}
