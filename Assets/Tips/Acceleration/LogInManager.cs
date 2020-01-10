using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private GameObject playertext;   //プレイヤーテキスト取得

    private string temp;        //入力されたテキストを一時保管

    InputField inputField;


    void Start()
    {

        FindObjectOfType<UserAuth>().logOut();

      

       
    }


    public void TextReflect_ID()
    {
        inputfield = GameObject.Find("InputField_ID");
        inputtext = GameObject.Find("InputField_ID/Text");
        playertext = GameObject.Find("InputField_ID/Placeholder");

        temp = inputtext.GetComponent<Text>().text;
        playertext.GetComponent<Text>().text = temp;
        id = playertext.GetComponent<Text>().text;
        Debug.Log(id);
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
        inputfield = GameObject.Find("InputField_MAIL");
        inputtext = GameObject.Find("InputField_MAIL/Text");
        playertext = GameObject.Find("InputField_MAIL/Placeholder");

        temp = inputtext.GetComponent<Text>().text;
        playertext.GetComponent<Text>().text = temp;
        mail = playertext.GetComponent<Text>().text;
        //  inputfield.SetActive(false);
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

        // currentPlayerを毎フレーム監視し、ログインが完了したら
        if (FindObjectOfType<UserAuth>().currentPlayer() != null)
        {
            Debug.Log("scene切替");
            Application.LoadLevel("TestAcceleration");
        }



        //Application.LoadLevel("TestAcceleration");
    }

    // 新規登録ボタンが押されたら
    public void OnClick_SignUp()
    {
        FindObjectOfType<UserAuth>().signUp(id, mail, pw);

        // currentPlayerを毎フレーム監視し、ログインが完了したら
        if (FindObjectOfType<UserAuth>().currentPlayer() != null)
        {
            Debug.Log("scene切替");
            Application.LoadLevel("TestAcceleration");
        }



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