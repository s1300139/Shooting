using UnityEngine;
using System.Collections;

public class PlaySoundEvery8Seconds : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        StartCoroutine(PlaySoundLoop());
    }

    IEnumerator PlaySoundLoop()
    {
        while (true)
        {
            audioSource.Play();
            yield return new WaitForSeconds(8f);
        }
    }
}
