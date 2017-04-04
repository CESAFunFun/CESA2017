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
    public void CreateChild(GameObject[] child,Vector3 pos)
    {
        for (int i = 0; i < child.Length; i++)
        {
            Instantiate(child[i], pos, Quaternion.identity);
            pos.x += i;
        }
    }

    //追従オブジェクトを決める
    public void TrackCharacter(GameObject predator,GameObject target)
    {
        predator.GetComponent<Tracking>()._target = target;
    }
}
