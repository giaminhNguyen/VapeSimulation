using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UnityHelper
{
    [RequireComponent(typeof(DOTweenScale))]
    public class LayerPopup : LayerBase
    {
        #region Properties

        [Header("References")]

        [SerializeField]
        private DOTweenScale _doTweenScale;
        
        [SerializeField]
        private Image _dimImage;

        [SerializeField]
        private Button _btnClose;
    
        [Header("--")]
        [SerializeField]
        private float _animTimeDim = 0.3f;
        
        private bool _hasDim;

        private Tweener _dimTweener;

        private float _dimAlpha = 1;
        
        #endregion

        protected override void OnValidate()
        {
            base.OnValidate();
            _doTweenScale = GetComponent<DOTweenScale>();
        }

        protected override void InitAwake()
        {
            _hasDim     = _dimImage;

            if (_hasDim)
            {
                var color = _dimImage.color;
                _dimAlpha       = color.a;
                color.a         = 0;
                _dimImage.color = color;
                _dimTweener     = _dimImage.DOFade(_dimAlpha, _animTimeDim);
            }
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            Open();
        }

        protected override void InitOnEnable()
        {
            if (_hasDim)
            {
                var color = _dimImage.color;
                color.a         = 0;
                _dimImage.color = color;
            }
        }

        protected override void InitStart()
        {
        }

        public override void Init()
        {
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public override void Open()
        {
            base.Open();
            _dimTweener?.PlayForward();
            _doTweenScale.PlayForward();
        }

        public override void Close()
        {
            base.Close();
            _dimTweener?.PlayBackwards();
            _doTweenScale.PlayBackward();
        }
    }
}