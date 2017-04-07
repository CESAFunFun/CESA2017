using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {

    public GameObject _pressMachine;
    public GameObject _player1;
    public GameObject _player2;

    private CM childManager;
    private PMachine topPressMachine;
    private PMachine buttomPressMachine;
    private PlayerController player1Controller;
    private PlayerController player2Controller;

    // Use this for initialization
    void Start () {
        childManager = GetComponent<CM>();
        topPressMachine = _pressMachine.transform.GetChild(0).GetComponent<PMachine>();
        buttomPressMachine = _pressMachine.transform.GetChild(1).GetComponent<PMachine>();
        if (_player1) player1Controller = _player1.GetComponent<PlayerController>();
        if (_player2) player2Controller = _player2.GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        // プレイヤー双方の入力を取得したらプレス機を稼働させる
		if(player1Controller._isPressMachineActived && player2Controller._isPressMachineActived)
        {
            topPressMachine._actived = true;
            buttomPressMachine._actived = true;
        }

        // 上のプレス機がプレイヤーと衝突
        if (topPressMachine._playerHit)
        {
            topPressMachine._playerHit = false;
            Press(topPressMachine, _player1, 3);
        }
        // 下のプレス機がプレイヤーと衝突
        if (buttomPressMachine._playerHit)
        {
            buttomPressMachine._playerHit = false;
            Press(buttomPressMachine, _player2, 3);
        }
    }

    private void Press(PMachine pressMachine, GameObject player, int length) {
        // プレス機が稼働したら子要素を作成する
        var children = new GameObject[length];
        for (int i = 0; i < children.Length; i++)
        {
            children[i] = childManager.CreateChildCharacter(player, pressMachine.transform.position);
            childManager.TrackCharacter(children[i], i == 0 ? player : children[i - 1]);
        }
        player.GetComponent<RigidbodyCharacter>().IgnoreCharacter("Child", true);
    }

    private void ResetPlayer(GameObject player) {
        player.SetActive(false);
    }

    private void DeadChild(GameObject child) {
        Destroy(child);
    }
}
