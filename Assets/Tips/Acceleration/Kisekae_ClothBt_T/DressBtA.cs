using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DressBtA : MonoBehaviour
{
    GameObject TopTab;

    Acce1 top1;
    Acce2 top2;
    Acce3 top3;

    GameObject image_object = null;
    GameObject image_object2 = null;
    GameObject image_object3 = null;

    private bool _OnOff1 = false;
    private bool _OnOff2 = false;
    private bool _OnOff3 = false;


    public int aa = 6;

    // Start is called before the first frame update
    void Start()
    {

        TopTab = GameObject.Find("Canvas/Accessory_tab");
        top1 = TopTab.GetComponent<Acce1>();
        top2 = TopTab.GetComponent<Acce2>();
        top3 = TopTab.GetComponent<Acce3>();

        image_object = GameObject.Find("inter_R1");
        image_object.SetActive(false);
        image_object2 = GameObject.Find("inter_R2");
        image_object2.SetActive(false);
        image_object3 = GameObject.Find("inter_R3");
        image_object3.SetActive(false);


        //  Debug.Log(image_object2);

    }


    // Update is called once per frame
    void Update()
    {
        _OnOff1 = top1._OnOff();
        _OnOff2 = top2._OnOff();
        _OnOff3 = top3._OnOff();

        //Debug.Log(_OnOff1);
        //Debug.Log(_OnOff2);

        if (_OnOff1 == true)
        {
            image_object.SetActive(true);
        }
        else if (_OnOff1 == false)
        {
            image_object.SetActive(false);
        }

        if (_OnOff2 == true)
        {
            image_object2.SetActive(true);
        }
        else if (_OnOff2 == false)
        {
            image_object2.SetActive(false);
        }

        if (_OnOff3 == true)
        {
            image_object3.SetActive(true);
        }
        else if (_OnOff3 == false)
        {
            image_object3.SetActive(false);
        }



    }
}
//    public void ClickThisButton()
//    {
//        if (OnOff == true)
//        {
//            image_object.SetActive(true);
//            image_object2.SetActive(false);
//            OnOff = false;
//        }
//        else if (OnOff == false)
//        {
//            image_object.SetActive(false);
//            OnOff = true;
//        }
//    }

//    public bool _OnOff()
//    {
//        return OnOff;
//    }
//}
