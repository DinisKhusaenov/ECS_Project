using Entitas;

namespace Code.Gameplay.Features.Armaments
{
    [Game] public class Armament : IComponent { }
    [Game] public class TargetLimit : IComponent { public int Value; }
    [Game] public class Processed : IComponent { }
    
    [Game] public class ScatteringCount : IComponent { public int Value; }
    [Game] public class ScatteringSize : IComponent { public float Value; }
}