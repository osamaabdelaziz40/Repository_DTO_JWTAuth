using PRJ.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PRJ.Utility
{
    
    public static class RoleStrings
    {
        public const string Admin = "Admin";
        public const string Employee = "User";
    }
    public static class SessionStrings
    {
        public const string UserId = "UserId";
        public const string RoleId = "RoleId";
        public const string Username = "Username";
        public const string Timezone = "Timezone";
    }

    public static class ResponseMessages
    {
        public const string ADD = "Record add successfully.";
        public const string BAD_REQUEST = "The server was unable to process the request.";
        public const string GET = "Record(s) get successfully.";
        public const string INVALID_CREDENTIALS = "Invalid email/password.";
        public const string NOT_FOUND = "Record not found.";
        public const string UPDATE = "Record update successfully.";
        public const string Deleted = "Record deleted successfully.";
        public const string UNAUTHORIZED = "You are not authorized to access this request.";
        public const string EMAILEXIST = "Email already exist";
        public const string BLOCKED = "User is blocked";
    }
    public static class ResponseMessagesCode
    {
        public const int ADD = 001;
        public const int BAD_REQUEST = 002;
        public const int BLOCKED = 003;
        public const int DELETE = 004;
        public const int EXIST = 005;
        public const int GET = 006;
        public const int INVALID_CREDENTIALS = 007;
        public const int NOT_FOUND = 008;
        public const int UPDATE = 009;
        public const int UNAUTHORIZED = 010;
        public const int VERIFIED_CODE = 011;
        public const int VERIFIED_CODE_SEND = 012;
        public const int EMAILEXIST = 015;
        public const int INVALIDCODE = 016;
        public const int INVALID_PASSWORD = 023;

    }

    public static class ResponseTypes
    {
        public const string Unauthorized = "Unauthorized";
        public const string BadRequest = "BadRequest";
        public const string NotFound = "NotFound";
        public const string SomethingWentWrong = "SomethingWentWrong";
        public const string Single = "Single";
        public const string List = "List";
        public const string Create = "Create";
        public const string Update = "Update";
        public const string Delete = "Delete";
        public const string Custom = "Custom";
        public const string Cancel = "Cancel";
    }
}
