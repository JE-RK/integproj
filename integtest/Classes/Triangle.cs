using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Triangle
{
    [Flags]
    public enum TriangleType
    {
        Oxygon = 1, //острый
        Obtuse = 2, //тупой
        Right = 4, //прямой
        Scalene = 8, //разносторонний
        Isosceles = 16, //равнобедренный
        Equilateral = 32, //равносторонний
    }
    public int id { get; set; }
    public int a { get; set; }
    public int b { get; set; }
    public int c { get; set; }
    public double area { get; set; }
    public TriangleType type { get; set; }
    public bool isvalid { get; set; }

    public Triangle(int id, int a, int b, int c, double area, TriangleType type)
    {
        this.id = id;
        this.a = a;
        this.b = b;
        this.c = c;
        this.area = area;
        this.type = type;
        isvalid = false;
    }
    public Triangle()
    {

    }
}
