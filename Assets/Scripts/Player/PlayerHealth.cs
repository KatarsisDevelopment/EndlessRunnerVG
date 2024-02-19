using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float CurrentHealth;
    [SerializeField] float MaxHealth;
    public GameObject PanelObj;
    bool IsTakeDamage = false;
    public Animator DamageAnimator;
    private void Start()
    {
        CurrentHealth = MaxHealth;
    }
    private void Update()
    {
        if (CurrentHealth <= 0)
        {
            GameManager.GameOver();
            PanelObj.SetActive(true);
        }
        if (IsTakeDamage && MaxHealth >= CurrentHealth)
        {
            Invoke(nameof(ResetHealth), 5f);
        }
    }
    void ResetHealth()
    {
        CurrentHealth = MaxHealth;
        IsTakeDamage = false;
    }
    void TakeDamage(float damageCount)
    {
        CurrentHealth -= damageCount;
        IsTakeDamage = true;
        DamageAnimator.SetTrigger("Damage");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            TakeDamage(1);
        }
    }
}
