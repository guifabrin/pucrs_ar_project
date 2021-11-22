using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Scripts : MonoBehaviour
{
    GameObject dunotA;
    GameObject dunotB;
    GameObject dunotC;
    GameObject dunotD;

    GameObject towerA;
    GameObject towerB;
    GameObject towerC;

    GameObject planeA;
    GameObject planeB;
    GameObject planeC;

    GameObject buttonA;
    GameObject buttonB;
    GameObject buttonC;
    GameObject buttonD;

    void moveTo(GameObject from, GameObject to)
    {
        GameObject element = topElement(from);
        if (element != null)
        {
            element.transform.parent = to.transform;
            element.transform.localPosition = new Vector3(0, 10.0f, 0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        dunotA = GameObject.FindGameObjectsWithTag("dunotA")[0];
        dunotB = GameObject.FindGameObjectsWithTag("dunotB")[0];
        dunotC = GameObject.FindGameObjectsWithTag("dunotC")[0];
        dunotD = GameObject.FindGameObjectsWithTag("dunotD")[0];


        towerA = GameObject.FindGameObjectsWithTag("towerA")[0];
        towerB = GameObject.FindGameObjectsWithTag("towerB")[0];
        towerC = GameObject.FindGameObjectsWithTag("towerC")[0];

        planeA = GameObject.FindGameObjectsWithTag("planeA")[0];
        planeB = GameObject.FindGameObjectsWithTag("planeB")[0];
        planeC = GameObject.FindGameObjectsWithTag("planeC")[0];


        buttonA = GameObject.FindGameObjectsWithTag("buttonA")[0];
        buttonB = GameObject.FindGameObjectsWithTag("buttonB")[0];
        buttonC = GameObject.FindGameObjectsWithTag("buttonC")[0];
        buttonD = GameObject.FindGameObjectsWithTag("buttonD")[0];

        bool doingA = false;
        bool doingB = false;
        bool doingC = false;
        bool doingD = false;

        buttonA.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed((arg) =>
        {
            if (doingA)
            {
                return;
            }
            doingA = true;
            moveTo(towerA, towerB);
        });
        buttonA.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased((arg) =>
        {
             doingA = false;
        });


        buttonB.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed((arg) =>
        {
            if (doingB)
            {
                return;
            }
            doingB = true;
            moveTo(towerB, towerA);
        });
        buttonB.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased((arg) =>
        {
            doingB = false;
        });

        buttonC.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed((arg) =>
        {
            if (doingC)
            {
                return;
            }
            doingC = true;
            moveTo(towerB, towerC);
        });
        buttonC.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased((arg) =>
        {
            doingC = false;
        });

        buttonD.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed((arg) =>
        {
            if (doingD)
            {
                return;
            }
            doingD = true;
            moveTo(towerC, towerB);
        });
        buttonD.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased((arg) =>
        {
            doingD = false;
        });
    }

    GameObject topElement(GameObject tower)
    {
        List<GameObject> list = new List<GameObject>();
        if (dunotA.transform.parent == tower.transform)
        {
            list.Add(dunotA);
        }
        if (dunotB.transform.parent == tower.transform)
        {
            list.Add(dunotB);
        }
        if (dunotC.transform.parent == tower.transform)
        {
            list.Add(dunotC);
        }
        if (dunotD.transform.parent == tower.transform)
        {
            list.Add(dunotD);
        }
        GameObject top = null;
        for (int i = 0; i < list.Count; i++)
        {
            if (top == null)
            {
                top = list[i];
            }
            else
            {
                if (top.transform.localPosition.y < list[i].transform.localPosition.y)
                {
                    top = list[i];
                }
            }
        }
        return top;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
