using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_6 : MonoBehaviour
{
    public List<Transform> flyList = new List<Transform>();
    public Transform imgGods;
    public Animator animTrigger;

    public Vector3 offset;
    public float frequency;
    public bool playAwake;

    private List<Vector3> flyOrigin = new List<Vector3>();
    private List<float> tickList = new List<float>();
    private float amplitude;
    private bool animate;

    private Vector3 offsetPos;
    private Vector3 originPos;
    private bool isEnterTrigger;
    private string curIndex;

    private void OnEnable()
    {
        if (Mathf.Approximately(frequency, 0f))
        {
            frequency = 1;
        }

        for (int i = 0; i < flyList.Count; i++)
        {
            flyOrigin.Add(flyList[i].position);
            tickList.Add(Random.Range(0f, 2f * Mathf.PI));
            flyList[i].GetComponent<Rigidbody2D>().simulated = false;
        }

        amplitude = 2 * Mathf.PI / frequency;
        animate = playAwake;

        originPos = transform.position;
    }

    private void Update()
    {
        if (animate)
        {
            for (int i = 0; i < flyList.Count; i++)
            {
                tickList[i] = tickList[i] + Time.deltaTime * amplitude;
                var amp = new Vector3(Mathf.Cos(tickList[i]) * offset.x, Mathf.Sin(tickList[i]) * offset.y, 0);
                flyList[i].position = flyOrigin[i] + amp;
            }
        }
    }

    public void Play()
    {
        for (int i = 0; i < flyList.Count; i++)
        {
            flyList[i].position = flyOrigin[i];
        }
        animate = true;
    }

    public void Stop()
    {
        for (int i = 0; i < flyList.Count; i++)
        {
            flyList[i].GetComponent<Rigidbody2D>().simulated = true;
        }
        animate = false;
    }

    public void OnBtnGodDragBegin()
    {
        offsetPos = transform.position - Input.mousePosition;
    }

    public void OnBtnGodDrag()
    {
        transform.position = Input.mousePosition + offsetPos;
    }

    public void OnBtnGodDragExit()
    {
        transform.DOMove(originPos, 0.5f);

        if (!isEnterTrigger) return;

        var imgGod = GameObject.Find("ImgGod_" + curIndex);
        imgGod?.GetComponent<Transform>().DOScale(new Vector3(1, 1, 1), 0.5F);
        imgGod?.GetComponent<Image>().DOFade(1, 0.5F).OnComplete(() => {
            isEnterTrigger = false;
            this.CheckGameWin();
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.name.Contains("GodArea")) return;

        curIndex = collision.name.Split('_')[1];
        isEnterTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.name.Contains("GodArea")) return;

        curIndex = "";
        isEnterTrigger = false;
    }

    private void CheckGameWin()
    {
        for (int i = 0; i < imgGods.childCount; i++)
        {
            if (imgGods.GetChild(i).GetComponent<Image>().color.a != 1) return;
        }

        // 所有神字都已出现
        animTrigger.SetTrigger("Level6Trigger");
    }
}
