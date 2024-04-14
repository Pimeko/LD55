using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QTEElementController : MonoBehaviour
{
    [SerializeField]
    TMP_Text textMesh;

    public void Init(char letter)
    {
        textMesh.text = letter.ToString();
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}