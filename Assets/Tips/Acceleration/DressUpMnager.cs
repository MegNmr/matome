using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;

public class DressUpMnager : MonoBehaviour
{
    private GameObject Canvas;
    private GameObject Head;   // ログインテキスト
    private GameObject Leg;  // 新規登録テキスト
    private GameObject Pants;
    private GameObject Top;
    private GameObject HeadItem;
    private string id = LogInManager.getid();


    // アイテムのデータを保持する辞書
    public static Dictionary<int, string> itemInfo;
    public static Dictionary<int, bool> _itemInfo;

    public static Dictionary<int, int> itemData;

    public static int itemId;
    public static string itemName;
    float time = 0f;
    static int second = 0;


    int ARUKA;
    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.Find("Head_tab");
        Head = Canvas.transform.Find("Image").gameObject;


        Leg = Canvas.transform.Find("Leg").gameObject;


        Pants = Canvas.transform.Find("Pants").gameObject;


        Top = Canvas.transform.Find("Top").gameObject;


        list();


        // HeadItem = Canvas.transform.Find("Head/" + itemName).gameObject;


        itemData = new Dictionary<int, int>();


        for (int i = 0; i < 12; i++)
        {
            list_data(i);
            Gacha_result(i, id);


        }




        // OnClick_Head();



    }
    void Gacha_result(int m, string id)
    {

        //id = "lewisia";
        NCMBQuery<NCMBObject> query1 = new NCMBQuery<NCMBObject>(id + "gacha_result");
        query1.WhereEqualTo("message", m);
        query1.FindAsync((List<NCMBObject> objList, NCMBException P) =>
        {
            if (P != null)
            {
                Debug.Log(m.ToString() + "はないよ");
                //itemName = itemInfo[m];
                //HeadItem = Canvas.transform.Find("Head/" + itemName).gameObject;
                //HeadItem.SetActive(false);



            }
            else
            {
                foreach (NCMBObject obj in objList)
                {
                    Debug.Log(m.ToString() + " はあるお");
                    //itemName = itemInfo[m];
                    //HeadItem = Canvas.transform.Find("Head/" + itemName).gameObject;
                    //Debug.Log(" あるお");

                    //HeadItem.SetActive(true);

                    itemData[m] = 1;

                }


            }
        });
        // }

    }
    // Update is called once per frame


    void Update()
    {
        //time count
        time += Time.deltaTime;//毎フレームの時間を加算.
        int minute = (int)time / 60;//分.timeを60で割った値.
        second = (int)time % 60;//秒.timeを60で割った余り.

        if (second == 1)
        {

            OnClick_Head();
            Debug.Log("こんちわー");

        }
    }


    void list()
    {

        itemInfo = new Dictionary<int, string>();
        itemInfo.Add(0, "inter_S1");
        itemInfo.Add(1, "inter_S2");
        itemInfo.Add(2, "inter_S3");
        itemInfo.Add(3, "inter_S4");
        itemInfo.Add(4, "inter_T1");
        itemInfo.Add(5, "inter_T2");
        itemInfo.Add(6, "inter_T3");
        itemInfo.Add(7, "inter_T4");
        itemInfo.Add(8, "inter_R1");
        itemInfo.Add(9, "inter_R2");
        itemInfo.Add(10, "inter_R3");
        itemInfo.Add(11, "inter_B1");
        itemInfo.Add(12, "inter_B2");
        itemInfo.Add(13, "inter_B3");
        itemInfo.Add(14, "inter_H1");
        itemInfo.Add(15, "inter_H2");
       


    }

    void _list()
    {
        _itemInfo = new Dictionary<int, bool>();
        _itemInfo.Add(0, false);
        _itemInfo.Add(1, false);
        _itemInfo.Add(2, false);
        _itemInfo.Add(3, false);
        _itemInfo.Add(4, false);
        _itemInfo.Add(5, false);
        _itemInfo.Add(6, false);
        _itemInfo.Add(7, false);
        _itemInfo.Add(8, false);
        _itemInfo.Add(9, false);
        _itemInfo.Add(10, false);
        _itemInfo.Add(11, false);
        _itemInfo.Add(12, false);
        _itemInfo.Add(13, false);
        _itemInfo.Add(14, false);
        _itemInfo.Add(15, false);

    }

    void list_data(int number)
    {


        itemData.Add(number, 0);




    }



    public void OnClick_Head()
    {
        list();
        Leg.SetActive(false);
        Pants.SetActive(false);
        Top.SetActive(false);
        Head.SetActive(true);

        for (int i = 6; i < 9; i++)
        {
            itemName = itemInfo[i];
            ARUKA = itemData[i];

            Debug.Log(i.ToString() + " " + ARUKA.ToString());
            HeadItem = Canvas.transform.Find("Head/" + itemName).gameObject;
            if (ARUKA == 1)
            {
                HeadItem.SetActive(true);
                _itemInfo[i] = true;
            }
            else
            {
                HeadItem.SetActive(false);
                _itemInfo[i] = false;
            }


        }








    }

    public void OnClick_Leg()
    {
        Head.SetActive(false);
        Leg.SetActive(true);
        Pants.SetActive(false);
        Top.SetActive(false);

        for (int i = 9; i < 12; i++)
        {
            itemName = itemInfo[i];
            ARUKA = itemData[i];

            Debug.Log(i.ToString() + " " + ARUKA.ToString());
            HeadItem = Canvas.transform.Find("Leg/" + itemName).gameObject;
            if (ARUKA == 1)
            {
                HeadItem.SetActive(true);
                _itemInfo[i] = true;
            }
            else
            {
                HeadItem.SetActive(false);
                _itemInfo[i] = false;
            }


        }


    }

    public void OnClick_Pants()
    {
        Head.SetActive(false);
        Leg.SetActive(false);
        Pants.SetActive(true);
        Top.SetActive(false);

        for (int i = 0; i < 3; i++)
        {
            itemName = itemInfo[i];
            ARUKA = itemData[i];

            Debug.Log(i.ToString() + " " + ARUKA.ToString());
            HeadItem = Canvas.transform.Find("Pants/" + itemName).gameObject;
            if (ARUKA == 1)
            {
                HeadItem.SetActive(true);
                _itemInfo[i] = true;
            }
            else
            {
                HeadItem.SetActive(false);
                _itemInfo[i] = false;
            }


        }


    }

    public void OnClick_Top()
    {
        Head.SetActive(false);
        Leg.SetActive(false);
        Pants.SetActive(false);
        Top.SetActive(true);

        for (int i = 3; i < 6; i++)
        {
            itemName = itemInfo[i];
            ARUKA = itemData[i];

            Debug.Log(i.ToString() + " " + ARUKA.ToString());
            HeadItem = Canvas.transform.Find("Top/" + itemName).gameObject;
            if (ARUKA == 1)
            {
                HeadItem.SetActive(true);
                _itemInfo[i] = true;
            }
            else
            {
                HeadItem.SetActive(false);
                _itemInfo[i] = false;
            }


        }

    }

    public static Dictionary<int, bool> returnList()
    {
        return _itemInfo;
    }

    public static Dictionary<int, string> returnListItem()
    {
        return itemInfo;
    }
}
