using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockGridManager : MonoBehaviour
{
    public GameObject clockPrefab;
    public int rows = 6;
    public int cols = 8;
    public float spacing = 2f;
    private Clock[,] clocks;

    void Start()
    {
        clocks = new Clock[rows, cols];

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                Vector3 pos = new Vector3(x * spacing, y * spacing, 0);
                Quaternion rotation = Quaternion.Euler(90f, 180f, 0f);
                GameObject clockObj = Instantiate(clockPrefab, pos, rotation, transform);

                Clock clockScript = clockObj.GetComponent<Clock>();
                clocks[y, x] = clockScript;

                // Start animation with random delay for wave effect
                float delay = Random.Range(0f, 1.5f);
                StartCoroutine(StartClockAnimation(clockScript, delay));
            }
        }
    }

    private IEnumerator StartClockAnimation(Clock clock, float delay)
    {
        yield return new WaitForSeconds(delay);
        clock.AnimateRandomRotation(1.5f);
    }
}
