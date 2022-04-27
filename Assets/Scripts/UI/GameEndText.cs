using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndText : MonoBehaviour
{
    private int gameID = 0; // No game
    private GameObject mainServerControllerObject;
    public int gameResult = 0;

    void Start()
    {
        mainServerControllerObject = GameObject.Find("Main Server Controller 1"); // Tic-Tac-Toe
        if (mainServerControllerObject != null) gameID = 1;
        else
        {
            mainServerControllerObject = GameObject.Find("Main Server Controller 2"); // Ship Battle
            if (mainServerControllerObject != null) gameID = 2;
        }

        switch (gameID)
        {
            case 0:
                // Nothing here
                break;
            case 1:
                gameResult = mainServerControllerObject.GetComponent<MainServerController1>().gameResult;
                break;
            case 2:
                gameResult = mainServerControllerObject.GetComponent<MainServerController2>().gameResult ? 1 : 0; // bool
                break;
        }

        if (gameResult == 0) // Won
        {
            GetComponent<Text>().text = "�� ��������!";
        }
        else if (gameResult == 1) // Lost
        {
            GetComponent<Text>().text = "�� ���������!";
        }
        else // Tie
        {
            GetComponent<Text>().text = "�����!";
        }

        if (gameID != 0)
        {
            Destroy(mainServerControllerObject);
        }
    }

    void Update()
    {
        
    }
}
