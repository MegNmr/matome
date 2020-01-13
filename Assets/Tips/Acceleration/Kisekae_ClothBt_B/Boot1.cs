using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boot1 : MonoBehaviour
{
    GameObject TopTab;
    Boot2 top2;
    Boot3 top3;
   

    public bool OnOff1;
    
    // Start is called before the first frame update
    void Start()
    {
        TopTab = GameObject.Find("Canvas/Leg_tab");
        top2 = TopTab.GetComponent<Boot2>();
        top3 = TopTab.GetComponent<Boot3>();
        

        OnOff1 = false;
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

        top2._switch(false);
        top3._switch(false);
       

        if (OnOff1 == true)
        {
            OnOff1 = false;
          

        }
        else if (OnOff1 == false)
        {
            
            OnOff1 = true;
        }
    }

    public bool _OnOff()
    {
        return OnOff1;
    }

    public void _switch(bool switcher)
    {
        OnOff1 = switcher;
    }
}
