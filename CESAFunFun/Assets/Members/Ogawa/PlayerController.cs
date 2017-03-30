using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class PlayerController : MonoBehaviour {

    private RigidbodyCharacter character;

    [SerializeField]
    private GamePad.Index playerIndex;

  

    private GamepadState inputState;
    public Vector3 velocity;

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
            // 移動の入力
            velocity.x = inputState.LeftStickAxis.x;

            // 持ち上げる入力
            if (inputState.X)
            {
                var obj = GameObject.FindGameObjectsWithTag("Child");
                foreach (var o in obj)
                {
                    o.GetComponent<SphereCollider>().isTrigger = false;
                }
            }
            else
            {
                var obj = GameObject.FindGameObjectsWithTag("Child");
                foreach (var o in obj)
                {
                    o.GetComponent<SphereCollider>().isTrigger = true;
                }
            }

            // 投げる入力
            if (inputState.Y)
            {
                ThrowChild();
            }

            // ジャンプの入力と処理
            if (inputState.A)
            {
                character.Jump(character.jumpPower);
            }
        }
        else
        {
            // 移動の入力
            if(Input.GetKey(KeyCode.A))
            {
                velocity.x = -character.moveSpeed;
            }
            else if(Input.GetKey(KeyCode.D))
            {
                velocity.x = +character.moveSpeed;
            }
            else
            {
                velocity.x = 0F;
            }

            // 持ち上げる入力
            if (Input.GetKeyDown(KeyCode.Z))
            {
                var obj = GameObject.FindGameObjectsWithTag("Child");
                foreach (var o in obj)
                {
                    o.GetComponent<SphereCollider>().isTrigger = false;
                }
            }
            else if (Input.GetKeyUp(KeyCode.Z))
            {
                var obj = GameObject.FindGameObjectsWithTag("Child");
                foreach (var o in obj)
                {
                    o.GetComponent<SphereCollider>().isTrigger = true;
                }
            }

            // 投げる入力
            if (Input.GetKey(KeyCode.X))
            {
                ThrowChild();
            }

            // ジャンプの入力と処理
            if (Input.GetKeyDown(KeyCode.Space))
            {
                character.Jump(character.jumpPower);
            }
        }

        // キャラクターの移動
        character.Move(velocity, character.moveSpeed);
    }

    void ThrowChild() {
        if (transform.childCount != 0)
        {
            Transform child = transform.GetChild(0);
            child.transform.SetParent(null);
            child.GetComponent<Rigidbody>().isKinematic = false;
            child.GetComponent<Rigidbody>().velocity = transform.up * 3F + transform.forward * 3.5F;
            child.GetComponent<SphereCollider>().isTrigger = false;
            child.GetComponent<RigidbodyCharacter>()._objected = true;
        }
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Child")
        {
            if (Input.GetKey(KeyCode.Z))
            {
                Vector3 overHead = new Vector3(0F, 1F + transform.childCount, 0F);
                other.transform.position = transform.position + overHead;
                other.transform.SetParent(transform);
            }
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
