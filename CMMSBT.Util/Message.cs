#region Imports

using System;
using System.Collections.Generic;

#endregion

namespace CMMSBT.Util
{
    #region Message entity

    public class Message
    {
        #region Variable(s)

        private string _msgCode;
        private object[] _holders;
        private MessageType _msgType;

        #endregion

        #region Constructor(s)

        public Message(string msgCode, MessageType msgType)
        {
            _msgCode = msgCode;
            _msgType = msgType;
            _holders = new object[5];
        }

        public Message(string msgCode, MessageType msgType, params object[] holders)
        {
            _msgCode = msgCode;
            _msgType = msgType;
            _holders = holders;
        }

        #endregion

        #region Properties

        public string MsgCode
        {
            get { return _msgCode; }
            set { _msgCode = value; }
        }

        public object[] Holders
        {
            get { return _holders; }
            set { _holders = value; }
        }

        public MessageType MsgType
        {
            get { return _msgType; }
            set { _msgType = value; }
        }

        #endregion
    }

    public class MessageCollection
    {
        private List<Message> _msgCollection = new List<Message>();

        public void Add(Message message)
        {
            _msgCollection.Add(message);
        }

        public Message this[int i]
        {
            get { return _msgCollection[i]; }
            set { _msgCollection[i] = value; }
        }

        public List<Message> MsgCollection
        {
            get { return _msgCollection; }
            set { _msgCollection = value; }
        }
    }

    #endregion

    #region Message type

    public enum MessageType
    {
        Error = 0,
        Info = 1,
        Warning = 2,
        Confirm = 3
    }

    public class ExceptionConstants
    {
        public const string UniqueKeyViolation = "violation of unique key constraint";
        public const string InsertDuplicateKey = "cannot insert duplicate key in object";
        public const string ConnectionFailed = "a transport-level error has occurred when sending the request to the server";
    }

    #endregion

    #region Message constant(s)

    public class MessageConstants
    {
        /// <summary>
        /// Kỳ ghi chỉ số này đã được khởi tạo.
        /// </summary>
        public const string E_GCS_KHOITAO_KYDAKHOITAO = "E_GCS_KHOITAO_KYDAKHOITAO";

        /// <summary>
        /// Kỳ ghi chỉ số này chưa được khởi tạo.
        /// </summary>
        public const string E_GCS_KHOITAO_KYCHUAKHOITAO = "E_GCS_KHOITAO_KYCHUAKHOITAO";

        /// <summary>
        /// {0} thành công.
        /// </summary>
        public const string I_THANHCONG = "I_THANHCONG";

        /// <summary>
        /// {0} không thành công. <br/>Kết nối đến cơ sở dữ liệu thất bại. Liên hệ với quản trị hệ thống để được hỗ trợ.
        /// </summary>
        public const string E_SQLCON_FAILED = "E_SQLCON_FAILED";

        /// <summary>
        /// {0} không thành công.<br/>Dữ liệu đã tồn tại sẵn.
        /// </summary>
        public const string E_FAILED_DUPLICATED_KEY = "E_FAILED_DUPLICATED_KEY";

        /// <summary>
        /// {0} không thành công
        /// </summary>
        public const string E_FAILED = "E_FAILED";

        /// <summary>
        /// {0} không thành công.<br/><br/> {1}
        /// </summary>
        public const string E_FAILED_EXCEPTION = "E_FAILED_EXCEPTION";

        /// <summary>
        /// {0} không thành công. Mã danh bộ đã tồn tại.
        /// </summary>
        public const string E_KH_MADB_TONTAI = "E_KH_MADB_TONTAI";

        /// <summary>
        /// Lỗi hệ thống. {0} <br/><br/> {1}
        /// </summary>
        public const string E_EXCEPTION = "E_EXCEPTION";

        /// <summary>
        /// {0} không hợp lệ.
        /// </summary>
        public const string E_INVALID_DATA = "E_INVALID_DATA";

        /// <summary>
        /// Không thể xóa {0} {1} vì đang được sử dụng.
        /// </summary>
        public const string E_OBJECT_IN_USED = "E_OBJECT_IN_USED";

        /// <summary>
        /// Đối tương {0} được thêm mới thành công.
        /// </summary>
        public const string I_CREATE_SUCCEED = "I_CREATE_SUCCEED";

        /// <summary>
        /// Đối tượng {0} được cập nhật thành công.
        /// </summary>
        public const string I_UPDATE_SUCCEED = "I_UPDATE_SUCCEED";

        /// <summary>
        /// Xóa {0} thành công.
        /// </summary>
        public const string I_DELETE_SUCCEED = "I_DELETE_SUCCEED";

        /// <summary>
        /// Duyệt {0} thành công.
        /// </summary>
        public const string I_APPROVE_SUCCEED = "I_APPROVE_SUCCEED";

        /// <summary>
        /// Từ chối {0} thành công.
        /// </summary>
        public const string I_REJECT_SUCCEED = "I_REJECT_SUCCEED";

        /// <summary>
        /// <b>{0}</b> tên <b>{0}</b> không tồn tại.
        /// </summary>
        public const string E_OBJECT_NOT_EXISTS = "E_OBJECT_NOT_EXISTS";

        /// <summary>
        /// Không đủ quyền để thực hiện thao tác này.
        /// </summary>
        public const string WARN_PERMISSION_DENIED = "WARN_PERMISSION_DENIED";

        /// <summary>
        /// Cập nhật {0} {1} thành công. {2} {3} không thành công.
        /// </summary>
        public const string W_UPDATELIST_SUCCEED_WITH_ERRORS = "W_UPDATELIST_SUCCEED_WITH_ERRORS";

        /// <summary>
        /// Xóa {0} {1} thành công. {2} {3} không thành công.
        /// </summary>
        public const string W_DELETELIST_SUCCEED_WITH_ERRORS = "W_DELETELIST_SUCCEED_WITH_ERRORS";


        /// <summary>
        /// Cập nhật {0} {1} thành công.
        /// </summary>
        public const string I_UPDATELIST_SUCCEED = "I_UPDATELIST_SUCCEED";

        /// <summary>
        /// Xóa {0} không thành công.<br/>Dữ liệu đã tồn tại sẵn.
        /// </summary>
        public const string E_DELETE_FAILED_DUPLICATED_KEY = "E_DELETE_FAILED_DUPLICATED_KEY";
        
        /// <summary>
        /// Xóa {0} không thành công.<br/><br/> {1}
        /// </summary>
        public const string E_DELETE_FAILED_EXCEPTION = "E_DELETE_FAILED_EXCEPTION";
        
        /// <summary>
        /// Xóa {0} không thành công. <br/>Kết nối đến cơ sở dữ liệu thất bại. Liên hệ với quản trị hệ thống để được hỗ trợ.
        /// </summary>
        public const string E_DELETE_SQLCON_FAILED = "E_DELETE_SQLCON_FAILED";
        
        /// <summary>
        /// Thêm mới {0} không thành công.<br/>Dữ liệu đã tồn tại sẵn.
        /// </summary>
        public const string E_INSERT_FAILED_DUPLICATED_KEY = "E_INSERT_FAILED_DUPLICATED_KEY";
        
        /// <summary>
        /// Thêm mới {0} không thành công.<br/><br/> {1}
        /// </summary>
        public const string E_INSERT_FAILED_EXCEPTION = "E_INSERT_FAILED_EXCEPTION";
        
        /// <summary>
        /// Thêm mới {0} không thành công. <br/>Kết nối đến cơ sở dữ liệu thất bại. Liên hệ với quản trị hệ thống để được hỗ trợ.
        /// </summary>
        public const string E_INSERT_SQLCON_FAILED = "E_INSERT_SQLCON_FAILED";
        
        /// <summary>
        /// Cập nhật {0} không thành công.<br/>Dữ liệu đã tồn tại sẵn.
        /// </summary>
        public const string E_UPDATE_FAILED_DUPLICATED_KEY = "E_UPDATE_FAILED_DUPLICATED_KEY";
        
        /// <summary>
        /// Cập nhật {0} không thành công.<br/><br/> {1}
        /// </summary>
        public const string E_UPDATE_FAILED_EXCEPTION = "E_UPDATE_FAILED_EXCEPTION";
        
        /// <summary>
        /// Cập nhật {0} không thành công. <br/>Kết nối đến cơ sở dữ liệu thất bại. Liên hệ với quản trị hệ thống để được hỗ trợ.
        /// </summary>
        public const string E_UPDATE_SQLCON_FAILED = "E_UPDATE_SQLCON_FAILED";
        
    }

    #endregion

    public class ExceptionHandler
    {
        /// <summary>
        /// handle object insert exception
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="objParameter"></param>
        /// <returns></returns>
        public static Message HandleInsertException(Exception ex, params object[] objParameter)
        {
            Message msg;

            // handle unique key violation
            if (ex.Message.ToLower().Contains(ExceptionConstants.UniqueKeyViolation) &&
                ex.Message.ToLower().Contains(ExceptionConstants.InsertDuplicateKey))
            {
                msg = new Message(MessageConstants.E_INSERT_FAILED_DUPLICATED_KEY, MessageType.Error, objParameter);
            }
            // handle sql connection failed
            else if (ex.Message.ToLower().Contains(ExceptionConstants.ConnectionFailed))
            {
                msg = new Message(MessageConstants.E_INSERT_SQLCON_FAILED, MessageType.Error, objParameter);
            }
            // handle unknown exception
            else
            {
                msg = new Message(MessageConstants.E_INSERT_FAILED_EXCEPTION, MessageType.Error, objParameter, ex.Message);
            }

            return msg;
        }

        /// <summary>
        /// handle object update exception
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="objParameter"></param>
        /// <returns></returns>
        public static Message HandleUpdateException(Exception ex, params object[] objParameter)
        {
            Message msg;

            // handle unique key violation
            if (ex.Message.ToLower().Contains(ExceptionConstants.UniqueKeyViolation) &&
                ex.Message.ToLower().Contains(ExceptionConstants.InsertDuplicateKey))
            {
                msg = new Message(MessageConstants.E_UPDATE_FAILED_DUPLICATED_KEY, MessageType.Error, objParameter);
            }
            // handle sql connection failed
            else if (ex.Message.ToLower().Contains(ExceptionConstants.ConnectionFailed))
            {
                msg = new Message(MessageConstants.E_UPDATE_SQLCON_FAILED, MessageType.Error);
            }
            // handle unknown exception
            else
            {
                msg = new Message(MessageConstants.E_UPDATE_FAILED_EXCEPTION, MessageType.Error, objParameter);
            }

            return msg;
        }

        /// <summary>
        /// handle object delete exception
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="objParameter"></param>
        /// <returns></returns>
        public static Message HandleDeleteException(Exception ex, params object[] objParameter)
        {
            Message msg;

            // handle sql connection failed
            if (ex.Message.ToLower().Contains(ExceptionConstants.ConnectionFailed))
            {
                msg = new Message(MessageConstants.E_DELETE_SQLCON_FAILED, MessageType.Error);
            }
            // handle unknown exception
            else
            {
                msg = new Message(MessageConstants.E_DELETE_FAILED_EXCEPTION, MessageType.Error, objParameter, ex.Message);
            }

            return msg;
        }
    }
}
