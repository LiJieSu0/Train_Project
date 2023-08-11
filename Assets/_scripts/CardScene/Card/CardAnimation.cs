using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAnimation : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 5.0f;

    private bool isMoving = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            StartCoroutine(MoveCardToTarget());
        }
    }

    IEnumerator MoveCardToTarget()
    {
        isMoving = true;

        Vector3 startPosition = transform.position;
        Vector3 targetPosition = target.position;

        float journeyLength = Vector3.Distance(startPosition, targetPosition);
        float startTime = Time.time;

        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;
            transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);
            yield return null;
        }

        transform.position = targetPosition;
        isMoving = false;
    }
}
