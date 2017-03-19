using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public bool isTimed = false;
    public float lifeTime = 5f;

    protected Player player = null;

    protected virtual void Init()
    {
        if (isTimed)
            Destroy(this, lifeTime);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
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
                po.player = other.gameObject.GetComponent<Player>();
                po.Init();

                // Destroy the power-up collectable object
                Destroy(gameObject);
            }
        }
    }
}