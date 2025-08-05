using UnityEngine;

public class PlayerController : Controller
{
    [Header("Input Keys")]
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode rotateClockwiseKey;
    public KeyCode rotateCounterClockwiseKey;
    public KeyCode shootKey = KeyCode.Space;

    [Header("Camera Data")]
    [Tooltip("Vector is Local to pawn")] public Vector3 cameraOffset;
    [Tooltip("Vector is Local to pawn")] public Vector3 cameraAimOffset;
    public Camera playerCamera;

    public void Awake()
    {
        // Add us to the GameManager list
        GameManager.instance.players.Add(this);
        // Change our object name
        gameObject.name = "Player " + GameManager.instance.players.Count;
    }

    public override void Start()
    {
    }

    public override void Update()
    {
        // Make a decision every frame draw. Note that AI's may make decisions at a slower rate.
        MakeDecisions();
    }

    public void Possess ( Pawn pawnToPossess )
    {
        // Possess the pawn
        pawn = pawnToPossess;

        // Setup our camera (if it exists)
        if (playerCamera != null)
        {
            // Attach the camera to the player
            // Move the camera to the offset
            Vector3 cameraWorldOffset = pawn.transform.TransformDirection(cameraOffset);
            playerCamera.transform.position = pawn.transform.position + cameraWorldOffset;
            // Make camera look at the player's aim offset based on the direction the player is facing
            Vector3 playerWorldAimOffset = pawn.transform.TransformDirection(cameraAimOffset);
            playerCamera.transform.LookAt(pawn.transform.position + playerWorldAimOffset);
            // Attach the camera to the player so it follows it around the game
            playerCamera.transform.parent = pawn.transform;
        }

    }


    public void OnDestroy()
    {
        // Remove us from the GameManager list
        GameManager.instance.players.Remove(this);
    }
    public override void MakeDecisions()
    {
        if (Input.GetKey(moveForwardKey))
        {
            pawn.MoveForward();
        }

        if (Input.GetKey(moveBackwardKey))
        {
            pawn.MoveBackward();
        }

        if (Input.GetKey(rotateClockwiseKey))
        {
            pawn.RotateClockwise();
        }

        if (Input.GetKey(rotateCounterClockwiseKey))
        {
            pawn.RotateCounterClockwise();
        }

        if (Input.GetKeyDown(shootKey))
        {
            pawn.Shoot();
        }
    }
}
