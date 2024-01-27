import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

interface UserDropdownProps {
  avatarSrc: string;
  userName: string;
  userEmail: string;
}

const UserDropdown: React.FC<UserDropdownProps> = ({ avatarSrc, userName, userEmail }) => {   
  const navigate = useNavigate();
  const [isDropdownOpen, setDropdownOpen] = useState(false);

  const handleAvatarClick = () => {
    setDropdownOpen(!isDropdownOpen);
  };

  const handleLogout = () => {
    localStorage.removeItem('token');
    // Chuyển hướng về trang đăng nhập hoặc trang chính (tùy thuộc vào logic của bạn)
    navigate('/');
    window.location.reload();
  };

  return (
    <div className="relative">
      <img
        id="avatarButton"
        onClick={handleAvatarClick}
        className="w-10 h-10 rounded-full cursor-pointer"
        src={avatarSrc}
        alt="User dropdown"
      />

      {/* Dropdown menu */}
      {isDropdownOpen && (
        <div
          id="userDropdown"
          className="z-10 absolute right-0 mt-2 bg-white divide-y divide-gray-100 rounded-lg shadow w-44 dark:bg-gray-700 dark:divide-gray-600"
        >
          <div className="px-4 py-3 text-sm text-gray-900 dark:text-white">
            <div>{userName}</div>
            <div className="font-medium truncate">{userEmail}</div>
          </div>
          <ul className="py-2 text-sm text-gray-700 dark:text-gray-200" aria-labelledby="avatarButton">
            <li>
              <a href="/infomation" className="block px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white">
                Thông tin cá nhân
              </a>
            </li>
            <li>
              <a href="/bookshelf" className="block px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white">
                Tủ sách
              </a>
            </li>
            <li>
              <a href="/message" className="block px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white">
                Tin nhắn
              </a>
            </li>
            <li>
              <a href="/forums" className="block px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white">
                Diễn đàn
              </a>
            </li>
            <li>
              <a href="/payment" className="block px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white">
                Nạp tiền
              </a>
            </li>
          </ul>
          <div className="py-1">
            <a
              onClick={handleLogout}
              className="block px-4 py-2 text-sm text-gray-700 hover:bg-gray-100 dark:hover:bg-gray-600 dark:text-gray-200 dark:hover:text-white"
            >
              Sign out
            </a>
          </div>
        </div>
      )}
    </div>
  );
};

export default UserDropdown;