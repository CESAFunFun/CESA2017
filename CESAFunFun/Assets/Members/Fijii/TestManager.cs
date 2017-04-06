using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour {

    [SerializeField]
    private GameObject[] childs;

    [SerializeField]
    private GameObject player;

    private ChildManager childManager;

    // Use this for initialization
    void Start () {
        childManager = GetComponent<ChildManager>();
        childManager.CreateChild(childs, new Vector3(childs.Length - 1, 1, 0));
        for (int i = 0; i < childs.Length; i++)
        {
            if (i == 0)
            {
                childManager.TrackCharacter(childs[i], player);
            }
            else
                childManager.TrackCharacter(childs[i - 1], childs[i]);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
