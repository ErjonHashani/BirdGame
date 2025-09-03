// Ky script kontrollon nëse të gjithë armiqtë janë mposhtur për të përfunduar nivelin.
// Nëse është niveli i fundit, shfaq mesazhin e fitores dhe kthehet në fillim.
// Përndryshe, kalon në nivelin tjetër.

using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private Enemy[] _enemies;
    public GameObject winMessage;
    public static bool levelCompleted = false;

    private void Start()
    {
        levelCompleted = false; // Rinis statusin e fitores në çdo nivel të ri
    }

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>(); // Gjen të gjithë armiqtë në skenë
    }

    void Update()
    {
        if (levelCompleted) return;

        // Kontrollon nëse ka ndonjë armik të mbetur
        foreach (Enemy enemy in _enemies)
        {
            if (enemy != null)
                return;
        }

        levelCompleted = true; // Niveli është përfunduar

        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        // Nëse është niveli i fundit (Level5), shfaq fitore dhe kthehet në fillim
        if (SceneManager.GetActiveScene().name == "Level5")
        {
            if (winMessage != null)
                winMessage.SetActive(true);

            Invoke("ReturnToStart", 3f); // E kthen në menynë kryesore pas 3 sekondash
        }
        else
        {
            SceneManager.LoadScene(nextIndex); // Kalo në nivelin tjetër
        }
    }

    void ReturnToStart()
    {
        SceneManager.LoadScene(0); // Kthehet në skenën 0 (menyja ose Level1)
    }
}
