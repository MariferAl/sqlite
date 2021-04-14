using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DataSave
{
    public class tblCoins
    {
        public string _coinID;
        public String _coinsCount;
        public String _dateCreated; // Auto generated timestamp

        public tblCoins(string id, String coinsCount)
        {
            _coinID = id;
            _coinsCount = coinsCount;
            _dateCreated = "";
        }

        public tblCoins(string id, String coinsCount, string dateCreated)
        {
            _coinID = id;
            _coinsCount = coinsCount;
            _dateCreated = dateCreated;
        }

        public static tblCoins getFakeCoins()
        {
            return new tblCoins("1", "5000");
        }
    }

    //public class HeroLeveling
    //{
    //    public string _HLID;
    //    public string _heroID;
    //    public string _str;
    //    public string _hp;
    //    public string _energy;

    //    public HeroLevelingDB(string HLID, string heroID, String strg, string hp, string energy)
    //    {
    //        _HLID = HLID;
    //        _heroID = heroID;
    //        _str = strg;
    //        _hp = hp;
    //        _energy = energy;
    //    }
    //}

    public class tblHeros
    {
        public string _heroID;
        public string _price;
        public String _story;

        public tblHeros(string v1, string v2)
        {
            V1 = v1;
            V2 = v2;
        }

        public tblHeros(string heroID, string price, String story)
        {
            _heroID = heroID;
            _price = price;
            _story = story;
        }

        public string V1 { get; }
        public string V2 { get; }

    }

}
