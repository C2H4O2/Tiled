using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DescriptionText : MonoBehaviour
{
    private TMP_Text descriptionTextField;

    public TMP_Text DescriptionTextField { get => descriptionTextField; set => descriptionTextField = value; }

    // Start is called before the first frame update
    void Start()
    {
        descriptionTextField = GetComponent<TMP_Text>();
    }

    
}
