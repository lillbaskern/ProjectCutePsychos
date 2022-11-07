using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int currentHealth;
    [SerializeField] public int maxHealth = 5;

    [Header("IFrames")]
    [SerializeField] private float _iFramesDuration;
    [SerializeField] private int _numberOfFlashes;
    private bool invulnerable;
    
    private SpriteRenderer spriteRend;

    private void Awake()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int _damage)
    {
        
        if ( currentHealth > 0)
        {
            if (invulnerable) return;
            currentHealth -= _damage;
            StartCoroutine(Invulnerability());
            Debug.Log("Took Damage");
        }
        if (currentHealth <= 0)
        {
            Die();
            Debug.Log("Dead");
        }
    }

    void Die()
    {
        print("You died");
        Destroy(gameObject);
    }

    public void RestoreHealth(int _healAmount)
    {
        currentHealth = Mathf.Clamp(currentHealth + _healAmount, 0, maxHealth);
    }

    public void IncreaseMaxHealth(int _incraseAmount)
    {
        maxHealth += _incraseAmount;
    }

    #region IFrames
    private IEnumerator Invulnerability()
    {
        invulnerable = true;
        //Physics2D.IgnoreLayerCollision(8,9, true);
        for (int i = 0; i < _numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);

            yield return new WaitForSeconds(_iFramesDuration / (_numberOfFlashes * 2));

            spriteRend.color = Color.white;

            yield return new WaitForSeconds(_iFramesDuration / (_numberOfFlashes * 2));
        }
        invulnerable = false;
        //Physics2D.IgnoreLayerCollision(8, 9, false); //i commented these out to just use a bool and it works so

    }
    #endregion
}