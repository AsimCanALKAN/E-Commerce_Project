using System;
using System.Runtime.Serialization;
using Core.Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Product is added.";
        public static string ProductUpdated = "Product is updated.";
        public static string ProductNameLengthError = "Product name can not be less than 2 char.";
        public static string ProductNameInvalid = "Product name is invalid.";
        public static string ProductStartsNameInvalid = "Product name starts with 'A'.";
        public static string ProductInvalid = "Product is invalid.";
        public static string InvalidDatetime = "You cannot do this function right now.";
        public static string ProductListed = "All your requested products is listed.";
        public static string ProductCountIsNotAllowed = "Product count cannot be more than 10."; 
        public static string CategoryCountExcedeed = "Category count is reached maximum count.";
        public static string AuthorizationDenied = "Authorization Denied";

        public static string UserRegistered = "User is successfully registered";
        public static string UserNotFound = "User is not found";
        public static string PasswordError = "Password Error";
        public static string AccessTokenCreated = "Access Token Created";
        public static string UserAlreadyExists = "User Already Exists";
        public static string SuccessfulLogin = "Login Successfull";
    }
}

