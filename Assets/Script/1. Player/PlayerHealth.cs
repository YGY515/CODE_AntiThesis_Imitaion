using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public event Action<int> HealthChange;
    public event Action HealthWarning;

    // ü�� 3ĭ
    private int maxHealth = 3;
    private int currentHealth;

    public int MaxHealth => maxHealth;
    public int CurrentHealth => currentHealth;


    [Header("Effect")]
    public AudioSource audioSource;
    public AudioClip hitClip;
    public SpriteRenderer spriteRenderer;
    public Color hitColor = Color.red;
    public float hitColorDuration = 1.0f;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        
        if (damage <= 0) return;

        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);    // �� �� �߿� �ִ� ��ȯ

        
        if (audioSource != null && hitClip != null)
            audioSource.PlayOneShot(hitClip);

        // ��������Ʈ ������ ȿ��
        if (spriteRenderer != null)
            StartCoroutine(HitEffect());

        HealthChange?.Invoke(currentHealth);


        if (currentHealth <= maxHealth / 3)
        {
            // ������ ü�� ���
            HealthWarning?.Invoke();
        }
    }

    public void Heal(int amount)
    {
        if (amount <= 0) return;

        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);    // �� �� �߿� �ּڰ� ��ȯ

        HealthChange?.Invoke(currentHealth);
    }

    private IEnumerator HitEffect()
    {
        Color originalColor = spriteRenderer.color;
        spriteRenderer.color = hitColor;

        float elapsed = 0f;
        while (elapsed < hitColorDuration)
        {
            spriteRenderer.color = Color.Lerp(hitColor, originalColor, elapsed / hitColorDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        spriteRenderer.color = originalColor;
    }
}