using Microsoft.VisualStudio.TestTools.UnitTesting;
using RA;
using System;

namespace uebungen
{
    [TestClass]
    public class uebung4_RestAssured
    {
        [TestMethod]
        public void GetProductsTest()
        {
            new RestAssured()
                .Given()
                    .Header("Content-Type", "application/json")
                .When()
                    .Get("https://api.predic8.de:443/shop/products/")
                .Then()
                    .TestStatus("Status Code should be 200", c => c == 200)
                    .TestBody("Body should contain 10 products", b => b.products.Count == b.meta.limit.Value)
                    .Debug()
                    .Assert("Status Code should be 200")
                    .Assert("Body should contain 10 products")
             ;
        }


        [TestMethod]
        public void CreateProductsTest()
        {

            var newProduct = new
            {
                name = "Wildberries",
                price = 4.99,
                category_url = "/shop/categories/Fruits",
                vendor_url = "/shop/vendors/672"
            };


            string newPRodID = CreateNewProduct(newProduct);
        }


        [TestMethod]
        public void CRUD_ProductsTest()
        {

            var newProduct = new
            {
                name = "Wildberries",
                price = 4.99,
                category_url = "/shop/categories/Fruits",
                vendor_url = "/shop/vendors/672"
            };

            var updatedProduct = new
            {
                name = "UpdatedWildberries",
                price = 5.99,
                category_url = "/shop/categories/Fruits",
                vendor_url = "/shop/vendors/672"
            };


            // 1. Create new product
            string newPRodID = CreateNewProduct(newProduct);

            // 2. Update new product
            new RestAssured()
                .Given()
                    .Header("Content-Type", "application/json")
                    .Body(updatedProduct)
                    .Debug()
                .When()
                    .Put("https://api.predic8.de:443/shop/products/" + newPRodID)
                .Then()
                    .TestStatus("Status Code should be 200", c => c == 200)
                    .TestBody("Body should contain valid  product name", b => b.name == "UpdatedWildberries")
                    .TestBody("Body should contain valid product price", b => b.price == 5.99)
                    .Debug()
                    .Assert("Status Code should be 200")
                    .Assert("Body should contain valid  product name")
                    .Assert("Body should contain valid product price")
             ;


            // 3. Delete new product
            new RestAssured()
                .Given()
                    .Header("Content-Type", "application/json")
                .When()
                    .Delete("https://api.predic8.de:443/shop/products/" + newPRodID)
                .Then()
                    .TestStatus("Status Code should be 200", c => c == 200)
                    .Debug()
                    .Assert("Status Code should be 200")
             ;

            // 4. Read deleted product
            new RestAssured()
                .Given()
                    .Header("Content-Type", "application/json")
                .When()
                    .Get("https://api.predic8.de:443/shop/products/" + newPRodID)
                .Then()
                    .TestStatus("Status Code should be 404", c => c == 404)
                    .Debug()
                    .Assert("Status Code should be 404")
             ;
        }




        private string CreateNewProduct(object body)
        {
            string newProductID =
                new RestAssured()
                .Given()
                    .Header("Content-Type", "application/json")
                    .Body(body)
                    .Debug()
                .When()
                    .Post("https://api.predic8.de:443/shop/products/")
                .Then()
                    .TestStatus("Status Code should be 201", c => c == 201)
                    .TestBody("Body should contain valid  product name", b => b.name == "Wildberries")
                    .TestBody("Body should contain valid product url", b => ((string)b.product_url).StartsWith("/shop/products/"))
                    .Debug()
                    .Assert("Status Code should be 201")
                    .Assert("Body should contain valid  product name")
                    .Assert("Body should contain valid product url")
                    .Retrieve(b => ((string)b.product_url).Replace("/shop/products/", ""))
                    .ToString();

            Console.WriteLine("New PRoduct ID: " + newProductID);

            return newProductID;
        }


    }
}
