using UnityEngine;
using UnityEngine.Networking;

public class PlayerInventory : NetworkBehaviour {
    [SyncVar]
    public int PickupCount = 0;

    public override void OnStartLocalPlayer()
    {
        FindObjectOfType<UIPoints>().playerInventory = this;
    }

    public override void OnStartServer()
    {
        FindObjectOfType<GameState>().PlayerInventories.Add(this);
    }

    [ClientRpc]
    public void RpcPlayerWin()
    {
        if (isLocalPlayer)
            Debug.Log("Nyertél! :D");
    }

    [ClientRpc]
    public void RpcPlayerLost()
    {
        if (isLocalPlayer)
        {
            Debug.Log("Vesztettél! :(");
            FindObjectOfType<UIGameOver>().Show();
        }
    }
}
