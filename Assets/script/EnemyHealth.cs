using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f; // ������������ �������� �����
    private float currentHealth; // ������� �������� �����

    void Start()
    {
        currentHealth = maxHealth; // � ������ ���� �������� ������
    }

    // ������� ��� ��������� �����
    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // ��������� �������� �� �������� �����
        Debug.Log(gameObject.name + " ������� " + damage + " �����.  ������� ��������: " + currentHealth);

        // ���������, ���� �� ����
        if (currentHealth <= 0)
        {
            Die(); // ���� �������� <= 0, �������� ������� ������
        }
    }

    // ������� ������ �����
    void Die()
    {
        Debug.Log(gameObject.name + " ����!");
        Destroy(gameObject); // ���������� ������ �����
    }
}
