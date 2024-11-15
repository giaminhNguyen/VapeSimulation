using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityHelper;

public class TypeObjectMenuLayer : LayerBase
{
    [SerializeField]
    private LayoutGroup _layoutGroup;
    [SerializeField]
    private DOTweenMove[] _buttonDOTweenMoveAnimaitonArr;

    protected override void InitAwake()
    {
    }

    protected override void InitOnEnable()
    {
    }

    protected override void InitStart()
    {
        StartCoroutine(Anim());
    }

    public override void Init()
    {
    }

    public override void Open()
    {
        base.Open();
        _content.SetActive(true);
    }

    public override void Close()
    {
        base.Close();
        _content.SetActive(false);
    }

    private IEnumerator Anim()
    {
        yield return new WaitForEndOfFrame();
        _layoutGroup.enabled = false;
        foreach(var button in _buttonDOTweenMoveAnimaitonArr)
        {
            button.enabled = true;
        }
    }
}