using UnityEngine;
using UnityEngine.SceneManagement;
public class RetryButton : MonoBehaviour
{
    public string gameScene = "Tutorial_Level";
    //Retry() just makes it so when the player clicks it goes back to the Tutorial_Level scene
    public void Retry()
    {
        SceneManager.LoadScene(gameScene);
    }
}
