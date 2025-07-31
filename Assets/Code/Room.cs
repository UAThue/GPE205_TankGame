using UnityEngine;

public class Room : MonoBehaviour
{
    // Store my walls (doors) so they can be easily accessed in code
    public GameObject doorNorth;
    public GameObject doorSouth; 
    public GameObject doorEast; 
    public GameObject doorWest;

    // TODO: If I have waypoints in this room, store them as part of the room
    // TODO: If I have extra info about the room -- like maybe it's a treasure room or a boss fight, store that, too.
    public int difficultyLevel;
}
