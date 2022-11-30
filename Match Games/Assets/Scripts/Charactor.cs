using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Charactor : MonoBehaviour
{
    /*
     * �������ꂽ��Ramdom�ňړ�������������߂�
     * ���ߕ���Ramdom�Ō��߂�ꂽ���l��
     * switch�Ɋ��蓖�Ă�
     * 
     * ��ʊO�ɏo����j������
     */

    //Random�̍ő�l�ƍŏ��l
    int RandomMax = 9;
    int RandomMin = 1;

    //Ramdom�Ō��܂������l��ۑ�
    int RandomSelect = 0;

    //�v���C���[�������X�s�[�h��ς��郉���_��
    int RandomSMin = 1;
    int RandomSMax = 4;

    //�X�s�[�h�����_���̐��l��ۑ�
    int RandomSpeed = 0;

    //Player���������߂̗�
    float Speed = 0.0f;     //���ɓ�����
    float UPSpeed = 1.0f;   //��ɏオ���
    float DWSpeed = -1.0f;  //���ɉ������

    //�ʒu���擾�p
    Vector3 Ptrans = Vector3.zero;

    //�I�u�W�F�N�g��������܂ł̃J�E���g
    float time = 0;
    float Dtime = 20;

    //���̃I�u�W�F�N�g�̖��O���擾����
    string this_name;

    //�ړ��z�u�p�̍��W
    private Vector3 p1 = new Vector3(-12.0f, -0.25f, 0.0f);
    private Vector3 p2 = new Vector3(-10.0f, 6.5f, 0.0f);
    private Vector3 p3 = new Vector3(-0.06f, 6.5f, 0.0f);
    private Vector3 p4 = new Vector3(11.0f, 5.7f, 0.0f);
    private Vector3 p5 = new Vector3(11.7f, 0.5f, 0.0f);
    private Vector3 p6 = new Vector3(11.9f, -5.8f, 0.0f);
    private Vector3 p7 = new Vector3(0.03f, -7.1f, 0.0f);
    private Vector3 p8 = new Vector3(-9.84f, -6.0f, 0.0f);

    Animator anime;
    Rigidbody2D rb2d;

    private void Awake()
    {
        //1����9�̒l�������_���ł���
        RandomSelect = Random.Range(RandomMin, RandomMax);

        //1����4�̒l�������_���ł���
        RandomSpeed = Random.Range(RandomSMin, RandomSMax);
        //Debug.Log(RandomSelect);
    }

    // Start is called before the first frame update
    void Start()
    {
        //�R���C�_�[�擾
        anime = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

        //���ݒn������
        Ptrans = this.gameObject.transform.position;

        //���̃X�N���v�g���A�^�b�`���ꂽ�I�u�W�F�N�g�̖��O���擾
        this_name = this.gameObject.name;

        //�����ʒu�ֈړ����郁�\�b�h
        PlayerStartPosition();

        //���O���Q�Ƃ�animation����
        PlayerName();
    }

    void PlayerName()
    {
        if (this_name == "Play1(Clone)") anime.SetBool("play1", true);
        if (this_name == "Play2(Clone)") anime.SetBool("play2", true);
        if (this_name == "Play3(Clone)") anime.SetBool("play3", true);
        if (this_name == "Play4(Clone)") anime.SetBool("play4", true);
    }

    private void PlayerStartPosition()
    {
        switch (RandomSelect)
        {
            //�ŏ��̍��W��
            case 1:
                //�^�񒆂̍��ֈړ�
                Ptrans = p1;
                this.gameObject.transform.position = Ptrans;
                break;
            case 2:
                //�΂ߍ���
                Ptrans = p2;
                this.gameObject.transform.position = Ptrans;
                break;
            case 3:
                //�����̏�
                Ptrans = p3;
                this.gameObject.transform.position = Ptrans;
                break;
            case 4:
                //�΂߉E��
                Ptrans = p4;
                this.gameObject.transform.position = Ptrans;
                //�������t�ɂ���
                transform.eulerAngles = new Vector3(0, 180, 0);
                break;
            case 5:
                //�^�񒆂̉E
                Ptrans = p5;
                this.gameObject.transform.position = Ptrans;
                //�������t�ɂ���
                transform.eulerAngles = new Vector3(0, 180, 0);
                break;
            case 6:
                //�΂߉E��
                Ptrans = p6;
                this.gameObject.transform.position = Ptrans;
                //�������t�ɂ���
                transform.eulerAngles = new Vector3(0, 180, 0);
                break;
            case 7:
                //�����̉�
                Ptrans = p7;
                this.gameObject.transform.position = Ptrans;
                //�������t�ɂ���
                transform.eulerAngles = new Vector3(0, 180, 0);
                break;
            case 8:
                //�΂ߍ���
                Ptrans = p8;
                this.gameObject.transform.position = Ptrans;
                break;

            default:
                Destroy(this.gameObject);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {   
        //�v���C���[�̃X�s�[�h��ω�
        switch (RandomSpeed)
        {
            case 1: Speed = 1.0f;
                break;
            case 2: Speed = 2.0f;
                break;
            case 3: Speed = 3.0f;
                break;
            default: Speed = 1.0f;
                break;
        }

        //�ΏۂƂȂ���W�ֈړ�
        switch (RandomSelect)
        {
            case 1:
                //�^�񒆉E�ֈړ�
                rb2d.velocity = new Vector3(Speed, 0.0f, 0.0f);
                time +=Time.deltaTime;
                if (time > Dtime) Destroy(this.gameObject);
                break;
            case 2:
                //�΂߉E���ֈړ�
                rb2d.velocity = new Vector3(Speed, DWSpeed, 0.0f);
                time += Time.deltaTime;
                if (time > Dtime) Destroy(this.gameObject);
                break;
            case 3:
                //�������ֈړ�
                rb2d.velocity = new Vector3(0.0f, DWSpeed, 0.0f);
                time += Time.deltaTime;
                if (time > Dtime) Destroy(this.gameObject);
                break;
            case 4:
                //�΂ߍ����ֈړ�
                rb2d.velocity = new Vector3(-Speed, DWSpeed, 0.0f);
                time += Time.deltaTime;
                if (time > Dtime) Destroy(this.gameObject);
                break;
            case 5:
                //�^�񒆍��ֈړ�
                rb2d.velocity = new Vector3(-Speed, rb2d.velocity.y, 0.0f);
                time += Time.deltaTime;
                if (time > Dtime) Destroy(this.gameObject);
                break;
            case 6:
                //�΂ߍ���ֈړ�
                rb2d.velocity = new Vector3(-Speed, UPSpeed , 0.0f);
                time += Time.deltaTime;
                if (time > Dtime) Destroy(this.gameObject);
                break;
            case 7:
                rb2d.velocity = new Vector3(0.0f, UPSpeed, 0.0f);
                time += Time.deltaTime;
                if (time > Dtime) Destroy(this.gameObject);
                //������ֈړ�
                break;
            case 8:
                //�΂߉E��ֈړ�
                rb2d.velocity = new Vector3(Speed, UPSpeed, 0.0f);
                time += Time.deltaTime;
                if (time > Dtime) Destroy(this.gameObject);
                break;

            default : Destroy(this.gameObject);
                break;
        }
    }

}
