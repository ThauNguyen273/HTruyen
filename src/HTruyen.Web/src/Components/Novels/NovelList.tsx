import React from 'react';
import { Novel } from '../../Services/Novels/NovelService';

export interface NovelListProps {
  novels: Novel[];
}

const NovelList: React.FC<NovelListProps> = ({ novels }) => {
  return (
    <div className="flex">
      <ul className="flex"> 
        {novels.map((novel) => (
          <li key={novel.id} className="m-2 p-2 rounded overflow-hidden border border-solid border-gray-200">
            <a href={`/novel/${novel.metalTitle}`} tabIndex={0}>
              <div className="flex items-center">
              <img
                src={`/public/CategoryDefault.png`} // Đường dẫn đến hình ảnh mặc định
                alt=""
                width="80"
                height="120"
                className=" lazy loaded"
                data-was-processed="true"
              />
              </div>
              <h3 className="flex items-center justify-between font-bold">{novel.name}</h3>
              <h3 className="flex items-center text-gray-500 dark:text-gray-400">{novel.author.authorName}</h3>
            </a>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default NovelList;