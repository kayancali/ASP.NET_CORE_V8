namespace FormsApp.Models
{
    public class Repository
    {
        private static readonly List<Product> _products =new();
         private static readonly List<Category> _categories =new();

         static Repository() {
            
            _categories.Add(new Category {CategoryId =1, Name ="Telefon"});
            _categories.Add(new Category {CategoryId =2, Name ="Bilgisayar"});

            _products.Add(new Product {ProductID = 1 ,Name = "Iphone 14", Price=4000, IsActive=true,Image="iphone1.jpg",CategoryId=1});

            _products.Add(new Product {ProductID = 2 ,Name = "Iphone 13", Price=5000, IsActive=true,Image="iphone2.jpg",CategoryId=1});

            _products.Add(new Product {ProductID = 3 ,Name = "Iphone 11", Price=6000, IsActive=true,Image="iphone3.jpg",CategoryId=1});

            _products.Add(new Product {ProductID = 4 ,Name = "samsung", Price=7000, IsActive=true,Image="samsung1.jpg",CategoryId=1});


            _products.Add(new Product {ProductID = 5 ,Name = "asus", Price=59000, IsActive=true,Image="asus.jpg",CategoryId=2});

            _products.Add(new Product {ProductID = 6 ,Name = "lenovo", Price=17000, IsActive=true,Image="lenovo.jpg",CategoryId=2});

         }


        public static List<Product> Products

        {
            get{
                return _products;
            }
        }

        public static void CreateProduct( Product entity)
        {

            _products.Add(entity);
        }

        public static void EditProduct(Product updatedProduct)
        {
            var entity = _products.FirstOrDefault(p=> p.ProductID == updatedProduct.ProductID);
            if(entity !=null)
            {
                if(string.IsNullOrEmpty(updatedProduct.Name))
                {
                    
                    entity.Name=updatedProduct.Name;

                }
                entity.Price=updatedProduct.Price;
                entity.Image=updatedProduct.Image;
                entity.CategoryId=updatedProduct.CategoryId;
                entity.IsActive=updatedProduct.IsActive;

            }
        }


        public static void EditIsactive(Product updatedProduct)
        {
            var entity = _products.FirstOrDefault(p=> p.ProductID == updatedProduct.ProductID);
            if(entity !=null)
            {

       
                entity.IsActive=updatedProduct.IsActive;

            }
        }

        public static void DeleteProduct(Product deletedProduct)
        {
            var entity = _products.FirstOrDefault(p=> p.ProductID == deletedProduct.ProductID);
            if(entity !=null)
            {
                    _products.Remove(entity);
            }

        }
  

        public static List<Category> Categorys

        {
            get{
                return _categories;
            }
        }
    }
}