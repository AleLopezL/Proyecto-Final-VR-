using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryManager : MonoBehaviour
{
    public static DictionaryManager instance;

    [Header("Dictionaries")]
    [SerializeField] public Dictionary<int, string> D_simpleSums = new Dictionary<int,string>();
    [SerializeField] public Dictionary<int, string> D_simpleSubstracs = new Dictionary<int, string>();
    [SerializeField] public Dictionary<int, string> D_simpledivides = new Dictionary<int, string>();
    [SerializeField] public Dictionary<int, string> D_simplemultiplies = new Dictionary<int, string>();
    [SerializeField] public Dictionary<int, string> D_simpleEcuations = new Dictionary<int, string>();


    [Header("Controller")]
    [SerializeField] public int _Result;

    [Header("Texts to Add")]
    [SerializeField] string _SumText;
    [SerializeField] string _SubsText;
    [SerializeField] string _DivText;
    [SerializeField] string _MulText;
    [SerializeField] string _EcuText;

    [Header("Texts Arrays")]
    [SerializeField] string[] _SumArray;
    [SerializeField] string[] _SubsArray;
    [SerializeField] string[] _DivArray;
    [SerializeField] string[] _MulArray;
    [SerializeField] string[] _EcuArray;
    

    // Start is called before the first frame update
    void Start()
    {
     
        D_simpleSums.Clear();
        D_simpleSubstracs.Clear();
        D_simpledivides.Clear();
        D_simplemultiplies.Clear();
        D_simpleEcuations.Clear();

        _SumArray = _SumText.Split(";");
        _SubsArray = _SubsText.Split(";");
        _DivArray = _DivText.Split(";");
        _MulArray = _MulText.Split(";");
        _EcuArray = _EcuText.Split(";");

        
        startSubstracts();
        startEcuation();
        startMultiply();
        startSums();
        startDiv();
        StartCoroutine("startGame");
    }
    // Update is called once per frame
    void Update()
    {
;
    }

    public void electSectionSimple(int section)
    {
        Debug.Log("PruebaA");
        switch (section)
        {
            case 0: PlaySums();
                break;
            case 1: PlaySubsttacts();
                break;
            case 2:PlayMultiplies();
                break;
            case 3: PlayDivides();
                break;
            case 4: PlayEcuations();
                break;
        }
        
    }
    public void PlaySums()
    {
        Debug.Log("prueba2");
        CardTextGenerator.instance.WriteOnCall(D_simpleSums[Random.Range(0, D_simpleSums.Count)]);
    }
    public void PlaySubsttacts()
    {

        Debug.Log("prueba2");
        CardTextGenerator.instance.WriteOnCall(D_simpleSubstracs[Random.Range(0, D_simpleSubstracs.Count)]);
    }
    public void PlayDivides()
    {
        Debug.Log("prueba2");
        CardTextGenerator.instance.WriteOnCall(D_simpledivides[Random.Range(0, D_simpledivides.Count)]);
    }
    public void PlayMultiplies()
    {
        Debug.Log("prueba2");
        CardTextGenerator.instance.WriteOnCall(D_simplemultiplies[Random.Range(0, D_simplemultiplies.Count)]);
    }
    public void PlayEcuations()
    {
        Debug.Log("prueba2");
        CardTextGenerator.instance.WriteOnCallEcuation(D_simpleEcuations[Random.Range(0, D_simpleEcuations.Count)]);
    }
    void startSums()
    {
        for (int y = 0; y < _SumArray.Length; y++)
        {
            Debug.Log(y);
            D_simpleSums.Add(y, _SumArray[y]);
        }

    }
    void startSubstracts()
    {
        for (int y = 0; y < _SubsArray.Length; y++)
        {
            Debug.Log(y);
            D_simpleSubstracs.Add(y, _SubsArray[y]);
        }
    }

    void startDiv()
    {
        for (int y = 0; y < _DivArray.Length; y++)
        {
            Debug.Log(y);
            D_simpledivides.Add(y, _DivArray[y]);
        }
    }

    void startMultiply()
    {
        for (int y = 0; y < _MulArray.Length; y++)
        {
            Debug.Log(y);
            D_simplemultiplies.Add(y, _MulArray[y]);
        }
    }
    void startEcuation()
    {
        for (int y = 0; y < _EcuArray.Length; y++)
        {
            Debug.Log(y);
            D_simpleEcuations.Add(y, _EcuArray[y]);
        }
    }

    IEnumerator startGame()
    {
        yield return new WaitForSeconds(2);
        GameManager.instance.startGame();
        StopCoroutine("startGame");
    }
}
