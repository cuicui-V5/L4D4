using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class emi_comtrol : MonoBehaviour
{
    private GameObject target;
    Rigidbody rig;
    public static float speed = 3;
    public float timer = 0.3f; // 定时
    private Animator ani;
    private GameObject obj;
    game_control gctrl;
    public AudioClip aud_attack, aud_stand, aud_dead, aud_beat;
    AudioSource audioSource;
    bool tag1 = false;
    bool tag2 = false;

    public float hp = 100;
    Collision col;
    public GameObject zombie;
    public float fin_dis;
    // Start is called before the first frame update
    // 开始接触
    void OnCollisionEnter(Collision col)
    {
        if (col.collider.name == "Bullet_Cover")
        {
            hp -= 30;
            if (audioSource.isPlaying == true)
            {

            }
            else
            {
                audioSource.clip = aud_beat;
                audioSource.Play();

            }
            if (hp <= 0)
            {
                if (tag2 == false)
                {
                    audioSource.clip = aud_dead;
                    audioSource.Play();
                }

                tag2 = true;



                ani.SetInteger("state", 4);
                //销毁当前游戏物体

                Destroy(this.gameObject, 2f);
            }

        }

    }

    // 碰撞结束
    void OnCollisionExit(Collision collision)
    {

    }

    // 碰撞持续中
    void OnCollisionStay(Collision collision)
    {

    }
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player");
        ani = GetComponent<Animator>();
        obj = GameObject.FindGameObjectWithTag("GameController");
        //不能用new 只能用getcom
        gctrl = obj.GetComponent<game_control>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v2 = this.transform.position;
        v2.y = 0;
        this.transform.position = v2;
        
    }

    void FixedUpdate()

    {

        this.transform.LookAt(target.transform.position);


        float dis = (this.transform.position - target.transform.position).sqrMagnitude;
        timer -= Time.deltaTime;
        if (dis < fin_dis)
        {

            if (target != null)
            {
                if (audioSource.isPlaying == true)
                {

                }
                else
                {
                    //播放攻击音效
                    audioSource.clip = aud_stand;
                    if (tag1 == false)
                    {
                        //audioSource.Play();

                    }
                    tag1 = true;
                }
                // Vector3 v1 = target.transform.position;
                // v1.y = 0;
                this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, Time.deltaTime * speed);
                ani.SetInteger("state", 2);
            }
            if (timer <= 0)
            {
                if (dis < 50)
                {
                    if (audioSource.isPlaying == true)
                    {

                    }
                    else
                    {
                        //播放攻击音效
                        audioSource.clip = aud_attack;
                        audioSource.Play();
                    }

                    //Debug.Log("你正在被攻击" + timer);
                    timer = 0.3f;
                    ani.SetInteger("state", 3);
                    gctrl.be_attacked();

                }
            }
        }
        else
        {

            ani.SetInteger("state", 1);
        }



    }
}