using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderCtrl : MonoBehaviour
{
    public Scrollbar scrollbar;
    public ScrollRect scrollRect;

    private float targetValue;

    public bool needMove = false;

    //private const float MOVE_SPEED = 1F;

    private const float SMOOTH_TIME = 0.2F;

    private float moveSpeed = 0f;

    public void OnPointerDown()
    {
        needMove = false;
    }

    public void OnPointerUp()
    {
        Debug.Log("test");
        //判斷當前位於哪個區間，設置自動滑動至的位置
        if (scrollbar.value <= 0.125f)
        {
            targetValue = 0;
        }
        else if (scrollbar.value <= 0.375f)
        {
            targetValue = 0.25f;
        }
        else if (scrollbar.value <= 0.625f)
        {
            targetValue = 0.5f;
        }
        else if (scrollbar.value <= 0.875f)
        {
            targetValue = 0.75f;
        }
        else
        {
            targetValue = 1f;
        }
        needMove = true;
        moveSpeed = 0;
    }

    public void OnButtonClick(int value)
    {
        switch (value)
        {
            case 1:
                targetValue = 0;
                break;
            case 2:
                targetValue = 0.25f;
                break;
            case 3:
                targetValue = 0.5f;
                break;
            case 4:
                targetValue = 0.75f;
                break;
            case 5:
                targetValue = 1f;
                break;
            default:
                Debug.LogError("!!!!!");
                break;
        }
        needMove = true;
    }

    void Update()
    {
        if (needMove)
        {
            if (Mathf.Abs(scrollbar.value - targetValue) < 0.01f)
            {
                scrollbar.value = targetValue;
                needMove = false;
                return;
            }
            scrollbar.value = Mathf.SmoothDamp(scrollbar.value, targetValue, ref moveSpeed, SMOOTH_TIME);
        }
    }
}
