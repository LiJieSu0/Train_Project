using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private float maxHealth;
    private float currentHealth;
    [SerializeField]
    private Vector3 Offset;

    private CharacterStatus character;

    // Reference to the HP bar Slider
    private GameObject HealthBarObj;
    private Slider healthSlider;

    void Start()
    {
        HealthBarObj=GetComponent<GameObject>();
        healthSlider = GetComponent<Slider>();
        character = transform.parent.gameObject. //canvas
                    transform.parent.gameObject.
                    GetComponent<CharacterStatus>();//character;
        maxHealth=character.getMaxHealth();
        currentHealth=character.getCurrHealth();
    }
    private void Update()
    {
        currentHealth = character.getCurrHealth();
        UpdateHealthBar();
    }
    // Function to decrease health
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        healthSlider.value = currentHealth / maxHealth;
    }

    void Die()
    {

        Debug.Log("Die!!");
    }
}
