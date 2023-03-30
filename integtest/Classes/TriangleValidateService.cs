using integtest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace integtest.Classes
{
    public class TriangleValidateService : ITriangleValidateService
    {
        private readonly ITriangleProvider TriangleProvider;
        private readonly ITriangleService TriangleService;
        private readonly ApplicationContext db;

        public TriangleValidateService(ITriangleProvider TriangleProvider, ITriangleService TriangleService, ApplicationContext db)
        {
            this.TriangleProvider = TriangleProvider;
            this.TriangleService = TriangleService;
            this.db = db;
        }
        public TriangleValidateService(ITriangleProvider TriangleProvider, ITriangleService TriangleService)
        {
            this.TriangleProvider = TriangleProvider;
            this.TriangleService = TriangleService;
        }
        public bool IsAllValid()
        {
            
            List<Triangle> list = TriangleProvider.GettAll();
            bool b = true;
            for (int i = 0; i < list.Count; i++)
            {
                if (TriangleService.IsValidTriangle(list[i].a, list[i].b, list[i].c) == false )
                {
                    list[i].isvalid = false;
                    TriangleProvider.Update(list[i]);
                    b = false;

                }
                if (TriangleService.GetType(list[i].a, list[i].b, list[i].c) != list[i].type)
                {
                    list[i].isvalid = false;
                    TriangleProvider.Update(list[i]);
                    b = false;
                }
                if (TriangleService.GetArea(list[i].a, list[i].b, list[i].c) != list[i].area)
                {
                    list[i].isvalid = false;
                    TriangleProvider.Update(list[i]);
                    b = false;
                }
                if (b == true)
                {
                    list[i].isvalid = true;
                    TriangleProvider.Update(list[i]);
                }
            }
            
            return b;
        }

        public bool IsValid(int id)
        {
            Triangle triangle = TriangleProvider.GetById(id);
            bool b = true;
            if (TriangleService.IsValidTriangle(triangle.a, triangle.b, triangle.c) == false)
            {
                b = false;
            }
            else if (TriangleService.GetType(triangle.a, triangle.b, triangle.c) != (Triangle.TriangleType)triangle.type)
            {
                b = false;
            }
            else if (TriangleService.GetArea(triangle.a, triangle.b, triangle.c) != triangle.area)
            {
                b = false;
            }
            if(b == true)
            {                              
                triangle.isvalid = true;
                TriangleProvider.Update(triangle);               
            }
            return b;
        }
    }
}
