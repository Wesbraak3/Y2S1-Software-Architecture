using System;
using UnityEngine;
using Core.Input;
using Entity.Player;

namespace Core {
    public class GameBootstrapper : MonoBehaviour
    {
        private InputHandler _input;
        
        [Header("Scene Settings")]
        [SerializeField] private InputContext context = InputContext.Gameplay;
        [SerializeField] private bool spawnPlayer = true;
        
        [Header("Player Settings")]
        [SerializeField] private PlayerView playerPrefab;
        // [SerializeField] private PlayerSaveData saveData;
        [SerializeField] private Transform spawnPoint;

        private PlayerPresenter _player;

        private void Awake()
        {
            _input = InputHandler.Instance;
            _input.SetContext(context);
            
            if (spawnPlayer) SpawnPlayer();
        }

        private void OnDestroy()
        {
            _input.Dispose();
        }

        private void SpawnPlayer()
        {
            Debug.Log("Spawning Player");
            if (playerPrefab == null) Debug.LogError("No playerPrefab assigned!");

            PlayerView playerView = Instantiate(playerPrefab, transform.position, transform.rotation);
            PlayerModel playerModel = new PlayerModel(5);
            _player = new PlayerPresenter(playerView, playerModel, _input);
        }
    }
}