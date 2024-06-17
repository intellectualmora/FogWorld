using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Backend
{
    [Serializable]
    public class Registry
    {
        private static Registry _registry;
        private Dictionary<Type, List<Obj>> _objDict;
        private Dictionary<Type, List<Node>> _nodeDict;
        private int _objIdCounter;
        private int _currentRoomId;

        private Registry()
        {
            _objDict = new Dictionary<Type, List<Obj>>();
            _nodeDict = new Dictionary<Type, List<Node>>();
            _objIdCounter = 0; // load from savedata
        }

        private Registry(int objCounter)
        {
            _objDict = new Dictionary<Type, List<Obj>>();
            _nodeDict = new Dictionary<Type, List<Node>>();
            _objIdCounter = objCounter; // load from savedata
        }

        public static Registry GetRegistry()
        {
            // 如果类的实例不存在则创建，否则直接返回
            return _registry ??= new Registry();
        }

        public static void SetRegistry(Registry reg)
        {
            _registry = reg;
        }

        public static Registry GetRegistry(int objCounter)
        {
            // 如果类的实例不存在则创建，否则直接返回
            return _registry ??= new Registry(objCounter);
        }

        public int AddObjId()
        {
            _objIdCounter++;
            return _objIdCounter;
        }

        public void Register(Type T, Obj obj)
        {
            if (_objDict.ContainsKey(T))
            {
                _objDict[T].Add(obj);
            }
            else
            {
                _objDict[T] = new List<Obj>();
                _objDict[T].Add(obj);
            }
        }

        public void Cancel(Type T, int objId)
        {
            if (_objDict.ContainsKey(T))
            {
                foreach (var obj in _objDict[T])
                {
                    if (obj.ObjId == objId)
                    {
                        _objDict[T].Remove(obj);
                        return;
                    }
                }
            }
        }

        public Obj GetObj(Type T, int objId)
        {
            if (_objDict.ContainsKey(T))
            {
                foreach (var obj in _objDict[T])
                {
                    if (obj.ObjId == objId)
                    {
                        return obj;
                    }
                }
            }

            throw new Exception();
        }

        public List<Obj> GetObjList(Type T)
        {
            if (_objDict.ContainsKey(T))
            {
                return _objDict[T];
            }

            throw new Exception();
        }

        public void RegisterNodeList<T>(List<Node> nodeList)
        {
            _nodeDict[typeof(T)] = nodeList;
        }

        public Node GetNode(Type T, int nodeId)
        {
            if (_nodeDict.ContainsKey(T))
            {
                foreach (var node in _nodeDict[T])
                {
                    if (node.NodeId == nodeId)
                    {
                        return node;
                    }
                }
            }

            throw new Exception();
        }

        public List<Node> GetNodeList(Type T)
        {
            if (_nodeDict.ContainsKey(T))
            {
                return _nodeDict[T];
            }

            throw new Exception();
        }

        public List<int> GetSurroundRoomIdList()
        {
            Room currentRoom = (Room)GetObj(typeof(Room), _currentRoomId);
            List<int> surroundRoomIdList = new List<int>();
            foreach (var roomId in currentRoom.ConnectionRoomIdList)
            {
                surroundRoomIdList.Add(roomId);
            }

            if (currentRoom.IsBaseRoom == 1)
            {
                Architecture architecture = (Architecture)GetObj(typeof(Architecture), currentRoom.FatherObjId);
                Street street = (Street)GetObj(typeof(Street), architecture.FatherObjId);
                if (architecture.IsBaseArchitecture == 1)
                {
                    foreach (var architectureId in street.ChildObjIdList)
                    {
                        Architecture childArch = (Architecture)GetObj(typeof(Architecture), architectureId);
                        if (childArch.IsBaseArchitecture == 0)
                        {
                            foreach (var roomId in childArch.ChildObjIdList)
                            {
                                Room childRoom = (Room)GetObj(typeof(Room), roomId);
                                if (childRoom.IsBaseRoom == 1)
                                {
                                    surroundRoomIdList.Add(roomId);
                                }
                            }
                        }
                    }

                    foreach (var streetId in street.ConnectionStreetIdList)
                    {
                        Street surroundStreet = (Street)GetObj(typeof(Street), streetId);
                        foreach (var architectureId in surroundStreet.ChildObjIdList)
                        {
                            Architecture childArch = (Architecture)GetObj(typeof(Architecture), architectureId);
                            if (childArch.IsBaseArchitecture == 1)
                            {
                                foreach (var roomId in childArch.ChildObjIdList)
                                {
                                    Room childRoom = (Room)GetObj(typeof(Room), roomId);
                                    if (childRoom.IsBaseRoom == 1)
                                    {
                                        surroundRoomIdList.Add(roomId);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (var architectureId in street.ChildObjIdList)
                    {
                        Architecture childArch = (Architecture)GetObj(typeof(Architecture), architectureId);
                        if (childArch.IsBaseArchitecture == 1)
                        {
                            foreach (var roomId in childArch.ChildObjIdList)
                            {
                                Room childRoom = (Room)GetObj(typeof(Room), roomId);
                                if (childRoom.IsBaseRoom == 1)
                                {
                                    surroundRoomIdList.Add(roomId);
                                }
                            }
                        }
                    }
                }
            }

            return surroundRoomIdList;
        }

        public string GetLocationName(int roomId)
        {
            string name = "";
            Room room = (Room)GetObj(typeof(Room), roomId);
            if (room.IsBaseRoom == 1)
            {
                Architecture architecture = (Architecture)GetObj(typeof(Architecture), room.FatherObjId);
                if (architecture.IsBaseArchitecture == 1)
                {
                    Street street = (Street)GetObj(typeof(Street), architecture.FatherObjId);
                    name = street.ObjName;

                }
                else
                {
                    name = architecture.ObjName;
                }
            }
            else
            {
                name = room.ObjName;
            }

            return name;
        }

        public void InitialCurrentRoomId(int roomId)
        {
            _currentRoomId = roomId;
        }

        public void UpdataCurrentRoomId(int roomId)
        {
            _currentRoomId = roomId;
        }

        public Dictionary<Type, List<Obj>> GetObjDict()
        {
            return _objDict;
        }

        public void SetObjDict(Dictionary<Type, List<Obj>> objDict)
        {
            _objDict = objDict;
        }

        public Dictionary<Type, List<Node>> GetNodeDict()
        {
            return _nodeDict;
        }

        public void SetNodeDict(Dictionary<Type, List<Node>> nodeDict)
        {
            _nodeDict = nodeDict;
        }

        public int GetObjIdCounter()
        {
            return _objIdCounter;
        }
        public void SetObjIdCounter(int objIdCounter)
        {
            _objIdCounter = objIdCounter;
        }

        public int GetCurrentRoomId()
        {
            return _currentRoomId;
        }
        public void SetCurrentRoomId(int currentRoomId)
        {
            _currentRoomId = currentRoomId;
        }

        public static void Save()
        {
            BinaryFormatter serializer = new BinaryFormatter();
            using (FileStream fs = File.Create(@Path.Combine(Common.SavePath, Common.SaveData)))
            {
                serializer.Serialize(fs, _registry);
            }
        }

        public static Registry Load()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.OpenRead(@Path.Combine(Common.SavePath, Common.SaveData));
            Registry tempreg = (Registry)bf.Deserialize(fs);
            SetRegistry(tempreg);
            return GetRegistry();
        }
    }   


}