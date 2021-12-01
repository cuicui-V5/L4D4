using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class esc_menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.gameObject.SetActive(false);
            Time.timeScale = 1;
            Cursor.visible = false;//隐藏鼠标
            Cursor.lockState = CursorLockMode.Locked;//把鼠标锁定到屏幕中间
        }
    }
    public void btn_ctn()
    {
        Time.timeScale = 1;
    }
    public void btn_main()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("start");
    }
    public void btn_exit()
    {
        Application.Quit();
    }
}
