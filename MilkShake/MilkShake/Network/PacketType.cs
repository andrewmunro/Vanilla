using System;
using Milkshake.Communication;

namespace Milkshake.Network
{
    public enum PacketHandleType
    {
        None,
        Logon,
        World,
    }
    public enum RealmServerOpCode : ushort
    {
        RESPONSE_SUCCESS = 0,
        RESPONSE_FAILURE = 1,
        RESPONSE_CANCELLED = 2,
        RESPONSE_DISCONNECTED = 3,
        RESPONSE_FAILED_TO_CONNECT = 4,
        RESPONSE_CONNECTED = 5,
        RESPONSE_VERSION_MISMATCH = 6,
        CSTATUS_CONNECTING = 7,
        CSTATUS_NEGOTIATING_SECURITY = 8,
        CSTATUS_NEGOTIATION_COMPLETE = 9,
        CSTATUS_NEGOTIATION_FAILED = 10,
        CSTATUS_AUTHENTICATING = 11,
        AUTH_OK = 12,
        AUTH_FAILED = 13,
        AUTH_REJECT = 14,
        AUTH_BAD_SERVER_PROOF = 15,
        AUTH_UNAVAILABLE = 16,
        AUTH_SYSTEM_ERROR = 17,
        AUTH_BILLING_ERROR = 18,
        AUTH_BILLING_EXPIRED = 19,
        AUTH_VERSION_MISMATCH = 20,
        AUTH_UNKNOWN_ACCOUNT = 21,
        AUTH_INCORRECT_PASSWORD = 22,
        AUTH_SESSION_EXPIRED = 23,
        AUTH_SERVER_SHUTTING_DOWN = 24,
        AUTH_ALREADY_LOGGING_IN = 25,
        AUTH_LOGIN_SERVER_NOT_FOUND = 26,
        AUTH_WAIT_QUEUE = 27, //
        AUTH_BANNED = 28,
        AUTH_ALREADY_ONLINE = 29,
        AUTH_NO_TIME = 30,
        AUTH_DB_BUSY = 31,
        AUTH_SUSPENDED = 32,
        AUTH_PARENTAL_CONTROL = 33,
        AUTH_LOCKED_ENFORCED = 34,
        REALM_LIST_IN_PROGRESS = 35,
        REALM_LIST_SUCCESS = 36,
        REALM_LIST_FAILED = 37,
        REALM_LIST_INVALID = 38,
        REALM_LIST_REALM_NOT_FOUND = 39,
        ACCOUNT_CREATE_IN_PROGRESS = 40, //
        ACCOUNT_CREATE_SUCCESS = 41,
        ACCOUNT_CREATE_FAILED = 42,
    }

    public class PacketType : IEquatable<PacketType>
    {
        public PacketType(PacketHandleType handleType, ushort opCode)
        {
            Type = handleType;
            OpCode = opCode;
        }

        public PacketType(AuthOpcodes opCode)
            : this(PacketHandleType.Logon, (ushort)opCode)
        { }

        public PacketType(RealmServerOpCode opCode)
            : this(PacketHandleType.World, (ushort)opCode)
        { }

        public PacketHandleType Type { get; private set; }
        public ushort OpCode { get; private set; }

        #region IEquatable<PacketType> Members

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.
        ///                 </param>
        public bool Equals(PacketType other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Equals(other.Type, Type) && other.OpCode == OpCode;
        }

        #endregion

        public static implicit operator PacketType(AuthOpcodes opCode)
        {
            return new PacketType(opCode);
        }

        public static implicit operator PacketType(RealmServerOpCode opCode)
        {
            return new PacketType(opCode);
        }

        public override string ToString()
        {
            switch (Type)
            {
                case PacketHandleType.Logon:
                    return ((AuthOpcodes)OpCode).ToString();
                case PacketHandleType.World:
                    return ((RealmServerOpCode)OpCode).ToString();
                default:
                    return "Unknown";
            }
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. 
        ///                 </param><exception cref="T:System.NullReferenceException">The <paramref name="obj"/> parameter is null.
        ///                 </exception><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != typeof(PacketType))
            {
                return false;
            }
            return Equals((PacketType)obj);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            unchecked
            {
                return (Type.GetHashCode() * 397) ^ OpCode.GetHashCode();
            }
        }

        public static bool operator ==(PacketType left, PacketType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PacketType left, PacketType right)
        {
            return !Equals(left, right);
        }
    }
}
