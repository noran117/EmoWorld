using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public Transform hourHand;
    public Transform minuteHand;

    public void SetAngle(float hourAngle, float minuteAngle)
    {
        hourHand.localRotation = Quaternion.Euler(0, 0, -hourAngle);
        minuteHand.localRotation = Quaternion.Euler(0, 0, -minuteAngle);
    }
    public void AnimateRandomRotation(float duration)
    {
        StartCoroutine(AnimateHands(duration));
    }

    private IEnumerator AnimateHands(float duration)
    {
        float elapsed = 0f;
        float startHour = hourHand.localEulerAngles.z;
        float startMin = minuteHand.localEulerAngles.z;

        float targetHour = Random.Range(0f, 360f);
        float targetMin = Random.Range(0f, 360f);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            float currentHour = Mathf.LerpAngle(startHour, targetHour, t);
            float currentMin = Mathf.LerpAngle(startMin, targetMin, t);

            hourHand.localRotation = Quaternion.Euler(0, 0, currentHour);
            minuteHand.localRotation = Quaternion.Euler(0, 0, currentMin);

            yield return null;
        }
    }

    }
