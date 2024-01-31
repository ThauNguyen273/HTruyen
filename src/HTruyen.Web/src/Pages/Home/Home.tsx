import React from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faArrowRight } from '@fortawesome/free-solid-svg-icons';
import HomeGrid from '../../Components/Grid/HomeGrid';
import NovelUpdate from '../../Components/Novels/NovelUpdate';
import NovelCategoryOT from '../../Components/Novels/NovelCategoryOT';
import NovelCV from '../../Components/Novels/NovelCV';
import NovelCreative from '../../Components/Novels/NovelCreative';

const Home: React.FC = () => {
  
  return (
    <div className="home-content p-2">

      {/* Function */}
      <div className="w-full flex justify-center">
        <div className="w-full rounded overflow-hidden border border-solid border-gray-300 dark:border-gray-300">
          <HomeGrid/>
        </div>
      </div>
      {/*Truyện Mới Cập Nhật*/}
      <section className="p-2 mt-2 rounded overflow-hidden border border-solid border-gray-300 dark:border-gray-300">
        <h2 className="flex items-center justify-between font-bold">
            Truyện Mới Cập Nhật
            <a href="/truyen-moi-cap-nhat" className="m-2">
              <span className="flex items-center text-gray-500 dark:text-gray-400">
                Thêm
                <FontAwesomeIcon icon={faArrowRight} className="ml-1"/>
              </span>
            </a>
        </h2>
        <div>
          {/* Sử dụng component NovelList để hiển thị danh sách truyện mới cập nhật */}
          <NovelUpdate/>
        </div>
      </section>

      {/*Truyện Dịch*/}
      <section className="p-2 mt-2 rounded overflow-hidden border border-solid border-gray-300 dark:border-gray-300">
        <h2 className="flex items-center justify-between font-bold">
            Truyện Dịch
            <a href="/truyen-moi-cap-nhat" className="m-2">
              <span className="flex items-center text-gray-500 dark:text-gray-400">
                Thêm
                <FontAwesomeIcon icon={faArrowRight} className="ml-1"/>
              </span>
            </a>
        </h2>
        <div>
          {/*Sử dụng component NovelList để hiển thị danh sách truyện mới cập nhật */}
          <NovelCategoryOT/>
        </div>
      </section>

      {/*Truyện Sáng Tác*/}
      <section className="p-2 mt-2 rounded overflow-hidden border border-solid border-gray-300 dark:border-gray-300">
        <h2 className="flex items-center justify-between font-bold">
            Truyện Sáng Tác
            <a href="/truyen-moi-cap-nhat" className="m-2">
              <span className="flex items-center text-gray-500 dark:text-gray-400">
                Thêm
                <FontAwesomeIcon icon={faArrowRight} className="ml-1"/>
              </span>
            </a>
        </h2>
        <div className='flex items-center justify-between'>
          {/*Sử dụng component NovelList để hiển thị danh sách truyện mới cập nhật */}
          <NovelCreative/>
        </div>
      </section>

      {/*Truyện Convert*/}
      <section className="p-2 mt-2 rounded overflow-hidden border border-solid border-gray-300 dark:border-gray-300">
        <h2 className="flex items-center justify-between font-bold">
            Truyện Convert
            <a href="/truyen-moi-cap-nhat" className="m-2">
              <span className="flex items-center text-gray-500 dark:text-gray-400">
                Thêm
                <FontAwesomeIcon icon={faArrowRight} className="ml-1"/>
              </span>
            </a>
        </h2>
        <div>
          {/*Sử dụng component NovelList để hiển thị danh sách truyện mới cập nhật */}
          <NovelCV/>
        </div>
      </section>

      {/*Truyện Hoàn Thành*/}
      <section className="p-2 mt-2 rounded overflow-hidden border border-solid border-gray-300 dark:border-gray-300">
        <h2 className="flex items-center justify-between font-bold">
            Truyện Hoàn Thành
            <a href="/truyen-moi-cap-nhat" className="m-2">
              <span className="flex items-center text-gray-500 dark:text-gray-400">
                Thêm
                <FontAwesomeIcon icon={faArrowRight} className="ml-1"/>
              </span>
            </a>
        </h2>
        <div>
          {/*Sử dụng component NovelList để hiển thị danh sách truyện mới cập nhật */}
          <NovelCV/>
        </div>
      </section>

    </div>
  );
};

export default Home;