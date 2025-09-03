// Ky script kontrollon sjelljen e zogut n� loj� (si n� Angry Birds).
// Lejon p�rdoruesin ta t�rheq� dhe ta l�shoj� zogun, dhe rifillon nivelin n�se zogu ngec ose del jasht� kufijve.

using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Vector3 _initialPosition; // Pozicioni fillestar i zogut
    private bool _birdWasLaunched;    // A �sht� l�shuar zogu?
    private float _timeSittingAround; // Koha q� zogu ka q�ndruar pa l�vizur

    [SerializeField] private float _launchPower = 500; // Fuqia e l�shimit

    private void Awake()
    {
        _initialPosition = transform.position; // Ruaj pozicionin fillestar
    }

    private void Update()
    {
        // N�se niveli ka p�rfunduar, mos b�j asgj�
        if (LevelController.levelCompleted)
            return;

        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
        GetComponent<LineRenderer>().SetPosition(0, transform.position);

        // N�se zogu �sht� l�shuar dhe �sht� ngadal�suar shum�
        if (_birdWasLaunched && GetComponent<Rigidbody2D>().linearVelocity.magnitude <= 0.1f)
        {
            _timeSittingAround += Time.deltaTime;
        }

        // Rifillo nivelin n�se zogu del jasht� kufijve ose ka q�ndruar pa l�vizur p�r shum� koh�
        if (
            transform.position.y > 20 || transform.position.y < -10 ||
            transform.position.x > 30 || transform.position.x < -15 ||
            _timeSittingAround > 3f)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    private void OnMouseDown()
    {
        if (LevelController.levelCompleted) return;

        GetComponent<LineRenderer>().enabled = true;
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnMouseUp()
    {
        if (LevelController.levelCompleted) return;

        GetComponent<SpriteRenderer>().color = Color.white;

        // Llogarit drejtimin p�r ta shtyr� zogun mbrapsht drejt pozicionit fillestar
        Vector2 directionToInitialPosition = _initialPosition - transform.position;

        // Shto forc� dhe aktivizo gravitetin
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdWasLaunched = true;

        GetComponent<LineRenderer>().enabled = false;
    }

    private void OnMouseDrag()
    {
        if (LevelController.levelCompleted) return;

        // Lejon p�rdoruesin t� t�rheq� zogun me maus
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
}
