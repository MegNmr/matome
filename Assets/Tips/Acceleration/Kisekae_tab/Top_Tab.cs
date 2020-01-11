using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Top_Tab : MonoBehaviour
{
    private Animator animator;
    GameObject top;
    GameObject head;
    GameObject pants;
    GameObject leg;
    GameObject acce;

    GameObject tab;

    Top_Bt script;
    Top_Bt script2;
    Top_Bt script3;
    Top_Bt script4;
    Top_Bt script5;


    void Start()
    {
        tab = GameObject.Find("Canvas/Tops_tab/Image");
        animator = tab.GetComponent<Animator>();
        animator.enabled = false;

        top = GameObject.Find("Canvas/Body_Top_Bt");
        head = GameObject.Find("Canvas/Head_Bt");
        pants = GameObject.Find("Canvas/Body_Under_Bt");
        leg = GameObject.Find("Canvas/Leg_Bt");
        acce = GameObject.Find("Canvas/Accessory_Bt");


        script = top.GetComponent<Top_Bt>();
        script2 = head.GetComponent<Top_Bt>();
        script3 = pants.GetComponent<Top_Bt>();
        script4 = leg.GetComponent<Top_Bt>();
        script5 = acce.GetComponent<Top_Bt>();

    }

    void Update()
    {
        bool OnOff = script._OnOff();
        Debug.Log("Tops " + OnOff);

        if (script.returnFlag() == true)
        {
            if (script2._OnOff() == true || script3._OnOff() == true || script4._OnOff() == true || script5._OnOff() == true)
            {
                script2._swtich(false);
                script3._swtich(false);
                script4._swtich(false);
                script5._swtich(false);

            }

            if (OnOff == true)
            {
                Debug.Log("top script2 " + script2._OnOff());

                tab.SetActive(true);
                animator.enabled = true;
                animator.Play("aa");

            }

            script._switchFlag(false);

        }
        else if (script.returnFlag() == false)
        {
            if (OnOff == true)
            {
                Debug.Log("top script2 2 " + script2._OnOff());

                tab.SetActive(true);
                animator.enabled = true;
                animator.Play("aa");

            }
            else if (OnOff == false)
            {
                tab.SetActive(false);
                animator.enabled = false;

            }
        }

    }

}
