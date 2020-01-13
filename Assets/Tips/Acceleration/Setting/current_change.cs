using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;
using System.Linq;
using UnityEngine.SceneManagement;

public class current_change : MonoBehaviour
{


    [SerializeField] GameObject pop;
    //[SerializeField] GameObject pop2;


    private GameObject OYA;
    private GameObject pass = null;
    private GameObject ad = null;
    private GameObject logout = null;

    private GameObject walk_change;
    private GameObject height_change;
    private GameObject weight_change;

    private GameObject ATO_walk;
    private GameObject ATO_height;
    private GameObject ATO_weight;

    private GameObject nowpass;
    private InputField inputNowPass;
    private GameObject newpass;
    private InputField inputNewPass;
    private GameObject newpass2;
    private InputField inputNewPass2;

    private GameObject mailText;
    Text _text;

    string walkpoint = "0";
    string heightpoint = "10";
    string weightpoint = "50";
    string selfPass;
    string selfID;
    string selfMail;

    string inputpassNow;
    string inputpassNew;
    string inputpassNew2;

    private GameObject popp;
    private GameObject popp2;

    private static string currentPlayerName;

    // Start is called before the first frame update
    void Start()
    {
        selfPass = UserAuth.returnSelfPass();
        selfID = UserAuth.returnSelfId();
        selfMail = UserAuth.returnSelfMail();

        pop.SetActive(false);
        //pop2.SetActive(false);

        OYA = GameObject.Find("Panel");
        pass = OYA.transform.Find("pass_change").gameObject;
        ad = OYA.transform.Find("adress_change").gameObject;
        logout = OYA.transform.Find("logout_button").gameObject;

        popp = GameObject.Find("Canvas/Panel/SuccessPop");
        popp.SetActive(false);

        popp2 = GameObject.Find("Canvas/Panel/SuccessPop2");
        popp2.SetActive(false);

        mailText = GameObject.Find("Canvas/Panel/passchangePage/nowpass");
        _text = mailText.GetComponent<Text>();
        _text.text = selfMail;
        // Text walk_text = pass.GetComponent<Text>();
        // walk_text.text = "現在の目標歩数: " + walkpoint;


        //ATO_walk = OYA.transform.Find("walk").gameObject;
        //ATO_height = OYA.transform.Find("height").gameObject;
        //ATO_weight = OYA.transform.Find("weight").gameObject;

        //ATO_walk.SetActive(false);
        //ATO_height.SetActive(false);
        //ATO_weight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRetry()
    {

        switch (transform.name)
        {
            case "pass_change":
                pass.SetActive(false);
                ad.SetActive(false);
                logout.SetActive(false);

                pop.SetActive(true);

                //passchange();


                break;
            case "adress_change":
                pass.SetActive(false);
                ad.SetActive(false);
                logout.SetActive(false);

                pop.SetActive(true);

                break;
            case "logout_button":

                pop.SetActive(true);
                pop.SetActive(true);

                break;
            default:
                break;
        }
    }

    public void ToLogin()
    {
        NCMBUser.LogOutAsync((NCMBException e) => {
            if (e == null)
            {
                currentPlayerName = null;
                Debug.Log("logout seikou");
            }
        });
        SceneManager.LoadScene("LogIn");
        //Application.LoadLevel("LogIn");
    }

    public void ToSetting()
    {
        Application.LoadLevel("Setting");
    }

    public void passchange()
    {
        ////Debug.Log("やったー入った");
        //nowpass = OYA.transform.Find("passchangePage/InputField/now").gameObject;
        //newpass = OYA.transform.Find("passchangePage/InputField/new").gameObject;
        //newpass2 = OYA.transform.Find("passchangePage/InputField/new2").gameObject;

        //inputNowPass = nowpass.GetComponent<InputField>();
        //inputNewPass = newpass.GetComponent<InputField>();
        //inputNewPass2 = newpass2.GetComponent<InputField>();

        //inputpassNow = inputNowPass.text;
        //inputpassNew = inputNewPass.text;
        //inputpassNew2 = inputNewPass.text;

        //Debug.Log("selfPass " + selfPass);
        //Debug.Log("selfId " + selfID);
        //Debug.Log("inputpassNow " + inputpassNow);
        //Debug.Log("inputpassNew " + inputpassNew);
        //Debug.Log("inputpassNew2 " + inputpassNew2);




        //if (inputpassNow == selfPass)
        //{
        //    Debug.Log("やったー入った");

        //    if (inputpassNew == inputpassNew2)
        //    {
        //        Debug.Log("やったー入った2");

        //        NCMBQuery<NCMBUser> query = NCMBUser.GetQuery();
        //        query.WhereEqualTo("objectId", selfID);

        //        query.FindAsync((List<NCMBUser> userList, NCMBException b) =>
        //        {
        //            if (b != null)
        //            {
        //                UnityEngine.Debug.Log("失敗 : " + b.Message);
        //            }
        //            else
        //            {
        //                foreach (NCMBUser user in userList)
        //                {
        //                    Debug.Log("やったーーーー！");
        //                    user.Password = inputpassNew;
        //                    user.SignUpAsync((NCMBException e) => {

        //                        if (e == null)
        //                        {
        //                           // currentPlayerName = id;
        //                        }
        //                        else
        //                        {
        //                            selfID = user.ObjectId;
        //                            UserAuth.changePass(inputpassNew);
        //                        }
        //                    });
        //                }
        //            }
        //        });
        //    }
        //}
        //else
        //{

        //}

        NCMBUser.RequestPasswordResetAsync("okakakoubu102184@gmail.com", (NCMBException e) => {
            if (e != null)
            {
                UnityEngine.Debug.Log("パスワードリセット要求に失敗: " + e.ErrorMessage);
            }
            else
            {
                UnityEngine.Debug.Log("パスワードリセット要求に成功");
                popp.SetActive(true);
            }
        });

    }

    public void changemail()
    {
        //Debug.Log("やったー入った");
        nowpass = OYA.transform.Find("addresshangePage/InputField/now").gameObject;
        newpass = OYA.transform.Find("addresshangePage/InputField/new").gameObject;
        newpass2 = OYA.transform.Find("addresshangePage/InputField/new2").gameObject;

        inputNowPass = nowpass.GetComponent<InputField>();
        inputNewPass = newpass.GetComponent<InputField>();
        inputNewPass2 = newpass2.GetComponent<InputField>();

        field aaa = inputNowPass.GetComponent<field>();
        field bbb = inputNewPass.GetComponent<field>();
        field ccc = inputNewPass2.GetComponent<field>();

        inputpassNow = inputNowPass.text;
        inputpassNew = inputNewPass.text;
        inputpassNew2 = inputNewPass.text;

        Debug.Log("selfPass " + selfPass);
        Debug.Log("selfId " + selfID);
        Debug.Log("inputpassNow " + inputpassNow);
        Debug.Log("inputpassNew " + inputpassNew);
        Debug.Log("inputpassNew2 " + inputpassNew2);


        if (inputpassNow == selfMail)
        {
            //Debug.Log("やったー入った");

            if (inputpassNew == inputpassNew2)
            {
                //Debug.Log("やったー入った2");

                NCMBQuery<NCMBUser> query = NCMBUser.GetQuery();
                query.WhereEqualTo("objectId", selfID);

                query.FindAsync((List<NCMBUser> userList, NCMBException b) =>
                {
                    if (b != null)
                    {
                        UnityEngine.Debug.Log("失敗 : " + b.Message);
                    }
                    else
                    {
                        foreach (NCMBUser user in userList)
                        {
                            //Debug.Log("やったーーーー！");
                            user.Email = inputpassNew;
                            user.SignUpAsync((NCMBException e) => {

                                if (e == null)
                                {
                                    // currentPlayerName = id;

                                    aaa.reset();
                                    bbb.reset();
                                    ccc.reset();

                                    UserAuth.changeMail(inputpassNew);

                                    popp.SetActive(true);
                                }
                                else
                                {
                                    Debug.Log("error");
                                }
                            });
                        }
                    }
                });
            }
        }
        else
        {

        }



    }

}
