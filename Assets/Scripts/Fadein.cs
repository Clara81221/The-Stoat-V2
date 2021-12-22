using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fadein : MonoBehaviour
{
    public GameObject Box;
    float sinceStart;
    Image image;
    Color color = new Color();
    // Start is called before the first frame update
    void Start()
    {
        sinceStart = 0f;
        image = GetComponent<Image>();
        color.a = 1;
    }
    void Update()
    {
        if (color.a > 0)
        {
            sinceStart += Time.deltaTime;
            if (sinceStart >= 2f)
            {
                color.a -= .15f * Time.deltaTime;
                image.color = color;
            }
        }
        else
        {
            Box.SetActive(false);
        }
    }
}
