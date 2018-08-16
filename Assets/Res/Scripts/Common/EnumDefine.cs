/// <summary>
/// 窗口类型
/// </summary>
public enum WindowUIType
{

    None,
    Hide,
    StartMenuPanel,
    LoginPanel,
    RegisterPanel,
    ServerPanel,
    GamePanel,
    CharacterSelectPanel,
    CharacterShowSelectPanel,//选择男女角色界面
    PlayerStatus,
    KnapsackPanel,
    NPCDialogPanel,
    SkillPanel,
    TranscriptPanel,
    TranscriptPanelDialog,
    BattleOverPanel

}

/// <summary>
/// 窗口的打开方式
/// </summary>
public enum WindowShowStyle
{
    Normal,
    CenterToBig,//中间放大
    FromTop,//从上来
    FromDown,//从下来
    FromLeft,//从左来
    FromRight//从右来
}

public enum ResourcesType
{


    UIPrefabs,
    Role, // 角色
    Effect // 特效
}



public enum InfoType
{
    Name,
    HeadPortrait,
    Level,
    Power,
    Exp,
    Diamond,
    Coin,
    Energy,
    Toughen,
    HP,
    Damage,
    Equip,
    All
}

/// <summary>
/// 角色类型
/// </summary>
public enum PlayerType
{
    Warrior,
    FemaleAssassin
}

public enum SkillType
{
    Basic,
    Skill
}

/// <summary>
/// 界面上的按钮位置
/// </summary>
public enum SkillPosType
{
    Basic=0,
    One=1,
    Two=2,
    Three=3
}

/// <summary>
/// 主角的攻击范围
/// </summary>
public enum AttackRange
{
    Forward,//前方向
    Around//周围
}


