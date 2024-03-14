using System.Collections.Generic;
using System.Linq;
using Auras;
using Unity.VisualScripting;
using UnityEngine;

namespace Behaviours
{
    public class AuraManager : MonoBehaviour
    {
        private List<Aura> _activeAuras = new List<Aura>();
        private AuraBar _auraBar;
        public GameObject auraBarPrefab;
        public GameObject currentAuraBar;

        public AuraBar InitializeAuraBar(GameObject parent)
        {
            currentAuraBar = Instantiate(auraBarPrefab, transform.position + new Vector3(0, -16, 0), Quaternion.identity, parent.transform);
            _auraBar = currentAuraBar.GetComponent<AuraBar>();
            return _auraBar;
        }

        public List<Aura> AddAura(Aura auraToAdd)
        {
            var active = _activeAuras.FirstOrDefault(a => a.AuraName == auraToAdd.AuraName);
            if (active != null)
            {
                active.Duration += auraToAdd.Duration;
            }
            else
            {
                _activeAuras.Add(auraToAdd);
            }
            UpdateAuraDisplay();

            return _activeAuras;
        }

        public void TickDownBuffs()
        {
            for (int i = _activeAuras.Count() - 1; i >= 0; i--)
            {
                _activeAuras[i].Duration--;

                if (_activeAuras[i].Duration <= 0)
                {
                    _activeAuras.RemoveAt(i);
                }
            }
            UpdateAuraDisplay();
        }

        public void UpdateAuraDisplay()
        {
            _auraBar.UpdateAuras(_activeAuras);
            _auraBar.RefreshIconDisplays();
        }

        // Other aura-related methods
    }
}