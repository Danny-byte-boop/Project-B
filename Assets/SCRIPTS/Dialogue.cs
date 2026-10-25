using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
public class Dialogue : MonoBehaviour
{
    //variables to make the lines appear in the text box along with textspeed.
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    // Start() just calls the StartDialogue() method.
    void Start()
    {
        
        textComponent.text = string.Empty;
        StartDialogue();
    }


    // Update() just makes the textbox go to the next line when the player hits the left mouse button. When
    //the player gets through all of the dialogue the textbox disappears.
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }
    //StartDialogue() starts the dialogue in the dynamic textbox.
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    //NextLine() just grabs the next line from the Dialogue that I manually wrote.
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            Debug.Log("Dialogue has concluded");
            gameObject.SetActive(false);

            string currentScene = SceneManager.GetActiveScene().name;
            if (currentScene != "Level1, The Trial Begins")
            {
                Debug.Log("Loading Level 1...");
                SceneManager.LoadScene("Level1, The Trial Begins");
            }
        }
    }
    //https://www.youtube.com/watch?v=8oTYabhj248 this is my source. It helped me with being able to do
    //the dynamic textbox
}


