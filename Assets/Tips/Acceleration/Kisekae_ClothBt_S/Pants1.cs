using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pants1 : MonoBehaviour
{
    GameObject TopTab;
    Pants2 top2;
    Pants3 top3;
    Pants4 top4;


    public bool OnOff1;
    
    // Start is called before the first frame update
    void Start()
    {
        TopTab = GameObject.Find("Canvas/Pants_tab");
        top2 = TopTab.GetComponent<Pants2>();
        top3 = TopTab.GetComponent<Pants3>();
        top4 = TopTab.GetComponent<Pants4>();

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
        top4._switch(false);

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
