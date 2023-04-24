using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLine : MonoBehaviour
{
    [SerializeField] float reloadDelay = 1f;
    [SerializeField] ParticleSystem finishEffect;
    private bool shouldPlaySound = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Invoke("reloadScene", reloadDelay);
            if (shouldPlaySound)
            {
                finishEffect.Play();
                shouldPlaySound = false;
            }
            GetComponent<AudioSource>().Play();

        }
    }

    void reloadScene()
    {
        SceneManager.LoadScene(0);
    }

}
