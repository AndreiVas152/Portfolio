using System.Collections.Generic;
using Auras;
using UnityEngine;

namespace Behaviours
{
    public class DamageCalculator : MonoBehaviour
    {
        private int _offensivePower;
        private int _defensivePower;
        private readonly float _offensiveMultiplier = 1.0f;
        private readonly float _defensiveMultiplier = 1.0f;

        public int CalculateDamageOutput(int baseDamage, List<Aura> _activeAuras)
        {
            var finalOffensiveMultiplier = _offensiveMultiplier;
            var finalOffensivePower = _offensivePower;

            for (var i = _activeAuras.Count - 1; i >= 0; i--)
            {
                if (_activeAuras[i].MagnitudeOffensive.HasValue)
                {
                    finalOffensiveMultiplier *= _activeAuras[i].MagnitudeOffensive.Value;
                }

                if (_activeAuras[i].PowerOffensive.HasValue)
                {
                    finalOffensivePower += _activeAuras[i].PowerOffensive.Value;
                }
            }

            var finalDamage = Mathf.CeilToInt((baseDamage + finalOffensivePower) * finalOffensiveMultiplier);
            
            return finalDamage;
        }

        public int CalculateDamageTaken(int baseDamage, List<Aura> _activeAuras)
        {
            var finalDefensiveMultiplier = _defensiveMultiplier;
            var finalDefensivePower = _defensivePower;

            for (var i = _activeAuras.Count - 1; i >= 0; i--)
            {
                if (_activeAuras[i].MagnitudeDefensive.HasValue)
                {
                    finalDefensiveMultiplier *= _activeAuras[i].MagnitudeDefensive.Value;
                }

                if (_activeAuras[i].PowerDefensive.HasValue)
                {
                    finalDefensivePower += _activeAuras[i].PowerDefensive.Value;
                }
            }

            var finalDamage = Mathf.CeilToInt((baseDamage - finalDefensivePower) * finalDefensiveMultiplier);

            return finalDamage;
        }

        // Other damage-related methods
    }
}