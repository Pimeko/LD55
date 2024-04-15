using System.Collections;
using System.Collections.Generic;
using cherrydev;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    [SerializeField]
    DialogBehaviour dialogBehaviour;
    [SerializeField]
    DialogNodeGraph dialogGraph;

    void Start()
    {
        dialogBehaviour.BindExternalFunction("GameOver", () => GameController.Instance.RunGameOver(false));
        dialogBehaviour.BindExternalFunction("Victory", () => GameController.Instance.RunVictory());
        dialogBehaviour.StartDialog(dialogGraph);
    }

}