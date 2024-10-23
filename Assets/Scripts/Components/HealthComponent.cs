using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private bool isPlayer;
    private float currentHealth;
    private float updatedHealth;

    void OnEnable()
    {
        EventManager.OnStartGame += SetHealthToMax;
    }

    void OnDisable()
    {
        EventManager.OnStartGame -= SetHealthToMax;
    }

    public float CurrentHealth()
    {
        return currentHealth;
    }

    public float MaxHealth()
    {
        return maxHealth;
    }

    private void SetHealthToMax()
    {
        currentHealth = maxHealth;
    }

    void Awake()
    {
        SetHealthToMax();
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
