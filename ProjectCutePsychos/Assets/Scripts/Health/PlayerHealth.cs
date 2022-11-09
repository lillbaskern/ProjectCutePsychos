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

        if (currentHealth > 0)
        {
            if (invulnerable) return;
            currentHealth -= _damage;
            StartCoroutine(Invulnerability());
            Debug.Log("Took Damage");
        }
        if (currentHealth <= 0)
        {
            GameController.Instance.StartCoroutine(GameController.Instance.Respawn(1.2f));
            Debug.Log("Dead");
        }
    }

    void Die()
    {
        print("You died");

    }

    public void RestoreHealth(int _healAmount)
    {
        currentHealth = Mathf.Clamp(currentHealth + _healAmount, 0, maxHealth);
    }

    public void IncreaseMaxHealth(int _incraseAmount)
    {
        maxHealth += _incraseAmount;
        PlayerPrefs.SetInt("HP", maxHealth);
    }

    #region IFrames
    private IEnumerator Invulnerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(8,9, true);
        for (int i = 0; i < _numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);

            yield return new WaitForSeconds(_iFramesDuration / (_numberOfFlashes * 2));

            spriteRend.color = Color.white;

            yield return new WaitForSeconds(_iFramesDuration / (_numberOfFlashes * 2));
        }
        invulnerable = false;
        Physics2D.IgnoreLayerCollision(8, 9, false); //in order for things to function on a subframe level we use the bool, but this still offers great functionality with ontriggerenter

    }
    #endregion
    private void OnEnable()
    {
        invulnerable = false;
        Physics2D.IgnoreLayerCollision(8, 9, false);
        spriteRend.color = Color.white;
        maxHealth = PlayerPrefs.GetInt("HP", 3);
        currentHealth = maxHealth;
    }
}