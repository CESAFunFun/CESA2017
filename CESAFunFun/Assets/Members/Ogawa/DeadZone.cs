using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour {

    private GameManager gameManager;

	// Use this for initialization
	void Start () {
        // Hierarichyから"GameManager"を探索して取得しておく
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision) {
        Debug.Log("OnCollision");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player");
            // タグ"Player"と衝突したらプレイヤーのリセットを行う
            gameManager.SendMessage("ResetPlayer", collision.gameObject);
        }
        if(collision.gameObject.tag == "Child")
        {
            Debug.Log("Child");
            // タグ"Child"と衝突したら子要素の消去と追従の変更を行う
            gameManager.SendMessage("DeadChild", collision.gameObject);
        }
    }
}
