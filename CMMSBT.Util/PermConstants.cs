
using System;
using System.Collections.Generic;
using CMMSBT.Domain;

namespace CMMSBT.Util
{
    public enum Permission
    {
        Read = 1,
        Insert = 2,
        Update = 3,
        Delete = 4
    }
 
    public enum Functions
    {
        SYS_Group = 7,
        SYS_UserAdmin = 8,

        DM_DonViTinh = 9,
        DM_PhongBan = 10,       
        DM_KhuVuc = 11,
        DM_DonVi = 12,        
        DM_NuocSanXuat = 13,
        DM_HangSanXuat = 14,
        DM_CongViec = 15,
        DM_BoPhan = 16,

    }

    public class PermConstants
    {
        
        public static List<ListItem> ListPerms
        {
            get
            {
                return new List<ListItem>
                           {
                               #region Hệ thống
                               new ListItem("Hệ thống / Nhóm người dùng", Functions.SYS_Group.GetHashCode().ToString()),
                               new ListItem("Hệ thống / Người dùng", Functions.SYS_UserAdmin.GetHashCode().ToString()),
                                #endregion

                               #region Danh mục
                               new ListItem("Danh mục / Đơn vị tính", Functions.DM_DonViTinh.GetHashCode().ToString()),
                               new ListItem("Danh mục / Phòng ban", Functions.DM_PhongBan.GetHashCode().ToString()),
                               new ListItem("Danh mục / Khu vực", Functions.DM_KhuVuc.GetHashCode().ToString()),
                               new ListItem("Danh mục / Đơn vị", Functions.DM_DonVi.GetHashCode().ToString()),
                               new ListItem("Danh mục / Nước sản xuất", Functions.DM_NuocSanXuat.GetHashCode().ToString()),
                               new ListItem("Danh mục / Hãng sản xuất", Functions.DM_HangSanXuat.GetHashCode().ToString()),
                               new ListItem("Danh mục / Công việc", Functions.DM_CongViec.GetHashCode().ToString()),
                               new ListItem("Danh mục / Bộ phận", Functions.DM_BoPhan.GetHashCode().ToString()),
                               #endregion                               

                               #region Kho                                                                                                                    
                                                         
                           
                               #endregion

                               #region Thiết kế
                               
                               #endregion                              

                               #region Thi công
                               
                                #endregion 

                               #region Khách hàng
                               
                                
                               #endregion

                               #region Sữa chữa 
                               
                                #endregion
                               
                           };
            }
        }
    }
}