using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour {

    [SerializeField]
    private GameObject child;

    [SerializeField]
    private GameObject player;

    private ChildManager childManager;

    // Use this for initialization
    void Start () {
        childManager = GetComponent<ChildManager>();
        var c=childManager.CreateChild(child, new Vector3(0, 1, 0));
        childManager.TrackCharacter(c, player);
        //childManager.CreateChild(childs, new Vector3(childs.Length - 1, 1, 0));
        //for (int i = 0; i < childs.Length; i++)
        //{
        //    if (i == 0)
        //    {
        //        childManager.TrackCharacter(childs[i], player);
        //    }
        //    else
        //        childManager.TrackCharacter(childs[i - 1], childs[i]);
        //}
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
