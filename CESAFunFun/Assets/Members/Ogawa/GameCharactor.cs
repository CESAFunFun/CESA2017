using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class GameCharactor : MonoBehaviour {

    [SerializeField]
    private bool downGravity = true;

    private CharacterController col;
    private Vector3 velocity;
    private float gravityPower = 9.8F;

	// Use this for initialization
	void Start () {
        col = GetComponent<CharacterController>();
        velocity = Vector3.zero;
        if(downGravity)
        {
            gravityPower *= -1F;
        }
	}
	
	// Update is called once per frame
	void Update () {
    }

    public void Move(Vector3 v, float speed) {
        // 移動速度の更新
        velocity.x = v.x * speed;
        velocity.y += gravityPower * Time.deltaTime;
        velocity.z = v.z * speed;
        // キャラクターコントローラの移動処理
        col.Move(velocity * Time.deltaTime);
    }

    public void Jump(float power) {
        if (col.isGrounded)
        {
            velocity.y = power;
        }
    }
}
