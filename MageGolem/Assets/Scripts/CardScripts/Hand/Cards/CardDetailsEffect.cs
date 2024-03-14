using UnityEngine;
using UnityEngine.EventSystems;

namespace Events
{
    public class CardDetailsEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private Vector3 _originalScale;
        private Vector3 _originalPosition;
        private Vector3 _enlargedScale;
        private Canvas _overlayCanvas;
        private Canvas _originalCanvas;
        

        [SerializeField] private float enlargementFactor = 1.2f;
        [SerializeField] private float verticalLift = 10f;        
        
        private void Start()
        {
            _originalScale = transform.localScale;
            _originalPosition = transform.position;
            _enlargedScale = _originalScale * enlargementFactor;
            _overlayCanvas = GameObject.Find("OverlayCanvas").GetComponent<Canvas>();
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            _originalCanvas = GetComponentInParent<Canvas>();
            transform.localScale = _enlargedScale;
            transform.position += Vector3.up * verticalLift;
            transform.SetParent(_overlayCanvas.transform);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.localScale = _originalScale;
            transform.position = _originalPosition;
            transform.SetParent(_originalCanvas.transform);
        }
    }
   
}