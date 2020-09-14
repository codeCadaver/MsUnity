using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointIncrement : MonoBehaviour
{
    public int pointIncrement = 10;
    public int pointTier = 50;

    private bool _bTierPassed = false;
    private int _totalPoints;

    public enum LevelSelector
    {
        Easy, 
        Normal, 
        Difficult, 
        Insane
    }

    public LevelSelector currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        _totalPoints = 0;

        switch (currentLevel)
        {
            case LevelSelector.Easy:
                Debug.Log("You are a Chicken");
                break;
            case LevelSelector.Normal:
                Debug.Log("Way to go with the flow");
                break;
            case LevelSelector.Difficult:
                Debug.Log("Ooooh...someone is up for a challenge");
                break;
            case LevelSelector.Insane:
                Debug.Log("You are fucked");
                break;
            default:
                Debug.Log("How did you make this selection? You done effed up!");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // add 10 points;
            _totalPoints += pointIncrement;
            Debug.Log($"Current point total: {_totalPoints}");

            if(_totalPoints >= pointTier && !_bTierPassed)
            {
                Debug.Log("You are AWESOME");
                _bTierPassed = true;
            }
        }
    }

}
