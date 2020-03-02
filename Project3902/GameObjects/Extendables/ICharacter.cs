namespace Project3902
{
    interface ICharacter : IGameObject, ICollidable
    {
        float Health { get; set; }
    }
}
