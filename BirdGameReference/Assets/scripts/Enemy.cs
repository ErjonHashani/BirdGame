// Ky script kontrollon sjelljen e armikut kur p�rplaset me objekte.
// Armiku shkat�rrohet kur goditet nga Zogu ose nga lart, dhe shfaq efektin "cloud".

using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _cloudParticlePrefab; // Prefab p�r efektin kur armiku shkat�rrohet

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // N�se p�rplaset me zogun
        Bird bird = collision.collider.GetComponent<Bird>();
        if (bird != null)
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }

        // Mos b�j asgj� n�se p�rplaset me armik tjet�r
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            return;
        }

        // N�se goditet nga lart, shkat�rrohet
        if (collision.contacts[0].normal.y < -0.5)
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }
    }
}
