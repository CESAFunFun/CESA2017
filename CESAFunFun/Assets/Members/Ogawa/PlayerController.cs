using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class PlayerController : MonoBehaviour {

    private RigidbodyCharacter character;

    [SerializeField]
    private GamePad.Index playerIndex;

    [HideInInspector]
    public Vector3 velocity;

    private GamepadState inputState;

    public bool _isPressMachineActived { get; private set; }

    // Use this for initialization
    void Start() {
        character = GetComponent<RigidbodyCharacter>();
        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update() {
        // インスペクターからゲームパッドを取得
        inputState = GetGamePad(playerIndex);

        if (inputState != null)
        {
            // 移動の入力
            velocity.x = inputState.LeftStickAxis.x;

            //// TODO : キーボード側で同じ処理が記載されているので修正する
            //// XXX : 入力Releseが取れないとオブジェクト化できない
            //// 持ち上げるための衝突判定を有効化
            //if (inputState.X)
            //{
            //    // ゲーム内の"Child"を取得して衝突判定を有効化する
            //    character._children = GameObject.FindGameObjectsWithTag("Child");
            //    for (int i = 0; i < character._children.Length; i++)
            //    {
            //        Physics.IgnoreCollision(character._children[i].GetComponent<Collider>(), GetComponent<Collider>(), false);
            //    }
            //}
            //else if (!inputState.X)
            //{
            //    // ゲーム内の"Child"を取得して衝突判定を無効化する
            //    character._children = GameObject.FindGameObjectsWithTag("Child");
            //    for (int i = 0; i < character._children.Length; i++)
            //    {
            //        Physics.IgnoreCollision(character._children[i].GetComponent<Collider>(), GetComponent<Collider>(), true);
            //    }
            //}

            // 投げる入力
            if (inputState.Y)
            {
                ThrowChild();
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                // ゲーム内の"Child"を取得して衝突判定を無視する
                character._children = GameObject.FindGameObjectsWithTag("Child");
                for (int i = 0; i < character._children.Length; i++)
                {
                    Physics.IgnoreCollision(character._children[i].GetComponent<Collider>(), GetComponent<Collider>(), true);
                    character._children[i].GetComponent<RigidbodyCharacter>()._objected = false;
                    character._children[i].GetComponent<Rigidbody>().isKinematic = false;
                }
            }

            // プレス機の稼働を許可を入力
            _isPressMachineActived = inputState.LeftShoulder ? true : false;

            // ジャンプの入力と処理
            if (inputState.A)
            {
                character.Jump(character._jumpPower);
            }
        }
        else
        {
            // 移動の入力
            if(Input.GetKey(KeyCode.A))
            {
                velocity.x = -character._moveSpeed;
            }
            else if(Input.GetKey(KeyCode.D))
            {
                velocity.x = +character._moveSpeed;
            }
            else
            {
                velocity.x = 0F;
            }

            // TODO : ゲームパッド側で同じ処理が記載されているので修正する
            // 持ち上げるための衝突判定を有効化
            if (Input.GetKeyDown(KeyCode.Z))
            {
                // ゲーム内の"Child"を取得して衝突判定を有効化する
                character._children = GameObject.FindGameObjectsWithTag("Child");
                for (int i = 0; i < character._children.Length; i++)
                {
                    //if (character._children[i].GetComponent<RigidbodyCharacter>()._objected)
                    {
                        Physics.IgnoreCollision(character._children[i].GetComponent<Collider>(), GetComponent<Collider>(), false);
                    }
                }
            }
            else if (Input.GetKeyUp(KeyCode.Z))
            {
                // ゲーム内の"Child"を取得して衝突判定を無効化する
                character._children = GameObject.FindGameObjectsWithTag("Child");
                for (int i = 0; i < character._children.Length; i++)
                {
                    if (!character._children[i].GetComponent<RigidbodyCharacter>()._objected)
                    {
                        Physics.IgnoreCollision(character._children[i].GetComponent<Collider>(), GetComponent<Collider>(), true);
                    }
                }
            }

            // 投げる入力
            if (Input.GetKey(KeyCode.X))
            {
                ThrowChild();
            }

            // プレス機の稼働を許可を入力
            _isPressMachineActived = (Input.GetKey(KeyCode.W)) ? true : false;

            // ジャンプ入力
            if (Input.GetKeyDown(KeyCode.Space))
            {
                character.Jump(character._jumpPower);
            }

            if(Input.GetKeyDown(KeyCode.C))
            {
                // ゲーム内の"Child"を取得して衝突判定を無視する
                character._children = GameObject.FindGameObjectsWithTag("Child");
                for (int i = 0; i < character._children.Length; i++)
                {
                    Physics.IgnoreCollision(character._children[i].GetComponent<Collider>(), GetComponent<Collider>(), true);
                    character._children[i].GetComponent<RigidbodyCharacter>()._objected = false;
                    character._children[i].GetComponent<Rigidbody>().isKinematic = false;
                }
            }
        }

        // キャラクターの移動
        character.Move(velocity, character._moveSpeed);
    }

    void ThrowChild() {
        if (transform.childCount != 0)
        {
            // 子要素になっているものを外して前方向に投げる
            Transform child = transform.GetChild(0);
            child.transform.SetParent(null);
            child.GetComponent<RigidbodyCharacter>()._isGrounded = false;
            child.GetComponent<Rigidbody>().velocity = transform.up * 3F + transform.forward * 3.5F;
        }
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Child")
        {
            // 有効化された衝突判定で持ち上げる
            if (Input.GetKey(KeyCode.Z) || ((inputState != null) && inputState.X))
            {
                Vector3 overHead = new Vector3(0F, 1F + transform.childCount, 0F);
                other.transform.GetComponent<RigidbodyCharacter>()._objected = true;
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
