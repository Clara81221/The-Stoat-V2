using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFader : MonoBehaviour
{
    public TextMeshProUGUI HelpText;
    float sinceStart;
    // Start is called before the first frame update
    void Start()
    {
        
        sinceStart = 0f;
    }
    void Update()
    {
        sinceStart += Time.deltaTime;
        if (sinceStart >= 6.75f)
        {
            HelpText.alpha -= 5 * Time.deltaTime;
        }
    }
}
