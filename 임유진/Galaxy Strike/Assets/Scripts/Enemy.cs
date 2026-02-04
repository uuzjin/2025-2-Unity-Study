using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX; 
    [SerializeField] int hitPoints = 3;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPoints--;

        if (hitPoints <= 0)
        {
            Instantiate(destroyedVFX, transform.position, Quaternion.identity); // Quaternion.identity: (0,0,0), no default rotation
            Destroy(this.gameObject);
        }
    }
}
