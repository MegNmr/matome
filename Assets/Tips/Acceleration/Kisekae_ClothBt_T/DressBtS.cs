using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DressBtS : MonoBehaviour
{
    GameObject TopTab;
    
    Pants1 top1;
    Pants2 top2;
    Pants3 top3;
    Pants4 top4;

    GameObject image_object = null;
    GameObject image_object2 = null;
    GameObject image_object3 = null;
    GameObject image_object4 = null;

    private bool _OnOff1 = false;
    private bool _OnOff2 = false;
    private bool _OnOff3 = false;
    private bool _OnOff4 = false;

    public int aa = 6;

    // Start is called before the first frame update
    void Start()
    {
        
        TopTab = GameObject.Find("Canvas/Pants_tab");
        top1 = TopTab.GetComponent<Pants1>();
        top2 = TopTab.GetComponent<Pants2>();
        top3 = TopTab.GetComponent<Pants3>();
        top4 = TopTab.GetComponent<Pants4>();

        image_object = GameObject.Find("inter_S1");
        image_object.SetActive(false);
        image_object2 = GameObject.Find("inter_S2");
        image_object2.SetActive(false);
        image_object3 = GameObject.Find("inter_S3");
        image_object3.SetActive(false);
        image_object4 = GameObject.Find("inter_S4");
        image_object4.SetActive(false);

        //  Debug.Log(image_object2);

    }
    

    // Update is called once per frame
    void Update()
    {
        _OnOff1 = top1._OnOff();
        _OnOff2 = top2._OnOff();
        _OnOff3 = top3._OnOff();
        _OnOff4 = top4._OnOff();

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


        if (_OnOff4 == true)
        {
            image_object4.SetActive(true);
        }
        else if (_OnOff4 == false)
        {
            image_object4.SetActive(false);
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
