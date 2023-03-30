using integtest.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace integtest.Classes
{
    
    public class TriangleProvider : ITriangleProvider
    {
        public List<Triangle> GettAll()
        {
            List<Triangle> list;
            using (var context = new ApplicationContext())
            {
                list = context.Triangle.ToList();
            }
            return list;
        }
        public Triangle GetById(int id)
        {
            Triangle triangle;
            using (var context = new ApplicationContext())
            {
                triangle = context.Triangle.Find(id);
            }
            return triangle;
        }
        public void Save(Triangle triangle)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Triangle.Add(triangle);
                db.SaveChanges();               
            }
        }
        public void Update(Triangle triangle)
        {     
            using (ApplicationContext db = new ApplicationContext())
            {               
                db.Triangle.Update(triangle);
                db.SaveChanges();
            }
        }
    }
}
