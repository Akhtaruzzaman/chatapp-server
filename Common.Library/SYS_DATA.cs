using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Library
{
    public static class SYS_DATA
    {
        public const string ADDED_SUCCESSFULL = "Added successfully";
        public const string Request_Submitted_Successfully = "Request Submitted successfully";
        public const string Attachment_Invalid = "Attachment Invalid";
        public const string UPDATED_SUCCESSFULLY = "Updated successfully";
        public const string UPGRADE_SUCCESSFULLY = "Upgrade successfully";       
        public const string Password_Change_Successfull = "Passwrod has been updated successfully";
        public const string SYNC_SUCCESSFULLY = "Sync successfully";
        public const string SOMETHING_GOES_WRONG = "Something goes wrong, please try again later";
        public const string Input_field_required = "Input field required";
        public const string INVALID_DATA = "Invalid data.";
        public const string DELETE_SUCCESS = "Deleted successfully";
        public const string DELETE_FAILED = "Deleted failed";
        public const string RS_NA_ID = "fadede5d-1c91-4d95-92e4-f447ea6edade";
        public const string RS_PARCEL_TABLE = "2E65F508-1906-4C3F-A9E1-52894D79C89B";
        public const string EmpetyGuid = "00000000-0000-0000-0000-000000000000";
        public static string DB_Connection = "";
        public const string JwtTokenName = "NetCore.BS23.2020-0Se0P_20xXA";


        public const string Default_Password = "123456";
        public const string Default_Password_Set_Success = "Default password (" + Default_Password + ") reset successfully";
        public const string Default_Password_Set_Failed = "Password not reset";
        public static bool IS_DEV_MODE = false;
        public static string AuthKey = "YourKey-2374-OFFKDI940NG7:56753253-tyuw-5769-0921-kfirox29zoxv";

        public const string URL = "https://localhost:5001";

        public static Guid GetId()
        {
            return Guid.NewGuid();
        }

    }
}
