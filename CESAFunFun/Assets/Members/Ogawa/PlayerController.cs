using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class PlayerController : MonoBehaviour {

    private RigidbodyCharacter character;

    [SerializeField]
    private GamePad.Index playerIndex;
    [SerializeField]
    private float moveSpeed = 1F;
    [SerializeField]
    private float jumpPower = 1F;

    private GamepadState inputState;
    private Vector3 velocity;

    // Use this for initialization
    void Start()
    {
        character = GetComponent<RigidbodyCharacter>();
        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // インスペクターからゲームパッドを取得
        inputState = GetGamePad(playerIndex);

        if (inputState != null)
        {
            velocity.x = inputState.LeftStickAxis.x;

            var obj = GameObject.FindGameObjectWithTag("Child");
            if (obj.GetComponent<Rigidbody>().isKinematic)
            {
                if (inputState.X)
                {
                    obj.GetComponent<BoxCollider>().isTrigger = false;
                }
                else
                {
                    obj.GetComponent<BoxCollider>().isTrigger = true;
                }
            }

            if(inputState.Y)
            {

            }

            if(inputState.A)
            {
                character.Jump(jumpPower);
            }
        }
        else
        {
            var obj = GameObject.FindGameObjectWithTag("Child");
            if (obj.GetComponent<Rigidbody>().isKinematic)
            {
                if (Input.GetKey(KeyCode.Z))
                {
                    obj.GetComponent<BoxCollider>().isTrigger = false;
                }
                else
                {
                    obj.GetComponent<BoxCollider>().isTrigger = true;
                }
            }

            if (Input.GetKey(KeyCode.X))
            {

            }

            if (Input.GetKey(KeyCode.A))
            {
                velocity.x = -1F;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                velocity.x = 1F;
            }
            else
            {
                velocity.x = 0F;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                character.Jump(jumpPower);
            }
        }

        // キャラクターの向き方向の設定
        transform.LookAt(transform.position + velocity);
        // キャラクターの移動
        character.Move(velocity, moveSpeed);
    }

    void OnCollisionEnter(Collision collision) {
        var obj = collision.gameObject;
        if (obj.tag == "Child")
        {
            Vector3 overHead = new Vector3(0F, 1F + transform.childCount, 0F);
            obj.transform.position = transform.position + overHead;
            obj.transform.SetParent(transform);
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
