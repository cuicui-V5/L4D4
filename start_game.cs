using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class start_game : MonoBehaviour

{
    public GameObject player;
    public GameObject cam;
    private float x = 0;
    private Animator ani;
    private float timer = 0.1f;
    public bool tags = false;
    private bool tags1 = false;

    public GameObject about_panel;
    // Start is called before the first frame update
    void Start()
    {
        ani = player.GetComponent<Animator>();
        //重置所有变量
        game_over.x1 = 0;
        game_over.x2 = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (tags == false)
        {
            cam.transform.RotateAround(player.transform.position, Vector3.up, 20 * Time.deltaTime);

        }
        else
        {
            ani.SetInteger("state", 2);
            cam.transform.RotateAround(player.transform.position, Vector3.up, -20 * Time.deltaTime);


        }

    }
    public void start_click()
    {
        tags = true;

    }
    public void exit_click()
    {
        Application.Quit();

    }
    public void easy_click()
    {
        SceneManager.LoadScene("main");
        game_control.level = 1;
    }

    public void mid_click()
    {
        SceneManager.LoadScene("main");
        game_control.level = 2;

    }
    public void high_click()
    {
        SceneManager.LoadScene("main");
        game_control.level = 3;

    }
    public void about_click()
    {
        
        about_panel.SetActive(true);

    }
        public void about_click_close()
    {
        
        about_panel.SetActive(false);

    }

}
