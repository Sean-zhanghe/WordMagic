using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_2 : MonoBehaviour
{
    public Animator animTrigger;
    public Scrollbar m_Scrollbar;
    public ScrollRect m_ScrollRect;

    private const float SMOOTH_TIME = 0.2F;

    private bool mNeedMove;
    private float mMoveSpeed = 0f;

    private void Update()
    {
        if (mNeedMove)
        {
            if (m_Scrollbar.value < 0.01f)
            {
                m_Scrollbar.value = 0;
                mNeedMove = false;
                return;
            }
            m_Scrollbar.value = Mathf.SmoothDamp(m_Scrollbar.value, 0, ref mMoveSpeed, SMOOTH_TIME);
        }
    }

    public void OnPointerUp()
    {
        if (m_Scrollbar.value != 1)
        {
            mNeedMove = true;
        }
        else
        {
            mNeedMove = false;
            m_ScrollRect.enabled = false;
            animTrigger.SetTrigger("Level2Trigger");
        }
    }
}
