using UnityEngine;

public class Pickup : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerInventory>().PickupCount++;
            gameObject.SetActive(false);
        }
    }
}
