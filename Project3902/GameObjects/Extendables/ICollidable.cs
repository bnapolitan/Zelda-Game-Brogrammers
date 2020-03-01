namespace Project3902
{
    interface ICollidable
    {
        Collider Collider { get; set; }

        void OnCollide(Collider other);
    }
}
