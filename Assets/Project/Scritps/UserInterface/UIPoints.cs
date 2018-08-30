using UnityEngine;
using UnityEngine.UI;

public class UIPoints : MonoBehaviour {

    private int _maxPickups;
    private PlayerInventory _playerInventory;
    private Text _text;

    private void Awake()
    {
        _maxPickups = GameObject.FindObjectsOfType<Pickup>().Length;
        _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        _text = GetComponent<Text>();
    }

    private void Update()
    {
        _text.text = "Score: " + _playerInventory.PickupCount + " / " + _maxPickups;
    }
}
