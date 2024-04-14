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
    

    [SerializeField]
    Vector2 delayBetweenOpenRange;

    Transform previousBoyContainerTransform;

    public Action onBegin, onStop;

    private void Start()
    {
        QTEController.Instance.onDone += OnQTEDone;
        BeginInterval();
    }
    
    void BeginInterval()
    {
        float delay = UnityEngine.Random.Range(delayBetweenOpenRange.x, delayBetweenOpenRange.y);
        DOVirtual.DelayedCall(delay, Begin);
    }

    public void Begin()
    {
        DOTween.Sequence()
            .AppendInterval(0.5f)
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

    void OnQTEDone()
    {
        Stop();
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

        BeginInterval();
    }

    private void OnDestroy()
    {
        QTEController.Instance.onDone -= OnQTEDone;
    }
}