using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject[] playerChilds;
    [SerializeField]
    private GameObject goalText;

    private PressMachine machineTop;
    private PressMachine machineBottom;
    private GoalScript goalArea;
    private GameObject playerParentTop; 
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
        playerParentTop = GameObject.FindGameObjectWithTag("Player");
        machineTop = GameObject.Find("PressMachine/MachineTop").GetComponent<PressMachine>();
        machineBottom = GameObject.Find("PressMachine/MachineBottom").GetComponent<PressMachine>();
        goalArea = GameObject.Find("Goal").GetComponent<GoalScript>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            machineTop._actived = true;
            machineBottom._actived = true;
        }      

        if (machineTop._playerHit || machineBottom._playerHit)
        {
            Destroy(playerParentTop);

            for (int j = 0; j < playerChilds.Length; j++)
            {
                Instantiate(playerChilds[j], new Vector3(1 - j, 1, 0), Quaternion.identity);
            }

            machineTop._playerHit = false;
            machineBottom._playerHit = false;
        }

        ShowGoal();
    }

    void ShowGoal()
    {
        if(goalArea._isGoal)
            goalText.SetActive(true);
        
    }
}
