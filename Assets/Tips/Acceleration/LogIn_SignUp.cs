using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogIn_SignUp : MonoBehaviour
{
    private GameObject OYA;
    private GameObject guiTextLogIn;   // ログインテキスト
    private GameObject guiTextSignUp;  // 新規登録テキスト
    private GameObject FALSE_OBJ_LOGIN;
    private GameObject FALSE_OBJ_SignUp;

    int flag = 0;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<UserAuth>().logOut();

        // ゲームオブジェクトを検索し取得する
        OYA = GameObject.Find("GUI");
        guiTextLogIn = OYA.transform.Find("GUITextLogIn").gameObject;
        guiTextSignUp = OYA.transform.Find("GUITextSignUp").gameObject;
        FALSE_OBJ_LOGIN = OYA.transform.Find("GUITextLogIn/FALSE_OBJ_LOGIN").gameObject;
        FALSE_OBJ_SignUp = OYA.transform.Find("GUITextSignUp/FALSE_OBJ_SignUp").gameObject;

        FALSE_OBJ_LOGIN.SetActive(false);
        FALSE_OBJ_SignUp.SetActive(false);



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
        guiTextSignUp.SetActive(true);
        guiTextLogIn.SetActive(false);
        FALSE_OBJ_LOGIN.SetActive(false);
        FALSE_OBJ_SignUp.SetActive(false);

        //Debug.Log("押された!");  // ログを出力
    }

    // 戻るボタンが押されたら
    public void OnClick_Back()
    {

        guiTextSignUp.SetActive(false);
        guiTextLogIn.SetActive(true);
        FALSE_OBJ_LOGIN.SetActive(false);
        FALSE_OBJ_SignUp.SetActive(false);
    }


}
