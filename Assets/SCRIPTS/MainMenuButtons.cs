using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuButtons : MonoBehaviour
{
    //StartGame() goes straight into the Tutorial_Level scene
    public void StartGame()
    {
        SceneManager.LoadScene(0);
        SceneManager.LoadSceneAsync("Tutorial_level");
    }
    //BackButton() goes back to the Main Menu scene
    public void BackButton()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }
    //ControlsButton() goes to the Controls Menu scene
    public void ControlsButton()
    {
        SceneManager.LoadSceneAsync("Controls Menu");
    }
    //MainStoryDetsButton() goes to the Main Story Dets Menu scene
    public void MainStoryDetsButton()
    {
        SceneManager.LoadSceneAsync("Main Story Dets Menu");
    }
    //EndCreditsButton() goes to the End Credits Scene Menu
    public void EndCreditsButton()
    {
        SceneManager.LoadSceneAsync("End Credits Scene");
    }
}
