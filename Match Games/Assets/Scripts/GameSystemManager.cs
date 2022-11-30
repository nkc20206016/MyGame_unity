using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameSystemManager : MonoBehaviour
{
    /*
     * ��邋��
     * ��������
     * 
    */ 

    //�L�����N�^�[�̎�ނ����߂郉���_���p�̍ő�l�ƍŏ��l
    int RandomMin = 1;
    int RandomMax = 5;

    //�L�����N�^�[�̎�ނ����߂郉���_���Ō��肵�����l��ۑ�
    int RandomSelect = 0;

    //�L�����N�^�[�̎�ނ̓��������肷�郉���_���p�̍ő�l�ƍŏ��l
    int RandomAnswerMin = 1;
    int RandomAnswerMax = 9;

    //�����̐������߂郉���_���Ō��肵�����l�̓�����ێ�
    int RandomAnswer = 0;

    //�����X�V�p�̐��l
    float intervalf = 2.0f;
    float intervals = 3.0f;
    float intervalt = 4.0f;

    //�����J�E���g
    int count = 0;

    //�����I���܂ł����鎞��
    float time = 0.0f;

    //���Y�I���܂ł̍ő厞��
    float maxtime = 0.0f;

    //text�g��̃J�E���g
    float text_time = 0;

    //�^�C�}�[�X�^�[�gflag
    bool StartTime = false;

    //Starttext�g��p�t���O
    bool textbuff = false;

    //��������Player���擾�p�̒l
    GameObject Player1;
    GameObject Player2;
    GameObject Player3;
    GameObject Player4;

    //�\������UI
    [SerializeField] GameObject CImage;
    [SerializeField] GameObject CImage2;

    //UI�擾�p
    Image image;
    Image image2;

    //inputField�̐e�I�u�W�F�N�g
    [SerializeField] GameObject answer;
    //��������͂���inputField
    [SerializeField] InputField answerField;
    [SerializeField] Text Ntext;

    //ResultPanel
    //Button�̐e�I�u�W�F�N�g
    [SerializeField] GameObject select;

    //�^�C�}�[�\��Text�擾
    [SerializeField] Text Timertext;

    //start�̊|�����p
    [SerializeField] Text Starttext;

    //Panel���擾�p
    [SerializeField] GameObject StartPanel;
    [SerializeField] GameObject ResultPanel;
    [SerializeField] GameObject CollationPanel;

    //������v���C���[�̉摜��\��
    [SerializeField] Sprite Player1image;
    [SerializeField] Sprite Player2image;
    [SerializeField] Sprite Player3image;
    [SerializeField] Sprite Player4image;

    //Audiosorce���擾���ĉ������Đ�
    AudioSource audioSource;
    public AudioClip raedy;
    public AudioClip go;
    public AudioClip click;
    public AudioClip hue;
    public AudioClip Out;
    public AudioClip hakusyu;


    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Start is called before the first frame update
    void Start()
    {
        //�����_������
        RandomSelect = Random.Range(RandomMin, RandomMax);
        RandomAnswer = Random.Range(RandomAnswerMin, RandomAnswerMax);
        
        //prefab�ł���Player�B���擾
        Player1 = (GameObject)Resources.Load("Play1");
        Player2 = (GameObject)Resources.Load("Play2");
        Player3 = (GameObject)Resources.Load("Play3");
        Player4 = (GameObject)Resources.Load("Play4");

        //AudioSource
        audioSource = GetComponent<AudioSource>();

        //Image���擾
        image = CImage.GetComponent<Image>();
        image2 = CImage2.GetComponent<Image>();

        //������L������\�����邽�߂̃��\�b�h�Ăяo��
        CharactorIndication();

        //ResultPanel���\����
        ResultPanel.SetActive(false);
        CollationPanel.SetActive(false);
        //ResultPanel��Button���\��
        select.SetActive(false);

        Debug.Log(RandomAnswer);
    }

    private void FixedUpdate()
    {
        //�I���܂ł̃^�C�}�[�J�n
        if (StartTime == true)
        {
            time += Time.deltaTime;
            Timertext.text = time.ToString("f1"); //������1�ʂ܂ŕ\��
        }

        //�^�C�}�[��30�b�𒴂�����Invoke��S��~���A��ʓ��̎c����Player���폜�A�^�C�}�[��~
        if (time > maxtime)
        {
            CancelInvoke();
            StartTime = false;
            time = 0;
            //�^�O�Ō�����obj��Dobject�ɓ���A�����PDestroy�̒��ɓ���foreach�ŌJ��Ԃ�
            GameObject[] Dobject = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject PDestroy in Dobject)
            {
                Destroy(PDestroy);
            }
            //�R���[�`�����g��
            StartCoroutine("Resultct");

        }
    }

    // Update is called once per frame
    void Update()
    {
        //text�����Ԍo�߂Ŋg�傷��
        if (textbuff == true)
        {
            text_time += Time.deltaTime;
            //2�b�ȉ��Ȃ�g��
            if (text_time < 2) Starttext.fontSize += 1;
            //4�b�������當����ς���
            if (text_time > 4)
            { 
                Starttext.text = "GO";
            }
            //5�b�������烊�Z�b�g
            if (text_time > 5)
            {
                text_time = 0;
                textbuff = false;
            }
        }
    }


    //Button
    //StartButton�������ꂽ��
    public void StartButton()
    {
        //SE
        audioSource.PlayOneShot(click);

        //Panel���\����
        StartPanel.SetActive(false);

        //�R���[�`���Ăяo��
        StartCoroutine("GameStart");

        //Ready��SE�p��Invock
        Invoke("Ready", 0.5f);
    }

    void Ready(){
        audioSource.PlayOneShot(raedy);
        Invoke("Go", 3.5f);
    }
    void Go()
    {
        audioSource.PlayOneShot(go);
    }

    //title�ɖ߂�{�^��
    public void Title()
    {
        //SE
        audioSource.PlayOneShot(click);

        //title�ɖ߂鏈��
        FadeManager.Instance.LoadScene("TitleScene",1.0f);
    }

    //�V�[�������[�h���Ă�蒼��
    public void Reset()
    {
        //SE
        audioSource.PlayOneShot(click);

        //�V�[�������[�h���鏈��
        //���݂̃V�[�����擾
        Scene loadScene = SceneManager.GetActiveScene();
        FadeManager.Instance.LoadScene(loadScene.name,1.0f);
    }

    //�������ׂ��G�l�~�[�̑I���Ɛ����w��
    public void SelectFactory()
    {
        //�G�l�~�[�̐����͂ł�����
        //InvokeRepeating�͓���������@�Œ萶���ɂ͎g����
        switch (RandomSelect)
        {
            case 1:
                //�G�l�~�[�𐶐�
                InvokeRepeating("Player2Factory", 1.0f, intervalf);
                InvokeRepeating("Player3Factory", 2.0f, intervals);
                InvokeRepeating("Player4Factory", 3.0f, intervalt);
                break;
            case 2:
                InvokeRepeating("Player1Factory", 1.0f, intervalf);
                InvokeRepeating("Player3Factory", 2.0f, intervals);
                InvokeRepeating("Player4Factory", 3.0f, intervalt);
                break;
            case 3:
                InvokeRepeating("Player1Factory", 1.0f, intervalf);
                InvokeRepeating("Player2Factory", 2.0f, intervals);
                InvokeRepeating("Player4Factory", 3.0f, intervalt);
                break;
            case 4:
                InvokeRepeating("Player1Factory", 1.0f, intervalf);
                InvokeRepeating("Player2Factory", 2.0f, intervals);
                InvokeRepeating("Player3Factory", 3.0f, intervalt);
                break;
            default:
                break;
        }
    }

    //������L�����N�^�[��\�����郁�\�b�h
    void CharactorIndication()
    {
        switch (RandomSelect)
        {
            //�L�����N�^�[�C���[�W��\��
            case 1:
                image.sprite = Player1image;
                image2.sprite = Player1image;
                Debug.Log(RandomSelect);
                break;
            case 2:
                image.sprite = Player2image;
                image2.sprite = Player2image;
                Debug.Log(RandomSelect);
                break;
            case 3:
                image.sprite = Player3image;
                image2.sprite = Player3image;
                Debug.Log(RandomSelect);
                break;
            case 4:
                image.sprite = Player4image;
                image2.sprite = Player4image;
                Debug.Log(RandomSelect);
                break;
            default:
                break;

        }
    }

    void PlayerAnswerSelectF()
    {
        switch (RandomSelect)
        {
            case 1://��莞�ԊԊu�ŏ��������s�@����Ŏ��Ԃ��󂯂ăv���n�u�𐶐��ł���
                   //�������Ɏ��s���������\�b�h���A���ɍŏ��ɋN�����鎞�ԁA��O�ɍX�V���鎞��
                InvokeRepeating("PASF1", 1.0f, intervalf);
                break;
            case 2:
                InvokeRepeating("PASF2", 1.0f, intervalf);
                break;
            case 3:
                InvokeRepeating("PASF3", 1.0f, intervalf);
                break;
            case 4:
                InvokeRepeating("PASF4", 1.0f, intervalf);
                break;
            default:
                break;
        }
    }

    //���ז��G�l�~�[�쐬����
    void Player1Factory()
    {
        Instantiate(Player1, new Vector3(0.0f, 7.0f, 0.0f), Quaternion.identity);
    }

    void Player2Factory()
    {
        Instantiate(Player2, new Vector3(0.0f, 7.0f, 0.0f), Quaternion.identity);
    }

    void Player3Factory()
    {
        Instantiate(Player3, new Vector3(0.0f, 7.0f, 0.0f), Quaternion.identity);
    }

    void Player4Factory()
    {
        Instantiate(Player4, new Vector3(0.0f, 7.0f, 0.0f), Quaternion.identity);
    }

    //������ׂ�Player�𐶐�����
    void PASF1()
    {
        count += 1;
        //�L�����N�^�[�𐶐�
        Instantiate(Player1, new Vector3(0.0f, 7.0f, 0.0f), Quaternion.identity);
        //count��answer�Ɠ����ɂȂ�����invoke���~
        if (count == RandomAnswer)
        {
            CancelInvoke("PASF1");
        }
    }

    void PASF2()
    {
        count += 1;
        Instantiate(Player2, new Vector3(0.0f, 7.0f, 0.0f), Quaternion.identity);
        if (count == RandomAnswer)
        {
            CancelInvoke("PASF2");
        }
    }

    void PASF3()
    {
        count += 1;
        Instantiate(Player3, new Vector3(0.0f, 7.0f, 0.0f), Quaternion.identity);
        if (count == RandomAnswer)
        {
            CancelInvoke("PASF3");
        }
    }

    void PASF4()
    {
        count += 1;
        Instantiate(Player4, new Vector3(0.0f, 7.0f, 0.0f), Quaternion.identity);
        if (count == RandomAnswer)
        {
            CancelInvoke("PASF4");
        }
    }

    //Start�������ꂽ��A������\�����Ďn�߂邽�߂̃R���[�`��
    IEnumerator GameStart()
    {
        //txet�̃X�P�[�������X�ɑ傫�����Ă�����ۂ�������
        textbuff = true;

        //�X�^�[�g�̍��m�@�ł����text���A�j���[�V�����ۂ�������
        yield return new WaitForSeconds(5f);

        //Starttext���\����
        Starttext.enabled = false;

        //�X�^�[�g���m�̌Ăяo��
        PlayerAnswerSelectF();
        SelectFactory();

        //�^�C�}�[�X�^�[�g
        StartTime = true;
    }

    //Result�p�̃R���[�`��
    IEnumerator Resultct()
    {
        //text�����������ďI����m�点��
        Starttext.text = "�I��";
        Starttext.enabled = true;

        //�I���z�C�b�X��
        audioSource.PlayOneShot(hue);

        //��b���ResultPanel��\������
        yield return new WaitForSeconds(2f);

        ResultPanel.SetActive(true);
    }

    //���͂��ꂽ���l�������Ă��邩�ǂ���
    public void Answer()
    {
        //���͂��ꂽ������𐔒l�ɕς��ē����Əƍ�
        int answern = int.Parse(answerField.text);
        if (answern == RandomAnswer)
        {
            CollationPanel.SetActive(true);
            audioSource.PlayOneShot(hakusyu);
            Debug.Log("a");
        }
        else
        {
            Ntext.text = "�c�O�c������x���A�^�C�g���ɖ߂��ĂˁB";
            audioSource.PlayOneShot(Out);

            //Button�o��
            select.SetActive(true);
            answer.SetActive(false);

            Debug.Log("no");
        }
    }

    //�V�[�����Ă΂ꂽ�Ƃ��ɌĂ΂��
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //scene���œ�Փx�ύX
        if (SceneManager.GetActiveScene().name == "EasyCount")
        { maxtime = 30.0f; }
        if (SceneManager.GetActiveScene().name == "NormalCount")
        {
            //���Ԃ̍ő�l
            maxtime = 15.0f;

            //answer�̍ŏ��l��ύX
            RandomAnswerMin = 7;
            RandomAnswerMax = 11;

            //Enemy�̃C���^�[�o����ύX
            intervalf = 1.0f;
            intervals = 1.5f;
            intervalt = 2.0f;

        }
    }
}