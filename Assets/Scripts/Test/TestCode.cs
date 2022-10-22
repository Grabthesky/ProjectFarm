using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;

public class TestCode : MonoBehaviour
{
    
    private void Start() {
        string lastTime = "10/12/2022 13:17:00";
        Debug.Log("Parse DATETIME: " + DateTime.ParseExact(lastTime, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture));
        CustomTime time = new CustomTime();
        time.GetDiffOfTime(lastTime);

    }
}
