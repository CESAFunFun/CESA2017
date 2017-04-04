using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject[] playerChilds;
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

    private ChildManager childManager;
    private PressMachine machineTop;
    private PressMachine machineBottom;

    public static GameManager _instance = null;

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
    }

    void ShowGoal()
    {
        if (goalArea._isGoal)
            goalText.SetActive(true);
        else
            goalText.SetActive(false);
        
    }
    
    void CreateChild()
    {
        if (machineTop._playerHit)
        {
            machineTop._playerHit = false;
            childManager.CreateChild(playerChilds, new Vector3(playerChilds.Length - 1, 1, 0));
            //playerParentTop.Jump(playerParentTop._jumpPower);
            for (int i = 0; i < playerChilds.Length; i++)
            {
                if (i == 0)
                {
                    Debug.Log("aaa");
                    childManager.TrackCharacter(playerChilds[i], playerParentTop);
                }
                else
                    childManager.TrackCharacter(playerChilds[i - 1], playerChilds[i]);
            }
        }

        if (machineBottom._playerHit)
        {
            machineBottom._playerHit = false;
            //childManager.CreateChild(playerChilds, new Vector3(playerChilds.Length - 1, -1, 0));
            //playerParentBottom.Jump(playerParentBottom._jumpPower);          
        }
    }
}
