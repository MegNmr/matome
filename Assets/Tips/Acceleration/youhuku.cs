using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;

public class youhuku : MonoBehaviour
{
    private GameObject Image;
    private GameObject Acce;   // ログインテキスト
    private GameObject Leg;  // 新規登録テキスト
    private GameObject Pants;
    private GameObject Top;
    
    
    private string id = LogInManager.getid();


    // アイテムのデータを保持する辞書
    public static Dictionary<int, string> itemInfo;
    public static Dictionary<int, string> itemTest;
    public static Dictionary<int, int> itemData;

    public static int itemId;
    public static string itemName;
    float time = 0f;
    static int second = 0;
    string selfID;


    int ARUKA;
    // Start is called before the first frame update
    void Start()
    {
        selfID = UserAuth.returnSelfId();
        getHuku();

    }

    void Update()
    {
        //time count
        time += Time.deltaTime;//毎フレームの時間を加算.
        int minute = (int)time / 60;//分.timeを60で割った値.
        second = (int)time % 60;//秒.timeを60で割った余り.

        if (second == 1)
        {

            getHuku();
            Debug.Log("こんちわー");

        }
    }

    

    public void getHuku()
    {
        string selfID = UserAuth.returnSelfId();
        string top = null;
        string pants = null;
        string leg = null;
        string acce = null;
        int _mokuhyoInt = 0;
        NCMBObject _query = new NCMBObject("personalData");
        NCMBQuery<NCMBObject> _list = new NCMBQuery<NCMBObject>("personalData");
        _query = new NCMBObject("personalData");
        _list = new NCMBQuery<NCMBObject>("personalData");
        _list.WhereEqualTo("ID", selfID);

        Debug.Log(UserAuth.returnSelfId() + "あるよおおおおおお");
        _list.FindAsync((List<NCMBObject> userList, NCMBException b) => {
            if (b != null)
            {
                UnityEngine.Debug.Log("失敗 : " + b.Message);
            }
            else
            {
                foreach (NCMBObject obj in userList)
                {
                    Debug.Log(obj["Top"]);
                    
                    _query = obj;
                    UnityEngine.Debug.Log("失敗 : " + b.Message);
                }
            }
        });

        Debug.Log(_query["Top"]+"あるよおおおおおお");

        Image = GameObject.Find("Image");
        
            // head = _query["Head"].ToString();
            top = _query["Top"].ToString();
            Top = Image.transform.Find(top).gameObject;
            Top.SetActive(true);


         // head = _query["Head"].ToString();
            pants = _query["Pants"].ToString();
            Pants = Image.transform.Find(pants).gameObject;
            Pants.SetActive(true);

        
            // head = _query["Head"].ToString();
            leg = _query["Leg"].ToString();
            Leg = Image.transform.Find(leg).gameObject;
            Leg.SetActive(true);
          

        
            // head = _query["Head"].ToString();
            acce = _query["Acce"].ToString();
            Acce = Image.transform.Find(acce).gameObject;
            Acce.SetActive(true);
            

        




       

        
        
       
       
        

        
       
      
       




    }


    
}
