using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    //// ボタンが押された場合、今回呼び出される関数
    //public void OnClick()
    //{
    //    Debug.Log("押された!");  // ログを出力
    //    SceneManager.LoadScene("TestAcceleration");
    //}

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //if (OnClick())
        //{
        //    SceneManager.LoadScene("main_scene");
        //}
    }

    public void OnClick()
    {
        Debug.Log("押された!");  // ログを出力
        SceneManager.LoadScene("TestAcceleration");
    }

}