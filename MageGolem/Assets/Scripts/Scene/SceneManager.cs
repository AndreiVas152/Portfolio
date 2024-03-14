using System.Collections.Generic;
using Behaviours;
using Enemies;
using UnityEngine;

namespace Scene
{
    public class SceneManager : MonoBehaviour
    {
        public GameObject placeholder;
        public static SceneManager Instance;
        public List<GameObject> enemyLocations;
        private EnemyManager enemyManager;
        public GameObject playerPrefab;
        private PlayerActor player;
        public Canvas worldSpaceCanvas;
        
        
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            } 
            enemyManager = GameObject.Find(nameof(EnemyManager)).GetComponent<EnemyManager>();
            enemyManager.SpawnEnemies(enemyLocations);
            
            player = Instantiate(playerPrefab, placeholder.transform.position, Quaternion.identity, parent: worldSpaceCanvas.transform).GetComponent<PlayerActor>();
            enemyManager.SetPlayer(player);
            
        }
    }
}