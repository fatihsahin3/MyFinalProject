using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Product was added!";
        public static string ProductNameInvalid = "Product name is invalid!";
        public static string ProductsListed = "Products were listed! ";
        public static string MaintenanceTime = "System in maintenance!";
        public static string ProductCountofCategoryError = "You exceeded the max. number of products in this category!";
        public static string ProductNameAlreadyExists = "Product name already exists!";
        public static string CategoryLimitExceeded = "Category limit has been exceeded! New product can not be added.";

        public static string AuthorizationDenied = "You have no access!";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
    }
}