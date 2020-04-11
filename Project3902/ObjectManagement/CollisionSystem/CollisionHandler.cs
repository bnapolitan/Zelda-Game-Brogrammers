using Project3902.GameObjects;
using System.Collections.Generic;

namespace Project3902
{
    class CollisionHandler
    {
        public static CollisionHandler Instance { get; } = new CollisionHandler();

        private Dictionary<ICollidable, LayerMasksHolder> colliders;

        private Dictionary<ICollidable, LayerMasksHolder> collidersToAdd;

        private List<ICollidable> collidersToDelete;

        private bool flushRequested = false;

        private CollisionHandler()
        {
            colliders = new Dictionary<ICollidable, LayerMasksHolder>();
            collidersToAdd = new Dictionary<ICollidable, LayerMasksHolder>();
            collidersToDelete = new List<ICollidable>();
        }

        public void RegisterCollidable(ICollidable collidable, Layer mainLayer, params Layer[] masks)
        {
            var holder = new LayerMasksHolder(mainLayer, masks);
            collidersToAdd.Add(collidable, holder);
        }

        public void RemoveCollidable(ICollidable collidable)
        {
            collidersToDelete.Add(collidable);
        }

        public void CheckCollisions()
        {
            if (flushRequested)
            {
                flushRequested = false;
                colliders = new Dictionary<ICollidable, LayerMasksHolder>();
                collidersToAdd = new Dictionary<ICollidable, LayerMasksHolder>(); //test
                collidersToDelete = new List<ICollidable>();
                return;
            }

            foreach (var collidable in collidersToDelete)
                colliders.Remove(collidable);
            collidersToDelete = new List<ICollidable>();

            foreach (var collidable in collidersToAdd)
                colliders.Add(collidable.Key, collidable.Value);
            collidersToAdd = new Dictionary<ICollidable, LayerMasksHolder>();

            foreach (ICollidable collider in colliders.Keys)
            {
                foreach (ICollidable collidee in colliders.Keys)
                {
                    if (colliders[collider].Masks.Contains(colliders[collidee].MainLayer))
                    {
                        if (collider.Collider.Intersects(collidee.Collider))
                        {
                            collider.OnCollide(collidee.Collider);
                        }
                    }
                }
            }
        }

        public void Flush()
        {
            flushRequested = true;
        }
    }
}
