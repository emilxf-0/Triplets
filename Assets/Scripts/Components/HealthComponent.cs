using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private bool isPlayer;
    private float currentHealth;
    private float updatedHealth;

    public float CurrentHealth()
    {
        return currentHealth;
    }

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void GainLife(float health)
    {
        currentHealth += health;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (isPlayer)
        {
            UpdateHealth();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (isPlayer)
        {
            UpdateHealth();
        }


        if (currentHealth <= 0)
        {
            if (isPlayer)
            {
                EventManager.GameOver();
            }

            Destroy(gameObject);
        }
    }

    void UpdateHealth()
    {
        updatedHealth = currentHealth / maxHealth;
        EventManager.UpdateHealth(updatedHealth);
    }
}
