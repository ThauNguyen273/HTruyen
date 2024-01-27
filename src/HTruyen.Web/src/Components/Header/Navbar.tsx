import { FC } from 'react';
import UserDropdown from '../Dropdown/UserDropdown';

const getStoredToken = () => localStorage.getItem('token');

interface NavbarLink {
  href: string;
  label: string; 
}

const LINKS: NavbarLink[] = [
  { href: '/', label: 'Home'},
  { href: '/reviews', label: 'Review'},
  { href: '/category', label: 'Thể loại'},
  { href: '/search', label: 'Tìm kiếm'}
];

const Navbar: FC = () => {
  const isLoggedIn = !!getStoredToken();

  return (
    <nav className="p-4 bg-white border-gray-200 dark:bg-gray-800 dark:border-gray-600">
      <div className="max-w-screen-xl mx-auto px-4 flex flex-wrap items-center justify-between">
          <a href="/" className="flex items-center space-x-3 rtl:space-x-reverse">
            <img
              className="h-8"
              src="public\HTruyện-logos.png"
              alt="HTruyen Logo"
            />
            <span className="self-center text-2xl font-semibold whitespace-nowrap dark:text-white">
              HTruyen
            </span>
            </a>
        <ul className="mt-3  flex flex-wrap text-sm font-medium text-gray-500 dark:text-gray-400 sm:mt-0">
          {LINKS.map(link => (
            <li key={link.label}>
              <a href={link.href} className="hover:underline me-4 md:me-8">
                {link.label}
              </a>
            </li>
          ))}
        </ul>
        <div className="flex">
        {isLoggedIn ? (
        // Hiển thị avatar và dropdown nếu đã đăng nhập
          <UserDropdown avatarSrc="/public/Images/default_avatar.jpg" userName="Test" userEmail="test@gmail.com" />
        ) : (
          <>
            <a
              className="text-gray-500 dark:text-white sm:mt-0 hover:text-blue-500 dark:hover:text-blue-400 mr-4"
              href="/login"
            >
              Đăng nhập
            </a>
            <a
              className="text-gray-500 dark:text-white sm:mt-0 hover:text-blue-500 dark:hover:text-blue-400 mr-4"
              href="/signup"
            >
              Đăng ký
            </a>
          </>  
        )}
        </div>  
      </div>
    </nav>
  )
}
export default Navbar;