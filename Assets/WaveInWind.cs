using UnityEngine;

public class WaveInWind : MonoBehaviour
{
    public float speed;
    public float amplitude;
    public float offset;

    private Vector3 startPosition;

    private bool waving = false;

    private DioramaCard card;

    void Start()
    {
        card = GetComponent<DioramaCard>();
        if (card == null)
        {
            startPosition = transform.position;
            waving = true;
        }
    }

    void Update()
    {
        if (!waving)
        {
            if (card.moveFinished)
            {
                waving = true;
                startPosition = transform.position;
            }
            else
            {
                return;
            }
        }
        float timeOffset = Time.time * speed + offset;
        float movement = amplitude * Mathf.Sin(timeOffset);
        transform.position = startPosition + new Vector3(movement, 0f, 0f);
    }
}
