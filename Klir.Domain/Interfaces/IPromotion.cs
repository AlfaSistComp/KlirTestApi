using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klir.Domain.Interfaces {
    public interface IPromotion {
        int Quantity();
        double Price();
        void UpdatePromotion();
    }
}
