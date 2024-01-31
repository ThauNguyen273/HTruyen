import React from 'react';
import { Novel } from '../../Services/Novels/NovelService';
import LazyLoadImage from '../Loading/LazyLoadImage';

export interface NovelListProps {
  novels: Novel[];
}

const NovelList: React.FC<NovelListProps> = ({ novels }) => {
  return (
    <div className="flex">
      <ul className="flex"> 
        {novels.map((novel) => (
          <li key={novel.id} className="m-2 p-2 rounded overflow-hidden border border-solid border-gray-200">
            <a href={`/novel/${novel.metalTitle}/${novel.id}`} tabIndex={0}>
              <div className="flex items-center justify-center">
                  <LazyLoadImage
                    src={'/Images/novel_default.png'}
                    alt=""
                    width={100}
                    height={150}
                  />
              </div>
              <h3 className="flex font-bold">{novel.name}</h3>
              <h3 className="flex text-gray-500 dark:text-gray-400">{novel.author.authorName}</h3>
            </a>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default NovelList;