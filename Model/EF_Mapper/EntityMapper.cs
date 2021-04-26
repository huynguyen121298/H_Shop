using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DTO.DTO_Ad;
using Model.DTO.DTO_Client;
using AutoMapper;
using DAL.EF;
using DAL.DAL_Model;
using Model.DTO_Model;

namespace Model.EF_Mapper
{
    public class EntityMapper<TSource, TDestination> where TSource : class where TDestination : class
    {

        public EntityMapper()
        {
            Mapper.CreateMap<Account, DTO_Account>();
            Mapper.CreateMap<DTO_Account, Account>();

            Mapper.CreateMap<CodeDiscount, DTO_CodeDiscount>();
            Mapper.CreateMap<DTO_CodeDiscount, CodeDiscount>();

            Mapper.CreateMap<Discount_Product, DTO_Discount_Product>();
            Mapper.CreateMap<DTO_Discount_Product, Discount_Product>();

            Mapper.CreateMap<CheckoutCustomer_Order, DTO_CheckoutCustomer_Order>();
            Mapper.CreateMap<DTO_CheckoutCustomer_Order, CheckoutCustomer_Order>();

            Mapper.CreateMap<Users_Acc, DTO_Users_Acc>();
            Mapper.CreateMap<DTO_Users_Acc, Users_Acc>();

            Mapper.CreateMap<Users_Acc, DTO_User_Acc>();
            Mapper.CreateMap<DTO_User_Acc, Users_Acc>();

            Mapper.CreateMap<Dis_Product, DTO_Dis_Product>();
            Mapper.CreateMap<DTO_Dis_Product, Dis_Product>();


            Mapper.CreateMap<Product, DTO_Product>();
            Mapper.CreateMap<DTO_Product, Product>();

            Mapper.CreateMap<DTO_Product_Item_Type, Product_Item_Type>();
            Mapper.CreateMap<Product_Item_Type, DTO_Product_Item_Type>();

            Mapper.CreateMap<Item, DTO_Item_Client>();
            Mapper.CreateMap<DTO_Item_Client, Item>();

            Mapper.CreateMap<Item, DTO_Item>();
            Mapper.CreateMap<DTO_Item, Item>();

            Mapper.CreateMap<Item_Type, DTO_Item_Type>();
            Mapper.CreateMap<DTO_Item_Type, Item_Type>();

            Mapper.CreateMap<Checkout_Customer, DTO_Checkout_Customer>();
            Mapper.CreateMap<DTO_Checkout_Customer,Checkout_Customer>();

            Mapper.CreateMap<Checkout_Oder, DTO_Checkout_Order>();
            Mapper.CreateMap<DTO_Checkout_Order, Checkout_Oder>();

            Mapper.CreateMap<Product, DTO.DTO_Client.DTO_Product_Client>();
            Mapper.CreateMap<DTO.DTO_Client.DTO_Product_Client, Product>();

            Mapper.CreateMap<Account_Role, DTO.DTO_Ad.DTO_Account_Role>();
            Mapper.CreateMap<DTO.DTO_Ad.DTO_Account_Role, Account_Role>();

            Mapper.CreateMap<Feedback, DTO_Feedback>();
            Mapper.CreateMap<DTO_Feedback, Feedback>();

        }


        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}
