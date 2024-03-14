using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Auras
{
    public class AuraFactory : MonoBehaviour
    {
        public static Aura GetAura(AuraEffect effect)
        {
            switch (effect)
            {
                case AuraEffect.MoreMultiplierOffense:
                    return new Aura(AuraEffect.MoreMultiplierOffense.ToString(), 3, magnitudeOffensive: 1.5f);
                case AuraEffect.LessMultiplierOffense:
                    return new Aura(AuraEffect.LessMultiplierOffense.ToString(), 3, magnitudeOffensive: 0.5f);
                case AuraEffect.LessMultiplierDefense:
                    return new Aura(AuraEffect.MoreMultiplierDefense.ToString(), 3, magnitudeDefensive: 1.5f);
                case AuraEffect.MoreMultiplierDefense:
                    return new Aura(AuraEffect.LessMultiplierDefense.ToString(), 3, magnitudeDefensive: 0.5f);
                case AuraEffect.MorePower:
                    return new Aura(AuraEffect.MorePower.ToString(), 3, powerOffensive: 3);
                case AuraEffect.LessPower:
                    return new Aura(AuraEffect.LessPower.ToString(), 3, powerOffensive: -3);
                case AuraEffect.MoreDefense:
                    return new Aura(AuraEffect.MoreDefense.ToString(), 3, powerDefensive: 3);
                case AuraEffect.LessDefense:
                    return new Aura(AuraEffect.LessDefense.ToString(), 3, powerDefensive: -3);
                default:
                    throw new ArgumentOutOfRangeException(nameof(effect), effect, null);
            }
        }
    }
}