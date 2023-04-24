using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{

    [SerializeField] float reloadDelay = 1f;
    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] AudioClip crashSFX;

    bool shouldPlaySound = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            FindObjectOfType<PlayerController>().DisableControls();
            if (shouldPlaySound)
            {
                GetComponent<AudioSource>().PlayOneShot(crashSFX);
                shouldPlaySound = false;
            }
            crashParticles.Play();
            Invoke("reloadScene", reloadDelay);
        }
    }

    void reloadScene()
    {
        SceneManager.LoadScene(0);
    }

}
