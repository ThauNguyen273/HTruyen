import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { GetCategory, Category } from '../../Services/Categories/CategoryService';
import NovelListVertical from '../../Components/Novels/NovelListVerTical';

const CategoryDetail: React.FC = () => {
  const { categoryMetalTile, categoryId } = useParams<{ categoryMetalTile: string, categoryId: string }>();
  const [categoryDetail, setCategoryDetail] = useState<Category | null>(null);

  useEffect(() => {
    const fetchCategoryDetail = async () => {
      try {
        if (categoryId) {
            const categoryDetailData = await GetCategory(categoryId);
            setCategoryDetail(categoryDetailData);
          }
      } catch (error) {
        console.error('Error fetching category detail:', error);
      }
    };

    fetchCategoryDetail();
  }, [categoryId]);

  if (!categoryDetail) {
    return <div>Loading...</div>;
  }

  return (
    <div className="category-content p-2">
      <div className="w-full p-2 mb-2 rounded overflow-hidden border border-solid border-gray-300 dark:border-gray-300">
        <h2 className="flex inline-block border-b-2 border-black mb-2 font-bold">
          Truyện {categoryDetail.name} Là Gì?
        </h2>
        <p>{categoryDetail.description}</p>
      </div>
      <div className="w-full p-2 mb-2 rounded overflow-hidden border border-solid border-gray-300 dark:border-gray-300">
        <h2 className="flex inline-block border-b-2 border-black mb-2 font-bold">
          Truyện {categoryDetail.name} Mới Cập Nhật
        </h2>
        <div className="w-full flex justify-center">
          <div className="w-full rounded overflow-hidden border border-solid border-gray-400 dark:border-gray-200">
            <NovelListVertical novelCategoryId={categoryId} categoryOT={1}/>
          </div>    
        </div>
      </div>  
      <div className="w-full p-2 mb-2 rounded overflow-hidden border border-solid border-gray-300 dark:border-gray-300">
        <h2 className="flex inline-block border-b-2 border-black mb-2 font-bold">
          Truyện {categoryDetail.name} Đã Hoàn Thành
        </h2>
        <div className="w-full flex justify-center">
          <div className="w-full rounded overflow-hidden border border-solid border-gray-400 dark:border-gray-200">
            <NovelListVertical novelCategoryId={categoryId} categoryOT={3}/>
          </div>    
        </div>
      </div>  
    </div>        
  );
};

export default CategoryDetail;
