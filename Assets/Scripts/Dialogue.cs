using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUI;
    public List<string> lines;
    public float textSpeed;

    private int index = 0;
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
        if(index < lines.Count - 1)
        {
            index++;
            textMeshProUI.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            //gameObject.SetActive(false);
            ShowDialogCanvas(false);
 

        }
    }

    public void ShowDialogCanvas(bool show)
    {
        transform.GetComponent<Image>().enabled = show;
        textMeshProUI.text = "";
    }

    public void AddDialogAndShow(string newDialog)
    {
        lines.Add(newDialog);
        NextLine();
        ShowDialogCanvas(true);
    }
}
