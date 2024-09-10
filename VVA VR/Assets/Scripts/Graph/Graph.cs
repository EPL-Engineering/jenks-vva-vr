using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public UdpSignal UdpSignal;
    private float[] data;

    List<GameObject> lineList = new List<GameObject>();

    private DD_DataDiagram m_DataDiagram;
    //private RectTransform DDrect;

    private float m_Input = 0f;

    void AddALine(Color color)
    {
        if (null == m_DataDiagram)
            return;

        //float h = Random.value;
        //Color color = Color.HSVToRGB((h += 0.1f) > 1 ? (h - 1) : h, 0.8f, 0.8f);
        GameObject line = m_DataDiagram.AddLine(color.ToString(), color);
        lineList.Add(line);
    }

    // Use this for initialization
    void Start()
    {
        GameObject dd = GameObject.Find("DataDiagram");
        if (null == dd)
        {
            Debug.LogWarning("can not find a gameobject of DataDiagram");
            return;
        }
        m_DataDiagram = dd.GetComponent<DD_DataDiagram>();
        m_DataDiagram.PreDestroyLineEvent += (s, e) => { lineList.Remove(e.line); };


        AddALine(Color.white);
        AddALine(Color.green);
        //AddALine();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        m_Input += Time.deltaTime;
        data = UdpSignal.signalData;
        ContinueInput(m_Input);
    }

    private void ContinueInput(float f)
    {
        if (null == m_DataDiagram)
            return;
        m_DataDiagram.InputPoint(lineList[0], new Vector2(0.01f, 511));
        m_DataDiagram.InputPoint(lineList[1], new Vector2(0.01f, (data[0]+511/2)));


    }
}
