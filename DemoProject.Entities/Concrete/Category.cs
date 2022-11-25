using DemoProject.Entities.Interfaces;
using System;
using System.Collections.Generic;

namespace DemoProject.Entities.Concrete
{
    public class Category:BaseEntity,ITable
    {
        //This is for recursivity
        public string Name { get; set; }
        public int ParentCategoryId { get; set; }
        public  Category ParentCategory { get; set; }
        public  List<Category> SubCategories { get; set; }
        public  List<Product> Products { get; set; }
    }
}
