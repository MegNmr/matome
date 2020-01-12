using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;
using System.Linq;

public class current_change : MonoBehaviour
{


    [SerializeField] GameObject pop;
    

    private GameObject OYA;
    private GameObject pass = null;
    private GameObject ad = null;
    private GameObject logout = null;

    private GameObject walk_change;
    private GameObject height_change;
    private GameObject weight_change;

    private GameObject ATO_walk;
    private GameObject ATO_height;
    private GameObject ATO_weight;

    string walkpoint = "0";
    string heightpoint = "10";
    string weightpoint = "50";

    // Start is called before the first frame update
    void Start()
    {

        pop.SetActive(false);

        OYA = GameObject.Find("Panel");
        pass = OYA.transform.Find("pass_change").gameObject;
        ad = OYA.transform.Find("adress_change").gameObject;
        logout = OYA.transform.Find("logout_button").gameObject;


       // Text walk_text = pass.GetComponent<Text>();
       // walk_text.text = "現在の目標歩数: " + walkpoint;
       

        ATO_walk = OYA.transform.Find("walk").gameObject;
        ATO_height = OYA.transform.Find("height").gameObject;
        ATO_weight = OYA.transform.Find("weight").gameObject;

        ATO_walk.SetActive(false);
        ATO_height.SetActive(false);
        ATO_weight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRetry()
    {

        switch (transform.name)
        {
            case "pass_change":
                pass.SetActive(false);
                ad.SetActive(false);
                logout.SetActive(false);


                break;
            case "adress_change":
                pass.SetActive(false);
                ad.SetActive(false);
                logout.SetActive(false);

                break;
            case "logout_button":

                pop.SetActive(true);

                break;
            default:
                break;
        }
    }

    public void ToLogin()
    {
        Application.LoadLevel("LogIn");
    }

    public void ToSetting()
    {
        Application.LoadLevel("Setting");
    }
    /*
        public void SaveRakugaki()
        {
            var message = _rakugakiText.text;
            // 何も入力されていなければ処理しない
            if (message == "")
                return;

            // ここからデータの保存処理開始
            // 検索にはNCMBQueryを使う
            _query = new NCMBQuery<NCMBObject>("TestClass");

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
        }*/

}
