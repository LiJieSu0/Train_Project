using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFollower : MonoBehaviour
{
    private Transform targetSprite; // Reference to the 2D sprite's Transform component
    public GameObject commandMenu; // Reference to the Button component
    public GameObject healthBar;
    [SerializeField] private Vector3 commandMenuOffset;
    [SerializeField] private Vector3 healthBarOffset;
    private void Start()
    {
        targetSprite = gameObject.transform;
    }
    void Update()
    {
        // Update the button's position to match the 2D sprite's position
        if (targetSprite != null)
        {
            Vector3 targetPosition = targetSprite.position+ commandMenuOffset;
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetPosition);
            commandMenu.transform.position = screenPosition;

            targetPosition = targetSprite.position + healthBarOffset;
            screenPosition = Camera.main.WorldToScreenPoint(targetPosition);
            healthBar.transform.position = screenPosition;
        }
    }
}
