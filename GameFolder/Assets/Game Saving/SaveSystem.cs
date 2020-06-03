using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {

  public static void SavePlayer(PlayerMovement playerMovement, PlayerHealth playerHealth, Inventory playerInventory, PlayerMoney playerMoney) {

    BinaryFormatter formatter = new BinaryFormatter();
    //type of file doesn't matter, Application.persistentDataPath makes it work on all operating systems
    string path = Application.persistentDataPath + "/player.fun";
    FileStream stream = new FileStream(path, FileMode.Create);

    PlayerData data = new PlayerData(playerMovement, playerHealth, playerInventory, playerMoney);

    formatter.Serialize(stream, data);
    stream.Close();


  }

  public static PlayerData LoadPlayer() {

    string path = Application.persistentDataPath + "/player.fun";
    if (File.Exists(path))  {
      BinaryFormatter formatter = new BinaryFormatter();
      FileStream stream = new FileStream(path, FileMode.Open);

      PlayerData data = formatter.Deserialize(stream) as PlayerData;
      stream.Close();
      return data;

    } else {
      Debug.LogError("Save file not found in " + path);
      return null;
    }

  }

  public static void DeletePlayer() {
    string path = Application.persistentDataPath + "/player.fun";
    File.Delete(path);
  }
}
