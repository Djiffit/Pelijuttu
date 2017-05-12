using UnityEngine;

public class Collectable : MonoBehaviour
{
    public AudioClip activationSound;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(activationSound, transform.position);
            Destroy(gameObject);
        }
    }
}