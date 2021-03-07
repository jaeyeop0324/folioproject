using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FrutisCollected : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            FindObjectOfType<FruitManager>().AllFruitsCollected();

            Destroy(gameObject,0.5f);

            audioSource.Play();

        }
    }

}
