using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Backend
{
   public static class Common
    {
        //public static string SavePath = Application.persistentDataPath;
        public static string SavePath = Application.dataPath + "/Data/savedata";
        public static string StaticPath = Application.dataPath;
        public static string ResourcePath = Application.dataPath+"/Resources";
        public static string DataPath = Application.dataPath + "/Data";
        public static string PoolPath = Application.dataPath + "/Data/pool";
        public static string FileNE =  "File Not Exit!";
        public static string RegionPool = "RegionPool.xml";
        public static string DistrictPool = "DistrictPool.xml";
        public static string StreetPool = "StreetPool.xml";
        public static string ArchitecturePool = "ArchitecturePool.xml";
        public static string BlockPool = "BlockPool.xml";
        public static string RoomPool = "RoomPool.xml";
        public static string MobPool = "MobPool.xml";
        public static string RelationPool = "RelationPool.xml";
        public static string OrganPool = "OrganPool.xml";
        public static string NamePool = "NamePool.xml";
        public static string DemandPool = "DemandPool.xml";
        public static string AbilityPool = "AbilityPool.xml";
        public static string MobImagePool = "MobImagePool.xml";
        public static string SaveData = "SaveData.savedata";
        public static int RootObjId = 0;
        public static bool IsLoad = false;
        public static int Population = 10;
        public static double SexRate = 0.5;
        public static double BabyAgeRate = 0.04;
        public static double ChildAgeRate = 0.2;
        public static double OldAgeRate = 0.85;
        public static int MainTimeCost = 3;
        public static int SubTimeCost = 1;
        public static int DayTime = 288;
        public static int Sunrise = 72;
        public static int Noon = 120;
        public static int Sunset = 216;
        public static int Night = 264;
        public static double CapcityRate = 5;
        public static int APLIndex = 0;//魅力
        public static int DEFIndex = 1; //防御
        public static int WISIndex = 2;//智力
        public static int PCTIndex = 3; //感知
        public static int DEXIndex = 4;//反应
        public static int STRIndex = 5; //力量
        public static int IMIIndex = 6; // 免疫
        public static int DIGIndex = 7; // 消化
        public static int CSNIndex = 8;// 意识
        public static int FTYIndex = 9;// 繁殖
        public static int RESIndex = 10; // 恢复
        public static double Stddev = 1;
        public static string Slave = "奴隶";
        public static string Citizen = "市民";
        public static string Stateless = "无籍人士";
        public static List<double> RebelThreshold = new List<double>() { -50, -50 };

    }
}
