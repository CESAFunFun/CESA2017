using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PressMachine[] pressMachines;

    public static GameManager _instance = null;

    void Awake()
    {
        if (!_instance)
            _instance = this;
        else if (_instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
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

    }
}
