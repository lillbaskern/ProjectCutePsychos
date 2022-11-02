using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int currentHealth;
    [SerializeField] public int maxHealth = 5;

    [Header("IFrames")]
    [SerializeField] private float _iFramesDuration;
    [SerializeField] private int _numberOfFlashes;
    private SpriteRenderer spriteRend;
    private ExperimentalPlayer _player;
    

    private void Awake()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        _player = GetComponent<ExperimentalPlayer>();
        Debug.Log(_player);
    }

    public void TakeDamage(int _damage)
    {
        if ( currentHealth > 0)
        {
            currentHealth -= _damage;
            StartCoroutine(Invulnerability());
        }
        if (currentHealth <= 0)
        {
            Debug.Log("dead");
            Die();
        }
    }

    void Die()
    {
        GameController.Instance.StartCoroutine(GameController.Instance.Respawn(1f));
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
        Physics2D.IgnoreLayerCollision(8,9, true);
        for (int i = 0; i < _numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);

            yield return new WaitForSeconds(_iFramesDuration / (_numberOfFlashes * 2));

            spriteRend.color = Color.white;

            yield return new WaitForSeconds(_iFramesDuration / (_numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }
    #endregion


    private void OnEnable() {
        currentHealth = maxHealth;
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }
    private void OnDisable() {
        spriteRend.color = Color.white;
    }
}