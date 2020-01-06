using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class Acceleration : MonoBehaviour
{
   
    const int HISMAX = 10;      // 履歴の個数
    const float BORDER = 2.0f; // しきい値
    double ikkomae = 1;
    double a = 0.4;
    double LPFY;
    double LPFX;
    int count = 0;
    int flag=0;
    public GameObject score_object = null; // Textオブジェクト



    Vector3 center;

    List<Vector3> history = new List<Vector3>(HISMAX);

    // Use this for initialization
    void Start()
    {
        center = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        float scale = 2f;
        Vector3 dir = Input.acceleration;
        Vector3 pos = new Vector3(
            center.x + dir.x * scale,
            center.y + dir.y * scale,
            center.z + dir.z * scale
        );
        this.transform.position = pos;

        LPFX = HypotenuseLength(dir.x, dir.y, dir.z);
        LPFY = a * LPFX + (1 - a) * ikkomae;
        ikkomae = LPFY;

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

        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_text.text = count.ToString();

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

        //Text text = obj.GetComponent<Text>();
        //Undo.RegisterCompleteObjectUndo(text, count.ToString());
        //GUI.TextField(new Rect(500, 1000, 100, 100),text);
        //Font font = Resources.Load<Font>("Fonts/07Gosic-Bold");
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
