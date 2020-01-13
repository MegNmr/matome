//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.Linq;
//using UnityEngine.UI;
//using NCMB;
//using System;

//public class mokuhyoWeight : MonoBehaviour
//{
//    private NCMBObject _testClass;
//    private NCMBQuery<NCMBObject> _query;
//    private NCMBObject deleteClass;

//    GameObject okButton;
//    GameObject mokuhyoWeightGO;

//    OKButton script;
//    field mokuhyoWeightScript;

//    private static int value;

//    private int number;
//    private string selfID;
//    private int mokuhyoWeightValue;

//    void Start()

//    {
//        selfID = UserAuth.returnSelfId();
//        //Debug.Log("button naka " + selfID);

//        okButton = GameObject.Find("Canvas/mokuhyoWeight_Button");
//        script = okButton.GetComponent<OKButton>();

//        mokuhyoWeightGO = GameObject.Find("Canvas/_mokuhyoWeight");
//        mokuhyoWeightScript = mokuhyoWeightGO.GetComponent<field>();


//    }

//    void Update()
//    {
//        if (script._OnOff() == true)
//        {
//            mokuhyoWeightValue = mokuhyoWeightScript.returnValue();
//            _saveData(mokuhyoWeightValue);
//            script._swtich(false);

//        }
//    }

//    public void _saveData(int weight)
//    {
//        NCMBObject _query = new NCMBObject("personalData");
//        NCMBQuery<NCMBObject> _list = new NCMBQuery<NCMBObject>("personalData");

//        _list.WhereEqualTo("ID", selfID);

//        _list.FindAsync((List<NCMBObject> objList, NCMBException e) =>
//        {
//            if (e == null)
//            {
//                if (objList.Count == 0)
//                {
//                    //存在しない
//                    Debug.Log("Obj is not found");
//                }
//                else
//                {
//                    objList[0]["MokuhyoWeight"] = mokuhyoWeightValue;
//                    objList[0].SaveAsync();
//                }

//            }
//            else
//            {

//            }

//        });
//    }
//}
