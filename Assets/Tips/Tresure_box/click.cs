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
            
                anim.Play();
                particle.Play();
               // Debug.Log("onaka suita!");
                



        }
        }
    }