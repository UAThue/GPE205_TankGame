using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("Lists")]
    public List<PlayerController> players;
    public List<TankPawn> pawns;

    [Header("Prefabs")]
    public GameObject playerPawnPrefab;
    public GameObject playerControllerPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            // Set THIS instance of the Game Manager to our static variable
            instance = this;

            // Don't destroy this object when loading scene
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // An instance already exists, so self-destruct
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPlayer(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPlayer (Vector3 spawnPosition)
    {
        // Instantiate ( Create an object and copy all the data from a prefab onto it ) the player controller
        GameObject tempPlayerControllerObject = Instantiate<GameObject>(playerControllerPrefab);
        // Move the Controller object to the origin
        tempPlayerControllerObject.transform.position = Vector3.zero; 
        // Get the controller component
        PlayerController tempPlayerController = tempPlayerControllerObject.GetComponent<PlayerController>();
        // (MOVED THIS TO THE CONTROLLER!) 
        // players.Add(tempPlayerController);

        // Instantiate the player pawn
        GameObject tempPlayerPawnObject = Instantiate<GameObject>(playerPawnPrefab);
        // Get the pawn component
        TankPawn tempPlayerPawn = tempPlayerPawnObject.GetComponent<TankPawn>();
        // Move the player pawn to the spawn position
        tempPlayerPawnObject.transform.position = spawnPosition;

        // Connect the pawn to the controller
        tempPlayerController.pawn = tempPlayerPawn;
        // (MOVED THIS TO THE TANKPAWN) Add it to the list
        // pawns.Add(tempPlayerPawn);
    }
}
