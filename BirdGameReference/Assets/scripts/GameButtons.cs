// Ky script kontrollon veprimet e butonave: rifillimin e nivelit aktual, rifillimin e loj�s nga fillimi dhe daljen nga loja.

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButtons : MonoBehaviour
{
    public void RestartCurrentLevel()
    {
        // Rifillon nivelin aktual
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void RestartWholeGame()
    {
        // E nis loj�n nga niveli i par�
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        // Dalje nga loja
        Debug.Log("Quit button pressed. Exiting game...");
        Application.Quit();
    }
}
