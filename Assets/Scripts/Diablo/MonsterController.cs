using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
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

    private void OnDestroy()
    {
        QTEController.Instance.onGoodQTE -= OnGoodQTE;
    }
}