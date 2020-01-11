using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Top1 : MonoBehaviour
{
    GameObject TopTab;
    Top2 top2;

    private bool OnOff1;
    
    // Start is called before the first frame update
    void Start()
    {
        TopTab = GameObject.Find("Canvas/Tops_tab");
        top2 = TopTab.GetComponent<Top2>();

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
        if (OnOff1 == true)
        {
            OnOff1 = false;
        }
        else if (OnOff1 == false)
        {
            if (top2._OnOff() == true)
            {
                top2._switch(false);
            }
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
