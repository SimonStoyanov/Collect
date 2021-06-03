using UnityEngine;
using UnityEngine.UI;

public class fpsCounter : MonoBehaviour
{
    Text fpsDisplay;

    // Start is called before the first frame update
    void Start()
    {
        fpsDisplay = this.GetComponent<Text>();
    }

    void Update()
    {
        float fps = 1 / Time.unscaledDeltaTime;
        fpsDisplay.text = "" + fps;
    }
}
