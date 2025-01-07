using System.ComponentModel;
using ff16.skins.clivesswords.Template.Configuration;
using Reloaded.Mod.Interfaces.Structs;

namespace ff16.skins.clivesswords.Configuration;

public class Config : Configurable<Config>
{
    public static readonly Dictionary<Sword, string> SwordStringMappings = new Dictionary<Sword, string>()
    {
        { Sword.ImperialInfantry, "b0002" },
        { Sword.Broadsword, "b0005" },
        { Sword.Longsword, "b0006" },
        { Sword.BastardSword, "b0007" },
        { Sword.Stormcry, "b0019" },
        { Sword.GaiaBlade, "b0008" },
        { Sword.Invictus, "b0001" },
        { Sword.Flametongue, "b0020" },
        { Sword.CoralSword, "b0016" },
        { Sword.Levinbolt, "b0021" },
        { Sword.PlatinumSword, "b0009" },
        { Sword.Grindstone, "b0022" },
        { Sword.Enhancer, "b0010" },
        { Sword.DiamondSword, "b0011" },
        { Sword.AncientSword, "b0017" },
        { Sword.Excalibur, "b0014" },
        { Sword.Brightburn, "b0023" },
        { Sword.RuneBlade, "b0012" },
        { Sword.Icebrand, "b0025" },
        { Sword.Masamune, "b0018" },
        { Sword.Everdark, "b0026" },
        { Sword.Defender, "b0013" },
        { Sword.Ragnorak, "b0015" },
        { Sword.FallenEnforcer, "b0034" },
        { Sword.Tidestrike, "b0024" },
        { Sword.UltimaWeapon, "b0027" },
        { Sword.OmegaWeapon, "b0035" },
        { Sword.OriginalSin, "b0036" },
        { Sword.TonberryKnife, "b0037" },
        { Sword.BraveBlade, "b0032" },
        { Sword.OnionSword, "b0030" }
    };

    public class SkinFileInfo
    {
        public string PackNum { get; set; }  // Pack number of weapon skin
        public string ModelPath { get; set; }   // Model number of weapon skin 
    }

    public static readonly Dictionary<Skin, SkinFileInfo> SkinStringMappings = new()
    {
        { (Skin.Invictus), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0001" } },
        { (Skin.Defender), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0013" } },
        { (Skin.Excalibur), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0014" } },
        { (Skin.AncientSword), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0017" } },
        { (Skin.Masamune), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0018" } },
        { (Skin.Ragnorak), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0015" } },
        { (Skin.Curtana), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0028" } },
        { (Skin.CloudBusterSword), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0031" } },
        { (Skin.RadiantStormcry), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0038" } },
        { (Skin.RadiantFlametongue), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0039" } },
        { (Skin.RadiantLevinbolt), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0040" } },
        { (Skin.RadiantGrindstone), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0041" } },
        { (Skin.RadiantBrightburn), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0042" } },
        { (Skin.RadiantIcebrand), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0044" } },
        { (Skin.RadiantEverdark), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0045" } },
        { (Skin.RadiantTidestrike), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0043" } },
        { (Skin.FallenEnforcer), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0034" } },
        { (Skin.UltimaWeapon), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0027" } },
        { (Skin.OmegaWeapon), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0035" } },
        { (Skin.OriginalSin), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0036" } },
        { (Skin.TonberryKnife), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0037" } },
        { (Skin.DionLance), new SkinFileInfo { PackNum = "c8209", ModelPath = "b0001" } },
        { (Skin.SleipnirGungnir), new SkinFileInfo { PackNum = "c8223", ModelPath = "b0001" } },
        { (Skin.OdinBlade), new SkinFileInfo { PackNum = "c1804", ModelPath = "b0002" } },
        { (Skin.OdinDoubleBlade), new SkinFileInfo { PackNum = "c1804", ModelPath = "b0001" } },
        { (Skin.ByronAxe), new SkinFileInfo { PackNum = "c8211", ModelPath = "b0001" } },
        { (Skin.DragoonSpear), new SkinFileInfo { PackNum = "c8002", ModelPath = "b0001" } },
        { (Skin.CidSword), new SkinFileInfo { PackNum = "c8203", ModelPath = "b0001" } },
        { (Skin.BenediktaSword), new SkinFileInfo { PackNum = "c8206", ModelPath = "b0001" } },
        { (Skin.JillRapier), new SkinFileInfo { PackNum = "c8212", ModelPath = "b0001" } },
        { (Skin.SleipnirSword), new SkinFileInfo { PackNum = "c8222", ModelPath = "b0001" } },
        { (Skin.JoshuaSword), new SkinFileInfo { PackNum = "c8202", ModelPath = "b0001" } }
    };


    [DisplayName("Sword to Reskin")]
    [Description("Choose which sword you wish to reskin.")]
    [DefaultValue(Sword.ImperialInfantry)]
    public Sword SelectedSword { get; set; } = Sword.ImperialInfantry;

    public enum Sword
    {
        ImperialInfantry,
        Broadsword,
        Longsword,
        BastardSword,
        Stormcry,
        GaiaBlade,
        Invictus,
        Flametongue,
        CoralSword,
        Levinbolt,
        PlatinumSword,
        Grindstone,
        Enhancer,
        DiamondSword,
        AncientSword,
        Excalibur,
        Brightburn,
        RuneBlade,
        Icebrand,
        Masamune,
        Everdark,
        Defender,
        Ragnorak,
        FallenEnforcer,
        Tidestrike,
        UltimaWeapon,
        OmegaWeapon,
        OriginalSin,
        TonberryKnife,
        BraveBlade,
        OnionSword
    }

    [DisplayName("Skin to Apply")]
    [Description("Choose which sword skin you wish to apply.")]
    [DefaultValue(Skin.UltimaWeapon)]
    public Skin SelectedSkin { get; set; } = Skin.UltimaWeapon;

    public enum Skin
    {
        Invictus,
        Defender,     
        Excalibur,
        AncientSword,
        Masamune,
        Ragnorak,
        Curtana,
        CloudBusterSword,
        RadiantStormcry,
        RadiantFlametongue,
        RadiantLevinbolt,
        RadiantGrindstone,
        RadiantBrightburn,
        RadiantIcebrand,
        RadiantEverdark,
        RadiantTidestrike,
        FallenEnforcer,
        UltimaWeapon,
        OmegaWeapon,
        OriginalSin,
        TonberryKnife,
        DionLance,
        SleipnirGungnir,
        OdinBlade,
        OdinDoubleBlade,
        ByronAxe, 
        DragoonSpear,
        CidSword,
        BenediktaSword,
        JillRapier, 
        SleipnirSword,
        JoshuaSword
    }

    [DisplayName("Also apply skin to Odin's blade?")]
    [Description("Reskins the blade appearance when Clive performs Odin abilities.")]
    [DefaultValue(false)]
    public bool ReskinOdin { get; set; } = false;

}

/// <summary>
/// Allows you to override certain aspects of the configuration creation process (e.g. create multiple configurations).
/// Override elements in <see cref="ConfiguratorMixinBase"/> for finer control.
/// </summary>
public class ConfiguratorMixin : ConfiguratorMixinBase
{
    // 
}