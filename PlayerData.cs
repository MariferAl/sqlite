using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataSave;
using UnityEngine.UI;
using System;

public class PlayerData : MonoBehaviour
{
	public Text coinsCount;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            //CoinsDB mLocationDb = new CoinsDB();

            ////Add Data
            //mLocationDb.addData(new tblCoins("1", "5000"));
            //mLocationDb.close();

            ////Fetch All Data
            //CoinsDB mLocationDb2 = new CoinsDB();
            //System.Data.IDataReader reader = mLocationDb2.getAllData();

            //int fieldCount = reader.FieldCount;
            //List<tblCoins> myList = new List<tblCoins>();
            //while (reader.Read())
            //{
            //    tblCoins entity = new tblCoins(reader[0].ToString(),
            //                            reader[1].ToString(),
            //                            reader[2].ToString());

            //    this.coinsCount.GetComponent<Text>().text = entity._coinsCount;

            //    Debug.Log("id: " + entity._coinsCount);
            //    myList.Add(entity);
            //}
        }
        catch (Exception e)
       {
           Debug.Log(e);
       }
        
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
