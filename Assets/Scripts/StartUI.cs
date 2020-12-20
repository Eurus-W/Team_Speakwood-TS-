using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    public string loadsecen;
    public GameObject settingsPanel, slidSound, slidFrame, Sound, Frame;

    void Start()
    {
        settingsPanel.SetActive(false);
    }

    void Update()
    {
        Sound.GetComponent<Text>().text = ((int)Mathf.Round(slidSound.GetComponent<Slider>().value)).ToString();
        Frame.GetComponent<Text>().text = ((int)Mathf.Round(slidFrame.GetComponent<Slider>().value)).ToString();
        Application.targetFrameRate = (int)Mathf.Round(slidFrame.GetComponent<Slider>().value);
        GameObject.Find("MainCamera").GetComponent<AudioSource>().volume = Mathf.Round(slidSound.GetComponent<Slider>().value) / 100;
        
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SButton()
    {
        if (settingsPanel.activeInHierarchy) return;
        settingsPanel.SetActive(true);

    }

    public void Xbutton()
    {
        GameObject.Find("SettingsPanel").SetActive(false);
    }

    public void localGame()
    {
        GameObject.Find("PopText").GetComponent<Animator>().SetBool("PopDefeat", false);
        GameObject.Find("Zimu").GetComponent<Animator>().SetBool("IsZimu", false);
        GameObject.Find("LocalGame").GetComponent<Animator>().SetBool("IsNewgame", true);
        StartCoroutine(WaitForScene(3));
    }

    public void OnlineGame()
    {
        GameObject.Find("Zimu").GetComponent<Animator>().SetBool("IsZimu", false);
        GameObject.Find("LocalGame").GetComponent<Animator>().SetBool("IsNewgame", false);
        GameObject.Find("PopText").GetComponent<Animator>().SetBool("PopDefeat", true);
        StartCoroutine(wait(1));
    }

    public void Kaifa()
    {
        GameObject.Find("PopText").GetComponent<Animator>().SetBool("PopDefeat", false);
        GameObject.Find("LocalGame").GetComponent<Animator>().SetBool("IsNewgame", false);
        GameObject.Find("Zimu").GetComponent<Animator>().SetBool("IsZimu", true);
        StartCoroutine(waitForzimu(10));
    }

    IEnumerator wait(int sec)
    {
        yield return new WaitForSeconds(sec);
        GameObject.Find("PopText").GetComponent<Animator>().SetBool("PopDefeat", false);
    }

    IEnumerator WaitForScene(int sec)
    {
        yield return new WaitForSeconds(sec);
        GameObject.Find("PopText").GetComponent<Animator>().SetBool("IsNewgame", false);
        SceneManager.LoadScene(loadsecen);
    }

    IEnumerator waitForzimu(int sec)
    {
        yield return new WaitForSeconds(sec);
        GameObject.Find("Zimu").GetComponent<Animator>().SetBool("IsZimu", false);
    }
}
