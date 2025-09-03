// Ky script lejon lojtarin të zgjedhë dhe ngarkojë nivele nga një dropdown menu.
// Kur zgjidhet një nivel (jo opsioni i parë), ngarkohet skena përkatëse me emër.

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public Dropdown levelDropdown;

    void Start()
    {
        // Shtohet funksioni që do thirret kur ndryshohet zgjedhja në dropdown
        levelDropdown.onValueChanged.AddListener(OnDropdownChanged);
    }

    public void OnDropdownChanged(int index)
    {
        if (index == 0) return; // Mos bëj asgjë nëse është zgjedhur opsioni i parë (p.sh. "Zgjidh nivelin")

        string selectedLevel = levelDropdown.options[index].text;
        Debug.Log("Loading: " + selectedLevel);
        SceneManager.LoadScene(selectedLevel); // Ngarkon skenën me emrin e zgjedhur
    }
}
