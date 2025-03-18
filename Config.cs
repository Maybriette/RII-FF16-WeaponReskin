using System.ComponentModel;
using ff16.skins.clivesweapon.Template.Configuration;
using Reloaded.Mod.Interfaces.Structs;

namespace ff16.skins.clivesweapon.Configuration;

public class Config : Configurable<Config>
{
    public static readonly Dictionary<Sword, string> SwordStringMappings = new Dictionary<Sword, string>()
    {
        { Sword.Imperial_Infantry, "b0002" },
        { Sword.Broadsword, "b0005" },
        { Sword.Longsword, "b0006" },
        { Sword.Bastard_Sword, "b0007" },
        { Sword.Stormcry, "b0019" },
        { Sword.Gaia_Blade, "b0008" },
        { Sword.Invictus, "b0001" },
        { Sword.Flametongue, "b0020" },
        { Sword.Coral_Sword, "b0016" },
        { Sword.Levinbolt, "b0021" },
        { Sword.Platinum_Sword, "b0009" },
        { Sword.Grindstone, "b0022" },
        { Sword.Enhancer, "b0010" },
        { Sword.Diamond_Sword, "b0011" },
        { Sword.Ancient_Sword, "b0017" },
        { Sword.Excalibur, "b0014" },
        { Sword.Brightburn, "b0023" },
        { Sword.Rune_Blade, "b0012" },
        { Sword.Icebrand, "b0025" },
        { Sword.Masamune, "b0018" },
        { Sword.Everdark, "b0026" },
        { Sword.Defender, "b0013" },
        { Sword.Ragnarok, "b0015" },
        { Sword.Fallen_Enforcer, "b0034" },
        { Sword.Tidestrike, "b0024" },
        { Sword.Ultima_Weapon, "b0027" },
        { Sword.Omega_Weapon, "b0035" },
        { Sword.Original_Sin, "b0036" },
        { Sword.Tonberry_Knife, "b0037" },
        { Sword.Brave_Blade, "b0032" },
        { Sword.Onion_Sword, "b0030" }
    };

    public class SkinFileInfo
    {
        public string PackNum { get; set; }  // Pack number of weapon skin
        public string ModelPath { get; set; }   // Model number of weapon skin 
    }

    public static readonly Dictionary<Skin, SkinFileInfo> SkinStringMappings = new()
    {
        { (Skin.Holy_Moonlight), new SkinFileInfo { PackNum = "External", ModelPath = "External" } },
        { (Skin.Invictus), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0001" } },
        { (Skin.Imperial_Infantry), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0002"} },
        { (Skin.Defender), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0013" } },
        { (Skin.Excalibur), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0014" } },
        { (Skin.Ancient_Sword), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0017" } },
        { (Skin.Masamune), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0018" } },
        { (Skin.Ragnarok), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0015" } },
        { (Skin.Curtana), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0028" } },
        { (Skin.Buster_Sword), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0031" } },
        { (Skin.Rosarian_Oath), new SkinFileInfo { PackNum = "c8201", ModelPath = "b0001" } },
        { (Skin.Stormcry), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0019" } },
        { (Skin.Flametongue), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0020" } },
        { (Skin.Levinbolt), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0021" } },
        { (Skin.Grindstone), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0022" } },
        { (Skin.Brightburn), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0023" } },
        { (Skin.Icebrand), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0025" } },
        { (Skin.Everdark), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0026" } },
        { (Skin.Tidestrike), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0024" } },
        { (Skin.Radiant_Stormcry), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0038" } },
        { (Skin.Radiant_Flametongue), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0039" } },
        { (Skin.Radiant_Levinbolt), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0040" } },
        { (Skin.Radiant_Grindstone), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0041" } },
        { (Skin.Radiant_Brightburn), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0042" } },
        { (Skin.Radiant_Icebrand), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0044" } },
        { (Skin.Radiant_Everdark), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0045" } },
        { (Skin.Radiant_Tidestrike), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0043" } },
        { (Skin.Fallen_Enforcer), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0034" } },
        { (Skin.Ultima_Weapon), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0027" } },
        { (Skin.Omega_Weapon), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0035" } },
        { (Skin.Original_Sin), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0036" } },
        { (Skin.Tonberry_Knife), new SkinFileInfo { PackNum = "c8001", ModelPath = "b0037" } },
        { (Skin.Dion_Lance), new SkinFileInfo { PackNum = "c8209", ModelPath = "b0001" } },
        { (Skin.Sleipnir_Gungnir), new SkinFileInfo { PackNum = "c8223", ModelPath = "b0001" } },
        { (Skin.Odin_Blade), new SkinFileInfo { PackNum = "c1804", ModelPath = "b0002" } },
        { (Skin.Odin_Double_Blade), new SkinFileInfo { PackNum = "c1804", ModelPath = "b0001" } },
        { (Skin.Byron_Axe), new SkinFileInfo { PackNum = "c8211", ModelPath = "b0001" } },
        { (Skin.Dragoon_Spear), new SkinFileInfo { PackNum = "c8002", ModelPath = "b0001" } },
        { (Skin.Cid_Sword), new SkinFileInfo { PackNum = "c8203", ModelPath = "b0001" } },
        { (Skin.Benedikta_Sword), new SkinFileInfo { PackNum = "c8206", ModelPath = "b0001" } },
        { (Skin.Jill_Rapier), new SkinFileInfo { PackNum = "c8212", ModelPath = "b0001" } },
        { (Skin.Sleipnir_Sword), new SkinFileInfo { PackNum = "c8222", ModelPath = "b0001" } },
        { (Skin.Joshua_Sword), new SkinFileInfo { PackNum = "c8202", ModelPath = "b0001" } },
        { (Skin.Imperial_Assassin_Sword), new SkinFileInfo { PackNum = "c8301", ModelPath = "b0007" } }
    };

    [DisplayName("Sword to Reskin")]
    [Description("Choose which sword you wish to reskin.")]
    [DefaultValue(Sword.Imperial_Infantry)]
    public Sword SelectedSword { get; set; } = Sword.Imperial_Infantry;

    public enum Sword
    {
        Imperial_Infantry,
        Broadsword,
        Longsword,
        Bastard_Sword,
        Stormcry,
        Gaia_Blade,
        Invictus,
        Flametongue,
        Coral_Sword,
        Levinbolt,
        Platinum_Sword,
        Grindstone,
        Enhancer,
        Diamond_Sword,
        Ancient_Sword,
        Excalibur,
        Brightburn,
        Rune_Blade,
        Icebrand,
        Masamune,
        Everdark,
        Defender,
        Ragnarok,
        Fallen_Enforcer,
        Tidestrike,
        Ultima_Weapon,
        Omega_Weapon,
        Original_Sin,
        Tonberry_Knife,
        Brave_Blade,
        Onion_Sword
    }

    [DisplayName("Skin to Apply")]
    [Description("Choose which weapon skin you wish to apply.")]
    [DefaultValue(Skin.Holy_Moonlight)]
    public Skin SelectedSkin { get; set; } = Skin.Holy_Moonlight;

    public enum Skin
    {
        Holy_Moonlight,
        Invictus,
        Imperial_Infantry,
        Defender,     
        Excalibur,
        Ancient_Sword,
        Masamune,
        Ragnarok,
        Curtana,
        Buster_Sword,
        Rosarian_Oath,
        Stormcry,
        Flametongue,
        Levinbolt,
        Grindstone,
        Brightburn,
        Icebrand,
        Everdark,
        Tidestrike,
        Radiant_Stormcry,
        Radiant_Flametongue,
        Radiant_Levinbolt,
        Radiant_Grindstone,
        Radiant_Brightburn,
        Radiant_Icebrand,
        Radiant_Everdark,
        Radiant_Tidestrike,
        Fallen_Enforcer,
        Ultima_Weapon,
        Omega_Weapon,
        Original_Sin,
        Tonberry_Knife,
        Dion_Lance,
        Sleipnir_Gungnir,
        Odin_Blade,
        Odin_Double_Blade,
        Byron_Axe, 
        Dragoon_Spear,
        Cid_Sword,
        Benedikta_Sword,
        Jill_Rapier, 
        Sleipnir_Sword,
        Joshua_Sword,
        Imperial_Assassin_Sword
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