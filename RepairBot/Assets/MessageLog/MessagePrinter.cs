using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagePrinter : MonoBehaviour
{
    public Text line1;
    public Text line2;
    public Text line3;
    public float delay = 2f;

    // Start is called before the first frame update
    void Start()
    {
        line1.text = "";
        line2.text = "";
        line3.text = "";
    }

    private void usageSample()
    {
        string[] test = { "Hello There", "This is a test", "of the log system", "extra line" };
        StartCoroutine(printTextToLog(test));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Pass messages to be printed out as an array of strings
    //The array must have at least 1 string
    IEnumerator printTextToLog(string[] messages)
    {
        

        if (messages.Length < 1)
        {
            Debug.LogError("MessagePrinter recieved empty array");
            yield return null;
        }


        line1.text = messages[0];
        line2.text = "";
        line3.text = "";
        yield return new WaitForSecondsRealtime(delay);

        for (int i = 1; i < messages.Length; i++)
        {
            line3.text = line2.text;
            line2.text = line1.text;
            line1.text = messages[i];
            yield return new WaitForSecondsRealtime(delay);
        }

        yield return new WaitForSecondsRealtime(delay);
        line3.CrossFadeAlpha(0.0f, 1.0f, true);
        yield return new WaitForSecondsRealtime(delay);
        line2.CrossFadeAlpha(0.0f, 1.0f, true);
        yield return new WaitForSecondsRealtime(delay);
        line1.CrossFadeAlpha(0.0f, 1.0f, true);
        yield return new WaitForSecondsRealtime(delay);

        line1.text = "";
        line2.text = "";
        line3.text = "";


        yield return null;
    }
}
