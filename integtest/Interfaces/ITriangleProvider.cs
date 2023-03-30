using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace integtest.Interfaces
{
    public interface ITriangleProvider
    {
        Triangle GetById(int id);
        List<Triangle> GettAll();
        void Save(Triangle triangle);
        void Update(Triangle triangle);
    }
}
