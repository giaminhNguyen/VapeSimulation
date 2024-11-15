using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityHelper;
using VInspector;
using EventDispatcher = UnityHelper.EventDispatcher;

namespace _GameAssets._Scripts.InGame.UI
{
    public class CapacityController : MonoBehaviour
    {
        [Header("Capacity")]
        [SerializeField,Variants("Text","Slider")]
        private string _type;
        
        [SerializeField]
        private TMP_Text _capacityText;
        
        [SerializeField]
        private Image _capacitySliderImage;


        private void OnEnable()
        {
            EventDispatcher.Instance.RegisterListener(EventID.UpdateEnergy, UpdateEnergy);
        }
        
        private void OnDisable()
        {
            EventDispatcher.Instance.RemoveListener(EventID.UpdateEnergy, UpdateEnergy);
        }

        private void UpdateEnergy(object obj)
        {
            if (_type.Equals("Text"))
            {
                var bullet = (int)obj;
                _capacityText.text = $"x {bullet}";
            }
            else
            {
                var energy = (float)obj;
                _capacitySliderImage.fillAmount = energy;
            }
        }
        
    }
}