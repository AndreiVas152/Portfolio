using System;
using System.Collections.Generic;
using CardScripts;
using Unity.VisualScripting;
using UnityEngine;

namespace Cards
{
    public class Initializer : MonoBehaviour
    {
        public Canvas canvas;
        private List<GameObject> _cardList = new();
        public GameObject handPrefab;
        private GameObject _hand;
        private void Awake()
        {
            _hand = Instantiate(handPrefab, transform.position, Quaternion.identity, canvas.transform);
            LoadCards();
            
            _cardList.Sort((a,b) => a.transform.position.x.CompareTo(b.transform.position.x));
        }
        
        public List<GameObject> GetCardList()
        {
            return _cardList;
        }

        private void LoadCards()
        {
            foreach(Transform card in _hand.transform)
            {
                card.gameObject.SetActive(false);
                _cardList.Add(card.gameObject);
            }
        }
    }
}