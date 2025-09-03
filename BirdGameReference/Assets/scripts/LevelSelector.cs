// Ky script lejon lojtarin t� zgjedh� dhe ngarkoj� nivele nga nj� dropdown menu.
// Kur zgjidhet nj� nivel (jo opsioni i par�), ngarkohet skena p�rkat�se me em�r.

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public Dropdown levelDropdown;

    void Start()
    {
        // Shtohet funksioni q� do thirret kur ndryshohet zgjedhja n� dropdown
        levelDropdown.onValueChanged.AddListener(OnDropdownChanged);
    }

    public void OnDropdownChanged(int index)
    {
        if (index == 0) return; // Mos b�j asgj� n�se �sht� zgjedhur opsioni i par� (p.sh. "Zgjidh nivelin")

        string selectedLevel = levelDropdown.options[index].text;
        Debug.Log("Loading: " + selectedLevel);
        SceneManager.LoadScene(selectedLevel); // Ngarkon sken�n me emrin e zgjedhur
    }
}
