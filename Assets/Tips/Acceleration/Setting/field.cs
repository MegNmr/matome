using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class field : MonoBehaviour
{
    //private GameObject weight;
    private InputField inputField;
    private static string value;


    /// <summary>
    /// Startメソッド
    /// InputFieldコンポーネントの取得および初期化メソッドの実行
    /// </summary>
    void Start()
    {
        //weight = GameObject.Find("Canvas/_Weight");
        inputField = GetComponent<InputField>();
        value = "";

            InitInputField();
    }



    /// <summary>
    /// Log出力用メソッド
    /// 入力値を取得してLogに出力し、初期化
    /// </summary>


    public void InputLogger()
    {
        try
        {
            string inputValue = inputField.text;
            value = inputValue;

            Debug.Log("value = " + value);

            InitInputField();


        }
        catch
        {
            Debug.Log("error");
        }
    }



    /// <summary>
    /// InputFieldの初期化用メソッド
    /// 入力値をリセットして、フィールドにフォーカスする
    /// </summary>


    void InitInputField()
    {

        // 値をリセット
        inputField.text = value.ToString();

        // フォーカス
        //inputField.ActivateInputField();
    }

    public string returnValue()
    {
        return value;
    }

    public void reset()
    {
        inputField.text = "";
    }
}
