using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoulleteWheel : MonoBehaviour
{
    // Start is called before the first frame update
    private int numberOfTurns;
    private int whatWeWin;

    private float speed;
    private bool canWeTurn;

    public Text winningText;

    void Start()
    {
        canWeTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canWeTurn)
        {
            StartCoroutine(TurnTheWheel());
        }
    }

    private IEnumerator TurnTheWheel()
    {
        canWeTurn = false;

        numberOfTurns = new System.Random().Next(10, 20);

        speed = 0.01f;

        for (int i = 0; i < numberOfTurns; i++)
        {
            transform.Rotate(0, 0, 5f);

            if (i > Mathf.RoundToInt(numberOfTurns * 0.1f))
            {
                speed = 0.01f;
            }
            if (i > Mathf.RoundToInt(numberOfTurns * 0.2f))
            {
                speed = 0.02f;
            }
            if (i > Mathf.RoundToInt(numberOfTurns * 0.3f))
            {
                speed = 0.03f;
            }
            if (i > Mathf.RoundToInt(numberOfTurns * 0.4f))
            {
                speed = 0.04f;
            }

            if (i > Mathf.RoundToInt(numberOfTurns * 0.5f))
            {
                speed = 0.05f;
            }
            if (i > Mathf.RoundToInt(numberOfTurns * 0.6f))
            {
                speed = 0.06f;
            }

            if (i > Mathf.RoundToInt(numberOfTurns * 0.7f))
            {
                speed = 0.07f;
            }
            if (i > Mathf.RoundToInt(numberOfTurns * 0.8f))
            {
                speed = 0.08f;
            }
            if (i > Mathf.RoundToInt(numberOfTurns * 0.9f))
            {
                speed = 0.09f;
            }


            yield return new WaitForSeconds(speed);
        }

        if (Mathf.RoundToInt(transform.eulerAngles.z) % 10 != 0)
        {
            transform.Rotate(0, 0, 5f);
        }

        whatWeWin = Mathf.RoundToInt(transform.eulerAngles.z);

        int divisionIndex = (int)(transform.eulerAngles.z / 9.72);

        switch (divisionIndex)
        {
            case 0:
                winningText.text = "26 red";
                break;
            case 1:
                winningText.text = "0 green";
                break;
            case 2:
                winningText.text = "32 red";
                break;
            case 3:
                winningText.text = "15 black";
                break;
            case 4:
                winningText.text = "19 red";
                break;
            case 5:
                winningText.text = "4 black";
                break;
            case 6:
                winningText.text = "21 red";
                break;
            case 7:
                winningText.text = "2 black";
                break;
            case 8:
                winningText.text = "25 red";
                break;
            case 9:
                winningText.text = "17 black";
                break;
            case 10:
                winningText.text = "34 red";
                break;
            case 11:
                winningText.text = "6 black";
                break;
            case 12:
                winningText.text = "27 red";
                break;
            case 13:
                winningText.text = "13 black";
                break;
            case 14:
                winningText.text = "36 red";
                break;
            case 15:
                winningText.text = "11 black";
                break;
            case 16:
                winningText.text = "30 red";
                break;
            case 17:
                winningText.text = "8 black";
                break;
            case 18:
                winningText.text = "23 red";
                break;
            case 19:
                winningText.text = "5 black";
                break;
            case 20:
                winningText.text = "24 red";
                break;
            case 21:
                winningText.text = " 16 black";
                break;
            case 22:
                winningText.text = "33 red";
                break;
            case 23:
                winningText.text = "1 black";
                break;
            case 24:
                winningText.text = "20 red";
                break;
            case 25:
                winningText.text = "14 black";
                break;
            case 26:
                winningText.text = "31 red";
                break;
            case 27:
                winningText.text = "9 black";
                break;
            case 28:
                winningText.text = "22 red";
                break;
            case 29:
                winningText.text = "18 black";
                break;
            case 30:
                winningText.text = "29 red";
                break;
            case 31:
                winningText.text = "7 black";
                break;
            case 32:
                winningText.text = "28 red";
                break;
            case 33:
                winningText.text = "12 black";
                break;
            case 34:
                winningText.text = "35 red";
                break;
            case 35:
                winningText.text = "3 black";
                break;
            case 36:
                winningText.text = "26 red";
                break;
            default:
                winningText.text = "3 black";
                break;
        }

        canWeTurn = true;
    }
}
