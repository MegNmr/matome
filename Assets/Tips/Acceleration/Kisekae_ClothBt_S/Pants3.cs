using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pants3 : MonoBehaviour
{
    GameObject TopTab;
    Pants1 top1;
    Pants2 top2;
    Pants4 top4;

    public bool OnOff3;

    // Start is called before the first frame update
    void Start()
    {
        TopTab = GameObject.Find("Canvas/Pants_tab");
        top1 = TopTab.GetComponent<Pants1>();
        top2 = TopTab.GetComponent<Pants2>();
        top4 = TopTab.GetComponent<Pants4>();

        OnOff3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(top2._OnOff());

        //if (top2._OnOff() == true)
        //{
        //    OnOff1 = false;
        //    Debug.Log("okikae");
        //}

    }
    public void ClickThisButton()
    {

        top1._switch(false);
        top2._switch(false);
        top4._switch(false);

        if (OnOff3 == true)
        {
            OnOff3 = false;
           
        }
        else if (OnOff3 == false)
        {
           
            OnOff3 = true;
        }
    }

    public bool _OnOff()
    {
        return OnOff3;
    }

    public void _switch(bool switcher)
    {
        OnOff3 = switcher;
    }
}
