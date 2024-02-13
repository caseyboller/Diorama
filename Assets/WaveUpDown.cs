using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveUpDown : MonoBehaviour
{
    public float speed;
    public float offset;
    public float amplitude;
    
    private Vector3 startPosition;


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        float timeOffset = Time.time * speed + offset;
        float movement = amplitude * Mathf.Sin(timeOffset);
        transform.position = startPosition + new Vector3(0f, movement, 0f);
    }
}
