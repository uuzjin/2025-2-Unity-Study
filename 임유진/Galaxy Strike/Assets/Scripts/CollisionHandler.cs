using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX; 

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Hit " + other.name);
        // Debug.Log($"Hit {other.gameObject.name}");

        Instantiate(destroyedVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
