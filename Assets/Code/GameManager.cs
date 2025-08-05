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

    [Header("Helper Objects")]
    public LevelGenerator levelGenerator;
    public Camera gameCamera;

    [Header("Gameplay State Objects")]
    public GameObject pressStartStateObject;
    public GameObject mainMenuStateObject;
    public GameObject playGameStateObject;
    public GameObject gameOverVictoryStateObject;
    public GameObject gameOverFailureStateObject;
    public GameObject gameOptionsStateObject;
    public GameObject creditsStateObject;

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
        // Start in our press start state
        ChangeGameplayState(pressStartStateObject);
    }

    private void ChangeGameplayState (GameObject gameplayStateObject)
    { 
        // Deactivate all states
        DeactivateAllStates();

        // Activate the new state to move into
        gameplayStateObject.SetActive(true);

    }

    private void DeactivateAllStates()
    {
        // Set all our state object to inactive
        pressStartStateObject.SetActive(false);
        mainMenuStateObject.SetActive(false);
        playGameStateObject.SetActive(false);
        gameOverVictoryStateObject.SetActive(false);
        gameOverFailureStateObject.SetActive(false);
        gameOptionsStateObject.SetActive(false);
        creditsStateObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateMainMenu()
    {
        // Change to the main menu state
        ChangeGameplayState(mainMenuStateObject);

        // TODO: Do anything we need to do when the main menu starts

    }

    public void ActivateGameplay()
    { 
        // Activate the object in the scene
        ChangeGameplayState(playGameStateObject);

        // TODO: Anything we need to do to start the game.  (Set score to zero? Set lives to? What? TBD!)
        // Generate our level
        levelGenerator.GenerateLevel();

        // Spawn our player
        SpawnPlayer(Vector3.zero);
    }

    public void ActivateOptionsScreen()
    {
        // Activate the object in the scene
        ChangeGameplayState(gameOptionsStateObject);
        // TODO: Anything we need to do
    }

    public void ActivateCreditsScreen()
    {
        // Activate the object in the scene
        ChangeGameplayState(creditsStateObject);
        // TODO: Anything we need to do
    }

    public void ActivateVictoryScreen()
    {
        // Activate the object in the scene
        ChangeGameplayState(gameOverVictoryStateObject);
        // TODO: Anything we need to do
    }

    public void ActivateLoseScreen()
    {
        // Activate the object in the scene
        ChangeGameplayState(gameOverFailureStateObject);
        // TODO: Anything we need to do
    }



    void SpawnPlayer (Vector3 spawnPosition)
    {
        // Instantiate ( Create an object and copy all the data from a prefab onto it ) the player controller
        GameObject tempPlayerControllerObject = Instantiate<GameObject>(playerControllerPrefab);
        // Move the Controller object to the origin
        tempPlayerControllerObject.transform.position = Vector3.zero; 
        // Get the controller component
        PlayerController tempPlayerController = tempPlayerControllerObject.GetComponent<PlayerController>();

        // Instantiate the player pawn
        GameObject tempPlayerPawnObject = Instantiate<GameObject>(playerPawnPrefab);
        // Get the pawn component
        TankPawn tempPlayerPawn = tempPlayerPawnObject.GetComponent<TankPawn>();
        // Move the player pawn to the spawn position
        tempPlayerPawnObject.transform.position = spawnPosition;

        // Connect the pawn to the controller (and set the camera)
        tempPlayerController.Possess(tempPlayerPawn);
    }
}
