using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolldice : MonoBehaviour
{

    private string dicetype = "d6-white";
    //private GameObject spwanpoint = null;
    private Vector3 center = new Vector3(5,18,-5);

    public int rollvalue = 0;
    // Start is called before the first frame update
    void Start()
    {
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
        if (Input.GetMouseButtonDown(Dice.MOUSE_LEFT_BUTTON))
        {
            Dice.Clear();
            Dice.Roll("1d6", "d6-white-dots", center, -Force() * (Random.value * 2 - 1));


            Dice.Roll("1d6", "d6-black-dots", center, -Force() * (Random.value * 2 - 1));


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
