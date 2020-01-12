using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NCMB;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class onemore : MonoBehaviour
{
    private int DP;
    private string id;
    int count;


    [SerializeField] GameObject pop;
    [SerializeField] GameObject _object;
    private NCMBObject _testClass;
    private NCMBQuery<NCMBObject> _query;


    // Start is called before the first frame update
    void Start()
    {

        
        id = LogInManager.getid();
        pop.SetActive(false);

        NCMBQuery<NCMBObject> query1 = new NCMBQuery<NCMBObject>(id + "currentDP");
        //Scoreの値が7と一致するオブジェクト検索
        query1.WhereEqualTo("id", 1);
        query1.FindAsync((List<NCMBObject> objList, NCMBException P) =>
        {
            if (P != null)
            {
            }
            else
            {
                foreach (NCMBObject obj in objList)
                {
                    DP = int.Parse(obj["message"].ToString());
                }
            }
        });



    }

    // Update is called once per frame
    public void onemore_popup()
    {
        
        if (DP < 10)
        {
            pop.SetActive(true);
            Text _text = _object.GetComponent<Text>();
            _text.text = "DPが不足しています！";

        }
        else
        {
            _query = new NCMBQuery<NCMBObject>(id + "currentDP");



            // 保存されているデータ件数を取得
            _query.CountAsync((int count, NCMBException e) =>
            {
                if (e != null)
                {
                    //件数取得失敗時の処理
                    Debug.Log("DP件数の取得に失敗しました");
                }
                else
                {
                    //データ件数が取得できていたらサーバにデータを送る

                    Debug.Log("ガチャ引くよ～");
                    SendRakugakiData(count);
                    SceneManager.LoadScene("確率判定");
                }
            });
        }
    }


    public void SendRakugakiData(int count)
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
                        obj["message"] = (int.Parse(mDP) - 10).ToString();
                        obj.SaveAsync((NCMBException e) => { });
                        Debug.Log("石が減りました");
                    }
                }
            });
        
    }

}

