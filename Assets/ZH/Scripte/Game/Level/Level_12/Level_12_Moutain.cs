using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Level_12_Moutain : MonoBehaviour
{
    public Level_12 lv12;
    private Quaternion originRotation;

    private void OnEnable() {
        originRotation = transform.rotation;
    }
    public void OnBtnDrag()
    {
        if (transform.rotation.eulerAngles.z == 90) return;

        Vector2 dir = Input.mousePosition - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle = angle <= 0 ? (angle + 360) : angle;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void OnBtnDragExit()
    {
        if (transform.rotation.eulerAngles.z < 100 && transform.rotation.eulerAngles.z > 80)
        {
            transform.DORotate(new Vector3(transform.rotation.x, transform.rotation.y, 90), 0.5f).OnComplete(() => lv12.OnCheckGameStart());
        }
        else
        {
            transform.DORotateQuaternion(originRotation, 0.5f);
        }
    }
}
