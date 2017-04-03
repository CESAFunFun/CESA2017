using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PressMachine[] pressMachines;
    [SerializeField]
    private GameObject[] playerChilds;
    [SerializeField]
    private GameObject goalText;


    private GoalScript goalArea;
    private GameObject playerParent; 
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
        playerParent = GameObject.Find("Player");
        goalArea = GameObject.Find("Goal").GetComponent<GoalScript>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            for (int i = 0; i < pressMachines.Length; i++)
            {
                pressMachines[i]._actived = true;
            }
        }

        for(int i = 0; i< pressMachines.Length; i++)
        {
            if(pressMachines[i]._playerHit)
            {
                Destroy(playerParent);

                for(int j = 0; j < playerChilds.Length; j++ )
                {
                    Instantiate(playerChilds[j], new Vector3(1 - j, 1, 0), Quaternion.identity);  
                }
                pressMachines[i]._playerHit = false;
            }

            
        }

        ShowGoal();
    }

    void ShowGoal()
    {
        if(goalArea._isGoal)
            goalText.SetActive(true);
        
    }
}
