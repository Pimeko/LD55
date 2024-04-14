using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DiabloController : MonoBehaviour
{
    #region SINGLETON
    public static DiabloController Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);

        Instance = this;
    }
    #endregion

    [SerializeField]
    Animator containerAnimator, necromancerAnimator;
    [SerializeField]
    RectTransform boy;
    [SerializeField]
    Transform boyTargetTransform;

    Transform previousBoyContainerTransform;

    public Action onBegin, onStop;

    public void Begin()
    {
        DOTween.Sequence()
            .AppendInterval(1)
            .AppendCallback(() =>
            {
                previousBoyContainerTransform = boy.transform.parent;
                boy.transform.SetParent(boyTargetTransform);
            })
            .Append(boy.DOLocalMove(Vector3.zero, 1.5f));

        containerAnimator.SetTrigger("open");
        necromancerAnimator.SetTrigger("summon");

        onBegin?.Invoke();
    }

    public void Stop()
    {
        containerAnimator.SetTrigger("close");
        DOTween.Sequence()
            .AppendCallback(() =>
            {
                boy.transform.SetParent(previousBoyContainerTransform);
            })
            .Append(boy.DOLocalMove(Vector3.zero, 1.5f));

        onStop?.Invoke();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Begin();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Stop();
        }
    }
}