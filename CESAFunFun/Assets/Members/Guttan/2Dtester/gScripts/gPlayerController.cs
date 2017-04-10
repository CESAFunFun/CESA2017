using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class gPlayerController : MonoBehaviour
{
    private gRigidbodyCharacter character;

    [SerializeField]
    private GamePad.Index playerIndex; //

    [HideInInspector]
    public Vector2 velocity;

    private GamepadState inputState; //

    public bool _isPressMachineActived { get; private set; }

    // Use this for initialization
    void Start()
    {
        character = GetComponent<gRigidbodyCharacter>();
        velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // インスペクターからゲームパッドを取得
        inputState = GetGamePad(playerIndex);
        if (inputState != null)
        {
            // 左joystick取得
            velocity.x = inputState.LeftStickAxis.x;

        }
        // キャラクターの移動
        if (velocity.x == 0)
        {
            //character.Move(velocity,1);
            character._moveSpeed = 0.0f;
        }
        else if(velocity.x<=-1)
        {
            character._moveSpeed = -0.05f;
            character.Move(velocity, character._moveSpeed);
        }
        else if(velocity.x>=1)
        {
            character._moveSpeed = 0.05f;
            character.Move(velocity, character._moveSpeed);
        }
        //ジャンプ処理
        if (inputState.A)
        {
            character.Jump(character._jumpPower);
        }

    }



    GamepadState GetGamePad(GamePad.Index index)
    {
        if (index != GamePad.Index.Any)
        {
            // Any以外のゲームパッド状態を返す
            return GamePad.GetState(index, false);
        }
        return null;
    }
}
