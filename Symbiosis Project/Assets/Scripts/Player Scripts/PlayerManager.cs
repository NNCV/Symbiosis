using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    
    public PlayerState[] totalPlayerStates;
    public LevelScript[] totalLevels;

    public int currentLevel;
    public int currentPlayerState;



    //LEVEL LOADING AND PLAYER SWITCHING

    public void loadLevel(int lvl)
    {
        //Claering up the old level
        foreach (GameObject lv in GameObject.FindGameObjectsWithTag("LEVEL"))
        {
            Destroy(lv);
        }

        //Loading in the new level
        Instantiate(totalLevels[currentLevel]);

        //Setting the spawn position
        transform.position = totalLevels[currentLevel].playerSpawn.position;
    }
    
    public void switchToPlayerState(int ps)
    {
        currentPlayerState = ps;
        
        //Clearing up whatever is under the Player GameObject (the actual playerstate)
        foreach (Transform ch in transform.GetComponentInChildren<Transform>())
        {
            Destroy(ch);
        }
        
        //Loading in the new Player GameObject
        Instantiate(totalPlayerStates[currentPlayerState].playerObject, transform);

        //Focusing the camera
        Camera.main.GetComponent<CameraMovementManager>().target = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).transform;
    }
    


    //INITIALIZATION

    public void Start()
    {
        //LoadGame();
        loadLevel(currentLevel);
        switchToPlayerState(currentPlayerState);
    }
    


    //SAVE AND LOAD
    //just in case we want to do more than simple things like saving the level and the playerstate,
    //I put them in functions and not just directly call what we want from 200 places

    public void SaveGame()
    {
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        PlayerPrefs.SetInt("CurrentPlayerState", currentPlayerState);
    }

    public void LoadGame()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        currentPlayerState = PlayerPrefs.GetInt("CurrentPlayerState");
    }
}
