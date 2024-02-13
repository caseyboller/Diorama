using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ToriiSpawner : MonoBehaviour
{
    public GameObject toriiPrefab;
    public Transform spawnTarget;
    public GameObject toriiCard;

    public bool spinning = false;
    public float spinSpeed;
    public int numberOfGates;
    public float distFromCenter;
    private float angleSeparation;
    private float nextSpawnTime;
    private int gatesSpawned = 0;

    private float rotationDone = 0f;

    // Start is called before the first frame update
    void Start()
    {
        angleSeparation = 360f / (float)numberOfGates;
        nextSpawnTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (spinning)
        {
            transform.Rotate(new Vector3(spinSpeed * Time.deltaTime, 0, 0));
            rotationDone += Mathf.Abs(spinSpeed) * Time.deltaTime;



            if (rotationDone > nextSpawnTime)
            {
                if (gatesSpawned == numberOfGates - 1)
                {
                    toriiCard.transform.SetParent(this.transform);
                } else
                {
                    SpawnTorii(rotationDone % 360f, ((gatesSpawned + 1) % 3) == 0);
                    gatesSpawned++;
                    nextSpawnTime += angleSeparation;
                }
            }
        }
    }

    private void SpawnTorii(float angle, bool enableLantern)
    {
        var gate = Instantiate(toriiPrefab);
        gate.transform.position = spawnTarget.position;
        gate.transform.rotation = spawnTarget.rotation;
        gate.transform.SetParent(this.transform);

        if (!enableLantern)
        {
            var torii = gate.GetComponent<ToriiGate>();
            torii.MyLantern.SetActive(false);
        }
    }
}
