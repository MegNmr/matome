using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

public class tresure_box_open : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("Touch");

   }
}
*/

public class click : MonoBehaviour
{
    Animation anim;
    ParticleSystem particle;
    //public GameObject particle;//Particleを宣言

    bool flag = false;
    // Use this for initialization
    void Start()
        {
            anim = this.gameObject.GetComponent<Animation>();
            particle = this.gameObject.GetComponent<ParticleSystem>();


    }

        // Update is called once per frame
        void Update()
        {

        if (Input.GetMouseButtonDown(0))
        {
            if (flag == false)
            {
                anim.Play();
                particle.Play();
                // Debug.Log("onaka suita!");
            }

            flag = true;
        }


        
        }
    }