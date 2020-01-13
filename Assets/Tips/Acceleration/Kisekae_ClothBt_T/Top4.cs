using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Top4 : MonoBehaviour
{
    GameObject TopTab;
    Top1 top1;
    Top2 top2;
    Top3 top3;
    public bool OnOff4;

    // Start is called before the first frame update
    void Start()
    {
        TopTab = GameObject.Find("Canvas/Tops_tab");
        top1 = TopTab.GetComponent<Top1>();
        top2 = TopTab.GetComponent<Top2>();
        top3 = TopTab.GetComponent<Top3>();

        OnOff4 = false;
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
        top3._switch(false);

        if (OnOff4 == true)
        {
            OnOff4 = false;

        }
        else if (OnOff4 == false)
        {

            OnOff4 = true;
        }
    }

    public bool _OnOff()
    {
        return OnOff4;
    }

    public void _switch(bool switcher)
    {
        OnOff4 = switcher;
    }
}
