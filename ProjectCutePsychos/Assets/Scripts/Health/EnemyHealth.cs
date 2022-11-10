using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float currentHealth = 2;
    [SerializeField] private float maxHealth = 3;

    [SerializeField] private float _iFramesDuration;
    [SerializeField] private int _numberOfFlashes;
    [SerializeField] private SpriteRenderer spriteRend;

    public bool IsFlashing { get; private set; }

    private void Awake()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int _damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= _damage;
            StartCoroutine(DamageVisual());
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void SetHP(int input)
    {
        currentHealth = Mathf.Clamp(input, 1, maxHealth);
    }

    void Die()
    {
        Destroy(this.gameObject);
    }

    private IEnumerator DamageVisual()
    {
        IsFlashing = true;
        for (int i = 0; i < _numberOfFlashes; i++)
        {
            if (i <= _numberOfFlashes  * 0.3)
            {
                IsFlashing = false;
            }
            spriteRend.color = new Color(1, 0, 0, 0.5f);

            yield return new WaitForSeconds(_iFramesDuration / (_numberOfFlashes * 2));

            spriteRend.color = Color.white;

            yield return new WaitForSeconds(_iFramesDuration / (_numberOfFlashes * 2));
        }
    }
}
