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
        if (_pickups.Count(p => p.isActiveAndEnabled)  < WinTreshold - _playerInventory.PickupCount)
        {
            Debug.Log("Nem lehet nyerni...");
        }

        if (WinTreshold <= _playerInventory.PickupCount)
        {
            Debug.Log("A játékos nyert!");
        }
    }
}
