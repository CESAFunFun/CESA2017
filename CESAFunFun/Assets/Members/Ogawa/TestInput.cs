using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInput : MonoBehaviour {

    private DownGravity gravity;
    private Vector3 velocity;

	// Use this for initialization
	void Start () {
        gravity = GetComponent<DownGravity>();
        velocity = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        // ＡＤキーによる横移動の入力
        if(Input.GetKey(KeyCode.A))
        {
            velocity.x = -1F;
            Debug.Log("Push A");
        }
        else if(Input.GetKey(KeyCode.D))
        {
            velocity.x = +1F;
            Debug.Log("Push D");
        }
        else
        {
            velocity.x = 0F;
        }
        // 重力に適した移動処理
        gravity.Move(velocity, 3F);

        // Spaceキーによるジャンプの入力
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 接地していたら重力に適した跳躍処理
            if (gravity._isGrounded)
            {
                gravity.Jump(5F);
            }
        }
	}
}
