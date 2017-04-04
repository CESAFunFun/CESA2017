using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject[] playerChilds;
    [SerializeField]
    private GameObject goalText;

    private ChildManager childManager;
    private PressMachine machineTop;
    private PressMachine machineBottom;
    private GoalScript goalArea;
    private RigidbodyCharacter playerParentTop;
    private RigidbodyCharacter playerParentBottom; 
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
        playerParentTop = GameObject.Find("Player_Top").GetComponent<RigidbodyCharacter>();
        playerParentBottom = GameObject.Find("Player_Bottom").GetComponent<RigidbodyCharacter>();
        machineTop = GameObject.Find("PressMachine/MachineTop").GetComponent<PressMachine>();
        machineBottom = GameObject.Find("PressMachine/MachineBottom").GetComponent<PressMachine>();
        goalArea = GameObject.Find("Goal").GetComponent<GoalScript>();
        childManager = gameObject.GetComponent<ChildManager>();
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
        /*
        if (goalArea._isGoal)
            goalText.SetActive(true);
        else
            goalText.SetActive(false);
        */
    }
    
    void CreateChild()
    {
        /*
        if (machineTop._playerHit)
        {
            machineTop._playerHit = false;
            //childManager.CreateChild(playerChilds, new Vector3(playerChilds.Length - 1, 1, 0));
            for (int i = 0; i < playerChilds.Length; i++)
            {
                Instantiate(playerChilds[i], new Vector3(1 - i, -1, 0), Quaternion.identity);
            }
            playerParentTop.Jump(playerParentTop._jumpPower);          
        }

        if (machineBottom._playerHit)
        {
            machineBottom._playerHit = false;
            for (int i = 0; i < playerChilds.Length; i++)
            {
                Instantiate(playerChilds[i], new Vector3(1 - i, -1, 0), Quaternion.identity);   
            }
            playerParentBottom.Jump(playerParentBottom._jumpPower);          
        }
        */
    }
}
