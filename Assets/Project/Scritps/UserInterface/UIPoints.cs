using UnityEngine;
using UnityEngine.UI;

public class UIPoints : MonoBehaviour {

    private int _maxPickups;
    public PlayerInventory playerInventory;
    private Text _text;

    private void Awake()
    {
        _maxPickups = FindObjectsOfType<Pickup>().Length;
        _text = GetComponent<Text>();
    }

    private void Update()
    {
        if (playerInventory != null)
        {
            _text.text = "Score: " + playerInventory.PickupCount + " / " + _maxPickups;
        }
    }
}
