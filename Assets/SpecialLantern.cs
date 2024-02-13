using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialLantern : MonoBehaviour
{
    public DioramaCard Card;
    public Light myLight;
    public GameObject myTorii;

    // Update is called once per frame
    void Update()
    {
        if (Card.moveFinished)
        {
            myLight.enabled = true;
            transform.SetParent(myTorii.transform);
            Destroy(this);
        }
    }
}
