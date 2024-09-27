using System.Collections;
using System.Collections.Generic;
using Backend;
using TMPro;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    // Start is called before the first frame update
    private bool Load = Common.IsLoad;
    public GameObject siteText;
    void LoadPools()
    {
        RegionPoolManager regionPoolManager = new RegionPoolManager();
        DistrictPoolManager districtPoolManager = new DistrictPoolManager();
        BlockPoolManager blockPoolManager = new BlockPoolManager();
        StreetPoolManager streetPoolManager = new StreetPoolManager();
        ArchitecturePoolManager architecturePoolManager = new ArchitecturePoolManager();
        RoomPoolManager roomPoolManager = new RoomPoolManager();
        MobPoolManager mobPoolManager = new MobPoolManager();
        OrganPoolManager organPoolManager = new OrganPoolManager();
        NamePoolManager namePoolManager = new NamePoolManager();
        RelationPoolManager relationPoolManager = new RelationPoolManager();
        DemandPoolManager demandPoolManager = new DemandPoolManager();
        regionPoolManager.LoadPool();
        districtPoolManager.LoadPool();
        blockPoolManager.LoadPool();
        streetPoolManager.LoadPool();
        architecturePoolManager.LoadPool();
        roomPoolManager.LoadPool();
        mobPoolManager.LoadPool();
        organPoolManager.LoadPool();
        namePoolManager.LoadPool();
        relationPoolManager.LoadPool();
        demandPoolManager.LoadPool();
    }

    void ConstructObj(Registry reg)
    {
        RegionFactory.Construct();
        List<Obj> regionList = reg.GetObjList(typeof(Region));
        foreach(Obj region in regionList){
            DistrictFactory.Construct((Region)region);
        }
        List<Obj> districtList = reg.GetObjList(typeof(District));
        foreach (Obj district in districtList)
        {
            StreetFactory.Construct((District)district);
        }
        List<Obj> streetList = reg.GetObjList(typeof(Street));
        foreach (Obj street in streetList)
        {
            ArchitectureFactory.Construct((Street)street);
        }
        List<Obj> architectureList = reg.GetObjList(typeof(Architecture));
        foreach (Obj architecture in architectureList)
        {
            RoomFactory.Construct((Architecture)architecture);
        }

        MobFactory.Construct("ÄÐÈË");
        List<Obj> moblist = reg.GetObjList(typeof(Mob));
        Mob mob = (Mob) moblist[0];
        Debug.Log(mob.WIS);

    }

    void Connection(Registry reg)
    {
        List<Obj> streetList = reg.GetObjList(typeof(Street));
        foreach (var street in streetList)
        {
            StreetFactory.Connection((Street) street);
        }
        List<Obj> architectureList = reg.GetObjList(typeof(Architecture));
        foreach (var architecture in architectureList)
        {
            RoomFactory.Connection((Architecture)architecture);
        }
    }

    void Start()
    {
        if (Load == false)
        {
            Registry reg = Registry.GetRegistry(0);
            LoadPools();
            ConstructObj(reg);
            Connection(reg);
            reg.InitialCurrentRoomId(reg.GetObjList(typeof(Room))[0].ObjId);
            siteText.GetComponent<TextMeshProUGUI>().text = reg.GetLocationName(reg.GetCurrentRoomId());
            Registry.Save();
        }
        else
        {
            Registry reg = Registry.Load();
            siteText.GetComponent<TextMeshProUGUI>().text = reg.GetLocationName(reg.GetCurrentRoomId());
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
