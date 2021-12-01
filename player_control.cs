using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class player_control : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes m_axes = RotationAxes.MouseXAndY;
    public float m_sensitivityX = 10f;
    public float m_sensitivityY = 10f;

    // 水平方向的 镜头转向
    public float m_minimumX = -360f;
    public float m_maximumX = 360f;
    // 垂直方向的 镜头转向 (这里给个限度 最大仰角为45°)
    public float m_minimumY = -90f;
    public float m_maximumY = 45f;

    public GameObject game1;
    public GameObject cam;
    public float movespeed = 0.5f;
    float m_rotationY = 0f;
    private Rigidbody obj;

    public GameObject gun;
    public AudioClip gunsound;
    public GameObject bullet;

    public GameObject gunhead;
    private float timer1 = 0.1f;
    private float timer2 = 0.05f;
    private float timer3 = 0.1f;

    private AudioSource audioSource;

    public GameObject fire;
    public GameObject player;

    private bool tags1;
    private bool tags2;
    private float x;

    // Use this for initialization
    void Start()
    {
        obj = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        // 防止 刚体影响 镜头旋转
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }


    }

    // Update is called once per frame
    void Update()
    {
        //控制视角移动
        if (m_axes == RotationAxes.MouseXAndY)
        {
            float m_rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * m_sensitivityX;
            m_rotationY += Input.GetAxis("Mouse Y") * m_sensitivityY;
            m_rotationY = Mathf.Clamp(m_rotationY, m_minimumY, m_maximumY);

            transform.localEulerAngles = new Vector3(0, m_rotationX, m_rotationY);
        }
        else if (m_axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * m_sensitivityX, 0);
        }
        else
        {
            m_rotationY += Input.GetAxis("Mouse Y") * m_sensitivityY;
            m_rotationY = Mathf.Clamp(m_rotationY, m_minimumY, m_maximumY);

            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, m_rotationY);
        }


        //控制移动
        if (Input.GetKey(KeyCode.LeftShift))

        {
            movespeed = 1;
        }
        else
        {
            movespeed = 0.5f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 v1 = this.transform.position;
            Vector3 v2 = transform.right;
            v2.y = 0;
            v1 += v2 * movespeed;

            this.transform.position = v1;

        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 v1 = this.transform.position;
            Vector3 v2 = transform.right;
            v2.y = 0;

            v1 += v2 * -movespeed;

            this.transform.position = v1;

        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 v1 = this.transform.position;
            Vector3 v2 = transform.forward;
            v2.y = 0;

            v1 += v2 * movespeed;

            this.transform.position = v1;

        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 v1 = this.transform.position;
            Vector3 v2 = transform.forward;
            v2.y = 0;

            v1 += v2 * -movespeed;

            this.transform.position = v1;

        }

        else
        {

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            obj.AddForce(0, 100, 0);
            //Debug.Log("u press space");
        }
        else
            obj.AddForce(0, -5f, 0);



        if (Input.GetKey(KeyCode.Mouse0))
        {
            fire.SetActive(true);
            tags1 = true;


            if (audioSource.isPlaying == true) //播放枪声
            {

            }
            else
            {
                audioSource.clip = gunsound;

                audioSource.Play();
            }
            //生成子弹
            if (timer2 <= 0)
            {
                Instantiate(bullet, gunhead.transform.position, gunhead.transform.rotation);
                timer2 = 0.05f;//发射子弹
            }
            timer2 -= Time.deltaTime;
        }
        else
        {

            fire.SetActive(false);
            tags1 = false;

            if (audioSource.isPlaying == false)
            {

            }
            else
            {
                // audioSource.volume -= 0.05f;
                // if (audioSource.volume < 0.1)
                // {
                audioSource.Stop();
                // audioSource.volume = 1f;
                //}
            }

        }


        //镜头抖动代码
        if (tags1)
        {


            if (tags2)
            {
                x += Time.deltaTime;
                x *= 10;
                cam.transform.localPosition = Vector3.Lerp(new Vector3(-104.669998f, 109.699997f, 53), new Vector3(-88.5100021f, 109.699997f, 53), x);
                cam.transform.localEulerAngles = Vector3.Lerp(new Vector3(1.95f,99.2600021f,359.915985f), new Vector3(2.5f,99.2600021f,359.915985f), x);

                if (timer3 <= 0)
                {
                    tags2 = false;
                    timer3 = 0.05f;
                    x = 0;

                }
                timer3 -= Time.deltaTime;
            }
            else
            {
                x += Time.deltaTime;
                x *= 10;

                cam.transform.localPosition = Vector3.Lerp(new Vector3(-88.5100021f, 109.699997f, 53), new Vector3(-104.669998f, 109.699997f, 53), x);
                cam.transform.localEulerAngles = Vector3.Lerp(new Vector3(2.5f,99.2600021f,359.915985f),new Vector3(1.95f,99.2600021f,359.915985f), x);


                if (timer3 <= 0)
                {

                    tags2 = true;
                    timer3 = 0.05f;
                    x = 0;

                }
                timer3 -= Time.deltaTime;

            }
        }
        else
        {

        }




    }
}