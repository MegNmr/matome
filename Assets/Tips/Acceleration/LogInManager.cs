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
    static int number;
    static string selfID;
    
    private GameObject inputfield;   //InputField取得
    private GameObject inputtext;    //InputFieldのテキスト取得
    private GameObject playertext;  //プレイヤーテキスト取得
    private GameObject OYA;
    private GameObject FALSE_OBJ_LOGIN;
    private GameObject FALSE_OBJ_SignUp;
    
    private string temp;


    //入力されたテキストを一時保管

    int flage = 3;
    InputField inputField;
    
    
    void Start()
    {
        
        // ゲームオブジェクトを検索し取得する
        OYA = GameObject.Find("GUI");
        
        number = 1;
        // FALSE_OBJ_LOGIN = OYA.transform.Find("GUITextLogIn/FALSE_OBJ_LOGIN").gameObject;
        //FALSE_OBJ_SignUp = OYA.transform.Find("GUITextSignUp/FALSE_OBJ_SignUp").gameObject;
        
        //FALSE_OBJ_LOGIN.SetActive(false);
        //FALSE_OBJ_SignUp.SetActive(false);
        
        
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
        //inputfield = GameObject.Find("InputField_ID");
        //inputtext = GameObject.Find("InputField_ID/Text");
        //playertext = GameObject.Find("InputField_ID/Placeholder");


        //temp = inputtext.GetComponent<Text>().text;
        //playertext.GetComponent<Text>().text = temp;
        //id = playertext.GetComponent<Text>().text;
        //Debug.Log(id);

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
        //inputfield = GameObject.Find("InputField_MAIL");
        //inputtext = GameObject.Find("InputField_MAIL/Text");
        //playertext = GameObject.Find("InputField_MAIL/Placeholder");

        //temp = inputtext.GetComponent<Text>().text;
        //playertext.GetComponent<Text>().text = temp;
        //mail = playertext.GetComponent<Text>().text;

        inputField = GetComponent<InputField>();
        string inputValue = inputField.text;

        Debug.Log(inputValue);
        mail = inputValue;
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
        
        flage = 0;
        
        // currentPlayerを毎フレーム監視し、ログインが完了したら
        

        //Application.LoadLevel("TestAcceleration");
    }
    
    // 新規登録ボタンが押されたら
    public void OnClick_SignUp()
    {
        Debug.Log("click ID = " + id);
        Debug.Log("click mail = " + mail);
        Debug.Log("click pw = " + pw);
        
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
    
    public static int getNumber()
    {
        return number;
    }
    
    //public static string getSelfID()
    //{
    //    return selfID;
    //}
}