using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gGoalScripts : MonoBehaviour {

    //衝突しているオブジェクトのリストをとる
    private List<GameObject> itemList = new List<GameObject>();
    //Item数のカウント
    public int _itemCount;
    //goal flag
    public bool _isGoal;

    // Use this for initialization
    void Start () {
        _isGoal = false;
    }
	
	// Update is called once per frame
	void Update () {
        //設定値と同じ数値であれば Goalしたことをおしえる
        if (_itemCount == itemList.Count)
        {
            _isGoal = true;
        }
        else
        {
            _isGoal = false;
        }
        Debug.Log(itemList.Count);

        //衝突オブジェクトの誤差がないようにクリアを定期的にする
        itemList.Clear();
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        //子供が当たっている数だけ検知する
        if (col.gameObject.tag == "Child"&&!itemList.Contains(gameObject))
        {
            itemList.Add(col.gameObject);
        }
    }
}
