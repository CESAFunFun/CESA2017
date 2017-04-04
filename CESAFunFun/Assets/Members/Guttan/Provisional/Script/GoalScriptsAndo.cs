using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//コライダーの中を検出

/*
 * 変更点
 * 1.GoalMarker_TopにBoxcolliderをつける　Box
 * 2.GoalMarker_ButtomにBox_colliderをつける 
 * 3.PlayerのtagをChildに変更してtest → Playerに戻すべし
 * 
 */

public class GoalScriptsAndo : MonoBehaviour
{
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
	
    void Update()
    {
        //設定値と同じ数値であれば Goalしたことをおしえる
        if (_itemCount == itemList.Count)
        {
            _isGoal = true;
        }
       
        //衝突オブジェクトの誤差がないようにクリアを定期的にする
        itemList.Clear();
    }

    //Box個数検知用
    void OnTriggerStay(Collider other)
    {
        //子供が当たっている数だけ検知する
        if (other.gameObject.tag == "Child")
        {
            itemList.Add(other.gameObject);
        }
        

    }
}
