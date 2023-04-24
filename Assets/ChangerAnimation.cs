using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangerAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    public void ActivationTalk()
    {
        _animator.SetBool("Talk", true);
    }
}
