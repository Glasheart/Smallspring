using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Audio_space
{
    VILLAGE,
    FOREST
}
public class Music_Controller : MonoBehaviour
{
    [SerializeField] private AudioClip village_song, forest_song;

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
        if(space == Audio_space.VILLAGE)
        {
            source.clip = village_song;
        }
        else if (space == Audio_space.FOREST)
        {
            source.clip = forest_song;
        }
        source.Stop();
        song_time = source.clip.length;
    }
}
