using System.Security.Cryptography;
using UnityEngine;

namespace Animation
{
    public class PowEffect : MonoBehaviour
    {
        public float showDuration = 1f;
        
        public void Show()
        {
            gameObject.SetActive(true);
            Invoke(nameof(Hide), showDuration);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Test()
        {
            gameObject.SetActive(true);
        }
    }
}
