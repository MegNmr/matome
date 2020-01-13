using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using NCMB;
using System;

public class DP_save : MonoBehaviour
{

    // 入力されたテキストへの参照保存用
    

    // NCMBを利用するためのクラス
    private NCMBObject _testClass;
    private NCMBQuery<NCMBObject> _query;
    private NCMBObject deleteClass;

    private int DP;
    private string id;


    void Start()
    {
        // Input Fieldの子要素のText(=入力されたテキスト)への参照を保存
        DP = Acceleration.getDP();
        id = LogInManager.getid();


        
        

    }

    public void SaveRakugaki()
    {
        //var message = _rakugakiText.text;
        // 何も入力されていなければ処理しない
        //if (message == "")
        //   return;

        // ここからデータの保存処理開始
        // 検索にはNCMBQueryを使う
        
       


        _query = new NCMBQuery<NCMBObject>(id + "currentDP"); //class名
        

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

    void SendRakugakiData(int count)
    {
        // ここで指定したクラス名(=RakugakiClass)でNCMBのデータストアに登録される
        // データストアにそのクラスがなければNCMB側で新規作成してくれる
        // データを送る時に、newしておかないと追加ではなく上書き保存されるので注意
        //FindObjectOfType<UserAuth>().logIn(id, pw);
        //QueryTestを検索するクラスを作成
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
                }
                else
                {
                    //Scoreが7のオブジェクトを出力
                    foreach (NCMBObject obj in objList)
                    {

                        obj.DeleteAsync();
                    }
                }
            });
        }






        _testClass = new NCMBObject(id + "currentDP"); //実際に入れるオブジェクト


        // NCMBオブジェクトに値を設定する
        // [ ]内に設定した項目名でデータストアに登録される
        _testClass["id"] = 1; // データ保存件数に+1して連番のidを作成
        _testClass["message"] = DP; // 入力されたテキストをセットで設定


        // データストアへデータを登録する
        _testClass.SaveAsync((NCMBException e) => {
            if (e != null)
            {
                //件数取得失敗時の処理
                Debug.Log("DPの保存に失敗しました");
            }
            else
            {
                //成功時の処理
                Debug.Log("DPの保存に成功しました");
            }
        });
    }


}