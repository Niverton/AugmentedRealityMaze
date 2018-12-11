using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarteDistance : MonoBehaviour
{
    public int[,] tab;
    private int size; 
    private Point cible;
    private float SPAN;
    private float WALL;
    private float CELL;
    private Vector3 decalage;
    private GameObject cases;
    private Transform parant;
    public CarteDistance(Point cible,Graph g,float SPAN,float WALL,float CELL, GameObject cases,Transform parant)
    {
        this.parant = parant;
        this.cases = cases;
        this.cible = cible;
        this.SPAN = SPAN;
        this.WALL = WALL;
        this.CELL = CELL;
        size = (int)Mathf.Sqrt(g.GetSize());
        decalage = new Vector3((WALL + CELL) * (-size / 2.0f) * SPAN, 0, (WALL + CELL) * (-size / 2.0f) * SPAN);
        tab = new int[size, size];
        Point p = g.getPosition(cible.GetX(), cible.GetY());
        for (int x = 0; x < size; x++)
            for (int y = 0; y < size; y++)
                tab[x,y] = -1;
        PointSuivant(p, 0);
        CreateCase();
    }
    public void PointSuivant(Point actuelle, int valeur)
    {
        float x = actuelle.GetX() * (CELL * SPAN + WALL * SPAN) + WALL * SPAN*2.0f;
        float y = actuelle.GetY()*(CELL * SPAN + WALL * SPAN) + WALL * SPAN *2.0f;
        if (tab[actuelle.GetX(),actuelle.GetY()] == -1 || tab[actuelle.GetX(),actuelle.GetY()] > valeur)
        {
            tab[actuelle.GetX(),actuelle.GetY()] = 1 + valeur++;
            if (actuelle.GetEst() != null)
                PointSuivant(actuelle.GetEst(), valeur);
            if (actuelle.GetNord() != null)
                PointSuivant(actuelle.GetNord(), valeur);
            if (actuelle.GetOuest() != null)
                PointSuivant(actuelle.GetOuest(), valeur);
            if (actuelle.GetSud() != null)
                PointSuivant(actuelle.GetSud(), valeur);
        }
    }
    public void CreateCase() {
        for(int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                float xx = x * (CELL * SPAN + WALL * SPAN) + WALL * SPAN * 2.0f;
                float yy = y * (CELL * SPAN + WALL * SPAN) + WALL * SPAN * 2.0f;
                GameObject tmpObj = Instantiate(cases, new Vector3(xx, 0, yy) + decalage, Quaternion.identity);
                tmpObj.transform.localScale = new Vector3(CELL * SPAN, 1, CELL * SPAN);
                tmpObj.GetComponent<Ball_detector>().nb_case = tab[x, y];
                tmpObj.transform.SetParent(parant);
            }
        }
    }
}
