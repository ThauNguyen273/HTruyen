import React, { useEffect, useState } from 'react';
import { GetNovelByCategory, Novel, NovelSearchCategory } from '../../Services/Novels/NovelService';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faChevronRight } from '@fortawesome/free-solid-svg-icons';
import moment from 'moment';

interface NovelListVerticalProps {
    novelCategoryId?: string;
    categoryOT: number;
  }

const NovelListVertical: React.FC<NovelListVerticalProps> = ({novelCategoryId, categoryOT}) => {
  const [novels, setNovels] = useState<Novel[]>([]);

  useEffect(() => {
    const fetchNovels = async () => {
      try {
        if (novelCategoryId) {
            const searchCriteria: NovelSearchCategory = {
              categoryOfType: categoryOT,
              categoryId: novelCategoryId,
              status: 2,
              pageNumber: 1,
              pageSize: 20,
            };

            const resultNovels = await GetNovelByCategory(searchCriteria);
            setNovels(resultNovels);
        }
      } catch (error) {
        console.error('Error fetching novels:', error);
      }
    };

    fetchNovels();
  }, [novelCategoryId]);

  return (
    <div className="">
      {novels.map((novel, index) => (
        <a key={index} className="p-2 flex items-center justify-between" href={`/novel/${novel.metalTitle}/${novel.id}`}>
          <div className="flex-row">
            <h3 className="flex items-center font-bold mb-1">{novel.name}</h3>
            <h4 className="flex items-center text-sm text-gray-500 mb-2">{novel.author.authorName}</h4>
            <h5 className="text-sm text-orange-400">{`${moment(novel.dateUpdated).fromNow()}`}</h5>
          </div>
          <div className="flex">
            <span className="flex items-center text-gray-500 dark:text-gray-400">
                {`${novel.categoryOT} Chương`}
                <FontAwesomeIcon icon={faChevronRight} className="ml-1"/></span>
          </div>
        </a>
      ))}
    </div>
  );
};

export default NovelListVertical;