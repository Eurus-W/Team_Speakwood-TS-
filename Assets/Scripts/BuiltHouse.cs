using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuiltHouse : MonoBehaviour
{
    public GameObject house1;
    bool test;
    private List<GameObject> houses;
    public float builtSpeed;
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        test = false;
        houses = new List<GameObject>();
        for (int i = 0; i<36; i++)
        {
            GameObject temp = new GameObject();
            temp.SetActive(false);
            houses.Add(temp);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (test)
        {
            builtHouseIn(1, 1);
            builtHouseIn(1, 1);
            builtHouseIn(2, 1);
            test = false;
        }
    }

    /// <summary>
    /// 在某个地块旁增加一层房子
    /// </summary>
    /// <param name="pos">地块id</param>
    public void builtHouseIn(int pos, int type)
    {
        bool IsHouse = true;
        int p_x=0, p_z=0, r_y = 0;
        switch (pos)
        {
            case 1:case 2:case 3:case 4:case 5:case 6:case 7:case 8:
                p_z = 11;
                r_y = 90;
                break;
            case 10:case 11:case 12:case 13:case 14:case 15:case 16:case 17:
                p_x = 11;
                r_y = 180;
                break;
            case 19:case 20:case 21:case 22:case 23:case 24:case 25:case 26:
                p_z = -11;
                r_y = 270;
                break;
            case 28:case 29:case 30:case 31:case 32:case 33:case 34:case 35:
                p_x = -11;
                r_y = 0;
                break;
            default:
                IsHouse = false;
                break;
        }
        if (IsHouse)
        {
            GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[GameObject.Find("Player").GetComponent<UIdemo>().GameTurn].Model.GetComponent<Animator>().SetBool("IsCheering", true);
            if (!houses[pos].activeInHierarchy)
            {
                switch (type)
                {
                    case 1:
                        houses[pos] = Instantiate(house1);
                        break;
                    default:
                        break;
                }

                Vector3 p= GameObject.Find("Player1").GetComponent<PlayerMove>().getPoint(pos) + new Vector3(p_x, -20, p_z);
                houses[pos].transform.position = p;
                houses[pos].transform.rotation = Quaternion.Euler(0, r_y, 0);
                houses[pos].SetActive(true);
                StartCoroutine(HouseShow(houses[pos],8));
            }
            else
            {
                StartCoroutine(HouseShow(houses[pos], 7));
            }



        }
    }
    /// <summary>
    /// 销毁房子
    /// </summary>
    /// <param name="pos">地块id</param>
    public void DeleteHouse(int pos)
    {
        if (!houses[pos].activeInHierarchy)
        {
            houses[pos].SetActive(false);
        }
    }

    IEnumerator HouseShow(GameObject target, int p_y)
    {
        Vector3 pos = target.transform.position + new Vector3(0, p_y, 0);
        Quaternion rot = Quaternion.Euler(target.transform.eulerAngles);
        while (target.transform.position != pos)
        {
            target.transform.position = Vector3.MoveTowards(target.transform.position, pos, builtSpeed * Time.deltaTime);
            target.transform.rotation=Quaternion.Slerp(target.transform.rotation, Quaternion.Euler(target.transform.eulerAngles + new Vector3(0, 10, 0)), Time.deltaTime * rotateSpeed);
            yield return 0;
        }

        target.transform.rotation = rot;
        GameObject.Find("Player").GetComponent<UIdemo>().players.playerlist[GameObject.Find("Player").GetComponent<UIdemo>().GameTurn].Model.GetComponent<Animator>().SetBool("IsCheering", false);
    }
}
