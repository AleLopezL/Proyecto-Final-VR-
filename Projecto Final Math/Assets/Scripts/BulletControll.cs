using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("bulletdespawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator bulletdespawn()
    {
        yield return new  WaitForSeconds(3);
        this.gameObject.SetActive(false);
    }
}
