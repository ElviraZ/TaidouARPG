using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : SingletonMono<SkillManager>

{
    public TextAsset listInfo;
    private List<Skill> skillList = new List<Skill>();

    public override void Awake()
    {
        base.Awake();
        IniiSkill();

    }
    void IniiSkill()
    {
        string str = listInfo.ToString();
        string[] itemStrArray = str.Split('\n');
        foreach (string itemStr in itemStrArray)
        {
            string[] proArray = itemStr.Split('|');
            Skill skill = new Skill();
            skill.Id = int.Parse(proArray[0]);
            skill.Name = proArray[1];
            skill.Icon = proArray[2];
            switch (proArray[3])
            {
                case "Warrior":
                    skill.PlayerType = PlayerType.Warrior;
                    break;
                case "FemaleAssassin":
                    skill.PlayerType = PlayerType.FemaleAssassin;
                    break;
                default:
                    break;
            }
            switch (proArray[4])
            {
                case "Basic":
                    skill.SkillType = SkillType.Basic;
                    break;
                case "Skill":
                    skill.SkillType = SkillType.Skill;
                    break;
    
                default:
                    break;
            }
            switch (proArray[5])
            {
                case "Basic":
                    skill.SkillPosType = SkillPosType.Basic;
                    break;
                case "One":
                    skill.SkillPosType = SkillPosType.One;
                    break;
                case "Two":
                    skill.SkillPosType = SkillPosType.Two;
                    break;
                case "Three":
                    skill.SkillPosType = SkillPosType.Three;
                    break;
                default:
                    break;
            }
            skill.ColdTime = int.Parse(proArray[6]);
            skill.Damage = int.Parse(proArray[7]);
            skill.Level = 1;

            skillList.Add(skill);
        }


    }


    public Skill GetSkillByPosType(SkillPosType  skillPosType)
    {
        PlayerInfo playerInfo = PlayerInfo.Instance;
        foreach (Skill item in skillList)
        {

            if (playerInfo.PlayerType==item.PlayerType&&skillPosType==item.SkillPosType)
            {
                return item;
            }
        }
        return null;
    }
}
