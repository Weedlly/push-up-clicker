using SuperMaxim.Core.Extensions;
using System;
using TMPro;
using UnityEngine;

namespace Common.Scripts.Inventory
{
    public class CommonInventoryDataView : MonoBehaviour
    {
        [SerializeField] protected string _pattern;
        [SerializeField] protected TextMeshProUGUI _txtAmount;
        public virtual void Setup(float amount)
        {
            _txtAmount.text = _pattern.IsNullOrEmpty() ? amount.ToString() : String.Format(_pattern,amount);;
        }
    }
}
