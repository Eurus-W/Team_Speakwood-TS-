using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    public string loadsecen;    

    public void localGame()
    {
        SceneManager.LoadScene(loadsecen);
    }
}
