using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCompletionManager : MonoBehaviour
{
    private Dictionary<DioramaCard, bool> cards = new Dictionary<DioramaCard, bool>();

    public GameObject dioramaPlatform;

    void Start()
    {
        foreach (var card in FindObjectsByType<DioramaCard>(sortMode: FindObjectsSortMode.None))
        {
            cards[card] = false;
            card.completionManager = this;
        }
    }

    public void CompleteCard(DioramaCard card)
    {
        cards[card] = true;
        foreach (var cardComplete in cards.Values)
        {
            if (!cardComplete)
                return;
        }

        LevelComplete();
    }

    private void LevelComplete()
    {
        Debug.Log("YAYYY");
        foreach (var card in FindObjectsByType<WaveInWind>(sortMode: FindObjectsSortMode.None))
        {
            card.enabled = false;
        }
        LeanTween.rotateY(dioramaPlatform, 1080, 5).setEaseInOutCubic()
            .setOnComplete(() =>
        {
            foreach (var card in FindObjectsByType<WaveInWind>(sortMode: FindObjectsSortMode.None))
            {
                card.enabled = true;
            };
        });
    }
}
