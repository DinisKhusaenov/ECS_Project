//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class GameComponentsLookup {

    public const int Destructed = 0;
    public const int SelfDestructTimer = 1;
    public const int View = 2;
    public const int Damage = 3;
    public const int DamageTaken = 4;
    public const int Id = 5;
    public const int SpriteRenderer = 6;
    public const int Transform = 7;
    public const int WorldPosition = 8;
    public const int Enemy = 9;
    public const int EnemyAnimator = 10;
    public const int Hero = 11;
    public const int HeroAnimator = 12;
    public const int CurrentHp = 13;
    public const int MaxHp = 14;
    public const int Direction = 15;
    public const int Moving = 16;
    public const int Speed = 17;
    public const int TurnedAlongDirection = 18;
    public const int CollectTargetsInterval = 19;
    public const int CollectTargetsTimer = 20;
    public const int LayerMask = 21;
    public const int Radius = 22;
    public const int ReadyToCollectTargets = 23;
    public const int TargetsBuffer = 24;
    public const int AxisInput = 25;
    public const int Input = 26;

    public const int TotalComponents = 27;

    public static readonly string[] componentNames = {
        "Destructed",
        "SelfDestructTimer",
        "View",
        "Damage",
        "DamageTaken",
        "Id",
        "SpriteRenderer",
        "Transform",
        "WorldPosition",
        "Enemy",
        "EnemyAnimator",
        "Hero",
        "HeroAnimator",
        "CurrentHp",
        "MaxHp",
        "Direction",
        "Moving",
        "Speed",
        "TurnedAlongDirection",
        "CollectTargetsInterval",
        "CollectTargetsTimer",
        "LayerMask",
        "Radius",
        "ReadyToCollectTargets",
        "TargetsBuffer",
        "AxisInput",
        "Input"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Code.Common.Destructed),
        typeof(Code.Common.SelfDestructTimer),
        typeof(Code.Common.View),
        typeof(Code.Gameplay.Common.Damage),
        typeof(Code.Gameplay.Common.DamageTakenComponent),
        typeof(Code.Gameplay.Common.Id),
        typeof(Code.Gameplay.Common.SpriteRendererComponent),
        typeof(Code.Gameplay.Common.TransformComponent),
        typeof(Code.Gameplay.Common.WorldPosition),
        typeof(Code.Gameplay.Features.Enemies.Enemy),
        typeof(Code.Gameplay.Features.Enemies.EnemyAnimatorComponent),
        typeof(Code.Gameplay.Features.Hero.Hero),
        typeof(Code.Gameplay.Features.Hero.HeroAnimatorComponent),
        typeof(Code.Gameplay.Features.Lifetime.CurrentHp),
        typeof(Code.Gameplay.Features.Lifetime.MaxHp),
        typeof(Code.Gameplay.Features.Movement.Direction),
        typeof(Code.Gameplay.Features.Movement.Moving),
        typeof(Code.Gameplay.Features.Movement.Speed),
        typeof(Code.Gameplay.Features.Movement.TurnedAlongDirection),
        typeof(Code.Gameplay.Features.TargetCollection.CollectTargetsInterval),
        typeof(Code.Gameplay.Features.TargetCollection.CollectTargetsTimer),
        typeof(Code.Gameplay.Features.TargetCollection.LayerMask),
        typeof(Code.Gameplay.Features.TargetCollection.Radius),
        typeof(Code.Gameplay.Features.TargetCollection.ReadyToCollectTargets),
        typeof(Code.Gameplay.Features.TargetCollection.TargetsBuffer),
        typeof(Code.Gameplay.Input.AxisInput),
        typeof(Code.Gameplay.Input.Input)
    };
}
