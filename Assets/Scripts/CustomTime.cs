using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class CustomTime {

    public int day, month, year, hours, minutes, seconds;

    public CustomTime(){
        string date = DateTime.UtcNow.ToString(); //09/28/2022 19:57:51

        string[] dateTimeSplit = date.Split(" ");
        string[] dateSplit = dateTimeSplit[0].Split("/");
        string[] timeSplit = dateTimeSplit[1].Split(":");

        day = int.Parse(dateSplit[0]);
        month = int.Parse(dateSplit[1]);
        year = int.Parse(dateSplit[2]);
        hours = int.Parse(timeSplit[0]);
        minutes = int.Parse(timeSplit[1]);
        seconds = int.Parse(timeSplit[2]);
    }
    
    public SEASON GetSeason(){
        if(month >= 12){
            return SEASON.WINTER;
        }else if(month >= 9){
            return SEASON.AUTUMN;
        }else if(month >= 6){
            return SEASON.SUMMER;
        }else if(month >= 3){
            return SEASON.SPRING;
        }else{
            return SEASON.WINTER;
        }
    }

    public override string ToString()
    {
        return day+"/"+month+"/"+year+" "+hours+":"+minutes+":"+seconds;
    }

}

public enum SEASON{
    WINTER,
    SPRING,
    SUMMER,
    AUTUMN
}