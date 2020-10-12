using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    private HingeJoint myHingeJoint;
    //初期の傾き
    private float defaultAngle = 20;
    //弾いたときの傾き
    private float flickAngle = -20;


    // Start is called before the first frame update
    void Start()
    {
        //HingeHointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾き
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        //左矢印キーを押した時に左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow)&& tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)&& tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //矢印キー離された時にフリッパーを元に戻す
        if  (Input.GetKeyUp(KeyCode.LeftArrow)&& tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow)&& tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle (float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
