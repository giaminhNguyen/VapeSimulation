using System;
using UnityEngine;
using UnityHelper;

namespace _GameAssets._Scripts.ObjectSimulation
{
    public abstract class ObjectSimulationBase : MonoBehaviour
    {
        #region Properties

        protected bool  _ísReload;
        protected float _capacity;
        protected bool  _onRotateMode;
        protected bool  _hasData;

        #endregion
        
        
        protected virtual void OnEnable()
        {
            _hasData = DataGame.Instance;
            EventDispatcher.Instance.RegisterListener(EventID.RotateMode, OnRotateMode);
            EventDispatcher.Instance.RegisterListener(EventID.DefaultMode, OnDefaultMode);
            GetObjectBase();
        }

        
        protected virtual void OnDisable()
        {
            EventDispatcher.Instance.RemoveListener(EventID.RotateMode, OnRotateMode);
            EventDispatcher.Instance.RemoveListener(EventID.DefaultMode, OnDefaultMode);
        }

        protected virtual void Start()
        {
        }

        protected virtual void Update()
        {
        }

        private void OnDefaultMode(object obj)
        {
            _onRotateMode = false;
        }

        private void OnRotateMode(object obj)
        {
            _onRotateMode = true;
        }

        protected virtual void UpdateEnergy(float energy)
        {
            EventDispatcher.Instance.PostEvent(EventID.UpdateEnergy,energy);
        }

        protected virtual void UpdateEnergy(int energy)
        {
            EventDispatcher.Instance.PostEvent(EventID.UpdateEnergy,energy);
        }

        protected abstract void GetObjectBase();
        public abstract void OnReload(object obj);
    }
}