using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoatController : MonoBehaviour
{
    public AudioSource MainAudio;
    public TextMeshProUGUI cardText;
    float sinceLastKeypress;
    public bool hold = false;
    float sinceLastBlink;
    float sinceLastOpen;
    public GameObject EyesOpen;
    public GameObject EyesClosed;
    public GameObject Menu;
    public GameObject MouthOpen;
    public GameObject MouthClosed;

    public void setHold(bool isHold)
    {
        hold = isHold;
    }
    void Update()
    {
        if (Menu.activeSelf == false)
        {
            if (Input.anyKeyDown)
            {

                if (Input.GetKeyDown(KeyCode.Backspace))
                {
                    cardText.SetText(cardText.text.Remove(cardText.text.Length - 1, 1));
                    sinceLastKeypress = 0f;
                }
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    cardText.SetText("");
                }
                if (Input.inputString == "A" | Input.inputString == "B" | Input.inputString == "C" | Input.inputString == "D" | Input.inputString == "E" | Input.inputString == "F" | Input.inputString == "G" | Input.inputString == "H" | Input.inputString == "I" | Input.inputString == "J" | Input.inputString == "K" | Input.inputString == "L" | Input.inputString == "M" | Input.inputString == "N" | Input.inputString == "O" | Input.inputString == "P" | Input.inputString == "Q" | Input.inputString == "R" | Input.inputString == "S" | Input.inputString == "T" | Input.inputString == "U" | Input.inputString == "V" | Input.inputString == "W" | Input.inputString == "X" | Input.inputString == "Y" | Input.inputString == "Z" | Input.inputString == "a" | Input.inputString == "b" | Input.inputString == "c" | Input.inputString == "d" | Input.inputString == "e" | Input.inputString == "f" | Input.inputString == "g" | Input.inputString == "h" | Input.inputString == "i" | Input.inputString == "j" | Input.inputString == "k" | Input.inputString == "l" | Input.inputString == "m" | Input.inputString == "n" | Input.inputString == "o" | Input.inputString == "p" | Input.inputString == "q" | Input.inputString == "r" | Input.inputString == "s" | Input.inputString == "t" | Input.inputString == "u" | Input.inputString == "v" | Input.inputString == "w" | Input.inputString == "x" | Input.inputString == "y" | Input.inputString == "z" | Input.inputString == "1" | Input.inputString == "2" | Input.inputString == "3" | Input.inputString == "4" | Input.inputString == "5" | Input.inputString == "6" | Input.inputString == "7" | Input.inputString == "8" | Input.inputString == "9" | Input.inputString == "0" | Input.inputString == "!" | Input.inputString == "#" | Input.inputString == "$" | Input.inputString == "%" | Input.inputString == "^" | Input.inputString == "&" | Input.inputString == "*" | Input.inputString == "(" | Input.inputString == ")" | Input.inputString == "-" | Input.inputString == "=" | Input.inputString == "_" | Input.inputString == "+" | Input.inputString == "[" | Input.inputString == "]" | Input.inputString == "{" | Input.inputString == "}" | Input.inputString == ";" | Input.inputString == ":" | Input.inputString == "'" | Input.inputString == "\"" | Input.inputString == "," | Input.inputString == "." | Input.inputString == "<" | Input.inputString == ">" | Input.inputString == "/" | Input.inputString == "?" | Input.inputString == "`" | Input.inputString == "~" | Input.inputString == "\\" | Input.inputString == "|" | Input.inputString == " ")
                {
                    MouthOpen.SetActive(true);
                    MouthClosed.SetActive(false);
                    MainAudio.Play();
                    if (sinceLastKeypress < .75f)
                    {
                        if (cardText.text.Length < 184)
                        {
                            cardText.SetText(cardText.text += Input.inputString);
                        }
                    }
                    if (sinceLastKeypress >= .75f)
                    {
                        cardText.SetText("");
                        cardText.SetText(Input.inputString);
                    }
                    sinceLastKeypress = 0f;
                }
            }
            else
            {
                sinceLastKeypress += Time.deltaTime;
            }            
            if (sinceLastKeypress >= .1f)
            {
                MouthOpen.SetActive(false);
                MouthClosed.SetActive(true);
            }
            if (hold == false)
            {
                if (sinceLastKeypress >= .75f)
                {
                    cardText.SetText("Stoat");
                }
            }
            if (EyesOpen.activeSelf)
            {
                sinceLastBlink += Time.deltaTime;
            }
            if (EyesClosed.activeSelf)
            {
                sinceLastOpen += Time.deltaTime;
            }
            if (sinceLastOpen >= .5f)
            {
                EyesOpen.SetActive(true);
                EyesClosed.SetActive(false);
                sinceLastOpen = 0f;
            }
            if (sinceLastBlink >= 8f)
            {
                EyesOpen.SetActive(false);
                EyesClosed.SetActive(true);
                sinceLastBlink = 0f;
            }
            
        }
    }
}
