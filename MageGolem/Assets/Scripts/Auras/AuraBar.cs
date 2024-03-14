using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Auras
{
    public class AuraBar : MonoBehaviour
    {
        
        public GameObject auraIconPrefab;

        private readonly Queue<AuraIcon> _iconPool = new();
        private readonly List<AuraIcon> _activeIcons = new();

        public void UpdateAuras(List<Aura> activeAuras)
        {
            foreach (AuraIcon icon in _activeIcons)
            {
                _iconPool.Enqueue(icon);
                icon.gameObject.SetActive(false);
            }
            _activeIcons.Clear();

            // Create or reuse icons
            foreach (var aura in activeAuras)
            {
                var icon = GetOrCreateIcon();
                icon.Setup(aura);
                _activeIcons.Add(icon);
            }
        }

        private AuraIcon GetOrCreateIcon()
        {
            if (_iconPool.Count > 0)
            {
                AuraIcon pooledIcon = _iconPool.Dequeue();
                pooledIcon.gameObject.SetActive(true);
                return pooledIcon;
            }

            var newIconObj = Instantiate(auraIconPrefab, transform);
            return newIconObj.GetComponent<AuraIcon>();
        }
        
        public void RefreshIconDisplays()
        {
            foreach (AuraIcon icon in _activeIcons)
            {
                icon.UpdateDisplay();
            }
        }
        
    }
}