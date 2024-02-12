using System.Collections.Generic;
using UnityEngine;

public class FallingSprites : MonoBehaviour
{
    public GameObject spritePrefab; // Reference to your sprite prefab
    public int numberOfSprites = 10; // Number of sprites to instantiate

    public float minForce = 1f;
    public float maxForce = 5f;

    public float zDepth = 50f;

    private List<GameObject> spriteInstances = new List<GameObject>();

    void Start()
    {
        // Instantiate sprites
        // Generate a random number of points
        for (int i = 0; i < numberOfSprites; i++)
        {
            // Calculate a random X coordinate within the screen width
            float randomX = Random.Range(0, Screen.width);

            // Convert the screen position to world coordinates at the top of the screen
            Vector3 randomPoint = Camera.main.ScreenToWorldPoint(new Vector3(randomX, Screen.height, zDepth));

            GameObject newSprite = Instantiate(spritePrefab, randomPoint, Quaternion.identity);
            SetupSprite(newSprite);

            // Log the random point for debugging
            // Add the instantiated sprite to the list
            spriteInstances.Add(newSprite);
            Debug.Log("Random Point " + i + ": " + randomPoint);
        }


    }

    private void SetupSprite(GameObject newSprite)
    {

        Rigidbody rb = newSprite.GetComponent<Rigidbody>();
        var size = newSprite.transform.localScale.x;
        newSprite.transform.localScale = new Vector3(Random.Range(0.5f * size, 1.5f * size), Random.Range(0.5f * size, 1.5f * size), 1);

        rb.drag = Random.Range(0.25f, 2);

        float force = Random.Range(minForce, maxForce);
        rb.velocity = Vector3.zero; // Reset velocity before applying force
        rb.AddForce(Vector3.down * force, ForceMode.Impulse);

        // Add rotation force
        Vector3 rotationForce = new Vector3(Random.Range(-maxForce, maxForce), Random.Range(-maxForce, maxForce), 0);
        rb.AddTorque(rotationForce, ForceMode.Impulse);
    }

    private void Update()
    {
        foreach (GameObject sprite in spriteInstances)
        {
            if (sprite.transform.position.y < GetTopOfScreenPosition().y * -1)
            {
                float randomX = Random.Range(0, Screen.width);

                // Convert the screen position to world coordinates at the top of the screen
                Vector3 randomPoint = Camera.main.ScreenToWorldPoint(new Vector3(randomX, Screen.height, zDepth));
                sprite.transform.position = randomPoint;
                SetupSprite(sprite);
            }
        }
    }

    Vector3 GetTopOfScreenPosition()
    {
        // Calculate a position at the top of the screen
        return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, zDepth));
    }
}
