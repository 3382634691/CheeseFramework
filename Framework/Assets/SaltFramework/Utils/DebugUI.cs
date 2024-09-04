using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DebugUI : UIBase, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //Tip: UI��ָ���λ��ƫ����
    Vector3 offset;
    //Tip: ��ǰ��λ��
    Vector3 pos;
    //Tip: �����RectTransform
    RectTransform rt;
    //Tip: ˮƽ��С��ק��Χ
    float minWidth;
    //Tip: ˮƽ�����ק��Χ
    float maxWidth;
    //Tip: ��ֱ��С��ק��Χ  
    float minHeight;
    //Tip: ��ֱ�����ק��Χ
    float maxHeight;
    //Tip: ��ק��Χ
    float rangeX;
    //Tip: ��ק��Χ
    float rangeY;
    //Tip: �رհ�ť
    public Button closeBtn;
    //Tip: �������X�ı�
    public Text cameraforText;
    //Tip: ��ǰ�ؿ����ı�
    public Text levelText;

    /// <summary>
    /// Base:update
    /// </summary>
    void Update()
    {
        DragRangeLimit();
        UpdataData();
    }

    /// <summary>
    /// Update:
    /// ��������
    /// </summary>
    public void UpdataData()
    {
       
    }

    /// <summary>
    /// Base:start
    /// </summary>
    public override void Start()
    {
        rt = GetComponent<RectTransform>();
        pos = rt.position;
        minWidth = rt.rect.width / 2;
        maxWidth = Screen.width - (rt.rect.width / 2);
        minHeight = rt.rect.height / 2;
        maxHeight = Screen.height - (rt.rect.height / 2);
        closeBtn.onClick.AddListener(() =>
        {
            Close();
        });
    }

    /// <summary>
    /// Drag:
    /// ��ק��Χ����
    /// </summary>
    void DragRangeLimit()
    {
        rangeX = Mathf.Clamp(rt.position.x, minWidth, maxWidth);
        rangeY = Mathf.Clamp(rt.position.y, minHeight, maxHeight);
        rt.position = new Vector3(rangeX, rangeY, 0);
    }

    /// <summary>
    /// Drag:
    /// ��ʼ��ק
    /// </summary>
    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, eventData.position, null, out globalMousePos))
        {
            offset = rt.position - globalMousePos;
        }
    }

    /// <summary>
    /// Drag:
    /// ��ק��
    /// </summary>
    public void OnDrag(PointerEventData eventData)
    {
        SetDraggedPosition(eventData);
    }

    /// <summary>
    /// Drag:
    /// ������ק
    /// </summary>
    public void OnEndDrag(PointerEventData eventData)
    {

    }

    /// <summary>
    /// Drag:
    /// ����UI��λ��
    /// </summary>
    private void SetDraggedPosition(PointerEventData eventData)
    {
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, eventData.position, null, out globalMousePos))
        {
            rt.position = offset + globalMousePos;
        }
    }
}
