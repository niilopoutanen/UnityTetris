using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    public int blocksPlaced;
    public int scoreOver20Times;
    public bool hasPlayedAGame;

    public PlayerData (Player player)
    {
        blocksPlaced = player.blocksPlaced;
        scoreOver20Times = player.scoreOver20Times;
        hasPlayedAGame = player.hasPlayedAGame;
    }
}
