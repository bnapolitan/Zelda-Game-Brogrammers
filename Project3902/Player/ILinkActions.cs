using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    interface ILinkActions
    {
        void TakeDamage(float damage);

        void MoveUp();

        void MoveDown();

        void MoveLeft();

        void MoveRight();

        void Attack();

        void UseItem();
    }
}
