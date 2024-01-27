import React from 'react';

const HomeGrid: React.FC = () => {
  return (
    <div className="flex flex-wrap justify-center grid grid-cols-3 gap-3 p-4">
      <GridItem title="Kim Thánh Bảng" link="#" imageSrc="/NovelVip.png"/>
      <GridItem title="Diễn Đàn" link="#" imageSrc="/Forum.png"/>
      <GridItem title="BTV Chọn Lọc" link="#" imageSrc="/NovelBTV.png"/>
      <GridItem title="Sáng Tác Bảng" link="/sang-tac-bang" imageSrc="/NovelCreative.png"/>
      <GridItem title="Truyện Dịch" link="/truyen-dich" imageSrc="/NovelTranslate.png"/>
      <GridItem title="Truyện Full" link="/truyen-full" imageSrc="/NovelComplete.png"/>
    </div>
  );
};

interface GridItemProps {
  title: string;
  link: string;
  imageSrc: string;
}

const GridItem: React.FC<GridItemProps> = ({ title, link, imageSrc}) => {
  return (
    <a href={link} className="flex flex-col items-center justify-center rounded border border-solid border-gray-100" data-id="button" title={title}>
      <div>
        <img
          src={imageSrc}
          alt="Logo"
          className="h-10 w-10"
        />
      </div>
      <p className="text-center">{title}</p>
    </a>
  );
};

export default HomeGrid;