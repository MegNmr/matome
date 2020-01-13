﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MokuhyoWeight : MonoBehaviour
{
    private GameObject height;
    private Text inputField;
    private static int value;


    /// <summary>
    /// Startメソッド
    /// InputFieldコンポーネントの取得および初期化メソッドの実行
    /// </summary>
    void Start()
    {
        height = GameObject.Find("Canvas/MokuhyoWeight");
        inputField = height.transform.Find("Text").GetComponent<Text>();
        value = 0;
        Debug.Log("value = " + value);

        //InitInputField();
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
            value = int.Parse(inputValue);

            Debug.Log("value = " + value);

            // InitInputField();


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


    public void InitInputField()
    {

        // 値をリセット
        inputField.text = value.ToString();

        // フォーカス
        // inputField.ActivateInputField();
    }

    public int returnValue()
    {
        return value;
    }
}
