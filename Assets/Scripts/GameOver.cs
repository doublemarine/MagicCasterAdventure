using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip GameOverSe;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable() {
         audioSource = GetComponent<AudioSource>();
         audioSource.PlayOneShot(GameOverSe);
    }
}
