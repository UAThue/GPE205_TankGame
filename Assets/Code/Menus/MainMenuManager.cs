using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartButtonPressed()
    {
        GameManager.instance.ActivateGameplay();
    }

    public void OnCreditsButtonPressed()
    {
        GameManager.instance.ActivateCreditsScreen();
    }

    public void OnOptionsButtonPressed()
    {
        GameManager.instance.ActivateOptionsScreen();
    }

    public void OnQuitButtonPressed()
    {
        // Quit the game
        Application.Quit();
    }
}
