using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BlurController : MonoBehaviour
{
    [SerializeField]
    GameObject container;

    void Start()
    {
        DiabloController.Instance.onBegin += OnBegin;
        DiabloController.Instance.onStop += OnStop;

        OnStop();
    }

    void OnBegin()
    {
        container.SetActive(true);
    }

    void OnStop()
    {
        container.SetActive(false);
    }

    void OnDestroy()
    {

        DiabloController.Instance.onBegin -= OnBegin;
        DiabloController.Instance.onStop -= OnStop;
    }
}