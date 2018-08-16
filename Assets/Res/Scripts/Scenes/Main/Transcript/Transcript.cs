using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


  public  class Transcript
{
     int id;
     int needLevel;
    string name;
    string des;
    string energyCost;
    string goods;
    string sceneName;
    public string Des
    {
        get { return des; }
        set { des = value; }
    }

    public string EnergyCost
    {
        get { return energyCost; }
        set { energyCost = value; }
    }
 
    public string Goods
    {
        get { return goods; }
        set { goods = value; }
    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public int NeedLevel
    {
        get { return needLevel; }
        set { needLevel = value; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string SceneName
    {
        get { return sceneName; }
        set { sceneName = value; }
    }
}

