using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //子供の生成
    void CreateChild(GameObject[] child)
    {
        for (int i = 0; i < child.Length; i++)
        {
            Instantiate(child[i], new Vector3(1 - i, 1, 0), Quaternion.identity);
        }
    }

    //追従オブジェクトを決める
    void TrackCharacter(GameObject predator,GameObject target)
    {
        predator.GetComponent<Tracking>()._target = target;
    }
}
