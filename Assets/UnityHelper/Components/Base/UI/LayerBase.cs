using System;
using UnityEngine;
using UnityEngine.Events;

namespace UnityHelper
{
   
    public abstract class LayerBase : MonoBehaviour
    {
        #region Properties
        [SerializeField]
        protected GameObject _content;

        [Header("Event")]
        public UnityEvent eventUnityOpen;

        public UnityEvent eventUnityClose;

        public Action actionOpen;
        public Action actionClose;
        
        protected bool _hasContent;
        
        #endregion
        
        protected virtual void Awake()
        {
            _hasContent = _content;
            InitAwake();
        }

        protected virtual void OnValidate()
        {
            if (!_content)
            {
                _content = gameObject;
            }
        }

        protected virtual void OnEnable()
        {
            InitOnEnable();
        }

        protected virtual void Start()
        {
            InitStart();
        }

        protected abstract void InitAwake();
        protected abstract void InitOnEnable();
        protected abstract void InitStart();
        
        public abstract void Init();

        public virtual void Open()
        {
            eventUnityOpen?.Invoke();
            actionOpen?.Invoke();
        }

        public virtual void Close()
        {
            eventUnityClose?.Invoke();
            actionClose?.Invoke();
        }

    }
}