// Ky script kontrollon sjelljen e zogut në lojë (si në Angry Birds).
// Lejon përdoruesin ta tërheqë dhe ta lëshojë zogun, dhe rifillon nivelin nëse zogu ngec ose del jashtë kufijve.

using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Vector3 _initialPosition; // Pozicioni fillestar i zogut
    private bool _birdWasLaunched;    // A është lëshuar zogu?
    private float _timeSittingAround; // Koha që zogu ka qëndruar pa lëvizur

    [SerializeField] private float _launchPower = 500; // Fuqia e lëshimit

    private void Awake()
    {
        _initialPosition = transform.position; // Ruaj pozicionin fillestar
    }

    private void Update()
    {
        // Nëse niveli ka përfunduar, mos bëj asgjë
        if (LevelController.levelCompleted)
            return;

        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
        GetComponent<LineRenderer>().SetPosition(0, transform.position);

        // Nëse zogu është lëshuar dhe është ngadalësuar shumë
        if (_birdWasLaunched && GetComponent<Rigidbody2D>().linearVelocity.magnitude <= 0.1f)
        {
            _timeSittingAround += Time.deltaTime;
        }

        // Rifillo nivelin nëse zogu del jashtë kufijve ose ka qëndruar pa lëvizur për shumë kohë
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

        // Llogarit drejtimin për ta shtyrë zogun mbrapsht drejt pozicionit fillestar
        Vector2 directionToInitialPosition = _initialPosition - transform.position;

        // Shto forcë dhe aktivizo gravitetin
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdWasLaunched = true;

        GetComponent<LineRenderer>().enabled = false;
    }

    private void OnMouseDrag()
    {
        if (LevelController.levelCompleted) return;

        // Lejon përdoruesin të tërheqë zogun me maus
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
}
