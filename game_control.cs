using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class game_control : MonoBehaviour
{

    public float hp = 100;
    public Slider hp_s;

    public Text text_hp;
    public Image image;
    public Text txt_time;
    public Text txt_zombie_num;

    public int speed;
    public GameObject emi;
    private Color32 col1 = new Color32(255, 0, 0, 0);
    private Color32 col2 = new Color32(255, 0, 0, 0);
    private Color32 col3 = new Color32(255, 0, 0, 0);
    public static int level = 1;
    public GameObject target;

    private float time;
    public int maxzombie = 20;

    public int zombie_num;

    public GameObject boss;
    private int boss_num = 0;
    private bool tags1 = false;
    public GameObject menu;


    void Awake()
    {
        Application.targetFrameRate = 60;
        Cursor.visible = false;//隐藏鼠标
        Cursor.lockState = CursorLockMode.Locked;//把鼠标锁定到屏幕中间
    }
    // Start is called before the first frame update
    void Start()
    {
        maxzombie = level * 20;
        emi_comtrol.speed = level * 3;
        Inst(maxzombie - 1);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            menu.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        text_hp.text = hp.ToString();

        if (Input.GetKeyDown(KeyCode.F12) || Time.timeSinceLevelLoad > 150)
        {
            GameObject[] obj = GameObject.FindGameObjectsWithTag("zombie");
            for (int i = 0; i < obj.Length; i++)
            {
                Destroy(obj[i]);
            }

        }
        if (Input.GetKeyDown(KeyCode.F11))
        {
            hp += 9999;
        }



    }
    void FixedUpdate()
    {
        time = Time.timeSinceLevelLoad;
        txt_time.text = time.ToString();
        zombie_num = GameObject.FindGameObjectsWithTag("zombie").Length;
        boss_num = GameObject.FindGameObjectsWithTag("boss").Length;
        //Debug.Log(zombie_num+"///"+boss_num);
        txt_zombie_num.text = (zombie_num + boss_num).ToString();
        if (zombie_num <= 0)
        {
            if (tags1)
            {

            }
            else
            {
                for (int i = 0; i < level; i++)
                {
                    Vector3 v1 = target.transform.position;
                    Vector3 v2 = new Vector3(50,
                             0,
                              50);
                    Quaternion Rotation = Quaternion.Euler(-90f, 0f, 0f);
                    Vector3 v3 = v1 + v2;
                    v3.y = 0;
                    Instantiate(boss, v3, Rotation);

                }
                tags1 = true;
                zombie_num++;
            }


        }
        if (zombie_num <= 0 && boss_num <= 0)
        {
            game_over.victory = true;
            game_over.time = time;
            game_over.kill_num = maxzombie;
            SceneManager.LoadScene("game_over");
        }
    }
    void Inst(int max)
    {
        for (int i = 0; i < max; i++)
        {
            target = GameObject.FindGameObjectWithTag("Player");

            Vector3 v1 = target.transform.position;
            Vector3 v2 = new Vector3(Random.Range(-100, 100),
                     0,
                      Random.Range(-100, 100));
            Quaternion Rotation = Quaternion.Euler(-90f, 0f, 0f);
            Vector3 v3 = v1 + v2;
            v3.y = 0;
            Instantiate(emi, v3, Rotation);

        }




    }

    public void be_attacked()

    {
        //Debug.Log("be_attacked");
        hp -= 10;
        hp_s.value = hp;

        col1.a += 10;
        if (hp > 100)
        {
            col1.a = 0;

        }
        image.color = col1;
        if (hp <= 0)
        {
            game_over.victory = false;
            game_over.time = time;
            game_over.kill_num = maxzombie - GameObject.FindGameObjectsWithTag("zombie").Length - 1;
            SceneManager.LoadScene("game_over");
        }
    }
}
