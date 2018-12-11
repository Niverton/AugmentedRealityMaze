using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_controller : MonoBehaviour {

	private double axisX = 0.0;
	private double axisZ = 0.0;

    private static Graph labyrinth;
    private static CarteDistance map;
    public GameObject wall;
    public GameObject poteau;
    public GameObject confeti;
    public GameObject cases;
    public GameObject ball;
    static float SPAN = 1.2f;
    static float WALL = 0.2f;
    static float CELL = 0.6f;
    public void reset() {
        for (int i = 1; i < transform.childCount; i++)
            Destroy(transform.GetChild(i).gameObject);
        transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        axisZ = 0.0;
        axisX = 0.0;
        labyrinth = Graph.getInstance();
        drawWall(labyrinth);
        map = new CarteDistance(new Point((int)Mathf.Sqrt(labyrinth.GetSize()) - 1, (int)Mathf.Sqrt(labyrinth.GetSize()) - 1), labyrinth, SPAN, WALL, CELL, cases, this.transform);
        Vector3 decalage = new Vector3((WALL + CELL) * (-(int)Mathf.Sqrt(labyrinth.GetSize()) / 2.0f) * SPAN, 0, (WALL + CELL) * (-(int)Mathf.Sqrt(labyrinth.GetSize()) / 2.0f) * SPAN);
        ball.transform.position = new Vector3( WALL * SPAN*2.0f, 0.1f,  WALL * SPAN*2.0f) + decalage;
        int tmp = (int)Mathf.Sqrt(labyrinth.GetSize());
        float xx = tmp * (CELL * SPAN + WALL * SPAN) + WALL * SPAN * 2.0f;
        float yy = tmp * (CELL * SPAN + WALL * SPAN) + WALL * SPAN * 2.0f;
        GameObject tmpObj = Instantiate(confeti, new Vector3(xx, 0, yy) + decalage, Quaternion.identity);
        tmpObj.transform.localScale = new Vector3(CELL * SPAN, 1, CELL * SPAN);
        tmpObj.transform.SetParent(this.transform);
    }

    public void drawWall(Graph g)
    {
        int tmp = (int)Mathf.Sqrt(g.GetSize());
        Vector3 decalage = new Vector3((WALL + CELL) * (-tmp / 2.0f) * SPAN, 0, (WALL + CELL) * (-tmp / 2.0f) * SPAN);
        for (int xx = -1; xx < (int)Mathf.Sqrt(g.GetSize()); ++xx)
        {
            float offsetX = ((WALL + CELL) + (WALL + CELL) * xx) * SPAN;
            for (int yy = -1; yy < (int)Mathf.Sqrt(g.GetSize()); ++yy)
            {
                float offsetY = ((WALL + CELL) + (WALL + CELL) * yy) * SPAN;
                GameObject tmpObj = Instantiate(poteau, new Vector3(offsetX, 0, offsetY)+decalage, Quaternion.identity);
                tmpObj.transform.localScale = new Vector3(WALL * SPAN, 1, WALL * SPAN);
                tmpObj.transform.SetParent(this.transform);
            }
        }
        float x = 0, y = 0, xspan = 0, yspan = 0;
        xspan = WALL * SPAN;
        yspan = CELL * SPAN;
        for (int i = 0; i < g.GetSize(); i++)
        {
            Point p = g.GetPoint(i % tmp, i / tmp);

            if (p.GetEst() == null)
            {
                x = ((WALL + CELL) * ((i+1) % tmp)) * SPAN;
                y = (WALL + ((i) / tmp) * (WALL + CELL)) * SPAN+ WALL * SPAN;
                GameObject tmpObj = Instantiate(wall, new Vector3(x, 0, y)+ decalage, Quaternion.identity);
                tmpObj.transform.localScale = new Vector3(xspan, 1, yspan);
                tmpObj.transform.SetParent(this.transform);
            }
            if (p.GetNord() == null)
            {
                x = (WALL + ((i) % tmp) * (WALL + CELL)) * SPAN+ WALL * SPAN;
                y = ((WALL + CELL) * ((i) / tmp)) * SPAN;
                GameObject tmpObj = Instantiate(wall, new Vector3(x, 0, y)+ decalage, Quaternion.identity);
                tmpObj.transform.localScale = new Vector3(yspan, 1, xspan);
                tmpObj.transform.SetParent(this.transform);
            }
        }
        for (int i = 0; i < tmp; i++) {
            x = ((WALL + CELL) * tmp) * SPAN;
            y = (WALL + ((i) % tmp) * (WALL + CELL)) * SPAN+ WALL * SPAN;
            GameObject tmpObj = Instantiate(wall, new Vector3(x, 0, y)+ decalage, Quaternion.identity);
            tmpObj.transform.localScale = new Vector3(xspan, 1, yspan);
            tmpObj.transform.SetParent(this.transform);
            x = (WALL + ((i + tmp) % tmp) * (WALL + CELL)) * SPAN+ WALL * SPAN;
            y = ((WALL + CELL) *  tmp) * SPAN;
            tmpObj = Instantiate(wall, new Vector3(x, 0, y)+ decalage, Quaternion.identity);
            tmpObj.transform.localScale = new Vector3(yspan, 1, xspan);
            tmpObj.transform.SetParent(this.transform);

        }
    }

    // Use this for initialization
    void Start () {
        reset();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.RightArrow))
			axisX -= 0.1;
		if (Input.GetKey (KeyCode.LeftArrow))
			axisX += 0.1;
		if (Input.GetKey (KeyCode.UpArrow))
			axisZ += 0.1;
		if (Input.GetKey (KeyCode.DownArrow))
			axisZ -= 0.1;
		transform.eulerAngles = new Vector3((float)axisZ,0.0f,(float)axisX);
	}
}
