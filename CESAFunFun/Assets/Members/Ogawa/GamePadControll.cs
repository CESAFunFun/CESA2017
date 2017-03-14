using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

[RequireComponent(typeof(CharacterController))]
public class GamePadControll : MonoBehaviour {

    [SerializeField]
    private GamePad.Index playerNumber;
    [SerializeField]
    private float moveSpeed = 5F;
    [SerializeField]
    private float jumpPower = 5F;

    [SerializeField] private bool freezeX = false;
    [SerializeField] private bool freezeY = false;
    [SerializeField] private bool freezeZ = false;

    private CharacterController col;
    private Vector3 velocity;
    private const float GRAVITY = -9.8F;

    // Use this for initialization
    void Start() {
        col = GetComponent<CharacterController>();
        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update() {
        // インスペクターからゲームパッドの状態を取得
        GamepadState inputState = SetGamePad(playerNumber);

        // ジャンプの入力処理
        if (inputState.A)
        {
            if (col.isGrounded)
                velocity.y = jumpPower;
        }
        if(!freezeY) velocity.y += GRAVITY * Time.deltaTime;

        // 左スティックで移動処理を行う
        if(!freezeX) velocity.x = inputState.LeftStickAxis.x * moveSpeed;
        if(!freezeZ) velocity.z = inputState.LeftStickAxis.y * moveSpeed;

        // キャラクターコライダーを用いて移動
        col.Move(velocity * Time.deltaTime);
    }

    GamepadState SetGamePad(GamePad.Index index) {
        if (index != GamePad.Index.Any)
        {
            // Any以外のゲームパッド状態を返す
            return GamePad.GetState(index, false);
        }
        return null;
    }
}
