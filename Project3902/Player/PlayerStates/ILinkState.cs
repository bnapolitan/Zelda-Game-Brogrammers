namespace Project3902
{
    interface ILinkState : IState, IDrawable, ILinkActions, ICollidable
    {

        ISprite Sprite { get; set; }
    }
}
