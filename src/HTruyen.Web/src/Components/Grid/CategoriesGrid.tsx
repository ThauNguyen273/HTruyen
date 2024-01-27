import React, { useEffect, useState } from 'react';
import { GetList, Category } from '../../Services/Categories/CategoryService';
import { Link } from 'react-router-dom';

interface GridItemProps {
  categoryId: string
  title: string
  categoryMetalTile: string
  imageSrc: string
}

const GridItem: React.FC<GridItemProps> = ({categoryId, title, categoryMetalTile, imageSrc}) => {

  return (
    <Link to={`/${categoryMetalTile}/${categoryId}`} className="flex flex-col items-center justify-center rounded border border-solid border-gray-100" data-id="button" title={title}>
      <div>
        <img
          src={imageSrc}
          alt="logo"
          className="h-10 w-10"
        />
      </div>
      <p className="text-center">{title}</p>
    </Link>  
  )
}

const CategoriesGrid: React.FC = () => {
  const [categories, setCategories] = useState<Category[]>([]);
  
  useEffect(() => {
    const fetchCategories = async () => {
      try {
        const categoriesData = await GetList();
        setCategories(categoriesData);
      } catch (error) {
        throw error;
      }
    };

    fetchCategories();
  }, []);

  return (
    <div className="flex flex-wrap justify-center grid grid-cols-3 gap-3 p-4">
      {categories.map((category) => (
        <GridItem
          key={category.id}
          categoryId={category.id}
          title={category.name}
          categoryMetalTile={category.metalTitle}
          imageSrc="public\CategoryDefault.png"/>
      ))}
    </div>
  );
};

export default CategoriesGrid;