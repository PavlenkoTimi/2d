using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f; // Максимальное здоровье врага
    private float currentHealth; // Текущее здоровье врага

    void Start()
    {
        currentHealth = maxHealth; // В начале игры здоровье полное
    }

    // Функция для получения урона
    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // Уменьшаем здоровье на величину урона
        Debug.Log(gameObject.name + " получил " + damage + " урона.  Текущее здоровье: " + currentHealth);

        // Проверяем, умер ли враг
        if (currentHealth <= 0)
        {
            Die(); // Если здоровье <= 0, вызываем функцию смерти
        }
    }

    // Функция смерти врага
    void Die()
    {
        Debug.Log(gameObject.name + " умер!");
        Destroy(gameObject); // Уничтожаем объект врага
    }
}
