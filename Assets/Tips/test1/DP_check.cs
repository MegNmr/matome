using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;  // 追加しましょう

public class DP_check : MonoBehaviour
{


    public GameObject _object = null; // Textオブジェクト
    private int DP;
    // 初期化
    void Start()
    {
        DP = Acceleration.getDP();
    }

    // 更新
    void Update()
    {
        // オブジェクトからTextコンポーネントを取得
        Text _text = _object.GetComponent<Text>();
        // テキストの表示を入れ替える
        _text.text = "ガチャを1回まわしますか？\n現在のDP: " + DP + "\nガチャ後のDP: " + (DP - 10);
    }
}