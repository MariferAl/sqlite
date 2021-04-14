using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DataSave
{
    public class CoinsDB : SqliteHelper
    {

        private const String checkTags = "Codistan: CoinsDB:\t";

        private const String TABLE_NAME = "tbl_Coins";
        private const String KEY_ID = "coinID";
        private const String KEY_COUNT = "coinsCount";
        private const String KEY_DATE = "date";
        private String[] COLUMNS = new String[] { KEY_ID, KEY_COUNT, KEY_DATE };

        public CoinsDB() : base()
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
                KEY_ID + " TEXT PRIMARY KEY, " +
                KEY_COUNT + " TEXT, " +
                KEY_DATE + " DATETIME DEFAULT CURRENT_TIMESTAMP )";
            dbcmd.ExecuteNonQuery();
            
        }


        public void addData(tblCoins coins)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "INSERT INTO " + TABLE_NAME
                + " ( "
                + KEY_ID + ", "
                + KEY_COUNT + ", "
                + KEY_DATE + " ) "

                // + "SELECT ('AR')"

                + "VALUES ( '"
                + coins._coinID + "', '"
                + coins._coinsCount + "', '"
                + coins._dateCreated + "' )";
            //  + "WHERE NOT EXISTS ( SELECT 1 FROM " + TABLE_NAME + " WHERE AR = 'AR');";
            dbcmd.ExecuteNonQuery();
            
        }

        public override IDataReader getDataById(int id)
        {
            return base.getDataById(id);
        }

        public override IDataReader getDataByString(string str)
        {
            Debug.Log(checkTags + "Getting Location: " + str);

            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "SELECT * FROM " + TABLE_NAME + " WHERE " + KEY_ID + " = '" + str + "'";
            return dbcmd.ExecuteReader();
        }

        public override void deleteDataByString(string id)
        {
            Debug.Log(checkTags + "Deleting Location: " + id);

            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "DELETE FROM " + TABLE_NAME + " WHERE " + KEY_ID + " = '" + id + "'";
            dbcmd.ExecuteNonQuery();
        }

        public override void deleteDataById(int id)
        {
            base.deleteDataById(id);
        }

        public override void deleteAllData()
        {
            Debug.Log(checkTags + "Deleting Table");

            base.deleteAllData(TABLE_NAME);
        }

        public override IDataReader getAllData()
        {
            return base.getAllData(TABLE_NAME);
        }
    }
    
}
