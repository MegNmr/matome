﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using NCMB;
using System;


public class MWeight_Button : MonoBehaviour
{

    // 入力されたテキストへの参照保存用


    // NCMBを利用するためのクラス
    private NCMBObject _testClass;
    private NCMBQuery<NCMBObject> _query;
    private NCMBObject deleteClass;

    GameObject okButton;
    GameObject weightGO;

    OKButton script;
    MokuhyoWeight weightScript;

    private static int value;

    private int number;
    private string selfID;
    private int weightValue;

    void Start()

    {
        selfID = UserAuth.returnSelfId();
        //Debug.Log("button naka " + selfID);

        okButton = GameObject.Find("Canvas/Mweight_Button");
        script = okButton.GetComponent<OKButton>();

        weightGO = GameObject.Find("Canvas/MokuhyoWeight");
        weightScript = weightGO.GetComponent<MokuhyoWeight>();
        Debug.Log("selfID: " + selfID);


    }

    void Update()
    {
        if(script._OnOff() == true)
        {

            weightValue = weightScript.returnValue();
            _saveData(weightValue);
            script._swtich(false);

        }
    }

    public void _saveData(int weight)
    {
        NCMBObject _query = new NCMBObject("personalData");
        NCMBQuery<NCMBObject> _list = new NCMBQuery<NCMBObject>("personalData");

        _list.WhereEqualTo("ID", selfID);

        _list.FindAsync((List<NCMBObject> objList, NCMBException e) =>
        {
            if (e == null)
            {
                if (objList.Count == 0)
                {
                    //存在しない
                    // Debug.Log("Obj is not found");
                }
                else
                {
                    objList[0]["mokuhyoWeight"] = weightValue;
                    objList[0].SaveAsync();
                }

            }
            else
            {

            }

        });
    }


}
