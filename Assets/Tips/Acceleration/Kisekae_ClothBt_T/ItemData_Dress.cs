using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;

public class ItemData_Dress : MonoBehaviour
{
    private GameObject Canvas;
    private GameObject Head;   // ログインテキスト
    private GameObject Leg;  // 新規登録テキスト
    private GameObject Pants;
    private GameObject Top;
    private GameObject Acce;
    private GameObject HeadItem;
    private GameObject HeadItem2;
    private string id = LogInManager.getid();


    // アイテムのデータを保持する辞書
    public static Dictionary<int, string> itemInfo;
    public static Dictionary<int, string> itemTest;
    public static Dictionary<int, int> itemData;

    public static int itemId;
    public static string itemName;
    float time = 0f;
    static int second = 0;


    int ARUKA;
    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        Head = Canvas.transform.Find("Head_tab").gameObject;
        Leg = Canvas.transform.Find("Leg_tab").gameObject;
        Pants = Canvas.transform.Find("Pants_tab").gameObject;
        Top = Canvas.transform.Find("Tops_tab").gameObject;
        Acce = Canvas.transform.Find("Accessory_tab").gameObject;

        //id = "lewisia";
        //list();


        // HeadItem = Canvas.transform.Find("Head_tab/Image/H1").gameObject;
        // HeadItem.SetActive(false);



        itemData = new Dictionary<int, int>();


        for (int i = 0; i < 16; i++)
        {

            itemData.Add(i, 0);
            
            Gacha_result(i, id);
           

        }




        // OnClick_Head();



    }

    
    
    void Gacha_result(int m, string id)
    {

        
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
                    //HeadItem = GameObject.Find(itemName).gameObject;
                    //Debug.Log(" あるお");

                    //HeadItem.SetActive(true);

                    itemData[m] = 1;

                }


            }
        });
        // }
        Debug.Log(itemData[m].ToString());


    }
    // Update is called once per frame


    void Update()
    {
      
    }


    void list()
    {

        itemInfo = new Dictionary<int, string>();
        itemInfo.Add(0, "S1");
        itemInfo.Add(1, "S2");
        itemInfo.Add(2, "S3");
        itemInfo.Add(3, "S4");
        itemInfo.Add(4, "T1");
        itemInfo.Add(5, "T2");
        itemInfo.Add(6, "T3");
        itemInfo.Add(7, "T4");
        itemInfo.Add(8, "A1");
        itemInfo.Add(9, "A2");
        itemInfo.Add(10, "A3");
        itemInfo.Add(11, "B1");
        itemInfo.Add(12, "B2");
        itemInfo.Add(13, "B3");
        itemInfo.Add(14, "H1");
        itemInfo.Add(15, "H2");




    }

    void Test_list()
    {

        itemData = new Dictionary<int, int>();
        itemData.Add(0, 1);
        itemData.Add(1, 0);
        itemData.Add(2, 1);
        itemData.Add(3, 1);
        itemData.Add(4, 0);
        itemData.Add(5, 1);
        itemData.Add(6, 1);
        itemData.Add(7, 0);
        itemData.Add(8, 1);
        itemData.Add(9, 0);
        itemData.Add(10, 1);
        itemData.Add(11, 1);
        itemData.Add(12, 0);
        itemData.Add(13, 0);
        itemData.Add(14, 1);
        itemData.Add(15, 0);




    }


    public void Pantstab_Onclick() {

        list();
        //Test_list();

        for (int i = 0; i < 4; i++)
        {
            itemName = itemInfo[i];
            ARUKA = itemData[i];
            Debug.Log(i.ToString() + " " + ARUKA.ToString() + " " + itemName);
            HeadItem = Pants.transform.Find("Image/" + itemName).gameObject;
            if (ARUKA == 1)
            {
               
            }
            else if (ARUKA == 0)
            {
                HeadItem.SetActive(false);
            }


        }


    }



    public void Toptab_Onclick()
    {
        list();

        for (int i = 4; i < 8; i++)
        {
            itemName = itemInfo[i];
            ARUKA = itemData[i];

            Debug.Log(i.ToString() + " " + ARUKA.ToString() + " " + itemName);
            HeadItem = Top.transform.Find("Image/" + itemName).gameObject;
            if (ARUKA == 1)
            {
                //HeadItem.SetActive(true);
            }
            else if (ARUKA == 0)
            {
                HeadItem.SetActive(false);
            }


        }

    }

    public void Accetab_Onclick()
    {

        list();
        //Test_list();

        for (int i = 8; i < 11; i++)
        {
            itemName = itemInfo[i];
            ARUKA = itemData[i];
            Debug.Log(i.ToString() + " " + ARUKA.ToString() + " " + itemName);
            HeadItem = Acce.transform.Find("Image/" + itemName).gameObject;
            if (ARUKA == 1)
            {

            }
            else if (ARUKA == 0)
            {
                HeadItem.SetActive(false);
            }


        }
    }

        public void Legtab_Onclick()
        {

            list();
            //Test_list();

            for (int i = 11; i < 14; i++)
            {
                itemName = itemInfo[i];
                ARUKA = itemData[i];
                Debug.Log(i.ToString() + " " + ARUKA.ToString() + " " + itemName);
                HeadItem = Leg.transform.Find("Image/" + itemName).gameObject;
                if (ARUKA == 1)
                {

                }
                else if (ARUKA == 0)
                {
                    HeadItem.SetActive(false);
                }


            }


        }

    public void Headtab_Onclick()
    {

        list();
        //Test_list();

        for (int i = 14; i < 16; i++)
        {
            itemName = itemInfo[i];
            ARUKA = itemData[i];
            Debug.Log(i.ToString() + " " + ARUKA.ToString() + " " + itemName);
            HeadItem = Head.transform.Find("Image/" + itemName).gameObject;
            if (ARUKA == 1)
            {

            }
            else if (ARUKA == 0)
            {
                HeadItem.SetActive(false);
            }


        }


    }










}
