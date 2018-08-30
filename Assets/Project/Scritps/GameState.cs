using System;
using System.Linq;
using UnityEngine;

public class GameState : MonoBehaviour {

    public int WinTreshold = 8;

    private PlayerInventory _playerInventory;
    private Pickup[] _pickups;

    private void Awake()
    {
        _pickups = FindObjectsOfType<Pickup>();
        _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }

    private void Update()
    {
        if (CanNotWin())
        {
            Debug.Log("Nem lehet nyerni...");
        }

        if (WinTreshold <= _playerInventory.PickupCount)
        {
            Debug.Log("A játékos nyert!");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public bool CanNotWin()
    {
        return _pickups.Count(p => p.isActiveAndEnabled) < WinTreshold - _playerInventory.PickupCount;
    }
}
