using UnityEngine;

public class WaveInWind : MonoBehaviour
{
    public float speed;
    public float amplitude;
    public float offset;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float timeOffset = Time.time * speed + offset;
        float movement = amplitude * Mathf.Sin(timeOffset);
        transform.position = startPosition + new Vector3(movement, 0f, 0f);
    }
}
