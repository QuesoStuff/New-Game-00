
using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public static class ScoreManager //: MonoBehaviour//, //I_SCORE //, I_other_Interface
{
    // ADDED SCRIPTS (internal allows to be accessed)
    //TO DO
    // FIELDS (variables)
    [SerializeField] internal static int score;
    // SET and CONSTRUCTORS 
    public static void set()
    {
        score = 0;
    }

    public static void scorechange()
    {
        score += CONSTANTS.SCORE_DEFAULT_INCREMENT;
    }
   public static void scoreChange(int newScore)
    {
        score += newScore;
    }
 public  static void scorechange_Random()
    {
        score += Random.Range(CONSTANTS.SCORE_RANGE_MIN , CONSTANTS.SCORE_RANGE_MAX);
    }
   public static void scorechange_Special()
    {
        score *=  Random.Range(CONSTANTS.SCORE_RANGE_MIN , CONSTANTS.SCORE_RANGE_MAX);
    }
    // used at the end of the level or death

}