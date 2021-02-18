using UnityEngine;


public class SFX : MonoBehaviour
{
    public AudioSource Collect;
    public AudioSource Jump;
    public AudioSource Loops;
    public AudioSource MySong;
    public AudioSource Apples;
    public AudioSource Burger;


    public void PlayCollect()
    {
        Collect.Play();
    }

    public void PlayBurger()
    {
        Burger.Play();
    }

    public void PlayJump()
    {
        Jump.Play();
    }

    public void PlayLoops()
    {
        Loops.Play();
    }

    public void PlayMySong()
    {
        MySong.Play();
    }

    public void PlayApples()
    {
        Apples.Play();
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Collect != null)
                Collect.Play();
            if (Jump != null)
                Jump.Play();
            if (Apples != null)
                Apples.Play();
        }
    }

}
