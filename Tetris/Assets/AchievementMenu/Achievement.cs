using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Achievement : MonoBehaviour
{
    private int totalBlocks = 500;
    private int ScoreOver20times = 10;


    public bool CheckIfDone(int requirement, int value)
    {
        if (requirement < value)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void ChangeVisibility(bool isSilver,string componentName)
    {
        GameObject tochange = GameObject.Find(componentName);

        if (isSilver == true)
        {
            tochange.transform.Find("Silver").gameObject.SetActive(true);
            tochange.transform.Find("Locked").gameObject.SetActive(false);
        }
        if(isSilver == false)
        {
            tochange.transform.Find("Gold").gameObject.SetActive(true);
            tochange.transform.Find("Locked").gameObject.SetActive(false);
        }
        tochange.transform.Find("Icon").gameObject.SetActive(true);
    }

    public Player player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        player.LoadPlayer();

        if (CheckIfDone(totalBlocks, player.blocksPlaced) == true)
        {
            ChangeVisibility(true, "500Blocks");
        }

        if (CheckIfDone(ScoreOver20times, player.scoreOver20Times) == true)
        {
            ChangeVisibility(false, "20Score10Times");

        }
        if(player.hasPlayedAGame == true)
        {
            ChangeVisibility(false, "FirstGame");
        }
    }

}
