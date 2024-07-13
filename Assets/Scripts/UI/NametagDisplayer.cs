using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NametagDisplayer : MonoBehaviour
{
    private TextMesh textMesh;
    private void Awake() {
        textMesh = GetComponent<TextMesh>();
    }
    void Start()
    {
        textMesh.text = GetComponentInParent<Player>().NameTag;
    }
}
