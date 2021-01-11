using System.ComponentModel;

namespace Common.Library
{
    public class Sys_Enum
    {
        public enum UserType
        {
            /// <summary>
            /// Super Admin
            /// </summary>
            [Description("Admin")]
            Admin = 1,
            /// <summary>
            /// Admin
            /// </summary>
            [Description("User")]
            User = 2,
        }
        
        public enum SeenStatus
        {
            /// <summary>
            /// Pending
            /// </summary>
            [Description("Pending")]
            Pending = 1,
            /// <summary>
            /// Seen
            /// </summary>
            [Description("Sent")]
            Sent = 2,
            /// <summary>
            /// Seen
            /// </summary>
            [Description("Seen")]
            Seen = 3,
        }

    }
}
