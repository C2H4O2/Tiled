using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DescriptorDisplayer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private DescriptionText descriptionText;
    private void Awake() {
        descriptionText = FindFirstObjectByType<DescriptionText>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        EffectTile effectTile = GetComponent<EffectTile>();
        descriptionText.DescriptionTextField.text = effectTile.Description;
        
    }

    // Called when the pointer exits the UI element
    public void OnPointerExit(PointerEventData eventData)
    {
        descriptionText.DescriptionTextField.text = null;
        
    }
}
