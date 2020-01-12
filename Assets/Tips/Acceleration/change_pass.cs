using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;
using System.Linq;

public class change_pass : MonoBehaviour
{
    private GameObject OYA;
    private GameObject current = null;
    private GameObject shin = null;
    private GameObject again = null;

    private Text _cur;
    private Text _shin;
    private Text _again;

    private string id;

    NCMBUser _query;




    // Start is called before the first frame update
    void Start()
    {
        OYA = GameObject.Find("Panel");
        current = OYA.transform.Find("current").gameObject;
        shin = OYA.transform.Find("new").gameObject;
        again = OYA.transform.Find("again").gameObject;

        _cur = current.transform.Find("Text").GetComponent<Text>();
        _shin = shin.transform.Find("Text").GetComponent<Text>();
        _again = shin.transform.Find("Text").GetComponent<Text>();

        id = LogInManager.getid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveRakugaki()
    {
        var mes_cur = _cur.text;
        var mes_shin = _shin.text;
        var mes_again = _again.text;

        // 何も入力されていなければ処理しない
        if (mes_cur == "" || mes_shin == "" || mes_again == "")
            return;

        // ここからデータの保存処理開始
        // 検索にはNCMBQueryを使う
        _query = NCMBUser.CurrentUser;
        if (_query != null)
        {
            if ((_query.mailAdress.Equals(mes_cur)) && (mes_shin.Equals(mes_again)))
            {
                Debug.Log("あってる！");
            }
        }
    }
/*
        // 保存されているデータ件数を取得
        _query.CountAsync((int count, NCMBException e) => {
            if (e != null)
            {
                //件数取得失敗時の処理
                Debug.Log("件数の取得に失敗しました");
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
        _testClass = new NCMBObject("TestClass");

        // NCMBオブジェクトに値を設定する
        // [ ]内に設定した項目名でデータストアに登録される


        _testClass["id"] = count + 1; // データ保存件数に+1して連番のidを作成
        _testClass["message"] = _rakugakiText.text; // 入力されたテキストをセットで設定

        // データストアへデータを登録する
        _testClass.SaveAsync((NCMBException e) => {
            if (e != null)
            {
                //件数取得失敗時の処理
                Debug.Log("データの保存に失敗しました");
            }
            else
            {
                //成功時の処理
                Debug.Log("データの保存に成功しました");
            }
        });


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


    }*/
}

