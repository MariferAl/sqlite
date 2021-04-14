using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DataSave
{
    public class tblHeroesDB : SqliteHelper
    {
        private const String checkTag = "CheckTag: LocationDb:\t";

        private const String TABLE_NAME = "tblHeroes";
        private const String KEY_ID = "heroID";
        private const String KEY_PRICE = "price";
        private const String KEY_STORY = "story";
        private String[] COLUMNS = new String[] { KEY_ID, KEY_PRICE, KEY_STORY };

        public tblHeroesDB() : base()
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
                KEY_ID + " TEXT PRIMARY KEY, " +
                KEY_PRICE + " TEXT, " +
                KEY_STORY + " TEXT )";
            dbcmd.ExecuteNonQuery();
        }

        public void addData(tblHeros heroes)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "INSERT INTO " + TABLE_NAME
                + " ( "
                + KEY_ID + ", "
                + KEY_PRICE + ", "
                + KEY_STORY + " ) "

               // + "SELECT ('AR')"

                + "VALUES ( '"
                + heroes._heroID + "', '"
                + heroes._price + "', '"
                + heroes._story + "')";             
              //  + "WHERE NOT EXISTS ( SELECT 1 FROM " + TABLE_NAME + " WHERE AR = 'AR');";
            dbcmd.ExecuteNonQuery();
        }

        public override IDataReader getDataById(int id)
        {
            return base.getDataById(id);
        }

        public override IDataReader getDataByString(string str)
        {
            Debug.Log(checkTag + "Getting Location: " + str);

            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "SELECT * FROM " + TABLE_NAME + " WHERE " + KEY_ID + " = '" + str + "'";
            return dbcmd.ExecuteReader();
        }

        public override void deleteDataByString(string id)
        {
            Debug.Log(checkTag + "Deleting Location: " + id);

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
            Debug.Log(checkTag + "Deleting Table");

            base.deleteAllData(TABLE_NAME);
        }

        public override IDataReader getAllData()
        {
            return base.getAllData(TABLE_NAME);
        }

        //public IDataReader getNearestLocation(LocationInfo loc)
        //{
        //    Debug.Log(CodistanTag + "Getting nearest centoid from: " + loc.latitude + ", " + loc.longitude);
        //    IDbCommand dbcmd = getDbCommand();

        //    string query = "SELECT * FROM " + TABLE_NAME  + " ORDER BY ABS(" + KEY_PRICE + " - " + loc.latitude
        //        + ") + ABS(" + KEY_LNG + " - " + loc.longitude + ") ASC LIMIT 1";

        //    dbcmd.CommandText = query;
        //    return dbcmd.ExecuteReader();
        //}

        //public IDataReader getLatestTimeStamp()
        //{
        //    IDbCommand dbcmd = getDbCommand();
        //    dbcmd.CommandText = "SELECT * FROM " + TABLE_NAME + " ORDER BY " + KEY_DATE + " DESC LIMIT 1";
        //    return dbcmd.ExecuteReader();
        //}
    }

    
}
