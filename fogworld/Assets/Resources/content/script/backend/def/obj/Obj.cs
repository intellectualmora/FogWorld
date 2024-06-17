using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtendedXmlSerializer.Core.Sources;

namespace Backend
{
    [System.Serializable]
    public abstract class Obj
    { 
        public string ObjName { get; set; }
        public int ObjId { get; set; }
        public int NodeId { get; set; }
        public string ImgPath { get; set; }
        public string Brief { get; set; }
        public List<int> ChildObjIdList { get; set; }
        public Type ChildType { get; set; }
        public int FatherObjId { get; set; }
        public Type FatherType { get; set; }
        public Type SelfType { get; set; }

        public Obj(string objName, string imgPath, string brief, int nodeId, Type selfType, Type childType,Type fatherType, int fatherObjId, List<int> childObjIdList)
        {
            Registry reg = Registry.GetRegistry();
            ObjName = objName;
            ImgPath = imgPath;
            Brief = brief;
            SelfType = selfType;
            ChildType = childType;
            FatherType = fatherType;
            FatherObjId = fatherObjId;
            ChildObjIdList = childObjIdList;
            NodeId = nodeId;
            ObjId = reg.AddObjId();
            if (fatherObjId != Common.RootObjId)
            {
                Obj fatherObj = reg.GetObj(FatherType, fatherObjId);
                fatherObj.AddChildObjId(ObjId);
            }
            reg.Register(SelfType, this);
        }
        public Obj()
        {

        }

        public void AddChildObjId(int objId)
        {
            ChildObjIdList.Add(objId);
        }
        public void RemoveChildObjId(int objId)
        {
            ChildObjIdList.Remove(objId);
        }

        public void Delete()
        {
            Registry reg = Registry.GetRegistry();
            if (FatherObjId != Common.RootObjId)
            {
              var father = reg.GetObj(FatherType, FatherObjId);
              father.RemoveChildObjId(ObjId);
            }
            if (ChildObjIdList is not null){
                foreach (int childObjId in ChildObjIdList)
                {
                    var child = reg.GetObj(ChildType, childObjId);
                    child.Delete();
                }
            }
            reg.Cancel(SelfType, ObjId);
        }

    }

}
