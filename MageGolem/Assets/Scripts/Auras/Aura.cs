using System;

namespace Auras
{
    [Serializable]
    public class Aura
    {
        public Aura(string auraName, int duration = 3, float? magnitudeOffensive = null,
            float? magnitudeDefensive = null, int? powerOffensive = null, int? powerDefensive = null)
        {
            AuraName = auraName;
            Duration = duration;
            MagnitudeOffensive = magnitudeOffensive;
            MagnitudeDefensive = magnitudeDefensive;
            PowerOffensive = powerOffensive;
            PowerDefensive = powerDefensive;
        }

        public Aura()
        {
            
        }

        public string AuraName { get; set; }

        public float? MagnitudeOffensive { get; set; }

        public float? MagnitudeDefensive { get; set; }

        public int? PowerOffensive { get; set; }

        public int? PowerDefensive { get; set; }
        public int Duration { get; set; }
    }
}