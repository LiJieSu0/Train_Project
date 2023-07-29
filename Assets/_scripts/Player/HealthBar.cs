using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float maxHealth = 100f;
    [SerializeField]
    private float currentHealth;
    [SerializeField]
    private Vector3 Offset;

    private GameObject character;

    // Reference to the HP bar Slider
    private GameObject HealthBarObj;
    private Slider healthSlider;

    void Start()
    {
        HealthBarObj=GetComponent<GameObject>();
        healthSlider = GetComponent<Slider>();
        character = transform.parent.gameObject. //canvas
                    transform.parent.gameObject; //character;

        currentHealth = maxHealth;
    }
    private void Update()
    {
        currentHealth = character.GetComponent<CharacterStatus>().getCurrHealth();
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
        // Implement death logic here if needed
        //Destroy(gameObject);
        Debug.Log("Die!!");
    }
}
