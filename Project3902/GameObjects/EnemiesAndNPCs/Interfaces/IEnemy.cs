
namespace Project3902
{
    interface IEnemy: ICharacter
    {
        void TakeDamage();
        void Attack();
        float Damage { get; set; }
    }
}
