using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Acceleration : MonoBehaviour
{

    const int HISMAX = 10;      // 履歴の個数
    const float BORDER = 2.0f; // しきい値
    double ikkomae = 1;
    double a = 0.3;
    double LPFY;
    double LPFX;
    int count = 0;
    int standard = 10;
    float time = 0f;
    int second = 0;
    //int counter = 0;
    Image image_component = null;
    GameObject image_object = null;
    GameObject image_object2 = null;

    InputField inputField;
    Text text;


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

        float scale = 2f;
        Vector3 dir = Input.acceleration;
        Vector3 pos = new Vector3(
            center.x + dir.x * scale,
            center.y + dir.y * scale,
            center.z + dir.z * scale
        );
        this.transform.position = pos;

        LPFX = HypotenuseLength(dir.x, dir.y, dir.z); //kasokudo
        LPFY = a * LPFX + (1 - a) * ikkomae;
        ikkomae = LPFY; //filter

        if (history.Count >= HISMAX)
        {

            if (LPFY >= 1.5 & LPFY <= 2.0)
            {
                count++; //hosuu
            }

            history.RemoveAt(0);
        }
        history.Add(pos);
        DrawLines();

        if (second > 5)
        {
            image_object.SetActive(false);
            image_object2.SetActive(true);
            Debug.Log(image_object.name);

        }

    }

    float HypotenuseLength(float sideALength, float sideBLength, float sideCLength)
    {
        return Mathf.Sqrt(sideALength * sideALength + sideBLength * sideBLength + sideCLength * sideCLength);
    }



    private void OnGUI()
    {
        Vector3 dir = Input.acceleration;
        GUI.TextField(new Rect(10, 10, 100, 100), "X = " + dir.x.ToString());
        GUI.TextField(new Rect(10, 30, 100, 100), "Y = " + dir.y.ToString());
        GUI.TextField(new Rect(10, 50, 100, 100), "Z = " + dir.z.ToString());
        GUI.TextField(new Rect(10, 70, 100, 100), "atai = " + HypotenuseLength(dir.x, dir.y, dir.z).ToString());
        GUI.TextField(new Rect(10, 90, 100, 100), "LPF = " + LPFY.ToString());
        GUI.TextField(new Rect(10, 110, 100, 100), "Count = " + count.ToString());
        GUI.TextField(new Rect(10, 130, 100, 100), "second = " + second.ToString());


    }

    void DrawLines()
    {
        for (int i = 1; i < history.Count; i++)
        {
            float distance = Vector3.Distance(history[i - 1], history[i]);
            Color col = (distance >= BORDER) ? Color.red : Color.green;
            Debug.DrawLine(history[i - 1], history[i], col, 2.0f);
        }

    }
}
