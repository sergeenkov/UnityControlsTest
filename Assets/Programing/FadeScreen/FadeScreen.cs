using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public static class FadeScreen {
    //Create Fader object and assing the fade scripts and assign all the variables
    public static void Fade (string inSceneName, Color inColor, float inDamp)
    {
        GameObject goCanvas;
        goCanvas = new GameObject("FadeCanvas");
        Canvas cCanvas = goCanvas.AddComponent<Canvas>();
        cCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        goCanvas.AddComponent<CanvasScaler>();
        goCanvas.AddComponent<GraphicRaycaster>();
        goCanvas.layer = SortingLayer.GetLayerValueFromName("UI");
        cCanvas.sortingOrder = 100;

        GameObject goPanel = new GameObject("FadePanel");         
        goPanel.AddComponent<CanvasRenderer>();        
        Image cImage = goPanel.AddComponent<Image>();
        cImage.color = new Color(0, 0, 0, 0);
        Fader fader = goPanel.AddComponent<Fader>();
        fader.fadeDamp = inDamp;
        fader.fadeScene = inSceneName;
        fader.fadeColor = inColor;
        fader.start = true;


        goPanel.transform.SetParent(goCanvas.transform);
        RectTransform rectTransform = goPanel.GetComponent<RectTransform>();        
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.anchorMax = Vector2.one;
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
        rectTransform.anchoredPosition = Vector2.zero;
        
    }
}
