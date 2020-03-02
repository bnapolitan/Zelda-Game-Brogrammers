using Project3902.GameObjects;
using System.Collections.Generic;

namespace Project3902
{
    class CollisionHandler
    {
        
        public static CollisionHandler Instance { get; } = new CollisionHandler();
        private FinalGame game;
        private Dictionary<ICollidable, LayerMasksHolder> dict;

        private CollisionHandler() 
        {
            Flush();
        }

        public void RegisterGame(FinalGame game)
        {
            this.game = game;
        }
        public void RegisterCollidable(ICollidable collidable, Layer mainLayer, params Layer[] masks)
        {
            var holder = new LayerMasksHolder(mainLayer, masks);
            dict.Add(collidable, holder);
        }

        public void CheckCollisions()
        {
            foreach (ICollidable collider in dict.Keys)
            {
                foreach (ICollidable collidee in dict.Keys)
                {
                    if (dict[collider].Masks.Contains(dict[collidee].MainLayer))
                    {
                        if (collider.Collider.Intersects(collidee.Collider))
                        {
                            collider.OnCollide(collidee.Collider);
                        }
                    }
                }
            }
        }

        public void RemoveCollider(ICollidable gameObject)
        {
            dict.Remove(gameObject);
            if(gameObject is IEnemy)
            {
                game.enemyObjects.Remove(gameObject as IGameObject);
            }
            if(gameObject is IInteractiveEnvironmentObject)
            {
                game.interactiveEnvironmentObjects.Remove(gameObject as IGameObject);
            }
        }

        public void Flush()
        {
            dict = new Dictionary<ICollidable, LayerMasksHolder>();
        }
    }
}
