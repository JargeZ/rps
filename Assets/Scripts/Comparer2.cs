// Ваш скрипт, где вы хотите получить значение Player1Value
using UnityEngine;

public class Comparer : MonoBehaviour
{
       public string Result1 = GetValue1.Player1Value;
        public string Result2 = GetValue2.Player2Value;
    void Update()
    {
          Debug.Log("Значение переменной Player1Value: " + Result2);
    }
}