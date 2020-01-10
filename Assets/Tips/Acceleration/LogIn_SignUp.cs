using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogIn_SignUp : MonoBehaviour
{
    private GameObject OYA;
    private GameObject guiTextLogIn;   // ログインテキスト
    private GameObject guiTextSignUp;  // 新規登録テキスト

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<UserAuth>().logOut();

        // ゲームオブジェクトを検索し取得する
        OYA = GameObject.Find("GUI");
        guiTextLogIn = OYA.transform.Find("GUITextLogIn").gameObject;
        guiTextSignUp = OYA.transform.Find("GUITextSignUp").gameObject;



        guiTextSignUp.SetActive(false);
        guiTextLogIn.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

    }

    // 新規登録画面に移動するボタンが押されたら
    public void OnClick_SignUpMenu()
    {
        guiTextLogIn.SetActive(false);
        guiTextSignUp.SetActive(true);

        Debug.Log("押された!");  // ログを出力
    }

    // 戻るボタンが押されたら
    public void OnClick_Back()
    {

        guiTextSignUp.SetActive(false);
        guiTextLogIn.SetActive(true);
    }


}
