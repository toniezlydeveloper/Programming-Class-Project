using Characters.Player.Interfaces;

namespace Characters.Enemies.Interfaces
{
    public interface IChaser
    {
        bool ReachedTarget { get; }
        float TargetDirection { get; }
        
        void StartChasing(ITargetable targetToChase);
        void StopChasing();
    }
}