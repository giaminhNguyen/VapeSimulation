using System;
using _GameAssets._Scripts.ObjectSimulation;
using Unity.VisualScripting;
using UnityEngine;
using UnityHelper;

public class LightSaberSimulation : ObjectSimulationBase
{
    #region Properties

    [SerializeField]
    private Transform[] _lightSaber;

    [SerializeField]
    private float _speed = 3;
    
    //Private
    private float          _progress;
    private LightSaberData _lightSaberData;
    private Color          _currentColor;
    private float          _capacity;
    private bool           _isin;
    
    //KEY
    private static readonly int BaseColor = Shader.PropertyToID("_BaseColor");
    
    #endregion

    #region Implement

    private void Update()
    {
        UpdateLightSaber();
    }

    private void UpdateLightSaber()
    {
        float nav = 1;

        if (!EventManager.onMouseInteract())
        {
            nav = -1;
            if(_progress <= 0) return;
        }else if(_progress >= 1) return;

        _progress = Mathf.Clamp01(_progress + nav * _speed * Time.deltaTime);

        foreach (var lightSaber in _lightSaber)
        {
            lightSaber.localScale = new Vector3(1, 1, _progress);
        }
    }

    #endregion
    
    
    protected override void GetObjectBase()
    {
        if(!_hasData) return;
        _lightSaberData = DataGame.Instance.GetLightSaberData(EventManager.getSelectedObjectIndex());
        _currentColor   = _lightSaberData.defaultColor;
        _capacity       = 0;
    }

    public override void OnReload()
    {
        _capacity = 100;
    }

    private void UpdateCapacity()
    {
        EventDispatcher.Instance.PostEvent(EventID.UpdateCapacity,_capacity);
    }
    
    
    //struct
    [Serializable]
    private struct LightSaberInfo
    {
        public Transform tf;
        public Axis      axisScale;
    }
}
