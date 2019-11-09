using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class ControlTest : MonoBehaviour
{
    int playerID = 0;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(playerID);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float AimX = player.GetAxis("AimHorizontal");
        float AimY = player.GetAxis("AimVertical");
    }
}
