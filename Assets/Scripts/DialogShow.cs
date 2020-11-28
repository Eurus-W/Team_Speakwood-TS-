using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogShow : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Text1;
    public string DiaLogText = "<color=blue>欢迎来到大富翁！</color>\n";
    public Scrollbar bar;
    void Start()
    {
        StartCoroutine(coroutine1());
    }  
    IEnumerator coroutine1()
    {
        while (true)
        {
            Text1.GetComponent<Text>().text = DiaLogText.Replace("\\n","\n");
            bar.value = 0;
            yield return new WaitForSeconds(0.5f);
        }
    }  

    //添加字幕
    public void DialogAdd(string text)
    {
        DiaLogText += text;
    }
}
