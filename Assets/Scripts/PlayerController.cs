using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Transform m_Transform;

    private bool mouseLock;

    void Start()
    {
        mouseLock = false;
        m_Transform = gameObject.GetComponent<Transform>();

    }

    // Update is called once per frame

    void Update()
    {

        MoveControl();
        Cursor.visible = !mouseLock;
        if (mouseLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }


    void MoveControl()

    {

        if (Input.GetKey(KeyCode.W))

        {

            m_Transform.Translate(Vector3.forward * 0.3f, Space.Self);

        }

        if (Input.GetKey(KeyCode.S))

        {

            m_Transform.Translate(Vector3.back * 0.3f, Space.Self);

        }

        if (Input.GetKey(KeyCode.A))

        {

            m_Transform.Translate(Vector3.left * 0.3f, Space.Self);

        }

        if (Input.GetKey(KeyCode.D))

        {

            m_Transform.Translate(Vector3.right * 0.3f, Space.Self);

        }

        if (Input.GetKey(KeyCode.LeftShift))

        {

            m_Transform.Translate(Vector3.down * 0.3f, Space.World);

        }

        if (Input.GetKey(KeyCode.Space))

        {

            m_Transform.Translate(Vector3.up*0.3f, Space.World);

        }

        if (Input.GetKey(KeyCode.Q))

        {

            m_Transform.Rotate(Vector3.up, -1.0f);

        }

        if (Input.GetKey(KeyCode.E))

        {

            m_Transform.Rotate(Vector3.up, 1.0f);

        }

        if (Input.GetKey(KeyCode.G))

        {

            mouseLock = !mouseLock;

        }

        if (mouseLock)
        {
            m_Transform.Rotate(Vector3.up, Input.GetAxis("Mouse X"));
            m_Transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y"));
        }

    }

}