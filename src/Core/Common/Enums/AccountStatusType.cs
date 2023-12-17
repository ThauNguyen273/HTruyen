namespace Core.Common.Enums;
public enum AccountStatusType
{
    //Active:Tài khoản đang hoạt động và có thể sử dụng
    //Locked:Tài khoản bị khóa, thường là do nhập sai mật khẩu quá nhiều lần. Người dùng cần liên hệ với quản trị viên để mở khóa
    //Inactive:Tài khoản dừng hoạt động
    Active = 1, 
    Locked = 2, 
    Inactive = 3
}
