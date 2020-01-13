using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using NCMB;
using System;


public class UserAuth : MonoBehaviour
{

    private static string currentPlayerName;
    private static string selfID;
    private static string selfPass;
    private static string selfMail;

    // mobile backendに接続してログイン ------------------------

    public void logIn(string id, string pw)
    {

        NCMBUser.LogInAsync(id, pw, (NCMBException e) => {
            // 接続成功したら
            if (e == null)
            {
                currentPlayerName = id;


                NCMBQuery<NCMBUser> query = NCMBUser.GetQuery();
                query.WhereEqualTo("userName", id);
                query.FindAsync((List<NCMBUser> userList, NCMBException b) => {
                    if (b != null)
                    {
                        UnityEngine.Debug.Log("失敗 : " + b.Message);
                    }
                    else
                    {
                       // Debug.Log("やったーーーー！");
                        foreach (NCMBUser user in userList)
                        {
                            //Debug.Log("やったーーーー！");
                            //UnityEngine.Debug.Log("ユーザー名: " + user.UserName);
                            selfID = user.ObjectId;
                            selfPass = pw;
                            selfMail = user.Email;
                            //Debug.Log("login " + selfID);
                        }
                    }
                });


            }

        });
    }

    // mobile backendに接続して新規会員登録 ------------------------

    public void signUp(string id, string mail, string pw)
    {

        NCMBUser user = new NCMBUser();
        user.UserName = id;
        user.Email = mail;
        user.Password = pw;
        user.SignUpAsync((NCMBException e) => {

            if (e == null)
            {
                currentPlayerName = id;
            }
            else
            {
                selfID = user.ObjectId;
                selfPass = pw;
                selfMail = mail;
            }
        });
    }

    // mobile backendに接続してログアウト ------------------------

    public void logOut()
    {

        NCMBUser.LogOutAsync((NCMBException e) => {
            if (e == null)
            {
                currentPlayerName = null;
            }
        });
    }

    // 現在のプレイヤー名を返す --------------------
    public string currentPlayer()
    {
        return currentPlayerName;
    }


    // シングルトン化する ------------------------

    private UserAuth instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            string name = gameObject.name;
            gameObject.name = name + "(Singleton)";

            GameObject duplicater = GameObject.Find(name);
            if (duplicater != null)
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.name = name;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static string returnSelfId()
    {
        return selfID;
    }

    public static string returnSelfPass()
    {
        return selfPass;
    }

    public static string returnSelfMail()
    {
        return selfMail;
    }

    public static void changePass(string newpass)
    {
        selfPass = newpass;
    }

    public static void changeMail(string newmail)
    {
        selfMail = newmail;
    }

    public static void logout()
    {

        NCMBUser.LogOutAsync((NCMBException e) => {
            if (e == null)
            {
                currentPlayerName = null;
            }
        });
    }
}