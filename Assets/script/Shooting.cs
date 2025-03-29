using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab; // ������ ����
    public float bulletSpeed = 10f; // �������� ����
    public float fireRate = 0.5f; // �������� ����� ���������� (�������)
    public float bulletDamage = 25f; // ����, ������� ������� ����

    private float lastShotTime = 0f; // ����� ���������� ��������

    void Update()
    {
        // ��������� ���� � ����������� ��������
        if (Input.GetButton("Fire1") && Time.time >= lastShotTime + fireRate)
        {
            Shoot();
            lastShotTime = Time.time; // ��������� ����� ���������� ��������
        }
    }

    void Shoot()
    {
        // ���������� ����������� �������� (�� ������ � ����)
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 shootDirection = (mousePosition - transform.position).normalized;

        // ������� ����
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        Bullet bulletScript = bullet.GetComponent<Bullet>(); // �������� ��������� Bullet

        if (bulletRb != null)
        {
            bulletRb.linearVelocity = shootDirection * bulletSpeed; // ������ �������� ����
        }
        else
        {
            Debug.LogError("� ������� ���� ��� ���������� Rigidbody2D!");
            Destroy(bullet); // ������� ����, ���� ��� Rigidbody2D
            return; // ���������� ���������� �������
        }

        //������������� ���� ����
        if (bulletScript != null)
        {
            bulletScript.damage = bulletDamage;
        }
        else
        {
            Debug.LogError("� ������� ���� ��� ���������� Bullet!");
            Destroy(bullet);
            return;
        }

        // ���������� ���� ����� ����� (����������� - ����� ������, ���� ���� ������ ������ ����������)
        Destroy(bullet, 5f); //  ��������, ������� ����� 5 ������
    }
}