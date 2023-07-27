using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFollower : MonoBehaviour
{
    private Transform targetSprite; // Reference to the 2D sprite's Transform component
    public Image commandMenu; // Reference to the Button component
    [SerializeField] private Vector3 offset;
    private void Start()
    {
        targetSprite = gameObject.transform;
    }
    void Update()
    {
        // Update the button's position to match the 2D sprite's position
        if (targetSprite != null)
        {
            Vector3 targetPosition = targetSprite.position + offset;
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetPosition);
            commandMenu.transform.position = screenPosition;
        }
    }
}
