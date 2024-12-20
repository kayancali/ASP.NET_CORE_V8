using System;
using StoreApp.Data.Concrete;

namespace StoreApp.Web.Models;

public class Cart
{
    public List<CartItem> Items { get; set; }= new List<CartItem>();

    public virtual void AddItem(Product product, int quantity)
    {
        var item = Items.Where(x => x.Product.Id == product.Id).FirstOrDefault();
        if (item == null)
        {
            Items.Add(new CartItem{Product=product, Quantity=quantity});
        }
        else
        {
            item.Quantity+=quantity;
        }
    }

    public virtual void RemoveItem(Product product)
{
    var item = Items.FirstOrDefault(x => x.Product.Id == product.Id);
    if (item != null)
    {
        if (item.Quantity > 1)
        {
            item.Quantity--; // Sadece miktarı azalt
        }
        else
        {
            Items.Remove(item); // Miktar 1 ise ürünü tamamen kaldır
        }
    }
}


    public double CalculateTotal()
    {
        return Items.Sum(i =>i.Product.Price * i.Quantity);
    }

    public virtual void Clear()
    {
        Items.Clear();
    }

}

public class CartItem
{
    public int CartItemId { get; set; }
    public Product Product { get; set; } = new Product();

    public int Quantity { get; set; }
}
