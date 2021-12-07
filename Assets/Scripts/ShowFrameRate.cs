using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFrameRate : MonoBehaviour
{
    public float timer, refresh, averageFramerate;
    public string display = "FPS: {0}";
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float timeLapse = Time.smoothDeltaTime;
        timer = timer <= 0 ? refresh : timer -= timeLapse;

        if (timer <= 0) averageFramerate = (int)(1f / timeLapse);
        text.text = string.Format(display, averageFramerate.ToString());
    }
}
