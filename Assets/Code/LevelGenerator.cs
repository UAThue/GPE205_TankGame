using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public enum mapRandomizationType { Random, Seeded, MapOfTheDay };
    public mapRandomizationType randomizationType;
    public int mapSeed;

    private Room[,] grid; // List of all the rooms in the generated level
    public List<Room> roomPrefabs;
    public int numRows;
    public int numCols;
    public int tileWidth;
    public int tileHeight;



    public void SeedRandomNumberGenerator ()
    {
        // switch based on what type of randomization to use
        switch (randomizationType)
        {
            case mapRandomizationType.Random:
                Random.InitState((int)System.DateTime.Now.Ticks);
                break;
            case mapRandomizationType.Seeded:
                Random.InitState(mapSeed);
                break;
            case mapRandomizationType.MapOfTheDay:
                Random.InitState((int)System.DateTime.Today.Ticks);
                break;
        }

    }

    public void GenerateLevel()
    {
        // Create our level

        // Seed the random number generator
        SeedRandomNumberGenerator();

        // Make our Rooms array the correct size, based on our number rows and cols
        grid = new Room[numCols, numRows];

        // For every row...
        for (int currentRow = 0; currentRow < numRows; currentRow++)
        {
            // Look at every col in that row...
            for (int currentCol = 0; currentCol < numCols; currentCol++)
            {
                // Instantiate a room
                GameObject tempRoom = Instantiate(GetRandomRoomPrefab(), Vector3.zero, Quaternion.identity) as GameObject;

                // Move it to the correct position
                float xPosition = currentCol * tileWidth;
                float zPosition = currentRow * tileHeight;
                tempRoom.transform.position = new Vector3(xPosition, -1, -zPosition);

                // Save it in our grid
                grid[currentCol, currentRow] = tempRoom.GetComponent<Room>();

                // If bottom row (0) open the north door
                if (currentRow == 0)
                {
                    grid[currentCol, currentRow].doorSouth.SetActive(false);
                }
                // If top row (numRows - 1) open the south door
                else if (currentRow == numRows - 1)
                {
                    grid[currentCol, currentRow].doorNorth.SetActive(false);
                }
                // Otherwise, open both doors
                else
                {
                    grid[currentCol, currentRow].doorNorth.SetActive(false);
                    grid[currentCol, currentRow].doorSouth.SetActive(false);
                }

                if (currentCol == 0)
                {
                    grid[currentCol, currentRow].doorEast.SetActive(false);
                }
                else if (currentCol == numCols -1)
                {
                    grid[currentCol, currentRow].doorWest.SetActive(false);
                }
                else
                {
                    grid[currentCol, currentRow].doorEast.SetActive(false);
                    grid[currentCol, currentRow].doorWest.SetActive(false);
                }

            }
        }
    }

    public GameObject GetRandomRoomPrefab()
    {
        // Return a random room from the list
        Room randomRoom = roomPrefabs[Random.Range(0, roomPrefabs.Count)];

        // If the chosed difficulty for this game session is less than the difficulty level of the room, return it...
        // Otherwise, pick another random room

        return randomRoom.gameObject;
    }

}
