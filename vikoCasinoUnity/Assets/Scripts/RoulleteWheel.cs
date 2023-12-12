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

        numberOfTurns = Random.Range(150, 300);

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
            transform.Rotate(0,0,5f);
        }

        whatWeWin = Mathf.RoundToInt(transform.eulerAngles.z);

        canWeTurn = true;
    }
}
