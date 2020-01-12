using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using NCMB;
using System.Linq;

public class first_pop : MonoBehaviour
{
    private int DP;
    private string id;
    GameObject mawasu = null;

    [SerializeField] GameObject pop;
    [SerializeField] GameObject _object;


    // Start is called before the first frame update
    void Start()
    {

        //DP = Acceleration.getDP();
        mawasu = GameObject.Find("Canvas/pop/to_gacha");
        pop.SetActive(false);
        mawasu.SetActive(false);
        id = LogInManager.getid();


        NCMBQuery<NCMBObject> query1 = new NCMBQuery<NCMBObject>(id + "currentDP");
        //Scoreの値が7と一致するオブジェクト検索
        query1.WhereEqualTo("id", 1);
        query1.FindAsync((List<NCMBObject> objList, NCMBException P) =>
        {
            if (P != null)
            {
            }
            else
            {
                foreach (NCMBObject obj in objList)
                {
                    DP = int.Parse(obj["message"].ToString());
                }
            }
        });
    }
        


    // Update is called once per frame
    void Update()
    {
        Text _text = _object.GetComponent<Text>();
        if (DP < 10)
        {
            
            _text.text = "DPが不足しています！";

        }
        else
        {
            mawasu.SetActive(true);

            _text.text = "ガチャを1回まわしますか？\n現在のDP: " + DP + "\nガチャ後のDP: " + (DP - 10);
        }
    }

    public void OnRetry()
    {
        pop.SetActive(true);
        
    }
}
