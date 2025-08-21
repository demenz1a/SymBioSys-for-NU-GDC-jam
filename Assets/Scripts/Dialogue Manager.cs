using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public string[] lines;
    public Color[] lineColors; // 🎨 массив цветов для каждой строки
    public float speedText;
    public GameObject blacked;
    public bool isEnd = false;
    public GameObject cutscene;

    public TextMeshProUGUI dialogueText;
    public GameObject dialogue;

    private int index;
    public int endnum;

    public static bool hasSeenBlockDialogue = false;

    private void Start()
    {
        if (hasSeenBlockDialogue)
        {
            gameObject.SetActive(false);
            return;
        }

        dialogueText.text = string.Empty;
        StartDialogue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SkipTextClick();
        }
    }

    public void StartDialogue()
    {
        Time.timeScale = 1f;
        StartDialogueFromIndex(0);
    }

    public void StartDialogueFromIndex(int startIndex)
    {
        //Instantiate(blacked);
        gameObject.SetActive(true);
        blacked.SetActive(true);
        dialogue.SetActive(true);
        index = startIndex;
        dialogueText.text = string.Empty;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        dialogueText.text = string.Empty;

        // Определяем цвет для текущей строки
        Color col = Color.white;
        if (lineColors != null && index < lineColors.Length)
            col = lineColors[index];

        dialogueText.color = col; // 🎨 ставим цвет напрямую

        foreach (char c in lines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSecondsRealtime(speedText);
        }

        // ⏳ Ждём чуть-чуть и идём к следующей строке
        yield return new WaitForSecondsRealtime(1f); // пауза между строками
        NextLines();
    }


    public void SkipTextClick()
    {
        Color col = Color.white;
        if (lineColors != null && index < lineColors.Length)
            col = lineColors[index];
        string hexColor = ColorUtility.ToHtmlStringRGBA(col);

        if (dialogueText.text == $"<color=#{hexColor}>{lines[index]}</color>")
        {
            NextLines();
        }
        else
        {
            StopAllCoroutines();
            dialogueText.text = $"<color=#{hexColor}>{lines[index]}</color>";
        }
    }

    private void NextLines()
    {
        if (index < lines.Length - 1)
        {
            index++;

            if (index == endnum && isEnd == false)
            {
                EndDialogue();
                return;
            }

            if (index == endnum && isEnd == true)
            {
                EndDialogue();
                Instantiate(cutscene);
                return;
            }

            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        gameObject.SetActive(false);
        blacked.SetActive(false);
        dialogue.SetActive(false);

    }
}

