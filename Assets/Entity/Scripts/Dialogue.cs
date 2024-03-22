using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
public class Dialogue : MonoBehaviour
{

    public TextMeshPro textComponent;
    public string[] dialogue;
    public float dialogueSpeed;
    private int index;


    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        startDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(textComponent.text == dialogue[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = dialogue[index];
            }
        }
    }

    private void startDialogue()
    {
        index = 0;
    }

    private IEnumerator TypeLine()
    {
        //type characters 1 by 1
        foreach(char c in dialogue[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(dialogueSpeed);
        }
    }

    private void NextLine()
    {
        if ( index < dialogue.Length -1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
