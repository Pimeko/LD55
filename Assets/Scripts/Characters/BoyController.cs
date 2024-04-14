using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyController : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    private void Start()
    {
        QTEController.Instance.onGoodQTE += OnGoodQTE;
    }

    void OnGoodQTE()
    {
        animator.SetTrigger("hit");
    }
}