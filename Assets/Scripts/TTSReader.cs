using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TTSReader : MonoBehaviour
{

    public GameObject inputTextObj;

    public AudioManager audio;

    char[] characters;

    public float speakSpeed = 0.15f;

    private bool timeToRead;
    private bool audioIsPlaying;

    private string inputText;
    private string letter;

    private int letterCounter;

    public void Awake() {
        audio = FindObjectOfType<AudioManager>().GetComponent<AudioManager>();
    }

    public void Start() {
        timeToRead = false;
        audioIsPlaying = false;
        letterCounter = 0;
    }

    public void Update() {
        inputText = inputTextObj.GetComponent<TMPro.TextMeshProUGUI>().text;
        characters = inputText.ToCharArray();

        audioIsPlaying = audio.IsPlaying();

        if (timeToRead) {
            CallNextLetter();
        }
    }

    // public void CallAudio() {
            

    //     if (letterCounter == characters.Length - 1) {
    //         letterCounter = 0;
    //         timeToRead = false;
    //     } else {
    //         letterCounter++;
    //     }
    // }

    public void CallNextLetter() {
        timeToRead = false;
        letter = characters[letterCounter].ToString().ToUpper();
        if (letterCounter == characters.Length - 1) {
            letterCounter = 0;
        } else {
            audio.Play(letter);
            Invoke("CallNextLetter", audio.currentSound.clip.length - speakSpeed);
            letterCounter++;
        }
    }

    public void ReadText()
    {
        timeToRead = true;
    }
}
