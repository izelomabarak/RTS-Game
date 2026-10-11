using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioSource music;
    public float startSecond = 0f;
    public float endSecond = 5f;

    void Start()
    {
        music.time = startSecond;
        music.Play();
    }

    void Update()
    {
        if (music.isPlaying && music.time >= endSecond)
        {
            music.time = startSecond;
            music.Play();
        }
    }
}
