using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WobbleOnComplete : MonoBehaviour
{
    public float speed;
    public float offset;
    public float amplitude;

    public DioramaCard card;

    private Vector3 startPosition;


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.eulerAngles;

    }

    // Update is called once per frame
    void Update()
    {
        if (!card.moveFinished)
            return;

        float timeOffset = Time.time * speed + offset;
        float movement = amplitude * Mathf.Sin(timeOffset);
        transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0f, movement, movement));
    }
}
