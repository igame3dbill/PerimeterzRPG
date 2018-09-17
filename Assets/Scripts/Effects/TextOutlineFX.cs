using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOutlineFX : MonoBehaviour
{

    [SerializeField]
    float maxX;
    float startX;
    [SerializeField]
    float maxY;
    float startY;
    [SerializeField]
    Text titleText;
    Outline textLine;
    [SerializeField]
    float changeRate;
    [SerializeField]
    float colorRate;
    // public Texture icon;
    public Color startColor = new Color(0f, 0f, 0f, 1f);
    private float rr = 0.0f, gg = 0.0f, bb = 0.0f;
    private int rv = 1, gv = 1, bv = 1;
    private float slowColorTime = 0.0f;

    // Use this for initialization
    void Start()
    {
        rr = startColor.r;
        gg = startColor.g;
        bb = startColor.b;
        textLine = titleText.GetComponent<Outline>();
        startX = textLine.effectDistance.x - maxX;
        startY = textLine.effectDistance.y - maxY;
    }

    // Update is called once per frame
    void Update()
    {
        float x = textLine.effectDistance.x;
        float y = textLine.effectDistance.y;
        if (textLine.effectDistance.x <= maxX)
        {
            x = textLine.effectDistance.x + changeRate;
        }
        else
        {
            x = startX;
        }

        if (textLine.effectDistance.y <= maxY)
        {
            y = textLine.effectDistance.y + changeRate;
        }
        else
        {
            y = startY;
        }

        textLine.effectDistance = new Vector2(x, y);

        textLine.effectColor = slowColor();



    }


    public Color slowColor()
    {
        Color GUITextColor = new Color(rr, gg, bb);
        slowColorTime = (Time.deltaTime * colorRate);
        // this little bit here cycles through colors very very slowly
        if (rr <= 0.0f) { rv = 1; }
        if (gg <= 0.0f) { gv = 1; }
        if (bb <= 0.0f) { bv = 1; }
        if (rr >= 0.99f) { rv = rv = -1; }
        if (gg >= 0.99f) { gv = gv = -1; }
        if (bb >= 0.99f) { bv = bv = -1; }
        if (rr <= 1.0f && gg <= 0.9f) { rr += (slowColorTime * rv); }
        if (gg <= 1.0f && rr >= 0.5f) { gg += (slowColorTime * gv); }
        if (bb <= 1.0f && gg >= 0.5f) { bb += (slowColorTime * bv); }
        return GUITextColor;
    }


}
