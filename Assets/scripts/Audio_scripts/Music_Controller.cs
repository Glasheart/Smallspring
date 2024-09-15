using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Audio_space
{
    VILLAGE,
    FOREST,
    STORM_FOREST
}
public class Music_Controller : MonoBehaviour
{
    [SerializeField] private AudioClip village_song, forest_song, storm_song;

    private AudioSource source;
    public Audio_space area;
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = village_song;
        song_time = source.clip.length;
    }

    private float song_time = 0;
    void Update()
    {
        song_time += Time.deltaTime;
        if(song_time >= source.clip.length)
        {
            song_time = 0;
            source.Play();
        }
    }

    public void change_clip(Audio_space space)
    {
        area = space;
        switch (space)
        {
            case Audio_space.VILLAGE:
                source.clip = village_song;
                break;
            case Audio_space.FOREST:
                source.clip = forest_song;
                break;
            case Audio_space.STORM_FOREST:
                source.clip = storm_song;
                break;
        }
        source.Stop();
        song_time = source.clip.length;
    }
}
