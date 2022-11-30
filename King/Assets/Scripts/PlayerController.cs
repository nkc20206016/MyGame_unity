using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{ 
    Rigidbody2D rb;
    Animator animator;

    public AudioClip SE_Asa;
    public AudioClip SE_Huka;
    public AudioClip SE_Sheld;
    AudioSource audioSource;

    Vector2 moveDirection;
    float jumpForce = 350.0f;       // ジャンプ時に加える力
    float SecondjumpForce = 350f;   //二段階ジャンプ時に加える力
    float jumpThreshold = 1.0f;    // ジャンプ中か判定するための閾値
    float runForce = 7f;       // 走り始めに加える力
    int reverce;
    float x;
    bool isGround = true;        // 地面と接地しているか管理するフラグ
    string state;//プレイヤーの状態管理
    string prevState;//前の情報を保存
    float stateEffect = 1;//状態に応じて横移動速度を変えるための係数
    bool secondJump;//二段階ジャンプ中かどうかの判定をするための変数
    int comboCount;//コンボ数
    float comboTime;//コンボ可能な時間
    bool AttackState;//攻撃中かどうかの判定をするための変数
    float GardTime = 5;
    bool GardState;
    Slider GardSlider;
    int direction;//rayの向き
    Mushroom mushScripts;
    Eye eyeScripts;
    Skeleton skeltonScripts;
    Bolt boltScripts;
    Slider PlayerHP;
    bool death;

    public float Mushdamage=5;
    public float Eyedamage = 10;
    public float Skedamage = 20;
    float start;
    float end;

    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.GardSlider = GameObject.Find("GardSlider").GetComponent<Slider>();
        PlayerHP = GameObject.Find("PlayerHP").GetComponent<Slider>();

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
        CameraMove();
        HP();
        GetInputKey();          // 入力を取得
        Move();                 // 入力に応じて移動する
        ChangeState();         //状態を変更する
        ChangeAnimation();     //入力に応じて移動する
        Attack();
       
    }

    void CameraMove()
    {

        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            start = -8.393365f;
            end = 70.42205f;

            if (transform.position.x < start)
            {
                transform.position = new Vector2(start, transform.position.y);
            }
            if (transform.position.x > end)
            {
                transform.position = new Vector2(end, transform.position.y);
            }
        }
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            start = -8.393365f;
            end = 283f;

            if (transform.position.x < start)
            {
                transform.position = new Vector2(start, transform.position.y);
            }
            if (transform.position.x > end)
            {
                transform.position = new Vector2(end, transform.position.y);
            }
        }


    }

    void GetInputKey()
    {

        //横
        x = Input.GetAxisRaw("Horizontal");

        moveDirection = new Vector2(x * runForce, 0);
        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y);

        if (moveDirection.x < 0)
        {
            reverce = -1;
        }
        else
        {
            reverce = 1;
        }

    }

    void Move()
    {
        if (isGround)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {

                this.rb.AddForce(transform.up * this.jumpForce);
                isGround = false;
                secondJump = true;
            }
        }
        else
        {
            if (secondJump)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    rb.velocity = Vector2.zero;
                    this.rb.AddForce(transform.up * this.SecondjumpForce);
                    secondJump = false;
                }
            }
        }
    }

    void ChangeState()
    {
        if (Mathf.Abs(rb.velocity.y) > jumpThreshold)
        {
            isGround = false;
        }

        // 接地している場合
        if (isGround)
        {
            // 走行中
            if (x != 0)
            {
                state = "RUN";
                //待機状態
            }
            else
            {
                state = "IDLE";
            }
            // 空中にいる場合
        }
        else
        {
            // 上昇中
            if (rb.velocity.y > 0)
            {
                state = "JUMP";
                // 下降中
            }
            else if (rb.velocity.y < 0)
            {
                state = "FALL";
            }
        }


        if (Input.GetMouseButtonDown(0))
        {
            comboCount++;

            audioSource.clip = SE_Asa;
            audioSource.Play();

            AttackState = true;
        }
        

        if (comboCount == 1)
        {
            state = "Attack1";

        }
        if (comboCount == 2)
        {
            state = "Attack2";

        }
        if (comboCount == 3)
        {
            state = "Attack3";

            comboCount = 0;
        }

        if (Input.GetMouseButtonUp(0))
        {
            AttackState = false;
        }



        if (!AttackState)
        {
            comboTime += Time.deltaTime;
            if (comboTime >= 0.5f)
            {
                comboCount = 0;
                comboTime = 0;
            }



        }

        if (Input.GetMouseButtonDown(1))
        {
            audioSource.clip = SE_Sheld;
            audioSource.Play();
            GardState = true;


        }
        else if (Input.GetMouseButtonUp(1))
        {
            GardState = false;

        }

        if (GardState)
        {
            Mushdamage = 0;
            Eyedamage = 0;
            Skedamage = 0;

            GardTime -= Time.deltaTime;
            GardSlider.value -= Time.deltaTime;

            state = "Block";


        }


        if (GardTime <= 0)
        {
            GardState = false;

        }

        if (!GardState)
        {
            Mushdamage = 5;
            Eyedamage = 10;
            Skedamage = 20;
            if (GardTime <= 5)
            {
                GardTime += Time.deltaTime;
                GardSlider.value += Time.deltaTime;
            }

        }

        if (death)
        {
            state = "Death";
        }
        

    }

    void Attack()
    {

       
        Ray2D ray = new Ray2D(new Vector2(this.transform.position.x, this.transform.position.y + 1), transform.right * direction);

        if (transform.localScale.x > 0)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }



        int layerMask = 1 << 9;
        float raydistance = 1.5f;
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 1.5f, layerMask);

        Debug.DrawRay(ray.origin, ray.direction * raydistance, Color.green);
        Debug.Log(hit.collider.name);
        if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {

            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.gameObject.tag == "Mushroom")
                {
                    audioSource.clip = SE_Huka;
                    audioSource.Play();
                    mushScripts = hit.collider.GetComponent<Mushroom>();

                    mushScripts.Hp -= 50;
                    StartCoroutine(damageMush());


                }
                if (hit.collider.gameObject.tag == "eye")
                {
                    audioSource.clip = SE_Huka;
                    audioSource.Play();
                    eyeScripts = hit.collider.GetComponent<Eye>();

                    eyeScripts.Hp -= 50;
                    StartCoroutine(damageEye());


                }
                if (hit.collider.gameObject.tag == "Skelton")
                {
                    audioSource.clip = SE_Huka;
                    audioSource.Play();
                    skeltonScripts = hit.collider.GetComponent<Skeleton>();

                    skeltonScripts.Hp -= 50;
                    StartCoroutine(damageSke());


                }

            }

        }

    }

    void HP()
    {
        if (PlayerHP.value <= 0)
        {
            StartCoroutine(Resusciation());
        }
    }

    void ChangeAnimation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "JUMP":
                    animator.SetBool("JumpUp", true);
                    animator.SetBool("JumpDown", false);
                    animator.SetBool("Run", false);
                    animator.SetBool("Idle", false);
                    animator.SetBool("Attack1", false);
                    animator.SetBool("Attack2", false);
                    animator.SetBool("Attack3", false);
                    animator.SetBool("Block", false);
                    animator.SetBool("Death", false);
                    stateEffect = 0.5f;
                    break;
                case "FALL":
                    animator.SetBool("JumpDown", true);
                    animator.SetBool("JumpUp", false);
                    animator.SetBool("Run", false);
                    animator.SetBool("Idle", false);
                    animator.SetBool("Attack1", false);
                    animator.SetBool("Attack2", false);
                    animator.SetBool("Attack3", false);
                    animator.SetBool("Block", false);
                    animator.SetBool("Death", false);
                    stateEffect = 0.5f;
                    break;
                case "RUN":
                    animator.SetBool("Run", true);
                    animator.SetBool("JumpDown", false);
                    animator.SetBool("JumpUp", false);
                    animator.SetBool("Idle", false);
                    animator.SetBool("Attack1", false);
                    animator.SetBool("Attack2", false);
                    animator.SetBool("Attack3", false);
                    animator.SetBool("Block", false);
                    animator.SetBool("Death", false);
                    transform.localScale = new Vector3(reverce, 1, 1);
                    stateEffect = 1f;
                    break;
                case "Attack1":
                    animator.SetBool("Attack1", true);
                    animator.SetBool("JumpDown", false);
                    animator.SetBool("JumpUp", false);
                    animator.SetBool("Run", false);
                    animator.SetBool("Idle", false);
                    animator.SetBool("Attack2", false);
                    animator.SetBool("Attack3", false);
                    animator.SetBool("Block", false);
                    animator.SetBool("Death", false);
                    stateEffect = 0.5f;
                    break;
                case "Attack2":
                    animator.SetBool("Attack2", true);
                    animator.SetBool("JumpDown", false);
                    animator.SetBool("JumpUp", false);
                    animator.SetBool("Run", false);
                    animator.SetBool("Idle", false);
                    animator.SetBool("Attack1", false);
                    animator.SetBool("Attack3", false);
                    animator.SetBool("Block", false);
                    animator.SetBool("Death", false);
                    stateEffect = 0.5f;
                    break;
                case "Attack3":
                    animator.SetBool("Attack3", true);
                    animator.SetBool("JumpDown", false);
                    animator.SetBool("JumpUp", false);
                    animator.SetBool("Run", false);
                    animator.SetBool("Idle", false);
                    animator.SetBool("Attack1", false);
                    animator.SetBool("Attack2", false);
                    animator.SetBool("Block", false);
                    animator.SetBool("Death", false);
                    stateEffect = 0.5f;
                    break;
                case "Block":
                    animator.SetBool("Block", true);
                    animator.SetBool("Attack3", false);
                    animator.SetBool("JumpDown", false);
                    animator.SetBool("JumpUp", false);
                    animator.SetBool("Run", false);
                    animator.SetBool("Idle", false);
                    animator.SetBool("Attack1", false);
                    animator.SetBool("Attack2", false);
                    animator.SetBool("Death", false);
                    stateEffect = 0.5f;
                    break;
                case "Death":
                    animator.SetBool("Death", true);
                    animator.SetBool("Block", false);
                    animator.SetBool("Attack3", false);
                    animator.SetBool("JumpDown", false);
                    animator.SetBool("JumpUp", false);
                    animator.SetBool("Run", false);
                    animator.SetBool("Idle", false);
                    animator.SetBool("Attack1", false);
                    animator.SetBool("Attack2", false);
                    stateEffect = 0.5f;
                    break;
                default:
                    animator.SetBool("Idle", true);
                    animator.SetBool("JumpDown", false);
                    animator.SetBool("Run", false);
                    animator.SetBool("JumpUp", false);
                    animator.SetBool("Attack1", false);
                    animator.SetBool("Attack2", false);
                    animator.SetBool("Block", false);
                    animator.SetBool("Attack3", false);
                    animator.SetBool("Death", false);
                    stateEffect = 1f;
                    break;
            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }

   



    IEnumerator damageMush()
    {
        mushScripts.damagestate = true;
        //3秒停止
        yield return new WaitForSeconds(0.3f);

        //青色にする
        mushScripts.damagestate = false;
    }

    IEnumerator damageEye()
    {
        eyeScripts.damagestate = true;
        //3秒停止
        yield return new WaitForSeconds(0.3f);

        //青色にする
        eyeScripts.damagestate = false;
    }

    IEnumerator damageSke()
    {
        skeltonScripts.damagestate = true;
        //3秒停止
        yield return new WaitForSeconds(0.3f);

        //青色にする
        skeltonScripts.damagestate = false;
    }


    IEnumerator Resusciation()
    {

        death = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        yield return new WaitForSeconds(5f);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        PlayerHP.value = 200;
        death = false;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground"|| col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (isGround)
                isGround = false;
        }


    }
    void OnTriggerStay2D(Collider2D col)
    {
        
        if (col.gameObject.layer == LayerMask.NameToLayer( "Ground") || col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (!isGround)
                isGround = true;
        }

        

    }


}
