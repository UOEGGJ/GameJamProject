using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUI;
    public string[] lines;
    public float textSpeed;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        textMeshProUI.text = string.Empty;
        StartDialogue();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(textMeshProUI.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textMeshProUI.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textMeshProUI.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
       
    }

    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textMeshProUI.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
