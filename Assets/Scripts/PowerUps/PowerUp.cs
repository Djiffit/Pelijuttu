using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public bool isTimed = false;
    public bool respawns = true;
    public float lifeTime = 5f;

    protected GameObject player = null;
    protected GameObject collectableObject;
    protected PlayerController playerController = null;

    public AudioClip activationSound;

    protected virtual void Init()
    {
        if (isTimed)
            Destroy(this, lifeTime);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(activationSound, transform.position);

            // The type of this power-up
            System.Type type = this.GetType();

            if (!other.gameObject.GetComponent(type))
            { 
                // Add new component of type to the player object
                PowerUp po = (PowerUp)other.gameObject.AddComponent(type);

                // Copy this object's fields to the new component in player
                System.Reflection.FieldInfo[] fields = type.GetFields();
                foreach (System.Reflection.FieldInfo field in fields)
                {
                    field.SetValue(po, field.GetValue(this));
                }

                // Attach player to the power-up and initialize
                po.player = other.gameObject;
                po.playerController = other.gameObject.GetComponent<PlayerController>();
                po.Init();

                // Attach this collectable object
                po.collectableObject = gameObject;
                gameObject.SetActive(false);
            }
        }
    }

    protected virtual void OnDestroy()
    {
        if (respawns  && collectableObject != null)
            collectableObject.SetActive(true);
    }
}