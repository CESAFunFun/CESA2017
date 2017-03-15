using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class GamePadControll : MonoBehaviour {

    [SerializeField]
    private GamePad.Index playerNumber;
    [SerializeField]
    private float moveSpeed = 5F;
    [SerializeField]
    private float jumpPower = 5F;

    private GameCharactor charactor;
    private Vector3 moveV = Vector3.zero;

    // Use this for initialization
    void Start() {
        charactor = GetComponent<GameCharactor>();
    }

    // Update is called once per frame
    void Update() {
        // インスペクターからゲームパッドの状態を取得
        GamepadState inputState = GetGamePad(playerNumber);

        // ゲームパッドでの操作
        if(inputState != null)
        {
            // ジャン処理
            if (inputState.A)
            {
                charactor.Jump(jumpPower);
            }
            // 左スティックで移動を行う
            moveV.x = inputState.LeftStickAxis.x;
        }
        // キーボードでの操作
        else
        {
            // ジャンプ処理
            if (Input.GetKeyDown(KeyCode.Space))
            {
                charactor.Jump(jumpPower);
            }

            // 方向キーで移動(横のみ)
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveV.x = -1F;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                moveV.x = +1F;
            }
            else
            {
                moveV.x = 0F;
            }
        }

        // 移動処理（座標の更新を行う）
        charactor.Move(moveV, moveSpeed);
    }

    GamepadState GetGamePad(GamePad.Index index) {
        if (index != GamePad.Index.Any)
        {
            // Any以外のゲームパッド状態を返す
            return GamePad.GetState(index, false);
        }
        return null;
    }
}
