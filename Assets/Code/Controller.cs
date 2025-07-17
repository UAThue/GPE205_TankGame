using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    // Variable to hold our Pawn
    public Pawn pawn;

    // Start is called before the first frame update
    public abstract void Start();
    // Update is called once per frame
    public abstract void Update();

    public abstract void MakeDecisions();
}