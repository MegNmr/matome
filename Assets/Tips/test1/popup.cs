using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class popup : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject pop;

    void Start()
    {
        pop.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRetry()
    {
        // 「ButtonScene」を自分の読み込みたいscene名に変える
        pop.SetActive(true);
    }
}
