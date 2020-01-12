using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using NCMB;
using System;

public class DP_check : MonoBehaviour
{


 
    private int DP;
    private string id;
    private NCMBObject _testClass;
    private NCMBQuery<NCMBObject> _query;

    // 初期化
    void Start()
    {
        DP = Acceleration.getDP();
        id = LogInManager.getid();
    }

    // 更新
    public void SaveRakugaki()
    {
        _query = new NCMBQuery<NCMBObject>(id + "currentDP");


        
        // 保存されているデータ件数を取得
        _query.CountAsync((int count, NCMBException e) => {
            if (e != null)
            {
                //件数取得失敗時の処理
                Debug.Log("DP件数の取得に失敗しました");
            }
            else
            {
                //データ件数が取得できていたらサーバにデータを送る


                SendRakugakiData(count);

            }
        });
    }

    public void SendRakugakiData(int count)
    {
        if (count != 0)
        {
            NCMBQuery<NCMBObject> query1 = new NCMBQuery<NCMBObject>(id + "currentDP");
            //Scoreの値が7と一致するオブジェクト検索
            query1.WhereEqualTo("id", 1);
            query1.FindAsync((List<NCMBObject> objList, NCMBException P) =>
            {
                if (P != null)
                {
                    //検索失敗時の処理
                    Debug.Log("石は減っていません");
                }
                else
                {
                    foreach (NCMBObject obj in objList)
                    {
                        string mDP = obj["message"].ToString();
                        obj["message"] =  (int.Parse(mDP)-10).ToString();
                         obj.SaveAsync((NCMBException e) => { });
                        Debug.Log("石が減りました");
                    }
                }
            });
        }
    }


}