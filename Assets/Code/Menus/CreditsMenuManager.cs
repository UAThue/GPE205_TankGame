using UnityEngine;

public class CreditsMenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBackToMenuButtonPressed()
    {
        // TODO: ??? Do we need to do anything special when credits end? Maybe? 
        // TODO: Achievement for watching them?

        // Go back to main menu
        GameManager.instance.ActivateMainMenu();
    }
}
