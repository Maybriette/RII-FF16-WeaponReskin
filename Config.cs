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

    public static readonly Dictionary<Skin, string> SkinStringMappings = new Dictionary<Skin, string>()
    {
        { Skin.Invictus, "b0001" },
        { Skin.Defender, "b0013" },
        { Skin.Excalibur, "b0014" },
        { Skin.AncientSword, "b0017" },
        { Skin.Masamune, "b0018" },
        { Skin.Ragnorak, "b0015" },
        { Skin.Curtana, "b0028" },
        { Skin.CloudBusterSword, "b0031" },
        { Skin.RadiantStormcry, "b0038" },
        { Skin.RadiantFlametongue, "b0039" },
        { Skin.RadiantLevinbolt, "b0040" },
        { Skin.RadiantGrindstone, "b0041" },
        { Skin.RadiantBrightburn, "b0042" },
        { Skin.RadiantIcebrand, "b0044" },
        { Skin.RadiantEverdark, "b0045" },
        { Skin.RadiantTidestrike, "b0043" },
        { Skin.FallenEnforcer, "b0034" },
        { Skin.UltimaWeapon, "b0027" },
        { Skin.OmegaWeapon, "b0035" },
        { Skin.OriginalSin, "b0036" },
        { Skin.TonberryKnife, "b0037" },
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
        TonberryKnife
    }
}

/// <summary>
/// Allows you to override certain aspects of the configuration creation process (e.g. create multiple configurations).
/// Override elements in <see cref="ConfiguratorMixinBase"/> for finer control.
/// </summary>
public class ConfiguratorMixin : ConfiguratorMixinBase
{
    // 
}