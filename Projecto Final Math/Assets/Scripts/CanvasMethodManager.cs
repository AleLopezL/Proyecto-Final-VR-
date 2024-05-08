using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasMethodManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Screen 1
    public void ScreenOnePlay()
    {
        AudioManager.instance.PlaySFX("Button");
    }
    public void Multiplayer()
    {
        AudioManager.instance.PlaySFX("Play");
        SCManager.instance.LoadScene("MultiplayerScene");
    }
    public void Settings()
    {
        AudioManager.instance.PlaySFX("Button");
    }
    public void Screen1Exit()
    {
        AudioManager.instance.PlaySFX("Button");
    }
    //Screen 1.1

    public void Back()
    {
        AudioManager.instance.PlaySFX("Button");
    }
    public void Summs()
    {
        GameManager.instance.boolController(0);
        AudioManager.instance.PlaySFX("Play");
        SCManager.instance.LoadScene("GameScene");
        GameManager.instance.electQuestion();
    }
    public void Substracts()
    {
        GameManager.instance.boolController(1);
        AudioManager.instance.PlaySFX("Play");
        SCManager.instance.LoadScene("GameScene");
        GameManager.instance.electQuestion();
    }
    public  void Multiply()
    {
        GameManager.instance.boolController(2);
        AudioManager.instance.PlaySFX("Play");
        SCManager.instance.LoadScene("GameScene");
        GameManager.instance.electQuestion();
    }
    public void Divide()
    {
        GameManager.instance.boolController(3);
        AudioManager.instance.PlaySFX("Play");
        SCManager.instance.LoadScene("GameScene");
        GameManager.instance.electQuestion();
    }
    public void Ecuations()
    {
        GameManager.instance.boolController(4);

        AudioManager.instance.PlaySFX("Play");
        SCManager.instance.LoadScene("GameScene");
        GameManager.instance.electQuestion();
    }

    public void Mixed()
    {
        AudioManager.instance.PlaySFX("Button");
    }

    // Screen 1.1.1

    public void BackScreenMixed() {
        AudioManager.instance.PlaySFX("Button");
    }
    public void MixedSums(Toggle toogle)
    {
        AudioManager.instance.PlaySFX("Toogle");
        GameManager.instance._BoolPool[0] = toogle.isOn;
    }

    public void MixedSubstracts(Toggle toogle)
    {
        AudioManager.instance.PlaySFX("Toogle");
        GameManager.instance._BoolPool[1] = toogle.isOn;
    }

    public void MixedMultiply(Toggle toogle)
    {
        AudioManager.instance.PlaySFX("Toogle");
        GameManager.instance._BoolPool[2] = toogle.isOn;
    }

    public void MixedDivide(Toggle toogle)
    {
        AudioManager.instance.PlaySFX("Toogle");
        GameManager.instance._BoolPool[3] = toogle.isOn;
    }
    public void MixedEquations(Toggle toogle)
    {
        AudioManager.instance.PlaySFX("Toogle");
        GameManager.instance._BoolPool[4] = toogle.isOn;
    }
    public void MixedPlay()
    {
        AudioManager.instance.PlaySFX("Play");
        GameManager.instance._IsMixed = true;
        SCManager.instance.LoadScene("MainGame");
        GameManager.instance.electQuestion();
    }
}
