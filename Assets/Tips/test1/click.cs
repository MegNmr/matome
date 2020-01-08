using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class tresure_box_open : MonoBehaviour
{
    void OnMouseDown()
    {
      //  Debug.Log("Onakasuita!");
        this.gameObject.transform.Rotate(0, 180, 0);
      //  Instantiate(particle, transform.position, transform.rotation);

    }
}

/*
public class tresure_box_open : MonoBehaviour
{
        Animation anim;

        // Use this for initialization
        void Start()
        {
            anim = this.gameObject.GetComponent<Animation>();


        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetMouseButtonDown(0))
            {

                anim.Play();



            }


        }
    }
 */