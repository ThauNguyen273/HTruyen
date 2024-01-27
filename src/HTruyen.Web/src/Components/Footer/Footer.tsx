import { FC } from 'react';

interface FooterLink {
  href: string;
  label: string; 
}

const LINKS: FooterLink[] = [
  { href: '/', label: 'About'},
  { href: '/rules', label: 'Rules'},
  { href: '/novel', label: 'Regulations'},
  { href: '/login', label: 'Licensing'},
  { href: '/contact', label: 'Contact'},
  { href: 'https://www.facebook.com/htruyenvn', label: 'Facebook'}
];

const Footer: FC = () => {
    return (
      <footer className="bottom-0 left-0 z-10 w-full p-4 bg-white border-t border-gray-200 shadow md:flex md:items-center md:justify-between md:p-4 dark:bg-gray-800 dark:border-gray-600">
        <span className="text-sm text-gray-500 dark:text-gray-400">
            &copy; 2023 - 2024 <a href="/" className="hover:underline">HTruyen</a>. All Rights Reserved.  
        </span>
  
        <ul className="mt-3 flex flex-wrap text-sm font-medium text-gray-500 dark:text-gray-400 sm:mt-0">
          {LINKS.map(link => (
            <li key={link.label}>
              <a href={link.href} className="hover:underline me-4 md:me-6">
                {link.label}
              </a>
            </li>
          ))}
        </ul>
      </footer>
    );
  };
export default Footer;