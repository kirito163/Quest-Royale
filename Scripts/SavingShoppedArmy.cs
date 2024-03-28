using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class SavingShoppedArmy : MonoBehaviour
{
   private string filePath = "./GameSave";

// Istanza da serializzare


// Funzione per serializzare e salvare il file su disco
public void Save(Player playerDataObject){
    string jsonString = JsonUtility.ToJson(playerDataObject, true); //Crea la stringa da salvare
    File.WriteAllText(filePath, jsonString); //Salva la stringa sul file al percorso stabilito
}

// Funzione per deserializzare il file ed inserire i dati in playerDataObject
public Player Load(){
    string jsonString = File.ReadAllText(filePath); //Leggi il file
    Player playerDataObject = JsonUtility.FromJson<Player>(jsonString); //Reinposta playerDataObject con i dati caricati
    return playerDataObject;
}
}
