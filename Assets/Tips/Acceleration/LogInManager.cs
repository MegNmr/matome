using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using NCMB;
using System;


public class LogInManager : MonoBehaviour
{

    private GameObject guiTextLogIn;   // ログインテキスト
    private GameObject guiTextSignUp;  // 新規登録テキスト

    // ログイン画面のときtrue, 新規登録画面のときfalse
    // private bool isLogIn;

    // ボタンが押されると対応する変数がtrueになる
    private bool logInButton;
    private bool signUpMenuButton;
    private bool signUpButton;
    private bool backButton;

    // テキストボックスで入力される文字列を格納
    static string id;
    static string pw;
    static string mail;

    private GameObject inputfield;   //InputField取得
    private GameObject inputtext;    //InputFieldのテキスト取得
    private GameObject playertext;  //プレイヤーテキスト取得
    private GameObject OYA;
    private GameObject FALSE_OBJ_LOGIN;
    private GameObject FALSE_OBJ_SignUp;
    static int number;
    static string selfID;




    private string temp;        //入力されたテキストを一時保管

    int flage = 3;
    InputField inputField;
    

    void Start()
    {

        // ゲームオブジェクトを検索し取得する
        OYA = GameObject.Find("GUI");
        FALSE_OBJ_LOGIN = OYA.transform.Find("GUITextLogIn/FALSE_OBJ_LOGIN").gameObject;
        FALSE_OBJ_SignUp = OYA.transform.Find("GUITextSignUp/FALSE_OBJ_SignUp").gameObject;

        FALSE_OBJ_LOGIN.SetActive(false);
        FALSE_OBJ_SignUp.SetActive(false);


    }

    void Update()
    {
        
        if (FindObjectOfType<UserAuth>().currentPlayer() != null)
        {
             Application.LoadLevel("TestAcceleration");
        }
        /*
        else if (flage == 0)
        {
            FALSE_OBJ_LOGIN.SetActive(true);
            FALSE_OBJ_SignUp.SetActive(false);
            flage = 3;

        }
        else if(flage == 1) {


            FALSE_OBJ_LOGIN.SetActive(false);
            FALSE_OBJ_SignUp.SetActive(true);
            flage = 3;
           
        }*/
        


    }

  

    public void TextReflect_ID()
    {
        inputField = GetComponent<InputField>();
        string inputValue = inputField.text;

        Debug.Log(inputValue);
        id = inputValue;
        // ログを出力
        // inputfield.SetActive(false);
    }

    public void TextReflect_PASS()
    {
        inputfield = GameObject.Find("InputField_PASS");
        inputtext = GameObject.Find("InputField_PASS/Text");
        playertext = GameObject.Find("InputField_PASS/Placeholder");

        temp = inputtext.GetComponent<Text>().text;
        playertext.GetComponent<Text>().text = temp;
        pw = playertext.GetComponent<Text>().text;
        Debug.Log(pw);
        // inputfield.SetActive(false);
    }

    public void TextReflect_MAIL()
    {

        inputField = GetComponent<InputField>();
        string inputValue = inputField.text;

        Debug.Log(inputValue);
        mail = inputValue;

    }

    public void InputLogger()
    {
        inputField = GetComponent<InputField>();
        string inputValue = inputField.text;

        Debug.Log(inputValue);
        pw = inputValue;


    }

    
    // ログインボタンが押されたら
    public void OnClick_login()
    {
       
        FindObjectOfType<UserAuth>().logIn(id, pw); // ログを出力
       
            flage = 0;



        // currentPlayerを毎フレーム監視し、ログインが完了したら

       



        //Application.LoadLevel("TestAcceleration");
    }

    // 新規登録ボタンが押されたら
    public void OnClick_SignUp()
    {
        Debug.Log(id);
        Debug.Log(mail);
        Debug.Log(pw);
        FindObjectOfType<UserAuth>().signUp(id, mail, pw);


        // currentPlayerを毎フレーム監視し、ログインが完了したら

        flage = 1;


        NCMBObject _query = new NCMBObject("personalData");
        _query["Number"] = number;
        _query["ID"] = id;
        _query["Higher"] = 0;
        _query["Weight"] = 0;
        _query["mokuhyoWight"] = 0;
        _query["mokuhyoWalk"] = 0;
        //_query["Head"] = 0;
        _query["Top"] = "Image_toumei";
        _query["Pants"] = "Image_toumei";
        _query["Leg"] = "Image_toumei";
        _query["Acce"] = "Image_toumei";

        _query.SaveAsync((NCMBException c) => {
            if (c != null)
            {
                //エラー処理
                Debug.Log("error");
            }
            else
            {
                selfID = _query.ObjectId;
                _query.SaveAsync((NCMBException e) => {
                    if (c != null)
                    {
                        //エラー処理
                        Debug.Log("error");
                    }
                    else
                    {
                        _query["SelfID"] = selfID;
                        //成功時の処理

                    }
                });
                //成功時の処理

            }
        });

        number += 1;





    }

    public static string getid()
    {
        return id;
    }

    /// <summary>
    /// Log出力用メソッド
    /// 入力値を取得してLogに出力し、初期化
    /// </summary>






    /// <summary>
    /// InputFieldの初期化用メソッド
    /// 入力値をリセットして、フィールドにフォーカスする
    /// </summary>






    /*
    void OnGUI()
    {

        // ログイン画面 
        if (isLogIn)
        {

            drawLogInMenu();

            // ログインボタンが押されたら
            if (logInButton)
                FindObjectOfType<UserAuth>().logIn(id, pw);

            // 新規登録画面に移動するボタンが押されたら
            if (signUpMenuButton)
                isLogIn = false;
        }

        // 新規登録画面
        else
        {

            drawSignUpMenu();

            // 新規登録ボタンが押されたら
            if (signUpButton)
                FindObjectOfType<UserAuth>().signUp(id, mail, pw);

            // 戻るボタンが押されたら
            if (backButton)
                isLogIn = true;
        }

        // currentPlayerを毎フレーム監視し、ログインが完了したら
        if (FindObjectOfType<UserAuth>().currentPlayer() != null)
            Application.LoadLevel("TestAcceleration");

    }*/

    /*
private void drawLogInMenu()
{
    // テキスト切り替え
    guiTextSignUp.SetActive(false);
    guiTextLogIn.SetActive(true);

    // テキストボックスの設置と入力値の取得
    GUI.skin.textField.fontSize = 20;
    int txtW = 150, txtH = 40;

    id = GUI.TextField(new Rect(Screen.width * 1 / 2, Screen.height * 1 / 3 - txtH * 1 / 2, txtW, txtH), id);
    pw = GUI.PasswordField(new Rect(Screen.width * 1 / 2, Screen.height * 1 / 2 - txtH * 1 / 2, txtW, txtH), pw, '*');

    // ボタンの設置
    int btnW = 180, btnH = 50;
    GUI.skin.button.fontSize = 20;
    logInButton = GUI.Button(new Rect(Screen.width * 1 / 4 - btnW * 1 / 2, Screen.height * 3 / 4 - btnH * 1 / 2, btnW, btnH), "Log In");
    signUpMenuButton = GUI.Button(new Rect(Screen.width * 3 / 4 - btnW * 1 / 2, Screen.height * 3 / 4 - btnH * 1 / 2, btnW, btnH), "Sign Up");

}
*/

    //
    /*
        private void drawSignUpMenu()
        {
            // テキスト切り替え
            guiTextLogIn.SetActive(false);
            guiTextSignUp.SetActive(true);


            // テキストボックスの設置と入力値の取得
            int txtW = 150, txtH = 35;
            GUI.skin.textField.fontSize = 20;
            id = GUI.TextField(new Rect(Screen.width * 1 / 2, Screen.height * 1 / 4 - txtH * 1 / 2, txtW, txtH), id);
            pw = GUI.PasswordField(new Rect(Screen.width * 1 / 2, Screen.height * 2 / 5 - txtH * 1 / 2, txtW, txtH), pw, '*');
            mail = GUI.TextField(new Rect(Screen.width * 1 / 2, Screen.height * 11 / 20 - txtH * 1 / 2, txtW, txtH), mail);

            // ボタンの設置
            int btnW = 180, btnH = 50;
            GUI.skin.button.fontSize = 20;
            signUpButton = GUI.Button(new Rect(Screen.width * 1 / 4 - btnW * 1 / 2, Screen.height * 3 / 4 - btnH * 1 / 2, btnW, btnH), "Sign Up");
            backButton = GUI.Button(new Rect(Screen.width * 3 / 4 - btnW * 1 / 2, Screen.height * 3 / 4 - btnH * 1 / 2, btnW, btnH), "Back");
        }
        */



}