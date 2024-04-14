using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEController : MonoBehaviour
{
    #region SINGLETON
    public static QTEController Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);

        Instance = this;
    }
    #endregion

    [SerializeField]
    GameObject qteElementPrefab, arrowGO;
    [SerializeField]
    RectTransform elementsParent;
    [SerializeField]
    Vector2 nbQTERange;

    Dictionary<char, KeyCode> chartoKeycode = new Dictionary<char, KeyCode>()
    {
        {'A', KeyCode.A},
        {'B', KeyCode.B},
        {'C', KeyCode.C},
        {'D', KeyCode.D},
        {'E', KeyCode.E},
        {'F', KeyCode.F},
        {'G', KeyCode.G},
        {'H', KeyCode.H},
        {'I', KeyCode.I},
        {'J', KeyCode.J},
        {'K', KeyCode.K},
        {'L', KeyCode.L},
        {'M', KeyCode.M},
        {'N', KeyCode.N},
        {'O', KeyCode.O},
        {'P', KeyCode.P},
        {'Q', KeyCode.Q},
        {'R', KeyCode.R},
        {'S', KeyCode.S},
        {'T', KeyCode.T},
        {'U', KeyCode.U},
        {'V', KeyCode.V},
        {'W', KeyCode.W},
        {'X', KeyCode.X},
        {'Y', KeyCode.Y},
        {'Z', KeyCode.Z}
    };

    List<QTEElementController> elementControllers;
    List<char> qtes;
    int nbDone;
    bool isDoingQTE;

    public Action onGoodQTE, onDone;

    void Start()
    {
        DiabloController.Instance.onBegin += OnBegin;
    }

    void OnBegin()
    {
        arrowGO.SetActive(true);

        elementControllers = new List<QTEElementController>();
        qtes = new List<char>();

        var nbQTE = UnityEngine.Random.Range(nbQTERange.x, nbQTERange.y);
        for (var i = 0; i < nbQTE; i++)
            Generate();

        nbDone = 0;
        isDoingQTE = true;
    }

    void Generate()
    {
        string all = "ABCDEFGHIJKLOPQRSTWXYZ";
        char c = all[UnityEngine.Random.Range(0, all.Length)];
        qtes.Add(c);

        var instance = Instantiate(qteElementPrefab, elementsParent);
        var elementController = instance.GetComponent<QTEElementController>();
        elementController.Init(c);

        elementControllers.Add(elementController);
    }

    void End()
    {
        arrowGO.SetActive(false);
        onDone?.Invoke();
            isDoingQTE = false;
    }

    void Update()
    {
        if (!isDoingQTE)
            return;

        foreach (var entry in chartoKeycode)
        {
            if (Input.GetKey(entry.Value))
            {
                if (entry.Key == qtes[nbDone])
                {
                    elementControllers[nbDone].Kill();
                    nbDone++;
                    onGoodQTE?.Invoke();
                }
            }
        }

        if (nbDone == elementControllers.Count)
            End();
    }

    void OnDestroy()
    {
        DiabloController.Instance.onBegin -= OnBegin;
    }
}