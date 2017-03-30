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

    private GamepadState inputState;
    private RigidbodyCharacter character;
    private Vector3 moveV = Vector3.zero;

    // Use this for initialization
    void Start() {
        character = GetComponent<RigidbodyCharacter>();
    }

    // Update is called once per frame
    void Update() {
        // インスペクターからゲームパッドの状態を取得
        inputState = GetGamePad(playerNumber);

        // ゲームパッドでの操作
        if(inputState != null)
        {
            // ジャン処理
            if (inputState.A)
            {
                character.Jump(jumpPower);
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
                character.Jump(jumpPower);
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
        character.Move(moveV, moveSpeed);
    }

    void LiftUp(GameObject obj) {
        // 子要素として頭上に設定
        Vector3 overHead = new Vector3(0F, 1F + transform.childCount, 0F);
        obj.transform.position = transform.position + overHead;
        obj.transform.SetParent(transform);
    }

    GamepadState GetGamePad(GamePad.Index index) {
        if (index != GamePad.Index.Any)
        {
            // Any以外のゲームパッド状態を返す
            return GamePad.GetState(index, false);
        }
        return null;
    }

    void OnControllerColliderHit(ControllerColliderHit hit) {
        if(hit.gameObject.tag == "Child") {
            //Debug.Log(hit.gameObject.name);
            if(inputState.X || Input.GetKeyDown(KeyCode.Z))
            {
                LiftUp(hit.gameObject);
            }
        }
    }
}
