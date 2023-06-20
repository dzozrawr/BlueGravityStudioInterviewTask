using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPrompt : MonoBehaviour
{
    private Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    public void Show(bool shouldShow)
    {
        canvas.enabled = shouldShow;
    }


    public bool IsShown()
    {
        return canvas.enabled;
    }
}
