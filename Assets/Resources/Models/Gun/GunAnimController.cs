using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnimController : MonoBehaviour
{
    // Start is called before the first frame update
    Animator _animator;
    AnimationClip _shoot;
    void Start()
    {
       
        _animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger("isShoot");
            
        }
        
    }


}
