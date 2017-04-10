//---------------------------------------
// IRFAN FAHMI RAMADHAN
//
// DetectorScript.cs
//---------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorScript : MonoBehaviour {

    private List<GameObject> objs = new List<GameObject>();         //床に当たるオブジェクト
    public int _objsNum = 0;                                        //床に当たるオブジェクトの数 

    private void Update()
    {
        //オブジェクトの数をマイフレームカウント
        _objsNum = objs.Count;
    }

    private void OnTriggerStay(Collider other)
    {
        //オブジェクトの数をリストに追加する
        if ((other.gameObject.tag == "Player"　|| other.gameObject.tag == "Child") && !objs.Contains(other.gameObject))
            objs.Add(other.gameObject);
        
    }
    private void OnTriggerExit(Collider other)
    {
        //出たオブジェクトをリストから削除
        objs.Remove(other.gameObject);
    }
}
