using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class result : MonoBehaviour
{
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = this.GetComponent<Image>();
        image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        string itemName = test1.getitemName();
        Sprite sprite = Resources.Load<Sprite>(itemName);

        image.sprite = sprite;
        image.enabled = true;



    }
}
