using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Time Manager")]
    [SerializeField] GameObject timeManager;
    [SerializeField] public bool _IsStarted;
    [Header("Score")]
    [SerializeField]public  int scoreCount;

    [Header("ElectionControll")]
    [SerializeField] public bool[] _BoolPool;

    [TextArea]
    [SerializeField] string BoolPoolReferences;
    [SerializeField] public bool _IsElected;
    [SerializeField] public bool _IsMixed;
    [SerializeField] public GameObject _DictionaryManager;
    private void Awake()
    {
        // ----------------------------------------------------------------
        // AQUÍ ES DONDE SE DEFINE EL COMPORTAMIENTO DE LA CLASE SINGLETON
        // Garantizamos que solo exista una instancia del AudioManager
        // Si no hay instancias previas se asigna la actual
        // Si hay instancias se destruye la nueva
        if (instance == null) instance = this;
        else { Destroy(gameObject); return; }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
       // AudioManager.instance.PlayMusic("MainGame");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void win()
    {

    }

    public void startGame()
    {
        if (!_IsStarted)
        {
            timeManager = GameObject.FindWithTag("TimeManager");
            _IsStarted = true;
            timeManager.GetComponent<TimeManager>().StartCoroutine("UpdateTotalTimer");
            timeManager.GetComponent<TimeManager>().StartCoroutine("UpdateQuestionTimer");
            _DictionaryManager = GameObject.FindWithTag("DictionaryManager");
            electQuestion();
        }
    }

    public void failQuestion()
    {
        timeManager.GetComponent<TimeManager>()._IsAnswered = true;
        scoreCount -= 20;

        timeManager.GetComponent<TimeManager>().restartQuestion();
    }
    public void accertQuestion()
    {
       
        timeManager.GetComponent<TimeManager>()._IsAnswered = true;
        scoreCount += 10;
        timeManager.GetComponent<TimeManager>().restartQuestion();
    }

    public void endOfGame()
    {
        Time.timeScale = 0f;
        restartBoolPool();
        _IsMixed=  false;
        
        SCManager.instance.LoadScene("EndGame");
    }

    
    public void electQuestion()
    {
        Debug.Log("electQuestion");
        if (_IsMixed)
        {
            while (!_IsElected)
            {

                switch (Random.Range(0, 5))
                {
                    case 0:
                        if (_BoolPool[0])
                        {
                            Debug.Log("Sumas");
                            _DictionaryManager.GetComponent<DictionaryManager>().PlaySums();
                            _IsElected = true;
                        }
                        break;
                    case 1:
                        if (_BoolPool[1])
                        {
                            _DictionaryManager.GetComponent<DictionaryManager>().PlaySubsttacts();
                            _IsElected = true;                     
                        }
                        break;
                    case 2:
                        if (_BoolPool[2]) {
                            _DictionaryManager.GetComponent<DictionaryManager>().PlayMultiplies();
                            _IsElected = true;

                                }
                        break;
                    case 3:
                        if (_BoolPool[3]) {
                            _DictionaryManager.GetComponent<DictionaryManager>().PlayDivides(); 
                            _IsElected = true;
                        }
                        break;
                    case 4:
                    if (_BoolPool[4]) {
                            _DictionaryManager.GetComponent<DictionaryManager>().PlayEcuations(); 
                        _IsElected = true;
                        }
                        break;
                }
            }
        }
        else {
            Debug.Log("electQuestionSimple");
            for (int i = 0; i < _BoolPool.Length; i++)
            {
                if(_BoolPool[i] == true)
                {
                    Debug.Log("electQuestionSimpletrue");
                    _DictionaryManager.GetComponent<DictionaryManager>().electSectionSimple(i);
                }

            }
            }
    }


    public void boolController(int selected)
    {
        for(int i= 0;i<_BoolPool.Length;i++)
        {
            if(selected == i)
            {
                _BoolPool[i] = true;
            }
            else
            {
                _BoolPool[i] = false;
            }

        }

    }
    public void restartBoolPool()
    {
        for (int i = 0; i < _BoolPool.Length; i++)
        {
            
                _BoolPool[i] = false;

        }
    }
}
