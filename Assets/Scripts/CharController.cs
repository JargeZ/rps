using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharController : MonoBehaviour
{
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetAnimation(string animation)
    {
        Debug.Log("Set animation: " + animation);
        _animator.Play(animation);
    }


}
