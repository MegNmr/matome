using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;

public class clothSave : MonoBehaviour
{
    Dictionary<int, bool> _listBool;
    Dictionary<int, string> _listItem;
    private string selfID;

    // Start is called before the first frame update
    void Start()
    {
        selfID = UserAuth.returnSelfId();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        _listBool = DressUpMnager.returnList();
        _listItem = DressUpMnager.returnListItem();

        //NCMBObject _query = new NCMBObject("personalData");
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
                    for (int i = 0; i < 3; i++)
                    {
                        if (_listBool[i] == true)
                        {
                            objList[0]["Pants"] = _listItem[i];
                        }

                    }
                    for (int i = 3; i < 6; i++)
                    {
                        if (_listBool[i] == true)
                        {
                            objList[0]["Top"] = _listItem[i];
                        }

                    }
                    for (int i = 6; i < 9; i++)
                    {
                        if (_listBool[i] == true)
                        {
                            objList[0]["Head"] = _listItem[i];
                        }

                    }
                    for (int i = 9; i < 12; i++)
                    {
                        if (_listBool[i] == true)
                        {
                            objList[0]["Leg"] = _listItem[i];
                        }

                    }
                    for (int i = 12; i < 15; i++)
                    {
                        if (_listBool[i] == true)
                        {
                            objList[0]["Acce"] = _listItem[i];
                        }

                    }

                    objList[0].SaveAsync();

                }

            }
            else
            {

            }

        });
    }

}

