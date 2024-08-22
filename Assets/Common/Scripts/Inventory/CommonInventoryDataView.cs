using SuperMaxim.Core.Extensions;
using System;
using TMPro;
using UnityEngine;

namespace Common.Scripts.Inventory
{
    public class CommonInventoryDataView : MonoBehaviour
    {
        [SerializeField] private string _pattern;
        [SerializeField] private TextMeshProUGUI _txtAmount;
        public void Setup(float amount)
        {
            _txtAmount.text = _pattern.IsNullOrEmpty() ? amount.ToString() : String.Format(_pattern,amount);;
        }
    }
}
