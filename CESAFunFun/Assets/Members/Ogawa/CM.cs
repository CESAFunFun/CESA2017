using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CM : MonoBehaviour {

    [SerializeField]
    private GameObject childPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public GameObject CreateChildCharacter(GameObject player, Vector3 position) {
        // プレハブから生成
        var child = Instantiate(childPrefab, position, Quaternion.identity);
        // プレイヤーのデータを元に設定を行う(変数にしないと値が変えられない)
        var character = child.GetComponent<RigidbodyCharacter>();
        character._downGravity = player.GetComponent<RigidbodyCharacter>()._downGravity;
        return child;
    }

    public void TrackCharacter(GameObject predator, GameObject target) {
        predator.GetComponent<Tracking>()._target = target;
    }

}
