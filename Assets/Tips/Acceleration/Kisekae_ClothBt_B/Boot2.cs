using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boot2 : MonoBehaviour
{
    GameObject TopTab;
    Boot1 top1;
    Boot3 top3;
   

    public bool OnOff2 = false;

    // Start is called before the first frame update
    void Start()
    {
        TopTab = GameObject.Find("Canvas/Leg_tab");
        top1 = TopTab.GetComponent<Boot1>();
        top3 = TopTab.GetComponent<Boot3>();
       

        OnOff2 = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        ////Debug.Log(top1._OnOff());
        //if (top1._OnOff() == true)
        //{
        //    OnOff2 = false;
        //}

    }

    public void ClickThisButton()
    {
        top1._switch(false);
        top3._switch(false);
       

        if (OnOff2 == true)
        {
            
            OnOff2 = false;
            

        }
        else if (OnOff2 == false)
        {
            OnOff2 = true;
        }
    }

    public bool _OnOff()
    {
        return OnOff2;
    }

    public void _switch(bool switcher)
    {
        OnOff2 = switcher;
    }

}
