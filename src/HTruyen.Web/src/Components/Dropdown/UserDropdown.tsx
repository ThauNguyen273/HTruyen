import { faBook, faCloudArrowUp, faRightFromBracket, faUser, faWallet } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import React, { useEffect, useRef, useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { Account, getAccount } from '../../Services/Authentications/AccountService';

interface UserDropdownProps {
  avatarSrc?: string;
  accountName?: string;
  accountEmail?: string;
}

const UserDropdown: React.FC<UserDropdownProps> = ({ avatarSrc, accountName, accountEmail }) => {   
  const navigate = useNavigate();
  const [isDropdownOpen, setDropdownOpen] = useState(false);
  const [role, setRole] = useState<string | null>(null)
  const [, setAccountId] = useState<string | null>(null);
  const [account, setAccount] = useState<Account | null>(null)
  const dropdownRef = useRef<HTMLDivElement>(null);


  useEffect (() => {
    const roleInfo = localStorage.getItem('role')
    setRole(roleInfo)

    const accountIdInfo = localStorage.getItem('accountId')
    setAccountId(accountIdInfo)
  },[])

  useEffect(() => {
    const fetchAccountInfo = async () => {
      try {
        const accountId = localStorage.getItem('accountId')
        if (accountId) {
          const accountData = await getAccount(accountId);
          setAccount(accountData)
        }
      } catch (error) {
        console.log('Error fetching account:', error)
      }
    }
    
    fetchAccountInfo()
  },[])

  useEffect(() => {
    const handleClickOutside = (event: MouseEvent) => {
      if (dropdownRef.current && !dropdownRef.current.contains(event.target as Node)) {
        setDropdownOpen(false);
      }
    };

    document.addEventListener('click', handleClickOutside);

    return () => {
      document.removeEventListener('click', handleClickOutside);
    };
  }, [isDropdownOpen]);

  const handleAvatarClick = () => {
    setDropdownOpen(!isDropdownOpen);
  };

  const handleLogout = () => {
    localStorage.removeItem('token');
    localStorage.removeItem('role')
    localStorage.removeItem('accountId')
    // Chuyển hướng về trang đăng nhập và reload
    navigate('/');
    window.location.reload();
  };

  return (
    <div className="relative" ref={dropdownRef}>
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
            <div>{accountName}</div>
            <div className="font-medium truncate">{accountEmail}</div>
          </div>
          <ul className="py-2 text-sm text-gray-700 dark:text-gray-200" aria-labelledby="avatarButton">
            {role === 'Author' && (
              <>
                <li>
                  <Link to={`/info/${account?.authorId}`} className="block px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white">
                    <FontAwesomeIcon icon={faUser} className="mr-2"/>
                    Thông Tin
                  </Link>
                </li>
                <li>
                  <Link to={`/manager/novel/create/${account?.authorId}`} className="block px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white">
                    <FontAwesomeIcon icon={faCloudArrowUp} className="mr-2"/>
                    Đăng Truyện
                  </Link>
                </li>
                <li>
                  <Link to={`/manager/novel/${account?.authorId}`} className="block px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white">
                    <FontAwesomeIcon icon={faBook} className="mr-2"/>
                    Quản Lý Truyện
                  </Link>
                </li>
              </>
            )}
            {role === 'User' && (
              <>
                <li>
                  <Link to={`/info/${account?.userId}`} className="block px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white">
                    <FontAwesomeIcon icon={faUser} className="mr-2"/>
                    Thông Tin
                  </Link>
                </li>
                <li>
                  <Link to={`/library/bookmarks/${account?.userId}`} className="block px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white">
                    <FontAwesomeIcon icon={faBook} className="mr-2"/>
                    Tủ Sách
                  </Link>
                </li>
              </>
            )}
            <li>
              <a href="#" className="block px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white">
                <FontAwesomeIcon icon={faWallet} className="mr-2"/>
                Nạp Tiền
              </a>
            </li>
          </ul>
          <div className="py-1">
            <a
              onClick={handleLogout}
              className="block px-4 py-2 text-sm text-gray-700 hover:bg-gray-100 dark:hover:bg-gray-600 dark:text-gray-200 dark:hover:text-white"
            >
              <FontAwesomeIcon icon={faRightFromBracket} className="mr-2"/>
              Sign out
            </a>
          </div>
        </div>
      )}
    </div>
  );
};

export default UserDropdown;