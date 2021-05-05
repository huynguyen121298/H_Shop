using DAL.DAL_Client;
using DAL.DAL_Model;
using DAL.EF;
using Model.DTO.DTO_Ad;
using Model.DTO_Model;
using Model.EF_Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL_Client
{
   public class BLL_Cart
    {
        DAL_Cart dalFb = new DAL_Cart();
        public int InsertBill(DTO_CheckoutCustomer_Order dTO_CheckoutCustomer_Order)
        {
            Checkout_Customer checkout_Customer = new Checkout_Customer();


            //double tiengiam = dalFb.GetGiamGia(dTO_CheckoutCustomer_Order.Zipcode);
            //if (tiengiam != 0)
            //{
                EntityMapper<DTO_CheckoutCustomer_Order, CheckoutCustomer_Order> mapObj = new EntityMapper<DTO_CheckoutCustomer_Order, CheckoutCustomer_Order>();
                CheckoutCustomer_Order customer_Order = new CheckoutCustomer_Order();
                customer_Order = mapObj.Translate(dTO_CheckoutCustomer_Order);
                Checkout_Customer _Customer = new Checkout_Customer();
                _Customer.FirstName = customer_Order.FirstName;
                _Customer.LastName = customer_Order.LastName;
                _Customer.Email = customer_Order.Email;
                _Customer.SDT = customer_Order.SDT;
                _Customer.DiaChi = customer_Order.DiaChi;
                _Customer.City = customer_Order.City;
                _Customer.Zipcode = customer_Order.Zipcode;
                _Customer.NgayTao = customer_Order.NgayTao;
                _Customer.TrangThai = customer_Order.TrangThai;
                // _Customer.GiamGia = dTO_CheckoutCustomer_Order.TongTien * tiengiam;
                _Customer.GiamGia = dTO_CheckoutCustomer_Order.GiamGia;
                _Customer.TongTien = dTO_CheckoutCustomer_Order.TongTien;
               // _Customer.TongTien = dTO_CheckoutCustomer_Order.TongTien - dTO_CheckoutCustomer_Order.TongTien * tiengiam;

                List<Checkout_Oder> checkout_Oder = new List<Checkout_Oder>();

                foreach (var item in dTO_CheckoutCustomer_Order.dTO_Checkout_Orders)
                {
                    Checkout_Oder checkout_order = new Checkout_Oder();
                    checkout_order.Id_SanPham = item.Id_SanPham; ;
                    checkout_order.TenSP = item.TenSP;
                    checkout_order.SoLuong = item.SoLuong;
                    checkout_order.Gia = item.Gia;
                    checkout_order.NgayTao = item.NgayTao;
                    checkout_order.TrangThai = item.TrangThai;
                    checkout_Oder.Add(checkout_order);
                }
                return dalFb.InsertBill(_Customer, checkout_Oder);
            //}
            //else
            //    return 0;
           
            //dTO_Feedback.TongTien = dTO_Feedback.TongTien - dTO_Feedback.TongTien * tiengiam;
            
          
            
          

        }

        public bool InsertCheckoutOrder(DTO_Checkout_Order dTO_Feedback)
        {
            EntityMapper<DTO_Checkout_Order, Checkout_Oder> mapObj = new EntityMapper<DTO_Checkout_Order, Checkout_Oder>();
            Checkout_Oder account = mapObj.Translate(dTO_Feedback);
            return dalFb.InsertCheckoutOrder(account);
        }
        public double GetGiamGia(string zipcode)
        {
           
            return dalFb.GetGiamGia(zipcode);
        }
    }
}
