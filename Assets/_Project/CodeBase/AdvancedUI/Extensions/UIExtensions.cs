using UnityEngine.Events;
using UnityEngine.UI;

namespace CodeBase.AdvancedUI.Extensions
{
    public static class UIExtensions
    {
        public static void AddListener(this Button button, UnityAction callback) => 
            button.onClick.AddListener(callback);
        
        public static void RemoveListener(this Button button, UnityAction callback) => 
            button.onClick.RemoveListener(callback);
    }
}