using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool playerCanMove = true;

    public bool IsPlayerMovementAllowed()
    {
        return playerCanMove;
    }
}
