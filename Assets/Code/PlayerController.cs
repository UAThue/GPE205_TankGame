using UnityEngine;

public class PlayerController : Controller
{
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode rotateClockwiseKey;
    public KeyCode rotateCounterClockwiseKey;
    public KeyCode shootKey = KeyCode.Space;

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
