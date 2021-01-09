using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soal : MonoBehaviour
{
    public string textSoal;
    public string textJawaban;
    public ValidateJawaban[] validasi;

    public int IsCorrect(int jmlPiring, int jmlApple){
        int result = -1;

        for (int i = 0; i < validasi.Length; i++)
        {
            if (jmlPiring == validasi[i].jmlPiring && jmlApple == validasi[i].jmlApple){
                result = i;
                break;
            }
        }

        return result;
    }
}
