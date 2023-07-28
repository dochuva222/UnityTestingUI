using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixedSize : MonoBehaviour
{
    public float fixedWidth = 667f;
    public float fixedHeight = 924f;
    [SerializeField]
    Canvas Canvas1;

    private Image image;
    private RectTransform rectTransform;

    private void Start()
    {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        
        SetFixedSize();
    }

    private void SetFixedSize()
    {
        float scaleFactor = GetScaleFactor();

        rectTransform.sizeDelta = new Vector2(fixedWidth / scaleFactor, fixedHeight / scaleFactor);
    }

    private float GetScaleFactor()
    {
        Canvas canvas = GetComponentInParent<Canvas>();
        float scaleFactor = canvas.scaleFactor;

        if (canvas.GetComponent<CanvasScaler>().uiScaleMode == CanvasScaler.ScaleMode.ScaleWithScreenSize)
        {
            float referenceWidth = canvas.GetComponent<CanvasScaler>().referenceResolution.x;
            float currentWidth = canvas.GetComponent<RectTransform>().rect.width;

            scaleFactor *= currentWidth / referenceWidth;
        }

        return scaleFactor;
    }
}
