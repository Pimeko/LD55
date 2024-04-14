using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlController : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    void Start()
    {
        GameController.Instance.onBeginSentence += BeginSentence;
        GameController.Instance.onBeginAnswer += BeginAnswer;
    }

    void BeginSentence()
    {
        animator.SetBool("isTalking", true);
    }

    void BeginAnswer()
    {
        animator.SetBool("isTalking", false);
    }

    private void OnDestroy()
    {
        GameController.Instance.onBeginSentence -= BeginSentence;
        GameController.Instance.onBeginAnswer -= BeginAnswer;
    }
}