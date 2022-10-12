using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class Serializer
{
    static string path = Application.persistentDataPath;
    static string PLAYER_INVENTORY = "/PlayerInventory.fg";
    static string CROP_FIELDS = "/CropFields.fg";
    static BinaryFormatter formatter = new BinaryFormatter();
        
    public static void SaveInventory(PlayerInventory data){
        FileStream fileStream = new FileStream(path + PLAYER_INVENTORY, FileMode.Create);

        formatter.Serialize(fileStream, JsonUtility.ToJson(data));
        fileStream.Close();
    }

    public static PlayerInventory LoadInventory(){
        Debug.Log("Loading data from: " + path);
        if(File.Exists(path + PLAYER_INVENTORY)){
            FileStream fileStream = File.Open(path + PLAYER_INVENTORY, FileMode.Open);
            PlayerInventory data = new PlayerInventory();
            JsonUtility.FromJsonOverwrite(formatter.Deserialize(fileStream).ToString(), data);
            fileStream.Close();
            return data;
        }
        return null;
    }

    public static void SaveCropFields(CropFieldsData data){
        FileStream fileStream = new FileStream(path + CROP_FIELDS, FileMode.Create);

        formatter.Serialize(fileStream, JsonUtility.ToJson(data));
        fileStream.Close();
    }

    public static CropFieldsData LoadCropFields(){
        Debug.Log("Loading data from: " + path);
        if(File.Exists(path + CROP_FIELDS)){
            FileStream fileStream = File.Open(path + CROP_FIELDS, FileMode.Open);
            CropFieldsData data = new CropFieldsData();
            JsonUtility.FromJsonOverwrite(formatter.Deserialize(fileStream).ToString(), data);
            fileStream.Close();
            return data;
        }
        return null;
    }
}
