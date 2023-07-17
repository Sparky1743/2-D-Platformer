using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    private int scr = 0;
    [SerializeField] private TextMeshProUGUI score;

    [SerializeField] private AudioSource collectionSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("apple"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            scr++;
            score.text = "SCORE : " + scr;
        }

        if (collision.gameObject.CompareTag("cherry"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            scr++;
            score.text = "SCORE : " + scr;
        }

        if (collision.gameObject.CompareTag("banana"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            scr++;
            score.text = "SCORE : " + scr;
        }

        if (collision.gameObject.CompareTag("gem"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            scr = scr + 3;
            score.text = "SCORE : " + scr;
        }
    }
}