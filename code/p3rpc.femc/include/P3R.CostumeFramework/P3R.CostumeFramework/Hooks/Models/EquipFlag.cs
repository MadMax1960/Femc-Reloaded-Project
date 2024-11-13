namespace P3R.CostumeFramework.Hooks.Models;

[Flags]
public enum EquipFlag
{
    NONE = 0,
    Player = 1 << 1,
    Yukari = 1 << 2,
    Stupei = 1 << 3,
    Akihiko = 1 << 4,
    Mitsuru = 1 << 5,
    Fuuka = 1 << 6,
    Aigis = 1 << 7,
    Ken = 1 << 8,
    Koromaru = 1 << 9,
    Shinjiro = 1 << 10,
    Metis = 1 << 11,
}
