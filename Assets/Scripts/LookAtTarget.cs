using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{

    public Transform target;
    public bool onlyY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //当目标对象运动时，始终面向物体

        if (!onlyY)
        {
            transform.LookAt(new Vector3(2*transform.position.x - target.position.x, 2 * transform.position.y - target.position.y, 2 * transform.position.z - target.position.z));
        }


        //当目标对象运动时，始终转向物体

        //但是尽在Y轴上旋转，而不会上下旋转

        //不造成物体倾斜

        else
        {
            transform.LookAt(new Vector3(2 * transform.position.x - target.position.x, transform.position.y, 2 * transform.position.z -  target.position.z));
        }
    }
}
