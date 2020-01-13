using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using NCMB;
using System;

public class HigherButton : MonoBehaviour
{
    // 入力されたテキストへの参照保存用


    // NCMBを利用するためのクラス
    private NCMBObject _testClass;
    private NCMBQuery<NCMBObject> _query;
    private NCMBObject deleteClass;

    GameObject okButton;
    GameObject higherGO;

    OKButton script;
    HigherField higherScript;

    private static int value;

    private int number;
    private string selfID;
    private int higherValue;

    void Start()

    {
        selfID = UserAuth.returnSelfId();
        //Debug.Log("button naka " + selfID);

        okButton = GameObject.Find("Canvas/Higher_Button");
        script = okButton.GetComponent<OKButton>();

        higherGO = GameObject.Find("Canvas/_Higher");
        higherScript = higherGO.GetComponent<HigherField>();


    }

    void Update()
    {
        if (script._OnOff() == true)
        {
            higherValue = higherScript.returnValue();
            _saveData(higherValue);
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
                    Debug.Log("Obj is not found");
                }
                else
                {
                    objList[0]["Higher"] = higherValue;
                    objList[0].SaveAsync();
                }

            }
            else
            {

            }

        });
    }


}
