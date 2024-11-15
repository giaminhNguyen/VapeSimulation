using System;
using _GameAssets._Scripts.ObjectSimulation;
using UnityEngine;
using UnityHelper;

public class LightSaberSimulation : ObjectSimulationBase
{
    #region Properties

    [SerializeField]
    private LightSaberInfo[] _lightSaber;

    [SerializeField]
    private float _activationTime = 0.25f;

    [SerializeField]
    private float _usageTime = 4f;
    
    //Private
    private float          _progress;
    private LightSaberData _lightSaberData;
    private Color          _currentColor;
    private float          _energy;
    
    //KEY
    private static readonly int BaseColor = Shader.PropertyToID("_BaseColor");
    
    #endregion

    #region Implement

    protected override void OnEnable()
    {
        base.OnEnable();
        _progress       = 0;
        foreach (var lightSaber in _lightSaber)
        {
            UpdateLightSaber(lightSaber,_progress);
        }
        //
        EventDispatcher.Instance.RegisterListener(EventID.Reload,OnReload);
    }
    
    protected override void OnDisable()
    {
        base.OnDisable();
        EventDispatcher.Instance.RemoveListener(EventID.Reload,OnReload);
    }

    protected override void Start()
    {
        base.Start();
        UpdateEnergy(_energy);
    }

    protected override void Update()
    {
        base.Update();
        UpdateLightSaber();
    }

    #endregion
    
    private void UpdateLightSaber()
    {
        float nav = 1;

        if (!EventManager.onMouseInteract())
        {
            if(_progress <= 0) return;
            nav = -1;
            
        }else if( _energy <= 0 || _progress >= 1) return;
        else
        {
            _energy = Mathf.Clamp01(_energy - Time.deltaTime / _usageTime);

            if (_energy == 0)
            {
                EventDispatcher.Instance.PostEvent(EventID.NeedReload);
            }
        }

        _progress = Mathf.Clamp01(_progress + nav *  Time.deltaTime / _activationTime);

        foreach (var lightSaber in _lightSaber)
        {
            UpdateLightSaber(lightSaber,_progress);
        }

        UpdateEnergy(_energy);
    }

    private void UpdateLightSaber(LightSaberInfo lightSaber, float progress)
    {
        Vector3 vt;

        switch (lightSaber.axisScale)
        {
            case Axis.X: 
                vt = new(progress, 1, 1);
                break;
            case Axis.Y: 
                vt = new(1, progress, 1);
                break;
            default: 
                vt = new(1, 1, progress);
                break;
        }

        lightSaber.tf.localScale = vt;

    }


    protected override void GetObjectBase()
    {
        if(!_hasData) return;
        _lightSaberData = DataGame.Instance.GetLightSaberData(EventManager.getSelectedObjectIndex());
        _currentColor   = _lightSaberData.defaultColor;
        _capacity       = 1;
        _energy         = 1;
    }

    public override void OnReload(object obj)
    {
        _energy = _capacity;
        UpdateEnergy(_energy);;
    }
    
    //struct
    [Serializable]
    private struct LightSaberInfo
    {
        public Transform tf;
        public Axis      axisScale;
    }
}
