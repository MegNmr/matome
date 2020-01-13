using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using UnityEngine.UI;


public class Acceleration : MonoBehaviour
{
   
    const int HISMAX = 10;      // 履歴の個数
    const float BORDER = 2.0f; // しきい値
    double ikkomae = 1;
    double a = 0.4;
    double LPFY;
    double LPFX;
    static int count = 0;
    int flag=0;
    public GameObject score_object = null; // 歩数表示Textオブジェクト
    public GameObject　tassei = null; // 達成度オブジェクト
    public GameObject ishi = null; // 石の個数表示Textオブジェクト
    public GameObject mokuhyou_obj = null; // 目標表示Textオブジェクト
    public GameObject DATE_obj = null; // 日付表示Textオブジェクト
    int standard = 10;
    float time = 0f;
    static int second = 0;
    int counter = 0;
    Image image_component = null;
    GameObject image_object = null;
    GameObject image_object2 = null;
    InputField inputField;
    Text text;
    int mokuhyou = 500;//目標歩数
    public static int ishinokazu ;//石の数

    Vector3 center;

    List<Vector3> history = new List<Vector3>(HISMAX);

    // Use this for initialization
    void Start()
    {
        center = transform.position;
        // text = GetComponent<Text>();
        image_object = GameObject.Find("Canvas/Debu_Image/debu");
        image_object2 = GameObject.Find("Canvas/Debu_Image/debu2");
        Debug.Log(image_object.name);

        image_object2.SetActive(false);


        //inputField = GameObject.Find("InputField").GetComponent<InputField>();
        //text = GameObject.Find("Message").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        //time count
        time += Time.deltaTime;//毎フレームの時間を加算.
        int minute = (int)time / 60;//分.timeを60で割った値.
        second = (int)time % 60;//秒.timeを60で割った余り.
        string minText, secText;//テキスト形式の分・秒を用意.

        if (minute < 10)
            minText = "0" + minute.ToString();//("0"埋め), ToStringでint→stringに変換.
        else
            minText = minute.ToString();

        if (second < 10)
            secText = "0" + second.ToString();//上に同じく.
        else
            secText = second.ToString();

        // text.text = "[Time] " + minText + ":" + secText;

        // time count end

        counter = second;

        float scale = 2f;
        Vector3 dir = Input.acceleration;
        Vector3 pos = new Vector3(
            center.x + dir.x * scale,
            center.y + dir.y * scale,
            center.z + dir.z * scale
        );
        this.transform.position = pos;

        //ローパスフィルタ処理
        LPFX = HypotenuseLength(dir.x, dir.y, dir.z);
        LPFY = a * LPFX + (1 - a) * ikkomae;
        ikkomae = LPFY;

        //連続でカウントするのを防ぐための処理。flagが０のときのみしかカウントは進まない。
        if (LPFY >= 1.2 && LPFY <= 2.0 && flag == 0)
        {
            count++;
            flag = 1;
        }

        if (flag == 1 && LPFY < 1.2)
        {
            flag = 0;

        }

        if (history.Count >= HISMAX)
        {

            history.RemoveAt(0);
        }

        history.Add(pos);
        DrawLines();

        if (count > 5)
        {
            image_object.SetActive(false);
            image_object2.SetActive(true);
            Debug.Log(image_object.name);

        }


        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text>();
        //count = second;
        //歩数の表示を入れ替える
        score_text.text = count.ToString();

        // オブジェクトからTextコンポーネントを取得
        Text ishi_text = ishi.GetComponent<Text>();
        ishinokazu = count / 10;
        // 石の個数の表示を入れ替える
        ishi_text.text = ishinokazu.ToString();

        // オブジェクトからTextコンポーネントを取得
        if (mokuhyou_obj != null)
        {
            Text makuhyou_text = mokuhyou_obj.GetComponent<Text>();
            makuhyou_text.text = mokuhyou.ToString();
        }
        // 石の個数の表示を入れ替える
        //makuhyou_text.text = mokuhyou.ToString();

        if (DATE_obj != null)
        {
            // オブジェクトからTextコンポーネントを取得
            Text date_text = DATE_obj.GetComponent<Text>();
            date_text.text = DateTime.Now.ToString("yyyy/MM/dd");

        }
        //歩数の表示を入れ替える
        //date_text.text = DateTime.Now.ToString("yyyy/MM/dd");


        //歩数が目標に達していないとき、円を大きくしていく
        if (mokuhyou>=count)
        {
            Transform tassei_scale = tassei.GetComponent<Transform>(); //達成円オブジェクトから Transformコンポーネント取得
            tassei_scale.transform.localScale = new Vector3(2 * (float)count / mokuhyou, 2*(float)count / mokuhyou, 1);//円サイズの変更
        }
        
    

    }


    float HypotenuseLength(float sideALength, float sideBLength, float sideCLength)
    {
        return Mathf.Sqrt(sideALength * sideALength + sideBLength * sideBLength + sideCLength * sideCLength);
    }





    /*private void OnGUI()
    {
        Vector3 dir = Input.acceleration;
       
        GUI.TextField(new Rect(10, 10, 100, 100), "X = " + dir.x.ToString());
        GUI.TextField(new Rect(10, 30, 100, 100), "Y = " + dir.y.ToString());
        GUI.TextField(new Rect(10, 50, 100, 100), "Z = " + dir.z.ToString());
        GUI.TextField(new Rect(10, 70, 100, 100), "atai = " + HypotenuseLength(dir.x, dir.y, dir.z).ToString());
        GUI.TextField(new Rect(10, 90, 100, 100), "LPF = " + LPFY.ToString());
        GUI.TextField(new Rect(10, 110, 100, 100), "Count = " + count.ToString());

        //Text text = obj.GetComponent<Text>();
        //Undo.RegisterCompleteObjectUndo(text, count.ToString());
        //GUI.TextField(new Rect(500, 1000, 100, 100),text);
        //Font font = Resources.Load<Font>("Fonts/07Gosic-Bold");
    }*/

    void DrawLines()
    {
        for (int i = 1; i < history.Count; i++)
        {
            float distance = Vector3.Distance(history[i - 1], history[i]);
            Color col = (distance >= BORDER) ? Color.red : Color.green;
            Debug.DrawLine(history[i - 1], history[i], col, 2.0f);
        }

    }
    public static int getDP()
    {
        ishinokazu = counter;
        return ishinokazu;
    }
}
