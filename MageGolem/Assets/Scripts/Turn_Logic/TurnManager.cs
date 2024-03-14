using System.Collections;
using System.Collections.Generic;
using Behaviours;
using CardScripts;
using Enemies;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Turn_Logic
{
    public class TurnManager : MonoBehaviour
    {
        public TurnState currentState;

        private List<EnemyActor> _enemies;

        private PlayerActor _player;

        private int _currentEnemyIndex = 0;

        private CardManager _cardManager;

        public Button endTurnButton;

        void Start()
        {
            _player = FindObjectOfType<PlayerActor>();
            _enemies = new List<EnemyActor>(FindObjectsOfType<EnemyActor>());
            _cardManager = FindObjectOfType<CardManager>();

            if (endTurnButton != null)
            {
                endTurnButton.onClick.AddListener(EndTurn);
            }

            UpdateButtonState();
            StartPlayerTurn();
        }

        public void EndTurn()
        {
            if (currentState == TurnState.PlayerTurn)
            {
                StartEnemyTurn();
            }
            else if (currentState == TurnState.EnemyTurn)
            {
                StartPlayerTurn();
            }

            UpdateButtonState();
        }

        private void StartPlayerTurn()
        {
            currentState = TurnState.PlayerTurn;
            foreach (var EnemyActor in _enemies)
            {
                EnemyActor.ShowIntent();
            }

            _player.DoPlayerTurn();
            _cardManager.CanPlayCards();
        }

        private void StartEnemyTurn()
        {
            currentState = TurnState.EnemyTurn;
            _player.EndPlayerTurn();
            
            for(int i = _enemies.Count - 1; i >= 0; i--)
            {
                if (_enemies[i] == null)
                {
                    _enemies.RemoveAt(i);
                }
            }
            _cardManager.CanPlayCards();
            ProcessNextEnemy();
        }

        void UpdateButtonState()
        {
            if (endTurnButton != null)
            {
                endTurnButton.interactable = (currentState == TurnState.PlayerTurn);
            }
        }

        public void RemoveEnemyFromTurnManager(EnemyActor enemyToRemove)
        {
            _enemies.Remove(enemyToRemove);
        }

        private void ProcessNextEnemy()
        {                
                if (_currentEnemyIndex < _enemies.Count)
                {
                    StartCoroutine(EnemyTurnRoutine());
                }
                else
                {
                    _currentEnemyIndex = 0;
                    EndTurn();
                }                    
        }

        private IEnumerator EnemyTurnRoutine()
        {            
            yield return StartCoroutine(_enemies[_currentEnemyIndex].DoEnemyTurn());
            _currentEnemyIndex++;
            ProcessNextEnemy();
        }
    }
}