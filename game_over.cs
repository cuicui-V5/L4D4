using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class game_over : MonoBehaviour
{
    public static bool victory;
    public static float time;
    public Text text;
    public Text txt_score;
    public Text txt_mzl;
    public Text txt_kill_num;
    public Text txt_time;


    public GameObject emi;
    public GameObject man;

    public GameObject obj;

    private float score = 0;

    public static int kill_num;

    public static float x1 = 0;

    public static float x2 = 0;
    // Start is called before the first frame update
    void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }
    void Start()
    {

        Debug.Log(x1 + "/" + x2);
        if (victory)
        {
            text.text = "你赢了!!!";
            man.SetActive(true);
            score = (1 / time) * 100000*game_control.level;
            score += 2000 * game_control.level;
        }
        else
        {
            text.text = "游戏失败!";
            emi.SetActive(true);
            score = kill_num * 100 + (1 / time) * 1000;
        }
        txt_score.text = "分数:" + Mathf.RoundToInt(score).ToString();
        txt_kill_num.text = "击杀数:" + kill_num.ToString();
        txt_mzl.text = "命中率:" + x2 / x1 * 100 + "%";
        txt_time.text = "时间:" +time.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.Rotate(Vector3.up, Time.deltaTime * 10);
    }

    public void rstart()
    {
        SceneManager.LoadScene("start");
    }
    public void exit_game()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
