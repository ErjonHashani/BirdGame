// Ky script kontrollon sjelljen e armikut kur përplaset me objekte.
// Armiku shkatërrohet kur goditet nga Zogu ose nga lart, dhe shfaq efektin "cloud".

using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _cloudParticlePrefab; // Prefab për efektin kur armiku shkatërrohet

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Nëse përplaset me zogun
        Bird bird = collision.collider.GetComponent<Bird>();
        if (bird != null)
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }

        // Mos bëj asgjë nëse përplaset me armik tjetër
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            return;
        }

        // Nëse goditet nga lart, shkatërrohet
        if (collision.contacts[0].normal.y < -0.5)
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }
    }
}
