using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Level_9 : MonoBehaviour
{
    public Transform imgTadpole;
    public Transform tadpoleTarget;
    public Transform[] movePos;

    public Transform btnDown;
    public Transform downTarget;

    public Transform btnUp;
    public Transform upTarget;

    public Transform imgFish;
    public Transform fishTarget;

    public Transform btnLand1;
    public Transform btnLand2;
    public Transform landArea1;
    public Transform landArea2;

    public Animator animFrog;


    public bool isStart;
    public bool isFinish;

    private Vector3 originFish;
    private int curMoveIndex = 0;
    private bool isArrive = true;


    // Start is called before the first frame update
    void OnEnable()
    {
        originFish = imgFish.position;
    }

    private void OnDisable() {
        DOTween.KillAll();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFinish)
        {
            return;
        }

        if (isArrive)
        {
            isArrive = false;
            curMoveIndex = (curMoveIndex + 1) % movePos.Length;

            // 计算偏转角度
            Quaternion rotation = CalcaleRotation(movePos[curMoveIndex].position);
            imgTadpole.DORotateQuaternion(rotation, 0.5f);
            imgTadpole.DOMove(movePos[curMoveIndex].position, 2f).SetId("move_" + curMoveIndex).OnComplete(() => isArrive = true);
        }
    }

    public void OnBtnDownClick()
    {
        if (isStart) return;

        isStart = true;
        btnDown.DOMove(downTarget.position, 1f);
    }

    public void OnBtnUpClick()
    {
        btnUp.DOMove(upTarget.position, 0.5f);
    }

    public void OnBtnFishClick()
    {
        var lv9Event = GameObject.Find("BtnLand2").GetComponent<Level_9_BtnEvent>();
        if (lv9Event.isDrag) return;

        Vector3 targetPos = imgFish.position == fishTarget.position ? originFish: fishTarget.position;
        imgFish.DOMove(targetPos, 0.8f);
        imgFish.DOScaleY(0.7f, 0.2f).SetLoops(2, LoopType.Yoyo);;
    }

    public void CheckGameWin()
    {
        if (btnLand1.position != landArea1.position) return;
        if (btnLand2.position != landArea2.position) return;

        this.OnGameFinish();
    }

    public void OnGameFinish()
    {
        isFinish = true;
        DOTween.Kill("move_" + curMoveIndex);
        imgTadpole.DORotateQuaternion(CalcaleRotation(tadpoleTarget.position), 0.5f);
        imgTadpole.DOMove(tadpoleTarget.position, 2f).OnComplete(() => 
            animFrog.SetTrigger("Level9Trigger")
        );
    }

    private Quaternion CalcaleRotation(Vector3 target)
    {
        Vector3 offset = target - imgTadpole.position;
        offset.z = 0;
        return Quaternion.FromToRotation(Vector3.up, offset);
    }
}
