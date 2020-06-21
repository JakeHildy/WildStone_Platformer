using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{

    [SerializeField] AudioClip musicClip;

    AudioSource audioSource;

    bool mPlay;
    bool mToggleChange;

    private void Awake() 
    {
        int numMusics = FindObjectsOfType<SoundEffects>().Length;
        if (numMusics > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = musicClip;
        audioSource.Play();
    }

    private void Update() 
    {
        
    }
}
