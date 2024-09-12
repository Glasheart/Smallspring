using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_functions : MonoBehaviour
{
    private string transfer_scene;
    private GameObject menu, controls;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        menu = GameObject.Find("Menu");
        controls = GameObject.Find("Tutorial");

        if(controls != null)
        {
            controls.SetActive(false);
        }
    }

    public void play_game()
    {
        transfer_scene = "Forest_scene";
        StartCoroutine(switch_scene());
    }
    public void show_controls()
    {
        GameObject.Find("Tutorial").SetActive(true);
        GameObject.Find("Menu").SetActive(false);
    }
    IEnumerator switch_scene()
    {
        SceneManager.LoadScene("Loading_screen");
        yield return new WaitForSeconds(3);
        SceneManager.LoadSceneAsync(transfer_scene);
    }
}
