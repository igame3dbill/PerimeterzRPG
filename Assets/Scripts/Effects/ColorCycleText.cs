using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorCycleText : MonoBehaviour {

    // Coloring the GUI
    [SerializeField] Color startColor;
    private float rr = 0.0f, gg = 0.0f, bb = 0.0f;
    private int rv = 1, gv = 1, bv = 1;
    private float slowColorTime = 0.0f;
    [SerializeField] float colorStep = 0.05f;
    [SerializeField] Text TextToColor;
    // color the GUI
    
    public Color slowColor()
    {
        Color TextColor = new Color(rr, gg, bb);
        slowColorTime = (Time.deltaTime * colorStep);
        // this little bit here cycles through colors very very slowly
        if (rr <= 0.0f) { rv = 1; }
        if (gg <= 0.0f) { gv = 1; }
        if (bb <= 0.0f) { bv = 1; }
        if (rr >= 0.99f) { rv = -1; }
        if (gg >= 0.99f) { gv = -1; }
        if (bb >= 0.99f) { bv = -1; }
        if (rr <= 1.0f && gg <= 0.9f) { rr += (slowColorTime * rv); }
        if (gg <= 1.0f && rr >= 0.5f) { gg += (slowColorTime * gv); }
        if (bb <= 1.0f && gg >= 0.5f) { bb += (slowColorTime * bv); }
        return TextColor;
    }

    // Use this for initialization
    void Start () {
		rr = startColor.r;
        bb = startColor.b;
        gg = startColor.g;
    }
	
	// Update is called once per frame
	void Update () {
        TextToColor.color = slowColor();
	}
}
