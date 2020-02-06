using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    interface ILinkState : IState, IDrawable
    {
        void TakeDamage(float damage);

        void MoveLeft();
        void MoveRight();
        void MoveDown();
        void MoveUp();
    }
}
