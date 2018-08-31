using UnityEngine;
using UnityEngine.Networking;

public class Pickup : NetworkBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isServer)
            {
                other.gameObject.GetComponent<PlayerInventory>().PickupCount++;
            }
            gameObject.SetActive(false);
        }
    }
}
