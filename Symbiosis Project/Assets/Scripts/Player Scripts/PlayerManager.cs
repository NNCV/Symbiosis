using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    
    public PlayerState[] totalPlayerStates;

    public int currentPlayerState;

    public void switchToPlayerState(int ps)
    {
        currentPlayerState = ps;
        
        //Clearing up whatever is under the Player gameobject (the actual playerstate)
        foreach (Transform ch in transform.GetComponentInChildren<Transform>())
        {
            Destroy(ch);
        }
        
        Instantiate(totalPlayerStates[currentPlayerState].playerObject, transform);
    }
    
    //let's initialize everything first
    //this will look different once we add in the save/load system
    public void Start()
    {
        Instantiate(totalPlayerStates[currentPlayerState].playerObject, transform);
    }
}
