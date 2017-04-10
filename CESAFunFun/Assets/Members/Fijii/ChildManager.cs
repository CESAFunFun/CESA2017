using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildManager : MonoBehaviour {

    [SerializeField]
    private GameObject childPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //子供の生成
    public GameObject[] CreateChild(GameObject player,Vector3 pos,int childNum)
    {
        GameObject[] children = new GameObject[childNum];
        for (int i = 0; i < childNum; i++)
        {
            children[i] = Instantiate(childPrefab, pos, Quaternion.identity);
            pos.x += i;
            //キャラクターに重力を設定する
            children[i].GetComponent<RigidbodyCharacter>()._downGravity = player.GetComponent<RigidbodyCharacter>()._downGravity;
        }
        return children;
    }

    public GameObject CreateChild(GameObject prefab, Vector3 position)
    {
        return Instantiate(prefab, position, Quaternion.identity);
    }

    //追従オブジェクトを決める
    public void TrackCharacter(GameObject predator,GameObject target)
    {
        predator.GetComponent<Tracking>()._target = target;
    }

    //追従オブジェクトを変更
    public void ChangeTrackCharacter(GameObject[] children, GameObject player)
    {

        int count = 0;

        for (int i = 0; i < children.Length; i++)
        {

            //子供がオブジェクトだったらターゲットを変える
            if (children[i].GetComponent<RigidbodyCharacter>()._objected)
            {
                count++;
                continue;
            }
            //親に追従
            if (i == count)
                TrackCharacter(children[i], player);
            //子供がオブジェクト化されていない時
            else if (count == 0)
                TrackCharacter(children[i], children[i - 1]);
            //子供がオブジェクト化されている時
            else
                TrackCharacter(children[i], children[i - count]);
        }
    }
}
