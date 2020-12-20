using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExcModel : MonoBehaviour
{
    public GameObject ui;

    // Start is called before the first frame update
    void Start()
    {
        ui.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))

        {

            ui.SetActive(true);
            Time.timeScale = 0;

        }
    }

    public void endButton()
    {
        Application.Quit();
    }
    public void returnButton()
    {
        ui.SetActive(false);
        Time.timeScale = 1;
    }
    public void startButton()
    {
        SceneManager.LoadScene("Scenes/StartScene");
        Time.timeScale = 1;
    }
}
