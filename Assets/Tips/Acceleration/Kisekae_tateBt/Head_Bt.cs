using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Head_Bt : MonoBehaviour
{
    private bool OnOff;
    private bool flag;

    // Start is called before the first frame update
    void Start()
    {
        OnOff = false;
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnSwitch()
    {
        if (OnOff == true)
        {
            OnOff = false;
        }
        else if (OnOff == false)
        {
            OnOff = true;
            flag = true;
        }
    }

    public bool _OnOff()
    {
        return OnOff;
    }
    public bool returnFlag()
    {
        return flag;
    }

    public void _swtich(bool switcher)
    {
        OnOff = switcher;
    }
    public void _switchFlag(bool _flag)
    {
        flag = _flag;
    }
}


