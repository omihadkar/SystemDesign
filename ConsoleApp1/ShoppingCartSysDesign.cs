using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    // Driver class
    class ShoppingCartSysDesign
    {
        static void Main(string[] args)
        {
            Cart cart = new Cart();
            cart.AddItemToCart(new Product());
        }
    }

    public class Cart
    {
        public int NoOfItems { get; set; }
        public double TotalCartValue { get; set; }
        public List<IItem> CartItems { get; set; }
        public Queue<IDiscount> Discounts { get; set; } // Only next sequence discounts.
        public List<IDiscount> AllDiscounts { get; set; } // Only next sequence discounts.

        public void AddItemToCart(IItem item)
        {
            if (item.Types==TypeOfProduct.Discount)
            {
                
                CartItems.Add(item);
                if (((IDiscount)item).DiscountingProductSequence==0)
                {
                    AllDiscounts.Add(((IDiscount)item));
                }
                else
                {
                    Discounts.Enqueue((IDiscount)item);
                }                
            }
            else
            {
                if (Discounts.Count>0)
                {
                    var discountOnItem = Discounts.Dequeue();
                    DiscountingSystem.Instance.ApplyDiscount(discountOnItem, (IProduct)item);
                }
                else
                {
                    // going to apllied on all products.
                    foreach (var discount in AllDiscounts)
                    {
                        DiscountingSystem.Instance.ApplyDiscount(discount, (IProduct)item);
                    }
                }
            }
            CartItems.Add(item);
        }

        public void RemoveItemFromCart(IItem item)
        {
            CartItems.Remove(item);
            //Needs to write logic wherein once product removed, We need to reiterate over all the products and apply discount.
        }      
    }

    //Different class created since this is dynamic class. Whose behaviour might chnage. Principle of Single responsibility. 
    public class DiscountingSystem
    {
        private static DiscountingSystem instance = null;
        static object ob = new object();

        private DiscountingSystem()
        {            
        }
        public static DiscountingSystem Instance // SIngleton pattern
        {
            get
            {
                lock (ob)
                {
                    if (instance == null)
                    {
                        instance = new DiscountingSystem();
                    }
                }
                return instance;
            }
        }

        public void ApplyDiscount(IDiscount discountedProduct, IProduct product)
        {
            switch (discountedProduct.DiscountingType)
            {
                case DiscountType.Cash:
                    IDiscountStrategy cash = new CashDiscountStartegy();
                    var price = cash.CalculateFinalPrice(discountedProduct.DiscountedPrice, product.ActualPrice);
                    product.DiscountedPrice = price;
                    break;
                case DiscountType.Percentage:
                    IDiscountStrategy percentage = new PercentDiscountStrategy();
                    var percPrice = percentage.CalculateFinalPrice(discountedProduct.DiscountedPrice, product.ActualPrice);
                    product.DiscountedPrice = percPrice;
                    break;
                case DiscountType.All:
                    IDiscountStrategy all = new AllPercentDiscountStrategy();
                    //We need to know whether any discountVoucher is already applied or not. If it is applied then we should consider dicounted price.
                    var actual = product.DiscountedPrice > 0 ? product.DiscountedPrice : product.ActualPrice;
                    var allPrice = all.CalculateFinalPrice(discountedProduct.DiscountedPrice, actual);
                    product.DiscountedPrice = allPrice;
                    break;
                default:
                    break;
            }


        }
    }

    public enum TypeOfProduct
    {
        ActualProduct,
        Discount
    }

    public interface IItem
    {
        Guid Id { get; set; }
        string Description { get; set; }
         TypeOfProduct Types { get; set; }
    }

    public interface IProduct:IItem
    {
        double ActualPrice { get; set; }
        double DiscountedPrice { get; set; }
    }

    public class Product : IProduct
    {
        public double ActualPrice { get; set; }
        public double DiscountedPrice { get; set; }
        public Guid Id { get ; set ; }
        public string Description { get; set; }
        public TypeOfProduct Types { get; set; }
    }

    public interface IDiscount : IItem
    {
        double Value { get; set; }
        double DiscountedPrice { get; set; }
        DiscountType DiscountingType { get; set; }
        int DiscountingProductSequence { get; set; }
    }

    class Discount : IDiscount
    {
        public double Value { get; set; }
        public double DiscountedPrice { get; set; }
        public DiscountType DiscountingType { get; set; }
        public Guid Id { get; set; }
        public string Description { get; set; }
        public TypeOfProduct Types { get; set; }
        public int DiscountingProductSequence { get; set; }
    }

    public enum DiscountType
    {
        Cash,
        Percentage,
        All
    }

    interface IDiscountStrategy
    {
        double CalculateFinalPrice(double Price, double DiscountValue);
    }

    interface ICashDiscountStrategy:IDiscountStrategy
    {
        
    }

    interface IPercentDiscountStrategy : IDiscountStrategy
    {

    }

    interface IAllPercentDiscountStrategy : IDiscountStrategy
    {

    }

    class CashDiscountStartegy : ICashDiscountStrategy
    {
        public double CalculateFinalPrice(double Price, double DiscountValue)
        {
            return Price - DiscountValue;
        }
    }

    class PercentDiscountStrategy : IPercentDiscountStrategy
    {
        public double CalculateFinalPrice(double Price, double DiscountValue)
        {
            var finalPrice = Price - ((Price * DiscountValue) / 100);
            return finalPrice;
        }
    }

    class AllPercentDiscountStrategy : IAllPercentDiscountStrategy
    {
        public double CalculateFinalPrice(double Price, double DiscountValue)
        {
            var finalPrice = Price - ((Price * DiscountValue) / 100);
            return finalPrice;
        }
    }
}
