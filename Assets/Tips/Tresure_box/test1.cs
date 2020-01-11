using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class test1 : MonoBehaviour
{

    // アイテムのデータを保持する辞書
    public static Dictionary<int, string> itemInfo;

    // 敵がドロップするアイテムの辞書
    public static Dictionary<int, float> itemDropDict;

    public static int itemId;
    public static string itemName;

    public static int flag = 0;

    public static Image image;
    void Start()
    {
        // GetDropItem();
        image = this.GetComponent<Image>();
        image.enabled = false;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if ((flag == 0) || (flag == 1))
            {
                GetDropItem();
                
            }


            


        }
    }

    public static void GetDropItem()
    {

        if (flag == 1)
        {
            Application.LoadLevel("gacha_result");

            flag = 0;
            
        }
        else
        {
            // 各種辞書の初期化
            InitializeDicts();

            // ドロップアイテムの抽選
            itemId = Choose();

            // アイテムIDに応じたメッセージ出力
            if (itemId != 7)
            {
                itemName = itemInfo[itemId];
                Debug.Log(itemName + " を入手した!");


                Sprite sprite = Resources.Load<Sprite>(itemName);

                image.sprite = sprite;
                image.enabled = true;






            }
            else
            {
                Debug.Log("アイテムは入手できませんでした。");
            }

            flag++;
        }
    }

    public static string getitemName()
    {
        return itemName;
    }

    public static int getitemId()
    {
        return itemId;
    }



    public static void InitializeDicts()
    {
        itemInfo = new Dictionary<int, string>();
        itemInfo.Add(0, "inter_S1");
        itemInfo.Add(1, "inter_S2");
        itemInfo.Add(2, "inter_S3");
        itemInfo.Add(3, "inter_T1");
        itemInfo.Add(4, "inter_T2");
        itemInfo.Add(5, "inter_T3");
        itemInfo.Add(6, "inter_R1");

        itemDropDict = new Dictionary<int, float>();
        itemDropDict.Add(0, 10.0f);
        itemDropDict.Add(1, 10.0f);
        itemDropDict.Add(2, 10.0f);
        itemDropDict.Add(3, 10.0f);
        itemDropDict.Add(4, 10.0f);
        itemDropDict.Add(5, 10.0f);
        itemDropDict.Add(6, 10.0f);
    }

    public static int Choose()
    {
        // 確率の合計値を格納
        float total = 0;

        // 敵ドロップ用の辞書からドロップ率を合計する
        foreach (KeyValuePair<int, float> elem in itemDropDict)
        {
            total += elem.Value;
        }

        // Random.valueでは0から1までのfloat値を返すので
        // そこにドロップ率の合計を掛ける
        float randomPoint = Random.value * total;

        // randomPointの位置に該当するキーを返す
        foreach (KeyValuePair<int, float> elem in itemDropDict)
        {
            if (randomPoint < elem.Value)
            {
                return elem.Key;
            }
            else
            {
                randomPoint -= elem.Value;
            }
        }
        return 0;
    }
}

/*
//probsは確率表記をいれた配列[50,30,10,5]

float Choose(float[] probs)
{

    float total = 0;

    foreach (float elem in probs)
    {
        total += elem;  //合計値に足し込み
    }

    float randomPoint = Random.value * total;//ガチャの値の合計値内相対的位置を算出

    for (int i = 0; i < probs.Length; i++)
    {
        if (randomPoint < probs[i]) //左から当たったガチャ内容を探索
        {
            return i;
        }
        else
        {
            randomPoint -= probs[i];
        }
    }
    return probs.Length - 1;
}

*/
