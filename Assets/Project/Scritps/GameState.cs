using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class GameState : MonoBehaviour {

    public int WinTreshold = 8;

    public List<PlayerInventory> PlayerInventories = new List<PlayerInventory>();

    private void Update()
    {
        var winner = PlayerInventories.FirstOrDefault(pi => pi.PickupCount >= WinTreshold);
        if (winner != null)
        {
            //notify winner
            winner.RpcPlayerWin();
            //GO for the others
            foreach (var looser in PlayerInventories)
            {
                if (looser != winner)
                {
                    looser.RpcPlayerLost();
                }
            }
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            NetworkManager.Shutdown();
            Application.Quit();
        }
    }
}
