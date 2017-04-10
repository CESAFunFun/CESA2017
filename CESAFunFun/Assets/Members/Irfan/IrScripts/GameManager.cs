using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject goalText;
    [SerializeField]
    private GameObject pressMachine;
    [SerializeField]
    private GoalScript goalArea;

    [SerializeField]
    private GameObject playerParentTop;

    [SerializeField]
    private GameObject playerParentBottom;

    [SerializeField]
    private PlayerController Press1;
    [SerializeField]
    private PlayerController Press2;

    private ChildManager childManager;
    private PressMachine machineTop;
    private PressMachine machineBottom;

    public static GameManager _instance = null;
    
    private GameObject[] childrenTop;

    private GameObject[] childrenBottom;

    void Awake()
    {
        if (!_instance)
            _instance = this;
        else if (_instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        //playerParentTop = GetComponent<RigidbodyCharacter>();
        //playerParentBottom.GetComponent<RigidbodyCharacter>();
        //goalArea.GetComponent<GoalScript>();
        childManager = GetComponent<ChildManager>();

        machineTop = pressMachine.transform.GetChild(0).GetComponent<PressMachine>();
        machineBottom = pressMachine.transform.GetChild(1).GetComponent<PressMachine>();

    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {

            machineTop._actived = true;
            machineBottom._actived = true;
        }      
        

        CreateChild();

        ShowGoal();

        ChildTargetUpdate();

        if (Press1._isPress && Press2._isPress)
        {
            machineTop._actived = true;
            machineBottom._actived = true;
        }
    }

    void ShowGoal()
    {
        /*
        if (goalArea._isGoal)
            goalText.SetActive(true);
        else
            goalText.SetActive(false);
        */
    }
    
    void CreateChild()
    {

        // 　4/7
        //   藤井　修正
        //   状態  ちょっと鼻がムズムズする時

        //プレス機と当たったら子供を生成
        if (machineTop._playerHit)
        {
            childrenTop = childManager.CreateChild(playerParentTop, new Vector3(-4, 2, 0));
            //プレイヤーとのあたり判定無視
            playerParentTop.GetComponent<RigidbodyCharacter>().IgnoreCharacter("Child", true);
            //追従オブジェクトの変更
            childManager.ChangeTrackCharacter(childrenTop, playerParentTop);
            machineTop._playerHit = false;
        }

        //プレス機と当たったら子供を生成
        if (machineBottom._playerHit)
        {
            childrenBottom = childManager.CreateChild(playerParentBottom, new Vector3(-4, -2, 0));
            //プレイヤーとのあたり判定無視
            playerParentBottom.GetComponent<RigidbodyCharacter>().IgnoreCharacter("Child", true);
            //追従オブジェクトの変更
            childManager.ChangeTrackCharacter(childrenBottom, playerParentBottom);
            machineBottom._playerHit = false;
        }
        
    }
    //子供がオブジェクト化しているか
    bool IsChild(GameObject[] child)
    {
        if (child != null)
        {
            for (int i = 0; i < child.Length; i++)
            {
                if (child[i].GetComponent<RigidbodyCharacter>()._objected)
                    return false;
            }
        }
        return true;
    }

    //ターゲットを更新する
    void ChildTargetUpdate()
    {
        //オブジェクト化している子供がいればターゲット変更
        if (!IsChild(childrenTop))
            childManager.ChangeTrackCharacter(childrenTop, playerParentTop);

        if (!IsChild(childrenBottom))
            childManager.ChangeTrackCharacter(childrenBottom, playerParentBottom);

    }

    private void ResetPlayer(GameObject player)
    {
        player.SetActive(false);
    }

    private void DeadChild(GameObject child)
    {
        Destroy(child);
    }
}
