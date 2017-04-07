using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PMachine : MonoBehaviour {

    public bool _actived = false;
    public bool _falled = true;
    public bool _playerHit = false;
    public bool _childHit = false;

    private Rigidbody rigidbody;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float FALL_SPEED = 5F;
    private float RISE_SPEED = 3F;

    // Use this for initialization
    void Start () {
        // 衝突判定のために物理演算を取得
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        rigidbody.useGravity = false;
        // 開始地点と終了地点を設定
        startPosition = transform.position;
        endPosition = Vector3.zero;
        // 衝突を防ぐためにIsTriggerを有効化
        GetComponent<Collider>().isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
        if(_actived)
        {
            // プレス機が稼働中の移動処理を計算
            if(_falled)
            {
                // 落下中の移動処理
                transform.position = Vector3.MoveTowards(transform.position, endPosition, FALL_SPEED * Time.deltaTime);
            }
            else
            {
                // 上昇中の移動処理
                transform.position = Vector3.MoveTowards(transform.position, startPosition, RISE_SPEED * Time.deltaTime);
            }
        }

        // 元の位置に戻ったらフラグを初期に戻す
        if(transform.position == startPosition)
        {
            _actived = false;
            _falled = true;
        }
	}

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Floor")
        {
            // タグ"Floor"に衝突したら上昇する
            _falled = false;
        }

        if(_actived)
        {
            if(other.gameObject.tag == "Player")
            {
                // GameManagerにて
                // タグ"Child"を生成
                _playerHit = true;
            }
            if(other.gameObject.tag == "Child")
            {
                // GameManagerにて
                // タグ"Child"を破棄
                _childHit = true;
            }
        }
    }
}
