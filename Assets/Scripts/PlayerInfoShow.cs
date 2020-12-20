using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoShow : MonoBehaviour
{
    public Transform minimap;
    public GameObject image, PlayerName, Strength, Agility, Intelligence, Toughness, Luck, DiscribText;

    private Heroes data;

    private Player player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        updateinfo();
    }

    void updateinfo()
    {
        switch (GameObject.Find("Player").GetComponent<UIdemo>().GameTurn)
        {
            case 1:
                player = GameObject.Find("Player").GetComponent<UIdemo>().player1;
                break;
            case 2:
                player = GameObject.Find("Player").GetComponent<UIdemo>().player2;
                break;
            case 3:
                player = GameObject.Find("Player").GetComponent<UIdemo>().player3;
                break;
            case 4:
                player = GameObject.Find("Player").GetComponent<UIdemo>().player4;
                break;
            default:
                Debug.Log("GameTurn error in script PlayerInfoShow");
                break;
        }
        data = GameObject.Find("HeroData").GetComponent<ReadData>().LoadedData;

        minimap.position = player.Model.transform.position + new Vector3(0, 20, 0);
        Sprite s = Resources.Load("player" + GameObject.Find("Player").GetComponent<UIdemo>().GameTurn,typeof(Sprite)) as Sprite;
        image.GetComponent<Image>().sprite = s;

        GameObject.Find("WoodSlider").GetComponent<Slider>().value = player.Wood;
        PlayerName.GetComponent<Text>().text = data.heroes[player.Key].Name;
        Strength.GetComponent<Text>().text = player.Strength.ToString();
        Agility.GetComponent<Text>().text = player.Agility.ToString();
        Intelligence.GetComponent<Text>().text = player.Intelligence.ToString();
        Toughness.GetComponent<Text>().text = player.Toughness.ToString();
        Luck.GetComponent<Text>().text = player.Luck.ToString();
        DiscribText.GetComponent<Text>().text = player.Intro + "\n<color=green>【技能】</color><color=red>" + player.SkillName + "</color>\n" + player.SkillIntro;

    }
}
